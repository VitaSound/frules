#!/usr/bin/env python3
"""
Track A — QLoRA on 0.5B (sandbox or merged JSONL).

  python3 training/train-sandbox.py
  python3 training/train-sandbox.py --dataset data/train-merged.jsonl --out output/sandbox-adapter-merged --epochs 2
"""
from __future__ import annotations

import argparse
import json
import os
import sys
from pathlib import Path

# Unsloth patches must run before transformers / trl / peft.
import unsloth  # noqa: F401
from unsloth import FastLanguageModel
from unsloth.chat_templates import get_chat_template
from datasets import Dataset
from trl import SFTConfig, SFTTrainer

ROOT = Path(__file__).resolve().parents[1]

MODEL = "Qwen/Qwen2.5-Coder-0.5B-Instruct"
DEFAULT_MAX_SEQ_LENGTH = 1024
LORA_R = 8
LORA_ALPHA = 16
LR = 2.0e-4
BATCH = 2
GRAD_ACCUM = 4


def load_jsonl(path: Path) -> Dataset:
    rows: list[dict] = []
    with path.open(encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if not line:
                continue
            obj = json.loads(line)
            if "messages" not in obj:
                raise ValueError(f"missing messages: {path}")
            rows.append({"messages": obj["messages"]})
    if not rows:
        raise SystemExit(f"empty dataset: {path}")
    return Dataset.from_list(rows)


def _proxy_hint() -> None:
    socks = os.environ.get("ALL_PROXY") or os.environ.get("all_proxy") or ""
    if "socks" in socks.lower():
        try:
            import socksio  # noqa: F401
        except ImportError:
            print(
                "hint: ALL_PROXY is SOCKS but socksio is missing — Hugging Face may fail.\n"
                "  unset ALL_PROXY   OR   pip install 'httpx[socks]'   OR use HTTP_PROXY only",
                file=sys.stderr,
            )


def parse_args() -> argparse.Namespace:
    ap = argparse.ArgumentParser(description="QLoRA train Qwen2.5-Coder-0.5B")
    ap.add_argument(
        "--dataset",
        type=Path,
        default=ROOT / "data" / "sandbox.jsonl",
        help="JSONL with messages[] (default: sandbox)",
    )
    ap.add_argument(
        "--out",
        type=Path,
        default=ROOT / "output" / "sandbox-adapter",
        help="LoRA output directory",
    )
    ap.add_argument("--epochs", type=int, default=1)
    ap.add_argument(
        "--learning-rate",
        type=float,
        default=LR,
        help="Peak LR (default 2e-4)",
    )
    ap.add_argument(
        "--max-seq",
        type=int,
        default=DEFAULT_MAX_SEQ_LENGTH,
        help="Max sequence length (default 1024; use 2048 for train-merged.jsonl)",
    )
    return ap.parse_args()


def main() -> None:
    args = parse_args()
    dataset = args.dataset if args.dataset.is_absolute() else ROOT / args.dataset
    out_dir = args.out if args.out.is_absolute() else ROOT / args.out

    if not dataset.is_file():
        raise SystemExit(
            f"missing {dataset}\n"
            "  sandbox:  python3 scripts/build-dataset.py --sandbox --validate\n"
            "  merged:   bash scripts/build-train-merged.sh"
        )

    os.makedirs(out_dir, exist_ok=True)
    _proxy_hint()
    hf_home = os.environ.get("HF_HOME")
    if hf_home:
        print(f"HF_HOME={hf_home}")
    n_lines = sum(1 for _ in dataset.open())
    print(f"dataset: {dataset} ({n_lines} lines)")
    print(f"output:  {out_dir}")
    print(f"epochs:  {args.epochs}")
    print(f"max_seq: {args.max_seq}")

    model, tokenizer = FastLanguageModel.from_pretrained(
        model_name=MODEL,
        max_seq_length=args.max_seq,
        load_in_4bit=True,
    )
    model = FastLanguageModel.get_peft_model(
        model,
        r=LORA_R,
        lora_alpha=LORA_ALPHA,
        lora_dropout=0,
        target_modules=[
            "q_proj",
            "k_proj",
            "v_proj",
            "o_proj",
            "gate_proj",
            "up_proj",
            "down_proj",
        ],
        bias="none",
        use_gradient_checkpointing="unsloth",
        random_state=3407,
    )
    tokenizer = get_chat_template(tokenizer, chat_template="qwen-2.5")

    raw = load_jsonl(dataset)

    def to_text(batch: dict) -> dict:
        texts = [
            tokenizer.apply_chat_template(
                convo,
                tokenize=False,
                add_generation_prompt=False,
            )
            for convo in batch["messages"]
        ]
        return {"text": texts}

    train_ds = raw.map(to_text, batched=True, remove_columns=raw.column_names)

    trainer = SFTTrainer(
        model=model,
        tokenizer=tokenizer,
        train_dataset=train_ds,
        dataset_text_field="text",
        max_seq_length=args.max_seq,
        packing=False,
        args=SFTConfig(
            output_dir=str(out_dir),
            per_device_train_batch_size=BATCH,
            gradient_accumulation_steps=GRAD_ACCUM,
            num_train_epochs=args.epochs,
            learning_rate=args.learning_rate,
            logging_steps=1,
            save_strategy="epoch",
            optim="adamw_8bit",
            warmup_steps=max(1, len(train_ds) // 10),
            lr_scheduler_type="linear",
            seed=3407,
            report_to="none",
        ),
    )
    trainer.train()
    model.save_pretrained(out_dir)
    tokenizer.save_pretrained(out_dir)
    print(f"done -> {out_dir}")


if __name__ == "__main__":
    main()

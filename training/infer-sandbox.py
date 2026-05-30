#!/usr/bin/env python3
"""
Smoke inference for Track A adapter (output/sandbox-adapter).

  source .venv-train/bin/activate
  export HF_HOME="$HOME/frules/output/hf-cache"
  python3 training/infer-sandbox.py
  python3 training/infer-sandbox.py --no-adapter   # base model only
"""
from __future__ import annotations

import argparse
import sys
from pathlib import Path

import unsloth  # noqa: F401
from peft import PeftModel
from unsloth import FastLanguageModel
from unsloth.chat_templates import get_chat_template

ROOT = Path(__file__).resolve().parents[1]
DEFAULT_ADAPTER = ROOT / "output" / "sandbox-adapter"
MODEL = "Qwen/Qwen2.5-Coder-0.5B-Instruct"
DEFAULT_PROMPT = (
    "Implement : gcd ( a b -- g ). Gforth only. "
    "Output only colon definition(s)."
)


def main() -> None:
    ap = argparse.ArgumentParser()
    ap.add_argument("--no-adapter", action="store_true", help="base model only")
    ap.add_argument(
        "--adapter",
        type=Path,
        default=DEFAULT_ADAPTER,
        help="LoRA dir (default: output/sandbox-adapter)",
    )
    ap.add_argument("--prompt", default=DEFAULT_PROMPT)
    args = ap.parse_args()

    adapter = args.adapter if args.adapter.is_absolute() else ROOT / args.adapter
    if not args.no_adapter and not (adapter / "adapter_config.json").is_file():
        raise SystemExit(f"missing adapter: {adapter}")

    model, tok = FastLanguageModel.from_pretrained(
        model_name=MODEL,
        max_seq_length=1024,
        load_in_4bit=True,
    )
    if not args.no_adapter:
        model = PeftModel.from_pretrained(model, str(adapter))
    FastLanguageModel.for_inference(model)
    tok = get_chat_template(tok, chat_template="qwen-2.5")

    msgs = [{"role": "user", "content": args.prompt}]
    batch = tok.apply_chat_template(
        msgs,
        tokenize=True,
        add_generation_prompt=True,
        return_tensors="pt",
        return_dict=True,
    )
    batch = {k: v.to("cuda") for k, v in batch.items()}
    out = model.generate(**batch, max_new_tokens=256, use_cache=True)
    n_in = batch["input_ids"].shape[1]
    text = tok.decode(out[0][n_in:], skip_special_tokens=True)
    label = "base" if args.no_adapter else "lora"
    print(f"--- {label} ---")
    print(text.strip())


if __name__ == "__main__":
    main()

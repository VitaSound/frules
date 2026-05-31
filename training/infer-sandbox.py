#!/usr/bin/env python3
"""
Smoke inference for Track A adapter — same chat roles as SFT JSONL.

  python3 training/infer-sandbox.py --adapter output/sandbox-adapter-fixed
  python3 training/infer-sandbox.py --from-jsonl data/train-simple.jsonl --word gcd
  python3 training/infer-sandbox.py --no-adapter --system short --word gcd
"""
from __future__ import annotations

import argparse
import json
import sys
from pathlib import Path

import unsloth  # noqa: F401
from peft import PeftModel
from unsloth import FastLanguageModel
from unsloth.chat_templates import get_chat_template

ROOT = Path(__file__).resolve().parents[1]
SCRIPTS = ROOT / "scripts"
if str(SCRIPTS) not in sys.path:
    sys.path.insert(0, str(SCRIPTS))

from sft_prompts import resolve_system  # noqa: E402

DEFAULT_ADAPTER = ROOT / "output" / "sandbox-adapter"
MODEL = "Qwen/Qwen2.5-Coder-0.5B-Instruct"
DEFAULT_DATASET = ROOT / "data" / "train-simple.jsonl"


def load_messages_from_jsonl(path: Path, word: str) -> list[dict]:
    with path.open(encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if not line:
                continue
            obj = json.loads(line)
            if obj.get("word") == word:
                return obj["messages"][:2]  # system + user only
    raise SystemExit(f"word {word!r} not found in {path}")


def default_user_prompt(word: str, effect: str = "( a b -- g )") -> str:
    return (
        f"Implement the Forth word `{word}` with stack effect {effect}.\n\n"
        f"Source: {word}.fs\n\n"
        "Requirements:\n"
        "- Gforth\n"
        "- Stack-effect comment on every colon definition you add\n"
        "- Postfix Forth only\n"
        "- Output only the colon definition(s), no explanation"
    )


def build_messages(args: argparse.Namespace) -> list[dict]:
    if args.from_jsonl and args.word:
        path = args.from_jsonl if args.from_jsonl.is_absolute() else ROOT / args.from_jsonl
        return load_messages_from_jsonl(path, args.word)

    system_mode = args.system
    if system_mode == "none":
        user = args.prompt or default_user_prompt(args.word or "gcd")
        return [{"role": "user", "content": user}]

    system = resolve_system(system_mode)
    if args.prompt:
        user = args.prompt
    elif args.word:
        user = default_user_prompt(args.word, args.effect)
    else:
        user = default_user_prompt("gcd")
    return [
        {"role": "system", "content": system},
        {"role": "user", "content": user},
    ]


def main() -> None:
    ap = argparse.ArgumentParser()
    ap.add_argument("--no-adapter", action="store_true", help="base model only")
    ap.add_argument(
        "--adapter",
        type=Path,
        default=DEFAULT_ADAPTER,
        help="LoRA dir (default: output/sandbox-adapter)",
    )
    ap.add_argument("--prompt", help="Custom user prompt (overrides --word)")
    ap.add_argument(
        "--word",
        default="gcd",
        help="Word name for default user prompt (default: gcd)",
    )
    ap.add_argument(
        "--effect",
        default="( a b -- g )",
        help="Stack effect for --word default prompt",
    )
    ap.add_argument(
        "--system",
        choices=("short", "full", "none"),
        default="short",
        help="system role: short=train parity (default), full=Ollama blob, none=old infer",
    )
    ap.add_argument(
        "--from-jsonl",
        type=Path,
        help="Use exact system+user from JSONL row matching --word",
    )
    ap.add_argument("--max-new-tokens", type=int, default=128)
    args = ap.parse_args()

    adapter = args.adapter if args.adapter.is_absolute() else ROOT / args.adapter
    if not args.no_adapter and not (adapter / "adapter_config.json").is_file():
        raise SystemExit(f"missing adapter: {adapter}")

    msgs = build_messages(args)

    model, tok = FastLanguageModel.from_pretrained(
        model_name=MODEL,
        max_seq_length=1024,
        load_in_4bit=True,
    )
    if not args.no_adapter:
        model = PeftModel.from_pretrained(model, str(adapter))
    FastLanguageModel.for_inference(model)
    tok = get_chat_template(tok, chat_template="qwen-2.5")

    batch = tok.apply_chat_template(
        msgs,
        tokenize=True,
        add_generation_prompt=True,
        return_tensors="pt",
        return_dict=True,
    )
    batch = {k: v.to("cuda") for k, v in batch.items()}
    out = model.generate(**batch, max_new_tokens=args.max_new_tokens, use_cache=True)
    n_in = batch["input_ids"].shape[1]
    text = tok.decode(out[0][n_in:], skip_special_tokens=True)
    label = "base" if args.no_adapter else "lora"
    print(f"--- {label} system={args.system} ---")
    if args.from_jsonl:
        print(f"--- from {args.from_jsonl} word={args.word} ---")
    print(text.strip())


if __name__ == "__main__":
    main()

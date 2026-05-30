#!/usr/bin/env python3
"""
Merge Track A LoRA adapter into full weights (Unsloth), optional GGUF for Ollama/LM Studio.

  source .venv-train/bin/activate
  export HF_HOME="$HOME/frules/output/hf-cache"
  python3 training/merge-sandbox.py
  python3 training/merge-sandbox.py --adapter output/sandbox-adapter-merged --out output/merged-0.5b
  python3 training/merge-sandbox.py --adapter output/sandbox-adapter-merged --gguf output/forth-gforth-q4_K_M.gguf

Needs free RAM (~4–8 GB for 0.5B merged_16bit). GPU loads base+adapter; merge uses CPU buffers.
Stop Ollama / other GPU jobs before running.
"""
from __future__ import annotations

import argparse
import gc
import sys
from pathlib import Path

import unsloth  # noqa: F401
from peft import PeftModel
from unsloth import FastLanguageModel
from unsloth.save import unsloth_generic_save, unsloth_save_pretrained_gguf

ROOT = Path(__file__).resolve().parents[1]
MODEL = "Qwen/Qwen2.5-Coder-0.5B-Instruct"
DEFAULT_ADAPTER = ROOT / "output" / "sandbox-adapter-merged"
DEFAULT_MERGED = ROOT / "output" / "merged-0.5b"
DEFAULT_GGUF = ROOT / "output" / "forth-gforth-q4_K_M.gguf"


def parse_args() -> argparse.Namespace:
    ap = argparse.ArgumentParser(description="Merge 0.5B LoRA adapter (Unsloth)")
    ap.add_argument(
        "--adapter",
        type=Path,
        default=DEFAULT_ADAPTER,
        help="LoRA dir with adapter_config.json",
    )
    ap.add_argument(
        "--out",
        type=Path,
        default=DEFAULT_MERGED,
        help="HF merged weights (merged_16bit)",
    )
    ap.add_argument(
        "--gguf",
        type=Path,
        default=None,
        metavar="PATH",
        help="Also write GGUF (e.g. output/forth-gforth-q4_K_M.gguf)",
    )
    ap.add_argument(
        "--quant",
        default="q4_k_m",
        help="GGUF quant method (default q4_k_m)",
    )
    ap.add_argument(
        "--no-merged-hf",
        action="store_true",
        help="Only --gguf, skip saving merged HF folder",
    )
    return ap.parse_args()


def main() -> None:
    args = parse_args()
    adapter = args.adapter if args.adapter.is_absolute() else ROOT / args.adapter
    out_dir = args.out if args.out.is_absolute() else ROOT / args.out
    if not (adapter / "adapter_config.json").is_file():
        raise SystemExit(f"missing adapter: {adapter}")

    print(f"base:    {MODEL}")
    print(f"adapter: {adapter}")
    model, tokenizer = FastLanguageModel.from_pretrained(
        model_name=MODEL,
        max_seq_length=1024,
        load_in_4bit=True,
    )
    model = PeftModel.from_pretrained(model, str(adapter))
    if not isinstance(model, PeftModel):
        raise SystemExit("internal: expected PeftModel after loading adapter")

    # PeftModel.__getattr__ forwards save_pretrained_* to the 4-bit base; self
    # becomes Qwen2ForCausalLM without LoRA → transformers 5.5 NotImplementedError.
    # Call Unsloth save helpers with the PeftModel explicitly.
    if not args.no_merged_hf:
        out_dir.mkdir(parents=True, exist_ok=True)
        print(f"merge -> {out_dir} (merged_16bit, may take several minutes)")
        unsloth_generic_save(
            model=model,
            tokenizer=tokenizer,
            save_directory=str(out_dir),
            save_method="merged_16bit",
            safe_serialization=False,
        )
        print(f"done HF merged: {out_dir}")

    if args.gguf is not None:
        gguf = args.gguf if args.gguf.is_absolute() else ROOT / args.gguf
        gguf.parent.mkdir(parents=True, exist_ok=True)
        print(f"gguf -> {gguf} ({args.quant})")
        unsloth_save_pretrained_gguf(
            model,
            str(gguf),
            tokenizer,
            quantization_method=args.quant,
        )
        print(f"done GGUF: {gguf}")
        print("Ollama: ollama create forth-gforth -f training/Modelfile.example")
        print(f"  (set FROM to {gguf})")

    if args.no_merged_hf and args.gguf is None:
        raise SystemExit("nothing to do: pass --out and/or --gguf")

    del model
    gc.collect()


if __name__ == "__main__":
    main()

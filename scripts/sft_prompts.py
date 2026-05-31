#!/usr/bin/env python3
"""Shared SFT system prompts for Track A/B JSONL and infer parity."""

from __future__ import annotations

from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
RULES = ROOT / "rules"

SYSTEM_FILES = (
    "forth-dialect-gforth.mdc",
    "forth-stack.mdc",
    "forth-anti-patterns.mdc",
)

TRAIN_SYSTEM_SHORT = (
    "You write Gforth. Postfix Forth only — never C, Python, or infix.\n"
    "Every colon definition documents stack effects ( before -- after ).\n"
    "Output only colon definition(s), no explanation."
)


def strip_mdc(text: str) -> str:
    if text.startswith("---"):
        end = text.find("---", 3)
        if end != -1:
            return text[end + 3 :].lstrip()
    return text


def build_full_system_prompt() -> str:
    parts = [
        "You write Gforth. Postfix Forth only — never C, Python, or infix.",
        (ROOT / "AGENTS.md").read_text(encoding="utf-8").strip(),
        "",
    ]
    for name in SYSTEM_FILES:
        path = RULES / name
        if path.is_file():
            parts.append(strip_mdc(path.read_text(encoding="utf-8")).strip())
            parts.append("")
    return "\n".join(parts).strip()


def resolve_system(mode: str) -> str:
    if mode == "short":
        return TRAIN_SYSTEM_SHORT
    if mode == "full":
        return build_full_system_prompt()
    raise ValueError(f"unknown system mode: {mode!r} (use short or full)")

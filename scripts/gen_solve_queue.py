#!/usr/bin/env python3
"""Regenerate data/challenge-solutions/SOLVE-QUEUE.md from eval-slices.yaml."""
from __future__ import annotations

import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
SLICES = ROOT / "tests/challenges/eval-slices.yaml"
CHALLENGES = ROOT / "tests/challenges"
OUT = ROOT / "data/challenge-solutions/SOLVE-QUEUE.md"


def train_files() -> list[str]:
    text = SLICES.read_text()
    in_tf = False
    files: list[str] = []
    for line in text.splitlines():
        if line.strip() == "train_for_sft:":
            in_tf = True
            continue
        if in_tf:
            if line.strip().startswith("eval_holdout:"):
                break
            m = re.match(r"\s+-\s+(\S+\.fs)\s*$", line)
            if m:
                files.append(m.group(1))
    return sorted(files, key=lambda f: int(f.split("-", 1)[0]))


def challenge_word(path: Path) -> str:
    """Word named in CHALLENGE header (\\   : foo  ( ... )), not scaffold."""
    for line in path.read_text().splitlines():
        m = re.search(r"\\\s+:\s+(\S+)\s+\(", line)
        if m:
            return m.group(1)
    return "?"


def main() -> None:
    files = train_files()
    old_text = OUT.read_text() if OUT.exists() else ""
    done = len(re.findall(r"^- \[x\] \S+\.fs", old_text, re.M))

    complete = done >= len(files) and len(files) > 0
    if complete:
        status_en = (
            "**Status:** solve phase **complete** (all train items verified). "
            "Do not reopen for batch solving; use for SFT export and as reference. "
            "Model **validation** → `eval_holdout` only — see `docs/CHALLENGE-TO-TRAIN.md`."
        )
        status_ru = (
            "**Статус:** фаза solve **завершена** (все train). "
            "Дальше: SFT (`build-challenge-dataset.py`) и **валидация моделей** только на `eval_holdout`."
        )
    else:
        status_en = f"**Status:** solve phase **in progress** ({done} / {len(files)})."
        status_ru = f"**Статус:** в работе ({done} / {len(files)})."
    lines = [
        "# Solve queue (`train_for_sft`)",
        "",
        status_en,
        "",
        status_ru,
        "",
        f"Progress: **{done} / {len(files)}**",
        "",
        "Historical checklist. Agent protocol (archived when complete): "
        "[`docs/AGENT-SOLVE-CHALLENGES.md`](../docs/AGENT-SOLVE-CHALLENGES.md).",
        "",
        "Do **not** put solutions in files listed only under `eval_holdout` in `eval-slices.yaml`.",
        "",
    ]
    for f in files:
        w = challenge_word(CHALLENGES / f)
        mark = "[x]" if re.search(rf"^- \[x\] {re.escape(f)}", old_text, re.M) else "[ ]"
        lines.append(f"- {mark} {f}  (`{w}`)")

    OUT.parent.mkdir(parents=True, exist_ok=True)
    OUT.write_text("\n".join(lines) + "\n")
    print(f"Wrote {OUT} ({len(files)} items, {done} done)")


if __name__ == "__main__":
    main()

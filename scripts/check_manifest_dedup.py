#!/usr/bin/env python3
"""Verify unique pattern_key across seeds + manifest challenges."""

from __future__ import annotations

import sys
from pathlib import Path

try:
    import yaml
except ImportError:
    yaml = None  # type: ignore

ROOT = Path(__file__).resolve().parent.parent
MANIFEST = ROOT / "tests" / "challenges" / "manifest.yaml"
SCRIPTS = Path(__file__).resolve().parent
sys.path.insert(0, str(SCRIPTS))

from challenge_catalog import get_challenges  # noqa: E402

SEED_KEYS = {
    "scalar-bounds",
    "scalar-pair-extrema",
    "string-reverse-in-place",
    "string-cipher-mod",
    "paren-balance-round",
    "table-encode-roman",
}


def main() -> int:
    challenges = get_challenges()
    keys: list[tuple[str, str]] = []
    for c in challenges:
        keys.append((c["pattern_key"], f"{c['id']:03d}-{c['slug']}.fs"))
    for k in SEED_KEYS:
        keys.append((k, f"seed:{k}"))

    seen: dict[str, str] = {}
    dupes = []
    for pk, loc in keys:
        if pk in seen:
            dupes.append((pk, seen[pk], loc))
        else:
            seen[pk] = loc

    if dupes:
        print("DUPLICATE pattern_key:", file=sys.stderr)
        for pk, a, b in dupes:
            print(f"  {pk}: {a} vs {b}", file=sys.stderr)
        return 1

    print(f"OK: {len(seen)} unique pattern_key ({len(challenges)} generated + {len(SEED_KEYS)} seeds)")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

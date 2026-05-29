#!/usr/bin/env python3
"""Print Rosetta Code hint paths for a challenge file or slug.

Usage (from repo root):
  python3 scripts/rosettacode-hint.py tests/challenges/134-edit-distance.fs
  python3 scripts/rosettacode-hint.py edit-distance
  python3 scripts/rosettacode-hint.py --list
"""

from __future__ import annotations

import argparse
import sys
from pathlib import Path

try:
    import yaml
except ImportError:
    print("ERROR: need PyYAML (python3-yaml)", file=sys.stderr)
    sys.exit(1)

REPO = Path(__file__).resolve().parents[1]
ROSETTA = REPO / "sources" / "rosettacode-forth"
LINKS = ROSETTA / "challenge-links.yaml"
INDEX = ROSETTA / "INDEX.md"


def load_links() -> dict:
    data = yaml.safe_load(LINKS.read_text(encoding="utf-8")) or {}
    return data.get("links", {})


def resolve_key(arg: str) -> str | None:
    arg = arg.strip()
    if arg.endswith(".fs"):
        name = Path(arg).name
        if (REPO / "tests" / "challenges" / name).exists():
            return name
        return name if name in load_links() else None
    # slug like edit-distance -> find NNN-edit-distance.fs
    links = load_links()
    for key in links:
        if arg in key:
            return key
    ch_dir = REPO / "tests" / "challenges"
    matches = sorted(ch_dir.glob(f"*-{arg}.fs"))
    if len(matches) == 1:
        return matches[0].name
    if matches:
        return matches[0].name
    return None


def format_entry(key: str, entry: dict) -> str:
    kind = entry.get("kind", "ref")
    lines = [f"Challenge: {key}", f"kind: {kind}", "Rosetta paths:"]
    for slug in entry.get("rosetta", []):
        task = ROSETTA / slug
        if task.is_dir():
            files = sorted(p.name for p in task.iterdir() if p.is_file())
            lines.append(f"  sources/rosettacode-forth/{slug}/  ({', '.join(files)})")
        else:
            lines.append(f"  sources/rosettacode-forth/{slug}/  (MISSING — fix challenge-links.yaml)")
    wiki = ROSETTA / "INDEX.md"
    lines.append(f"Catalog: sources/rosettacode-forth/INDEX.md")
    lines.append(f"Extend:  sources/rosettacode-forth/challenge-links.yaml")
    return "\n".join(lines)


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("target", nargs="?", help="challenge file or slug")
    parser.add_argument("--list", action="store_true", help="list all curated links")
    args = parser.parse_args()

    links = load_links()

    if args.list:
        for key in sorted(links):
            slugs = ", ".join(links[key].get("rosetta", []))
            print(f"{key}\t{links[key].get('kind', 'ref')}\t{slugs}")
        return 0

    if not args.target:
        parser.print_help()
        return 2

    key = resolve_key(args.target)
    if not key or key not in links:
        print(f"No curated Rosetta hint for {args.target!r}.", file=sys.stderr)
        print("Try: rg -l 'keyword' sources/rosettacode-forth/", file=sys.stderr)
        print(f"Or add a row to {LINKS.relative_to(REPO)}", file=sys.stderr)
        return 1

    print(format_entry(key, links[key]))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

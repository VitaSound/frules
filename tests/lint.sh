#!/usr/bin/env bash
# English-only lint for agent rule files (Cyrillic must not appear in rules/templates).
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/.." && pwd)"

exec python3 - "$ROOT" <<'PY'
import re
import sys
from pathlib import Path

root = Path(sys.argv[1])
pat = re.compile(r"[А-Яа-яЁё]")
fail = False

for sub in ("rules", "templates"):
    d = root / sub
    if not d.is_dir():
        continue
    for path in sorted(d.glob("*.mdc")):
        text = path.read_text(encoding="utf-8")
        for lineno, line in enumerate(text.splitlines(), 1):
            if pat.search(line):
                rel = path.relative_to(root)
                print(f"FAIL: Cyrillic in {rel}:{lineno}: {line.strip()[:100]}")
                fail = True

if fail:
    print("lint: English-only check failed (rules/*.mdc, templates/*.mdc)", file=sys.stderr)
    sys.exit(1)

print("ok   lint English-only (rules, templates)")
PY

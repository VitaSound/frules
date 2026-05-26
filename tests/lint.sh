#!/usr/bin/env bash
# English-only lint: rules/*.mdc and templates/*.mdc must not contain Cyrillic.
set -euo pipefail

cd "$(dirname "$0")/.."

# Cyrillic letters (Russian block + Ё/ё). grep -E '[А-Я…]' needs a Cyrillic locale;
# \p{Cyrillic} works with GNU grep -P under C.UTF-8.
pattern='\p{Cyrillic}'
fail=0

check_dir() {
  local dir="$1" f hits
  for f in "$dir"/*.mdc; do
    [ -f "$f" ] || continue
    hits=$(grep -nP "$pattern" "$f" 2>/dev/null || true)
    if [[ -n "$hits" ]]; then
      echo "FAIL: non-English text in $f"
      sed 's/^/    /' <<<"$hits"
      fail=1
    fi
  done
}

check_dir rules
check_dir templates

if (( fail )); then
  echo "lint: English-only check FAILED" >&2
  exit 1
fi

echo "lint: English-only ok"

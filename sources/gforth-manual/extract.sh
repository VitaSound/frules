#!/usr/bin/env bash
# extract.sh — fetch full Gforth manual from gforth.org/manual/
# Idempotent: re-run safely. Uses wget or curl (honours http(s)_proxy).
# Optional: pandoc to rebuild *.md from upstream/*.html
#
# License: Gforth manual is GPL (same as Gforth). See https://gforth.org/

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

BASE="https://gforth.org/manual"
PARALLEL="${PARALLEL:-12}"

need_fetch() {
  command -v wget >/dev/null 2>&1 && return 0
  command -v curl >/dev/null 2>&1 && return 0
  echo "ERROR: need wget or curl" >&2
  exit 1
}

upstream_path() {
  # Keep URL-encoded names on disk; normalize legacy %5F002d for paths.
  printf 'upstream/%s' "${1//%5F002d/-}"
}

md_slug() {
  python3 - "$1" <<'PY'
import sys
name = sys.argv[1]
name = name.replace("%5F002d", "-")
if name.lower().endswith(".html"):
    name = name[:-5]
print(name.lower().replace("_", "-"))
PY
}

fetch_one() {
  local page="$1"
  local out
  out="$(upstream_path "$page")"
  mkdir -p upstream
  if [ -f "$out" ]; then
    return 0
  fi
  if command -v wget >/dev/null 2>&1; then
    wget -q -O "$out" "${BASE}/${page}"
  else
    curl -fsSL -o "$out" "${BASE}/${page}"
  fi
}

discover_pages() {
  local idx
  idx="$(upstream_path index.html)"
  if [ ! -f "$idx" ]; then
    echo "==> fetch index"
    fetch_one index.html
  fi
  python3 - "$idx" <<'PY'
import re, sys
from pathlib import Path
html = Path(sys.argv[1]).read_text(errors="replace")
pages = sorted(set(re.findall(r'href="([A-Za-z0-9%_.-]+\.html)', html)))
if "index.html" not in pages:
    pages.insert(0, "index.html")
for p in pages:
    print(p)
PY
}

need_fetch

echo "==> discover pages from index"
mapfile -t PAGES < <(discover_pages)
printf '%s\n' "${PAGES[@]}" > pages.list
echo "==> ${#PAGES[@]} pages in pages.list"

echo "==> fetch HTML (parallel=${PARALLEL})"
failed=0
printf '%s\n' "${PAGES[@]}" | xargs -r -P "$PARALLEL" -I {} bash -c '
  page="$1"
  out="upstream/${page//%5F002d/-}"
  mkdir -p upstream
  if [ -f "$out" ]; then exit 0; fi
  if command -v wget >/dev/null 2>&1; then
    wget -q -O "$out" "'"${BASE}"'/${page}"
  else
    curl -fsSL -o "$out" "'"${BASE}"'/${page}"
  fi
' _ {} || failed=1
missing=0
while IFS= read -r page; do
  out="$(upstream_path "$page")"
  [ -f "$out" ] || { echo "ERROR: missing upstream: $page" >&2; missing=$((missing + 1)); }
done < pages.list
if [ "$missing" -gt 0 ]; then
  echo "ERROR: $missing page(s) not fetched" >&2
  exit 1
fi
[ "$failed" -eq 0 ] || true

if ! command -v pandoc >/dev/null 2>&1; then
  echo "==> upstream/ fetched; install pandoc to rebuild *.md"
  echo "==> done ($(find upstream -name '*.html' | wc -l) HTML files)"
  exit 0
fi

echo "==> convert HTML → markdown (pandoc)"
for page in "${PAGES[@]}"; do
  html="$(upstream_path "$page")"
  slug="$(md_slug "$page")"
  out="${slug}.md"
  pandoc -f html -t gfm --wrap=none "$html" -o "${out}.tmp"
  {
    echo "> Source: ${BASE}/${page}"
    echo
    cat "${out}.tmp"
  } > "$out"
  rm -f "${out}.tmp"
done

echo "==> done ($(find upstream -name '*.html' | wc -l) HTML, $(ls -1 *.md 2>/dev/null | wc -l) MD)"

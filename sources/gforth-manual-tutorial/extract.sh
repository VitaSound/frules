#!/usr/bin/env bash
# extract.sh — fetch Gforth manual Tutorial chapter from gforth.org
# Idempotent: re-run safely. Requires wget or curl; optional html2text for MD rebuild.
#
# Outputs:
#   upstream/*.html   raw HTML pages
#   *.md              markdown (if html2text or pandoc available)
#
# License: Gforth manual is GPL (same as Gforth). See https://gforth.org/

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

BASE="https://gforth.org/manual"

PAGES=(
  Tutorial.html
  Starting-Gforth-Tutorial.html
  Syntax-Tutorial.html
  Crash-Course-Tutorial.html
  Stack-Tutorial.html
  Arithmetics-Tutorial.html
  Stack-Manipulation-Tutorial.html
  Using-files-for-Forth-code-Tutorial.html
  Comments-Tutorial.html
  Colon-Definitions-Tutorial.html
  Decompilation-Tutorial.html
  Stack%5F002dEffect-Comments-Tutorial.html
  Types-Tutorial.html
  Factoring-Tutorial.html
  Designing-the-stack-effect-Tutorial.html
  Local-Variables-Tutorial.html
  Conditional-execution-Tutorial.html
  Flags-and-Comparisons-Tutorial.html
  General-Loops-Tutorial.html
  Counted-loops-Tutorial.html
  Recursion-Tutorial.html
  Leaving-definitions-or-loops-Tutorial.html
  Return-Stack-Tutorial.html
  Memory-Tutorial.html
  Characters-and-Strings-Tutorial.html
  Alignment-Tutorial.html
  Floating-Point-Tutorial.html
  Files-Tutorial.html
  Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html
  Execution-Tokens-Tutorial.html
  Exceptions-Tutorial.html
  Defining-Words-Tutorial.html
  Arrays-and-Records-Tutorial.html
  POSTPONE-Tutorial.html
  Literal-Tutorial.html
  Advanced-macros-Tutorial.html
  Compilation-Tokens-Tutorial.html
  Wordlists-and-Search-Order-Tutorial.html
)

need_fetch() {
  command -v wget >/dev/null 2>&1 && return 0
  command -v curl >/dev/null 2>&1 && return 0
  echo "ERROR: need wget or curl" >&2
  exit 1
}

fetch_one() {
  local page="$1"
  local out="upstream/${page//%5F002d/-}"
  mkdir -p upstream
  if [ -f "$out" ]; then
    echo "==> skip (exists): $page"
    return 0
  fi
  echo "==> fetch: $page"
  if command -v wget >/dev/null 2>&1; then
    wget -q -O "$out" "${BASE}/${page}"
  else
    curl -fsSL -o "$out" "${BASE}/${page}"
  fi
}

need_fetch
for page in "${PAGES[@]}"; do
  fetch_one "$page"
done

if command -v html2text >/dev/null 2>&1; then
  echo "==> converting HTML → markdown (html2text)"
  for page in "${PAGES[@]}"; do
    html="upstream/${page//%5F002d/-}"
    base="${html#upstream/}"
    base="${base%.html}"
    base="${base%-Tutorial}"
    base="$(echo "$base" | tr '[:upper:]' '[:lower:]')"
    html2text -width 0 "$html" > "${base}.md.tmp"
    {
      echo "> Source: ${BASE}/${page}"
      echo
      cat "${base}.md.tmp"
    } > "${base}.md"
    rm -f "${base}.md.tmp"
  done
elif command -v pandoc >/dev/null 2>&1; then
  echo "==> converting HTML → markdown (pandoc)"
  for page in "${PAGES[@]}"; do
    html="upstream/${page//%5F002d/-}"
    base="${html#upstream/}"
    base="${base%.html}"
    base="${base%-Tutorial}"
    base="$(echo "$base" | tr '[:upper:]' '[:lower:]')"
    pandoc -f html -t gfm --wrap=none "$html" -o "${base}.md.tmp"
    {
      echo "> Source: ${BASE}/${page}"
      echo
      cat "${base}.md.tmp"
    } > "${base}.md"
    rm -f "${base}.md.tmp"
  done
else
  echo "==> upstream/ fetched; install html2text or pandoc to rebuild *.md"
fi

echo "==> done ($(ls upstream/*.html 2>/dev/null | wc -l) HTML files)"

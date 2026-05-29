#!/usr/bin/env bash
# fetch.sh — vendored copy of Rosetta Code Forth examples from RosettaCodeData.
# Idempotent: re-run safely. Requires git.
#
# Upstream: https://github.com/acmeism/RosettaCodeData/tree/main/Lang/Forth
# Wiki:     https://rosettacode.org/wiki/Category:Forth
#
# Lang/Forth entries are symlinks to Task/<slug>/Forth; this script copies
# with symlinks dereferenced so frules does not need the full Task/ tree.

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

REPO_URL="https://github.com/acmeism/RosettaCodeData.git"
BRANCH="main"
UPSTREAM="${UPSTREAM:-upstream}"

need() {
  command -v "$1" >/dev/null 2>&1 || {
    echo "ERROR: missing tool '$1'. Install with: $2" >&2
    exit 1
  }
}
need git "sudo apt install git"

if [[ ! -d "$UPSTREAM/.git" ]]; then
  git clone --depth 1 --branch "$BRANCH" "$REPO_URL" "$UPSTREAM"
else
  git -C "$UPSTREAM" fetch --depth 1 origin "$BRANCH"
  git -C "$UPSTREAM" checkout "$BRANCH"
  git -C "$UPSTREAM" reset --hard "origin/$BRANCH"
fi

# Preserve meta files; replace task dirs only.
for item in "$UPSTREAM/Lang/Forth"/*; do
  base="$(basename "$item")"
  case "$base" in
    00-LANG.txt|00-META.yaml) cp "$item" "./$base" ;;
    *)
      rm -rf "./$base"
      cp -rL "$item" "./$base"
      ;;
  esac
done

echo "Rosetta Code Forth examples refreshed from $REPO_URL ($BRANCH)."
python3 gen-index.py

#!/usr/bin/env bash
# extract.sh — fetch Thinking Forth LaTeX sources from upstream GitHub,
# preprocess them through preprocess.pl, and convert to per-chapter
# Markdown with pandoc.  Idempotent: re-run safely.
#
# Outputs:
#   chapterN.md, appendix{a..e}.md, epilog.md
#   figures/*.png  (PNG figures from upstream; for human reading only)
#
# Requirements: pandoc, perl, git.

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

REPO_URL="https://github.com/forthy42/thinking-forth.git"
BRANCH="ans_tf"

# --- preflight -----------------------------------------------------------
need() {
    command -v "$1" >/dev/null 2>&1 || {
        echo "ERROR: missing tool '$1'. Install with: $2" >&2
        exit 1
    }
}
need pandoc "sudo apt install pandoc"
need perl   "sudo apt install perl"
need git    "sudo apt install git"

# --- 1. clone or refresh upstream ----------------------------------------
if [ ! -d upstream/.git ]; then
    echo "==> Cloning $REPO_URL ($BRANCH) into upstream/"
    git clone --depth 1 --branch "$BRANCH" "$REPO_URL" upstream
else
    echo "==> upstream/ already present (use 'rm -rf upstream' to force refresh)"
fi

# --- 2. copy PNG figures -------------------------------------------------
mkdir -p figures
echo "==> Copying PNG figures into figures/"
cp -u upstream/*.png figures/ 2>/dev/null || true
echo "    figures/: $(ls figures/*.png 2>/dev/null | wc -l) PNG files"

# --- 3. preprocess + pandoc per chapter ----------------------------------
TEX_FILES=(
    chapter1.tex chapter2.tex chapter3.tex chapter4.tex
    chapter5.tex chapter6.tex chapter7.tex chapter8.tex
    appendixa.tex appendixb.tex appendixc.tex appendixd.tex appendixe.tex
    epilog.tex
)

mkdir -p tmp
rm -f tmp/*.clean.tex

for src in "${TEX_FILES[@]}"; do
    in="upstream/$src"
    if [ ! -f "$in" ]; then
        echo "    warn: $in missing, skipping"
        continue
    fi
    base="${src%.tex}"
    clean="tmp/${base}.clean.tex"
    out="${base}.md"

    echo "==> $src -> $out"
    perl preprocess.pl < "$in" > "$clean"
    pandoc --from=latex --to=gfm --wrap=none "$clean" -o "$out"
done

# --- 4. sanity check: every image link in generated .md files resolves ---
echo "==> Verifying image references"
missing=0
GEN_MD=(chapter*.md appendix*.md epilog.md)
for md in "${GEN_MD[@]}"; do
    [ -f "$md" ] || continue
    while IFS= read -r target; do
        [ -z "$target" ] && continue
        if [ ! -f "$target" ]; then
            echo "    warn: $md -> $target (missing)" >&2
            missing=$((missing + 1))
        fi
    done < <(perl -ne 'while (/<img\s+src="(figures\/[^"]+)"|!\[[^\]]*\]\((figures\/[^)]+)\)/g) { print(defined($1) ? $1 : $2), "\n"; }' "$md")
done
if [ "$missing" -eq 0 ]; then
    echo "    all image references resolve"
else
    echo "    $missing missing image targets (see warnings above)" >&2
fi

# --- 5. residual LaTeX check ---------------------------------------------
echo "==> Scanning for residual LaTeX commands"
leftover=$(
    grep -Eo '\\(index|Chapmark|Sectmark|Forth|initial|person|wepsfig[a-z]*|wtexfig[a-z]*|includegraphics)\b' \
        chapter*.md appendix*.md epilog.md 2>/dev/null | sort -u || true
)
if [ -z "$leftover" ]; then
    echo "    clean"
else
    echo "    WARNING: residual macros found:" >&2
    echo "$leftover" | sed 's/^/      /' >&2
fi

# --- 6. cleanup ----------------------------------------------------------
rm -rf tmp

echo "==> Done. Output in $SCRIPT_DIR"

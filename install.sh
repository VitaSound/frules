#!/usr/bin/env bash
# Install frules into target .cursor/rules/
#
# Usage:
#   ./install.sh [target-dir] [dialect] [profile]
#     target-dir  default: .
#     dialect     gforth | ans      (default: from frules.conf, else ans)
#     profile     full | core       (default: full)
#
# Examples:
#   ./install.sh . gforth
#   ./install.sh . gforth core
#   ./install.sh . ans
#
# Notes:
# - Symlinks point at this checkout's rules/. Edits to rules/ are picked up live.
# - `.fs` is shared with F#: keep Forth sources in a Forth-only repo, or tighten
#   topic globs to your project layout.

set -euo pipefail

FRULES_ROOT="$(cd "$(dirname "$0")" && pwd)"
TARGET="${1:-.}"
RULES_SRC="$FRULES_ROOT/rules"
TPL_DIR="$FRULES_ROOT/templates"
CONF="$FRULES_ROOT/frules.conf"
RULES_DST="$(cd "$TARGET" && pwd)/.cursor/rules"

read_dialect_from_conf() {
  if [ -f "$CONF" ]; then
    local v
    v="$(grep -E '^[[:space:]]*dialect[[:space:]]*=' "$CONF" 2>/dev/null \
         | tail -1 \
         | sed 's/.*=[[:space:]]*//; s/[[:space:]]*#.*//; s/^[[:space:]]*//; s/[[:space:]]*$//' \
         | tr '[:upper:]' '[:lower:]')"
    [ -n "$v" ] && { echo "$v"; return; }
  fi
  echo "ans"
}

DIALECT="${2:-$(read_dialect_from_conf)}"
DIALECT="$(echo "$DIALECT" | tr '[:upper:]' '[:lower:]')"
PROFILE="${3:-full}"
PROFILE="$(echo "$PROFILE" | tr '[:upper:]' '[:lower:]')"

case "$DIALECT" in
  gforth|ans) ;;
  *) echo "Unknown dialect: $DIALECT (use: gforth | ans)" >&2; exit 1 ;;
esac

case "$PROFILE" in
  full|core) ;;
  *) echo "Unknown profile: $PROFILE (use: full | core)" >&2; exit 1 ;;
esac

TEMPLATE="$TPL_DIR/frules-dialect-${DIALECT}.mdc"
[ -f "$TEMPLATE" ] || { echo "Missing template: $TEMPLATE" >&2; exit 1; }

mkdir -p "$RULES_DST"

# Files always installed regardless of profile/dialect.
ALWAYS=(
  frules-index.mdc
  forth-system-context.mdc
)

# Topic files for `full` profile (alphabetical).
FULL_TOPICS=(
  forth-anti-patterns.mdc
  forth-c-bindings.mdc
  forth-control.mdc
  forth-debugging.mdc
  forth-defining.mdc
  forth-factoring.mdc
  forth-floating-point.mdc
  forth-io.mdc
  forth-memory.mdc
  forth-meta.mdc
  forth-naming.mdc
  forth-numeric.mdc
  forth-oof.mdc
  forth-portability.mdc
  forth-stack.mdc
  forth-strings.mdc
  forth-style.mdc
  forth-wordlists.mdc
)

# Topic files kept by `core` profile (subset).
CORE_TOPICS=(
  forth-anti-patterns.mdc
  forth-stack.mdc
  forth-style.mdc
)

if [ "$PROFILE" = "core" ]; then
  TOPICS=("${CORE_TOPICS[@]}")
else
  TOPICS=("${FULL_TOPICS[@]}")
fi

DIALECT_TOPICS=()
[ "$DIALECT" = "gforth" ] && DIALECT_TOPICS+=(forth-dialect-gforth.mdc)

# Compute the set of files we WILL install; remove stale frules-managed links not in the set.
declare -A KEEP=()
KEEP["frules-dialect.mdc"]=1
for f in "${ALWAYS[@]}" "${TOPICS[@]}" "${DIALECT_TOPICS[@]}"; do
  KEEP["$f"]=1
done

prune_stale_links() {
  local dst base
  for dst in "$RULES_DST"/*.mdc; do
    [ -L "$dst" ] || continue
    base="$(basename "$dst")"
    # Only prune symlinks that point into THIS frules checkout.
    local target
    target="$(readlink "$dst")"
    case "$target" in
      "$FRULES_ROOT"/*) ;;
      *) continue ;;
    esac
    if [ -z "${KEEP[$base]:-}" ]; then
      rm -f "$dst"
      echo "removed: $base"
    fi
  done
}

link_rule() {
  local src="$1"
  local base
  base="$(basename "$src")"
  local dst="$RULES_DST/$base"
  if [ -e "$dst" ] && [ ! -L "$dst" ]; then
    echo "skip (exists, not symlink): $base"
    return
  fi
  ln -sf "$src" "$dst"
  echo "linked: $base"
}

# Dialect marker (alwaysApply) — always reset to current choice.
ln -sf "$TEMPLATE" "$RULES_DST/frules-dialect.mdc"
echo "dialect marker: frules-dialect.mdc -> $(basename "$TEMPLATE")"

for f in "${ALWAYS[@]}";        do link_rule "$RULES_SRC/$f"; done
for f in "${TOPICS[@]}";        do link_rule "$RULES_SRC/$f"; done
for f in "${DIALECT_TOPICS[@]}"; do link_rule "$RULES_SRC/$f"; done

prune_stale_links

echo ""
echo "Installed: dialect=$DIALECT  profile=$PROFILE"
echo "Target:    $RULES_DST"
echo "See docs/RULES-ARCHITECTURE.md for activation behavior."

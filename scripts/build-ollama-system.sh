#!/usr/bin/env bash
# Build one system-prompt text file from frules rules/*.mdc (for Ollama Modelfile / API).
# Same file set as install.sh (dialect + profile).
#
#   bash scripts/build-ollama-system.sh
#   bash scripts/build-ollama-system.sh gforth core -o output/frules-ollama-system-core.txt
#   wc -c output/frules-ollama-system.txt
#
# Strip YAML frontmatter (--- ... ---). Ollama does not read .mdc paths by itself.

set -euo pipefail

ROOT="$(cd "$(dirname "$0")/.." && pwd)"
RULES="$ROOT/rules"
CONF="$ROOT/frules.conf"
OUT="${ROOT}/output/frules-ollama-system.txt"

read_dialect_from_conf() {
  if [ -f "$CONF" ]; then
    local v
    v="$(grep -E '^[[:space:]]*dialect[[:space:]]*=' "$CONF" 2>/dev/null \
         | tail -1 \
         | sed 's/.*=[[:space:]]*//; s/[[:space:]]*#.*//; s/^[[:space:]]*//; s/[[:space:]]*$//' \
         | tr '[:upper:]' '[:lower:]')"
    [ -n "$v" ] && { echo "$v"; return; }
  fi
  echo "gforth"
}

DIALECT="$(read_dialect_from_conf)"
PROFILE="full"

while [ $# -gt 0 ]; do
  case "$1" in
    -o|--out)
      OUT="$2"
      shift 2
      ;;
    gforth|ans|full|core)
      if [ "$1" = "gforth" ] || [ "$1" = "ans" ]; then
        DIALECT="$1"
      else
        PROFILE="$1"
      fi
      shift
      ;;
    -h|--help)
      sed -n '2,12p' "$0"
      exit 0
      ;;
    *)
      echo "unknown arg: $1 (use: gforth|ans full|core -o path)" >&2
      exit 1
      ;;
  esac
done

case "$DIALECT" in gforth|ans) ;; *)
  echo "dialect must be gforth or ans" >&2; exit 1 ;; esac
case "$PROFILE" in full|core) ;; *)
  echo "profile must be full or core" >&2; exit 1 ;; esac

ALWAYS=(frules-index.mdc forth-system-context.mdc)
FULL_TOPICS=(
  forth-anti-patterns.mdc forth-c-bindings.mdc forth-control.mdc
  forth-debugging.mdc forth-defining.mdc forth-factoring.mdc
  forth-floating-point.mdc forth-io.mdc forth-memory.mdc forth-meta.mdc
  forth-naming.mdc forth-numeric.mdc forth-oof.mdc forth-portability.mdc
  forth-stack.mdc forth-strings.mdc forth-style.mdc forth-wordlists.mdc
)
CORE_TOPICS=(forth-anti-patterns.mdc forth-stack.mdc forth-style.mdc)

if [ "$PROFILE" = "core" ]; then
  TOPICS=("${CORE_TOPICS[@]}")
else
  TOPICS=("${FULL_TOPICS[@]}")
fi

DIALECT_TOPICS=()
[ "$DIALECT" = "gforth" ] && DIALECT_TOPICS+=(forth-dialect-gforth.mdc)

strip_mdc() {
  sed '1,/^---$/d;/^---$/d' "$1"
}

mkdir -p "$(dirname "$OUT")"
{
  cat <<'HDR'
You write Gforth unless the user asks for portable ANS only. Postfix Forth — never C, Python, or infix.
Every colon definition must include a stack-effect comment ( before -- after ).
Output only Forth code when asked to implement a word; no markdown fences unless the user requests explanation.

HDR
  echo "# frules rules (generated from rules/*.mdc)"
  echo "# dialect=${DIALECT} profile=${PROFILE}"
  echo ""

  for base in "${ALWAYS[@]}" "${TOPICS[@]}" "${DIALECT_TOPICS[@]}"; do
    f="$RULES/$base"
    if [ ! -f "$f" ]; then
      echo "warn: missing $f" >&2
      continue
    fi
    echo "## ${base}"
    strip_mdc "$f"
    echo ""
  done
} > "$OUT"

BYTES="$(wc -c < "$OUT" | tr -d ' ')"
echo "wrote: $OUT ($BYTES bytes, dialect=$DIALECT profile=$PROFILE)"
if [ "$BYTES" -gt 50000 ]; then
  echo "hint: full rules are large — use 'core' or raise PARAMETER num_ctx (8192–16384) in Modelfile" >&2
fi

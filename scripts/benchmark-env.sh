#!/usr/bin/env bash
# Switch frules benchmark environment: bare | ecosystem | ollama | status | restore
#
#   ./scripts/benchmark-env.sh bare
#   ./scripts/benchmark-env.sh ecosystem
#   ./scripts/benchmark-env.sh ollama
#   ./scripts/benchmark-env.sh status
#   ./scripts/benchmark-env.sh restore
#
# State: output/benchmark/.env-state

set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

STATE_DIR="$ROOT/output/benchmark"
STATE_FILE="$STATE_DIR/.env-state"
CURSOR_DIR="$ROOT/.cursor"
RULES_ON="$CURSOR_DIR/rules"
RULES_OFF="$CURSOR_DIR/rules.frules-off"
RULES_SRC="$ROOT/rules"

write_state() {
  mkdir -p "$STATE_DIR"
  echo "mode=$1" >"$STATE_FILE"
  date -u +"%Y-%m-%dT%H:%M:%SZ" >>"$STATE_FILE"
}

rules_enabled() {
  [ -d "$RULES_ON" ] && [ -n "$(ls -A "$RULES_ON" 2>/dev/null || true)" ]
}

disable_rules() {
  if rules_enabled; then
    rm -rf "$RULES_OFF"
    mv "$RULES_ON" "$RULES_OFF"
    echo "rules: disabled ($RULES_ON -> $RULES_OFF)"
  elif [ -d "$RULES_OFF" ]; then
    echo "rules: already disabled"
  else
    mkdir -p "$RULES_OFF"
    echo "rules: none active (created empty $RULES_OFF)"
  fi
}

install_rules_gforth_full() {
  mkdir -p "$RULES_ON"
  local files=(
    frules-index.mdc forth-system-context.mdc frules-dialect.mdc
    forth-dialect-gforth.mdc
    forth-anti-patterns.mdc forth-c-bindings.mdc forth-control.mdc
    forth-debugging.mdc forth-defining.mdc forth-factoring.mdc
    forth-floating-point.mdc forth-io.mdc forth-memory.mdc forth-meta.mdc
    forth-naming.mdc forth-numeric.mdc forth-oof.mdc forth-portability.mdc
    forth-stack.mdc forth-strings.mdc forth-style.mdc forth-wordlists.mdc
  )
  local base dest
  for base in "${files[@]}"; do
    dest="$RULES_ON/$base"
    [ -f "$RULES_SRC/$base" ] || continue
    ln -sf "$RULES_SRC/$base" "$dest"
  done
}

enable_rules() {
  if [ -f "$ROOT/install.sh" ]; then
    bash "$ROOT/install.sh" . gforth full
    echo "rules: install.sh . gforth full"
    return
  fi
  if [ -d "$RULES_OFF" ] && [ -n "$(ls -A "$RULES_OFF" 2>/dev/null || true)" ]; then
    rm -rf "$RULES_ON"
    mv "$RULES_OFF" "$RULES_ON"
    echo "rules: restored ($RULES_OFF -> $RULES_ON)"
    return
  fi
  rm -rf "$RULES_ON"
  install_rules_gforth_full
  echo "rules: symlinked gforth full from $RULES_SRC"
}

cmd_status() {
  echo "repo: $ROOT"
  if [ -f "$STATE_FILE" ]; then
    echo "state:"
    cat "$STATE_FILE"
  else
    echo "state: (none)"
  fi
  if rules_enabled; then
    echo "cursor rules: ON ($(ls -1 "$RULES_ON" 2>/dev/null | wc -l) files)"
  elif [ -d "$RULES_OFF" ]; then
    echo "cursor rules: OFF ($RULES_OFF)"
  else
    echo "cursor rules: OFF (no directory)"
  fi
  echo "OLLAMA_MODEL=${OLLAMA_MODEL:-<unset>}"
  command -v ollama >/dev/null && ollama list 2>/dev/null | head -5 || echo "ollama: not in PATH"
  command -v fmcp >/dev/null && fmcp version 2>/dev/null || echo "fmcp: not in PATH (arm B needs MCP + PATH)"
}

cmd_restore() {
  enable_rules
  unset OLLAMA_MODEL 2>/dev/null || true
  write_state restore
  echo "restored default (rules on, OLLAMA_MODEL unset)"
}

MODE="${1:-status}"
case "$MODE" in
  bare)
    disable_rules
    unset OLLAMA_MODEL 2>/dev/null || true
    write_state bare
    echo "arm A: cursor_auto_bare (no rules, no OLLAMA_MODEL)"
    ;;
  ecosystem)
    enable_rules
    unset OLLAMA_MODEL 2>/dev/null || true
    write_state ecosystem
    echo "arm B: cursor_auto_eco (rules on; enable MCP vitasound-forth in Cursor)"
    ;;
  ollama)
    disable_rules
    export OLLAMA_MODEL="${OLLAMA_MODEL:-forth-qwen3b-core}"
    write_state ollama
    echo "arm C: ollama_local (OLLAMA_MODEL=$OLLAMA_MODEL)"
    echo "hint: export OLLAMA_MODEL in this shell before ollama/curl runs"
    ;;
  status)
    cmd_status
    ;;
  restore)
    cmd_restore
    ;;
  -h|--help)
    sed -n '2,10p' "$0"
    ;;
  *)
    echo "unknown mode: $MODE (bare|ecosystem|ollama|status|restore)" >&2
    exit 1
    ;;
esac

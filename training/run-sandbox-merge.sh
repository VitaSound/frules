#!/usr/bin/env bash
# Merge LoRA adapter -> HF weights (+ optional GGUF). See README "Merge LoRA".
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

if [[ ! -d .venv-train ]]; then
  echo "missing .venv-train — see docs/MODEL-TRAINING.md §1d"
  exit 1
fi
# shellcheck source=/dev/null
source .venv-train/bin/activate

export HF_HOME="${HF_HOME:-$ROOT/output/hf-cache}"
unset ALL_PROXY all_proxy 2>/dev/null || true

ADAPTER="${ADAPTER:-output/sandbox-adapter-merged}"
OUT="${OUT:-output/merged-0.5b}"
GGUF="${GGUF:-}"   # set to e.g. output/forth-gforth-q4_K_M.gguf to export

mkdir -p "$HF_HOME" "$(dirname "$OUT")"

ARGS=(--adapter "$ADAPTER" --out "$OUT")
if [[ -n "$GGUF" ]]; then
  ARGS+=(--gguf "$GGUF")
fi

echo "=== merge LoRA: adapter=$ADAPTER out=$OUT${GGUF:+ gguf=$GGUF} ==="
python3 training/merge-sandbox.py "${ARGS[@]}"

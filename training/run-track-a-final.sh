#!/usr/bin/env bash
# Track A final run — short system, train/infer parity, honest smoke eval.
#
# Prerequisites:
#   source .venv-train/bin/activate
#   export HF_HOME="$HOME/frules/output/hf-cache"
#
# Usage:
#   bash training/run-track-a-final.sh              # rebuild + train + infer smoke
#   SKIP_TRAIN=1 bash training/run-track-a-final.sh # only rebuild + infer
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

ADAPTER="${ADAPTER:-output/sandbox-adapter-fixed}"
DATASET="${DATASET:-data/train-simple.jsonl}"
EPOCHS="${EPOCHS:-3}"
if [[ -z "${MAX_SEQ:-}" ]]; then
  if [[ "$DATASET" == *merged* ]]; then
    MAX_SEQ=2048
  else
    MAX_SEQ=1024
  fi
fi

if [[ -z "${VIRTUAL_ENV:-}" ]]; then
  echo "error: activate venv first:  source .venv-train/bin/activate" >&2
  exit 1
fi

export HF_HOME="${HF_HOME:-$ROOT/output/hf-cache}"
mkdir -p "$HF_HOME" "$ROOT/$ADAPTER"

if [[ "${ALL_PROXY:-}${all_proxy:-}" == *socks* ]]; then
  if ! python3 -c "import socksio" 2>/dev/null; then
    echo "warn: unsetting ALL_PROXY/all_proxy" >&2
    unset ALL_PROXY all_proxy
  fi
fi

echo "=== 1/5 rebuild datasets (short system) ==="
python3 scripts/build-dataset.py --validate --system short --out data/train-simple.jsonl
FORCE_MERGE_BUILD=1 SYSTEM=short bash scripts/build-train-merged.sh

echo "=== 2/5 validate token lengths (max_seq=$MAX_SEQ) ==="
python3 scripts/validate-train-tokens.py "$DATASET" --max-seq "$MAX_SEQ"

if [[ "${SKIP_TRAIN:-}" != 1 ]]; then
  echo "=== 3/5 train 0.5B -> $ADAPTER ($EPOCHS epochs, max_seq=$MAX_SEQ) ==="
  python3 training/train-sandbox.py \
    --dataset "$DATASET" \
    --out "$ADAPTER" \
    --epochs "$EPOCHS" \
    --max-seq "$MAX_SEQ"
else
  echo "=== 3/5 SKIP_TRAIN=1 — using existing $ADAPTER ==="
fi

if [[ ! -f "$ADAPTER/adapter_config.json" ]]; then
  echo "error: missing adapter $ADAPTER" >&2
  exit 1
fi

echo "=== 4/5 infer smoke (train parity: short system + jsonl user) ==="
bash "$ROOT/scripts/track-a-smoke-infer.sh" "$ADAPTER"

echo "=== 5/5 done ==="
echo "Adapter: $ADAPTER"
echo "Log results in docs/TRAINING-RUNS.md (Track A final row)."
echo "Protocol: docs/TRACK-A-FINAL.md"

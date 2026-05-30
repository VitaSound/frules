#!/usr/bin/env bash
# Same 0.5B as Track A, but data/train-merged.jsonl (~120+ pairs from repo).
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

if [[ -z "${VIRTUAL_ENV:-}" ]]; then
  echo "error: activate venv first:  source .venv-train/bin/activate" >&2
  exit 1
fi

if [[ "${FORCE_MERGE_BUILD:-}" == 1 ]] || [[ ! -f data/train-merged.jsonl ]]; then
  bash scripts/build-train-merged.sh
else
  echo "=== using existing data/train-merged.jsonl (FORCE_MERGE_BUILD=1 to rebuild) ==="
fi

export HF_HOME="${HF_HOME:-$ROOT/output/hf-cache}"
mkdir -p "$HF_HOME" "$ROOT/output/sandbox-adapter-merged"

if [[ "${ALL_PROXY:-}${all_proxy:-}" == *socks* ]]; then
  if ! python3 -c "import socksio" 2>/dev/null; then
    echo "warn: unsetting ALL_PROXY/all_proxy" >&2
    unset ALL_PROXY all_proxy
  fi
fi

echo "=== Track A+ train: 0.5B + train-merged.jsonl (2 epochs) ==="
exec python3 "$ROOT/training/train-sandbox.py" \
  --dataset data/train-merged.jsonl \
  --out output/sandbox-adapter-merged \
  --epochs 2

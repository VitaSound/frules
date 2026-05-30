#!/usr/bin/env bash
# Long 0.5B run: repeat dataset + many epochs (no rush). Not a replacement for 7B/rules.
#
# Defaults: train-simple x5, 10 epochs -> output/sandbox-adapter-long
#
#   source .venv-train/bin/activate
#   export HF_HOME="$HOME/frules/output/hf-cache"
#   bash training/run-sandbox-long.sh
#
# Custom:
#   BASE=data/train-merged.jsonl REPEAT=3 EPOCHS=8 OUT=sandbox-adapter-long bash training/run-sandbox-long.sh
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

BASE="${BASE:-data/train-simple.jsonl}"
REPEAT="${REPEAT:-5}"
EPOCHS="${EPOCHS:-10}"
OUT="${OUT:-sandbox-adapter-long}"
REPEATED="data/train-repeated.jsonl"

if [[ -z "${VIRTUAL_ENV:-}" ]]; then
  echo "error: activate venv first:  source .venv-train/bin/activate" >&2
  exit 1
fi

if [[ ! -f "$BASE" ]]; then
  echo "=== building $BASE ==="
  python3 scripts/build-dataset.py --validate --out "$BASE"
fi

echo "=== repeat $BASE x$REPEAT -> $REPEATED ==="
python3 scripts/repeat-jsonl.py "$BASE" "$REPEATED" -n "$REPEAT"

export HF_HOME="${HF_HOME:-$ROOT/output/hf-cache}"
mkdir -p "$HF_HOME" "$ROOT/output/$OUT"

if [[ "${ALL_PROXY:-}${all_proxy:-}" == *socks* ]]; then
  if ! python3 -c "import socksio" 2>/dev/null; then
    echo "warn: unsetting ALL_PROXY/all_proxy" >&2
    unset ALL_PROXY all_proxy
  fi
fi

echo "=== long train: 0.5B, $REPEATED, $EPOCHS epochs -> output/$OUT ==="
echo "    (watch loss; if still falling at end, raise EPOCHS or REPEAT)"
exec python3 "$ROOT/training/train-sandbox.py" \
  --dataset "$REPEATED" \
  --out "output/$OUT" \
  --epochs "$EPOCHS"

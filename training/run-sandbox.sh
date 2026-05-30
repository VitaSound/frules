#!/usr/bin/env bash
# Track A helper — see docs/MODEL-TRAINING.md for full steps.
# Requires: venv with unsloth, CUDA, data/sandbox.jsonl
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

if [[ ! -f data/sandbox.jsonl ]]; then
  python3 scripts/build-dataset.py --sandbox
fi

if [[ -z "${VIRTUAL_ENV:-}" ]]; then
  echo "error: activate venv first:  source .venv-train/bin/activate" >&2
  exit 1
fi
export HF_HOME="${HF_HOME:-$ROOT/output/hf-cache}"
mkdir -p "$HF_HOME" "$ROOT/output/sandbox-adapter"
echo "HF_HOME=$HF_HOME"

# WSL/Cursor VPN: ALL_PROXY=socks5 without socksio breaks Hugging Face (empty cache → Unsloth "No config file").
if [[ "${ALL_PROXY:-}${all_proxy:-}" == *socks* ]]; then
  if ! python3 -c "import socksio" 2>/dev/null; then
    echo "warn: unsetting ALL_PROXY/all_proxy (SOCKS needs: pip install 'httpx[socks]')" >&2
    echo "      keep HTTP_PROXY/HTTPS_PROXY if you need a proxy" >&2
    unset ALL_PROXY all_proxy
  fi
fi
echo "=== Track A train (downloads ~0.5B on first run) ==="
exec python3 "$ROOT/training/train-sandbox.py"

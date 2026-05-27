#!/usr/bin/env bash
# Track A helper — see docs/MODEL-TRAINING.md for full steps.
# Requires: venv with unsloth, CUDA, data/sandbox.jsonl
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

if [[ ! -f data/sandbox.jsonl ]]; then
  python3 scripts/build-dataset.py --sandbox
fi

echo "=== Next: activate venv and run Unsloth train (see MODEL-TRAINING.md §3) ==="
echo "  python3 -m venv .venv-train && source .venv-train/bin/activate"
echo "  pip install -r training/requirements-train.txt"
echo "  # Then use Unsloth notebook or script with Qwen2.5-Coder-0.5B-Instruct + data/sandbox.jsonl"

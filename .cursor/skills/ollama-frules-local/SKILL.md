---
name: ollama-frules-local
description: Builds and runs local Ollama models with frules SYSTEM text from build-ollama-system.sh for Tier 1 Gforth IR drafts and smoke tests without API cost. Use for Ollama, Modelfile, forth-qwen-core, or local challenge smoke on RTX-class GPUs.
---

# Ollama + frules local

## Build SYSTEM file

```bash
cd /path/to/frules
bash scripts/build-ollama-system.sh gforth core -o output/frules-ollama-system-core.txt
bash scripts/build-ollama-system.sh gforth full -o output/frules-ollama-system.txt
```

## Create model (example 3B arm C)

```bash
ollama pull qwen2.5-coder:3b-instruct
bash training/write-modelfile-with-rules.sh forth-qwen3b-core qwen2.5-coder:3b-instruct \
  --system output/frules-ollama-system-core.txt --num-ctx 8192
ollama create forth-qwen3b-core -f training/Modelfile.forth-qwen3b-core
```

## Use

- Tier 1: IR draft, smoke — **not** final judge
- Judge remains **gforth** (Tier 0)
- 0.5B known fail (Track A) — use as negative control only

## Related skills

- `tier-escalation-cost-gate` — when local vs Opus
- `gforth-ir-pipeline` — what local model outputs
- `benchmark-challenge-arm` — arm C protocol

Docs: `docs/OLLAMA-FRULES.md`, `docs/BENCHMARK-AB-98.md`.

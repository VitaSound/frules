# Training run log

Manual log for LoRA / QLoRA experiments (like [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) for inference).

## How to use

After each train or benchmark, add one row. Do not commit multi-GB weights — only notes and paths under `output/`.

## Runs

| Date | Track | Base model | Dataset | Train notes | Challenges N/6 | Notes |
|------|-------|------------|---------|-------------|----------------|-------|
| 2026-05-30 | A sandbox | Qwen2.5-Coder-0.5B | `sandbox.jsonl` (~24 val) | 3 steps, ~45 s, loss ~4.04 | n/a | `output/sandbox-adapter/` — pipeline OK |
| 2026-05-30 | A+ merged | Qwen2.5-Coder-0.5B | `train-merged.jsonl` (122) | 32 steps, 2 ep, ~144 s, train_loss 2.61 | TBD holdout | `output/sandbox-adapter-merged/` |
| 2026-05-30 | A simple | Qwen2.5-Coder-0.5B | `train-simple.jsonl` (~24) | 18 steps, 3 ep, ~78 s, train_loss 3.26 | gcd fail infer | `output/sandbox-adapter-simple/` |
| 2026-05-30 | A long | Qwen2.5-Coder-0.5B | `train-simple`×5 → `train-repeated.jsonl` (205) | 260 steps, 10 ep, ~19 min; step loss ~1.7e-4; `train_loss` 0.344 | gcd/factorial infer **fail** | `output/sandbox-adapter-long/` — low loss, invalid Forth; **Track A 0.5B closed** |
| | B prod | Qwen2.5-Coder-7B | `data/train.jsonl` ≥500 | | | |
| | baseline | gemma4:e4b Ollama | n/a | | | frules on/off — see LOCAL-GEMMA-BENCHMARK |

## Eval matrix (Track B, when ready)

| Run | frules rules | LoRA `forth-gforth` | Score |
|-----|--------------|---------------------|-------|
| Base Ollama (no LoRA) | off | off | /6 |
| +frules | on | off | /6 |
| +LoRA | off | on | /6 |
| +LoRA+frules | on | on | /6 |

Protocol: [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) — one fresh chat per challenge, judge = `gforth`.

## See also

- [`TRAINING-NEXT-STEPS.md`](TRAINING-NEXT-STEPS.md) — **после Track A / A+ / long:** infer, eval, Ollama+rules
- [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md) — Ollama + frules SYSTEM (full/core, Qwen 0.5B, LoRA+GGUF)
- [`MODEL-TRAINING.md`](MODEL-TRAINING.md) — full instructions
- [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) — Gemma baseline without training

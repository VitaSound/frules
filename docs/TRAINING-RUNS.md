# Training run log

Manual log for LoRA / QLoRA experiments (like [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) for inference).

## How to use

After each train or benchmark, add one row. Do not commit multi-GB weights — only notes and paths under `output/`.

## Runs

| Date | Track | Base model | Dataset | Train notes | Challenges N/6 | Notes |
|------|-------|------------|---------|-------------|----------------|-------|
| | A sandbox | Qwen2.5-Coder-0.5B | `data/sandbox.jsonl` | | n/a (smoke gcd) | |
| | B prod | Qwen2.5-Coder-7B | `data/train.jsonl` | | | |
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

- [`MODEL-TRAINING.md`](MODEL-TRAINING.md) — full instructions
- [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) — Gemma baseline without training

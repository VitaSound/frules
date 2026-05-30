# data/ — SFT datasets for Forth training

| Path | Purpose |
|------|---------|
| [`challenge-solutions/SOLVE-QUEUE.md`](challenge-solutions/SOLVE-QUEUE.md) | Solve complete (**98/98** `train_for_sft`); gold not in `tests/challenges/` |
| `challenge-solutions/*.fs` | Verified solutions → `challenge-train.jsonl` only for `train_for_sft` |
| `challenge-train.jsonl` | **98** SFT pairs (`build-challenge-dataset.py --validate`) |
| `sandbox.jsonl` | Track A: **33** pairs (`tests/ans` + …); **24** with `--validate` |
| `train-simple.jsonl` | ans + examples (`good.fs`, `portable.fs` with `T{ }T`); **~41** validated |
| `train-core-validated.jsonl` | `tests/ans` + `tests/gforth` only; **~24** (`build-train-merged.sh` step 1) |
| `train-merged.jsonl` | `train-core-validated` + `challenge-train` → **122** pairs (Track A+) |
| `train-repeated.jsonl` | oversampled jsonl for long run (`repeat-jsonl.py`, e.g. 205 = 41×5) |
| `train.jsonl` | Track B core from frules (**~24** validated); goal **≥ 500** total |
| `eval.jsonl` | Optional hold-out (generate with `--split` later) |
| `raw.jsonl` | Optional intermediate from `build-dataset.py` |
| `forth-fmap-profiles.json` | FMAP profiles of Forth systems (SFT conditioning, retrieval) |
| `forth-threading-models.json` | Threading models (ITC/DTC/STC/…); join via `ex_c` / `fmap_ex_c` |
| `forth-use-case-templates.json` | Use-case → FMAP templates (embedded, ECU, hosted, …) |

## Regenerate

```bash
# From repo root
python3 scripts/build-dataset.py --sandbox
python3 scripts/build-dataset.py --out data/train.jsonl
python3 scripts/build-dataset.py --validate --out data/train-simple.jsonl

# Keep only sources that pass gforth TESTS OK (excludes examples/good.fs)
python3 scripts/build-dataset.py --sandbox --validate

# Merged + challenge train (122 lines; long step = 98× gforth)
bash scripts/build-train-merged.sh
python3 scripts/repeat-jsonl.py data/train-simple.jsonl data/train-repeated.jsonl -n 5
```

## JSONL record shape

Each line is one JSON object:

```json
{
  "type": "implement",
  "source": "tests/ans/gcd.fs",
  "word": "gcd",
  "messages": [
    {"role": "system", "content": "..."},
    {"role": "user", "content": "Implement : gcd ..."},
    {"role": "assistant", "content": ": gcd ( a b -- g )\n  ... ;"}
  ]
}
```

**Not in JSONL:** `tests/challenges/` (**145** hold-out tasks; ~**53** in `eval_holdout` slice) — blind eval only. Why counts differ: [`../README.md`](../README.md#почему-33-строки-sandbox-а-челленджей-145). See [`docs/MODEL-TRAINING.md`](../docs/MODEL-TRAINING.md). Train log metrics and CLI args: [`../training/README.md`](../training/README.md#строка-лога-при-train-что-значит-каждое-поле).

# data/ — SFT datasets for Forth training

| Path | Purpose |
|------|---------|
| [`challenge-solutions/SOLVE-QUEUE.md`](challenge-solutions/SOLVE-QUEUE.md) | **Solve queue complete** (94/94); corpus for SFT + reference; model validation on `eval_holdout` |
| `challenge-solutions/*.fs` | Verified solutions (not in `tests/challenges/`) |
| `sandbox.jsonl` | Track A (~30+ pairs): learn train → infer pipeline |
| `train.jsonl` | Track B seed from frules only (~40 pairs); extend to 500+ |
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

# Keep only sources that pass gforth TESTS OK (excludes examples/good.fs)
python3 scripts/build-dataset.py --sandbox --validate
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

**Not included:** `tests/challenges/` (benchmark hold-out). See [`docs/MODEL-TRAINING.md`](../docs/MODEL-TRAINING.md).

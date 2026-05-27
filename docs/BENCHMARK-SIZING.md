# Challenge bank sizing (for neural training)

`tests/challenges/` is **hold-out only** — it does not appear in `data/train.jsonl`. Training data comes from `tests/ans/`, `tests/gforth/`, `examples/`, and external Gforth you add (target **≥ 500** SFT pairs).

The bank exists to **measure** the model after training, not to train it.

## Optimal size: **145 total** (6 seeds + 139 bank)

| Role | Count | Why |
|------|------:|-----|
| **Seeds** | 6 | Fast smoke (`01`–`06`); frules style checks |
| **Bank** | 139 | ~8 tasks × 18 taxonomy blocks; room for Forth-heavy patterns |
| **Total hold-out** | **145** | Upper bound of plan corridor (130±15); stable eval without clone inflation |

Adding more than ~145 mostly duplicates `pattern_key` skills and wastes eval time (each run = fresh chat + `gforth`). Training quality is improved by **more train.jsonl**, not more challenges.

## Eval slices (use these for training milestones)

See [`tests/challenges/eval-slices.yaml`](../tests/challenges/eval-slices.yaml).

| Slice | ~Files | When |
|-------|-------:|------|
| `smoke` | 12 | After sandbox / each checkpoint |
| `standard` | ~24 | Track B milestone (seeds + 1 per block) |
| `stratified_20` | 20 | Pick from cognitive tier lists in YAML |
| `full` | 145 | Release / paper only |

**Do not** run `full` on every experiment — use `standard` or `stratified_20`.

## Taxonomy targets (bank + seeds)

Aim **6–10 tasks** per block for blocks that matter for Forth:

| Priority | Blocks | Target |
|----------|--------|--------|
| High | linked-structure, strings, arrays-hash, trees-bst, dynamic-programming | 8–10 |
| Medium | graph, parse-interpreter, binary-search, stack-queue | 7–8 |
| Lower | scalar-math, bit-xor | 8–12 (many easy LC/PE; avoid adding clones) |

## Relation to train.jsonl

| Dataset | Size goal | Content |
|---------|-----------|---------|
| `data/sandbox.jsonl` | ≥ 25 | Pipeline test |
| `data/train.jsonl` | **≥ 500** | Real Forth with tests |
| `tests/challenges/` | **145 fixed** | Blind eval only |

**Challenge solutions for SFT:** large model solves **`train_for_sft`** only (~100) → [`docs/CHALLENGE-TO-TRAIN.md`](CHALLENGE-TO-TRAIN.md). Never put solutions in `tests/challenges/`; never train on `eval_holdout` (~45).

## Regenerating after catalog edits

```bash
python3 scripts/_build_catalog.py
python3 scripts/gen_challenges.py
python3 scripts/check_manifest_dedup.py
bash scripts/verify_challenges.sh
```

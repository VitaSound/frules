# Challenge bank sizing (for neural training)

**151 total** = 6 seeds + **145 bank**. Split: **98** `train_for_sft` (gold in `data/challenge-solutions/`) + **53** `eval_holdout` (blind eval). Source: [`eval-slices.yaml`](../tests/challenges/eval-slices.yaml).

Training JSONL: `tests/ans/`, `examples/`, `challenge-train.jsonl` — target **≥ 500** SFT pairs total for Track B. The bank **measures** generalization on hold-out, not replaces train volume.

## Size summary

| Role | Count | Why |
|------|------:|-----|
| **Seeds** | 6 | Fast smoke (`01`–`06`); frules style checks |
| **Bank** | 145 | Taxonomy coverage; LeetCode/Codewars/Rosetta mix |
| **Total** | **151** | Stable eval set |
| **train_for_sft** | 98 | SFT export (not blind) |
| **eval_holdout** | 53 | **Blind** exam only |

Adding clones beyond ~151 mostly duplicates `pattern_key` skills. Training quality improves from **more train.jsonl**, not from putting hold-out into SFT.

## Legacy note

Older docs said «145 hold-out only» — **outdated** after train split. See [`PROOFREAD-AI-GENERATED.md`](PROOFREAD-AI-GENERATED.md).

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

**Challenge solutions for SFT:** **`train_for_sft` solve complete** (**98** verified in `data/challenge-solutions/`) → [`docs/CHALLENGE-TO-TRAIN.md`](CHALLENGE-TO-TRAIN.md). Never put solutions in hold-out paste zones; never train on **`eval_holdout` (53)** — use hold-out for **model validation** after training.

## Regenerating after catalog edits

```bash
python3 scripts/_build_catalog.py
python3 scripts/gen_challenges.py
python3 scripts/check_manifest_dedup.py
bash scripts/verify_challenges.sh
```

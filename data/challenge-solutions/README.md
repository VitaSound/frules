# data/challenge-solutions/

## Task checklist (mark done here)

**[`SOLVE-QUEUE.md`](SOLVE-QUEUE.md)** — 94 `train_for_sft` challenges with `- [ ]` / `- [x]`.  
Agent: first unchecked line → solve → user review → then check off and commit.

Regenerate from `eval-slices.yaml`:

```bash
python3 scripts/gen_solve_queue.py
```

---

Verified solutions for the **train_for_sft** split only (~100 files).

При написании можно опираться на `tests/ans/`, `examples/`, `sources/theforth.net-packages/` и уже готовые файлы здесь — см. [`docs/AGENT-SOLVE-CHALLENGES.md`](../docs/AGENT-SOLVE-CHALLENGES.md).

- Copy from `tests/challenges/NNN-slug.fs`
- Paste model code **between** the `=== paste your solution ===` markers
- Run `gforth` → must print `TESTS OK`
- **Do not** commit solutions into `tests/challenges/` (hold-out stays empty)

Build training JSONL:

```bash
python3 scripts/build-challenge-dataset.py --validate
```

See [`docs/CHALLENGE-TO-TRAIN.md`](../docs/CHALLENGE-TO-TRAIN.md).

**Agent workflow (English):** [`docs/AGENT-SOLVE-CHALLENGES.md`](../docs/AGENT-SOLVE-CHALLENGES.md), [`SOLVE-QUEUE.md`](SOLVE-QUEUE.md). After `TESTS OK` → user review; `- [x]` and commit only after explicit OK.

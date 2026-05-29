# data/challenge-solutions/

## Task checklist (solve phase complete)

**[`SOLVE-QUEUE.md`](SOLVE-QUEUE.md)** — **94 / 94** `train_for_sft` challenges, all `- [x]`.  
Фаза batch-solve **завершена**. Дальше: экспорт в JSONL и **валидация моделей** на `eval_holdout` (не на этом срезе).

Regenerate from `eval-slices.yaml`:

```bash
python3 scripts/gen_solve_queue.py
```

---

Verified solutions for the **train_for_sft** split only (~100 files).

При написании можно опираться на `tests/ans/`, `examples/`, `sources/theforth.net-packages/`, `sources/brodie-thinking-forth/`, `sources/gforth-manual-tutorial/`, `sources/gforth-manual/` и уже готовые файлы здесь — см. [`docs/AGENT-SOLVE-CHALLENGES.md`](../docs/AGENT-SOLVE-CHALLENGES.md).

- Copy from `tests/challenges/NNN-slug.fs`
- Paste model code **between** the `=== paste your solution ===` markers
- Run `gforth` → must print `TESTS OK`
- **Do not** commit solutions into `tests/challenges/` (hold-out stays empty)

Build training JSONL:

```bash
python3 scripts/build-challenge-dataset.py --validate
```

See [`docs/CHALLENGE-TO-TRAIN.md`](../docs/CHALLENGE-TO-TRAIN.md).

**Agent workflow (archived):** [`docs/AGENT-SOLVE-CHALLENGES.md`](../docs/AGENT-SOLVE-CHALLENGES.md) — отладка и редкие правки; очередь solve закрыта. См. [`docs/CHALLENGE-TO-TRAIN.md`](../docs/CHALLENGE-TO-TRAIN.md) для eval.

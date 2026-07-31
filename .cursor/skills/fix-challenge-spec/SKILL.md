---
name: fix-challenge-spec
description: Fixes obvious errors in tests/challenges spec files including T{ }T expected values and English CHALLENGE text while keeping paste zones empty. Use when challenge tests contradict the problem statement or Source URL.
---

# Fix challenge spec

## When allowed

Fix **`tests/challenges/NNN-slug.fs`** only when error is **obvious**:

- Wrong `->` value in `T{ }T`
- Typo in word name vs CHALLENGE
- Contradiction between header text and tests
- Off-by-one clearly wrong vs Source URL

If intent unclear — **stop** and ask user (English).

## Steps

1. Confirm bug by hand against Source / CHALLENGE text
2. Edit header (English), `T{ }T`, and/or scaffold in `tests/challenges/`
3. Add header comment: `\ Fixed: T{ … } expected X, was Y`
4. Keep paste zone **empty**
5. Re-copy scaffold to `data/challenge-solutions/` if train slice
6. After wide edits: `bash scripts/verify_challenges.sh`

## Forbidden

- Force wrong solution past broken test without fixing spec
- Fill hold-out paste zone with gold

## Related skills

- `solve-gforth-challenge` — implement after spec OK
- `eval-holdout-integrity` — hold-out paste stays empty
- `debug-gforth-stack` — distinguish spec bug vs code bug

Docs: `docs/AGENT-SOLVE-CHALLENGES.md`.

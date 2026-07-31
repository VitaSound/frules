---
name: rosettacode-hint-workflow
description: Finds Rosetta Code Forth snippet hints for bank challenges using rosettacode-hint.py and challenge-links.yaml. Use when solving tests/challenges tasks or looking for algorithm patterns in sources/rosettacode-forth.
---

# Rosetta Code hint workflow

## Run hint script

```bash
python3 scripts/rosettacode-hint.py tests/challenges/NNN-slug.fs
```

Output: `exact` / `related` / `ref` entries from `sources/rosettacode-forth/challenge-links.yaml`.

## Catalog

- [`sources/rosettacode-forth/INDEX.md`](sources/rosettacode-forth/INDEX.md) — 569 tasks by taxonomy
- Do **not** edit vendored `.fth` to fix Gforth — see `gforth-compat.yaml`

## Adaptation

- Rosetta contracts differ from bank `T{ }T` — adapt to `WORD` and Style guard
- Prefer theForthNet libraries for reusable words when INDEX points there
- Ideas only — verify with gforth

## Related skills

- `solve-gforth-challenge` — full challenge flow
- `pattern-similar-train-challenge` — train gold patterns
- `lookup-gforth-manual` — word semantics after hint

Hub: `sources/rosettacode-forth/INDEX.md`.

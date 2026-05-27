# tests/challenges/

Tasks **without reference solutions**. Each file:

- documents the contract in **English** (`CHALLENGE`, description, Style guard, stack effect, behaviour),
- defines any scaffold the asserts need (buffers, fixtures),
- ends with `T{ … }T` assertions and `report bye`.

The challenge word itself is **not** defined here. When you run a challenge
file as-is, gforth aborts with "undefined word" at the first assertion —
that is by design.

## Catalog size

| Set | Files | Naming |
|-----|-------|--------|
| **Seeds** (warm-up) | 6 | `01-clamp.fs` … `06-roman.fs` |
| **Bank** | 139 | `001-slug.fs` … `139-slug.fs` |
| **Total** | **145** | See [`INDEX.md`](INDEX.md), [`eval-slices.yaml`](eval-slices.yaml) |

Sized for **post-training eval** (hold-out), not for train.jsonl — see [`docs/BENCHMARK-SIZING.md`](../../docs/BENCHMARK-SIZING.md).

Sources: mostly [LeetCode Top 100 Liked](https://leetcode.com/studyplan/top-100-liked/), plus Codewars/kata, Project Euler, Rosetta — one task per `pattern_key` (no duplicate skills). Metadata: [`manifest.yaml`](manifest.yaml), coverage: [`taxonomy-coverage.md`](taxonomy-coverage.md).

Each bank file header includes **Cognitive: N/10** and **Pattern:** `pattern_key`.

## How to use

1. Open the challenge file in your editor.
2. Paste your solution between the marked banner lines.
3. Run it under gforth:

   ```bash
   cd tests/challenges
   gforth 01-clamp.fs      # seed
   gforth 052-two-sum.fs   # bank
   ```

   A successful solution prints `TESTS OK`. A wrong one prints
   `INCORRECT RESULT: …` per failed case and `TESTS FAILED: <n>`.

## How to use them as a model benchmark

| Guide | Use when |
|-------|----------|
| [`docs/CHALLENGE-RUNS.md`](../../docs/CHALLENGE-RUNS.md) | Cursor / cloud models, prompt template, result log |
| [`docs/LOCAL-GEMMA-BENCHMARK.md`](../../docs/LOCAL-GEMMA-BENCHMARK.md) | Local **Gemma 4** via Ollama; rules on/off |

The honest signal for "do the rules actually work" is: open a fresh chat,
attach one challenge file, run with **frules installed** (`./install.sh . gforth`),
and solve **without** looking at `tests/ans/` or `examples/`. Then verify:

```bash
cd tests/challenges && gforth NN-name.fs
```

Stratified eval: pick challenges by cognitive tier (0–3 / 4–6 / 7–10) from `INDEX.md`.

These files are intentionally **not** picked up by `./test.sh` (the script
only scans `tests/ans/` and `tests/gforth/`). They would always fail under
CI, which is the wrong signal.

## Regenerating the bank

```bash
python3 scripts/_build_catalog.py   # optional: edit tuples, rebuild catalog
python3 scripts/gen_challenges.py   # writes 001-125.fs, manifest, INDEX
python3 scripts/check_manifest_dedup.py
bash scripts/verify_challenges.sh   # smoke: undefined challenge word
```

Do **not** hand-edit generated `001-125.fs` files; change `scripts/_build_catalog.py` and regenerate.

## Adding a challenge

- **Seeds:** `NN-name.fs` (two-digit, `01`–`99`).
- **Bank:** `NNN-name.fs` (three-digit); add a tuple in `_build_catalog.py`, unique `pattern_key`, run generators above.
- Header in English; spec first; one challenge-word per file.
- Include `include _tester.fs`.
- Do not commit scratch files (`_*.fs` in this directory).

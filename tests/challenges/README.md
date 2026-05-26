# tests/challenges/

Tasks **without reference solutions**. Each file:

- documents the contract for one word (stack effect + behaviour),
- defines any scaffold the asserts need (buffers, fixtures),
- ends with `T{ … }T` assertions and `report bye`.

The challenge word itself is **not** defined here. When you run a challenge
file as-is, gforth aborts with "undefined word" at the first assertion —
that is by design.

## How to use

1. Open the challenge file in your editor.
2. Paste your solution between the marked banner lines.
3. Run it under gforth:

   ```bash
   cd tests/challenges
   gforth 01-clamp.fs
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

These files are intentionally **not** picked up by `./test.sh` (the script
only scans `tests/ans/` and `tests/gforth/`). They would always fail under
CI, which is the wrong signal.

## Adding a challenge

- Filename: `NN-name.fs` (two-digit prefix; keeps `ls` ordering stable).
- Header comment in English; spec first, constraints second.
- One word per file. If the problem needs helpers, they belong inside the
  solution; the scaffold should only set up buffers / inputs for the
  asserts.
- Include via `include _tester.fs` (which forwards to the vendored
  `ttester.4th` in `tests/ans/`).
- Do not commit scratch files (`_*.fs` in this directory).

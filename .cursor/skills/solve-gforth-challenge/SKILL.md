---
name: solve-gforth-challenge
description: Implements and debugs Gforth challenge solutions with frules style, gforth TESTS OK, and optional fmcp. Use when solving or fixing tests/challenges/*.fs, T{ }T failures, eval_holdout validation, data/challenge-solutions/, or when the user mentions a challenge slug or WRONG NUMBER OF RESULTS.
---

# Solve Gforth challenge

## Preconditions

- Dialect: **Gforth** (`frules.conf`, `forth-dialect-gforth.mdc`).
- Rules: `AGENTS.md`, `.cursor/rules/*.mdc` (from `./install.sh`), topic map in `frules-index.mdc`.
- **Judge:** `gforth` must report **`TESTS OK`** — never claim success without running it.
- MCP `vitasound-forth` when available: prefer `gforth_eval` over guessing.

## Hold-out (critical)

| Slice | Path | Allowed |
|-------|------|---------|
| train | `data/challenge-solutions/` | implement, read gold |
| **eval_holdout** | paste zone in `tests/challenges/` stays **empty** | run tests only; **no** copying train gold |

Check `tests/challenges/eval-slices.yaml`. Do not RAG or paste hold-out solutions.

## Workflow

### 1. Read spec (English)

Open `tests/challenges/NNN-slug.fs`:

- `CHALLENGE` block — what `WORD` must do
- stack effect `( before -- after )`
- Style guard
- every `T{ ... -> ... }T` — sanity-check expected values by hand

Optional references (ideas only, adapt to `WORD`):

- `python3 scripts/rosettacode-hint.py tests/challenges/NNN-slug.fs`
- `rg -l 'wordname' sources/gforth-manual/`
- similar `data/challenge-solutions/` (train only, not hold-out slug)

### 2. Algorithm choice

| Complexity | Approach |
|------------|----------|
| Simple scalar word | Implement directly in Forth between paste markers |
| Non-trivial logic | Draft **IR** (Lisp S-expr / JSON AST) first; transpiler when available — avoid long raw algorithm in one `: word` |

Follow Style guard and frules habits: locals `{ }`, stack-effect comments, no magic numbers (`CONSTANT`/`VALUE`), shallow stack.

### 3. Implement

- Code **only** between `=== paste your solution ===` markers
- Every `: name` has `\ ( before -- after )`
- For train: save to `data/challenge-solutions/NNN-slug.fs` (scaffold + filled paste zone)
- **Never** fill hold-out paste zone in `tests/challenges/`

### 4. Run tests (mandatory)

```bash
cd tests/challenges
gforth ../../data/challenge-solutions/NNN-slug.fs
```

Or MCP `gforth_eval` with `project_root` and path to solution file.

Expected: **`TESTS OK`**. On failure → fix solution or fix **obvious** spec bug in challenge file (keep paste zone empty).

### 5. Debug failures

Use skill **`debug-gforth-stack`** for `WRONG NUMBER OF RESULTS`, segfault, hang, or almost-right values.

Quick depth probe (replace `isqrt` with the word name from the CHALLENGE header):

```bash
cd tests/challenges
gforth -e 'fpath path+ . include ../../data/challenge-solutions/NNN-slug.fs' \
  -e 'depth . isqrt . depth . cr bye'
```

See `docs/AGENT-SOLVE-CHALLENGES.md` §5b.

### 6. Stop condition

After **`TESTS OK`**: report result with challenge path, solution path, and test command. Do not mark queue items or commit unless the user explicitly asks.

## Non-trivial logic reminder

LLM writes **meaning → IR**; postfix glue belongs in transpiler/stack-glue (Tier 0). Opus/thinking for algorithm choice only — not for `rot rot` loops.

## Related skills

- `debug-gforth-stack` — WRONG NUMBER OF RESULTS, segfault
- `eval-holdout-integrity` — hold-out eval rules
- `gforth-ir-pipeline` — non-trivial algorithms
- `gforth-verify-loop` — mandatory PASS loop
- `fix-challenge-spec` — obvious spec bugs
- `rosettacode-hint-workflow`, `pattern-similar-train-challenge` — references

Hub: `docs/GFORTH-AI-ECOSYSTEM.md`, `docs/GFORTH-SKILLS-CATALOG.md`, `docs/AI-VS-TOOLS.md`.

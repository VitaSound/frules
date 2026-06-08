# Challenge benchmark protocol

How to check whether **frules** actually steer a **fresh** model toward idiomatic Forth.
This is manual QA, not CI.

**A/B 98 train (Cursor Auto vs ecosystem vs Ollama):** see [`BENCHMARK-AB-98.md`](BENCHMARK-AB-98.md) —
`scripts/benchmark-env.sh`, timeout, cognitive sort.

**Local Gemma 4 (Ollama):** see [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) —
install model, connect/disconnect `.cursor/rules`, A/B baseline vs frules on.

**Your own LoRA (trained weights):** see [`MODEL-TRAINING.md`](MODEL-TRAINING.md) and log runs in [`TRAINING-RUNS.md`](TRAINING-RUNS.md).

## What you are measuring

| Signal | Meaning |
|--------|---------|
| `TESTS OK` after paste | Correct behaviour on all asserts |
| Code style vs `rules/` | Stack effects, no `PICK`/`ROLL`, naming (`balanced?`), factoring, Brodie idioms |
| Time / turns | Rough cost of getting green without hints |

You are **not** measuring whether `./test.sh` passes — challenges are excluded from it on purpose.

## Prerequisites

```bash
# From frules repo root
command -v gforth    # required
./install.sh . gforth   # optional: if you benchmark inside frules itself
```

For a **foreign** Forth project, run `install.sh` there so `.cursor/rules/` contains the symlinks to `rules/*.mdc`.

## Files the model may see

**Allow (attach or @-mention):**

- One challenge: `tests/challenges/NN-name.fs` (seed) or `NNN-slug.fs` (bank `001`–`125`)
- Rules (full benchmark): all `rules/forth-*.mdc` + `rules/frules-index.mdc`
- Dialect marker is applied automatically after `install.sh` (`frules-dialect.mdc`, `forth-dialect-gforth.mdc`)

**Deny (cheating — do not attach, do not @-mention):**

- `tests/ans/` — contains reference solutions (`gcd.fs`, `parse-int.fs`, `clamp-locals.fs`, …)
- `tests/gforth/` — same
- `examples/` — curated good/bad samples
- `sources/brodie-thinking-forth/` — full book text
- `sources/gforth-manual/` — full Gforth manual
- `sources/gforth-manual-tutorial/` — Gforth manual tutorial (ch.3)
- `sources/theforth.net-packages/` — vendored library source
- `sources/rosettacode-forth/` — Rosetta Code algorithm snippets (569 tasks)
- Any file you already solved in an earlier chat for the same challenge

If the model searches the repo on its own, say explicitly: *solve only from the attached challenge + rules; do not open `tests/ans`, `examples`, or `sources/`.*

## Fresh-chat procedure (one challenge)

1. **New Cursor chat** (Composer or Agent — pick one and stick to it for the whole matrix).
2. **Context**
   - Open the challenge file in the editor (helps globs), **or** attach `@tests/challenges/01-clamp.fs`.
   - Ensure project rules are installed (`./install.sh . gforth` once).
3. **Prompt** (copy, replace `NN` / word name):

   ```
   Solve the Forth challenge in tests/challenges/NN-name.fs.

   - Implement only the word named in the CHALLENGE header.
   - Paste the definition between the two "=== paste your solution ===" lines.
   - Follow stack-effect comments on every colon definition you add.
   - Obey the Style guard lines in the file header.
   - Do not read tests/ans/, tests/gforth/, or examples/.
   - Do not change the T{ }T assertions or scaffold (setup, buffers).
   - Gforth; ANS + Gforth locals allowed where the challenge allows it.
   ```

4. **Accept** the model's edit only between the paste markers.
5. **Verify** (human or script):

   ```bash
   cd tests/challenges
   gforth 01-clamp.fs
   ```

   | Outcome | Verdict |
   |---------|---------|
   | `TESTS OK` | Pass |
   | `INCORRECT RESULT:` / `TESTS FAILED:` | Fail (logic) |
   | `Undefined word` before paste | Expected on empty file; after paste = fail |
   | `error:` / `Backtrace` | Fail (syntax / compile) |

6. **Record** one row in the log table below (optional but recommended).

## Seed set (6 files)

Run **six separate fresh chats** — one file per chat. Order does not matter; use the same model and prompt template for comparability.

| File | Word | Cog | Rules stressed |
|------|------|-----|----------------|
| `01-clamp.fs` | `clamp` | 2 | style, anti-patterns |
| `02-min-max.fs` | `min-max` | 1 | factoring |
| `03-reverse-string.fs` | `reverse` | 3 | anti-patterns, factoring |
| `04-caesar-shift.fs` | `caesar` | 4 | anti-patterns, naming/constants |
| `05-balanced-parens.fs` | `balanced?` | 4 | naming, control |
| `06-roman.fs` | `roman` | 5 | factoring (table/lexicon) |

Suggested pass criteria for a "rules work" release (seeds):

- ≥ 5/6 green on first attempt **or** green within one fix turn after `TESTS FAILED`
- No `PICK`/`ROLL` in solutions where the challenge forbids them
- Every new word has `( … -- … )`

## Full bank (145 total)

**139** generated challenges (`001`–`139`) plus **6** seeds. Catalog: [`tests/challenges/INDEX.md`](../tests/challenges/INDEX.md). Eval subsets: [`eval-slices.yaml`](../tests/challenges/eval-slices.yaml). Sizing rationale: [`BENCHMARK-SIZING.md`](BENCHMARK-SIZING.md).

For large model benchmarks, do **not** run all 131 in one session. Suggested slices:

| Slice | Files | Purpose |
|-------|-------|---------|
| Smoke | `01`–`06` + 5 random `NNN` | Quick rules check |
| Tier A | cognitive 0–3 from INDEX | Warm-up |
| Tier B | cognitive 4–6 | Core interview level |
| Tier C | cognitive 7–10 | Hard / structure-heavy |
| `stratified_20` | 20 from tier lists in eval-slices.yaml | Training eval (see MODEL-TRAINING.md) |
| `standard` | ~24 (seeds + 1/block) | Track B milestone |
| `full` | 145 | Release only |

One `pattern_key` per skill — no duplicate themes (e.g. only one in-place string reverse in seeds; bank uses distinct keys).

## Quick check without the model

Confirm the harness is wired:

```bash
cd tests/challenges
gforth 01-clamp.fs   # must error: Undefined word: clamp
```

After a solution is pasted:

```bash
gforth 01-clamp.fs   # must print: TESTS OK
```

## Result log (template)

Copy into this file or a dated gist when you finish a run.

```markdown
## Run YYYY-MM-DD

- Model: (e.g. Composer 2.5 / Sonnet 4.6 / …)
- Rules: install.sh . gforth (full)
- Prompt: standard (see above)

| Challenge | 1st run | Notes |
|-----------|---------|-------|
| 01-clamp | OK / FAIL | |
| 02-min-max | | |
| 03-reverse-string | | |
| 04-caesar-shift | | |
| 05-balanced-parens | | |
| 06-roman | | |

Score: __/6 green
```

### Recorded run 2026-05-27 (frules repo, rules via `install.sh . gforth`)

| Challenge | Composer 2.5 | Cursor Agent (auto) | Notes |
|-----------|--------------|---------------------|-------|
| 01-clamp | **OK** | **OK** | Composer: `{ n lo hi }` + `n lo max hi min` — idiomatic |
| 02-min-max | — | **OK?** (log) | Agent ran long; `TESTS OK` seen in log before stop — confirm with `gforth 02-min-max.fs` |
| 03-reverse-string | — | **incomplete** | Hung; no confirmed stop |
| 04-caesar-shift | — | **incomplete** | Hung; no confirmed stop |
| 05-balanced-parens | — | not run | |
| 06-roman | — | not run | |

**Takeaway:** tier-1 (clamp) is easy for both; tier-2 (stack juggling / in-place indices) stalls Agent even when a green run may exist in the log.

## Agent timeout protocol

Do **not** wait for the agent to finish "thinking" after tests pass.

1. Watch the tool output / terminal panel for `TESTS OK`.
2. **Stop** the agent (or accept the diff).
3. Verify yourself (5 seconds):

   ```bash
   cd tests/challenges && gforth NN-name.fs
   ```

4. Record **OK** only if step 3 prints `TESTS OK` with no `STRINGS NOT EQUAL` / `INCORRECT RESULT`.

A passing line in the chat log without a local `gforth` run is **inconclusive**.

## Variants (optional)

| Variant | Purpose |
|---------|---------|
| **Rules off** | Same prompt, disable Forth rules in Cursor — baseline |
| **Core profile** | `./install.sh . gforth core` — fewer `.mdc` files |
| **Single rule file** | Only `forth-anti-patterns.mdc` + challenge — which rule file actually helps |
| **ANS only** | `./install.sh . ans` — no Gforth locals in 01-clamp |

## Troubleshooting

| Problem | Fix |
|---------|-----|
| `include _tester.fs` not found | Run `gforth` with cwd `tests/challenges`, not repo root |
| `Undefined word: expect-str-eq` | `_tester.fs` must include `ttester-ext.4th` (already in repo) |
| Model edits asserts | Revert file; repeat chat with "do not change T{ }T" |
| Model puts solution outside markers | Move lines between banners manually, re-run |
| Wants to read `tests/ans/gcd.fs` | Refuse; that invalidates the benchmark |

## Related

- [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) — Ollama + Gemma 4, rules on/off
- `tests/challenges/README.md` — file format
- `TODO.md` — roadmap item for automated benchmark table across models

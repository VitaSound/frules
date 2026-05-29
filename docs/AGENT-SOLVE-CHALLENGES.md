# Agent instructions: solve challenges one at a time

Protocol for an AI agent (Cursor, Composer, API). **One queue item per run:** implement → `TESTS OK` → **ask the user to review** → only after explicit approval: mark done, commit, and push.

**Goal:** build a **verified solution set** for training (`challenge-train.jsonl`), not a blind problem-solving benchmark. **Reading and reusing code is encouraged** — all of [`sources/`](../sources/), `tests/ans/`, `examples/`, existing files in `data/challenge-solutions/`, similar challenges, external references.

**Language:** All **problem statements** live in English: the `CHALLENGE` block in each `tests/challenges/*.fs` file (title, description, Style guard). Keep challenge fixes, solution comments, commit messages, and agent↔user messages about the task in **English** unless the user explicitly asks otherwise.

**Style and idioms:** Follow this repo’s **Forth programming rules** — [`AGENTS.md`](../AGENTS.md), [`rules/`](../rules/) (`forth-style`, `forth-stack`, `forth-factoring`, `forth-dialect-gforth`, …), `.cursor/rules/*.mdc` after `./install.sh` if present; topic index: [`rules/frules-index.mdc`](../rules/frules-index.mdc). The Style guard in each challenge header points at the same rules.

**Checklist file (check off here):** [`data/challenge-solutions/SOLVE-QUEUE.md`](../data/challenge-solutions/SOLVE-QUEUE.md)  
If missing: `python3 scripts/gen_solve_queue.py` from repo root.

Dialect: **Gforth**.

**Environment:** `gforth` and `python3` are already installed — do not install them.

---

## Hard rules

| Allowed | Forbidden |
|---------|-----------|
| Edit `data/challenge-solutions/NNN-slug.fs` (solution code) | Force a wrong solution past an obviously broken test instead of fixing the spec |
| Fix **obvious** errors in `tests/challenges/NNN-slug.fs` (English CHALLENGE text, `T{ }T`, scaffold) | Fill the paste zone in `tests/challenges/` (hold-out stays empty) |
| Mark `- [x]` and **commit/push** only after explicit **user OK** | Mark `- [x]` or commit right after `TESTS OK` without human review |
| Read `sources/`, repo examples, and **Forth rules** from `rules/` / `.cursor/rules/` | Work on `eval_holdout` files |
| Commit solution, queue, and challenge (if fixed) — **after user OK** | Batch-close multiple tasks without per-task review |
| One challenge per run (until review request or final push) | |

Train list: only `- [ ]` / `- [x]` lines in `SOLVE-QUEUE.md` (~94 files). Do **not** take tasks from `eval_holdout` in [`eval-slices.yaml`](../tests/challenges/eval-slices.yaml).

---

## Algorithm (one iteration)

### 0. Setup

```bash
cd /path/to/frules
# if the queue is missing or stale:
python3 scripts/gen_solve_queue.py
```

### 1. Pick the next task

```bash
bash scripts/next-challenge-to-solve.sh
```

If output is `QUEUE_EMPTY`, all train tasks are done — **stop**.

Otherwise note:

- `FILE` — e.g. `004-sqrt-int.fs`
- `WORD` — word name from the CHALLENGE header (e.g. `isqrt`)
- `CHALLENGE` — scaffold under `tests/challenges/`
- `SOLUTION` — where to write the solution

**Alternative:** open `SOLVE-QUEUE.md` and take the **first** `- [ ]` line.

### 2. Read and verify the problem statement (English)

Open:

- `tests/challenges/NNN-slug.fs` — full header: `CHALLENGE`, stack effect, Style guard, `T{ }T` tests (all in English)
- if unsure — **Source** URL in the header (LeetCode, Codewars, PE, etc.)

**Forth rules for this project (follow when writing code):**

- [`AGENTS.md`](../AGENTS.md) — habits (postfix, stack effects, factoring, no magic numbers)
- [`rules/`](../rules/) — `.mdc` files: `forth-dialect-gforth`, `forth-style`, `forth-stack`, `forth-factoring`, `forth-naming`, `forth-control`, `forth-defining`, `forth-portability`, `forth-anti-patterns`
- `.cursor/rules/` — same rules after `./install.sh` (if present in the workspace)
- [`rules/frules-index.mdc`](../rules/frules-index.mdc) — which rule file matches the task (strings, memory, loops, …)

**References and examples from `sources/` (allowed and useful):**

- [`sources/theforth.net-packages/`](../sources/theforth.net-packages/) — theForthNet libraries (`<pkg>/current/*.4th`, `*.fs`)
- [`sources/brodie-thinking-forth/`](../sources/brodie-thinking-forth/) — idioms and style (prose; do not paste verbatim into `.fs`)
- [`sources/gforth-manual-tutorial/`](../sources/gforth-manual-tutorial/) — Gforth manual ch.3 Tutorial (stack, loops, locals, defining words; prose + code examples)
- [`sources/gforth-manual/`](../sources/gforth-manual/) — full Gforth manual (word reference ch.5, environment, conformance, tools; prose + code)
- rest of [`sources/`](../sources/) — see [`sources/README.md`](../sources/README.md)
- plus [`data/challenge-solutions/`](../data/challenge-solutions/), [`tests/ans/`](../tests/ans/), [`tests/gforth/`](../tests/gforth/), [`examples/`](../examples/), seeds `01-clamp.fs` … `06-roman.fs`, web via Source

**theforth.net-packages:** use `current/` or `recent/`, search with `rg -l '…' sources/theforth.net-packages/`. Copy **ideas and fragments** into the paste zone (adapt to Gforth and `WORD`); prefer inlining words between markers over fragile `include` paths from `tests/challenges/`.

**gforth-manual-tutorial:** start from [`index.md`](../sources/gforth-manual-tutorial/index.md); pick sections by topic (`stack.md`, `factoring.md`, `local-variables.md`, …). Use for stack effects, control flow, and Gforth idioms — adapt examples to `WORD`; do not paste prose into `.fs`.

**gforth-manual:** start from [`index.md`](../sources/gforth-manual/index.md); search with `rg -l 'wordname' sources/gforth-manual/` or open topic files (`words.md`, `memory.md`, `assertions.md`, `standard-conformance.md`, …). Use for exact word semantics, stack effects, and Gforth-specific behaviour — adapt to `WORD`; do not paste prose into `.fs`. Prefer tutorial sections for pedagogy; prefer full manual for glossary-level detail.

**brodie-thinking-forth:** style and factoring guidance; same as above — ideas only, no verbatim prose in solution files.

Adapt borrowed code to **`WORD`**, stack effect, and Style guard; the result must pass all `T{ }T`.

#### Correctness check (required)

Before coding, confirm consistency of:

1. **CHALLENGE** text — what `WORD` must do
2. **Stack effect** `( before -- after )` and Style guard
3. **Expected values** in each `T{ ... -> ... }T` (sanity-check by hand)
4. **Scaffold** (variable names, helper word signatures, if any)

Common obvious bugs: wrong `->` value, typo in word name, mismatch with Source, text vs tests contradiction, off-by-one, wrong edge cases.

#### If the spec or a test is wrong

When the error is **obvious** (not a debatable interpretation):

1. Fix **`tests/challenges/NNN-slug.fs`** — header (English), `T{ }T`, and/or scaffold. Keep the paste zone **empty**.
2. Add one header comment, e.g. `\ Fixed: T{ 99 isqrt } expected 9, was 10`.
3. Re-copy the scaffold to `data/challenge-solutions/` (step 4).
4. After wide bank edits — `bash scripts/verify_challenges.sh`.

Do **not** “fix” the task if intent is unclear — stop and describe the issue to the user (in English).

### 3. Implement one word

Port from `sources/`, `tests/ans`, `examples`, another solution, or write from scratch — must pass tests and match **`rules/`** and the Style guard.

Requirements:

- Implement **only** `WORD` from the “Define a word” block
- Code **between** the `=== paste your solution ===` lines
- Every `: ...` has a stack-effect comment `( before -- after )`
- Follow the Style guard in the header
- No solution in `tests/challenges/`; in the solution copy only the filled paste block (+ same tests as the challenge file)

### 4. Save the solution

```bash
cp tests/challenges/004-sqrt-int.fs data/challenge-solutions/004-sqrt-int.fs
# Insert definition(s) between the markers in data/challenge-solutions/...
```

The solution file is the current scaffold **with code between the markers**.

### 5. Run tests

```bash
cd tests/challenges
gforth ../../data/challenge-solutions/004-sqrt-int.fs
```

Expected output: **`TESTS OK`**.

On `TESTS FAILED`:

1. Re-check step 2 — broken spec or test?
2. If tests are correct — fix the solution under `data/challenge-solutions/...` and retry.

After `TESTS OK` — **stop**. Do not mark `- [x]`, do not commit, do not push.

Optional: `bash scripts/verify_challenges.sh` (after edits under `tests/challenges/`).

### 5b. Gforth challenge debugging (stack and tests)

Rules: `forth-control.mdc` (flags, `if`, `WHILE`/`REPEAT`), `forth-stack.mdc`, `forth-debugging.mdc`.

| Symptom | Likely cause | Action |
|---------|----------------|--------|
| `WRONG NUMBER OF RESULTS: T{ … }T` | Stack **depth** after `word` ≠ expected (often **leak**, not wrong arithmetic) | `depth . word . depth .` or `word .s` before fixing the algorithm |
| `Invalid memory address` / segfault | Bad `cells +` index, `tuck` with **one** stack item, queue off-by-one | Smoke-test `enq`/`deq` in isolation; index buffers like `ch!`: `( n i -- ) swap cells buf + !` |
| Hang / `timeout` | Infinite loop, wrong exit condition (e.g. queue non-empty while work is done) | Tie loop to **problem invariant** (e.g. fresh count), not auxiliary structure size |
| Value almost right (e.g. 5 vs 4) | Off-by-one wave/minute or wrong test | Re-read Source; fix spec if obviously wrong |

**Quick probes** (minimal scaffold + paste zone only):

```bash
cd tests/challenges
gforth -e 'fpath path+ . include ../../data/challenge-solutions/NNN-slug.fs' \
  -e 'depth . WORD . depth . cr bye'   # omit if file ends with T{ }T report
```

Use `timeout 5 gforth …` while debugging loops. Prefer **`gforth`** over `gforth-fast` for backtraces (`forth-debugging.mdc`).

**Indexed buffers** (queues, DP, grids): reuse the repo `ch!` / `ch@` pattern — `( value index -- )` / `( index -- value )` with `swap cells field + !` / `cells field + @`; do not copy `tuck` queue snippets unless three stack items are present before `tuck`.

### 6. Ask the user to review (English)

Post an **explicit review request** to the user **in English**. Template:

---

**Please review: `004-sqrt-int.fs` (`isqrt`)**

- Challenge: `tests/challenges/004-sqrt-int.fs`
- Solution: `data/challenge-solutions/004-sqrt-int.fs`
- Test: `cd tests/challenges && gforth ../../data/challenge-solutions/004-sqrt-int.fs` → **TESTS OK**
- If the challenge was fixed: `tests/challenges/004-sqrt-int.fs` (brief note what changed)

Please check: problem statement, code between markers, frules style, whether tests make sense.

Reply **ok** / **accepted** / **lgtm** — then I will mark the task done and commit (+ push).  
If changes are needed, describe them; I will revise and ask for review again.

---

Wait for a reply. **Do not run steps 7–8 without user confirmation.**

If the user requests changes — edit the solution (and challenge if needed), re-run `gforth`, post step 6 again.

If the user rejects the task — do not mark `[x]`; leave `- [ ]` (keep or drop the solution file per user instruction).

### 7. After user confirmation — update the queue

Only when the user **explicitly approved** (`ok`, `accepted`, `lgtm`, `approved`, …):

In `data/challenge-solutions/SOLVE-QUEUE.md`:

```diff
- - [ ] 004-sqrt-int.fs  (`isqrt`)
+ - [x] 004-sqrt-int.fs  (`isqrt`)
```

Update `Progress: **N / 94**`. Regenerating the queue keeps `[x]`: `python3 scripts/gen_solve_queue.py`.

### 8. Git commit and push

```bash
git add data/challenge-solutions/004-sqrt-int.fs data/challenge-solutions/SOLVE-QUEUE.md
# if the challenge/spec was fixed:
git add tests/challenges/004-sqrt-int.fs
git status   # no stray paths
git commit -m "$(cat <<'EOF'
Add challenge solution: 004-sqrt-int.fs (isqrt)

TESTS OK. Fix challenge tests: wrong expected in T{ 99 isqrt }.
EOF
)"
git push
```

Mention challenge/test fixes in the commit message when applicable.

---

## Copy-paste prompt for a new chat

Replace `NNN-slug.fs` and `WORD` from step 1.

```
You are building ONE verified solution for the frules training dataset (not a blind solve test).

All problem statements are in English (CHALLENGE block in tests/challenges/*.fs). Use English for fixes, comments, and user messages about this task.

Queue: data/challenge-solutions/SOLVE-QUEUE.md — FIRST line with "- [ ]" only.
Task: tests/challenges/NNN-slug.fs → word WORD → data/challenge-solutions/NNN-slug.fs

Environment: gforth and python3 are already installed.

You MAY read and reuse examples from anywhere in the repo: sources/ (theforth.net-packages, brodie-thinking-forth, gforth-manual-tutorial, gforth-manual, …), data/challenge-solutions/, tests/ans/, tests/gforth/, examples/, similar challenges, Source URL. Prefer inlining adapted idioms in the paste zone over fragile includes.

Follow this project's Forth rules: AGENTS.md, rules/*.mdc, .cursor/rules/ if present, frules-index.mdc. Match Style guard in the challenge header.

Before coding — VERIFY the English problem statement:
- CHALLENGE text, stack effect, Style guard, every T{ }T expected value
- Compare with Source URL if anything looks wrong
- If spec or tests are obviously wrong, FIX tests/challenges/NNN-slug.fs (English header and/or T{ }T / scaffold; paste zone EMPTY)
- Then cp the fixed scaffold to data/challenge-solutions/ and implement there
- Do not force a wrong solution to pass bad tests

Rules:
- Gforth; AGENTS.md + rules/ + .cursor/rules/
- Implement ONLY : WORD
- Solution code ONLY between "=== paste your solution ===" in data/challenge-solutions/
- Stack-effect on every colon definition

When TESTS OK — STOP and ask the USER to review in English (do NOT commit or mark [x] yet):
- paths to challenge and solution
- gforth command and result
- what to check; ask for explicit OK before commit

ONLY after user confirms (ok / accepted / lgtm):
1. Mark - [x] in SOLVE-QUEUE.md, update Progress
2. git add solution + SOLVE-QUEUE.md (+ tests/challenges/NNN-slug.fs if fixed)
3. git commit -m "Add challenge solution: NNN-slug.fs (WORD)"
4. git push

If user requests changes: fix, re-run gforth, ask for review again.
ONE challenge per run until user OK; then commit and stop.
```

---

## After many solutions (not every run)

```bash
python3 scripts/build-challenge-dataset.py --validate
```

Eval only on `eval_holdout`, not `train_for_sft`.

---

## Agent checklist

**Before user review**

- [ ] First `- [ ]` from `SOLVE-QUEUE.md`
- [ ] English spec and `T{ }T` verified; obvious errors fixed in `tests/challenges/` (paste empty)
- [ ] Used `sources/` (theforth.net-packages, brodie-thinking-forth, gforth-manual-tutorial, gforth-manual, …) and `rules/` / `AGENTS.md`
- [ ] Solution in `data/challenge-solutions/`
- [ ] `gforth` → `TESTS OK`
- [ ] **Review request** sent to user (step 6 template, English)

**Only after user OK**

- [ ] `- [x]` and Progress in `SOLVE-QUEUE.md`
- [ ] Commit: solution + queue (+ challenge if changed)
- [ ] Push (or report if push is blocked)

---

## See also

- [`docs/CHALLENGE-TO-TRAIN.md`](CHALLENGE-TO-TRAIN.md) (Russian overview of train/holdout)
- [`AGENTS.md`](../AGENTS.md), [`rules/`](../rules/), [`sources/README.md`](../sources/README.md)
- [`data/challenge-solutions/README.md`](../data/challenge-solutions/README.md)
- [`tests/challenges/README.md`](../tests/challenges/README.md)

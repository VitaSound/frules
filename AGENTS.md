# Forth (frules)

**Dialect: Gforth** (see `frules.conf`, `rules/forth-dialect-gforth.mdc`). Run `./install.sh <project> gforth` to install into a target repo.

When editing Forth, follow `.cursor/rules/*.mdc` if present, or `frules/rules/` + dialect file.

Core habits:

- Postfix: operands before operators (`2 3 +`, not `2 + 3`).
- Every colon definition documents stack effects: `( before -- after )` for data stack; `(R …)` when using return stack.
- Factor into small words; keep stack depth shallow; avoid `PICK`/`ROLL` unless refactoring is impossible.
- No magic numbers in word bodies — use `CONSTANT` / `VALUE`.
- Prefer ANS words and portable sizing (`CELL`, `CHARS`, `ALIGNED`) over machine-specific assumptions.
- Name words for **what** they do (English), max 31 characters, functional not implementation detail.

Full detail: see `rules/` in the frules package. Reference prose and word glossary: `sources/gforth-manual/`, `sources/gforth-manual-tutorial/`. Algorithm snippets (hints only): `sources/rosettacode-forth/INDEX.md`.

**System / architecture questions** (choosing a Forth, FMAP, embedded vs hosted, layers, domain dialects FORTH-X, co-design) — use `rules/forth-system-context.mdc` and `docs/FORTH-*.md`, not challenge coding rules. Treat FORTH docs as **AI-assisted (human-directed)** — see [`docs/DOC-AUTHORSHIP.md`](docs/DOC-AUTHORSHIP.md); not exhaustively proofread by the human maintainer.

**Code / challenges** — stack, style, control, factoring (`forth-*.mdc`); ignore architecture docs unless the task is porting or target-specific. Train solve queue **complete** (94/94); use `eval_holdout` for model validation (`docs/CHALLENGE-TO-TRAIN.md`). If `T{ }T` reports `WRONG NUMBER OF RESULTS`, check stack depth after the word (`docs/AGENT-SOLVE-CHALLENGES.md` §5b, `forth-control.mdc`).

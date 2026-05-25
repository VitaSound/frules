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

Full detail: see `rules/` in the frules package.

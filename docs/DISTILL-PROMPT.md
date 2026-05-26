# Distillation prompt template

Use this prompt (in English) when asking an AI to convert a book chapter from `sources/` into rule files under `rules/`.

---

You are extracting durable, idiomatic guidance for **Gforth / ANS Forth** from `sources/<file>` into the `frules` repository. Audience: an AI coding assistant editing real Forth code.

## Output

For each topic identified, write or update **one** `rules/forth-<topic>.mdc`.

Frontmatter (mandatory):

```yaml
---
description: <one-line topic summary>
globs: "**/*.{fth,fs,4th,forth,fb}"
alwaysApply: false
---
```

Body:

- **English only**. Body fits in roughly 30–80 lines.
- One topic per file. Do not duplicate material from existing rules; cross-reference by file name (note: Cursor does not auto-load — see `docs/RULES-ARCHITECTURE.md`).
- Use the existing topic taxonomy first (`stack`, `style`, `control`, `defining`, `factoring`, `portability`, `anti-patterns`, `dialect-gforth`). Create a new file only for a genuinely new topic.

## Keep

- Stack discipline, contracts, factoring guidance.
- Idiomatic words and combinations the book endorses.
- Concrete short examples — **every code snippet must be valid Gforth** with correct stack-effect comments.
- Anti-patterns with the recommended fix.

## Drop

- Anecdotes, personal history, office analogies, jokes.
- Exercises without a concrete idiom payload.
- Re-statements of the ANS dictionary that are already covered by the Gforth manual.
- Vendor-specific quirks unrelated to Gforth.
- Markdown image references such as `![](figures/…)` or `<img src="figures/…">`.
  Figures are kept in the source tree for human reading only; they are not
  expected to contribute rules and should be ignored during distillation.

## Validation checklist (before saving)

- [ ] Every `: word ( … -- … ) … ;` parses and matches its stack-effect comment.
- [ ] No infix code, no undefined names, no C-string assumptions.
- [ ] Locals examples bind in stack-picture order (rightmost = TOS).
- [ ] `[ … ] literal` only for cells; `sliteral` for strings.
- [ ] Address/length pairs (`c-addr u`) not called "counted strings".
- [ ] `xt` for execution tokens (not "compilation address").

## Bookkeeping

- Add a row to `docs/SOURCES.md` listing the chapter and which rule files it updated.
- If a new rule file was created, mention it in `rules/frules-index.mdc` precedence list only if it changes conflict resolution.

## Output format in the chat

Return a short summary of what was added/changed, then the full text of each new or modified `.mdc` in code blocks.

---
name: gforth-defining-word
description: Implements Gforth defining words with CREATE, DOES>, defer, and field layouts following forth-defining rules. Use for compile-time vs run-time behavior, +field structs, queue defining words, or vocabulary-style word constructors.
---

# Gforth defining word workflow

## Rule file

`rules/forth-defining.mdc` — CREATE/DOES>, defer, quotations, +field.

## Workflow

```text
1. Clarify compile-time vs run-time behavior
2. Stack effects on **both** CREATE and DOES> paths
3. Prefer factoring; document ( before -- after ) on every :
4. gforth_eval / TESTS OK
```

## Bank gap

Train bank is integer-heavy; few `does>` challenges. Use `tests/ans/` or future defining tests when added (see TODO.md).

## Manual

`lookup-gforth-manual` for CREATE, DOES>, compile semantics.

## Related skills

- `frules-topic-routing` — defining vs meta
- `gforth-meta-compile` — `[`/`]` interaction
- `gforth-verify-loop` — mandatory PASS
- `add-gforth-word` — new word checklist

---
name: gforth-floating-point
description: Implements Gforth floating-point stack words using f+, fdup, f~ and forth-floating-point rules. Use for FP algorithms, float comparisons, or when Style guard allows floating point (many bank challenges forbid FP).
---

# Gforth floating-point workflow

## Rule file

`rules/forth-floating-point.mdc` — FP stack, `1e`, `f~abs`, Gforth FP idioms.

## Bank gap

Most train challenges use Style guard **"No floating point"**. Check header before using FP.

Dedicated FP tests planned in TODO.md — not yet in main bank.

## Workflow

```text
1. Confirm FP allowed in spec
2. Separate FP stack from integer stack — document effects
3. Use Gforth FP words, not integer approximations
4. gforth / project tests
```

## Related skills

- `gforth-double-numeric` — when double-cell needed instead
- `gforth-verify-loop` — mandatory PASS
- `frules-topic-routing`
- `lookup-gforth-manual`

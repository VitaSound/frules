---
name: gforth-double-numeric
description: Implements Gforth double-cell numeric words using d+, m*/, pictured numeric output, and forth-numeric rules. Use for extended precision integers, double arithmetic, or pictured number formatting without FP.
---

# Gforth double numeric workflow

## Rule file

`rules/forth-numeric.mdc` — double stack, `d+`, `m*/`, pictured output, fixed-point §.

## Bank gap

Train bank avoids double for simplicity. Use dedicated tests when added (TODO.md).

## Workflow

```text
1. Confirm double-cell stack contract (two cells per double)
2. No FP if Style guard forbids — use integer/double path
3. Stack effects show double as d1 d2 or documented convention
4. Verify no stack leaks across double ops
```

## Related skills

- `gforth-floating-point` — when FP allowed instead
- `frules-topic-routing` — forth-numeric.mdc
- `debug-gforth-stack`
- `gforth-verify-loop`

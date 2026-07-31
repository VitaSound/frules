---
name: gforth-string-parse
description: Implements Gforth string and parsing tasks using S", counted strings, and parse idioms per forth-strings rules. Use for reverse string, caesar, parse challenges, or text processing words in .fs files.
---

# Gforth string and parse workflow

## Rule file

`rules/forth-strings.mdc` — `S"` / `s\"`, `$@`, `$!`, parse, xchars.

## Reference challenges

- `tests/challenges/03-reverse-string.fs`
- `tests/challenges/04-caesar-shift.fs`
- parse-interpreter block in `tests/challenges/taxonomy-coverage.md`

## Workflow

```text
1. Confirm counted vs c-addr u contract in spec
2. Use Gforth string words (not C hacks)
3. Stack effect on every helper
4. gforth TESTS OK
```

## Related skills

- `solve-gforth-challenge` — bank string tasks
- `gforth-verify-loop` — mandatory PASS
- `lookup-gforth-manual` — word-specific semantics
- `gforth-control-flow` — parse loops

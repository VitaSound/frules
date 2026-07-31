---
name: gforth-meta-compile
description: Handles Gforth compilation state with immediate, postpone, bracket words, and recognizers per forth-meta rules. Use when compile-only errors occur, defining immediate words, or parsing/recognizer tasks.
---

# Gforth meta and compile state workflow

## Rule file

`rules/forth-meta.mdc` — `[` / `]`, immediate, postpone, parsing words.

## Common failure

"Forgot `]` after `[`" — compile-only word executed at interpret time.

## Workflow

```text
1. Identify compile vs interpret time behavior
2. Use postpone / [compile] when forwarding compile-only words
3. Test both interpreting and compiling paths if applicable
4. gforth_eval
```

## Related skills

- `gforth-defining-word` — CREATE/DOES> vs immediate
- `gforth-verify-loop` — mandatory PASS
- `fix-challenge-spec` — if scaffold has wrong `[`/`]` state
- `frules-topic-routing`

TODO: compile-state error tests in repo (see TODO.md).

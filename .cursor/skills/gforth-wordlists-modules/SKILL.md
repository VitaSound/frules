---
name: gforth-wordlists-modules
description: Organizes Gforth code with wordlists, vocabularies, and MODULE/EXPORT per forth-wordlists rules. Use for multi-module projects, search order changes, or encapsulating word sets.
---

# Gforth wordlists and modules workflow

## Rule file

`rules/forth-wordlists.mdc` — word lists, search order, MODULE/EXPORT.

## Workflow

```text
1. Plan module boundaries and exported words
2. Set search order explicitly when switching contexts
3. Document public stack effects on exported words only
4. fmix_test / gforth project tests
```

## Related skills

- `fmix-project-workflow` — package layout
- `gforth-verify-loop` — mandatory PASS
- `add-gforth-word` — words inside modules
- `frules-topic-routing`

Source hints: `sources/theforth.net-packages/INDEX.md` for MODULE examples.

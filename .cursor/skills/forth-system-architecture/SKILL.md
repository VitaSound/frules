---
name: forth-system-architecture
description: Routes system-level Forth questions to forth-system-context and FORTH architecture docs without writing challenge code. Use for FMAP, threading models, embedded vs hosted, dialect layers, or choosing a Forth system — not for implementing .fs challenges.
---

# Forth system architecture routing

## Not a coding skill

For **implement/fix `.fs`** use `frules-topic-routing` and topic skills — **not** this skill.

## Start here

1. `rules/forth-system-context.mdc`
2. Human docs under `docs/FORTH-*.md` (English: `*-eng.md`)

| Topic | Doc |
|-------|-----|
| Choosing a Forth / FMAP | `docs/FORTH-FMAP-GUIDE.md` |
| System layers | `docs/FORTH-SYSTEM-ARCHITECTURE.md` |
| Threading ITC/DTC | `docs/FORTH-THREADING.md` |
| Embedded / co-design | `docs/FORTH-HARDWARE-CODESIGN.md` |
| Feature cost | `docs/FORTH-FEATURE-COMPLEXITY.md` |

## Out of scope

- fhdl / fhdlgen Verilog workflow (separate HDL ecosystem)
- Challenge solutions and `T{ }T`

## Related skills

- `frules-topic-routing` — coding vs architecture split
- `setup-frules-ecosystem` — Gforth + frules daily setup

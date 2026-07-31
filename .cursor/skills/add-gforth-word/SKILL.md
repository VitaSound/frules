---
name: add-gforth-word
description: Adds or refactors Gforth colon definitions with stack-effect comments, frules style, gforth verification, flint, and fmix test. Use when creating a new word, extending a .fs or .4th module, fixing stack effects, or when the user asks to implement Forth functionality in a VitaSound/fmix project.
---

# Add Gforth word

## Before coding

1. Read `AGENTS.md` and relevant `.cursor/rules/forth-*.mdc`.
2. Name the word for **what** it does (English, ≤31 chars), not implementation detail.
3. Write stack effect **before** the body: `\ ( before -- after )` or `(R …)` if return stack used.
4. Prefer `{ locals }` over deep `rot`/`pick`; factor helpers when stack depth grows.

## Implementation checklist

- [ ] No magic numbers — `CONSTANT` / `VALUE`
- [ ] Gforth strings: `S"` / `s\"`, `$@`, `$!` per `forth-dialect-gforth.mdc`
- [ ] Portable sizing: `CELL`, `CHARS`, `ALIGNED` where relevant
- [ ] Anti-patterns: avoid `PICK`/`ROLL` unless refactor blocked (`forth-anti-patterns.mdc`)

## Verify loop (mandatory)

Use MCP `vitasound-forth` when configured; otherwise shell.

```text
1. gforth_eval or gforth on file / inline T{ }T
2. flint_lint on project_root (optional strict)
3. fmix_test on project_root when fmix project
```

**Never** tell the user it works without a PASS from gforth (or fmix test when that is the project gate).

## Non-trivial logic

For algorithms beyond a few stack ops:

```text
intent → IR (Lisp / JSON AST) → transpiler → Forth → gforth
```

Do not write long algorithmic logic as raw postfix in one definition when IR pipeline is available.

## References on demand

| Need | Look in |
|------|---------|
| Word semantics | `sources/gforth-manual/` (`rg -l 'name' …`) |
| Idioms | `sources/gforth-manual-tutorial/`, `rules/*.mdc` |
| Snippet hints | `sources/rosettacode-forth/INDEX.md` |

Distill ideas; do not paste manual prose into source files.

## Related skills

- `gforth-verify-loop` — mandatory PASS before done
- `flint-fcov-quality-gate` — lint/coverage after PASS
- `gforth-ir-pipeline` — non-trivial logic
- `lookup-gforth-manual`, `frules-topic-routing`

Hub: `docs/GFORTH-AI-ECOSYSTEM.md`, `docs/GFORTH-SKILLS-CATALOG.md`.

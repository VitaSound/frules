---
name: frules-topic-routing
description: Routes Gforth coding tasks to the correct frules rule file, manual section, or architecture doc. Use when unsure which forth-*.mdc applies, which sources/ manual to read, whether a question is system architecture vs implementation, or when the user asks about frules rules or Gforth idioms for a topic.
---

# frules topic routing

Cross-references in rules **do not auto-load** files. Pick the topic file or `@mention` it when the agent needs that guidance.

## Architecture vs coding

| Question type | Start here |
|---------------|------------|
| FMAP, threading, FPGA co-design, choosing a Forth | `forth-system-context.mdc` → `docs/FORTH-*.md` |
| Implement/fix `.fs`, challenges, stack effects | `forth-stack`, `forth-style`, `forth-control`, … — **not** FORTH architecture docs |

## Topic → rule file

| Task | Rule file |
|------|-----------|
| Stack order, depth, effects | `forth-stack.mdc` |
| Naming, factoring, `variable` as handle | `forth-style.mdc`, `forth-factoring.mdc`, `forth-naming.mdc` |
| if/loop/exit/recursion, `T{ }T` debug | `forth-control.mdc`, `forth-debugging.mdc` |
| CREATE/DOES>, defer, quotations | `forth-defining.mdc` |
| allot, buffers, linked lists | `forth-memory.mdc` |
| Strings, parse | `forth-strings.mdc` |
| FP / double | `forth-floating-point.mdc`, `forth-numeric.mdc` |
| Wordlists, MODULE | `forth-wordlists.mdc` |
| `[`/`]`, immediate, postpone | `forth-meta.mdc` |
| Gforth locals, try/endtry, structs | `forth-dialect-gforth.mdc` |
| What not to do | `forth-anti-patterns.mdc` |

Full table: `rules/frules-index.mdc`.

## P2 topic skills (workflow)

| Topic | Skill |
|-------|-------|
| Defining words | `gforth-defining-word` |
| Strings / parse | `gforth-string-parse` |
| Control flow | `gforth-control-flow` |
| Memory / buffers | `gforth-memory-buffers` |
| Floating point | `gforth-floating-point` |
| Double numeric | `gforth-double-numeric` |
| Meta / compile | `gforth-meta-compile` |
| File I/O | `gforth-io-files` |
| Wordlists / MODULE | `gforth-wordlists-modules` |

## Sources (lookup, not paste verbatim)

| Source | Use for |
|--------|---------|
| `sources/gforth-manual/` | exact word semantics (`rg -l 'word' …`) |
| `sources/gforth-manual-tutorial/` | pedagogy, idioms |
| `sources/rosettacode-forth/` + `rosettacode-hint.py` | challenge hints |
| `sources/theforth.net-packages/INDEX.md` | package APIs |
| `data/challenge-solutions/` | train patterns only |

## Precedence on conflict

1. `frules-dialect.mdc`
2. `forth-dialect-gforth.mdc`
3. Other `forth-*.mdc` (dialect wins over generic ANS)

## Related skills

- Challenge workflow → `solve-gforth-challenge`
- New word in project → `add-gforth-word`
- System architecture (not coding) → `forth-system-architecture`
- Manual lookup → `lookup-gforth-manual`

Hub: `docs/GFORTH-AI-ECOSYSTEM.md`, `docs/GFORTH-SKILLS-CATALOG.md`, `docs/RULES-ARCHITECTURE.md`.

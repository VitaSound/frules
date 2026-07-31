---
name: lookup-gforth-manual
description: Looks up Gforth word semantics and idioms in vendored gforth-manual and tutorial using ripgrep and index files. Use when implementing rare words, CREATE/DOES>, exceptions, locals, or when frules rules are insufficient for exact stack effects.
---

# Lookup Gforth manual

## Which corpus

| Need | Start |
|------|-------|
| Pedagogy, idioms | `sources/gforth-manual-tutorial/index.md` |
| Exact word semantics | `sources/gforth-manual/index.md` |

## Search

```bash
rg -l 'wordname' sources/gforth-manual/
rg -l 'CREATE' sources/gforth-manual/words.md
```

Open matching `.md` files; read stack effects and Gforth-specific notes.

## Usage rules

- Adapt examples to target `WORD` and Style guard
- Do **not** paste manual prose into `.fs` solution files
- Prefer tutorial for learning flow; full manual for glossary detail

## When RAG exists

Future MCP `rag_manual(query)` replaces manual grep — same adapt-not-paste rule.

## Related skills

- `frules-topic-routing` — which rule file complements manual
- `add-gforth-word` — implement after lookup
- `gforth-defining-word`, `gforth-string-parse`, … — topic workflows

Hub: `docs/SOURCES.md`.

---
name: distill-source-to-rule
description: Distills vendored sources into frules rules using DISTILL-PROMPT for maintainers adding forth-*.mdc topic files. Use when adding sources/ content, updating rules from manuals or books, or registering new topics in frules-index.
---

# Distill source to rule (maintainer)

## Audience

frules **maintainers** — not daily challenge solving.

## Workflow

```text
1. Add source under sources/ (vendored prose)
2. Run docs/DISTILL-PROMPT.md on chapter/section
3. Create or update rules/forth-<topic>.mdc (English, ≤80 lines ideal)
4. Register in rules/frules-index.mdc and docs/SOURCES.md
5. ./test.sh — lint English-only in rules
```

## One topic per file

Do not merge unrelated concerns. Dialect wins on conflict (`frules-index`).

## Related skills

- `frules-topic-routing` — where new rule appears
- `lookup-gforth-manual` — end-user lookup (not distill)

Docs: `docs/DISTILL-PROMPT.md`, `docs/RULES-ARCHITECTURE.md`.

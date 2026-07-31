---
name: gforth-ir-pipeline
description: Routes non-trivial Gforth logic through IR (Lisp S-expr or JSON AST) and transpiler instead of long raw postfix colon definitions. Use for algorithms with control flow, DP, graphs, parsers, or when stack glue would require deep rot/pick chains.
---

# Gforth IR pipeline

## When to use IR

| Complexity | Path |
|------------|------|
| Simple scalar word (few stack ops) | Direct Forth + `gforth-verify-loop` |
| Non-trivial logic (loops + state + helpers) | **IR first** |

## Pipeline

```text
1. Intent + edge cases (Tier 3 Opus or human — one turn)
2. IR: Lisp S-expr or JSON AST (Tier 1–3)
3. transpiler + stack-glue (Tier 0) — when scripts/lisp-to-forth.py exists
4. gforth_eval / TESTS OK (Tier 0)
5. FAIL → fix IR, not rot marathon
```

## LLM must not

- Write long algorithmic logic as one raw `: word` when IR path exists
- Pay Opus/thinking for `dup swap rot` glue — that is Tier 0 stack-glue

## IR shapes (target)

- Lisp: `(+ a (* b c))` → post-order emit
- JSON: `{ "op": "+", "args": [...] }` → strict parser

## Related skills

- `compile-ir-tool` — MCP transpile when backend exists
- `tier-escalation-cost-gate` — when to escalate to Opus for IR design
- `gforth-verify-loop` — judge after emit
- `solve-gforth-challenge` — simple challenges may skip IR

Docs: `docs/NOTATION-AND-TRANSPILER.md`, `docs/AI-VS-TOOLS.md`.

---
name: tier-escalation-cost-gate
description: Selects the correct LLM tier (Opus, Auto, Ollama, Tier 0 tools) for Gforth tasks and avoids expensive Agent loops on postfix glue. Use when choosing models, enabling thinking, or when rot/stack fixes repeat without gforth progress.
---

# Tier escalation and cost gate

## Tier model

| Tier | Who | Use for |
|------|-----|---------|
| **0** | gforth, transpiler, stack-glue, flint, fmix | compile, test, postfix glue, lint |
| **1** | Ollama + frules SYSTEM | IR draft, smoke, $0 API |
| **2** | Cursor Auto / Composer | bulk docs, yaml, simple words + fmcp |
| **3** | Opus / thinking | algorithm, IR design, ambiguous spec — **one short turn** |

## Escalate to Tier 3 when

- Ambiguous RU/EN spec with edge cases
- Algorithm choice (DP vs greedy, data structures)
- IR architecture for non-trivial module

## Do NOT escalate to Tier 3 for

- `gforth` rerun, `./test.sh`, `fmix test`
- Stack balance between known ops → stack-glue (Tier 0)
- Infix→RPN, AST walk → transpiler (Tier 0)
- "Fix rot again" loops → stop; use `debug-gforth-stack` + Tier 0

## Cost gate

- Thinking/xhigh: architecture / IR only
- No thinking for «run gforth again»

## Related skills

- `gforth-ir-pipeline` — what Opus should output
- `gforth-verify-loop` — Tier 0 judge
- `ollama-frules-local` — Tier 1 setup

Docs: `docs/EXTERNAL-LLM-ARCHITECTURE.md`.

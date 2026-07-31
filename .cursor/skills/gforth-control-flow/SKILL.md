---
name: gforth-control-flow
description: Implements Gforth control flow with if/loop/exit/recursion and flag idioms per forth-control rules. Use for loops, recursion, graph traversal, or fixing T{ }T failures involving branches and return stack.
---

# Gforth control flow workflow

## Rule file

`rules/forth-control.mdc` — if/else/then, begin/while/repeat, exit, recursion, flags.

## Taxonomy examples

- `recursion` block — `tests/challenges/117-gen-parens-count.fs`, combos
- `graph`, `trees-bst` — recursive DFS/BFS patterns

## Habits

- Match stack depth on **all** branch paths (`if`/`else`)
- Prefer `exit` over deep nesting when clear
- Document `(R …)` when using return stack

## Debug

`debug-gforth-stack` for WRONG NUMBER OF RESULTS after branches.

## Related skills

- `gforth-ir-pipeline` — complex control → IR first
- `gforth-verify-loop` — mandatory PASS
- `solve-gforth-challenge`
- `frules-topic-routing`

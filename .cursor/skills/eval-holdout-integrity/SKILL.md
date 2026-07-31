---
name: eval-holdout-integrity
description: Enforces honest model evaluation on eval_holdout challenges without gold solutions, empty paste zones, and no train/RAG leakage. Use for benchmark runs, eval_holdout validation, A/B tests, or when validating LLM on blind challenge slices.
---

# Eval hold-out integrity

## Slices

| Slice | Files | Gold | Agent may implement in |
|-------|-------|------|------------------------|
| `train_for_sft` | 98 | `data/challenge-solutions/` | train paths OK |
| **`eval_holdout`** | **53** | **none** | **never fill paste zone in tests/challenges/** |

Source: `tests/challenges/eval-slices.yaml`.

## Hard rules

- Paste zone in `tests/challenges/NNN-slug.fs` stays **empty** for hold-out
- Do **not** read or copy train gold for hold-out slug
- Do **not** RAG/index hold-out solutions into prompts
- One fresh chat per eval task (benchmark protocol)
- Judge: **gforth only** — `TESTS OK`

## Allowed for hold-out

- Read challenge spec, `T{ }T`, Style guard
- Write solution in **separate** eval workspace if your harness requires (not committed gold in repo)
- Run `gforth` on solution copy outside train gold paths

## Benchmark context

Arm B (`cursor_auto_eco`): frules rules + MCP + **no gold in context**. See `docs/BENCHMARK-AB-98.md`.

## Related skills

- `solve-gforth-challenge` — train workflow (different rules)
- `benchmark-challenge-arm` — full A/B protocol
- `pattern-similar-train-challenge` — train only, never hold-out slug

Hub: `docs/CHALLENGE-TO-TRAIN.md`.

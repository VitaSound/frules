---
name: pattern-similar-train-challenge
description: Finds similar train_for_sft challenge patterns and gold solutions by taxonomy and pattern_key without using eval_holdout slugs. Use when looking for algorithm patterns, comparable train examples, or inspiration for new Gforth implementations.
---

# Pattern similar train challenge

## Allowed corpus

| Slice | Path | Use |
|-------|------|-----|
| train (98) | `data/challenge-solutions/` | read gold, learn patterns |
| **hold-out (53)** | **forbidden** as gold source | eval only |

Check slug against `tests/challenges/eval-slices.yaml` → `eval_holdout`.

## Find similar

1. Read `pattern_key` / taxonomy in challenge header or `tests/challenges/manifest.yaml`
2. `rg pattern_key tests/challenges/` or open `tests/challenges/taxonomy-coverage.md`
3. Read train gold in `data/challenge-solutions/` — **adapt**, do not copy verbatim into hold-out eval

## Use

- Extract **IR shape** or factoring idea, not paste entire solution
- Combine with `rosettacode-hint-workflow` for external hints

## Related skills

- `solve-gforth-challenge` — implement target task
- `eval-holdout-integrity` — never leak hold-out
- `gforth-ir-pipeline` — distill pattern to IR

Hub: `tests/challenges/taxonomy-coverage.md`.

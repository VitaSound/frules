---
name: benchmark-challenge-arm
description: Runs A/B benchmark arms on train_for_sft challenges with fresh chats, no gold context, and gforth TESTS OK as the only judge. Use for BENCHMARK-AB-98, model comparison, or recording eval metrics on the 98 train slice.
---

# Benchmark challenge arm

## Arms (BENCHMARK-AB-98)

| Arm | Environment |
|-----|-------------|
| A bare | minimal prompt, no frules, no MCP hint |
| B ecosystem | `./install.sh` + AGENTS.md + MCP vitasound-forth + PATH |
| C local | Ollama + frules core SYSTEM |

## Protocol

- One **fresh chat** per challenge file
- **Forbidden:** gold from `data/challenge-solutions/` in agent context (cheating)
- Judge: **gforth** → `TESTS OK` only
- Timeout protocol in `docs/BENCHMARK-AB-98.md`

## Setup arm B

```bash
bash scripts/benchmark-env.sh ecosystem
# or ./install.sh . gforth in frules
```

## Related skills

- `eval-holdout-integrity` — hold-out eval stricter rules
- `solve-gforth-challenge` — solving (not benchmarking with gold)
- `tier-escalation-cost-gate` — model choice per arm

Docs: `docs/BENCHMARK-AB-98.md`, `scripts/benchmark-record.sh`.

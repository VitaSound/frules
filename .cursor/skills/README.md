# frules Cursor skills

Project skills for Gforth programming with frules + fmcp. Cursor discovers `.cursor/skills/*/SKILL.md` in the open project.

## Install

```bash
./install.sh /path/to/target-project gforth
```

Symlinks rules (`.cursor/rules/`) and all skills below into the target repo.

Catalog: [`docs/GFORTH-SKILLS-CATALOG.md`](../../docs/GFORTH-SKILLS-CATALOG.md).

## All skills (29)

| Skill | P | Use when |
|-------|---|----------|
| `solve-gforth-challenge` | P0 | challenges, `T{ }T` |
| `add-gforth-word` | P0 | new `: word`, fmix module |
| `frules-topic-routing` | P0 | which rule / manual |
| `debug-gforth-stack` | P0 | stack leaks, segfault, hang |
| `gforth-verify-loop` | P0 | after any `.fs` edit |
| `eval-holdout-integrity` | P0 | eval_holdout, benchmark honesty |
| `gforth-ir-pipeline` | P0 | non-trivial algorithms → IR |
| `setup-frules-ecosystem` | P0 | onboarding, install |
| `lookup-gforth-manual` | P1 | rare Gforth words |
| `rosettacode-hint-workflow` | P1 | Rosetta hints |
| `tier-escalation-cost-gate` | P1 | Opus vs Auto vs Ollama |
| `fmix-project-workflow` | P1 | fmix repo, packages |
| `flint-fcov-quality-gate` | P1 | lint, coverage |
| `fix-challenge-spec` | P1 | wrong challenge tests |
| `pattern-similar-train-challenge` | P1 | similar train patterns |
| `gforth-defining-word` | P2 | CREATE, DOES> |
| `gforth-string-parse` | P2 | strings, parse |
| `gforth-control-flow` | P2 | loops, recursion |
| `gforth-memory-buffers` | P2 | queues, grids, DP |
| `gforth-floating-point` | P2 | FP stack |
| `gforth-double-numeric` | P2 | double, pictured |
| `gforth-meta-compile` | P2 | `[`/`]`, immediate |
| `gforth-io-files` | P2 | open-file, paths |
| `gforth-wordlists-modules` | P2 | MODULE, vocab |
| `benchmark-challenge-arm` | P3 | A/B 98 benchmark |
| `ollama-frules-local` | P3 | local Ollama + SYSTEM |
| `forth-system-architecture` | P3 | FMAP, system docs |
| `distill-source-to-rule` | P3 | maintainer distill |
| `compile-ir-tool` | P3 | IR transpile (future) |

## Bundles

- **Minimal (7):** solve-gforth-challenge, add-gforth-word, frules-topic-routing, debug-gforth-stack, gforth-verify-loop, lookup-gforth-manual, tier-escalation-cost-gate
- **VitaSound (12):** Minimal + fmix-project-workflow, flint-fcov-quality-gate, gforth-ir-pipeline, eval-holdout-integrity, setup-frules-ecosystem

**P** = rollout priority (waves), not install bundle. **Minimal** = smallest useful set for generic Gforth coding (no eval/IR/setup). Three P0 skills (`eval-holdout-integrity`, `gforth-ir-pipeline`, `setup-frules-ecosystem`) are in **VitaSound/Full**, not Minimal.

## Not included

fhdl / fhdlgen (Verilog) — separate HDL ecosystem.

# Catalog: Cursor skills for Gforth + frules

Hub: [`GFORTH-AI-ECOSYSTEM.md`](GFORTH-AI-ECOSYSTEM.md). Canonical files: [`.cursor/skills/`](../.cursor/skills/).

**Principle:** skills = **workflow recipes**; rules = **language habits**. Skills do not duplicate `rules/*.mdc` bodies.

**Excluded:** fhdl / fhdlgen (Verilog/HDL) — separate ecosystem.

---

## Install

```bash
./install.sh <target-project> gforth    # rules + skills symlinks
```

Skills also live in frules when editing this repo. Cursor discovers `.cursor/skills/*/SKILL.md` automatically.

---

## Bundles

| Bundle | Skills |
|--------|--------|
| **Minimal** (7) | solve-gforth-challenge, add-gforth-word, frules-topic-routing, debug-gforth-stack, gforth-verify-loop, lookup-gforth-manual, tier-escalation-cost-gate |
| **VitaSound** (12) | Minimal + fmix-project-workflow, flint-fcov-quality-gate, gforth-ir-pipeline, eval-holdout-integrity, setup-frules-ecosystem |
| **Full** (29) | all skills below |

**P** = rollout priority (waves), not install bundle. **Minimal** = smallest useful set for generic Gforth coding (no eval/IR/setup). Three P0 skills (`eval-holdout-integrity`, `gforth-ir-pipeline`, `setup-frules-ecosystem`) are in **VitaSound/Full**, not Minimal.

---

## Full catalog (29 skills)

| ID | Skill | P | Triggers | Rules / docs |
|----|-------|---|----------|--------------|
| S01 | `solve-gforth-challenge` | P0 | challenge, `T{ }T`, eval | AGENT-SOLVE, challenges |
| S02 | `add-gforth-word` | P0 | new `: word`, fmix module | AGENTS.md, forth-style |
| S03 | `frules-topic-routing` | P0 | which rule/manual | frules-index |
| S04 | `debug-gforth-stack` | P0 | WRONG NUMBER OF RESULTS, segfault | forth-debugging, AGENT-SOLVE §5b |
| S05 | `gforth-verify-loop` | P0 | any `.fs` edit | fmcp, AI-VS-TOOLS |
| S06 | `eval-holdout-integrity` | P0 | eval, benchmark | CHALLENGE-TO-TRAIN, eval-slices |
| S07 | `gforth-ir-pipeline` | P0 | non-trivial algorithm | NOTATION-AND-TRANSPILER |
| S08 | `setup-frules-ecosystem` | P0 | new project setup | GFORTH-AI-ECOSYSTEM |
| S09 | `lookup-gforth-manual` | P1 | rare word semantics | gforth-manual/ |
| S10 | `rosettacode-hint-workflow` | P1 | challenge hints | rosettacode-hint.py |
| S11 | `tier-escalation-cost-gate` | P1 | Opus, thinking, cost | EXTERNAL-LLM |
| S12 | `fmix-project-workflow` | P1 | fmix repo | fmcp fmix_* |
| S13 | `flint-fcov-quality-gate` | P1 | lint, coverage | fmcp flint/fcov |
| S14 | `fix-challenge-spec` | P1 | wrong `T{ }T` in spec | AGENT-SOLVE |
| S15 | `pattern-similar-train-challenge` | P1 | similar train task | taxonomy, train gold |
| S16 | `gforth-defining-word` | P2 | CREATE, DOES> | forth-defining |
| S17 | `gforth-string-parse` | P2 | strings, parse | forth-strings |
| S18 | `gforth-control-flow` | P2 | loops, recursion | forth-control |
| S19 | `gforth-memory-buffers` | P2 | queues, grids, DP | forth-memory |
| S20 | `gforth-floating-point` | P2 | FP stack | forth-floating-point |
| S21 | `gforth-double-numeric` | P2 | double, pictured | forth-numeric |
| S22 | `gforth-meta-compile` | P2 | `[`/`]`, immediate | forth-meta |
| S23 | `gforth-io-files` | P2 | open-file, paths | forth-io |
| S24 | `gforth-wordlists-modules` | P2 | MODULE, vocab | forth-wordlists |
| S25 | `benchmark-challenge-arm` | P3 | A/B 98 benchmark | BENCHMARK-AB-98 |
| S26 | `ollama-frules-local` | P3 | local Ollama | OLLAMA-FRULES |
| S27 | `forth-system-architecture` | P3 | FMAP, system choice | forth-system-context, FORTH-* |
| S28 | `distill-source-to-rule` | P3 | maintainer distill | DISTILL-PROMPT |
| S29 | `compile-ir-tool` | P3 | IR transpile (future) | ROADMAP Phase 1 |

---

## Wave rollout

| Wave | IDs | Count |
|------|-----|-------|
| 0 review | S01–S03 | 3 |
| 1 P0 | S04–S08 | 5 |
| 2 P1 | S09–S15 | 7 |
| 3 P2 | S16–S24 | 9 |
| 4 P3 | S25–S29 | 5 |

---

## Not skills (by design)

- LoRA / training pipelines
- RLM-MCP (Phase 2b)
- fhdl / fhdlgen Verilog workflow
- Duplicating each `forth-*.mdc` as a skill

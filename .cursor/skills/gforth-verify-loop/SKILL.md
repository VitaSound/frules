---
name: gforth-verify-loop
description: Runs mandatory gforth or fmcp gforth_eval verification after every Forth code change and reports PASS or FAIL before claiming success. Use after editing any .fs or .4th file, implementing words, or when the user asks if code works.
---

# Gforth verify loop

## Rule

**Never** tell the user code works without a PASS from gforth (or fmix test when that is the project gate).

## Loop

```text
1. Edit Forth source
2. Run judge (MCP preferred, shell fallback)
3. Read output: TESTS OK / PASS / FAIL / error text
4. If FAIL → fix → return to step 2
5. Only then report success to user
```

## MCP (vitasound-forth)

| Tool | When |
|------|------|
| `gforth_eval` | inline snippet or evaluate file path |
| `fmix_test` | fmix project test gate |
| `flint_lint` | after PASS, optional quality |
| `fcov_run` | coverage when requested |

## Shell fallback

```bash
cd tests/challenges && gforth ../../data/challenge-solutions/NNN-slug.fs
# expect: TESTS OK
```

Or project-specific `./test.sh`, `fmix test`.

## Report format

State: file path, command/tool used, exact result (`TESTS OK` or error line).

## Related skills

- `add-gforth-word` — new word workflow
- `solve-gforth-challenge` — challenge tests
- `debug-gforth-stack` — when FAIL is stack-related
- `flint-fcov-quality-gate` — post-PASS quality

Hub: `docs/AI-VS-TOOLS.md`.

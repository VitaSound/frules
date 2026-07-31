---
name: fmix-project-workflow
description: Works with VitaSound fmix project structure using fmix_check, fmix_test, and fmix_packages_get MCP tools. Use in fmix repos, package deps, CI test gates, or when the user mentions fmix test or project layout.
---

# fmix project workflow

## MCP tools (vitasound-forth)

| Tool | Purpose |
|------|---------|
| `fmix_check` | validate project structure |
| `fmix_test` | run test suite (project gate) |
| `fmix_packages_get` | fetch package dependencies |

Pass `project_root` to each call.

## Workflow

```text
1. fmix_check(project_root) — fix structure issues first
2. Implement / edit Forth under project layout
3. gforth_eval or unit file test
4. fmix_test(project_root) — required gate before done
5. flint_lint optional — see flint-fcov-quality-gate
```

## With frules

```bash
./install.sh /path/to/fmix-project gforth
```

Skills symlink via same install.sh.

## Related skills

- `add-gforth-word` — implement words
- `gforth-verify-loop` — gforth before fmix_test
- `flint-fcov-quality-gate` — lint/coverage
- `setup-frules-ecosystem` — initial setup

Hub: [fmcp](https://github.com/VitaSound/fmcp).

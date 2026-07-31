---
name: flint-fcov-quality-gate
description: Runs flint lint and fcov coverage via vitasound-forth MCP after gforth passes. Use before commit, after refactor, or when checking duplicate word names and test coverage in VitaSound Forth projects.
---

# Flint and fcov quality gate

## Order

```text
1. gforth PASS (gforth-verify-loop)
2. flint_lint(project_root)
3. fcov_run(project_root) when coverage requested
4. fcov_report(project_root) for summary
```

## MCP (vitasound-forth)

| Tool | Notes |
|------|-------|
| `flint_lint` | optional `strict`, `project_only` |
| `fcov_run` | after tests |
| `fcov_report` | read coverage output |

## What flint catches

- Duplicate word names
- Project tree issues (project-specific rules)

Flint does **not** replace gforth — compile/test first.

## Related skills

- `gforth-verify-loop` — prerequisite
- `fmix-project-workflow` — fmix_test gate
- `add-gforth-word` — new word checklist

Hub: `docs/AI-VS-TOOLS.md`.

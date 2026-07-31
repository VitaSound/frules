---
name: setup-frules-ecosystem
description: Sets up frules rules, Cursor skills, vitasound-forth MCP, and toolchain PATH for Gforth development in a target project. Use when onboarding a repo, first-time frules install, or when the user asks how to connect Cursor to Gforth tooling.
---

# Setup frules ecosystem

## 1. Rules + skills

```bash
cd /path/to/frules
./install.sh /path/to/target-project gforth
# or core profile for smaller context:
./install.sh /path/to/target-project gforth core
```

Installs symlinks:

- `.cursor/rules/*.mdc` — frules habits
- `.cursor/skills/*/` — workflow skills

## 2. MCP vitasound-forth (fmcp)

Configure in Cursor MCP settings. Requires on `PATH`:

- `gforth`
- `fmix`, `flint`, `fcov`, `fmcp` (VitaSound toolchain)

See [fmcp README](https://github.com/VitaSound/fmcp/blob/main/README.md).

## 3. Project AGENTS.md

Add: algorithm → IR for non-trivial logic; after edits → `gforth_eval`; hold-out integrity for eval.

## 4. Verify

- Open target project in Cursor
- Skills visible under `.cursor/skills/`
- Run MCP `mcp_ping` or `gforth_eval` smoke test

## Related skills

- `gforth-verify-loop` — daily verify habit
- `fmix-project-workflow` — VitaSound project layout
- `ollama-frules-local` — optional local Tier 1

Hub: `docs/GFORTH-AI-ECOSYSTEM.md`, `docs/GFORTH-SKILLS-CATALOG.md`.

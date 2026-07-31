---
name: compile-ir-tool
description: Invokes IR-to-Forth transpilation via future compile_ir MCP tool or scripts/lisp-to-forth.py after LLM produces Lisp or JSON AST. Use when gforth-ir-pipeline IR is ready and Tier 0 backend should emit Forth instead of manual postfix.
---

# Compile IR tool

## Status

**Blocked** until `scripts/lisp-to-forth.py` (or chosen transpiler) exists. See `docs/ROADMAP-AI-PLATFORM.md` Phase 1.

## Target workflow

```text
1. LLM outputs validated IR (Lisp S-expr or JSON AST)
2. compile_ir(source, format=lisp|json)  [future MCP]
   OR: python3 scripts/lisp-to-forth.py < ir.lisp > word.fs
3. stack-glue layer if needed (Tier 0)
4. gforth_eval — gforth-verify-loop
```

## Until backend exists

- Use `gforth-ir-pipeline` for IR design
- Emit Forth manually only for **simple** words
- Do not simulate transpiler in long Agent loops

## Related skills

- `gforth-ir-pipeline` — upstream IR
- `gforth-verify-loop` — downstream judge
- `tier-escalation-cost-gate` — Opus for IR only

Docs: `docs/NOTATION-AND-TRANSPILER.md`, `TODO.md` IR pipeline.

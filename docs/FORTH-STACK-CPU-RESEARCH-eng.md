# Stack CPU: Research Theses (Superscalar, Co-Design)

> **Russian:** [FORTH-STACK-CPU-RESEARCH.md](FORTH-STACK-CPU-RESEARCH.md)  
> **Authorship:** [DOC-AUTHORSHIP-eng.md](DOC-AUTHORSHIP-eng.md) — AI-assisted (human-directed); distilled from zzeng (Habr) articles and related context; not Forth-community canon.  
> **Hub:** [FORTH-SYSTEM-ARCHITECTURE-eng.md](FORTH-SYSTEM-ARCHITECTURE-eng.md) · **Co-design:** [FORTH-HARDWARE-CODESIGN-eng.md](FORTH-HARDWARE-CODESIGN-eng.md)

Condensed **working theses** for the frules knowledge base: why a stack **external** ISA can coexist with an internal register superscalar backend, and how that relates to Forth, J1, and historical machines.

**Primary sources (zzeng / B. Muratshin, Habr):**

| Topic | URL |
|-------|-----|
| Calls, volatile/non-volatile, register windows | [267771](https://habr.com/ru/articles/267771/) |
| Loop fracking (wide expression trees) | [271905](https://habr.com/ru/articles/271905/) |
| Model: stack frontend + mops + OoO | [278575](https://habr.com/ru/articles/278575/) |
| Calls: register windows, FILL/SPILL | [279123](https://habr.com/ru/articles/279123/) |
| Calls from inside: mop serialization | [280087](https://habr.com/ru/articles/280087/) |
| Bookmarks, memory optimization | [281352](https://habr.com/ru/articles/281352/) |
| Elbrus-1/2: historical prototype | [313376](https://habr.com/ru/articles/313376/) |

---

## Contents

1. [Why this document in frules](#1-why-this-document-in-frules)
2. [Problem the articles address](#2-problem-the-articles-address)
3. [Architectural thesis: two “stacks”](#3-architectural-thesis-two-stacks)
4. [Function calls and context](#4-function-calls-and-context)
5. [Optimization: fracking and bookmarks](#5-optimization-fracking-and-bookmarks)
6. [Historical line](#6-historical-line)
7. [Comparison with FMAP and J1](#7-comparison-with-fmap-and-j1)
8. [Theses for agents and dataset](#8-theses-for-agents-and-dataset)
9. [Misconceptions (supplement to hub §12)](#9-misconceptions-supplement-to-hub-12)

---

## 1. Why this document in frules

| Question | Where to look |
|----------|----------------|
| Which Forth / CPU to choose today? | [FORTH-FMAP-GUIDE-eng.md](FORTH-FMAP-GUIDE-eng.md) |
| FMAP axes, class 0, J1 | [FORTH-SYSTEM-ARCHITECTURE-eng.md](FORTH-SYSTEM-ARCHITECTURE-eng.md) §9–§11 |
| Build custom hardware for a task? | [FORTH-HARDWARE-CODESIGN-eng.md](FORTH-HARDWARE-CODESIGN-eng.md) |
| **Why a stack ISA if registers are inside anyway?** | **this document** |
| **Was “superscalar stack” ever built?** | **§6 (Elbrus), §7 (J1)** |

This document does **not** describe a shipping CPU in frules — only an idea map for architecture questions and co-design.

---

## 2. Problem the articles address

**Outside (ISA / compiler):**

- Register names in asm are a **link interface** between instructions, not necessarily physical registers.
- The compiler statically allocates “virtual” registers (NP-complete); ABI register count is **fictitious** and does not scale with hardware.
- Stack code is **more compact**: no register names per instruction; dependencies are **implicit** via stack order.

**Inside (superscalar):**

- Sequential input must be **unpacked** into parallel micro-operations — expensive at decode/rename.
- A stack machine **looks** strictly sequential → ILP stays hidden until runtime.

**zzeng’s requirements for a new interface:**

1. All compiler-known parallelism must **reach the hardware** without loss.
2. Dependency unpacking cost must be **minimal** (dependencies already in stack / tree structure).

Forth/postfix fits as a **natural compact frontend**; see [Koopman stack computers](https://users.ece.cmu.edu/~koopman/stack_computers/sections.html) for a classic survey.

---

## 3. Architectural thesis: two “stacks”

```text
External ISA:  push / + / @ / call     ← what the compiler sees (Forth, stack C backend)
       ↓ decoder
Internal:      mops (lload, ladd, …)   ← register μops, OoO dispatch
       ↓
Hardware:      register file + pipelines (ALU, memory)
```

**Key trick:** the external “stack top” is a **mop index stack** (operation queue), not necessarily a data stack in memory.

| Mechanism | Meaning |
|-----------|---------|
| **Mop** | Internal three-address stub (`add r1 r2 r3`); links to parent mops |
| **Index stack** | Decoder pops N top mops as operands of a binary op |
| **Readiness** | Mop runs when ancestor count = 0; register assigned at **pipeline issue**, not at decode |
| **OoO** | Independent loads and adds from different tree branches run in parallel (e.g. FFT, balanced sum) |

**Thesis for frules:** postfix Forth describes an **expression tree**; data stack depth ≈ tree depth; **parallelism** is **across** the tree, not down a chain of `+`.

**Gforth coding (layer 1):** linear `a b + c + d +` is the worst ILP case; explicit grouping / locals / factoring is language-level “fracking” (see §5).

---

## 4. Function calls and context

Articles [279123](https://habr.com/ru/articles/279123/), [280087](https://habr.com/ru/articles/280087/) + foundation [267771](https://habr.com/ru/articles/267771/).

### External model (SPARC / AMD29K style, not MIPS fixed ABI)

| Idea | Detail |
|------|--------|
| **Register windows** | Local register numbering **from zero per function**; in/out overlap on call |
| **Dual stack** | Register stack (fast) + memory stack (large data, spill) — **AMD29K** pattern |
| **FILL / SPILL** | Per **call frame**, with **occupancy mask** — do not save empty slots |
| **Call as μop** | Arguments must be **evaluated** before call; call triggers context serialization |

### Internal model (superscalar + recursion)

| Problem | Approach |
|---------|----------|
| Parent mops “hang” on nested call | Serialize waiting mops to stack (L0μ-cache alternative) |
| Recursion depth (Ackermann) | Per-function mop numbering; compiler splits `f(a, g(b))` via temps |
| Code after call | Decode **portions** with **one** unconditional exit (Sandy Bridge lesson) |

**Thesis for frules:** on **register MCU + STC Forth** (stm8ef, Mecrisp) call context is **explicit** (stack, saved regs); on a **hypothetical superscalar stack CPU** the Forth compiler **need not know** about registers — save/restore is **hardware**. That is **not** current J1 (see §7).

**C++ EH link ([267771](https://habr.com/ru/articles/267771/)):** on normal call/unwind, context recovery data is **already on the stack** — zero-cost exceptions via static tables; also explains volatile vs callee-saved.

---

## 5. Optimization: fracking and bookmarks

Sources: [271905](https://habr.com/ru/articles/271905/), [281352](https://habr.com/ru/articles/281352/).

### Loop fracking

| Sum shape | Tree | ILP |
|-----------|------|-----|
| `sum += x[i]` | left list | none (dependency chain) |
| nesting ×2, ×4 | two/four accumulators | partial |
| pyramid / popadd | balanced | log₂(N) levels, scales with ALU count |

**Thesis:** a wide expression tree is a **portable** optimization (not SIMD-tied); x86 `/fp:fast` may beat manual nesting; other hardware may not.

### Bookmarks

Compiler marks a “valuable” value: `bmk N` / `add_bmk N` — named slot until return, participates in FILL/SPILL.

| Forth analog (layer 1) | zzeng ISA analog |
|------------------------|------------------|
| `{ locals }`, `VALUE` | bookmark N |
| factoring into `: helper` | separate bmk |
| `VARIABLE` + `@`/`!` | memory stack (slow) |

**Thesis:** naive stack codegen’s weakness is extra `push`/`@`; bookmarks are **explicit temps in the fast stack**, like locals without changing external postfix style.

---

## 6. Historical line

| System | Overlap with zzeng theses | Status |
|--------|---------------------------|--------|
| **Burroughs B5000** | stack ISA, compact code | historical |
| **Elbrus-1/2** ([313376](https://habr.com/ru/articles/313376/)) | stackless-address + **СтОп/operand stack** (32 reg + mask) + **OoO** (~2 insn/cycle) + scoreboard | built ~1973–80 |
| **AMD29K** | dual stack, register windows, SPILL/FILL | commercial |
| **SPARC / Itanium RSE** | register windows | commercial |
| **J1** | postfix ISA, **no** OoO rename, fixed shallow stack | open soft-CPU |
| **zzeng project** | stack frontend + mops + bookmarks | **research**, not silicon |

**Elbrus (important for frules):**

- **Operand stack (СтОп)** — circular register buffer for “stack top”; occupancy bitmask; register assigned at decode, freed after exec.
- **Not** register renaming in the modern sense — **scoreboarding**.
- Author of [313376](https://habr.com/ru/articles/313376/): superscalar stack CPU idea is **conceptually cleaner** but **did not win** commercially.

---

## 7. Comparison with FMAP and J1

| Axis | J1 (frules §11.1) | Elbrus | zzeng (hypothesis) |
|------|-------------------|--------|---------------------|
| **MM** | V | unified + tagged VM | V-like internal |
| **External ISA** | postfix insn | stackless-address stack | stack push/pop |
| **EX-C** | V (colon→insn on host) | native decode | mops + OoO |
| **Data stack** | fixed ~33, **no spill** | operand stack + RAM spill | register window + mem |
| **Parallelism** | minimal (1 ALU) | multi-EU, OoO | multi-EU, OoO |
| **Call/return** | hardware R stack ~32 | multi-phase (mark→enter) | serialized mops + windows |
| **Forth runtime** | RP=0, cross-only | full OS + tagged | compiler may ignore regs |

**Thesis:** J1 is **practical L2 co-design** (simplicity, Verilog); zzeng/Elbrus line is a **different trade-off**: harder hardware, richer ILP, more compact code. Do not conflate in agent recommendations.

**Register MCU + Gforth** is a third branch: stacks **in RAM**, STC/ITC, superscalar in **x86/ARM CPU**, not in Forth-ISA. Dominant path for application Forth today.

---

## 8. Theses for agents and dataset

For architecture prompts include **provenance**: “research thesis from zzeng distill, not verified silicon”.

| # | Thesis | Agent action |
|---|--------|--------------|
| T1 | Postfix = compact **DAG** for an expression | Do not equate “stack” only with RAM PSP |
| T2 | Deep linear stack = little ILP | Factoring, locals, balanced forms — OK |
| T3 | “Stack CPU” ≠ one design | Clarify: fixed internal (J1) vs RAM-backed vs internal OoO (Elbrus) |
| T4 | J1 is **not** zzeng superscalar stack | Do not promise OoO/bookmarks on J1 |
| T5 | Bookmarks ≈ **named temps** / locals | On Gforth — `{ }`, do not invent ISA `bmk` |
| T6 | Call on windowed CPU — frame SPILL | On STM8/Mecrisp — explicit stack frame, not “magic” |
| T7 | Elbrus proves **stack frontend + OoO** existed | Cite as historical, not shipping target |
| T8 | Co-design today | J1/Mecrisp-Ice in [FORTH-HARDWARE-CODESIGN-eng.md](FORTH-HARDWARE-CODESIGN-eng.md); zzeng — **research map** |

### Prompt template (research context)

```text
Topic: superscalar stack CPU (research, zzeng distill).
Not a shipping frules target. Contrast with J1: fixed stack, no OoO.
For application code: use Gforth + forth-*.mdc, not fictional bmk ISA.
Historical precedent: Elbrus-1 operand stack (СтОп) + OoO.
```

---

## 9. Misconceptions (supplement to hub §12)

| Claim | True? |
|-------|-------|
| Stack ISA ⇒ data only on hardware stack | **no** — zzeng/Elbrus: internal registers |
| zzeng superscalar stack = J1 | **no** |
| Forth on MCU is slow because “stack-based” | **no** — STC + RAM stacks; bottleneck is MCU, not model |
| Loop nesting always faster | **no** — can hurt `/fp:fast` vectorizer |
| Bookmarks are standard Forth words | **no** — ISA research; analog is locals |
| Elbrus = Burroughs clone | **no** — tagged VM, segments, own call protocol |
| Register renaming required for OoO stack | **no** — Elbrus: scoreboard |

Full J1/REPL/VM misconceptions: [FORTH-SYSTEM-ARCHITECTURE-eng.md](FORTH-SYSTEM-ARCHITECTURE-eng.md) §12.

---

## Related stack

| Question | Document |
|----------|----------|
| Class 0, ISA/Forth/runtime axes | [FORTH-SYSTEM-ARCHITECTURE-eng.md](FORTH-SYSTEM-ARCHITECTURE-eng.md) §9.1 |
| J1 contract | §11.1 |
| Historical CPUs (NC4016, J1, …) | [FORTH-HARDWARE-CODESIGN-eng.md](FORTH-HARDWARE-CODESIGN-eng.md) §11 |
| Shallow stack in code | `rules/forth-stack.mdc`, `forth-factoring.mdc` |

---

*Distillation for frules. Update when adding primary sources under `sources/` or new case studies.*

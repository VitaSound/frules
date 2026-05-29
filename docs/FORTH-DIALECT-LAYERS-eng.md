# Domain Dialects (Layer 0)

> **Russian:** [FORTH-DIALECT-LAYERS.md](FORTH-DIALECT-LAYERS.md)

Forth **natively** allows **foreign or declarative syntax** on top of the postfix core — not as “another language”, but as a **named, versioned facade** that expands at load/compile time into ordinary dictionary words.

Typical naming: **FORTH-&lt;domain&gt;** — e.g. **FORTH-BASIC**, **FORTH-Pascal**, **FORTH-HDL** — where the `FORTH-` prefix means “a dialect implemented with Forth”, not a separate runtime.

**Related documents:** [FORTH-ANS-PORTABILITY-LAYER-eng](FORTH-ANS-PORTABILITY-LAYER-eng.md) (layers 1–3) · [FORTH-SYSTEM-ARCHITECTURE-eng](FORTH-SYSTEM-ARCHITECTURE-eng.md) · [`forth-meta.mdc`](../rules/forth-meta.mdc) · [`forth-defining.mdc`](../rules/forth-defining.mdc) · [`forth-system-context.mdc`](../rules/forth-system-context.mdc)

---

## Contents

1. [Idea](#1-idea)
2. [Place in the layer model](#2-place-in-the-layer-model)
3. [How Forth does this](#3-how-forth-does-this)
4. [Three depths (do not conflate)](#4-three-depths-do-not-conflate)
5. [Discipline: FORTH-X specification](#5-discipline-forth-x-specification)
6. [ANS and environmental dependencies](#6-ans-and-environmental-dependencies)
7. [Less niche surface without replacing the core](#7-less-niche-surface-without-replacing-the-core)
8. [For agents and datasets](#8-for-agents-and-datasets)

---

## 1. Idea

Postfix and the stack are the **kernel notation** and **implementation face**. For a domain or for audiences blocked by postfix, the accepted pattern is:

> **surface syntax → parsing / compile words → colon definitions / prim / IR**

Surface “meta” looks **foreign** (like macros elsewhere), but in Forth it is **built-in**: `IMMEDIATE`, parsing words, `[`/`]`, recognizers, defining words — not a library hack.

**FORTH-&lt;domain&gt;** is not a promise to clone another language wholesale. It is a **contract**: what text is accepted, what it compiles to, which environmental dependencies are declared.

---

## 2. Place in the layer model

Full scheme (see [FORTH-ANS-PORTABILITY-LAYER-eng](FORTH-ANS-PORTABILITY-LAYER-eng.md)):

```mermaid
flowchart TB
    subgraph L0 ["Layer 0 — Domain dialect (FORTH-X)"]
        DIAL["Parsing / compile facade\nFORTH-HDL, FORTH-BASIC, …"]
    end
    subgraph L1 ["Layer 1 — Algorithms (ANS)"]
        ALG["`: sort` `: crc16` …"]
    end
    subgraph L2 ["Layer 2 — Adapters / shim"]
        SHIM["compat/*.fs, I/O glue"]
    end
    subgraph L3 ["Layer 3 — Platform (FMAP + hardware)"]
        PLAT["MM, EX-C, RP, prim, cross"]
    end
    L0 --> L1 --> L2 --> L3
```

| Layer | Content | Portability |
|-------|---------|-------------|
| **0. Domain dialect** | Syntax facade, compile-time expansion | **Per FORTH-X spec** (environmental dependency) |
| **1. Algorithms** | ANS colon definitions | Across targets with same wordsets |
| **2. Adapters** | Thin shims, compat | Changes rarely |
| **3. Platform** | FMAP, drivers, prim | Changes with hardware |

**FMAP** still describes **layer 3**. A layer-0 dialect **does not remove** Harvard, STC, or cross — it only defines **how the user or generator** reaches layers 1–3.

---

## 3. How Forth does this

Mechanisms (see [`forth-meta.mdc`](../rules/forth-meta.mdc), [`forth-defining.mdc`](../rules/forth-defining.mdc)):

| Mechanism | Role in FORTH-X |
|-----------|-----------------|
| **Parsing words** | Read foreign or declarative text until end marker |
| **`IMMEDIATE` / compile-only** | Different load-time vs run-time semantics |
| **`POSTPONE`, `[`/`]`** | Compile-time evaluation inside definitions |
| **Defining words** | “Create domain entity → dictionary word” templates |
| **Recognizers** (Gforth) | Alternate lexemes without breaking the outer interpreter |

The outcome is always the same: a **Forth dictionary** (colon defs, sometimes prim or data). No separate VM for “FORTH-BASIC” — a **subset compiler** or **transpiler** into layer 1 is enough.

---

## 4. Three depths (do not conflate)

| Depth | Meaning | Typical outcome |
|-------|---------|-----------------|
| **A. Syntax facade** | Different text → same colon words | Lower entry barrier; stack hidden in generated code |
| **B. Domain subset** | Fixed grammar for the task (HDL, ECU config, tables) | Spec + golden tests on expansion |
| **C. Full host of another language** | Original semantics, types, GC | Usually **not** a Forth goal; too expensive |

Forth is strongest at **A** and **B**. The name **FORTH-Pascal** usually means **B** (lite), not Free Pascal.

---

## 5. Discipline: FORTH-X specification

Without a spec, every project invents its own “BASIC” — **Babel in one dictionary**. Minimum for any **FORTH-X**:

1. **Id and version** — `FORTH-HDL v0.3`, not “just words in the project”.
2. **Block boundaries** — which words open/close the dialect.
3. **Expansion** — compile target (colon, data, IR); stack effects **at block boundaries**.
4. **Environmental dependencies** — required dictionary before load.
5. **Golden / regression** — dialect source → expected layer 1 or artifact.

One **standard per domain** beats ten ad-hoc syntaxes.

---

## 6. ANS and environmental dependencies

**ANS** is the **layer 1** contract (algorithms, control, memory model words).

**FORTH-X** is a **layer 0 environmental dependency**, same logic as ANS Appendix C wordsets:

```text
Environmental dependencies: FORTH-HDL v0.3
Required before load: hdl-module, hdl-assign, …
```

Portability of **FORTH-X source** = the same FORTH-X spec on the target, not “any Forth understands this text”.

Portability of **algorithms after expansion** — per [FORTH-ANS-PORTABILITY-LAYER-eng](FORTH-ANS-PORTABILITY-LAYER-eng.md).

---

## 7. Less niche surface without replacing the core

| Role | Sees | Forth remains |
|------|------|---------------|
| Domain author | FORTH-X syntax, declarative blocks | expanded dictionary |
| System author | postfix, cross, prim, FMAP | kernel |
| Port author | platform.fs, MM, EX-C | layer 3 |

Stack notation stops being the **only UI**, but stays in **implementation** and **debugging**.

**Risk:** layer 0 without versions and tests. **Fix:** spec + golden, like any compiler.

---

## 8. For agents and datasets

- Question **“how to write `: gcd`”** → `rules/forth-*.mdc`, not this document.
- Question **“do we need FORTH-X / how layers work / embedded niche”** → this doc + [FORTH-SYSTEM-ARCHITECTURE-eng](FORTH-SYSTEM-ARCHITECTURE-eng.md), [FORTH-FMAP-GUIDE-eng](FORTH-FMAP-GUIDE-eng.md), [`forth-system-context.mdc`](../rules/forth-system-context.mdc).
- In SFT: teach **expansion rules** (layer 0 → 1); do not mix FORTH-X syntax with ANS challenges without a dialect tag.

See also [MODEL-TRAINING.md](MODEL-TRAINING.md) § Embedded and FMAP.

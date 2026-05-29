# ANS as a Portable Algorithm Layer

> **Russian:** [FORTH-ANS-PORTABILITY-LAYER.md](FORTH-ANS-PORTABILITY-LAYER.md)

Thesis: if **algorithmic code** stays in an **ANS subset**, work carries over between **any** target — old 6502, STM8, Cortex-M, Gforth on Linux, or a **new** soft-CPU on FPGA. FMAP describes the **platform**; ANS is the **shared algorithm language** on top of it.

**Related documents:** [FORTH-DIALECT-LAYERS-eng](FORTH-DIALECT-LAYERS-eng.md) (layer 0) · [`forth-portability.mdc`](../rules/forth-portability.mdc) · [FORTH-FMAP-GUIDE-eng](FORTH-FMAP-GUIDE-eng.md) · [FORTH-HARDWARE-CODESIGN-eng](FORTH-HARDWARE-CODESIGN-eng.md) · [FORTH-FEATURE-COMPLEXITY-eng](FORTH-FEATURE-COMPLEXITY-eng.md)

---

## Contents

1. [Idea](#1-idea)
2. [Layers 0–3](#2-layers-03)
3. [What carries over](#3-what-carries-over)
4. [What stays on the platform](#4-what-stays-on-the-platform)
5. [FMAP and ANS: separation of concerns](#5-fmap-and-ans-separation-of-concerns)
6. [Co-design does not break portability](#6-co-design-does-not-break-portability)
7. [Development discipline](#7-development-discipline)
8. [Porting examples](#8-porting-examples)
9. [Limitations (honestly)](#9-limitations-honestly)
10. [For model training](#10-for-model-training)

---

## 1. Idea

Forth on different systems **looks** different (ITC vs STC, REPL vs frozen, Harvard vs unified). But **postfix algorithms** — sorting, parsing, CRC, PID, finite-state logic — **do not depend** on how the inner interpreter performs `NEXT` or `CALL`.

**ANS Forth** (DPANS94 and wordset profiles) defines:

- semantics of standard words;
- stack and number model;
- the contract “if a word exists, it behaves like this.”

If application code uses only a consistent **wordset subset**, you can:

1. Develop on **Gforth** (RP=5, MM=U).
2. Run on **FlashForth** (RP=4, STC, Harvard).
3. Cross-compile for a **custom FPGA** (RP=0, MM=V) — *if* the target implements the same wordsets.
4. Port to **6502** via TaliForth2 — with the same `.fs` core.

**Plus the frules ecosystem:** one algorithm style (`rules/forth-*.mdc`) + explicit marking of the platform-specific layer.

---

## 2. Layers 0–3

```mermaid
flowchart TB
    subgraph L0 ["Layer 0 — Domain dialect (FORTH-X)"]
        DIAL["Parsing / compile facade\noptional"]
    end
    subgraph L1 ["Layer 1 — Algorithms (ANS)"]
        ALG["`: sort` `: crc16`\n`: pid-step` …"]
    end
    subgraph L2 ["Layer 2 — Adapters / shim"]
        SHIM["Environmental deps\ncompat/*.fs\nconditional compilation"]
    end
    subgraph L3 ["Layer 3 — Platform (FMAP + hardware)"]
        PLAT["MM, EX-C, RP\nUART, PWM@, `@`/`!`\nboot, cross"]
    end
    L0 --> L1 --> L2 --> L3
```

| Layer | Contents | Changes when switching target? |
|-------|----------|--------------------------------|
| **0. Domain dialect** | **FORTH-X** — syntax facade, expands to dictionary (see [FORTH-DIALECT-LAYERS-eng](FORTH-DIALECT-LAYERS-eng.md)) | **Per FORTH-X spec**; optional |
| **1. Algorithms** | ANS colon definitions, data structures on `@`/`!` | **No** (if wordsets are the same) |
| **2. Adapters** | Dependency headers, `compat/`, I/O wrappers | **Rarely** (thin glue) |
| **3. Platform** | FMAP, drivers, prim, cross, memory map | **Yes** |

**FMAP** applies only to **layer 3**. Algorithm portability is **layer 1 + layer 2 discipline**. Layer 0 does not replace ANS; it is an **environmental dependency** above layer 1.

---

## 3. What carries over

With matching **Environmental dependencies**, the following carry over unchanged:

| Category | ANS word examples | Notes |
|----------|-------------------|-------|
| Stack, factoring | `dup` `swap` `rot` `nip` … | Universal |
| Integer arithmetic | `+` `-` `*` `/` `mod` `*/` … | Check cell size |
| Logic, comparison | `=` `<>` `<` `>` `and` `or` … | |
| Flow control | `if` `else` `then` `begin` `until` `case` … | |
| Loops | `do` `loop` `+loop` | |
| Memory (data model) | `@` `!` `c@` `c!` `+!` `create` `,` `allot` | Addresses via layer 2 |
| Strings (if STRING exists) | `place` `count` `find` … | Subset on embedded |
| Double (if DOUBLE exists) | `d+` `d*` … | See `forth-numeric.mdc` |
| ANS locals (if LOCALS exists) | `(local)` `locals\|` | Not Gforth `{ }` |
| Exceptions (if EXCEPTION exists) | `throw` `catch` | Align error codes |

**frules-challenges algorithms** (gcd, sort, parse) are typical **layer 1**: they know nothing about STM8 and J1.

---

## 4. What stays on the platform

| Does not port “as-is” | Why | Where it lives |
|-----------------------|-----|----------------|
| `KEY` / `EMIT` vs `?RX` / `TX!` | Different I/O | Layer 2: `io.fs` |
| `open-file`, paths | No FILE on MCU | Layer 2 or `#ifdef` wordset |
| Gforth `{ locals }` | Not ANS | Gforth only or shim |
| `CODE` / asm inline | CPU-specific | Layer 3 |
| `PWM@` / custom prim | Your hardware | Layer 3; algorithm calls via layer 2 |
| `HERE ,` in Flash | Harvard / NVM path | Layer 3; compile policy |
| Threading (ITC/STC) | Engine internal | **Invisible** to layer 1 |
| REPL / QUIT | RP | Layer 3 |

**Rule:** if a word is **not in ANS** and **not in declared wordsets** — it is **not** in layer 1.

---

## 5. FMAP and ANS: separation of concerns

```
FMAP answers:  “HOW is the system built?”
ANS answers:   “WHAT does this algorithm mean?”
```

| Question | Tool |
|----------|------|
| Need a REPL in the field? | FMAP **RP** |
| STC or ITC? | FMAP **EX-C** (algorithm does not care) |
| Is FILE available? | ANS wordset + FMAP **RP**/Flash |
| Will `: heapsort` port? | ANS CORE + ARRAY/STRING deps |
| Custom ECU registers? | FMAP **+HW**; algorithm via `: read-rpm` shim |

The “target → FMAP” table ([profiles JSON](../data/forth-fmap-profiles.json)) **does not replace** the ANS wordset profile of your application.

### Application ANS profile (recommended in project README)

```text
Required wordsets: CORE CORE-EXT STRING EXT
Optional: EXCEPTION DOUBLE
Forbidden extensions: Gforth { } (use LOCALS| or stack)
Environmental: cell=16 on AVR targets; cell=32 on ARM
```

---

## 6. Co-design does not break portability

Custom hardware ([HARDWARE-CODESIGN-eng](FORTH-HARDWARE-CODESIGN-eng.md)) changes **layer 3**, not the **semantics** of `: +` or `: find-tag`.

Strategy:

1. **Prim / MMIO** — only in `platform.fs` (layer 3).
2. **Drivers** — thin colon words with ANS stack effects (layer 2).
3. **ECU / NN schedule strategy** — ANS algorithms (layer 1).

```forth
\ platform.fs (layer 3 — custom FPGA)
: inj!  ( n ch -- )  ... hardware ... ;

\ engine.fs (layer 1 — portable if numbers match)
: fire-cylinder  ( ch duty -- )
    inj!  ;
```

On **Gforth** for simulation, `inj!` is written as `drop drop` or a mock — the **same** `engine.fs` runs in CI.

**Co-design + ANS:** you design **narrow hardware**, but a **broad** algorithm vocabulary with standard words — portability is preserved.

---

## 7. Development discipline

### 7.1 Directory structure (recommendation)

```
src/
  algo/           \ layer 1 — ANS only
  compat/         \ layer 2 — shims
  platform/
    gforth/       \ layer 3
    flashforth/
    my-fpga/
```

### 7.2 Header for each layer 1 file

```forth
\ Environmental dependencies: CORE EXT STRING
\ No implementation-defined words beyond ANS usage notes.
```

### 7.3 Pre-port check

```forth
include ans-report.fs
include src/algo/heapsort.fs
print-ans-report
```

See [`forth-portability.mdc`](../rules/forth-portability.mdc).

### 7.4 Top-down development

1. Algorithm on **Gforth** + ans-report → green.
2. Mock platform (stdio instead of UART).
3. Target platform: only **platform/** changes.
4. FMAP records **which** target (not algorithm contents).

---

## 8. Porting examples

### One module — three targets

| Target | FMAP (brief) | What changes |
|--------|--------------|--------------|
| Gforth Linux | U / RP=5 | `platform/gforth/io.fs` |
| FlashForth AVR | S / RP=4 / STC | `platform/flashforth/io.fs` |
| J1 FPGA | V / RP=0 | `platform/j1/io.fs` + cross |

**Shared:** `algo/*.fs` — **identical** (on 16-bit cell AVR — check numeric range).

### Old and new targets

| “Old” | “New” | What is shared |
|-------|-------|----------------|
| 6502 TaliForth2 | Cortex Mecrisp | ANS CORE algorithms |
| stm8ef | custom ECU FPGA | layer 1 if wordsets + cell size match |
| FIG-Forth 1979 | Gforth 2026 | porting idea; wordsets need verification |

**Historical link:** ANS formalized what the community **already** practiced — factored words, portable core.

---

## 9. Limitations (honestly)

ANS **does not** make code portable automatically:

| Limitation | Consequence |
|------------|-------------|
| Embedded **not full ANS** | Declare minimum wordsets; `#require` or `environment?` |
| **Cell size** 16 vs 32 vs 64 | Bit algorithms — use `cells`, test on both |
| **Missing FP / FILE / LOCALS** | Simplify algo or add compat |
| **Timing / IRQ** | Real-time — layer 3; ANS is not about microseconds |
| **Implementation-defined semantics** | `@`/`!` alignment — `forth-memory.mdc` |
| **Gforth habits** | `{ }`, `s\"`, dynamic strings — not ANS by default |

**ANS is not “write once run anywhere” like JVM**, but **“one algorithm, explicit dependencies, swap platform dir”**.

FMAP helps **not confuse** platform constraints with algorithm bugs.

---

## 10. For model training

When doing SFT, separate in context:

```text
Layer 1 (portable): ANS CORE+STRING — implement heapsort, no platform words.
Layer 3 (target): FMAP stm8ef MM=D EX-C=S — only if generating platform/io.fs.
```

**The model must not:**

- mix `{ locals }` into “portable algo” without marking it;
- generate HAL-style C in Forth for the portable layer;
- assume FILE on embedded without `environment?`.

**The model should:**

- document **Environmental dependencies**;
- propose **platform/** separately from **algo/**;
- use FMAP only for layer 3.

---

## Summary

| Claim | True? |
|-------|-------|
| ANS makes algorithms portable across targets | **Yes**, with layer discipline and wordsets |
| FMAP hinders portability | **No** — it describes a different layer |
| Co-design = unique non-portable code | **No** — hardware in layer 3, algo in ANS |
| Gforth-challenges = universal algo layer | **Yes** for CORE; dialect is Gforth |
| Old 6502 and new FPGA share algo | **Yes**, if both implement required wordsets |

**Practical frules takeaway:** keep the **algorithm library in ANS**, **platform adapters** thin, **FMAP** for choosing and documenting hardware — not for rewriting sort/gcd on every MCU.

---

*Hand-authored for frules.*

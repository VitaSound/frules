# Forth Feature Implementation Complexity

> **Russian:** [FORTH-FEATURE-COMPLEXITY.md](FORTH-FEATURE-COMPLEXITY.md)

Reference for **kernel**, **embedded port**, and **application** authors: what lies behind a “simple” Forth feature and why minimal systems deliberately omit it.

Not tied to specific frules challenges — describes **any** Forth system (eForth, FlashForth, Mecrisp, Gforth, SwiftForth, …).

Two levels in this reference:

1. **Minimal kernel (bootstrap)** — how many primitives to embed in asm/C so the rest can be defined in Forth.
2. **Feature complexity** — what to add after bootstrap and why embedded systems trim it.

See also: [`FORTH-FMAP-GUIDE-eng.md`](FORTH-FMAP-GUIDE-eng.md) (choosing a system for the task), [`FORTH-THREADING-eng.md`](FORTH-THREADING-eng.md) (ITC/DTC/STC, inner interpreter), [`FORTH-SYSTEM-ARCHITECTURE-eng.md`](FORTH-SYSTEM-ARCHITECTURE-eng.md) (FMAP/FTAS, Harvard, system catalog), [`forth-portability.mdc`](../rules/forth-portability.mdc), [`forth-dialect-gforth.mdc`](../rules/forth-dialect-gforth.mdc), [`docs/DIALECT-TEST.md`](DIALECT-TEST.md).

---

## Minimal kernel (bootstrap)

**Question:** which word set is enough to implement *outside* Forth (asm, C) so that colon definitions on top build a **working** interactive system?

**Short answer:** **~25–40 primitives** plus an **inner interpreter** (often not a user word, but engine code). On that foundation you raise the text interpreter, the `: … ;` compiler, and then extend the system entirely in Forth.

### Three levels of “minimum”

| Level | Size | What you get |
|-------|------|--------------|
| Academic | ~10–15 VM instructions | Proof of concept; interactive Forth is hard to achieve |
| Practical bootstrap (eForth, MAF, Gforth EC) | **~31–40 primitives** | Outer interpreter, `:`, `CREATE`, control flow, basic I/O |
| Comfortable embedded | ~50–80 primitives + some in Forth | ANS subset, acceptable speed, fewer hacks |

**Primitive criterion:** a word **cannot reasonably be synthesized** from others without temporary cells that themselves require `@`/`!` and dictionary addressing.

### What must live outside Forth (engine)

Not always exposed as “words”, but the system cannot exist without:

| Component | Purpose |
|-----------|---------|
| Inner interpreter | `NEXT` / `docol` / `doprim` loop — **ITC/DTC only**; STC has no inner loop — see [`FORTH-THREADING-eng.md`](FORTH-THREADING-eng.md) |
| Memory map | Stacks, dictionary heap, cold start |
| Word header format | Link, name, code field — at least implicitly in `CREATE` primitives |

Everything else is a candidate for definition in Forth.

### Reference: 31 eForth primitives (Muench / Ting)

Classic set (~200 system words, including outer interpreter and compiler, built **on top**):

**Inner interpreter / execution**

- `doLIST`, `EXIT`, `EXECUTE`, `doLIT`
- `?branch`, `branch`, `next` (or equivalent for loop model)
- machine `$NEXT` (not a user word)

**Memory:** `@`, `!`, `C@`, `C!`

**Stacks:** `SP@`, `SP!`, `DUP`, `DROP`, `SWAP`, `OVER`; `RP@`, `RP!`, `>R`, `R>`, `R@`

**Logic / arithmetic (minimum):** `0<`, `AND`, `OR`, `XOR`; **`UM+`** — the only “real” arithmetic (`+`, `-`, `*`, `/` are colon definitions)

**I/O / platform:** `?RX`, `TX!`, `!IO`, `BYE` (on MCU — UART instead of OS calls)

Source: eForth overview (vendored context — see community discussion and [Gforth manual: Forth is written in Forth](../sources/gforth-manual/review--002d-elements-of-a-forth-system.md)).

### Minimum by functional block

| Block | Minimum set |
|-------|-------------|
| VM | execute xt list + conditional/unconditional branch + literal in code |
| Two stacks | `DUP` `DROP` `SWAP` (+ `OVER` desirable); `>R` `R>` `R@` |
| Memory | `@` `!` (`C@` `C!` — almost always for names and strings) |
| Arithmetic | one of: `+`, `UM+`; one comparison: `0<`, `0=` or `=` |
| Compilation | `CREATE`, `,`, `:`/`;`, `LITERAL`/`doLIT`, xt reference (`'` or equivalent) |
| Control flow at compile time | `IMMEDIATE` **or** separate compile-only words (`goto`, `-exit` in bootstrap models) |
| Text interpreter | `KEY`/`EMIT` or `?RX`/`TX!` + name parsing + `FIND` + interpret/compile |

**Ultra-minimum (educational):** `@` `!` `>R` `R>` `+` `NAND` `?BRANCH` `EXECUTE` + entry for colon words — *theoretically* enough, but `DUP`, `IF`, `CREATE` are built via `HERE` and temporary cells; that is bootstrap, not product.

### Next layer (~100–200 words, already in Forth)

Typical “outer core” after primitives:

- arithmetic: `+`, `-`, `*`, `/`, `MOD`, `MIN`, `MAX`
- control flow: `IF`, `ELSE`, `THEN`, `BEGIN`, `UNTIL`, `DO`/`LOOP`
- dictionary: `VARIABLE`, `CONSTANT`, `VALUE`, `HERE`, `ALLOT`, `'`, `[']`
- meta: `[`, `]`, `STATE`, `IMMEDIATE`
- interpreter: `INTERPRET`, `EVALUATE`, `QUIT`, `#`/`$`/`BASE`, `.`/`CR`
- utilities: `DUMP`, `.S`, `SEE`

This layer is what makes the system **interactive and self-extending**.

### Pitfalls of a “too small” kernel

1. **Circular definitions** — without `@`/`!` and `HERE` you cannot allocate a temporary cell for `DUP`.
2. **Performance** — below ~30 primitives, code size and runtime grow sharply.
3. **Threading model** — DTC needs `EXECUTE`; STC needs a different set of “glue” words.
4. **Gforth** — compiler written in Forth, but startup comes from an **image file** + C loader; “bare engine + `.fs`” without an image will not bring up full Gforth.

### Working system formula

```
Working system =
  inner interpreter (asm/C)
+ ~31–40 primitives (stacks, memory, branches, one arithmetic, I/O)
+ ~150–200 words outer core (compiler + text interpreter, in Forth)
+ application vocabulary
```

Sections below describe **cost of features after** this bootstrap.

---

## How to read the scale

| Level | Meaning | Guide (one developer, kernel already exists) |
|-------|---------|----------------------------------------------|
| ★☆☆☆☆ | Almost inevitable part of minimal kernel | hours — a couple of days |
| ★★☆☆☆ | Typical “second layer” extension | several days |
| ★★★☆☆ | Separate submodule, noticeable code volume | ~1–2 weeks |
| ★★★★☆ | Compiler / runtime with non-trivial edge cases | several weeks |
| ★★★★★ | Subsystem on the scale of “second half of the system” | months |

Ratings are **relative**: they depend on target platform (MCU vs desktop), kernel style (threaded vs token), reentrancy requirements, and portability.

---

## Interpreter kernel

| Feature | Complexity | Notes |
|---------|------------|-------|
| Data stack + basic arithmetic/logic words | ★☆☆☆☆ | Foundation of any system |
| Dictionary (linked list / hash), `CREATE`, `: … ;`, `IMMEDIATE` | ★★☆☆☆ | Without this, no “real” Forth |
| Interpreter vs compiler (`[` / `]`) | ★★☆☆☆ | STATE, basic meta-compilation |
| Return stack, basic control flow (`if`/`begin`/`do`) | ★★☆☆☆ | Stack depth consistency on all paths — main pitfall |
| Number parser (`#` / `$` / `.`), `BASE` | ★★☆☆☆ | Often underestimated in a “minimal” kernel |

**Embedded:** usually stop here + `VARIABLE` + sometimes `VALUE`.

---

## Global mutable state

| Feature | Complexity | What to implement |
|---------|------------|---------------------|
| `VARIABLE`, `CREATE … ALLOT`, `@` / `!` | ★☆☆☆☆ | Cell in dictionary; address on stack |
| `CONSTANT`, `VALUE` (read) | ★★☆☆☆ | Defining word; literal stored in word body |
| `TO` for `VALUE` | ★★☆☆☆ | Compile-time name recognition; write to cell |
| `DEFER` / `IS` | ★★★☆☆ | Indirect threading or table; late binding |
| Multi-thread / reentrancy for global `VARIABLE` | ★★★★☆ | Either forbid, or per-task dictionaries / TLS |

**Embedded:** `VARIABLE` almost always present; `VALUE`/`TO` — often; `DEFER` — less often.

**Application code:** globals are fine for single-context firmware; for libraries, stack arguments are preferred (see `forth-anti-patterns.mdc`).

---

## Local variables

Separate from “variable” in the `VARIABLE` sense: this is a **compiler mechanism** — names bound to one word invocation.

| Feature | Complexity | What to implement |
|---------|------------|---------------------|
| Stack as the only “locals” | ★☆☆☆☆ | Already there; factoring discipline |
| Return stack (`>r` / `r@` / `r>`) as temporary storage | ★★☆☆☆ | Free in RAM; risk of leaks and conflict with `loop` |
| ANS `LOCALS\|` / `(LOCAL)` | ★★★☆☆ | Compile-time registration; runtime frame; index-based access words |
| Gforth-style `{ name … }` | ★★★★☆ | Block parser; locals stack / control-flow tags; codegen per name |
| `{ … }` + `TO` + rebinding in a loop | ★★★★☆ | Additional compile-time and runtime paths |
| Reentrant / nested locals with predictable semantics | ★★★★☆ | Coordination with `leave`, `exit`, quotations |

**Embedded:** locals are often **absent by design** (Flash, simplicity, predictable compilation).

**frules / Gforth:** locals are allowed and preferred over long `rot`/`pick`; see `forth-dialect-gforth.mdc`. For portable ANS code — stack or `LOCALS|`, not `{ }`.

---

## Defining words and data structures

| Feature | Complexity | Notes |
|---------|------------|-------|
| `CREATE` without `DOES>` | ★☆☆☆☆ | Constant template + allot |
| `DOES>` | ★★★☆☆ | Runtime “type” semantics; affects dictionary model |
| Fields (`field`, `struct` / Gforth `end-structure`) | ★★★☆☆ | Compile-time offsets; alignment (`aligned`) |
| Dictionaries / wordlists (ANS SEARCH-ORDER) | ★★★☆☆ | Contexts, `ALSO`/`PREVIOUS`, sealed vocabularies |
| OOP (`objects.fs` and similar) | ★★★★★ | Meta-compilation + dispatch + lifecycle |

---

## Meta-compilation and syntax

| Feature | Complexity | Notes |
|---------|------------|-------|
| `POSTPONE`, `[COMPILE]`, `IMMEDIATE` | ★★★☆☆ | Basic “extension language” level |
| Parsing words (`S"`, `.(`, `[CHAR]`) | ★★★☆☆ | TIB, compilation state |
| Recognizers / non-standard syntax | ★★★★☆ | Gforth-specific; high port cost |
| Quotations (`[: … ;]`, `noname`) | ★★★☆☆ | Anonymous xt; interaction with locals and GC |

---

## Memory and addressing

| Feature | Complexity | Notes |
|---------|------------|-------|
| Static dictionary (only `ALLOT` in dictionary heap) | ★★☆☆☆ | Typical for MCU |
| `HEAP`, `ALLOCATE` / `FREE` | ★★★☆☆ | Fragmentation, `-9` errors, embedded policy |
| `MOVE` / `CMOVE`, alignment | ★★☆☆☆ | Portable address units — see `forth-memory.mdc` |
| Blocks (`BLOCK`, 1024-byte sectors) | ★★★☆☆ | Legacy; on modern systems — files |

---

## I/O and environment

| Feature | Complexity | Notes |
|---------|------------|-------|
| `EMIT` / `KEY` / `TYPE` via UART | ★★☆☆☆ | Minimal embedded I/O |
| `INCLUDE` / `REQUIRE`, search path | ★★★☆☆ | File system or ROM image |
| ANS `FILE` wordset (`open-file`, …) | ★★★☆☆ | Depends on OS or FAT/LittleFS |
| CLI arguments, `ARGV` | ★★☆☆☆ | Desktop; often absent on MCU |

---

## Exceptions and debugging

| Feature | Complexity | Notes |
|---------|------------|-------|
| `ABORT` / `ABORT"` | ★★☆☆☆ | Without stack unwinding |
| `THROW` / `CATCH` | ★★★☆☆ | Save/restore stacks |
| Gforth `TRY` / `ENDTRY` / `RECOVER` | ★★★★☆ | Structured exceptions on top of catch |
| `SEE`, backtrace, assertions | ★★★☆☆ | Development tools; often stripped on target MCU |

---

## Numbers and strings

| Feature | Complexity | Notes |
|---------|------------|-------|
| Single precision (`*`, `/MOD`, `M*`) | ★★☆☆☆ | Kernel |
| Double precision (`D+`, `UM/MOD`, pictured numeric) | ★★★☆☆ | Separate coding style |
| FP wordset | ★★★★☆ | Second stack or tagged values; soft-float on MCU |
| ANS counted strings `c-addr u` | ★★☆☆☆ | Basic model |
| Gforth dynamic strings (`$VARIABLE`, `$@`, `$!`) | ★★★☆☆ | Heap + ownership conventions |

---

## Cross-compiler and images

| Feature | Complexity | Notes |
|---------|------------|-------|
| Standalone image / save-system | ★★★★☆ | Platform-dependent |
| Cross-compiler (host → target) | ★★★★★ | Separate product (Gforth cc, Mecrisp embed, …) |
| Relocatable dictionary | ★★★★☆ | Addresses, CFA, symbol tables |

---

## Why simple embedded systems trim features

1. **Flash and RAM** — locals, FILE, FP, OOP multiply both compiler code and runtime.
2. **Predictability** — less compile-time “magic” → easier debugging on hardware.
3. **Reentrancy** — globals and locals without an explicit model are dangerous in interrupts and co-routines.
4. **Portability between MCUs** — easier to keep a minimal ANS subset.
5. **Port speed** — new hardware = new UART and dictionary, not a new `{ }` parser.

---

## Substitutes for missing features (any task)

| Need | Only minimal kernel available |
|------|-------------------------------|
| Named intermediate values | Factoring; stack; return stack (carefully) |
| Algorithm state between calls | `CREATE … ALLOT` + explicit indices; buffer write |
| Parameterization without globals | Stack arguments; xt on stack; `DEFER` if available |
| Dynamic memory | Static pools; fixed-size buffers |
| Port from Gforth to embedded | Remove `{ }`, dynamic strings, `TRY`; check `environment?` |
| Port from desktop to ANS | `ans-report.fs`; **Environmental dependencies** header |

frules rule: **do not pull Gforth extensions into an ANS target** without a shim or refactor — see `forth-portability.mdc`.

---

## Practical choice for a new port

Recommended build order (each step gives maximum benefit per unit of complexity):

1. Kernel + dictionary + control flow  
2. `VARIABLE` / `CREATE` / `@` / `!`  
3. `VALUE` (optionally `TO`)  
4. Counted strings + basic I/O  
5. `THROW` / `CATCH` or project error equivalent  
6. `FILE` or ROM `INCLUDE`  
7. ANS `LOCALS|` **or** “stack-only” discipline (not necessarily both)  
8. Gforth `{ }`, dynamic strings, structs — only if target platform = Gforth-class  

---

## Relation to frules

| Context | Guide |
|---------|-------|
| `dialect=gforth`, desktop, challenges | locals, Gforth strings — OK |
| `dialect=ans`, multiple Forth systems | no `{ }`; standard wordsets |
| Embedded / cross-compile | design on the stack; globals only for hardware and singleton state |
| Model training | in dataset explicitly mark **environmental dependencies**, target system **FMAP**, and **algo/platform separation** — see [`FORTH-ANS-PORTABILITY-LAYER-eng.md`](FORTH-ANS-PORTABILITY-LAYER-eng.md), [`FORTH-SYSTEM-ARCHITECTURE-eng.md`](FORTH-SYSTEM-ARCHITECTURE-eng.md) §13, [`data/forth-fmap-profiles.json`](../data/forth-fmap-profiles.json) |

When adding a new `forth-dialect-*.mdc` for an embedded system — record the **wordset subset** and missing features; implementation complexity of gaps — from the tables above; system profile — in FMAP JSON.

---

*Hand-authored for frules.*

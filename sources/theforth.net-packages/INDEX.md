# theForthNet packages — index

Catalog of vendored libraries under `sources/theforth.net-packages/`. Use **`/<pkg>/current/`** (symlink to pinned version from `current-version`) unless you need an older release.

**Upstream:** [theforth/theforth.net-packages](https://github.com/theforth/theforth.net-packages) · [theforth.net/packages](https://theforth.net/packages)

**Purpose in frules:**

| Use | Action |
|-----|--------|
| Challenge solutions | Copy **ideas/fragments** into paste zone; prefer inlining over fragile `include` from `tests/challenges/` ([`docs/AGENT-SOLVE-CHALLENGES.md`](../../docs/AGENT-SOLVE-CHALLENGES.md)) |
| Rules (`rules/*.mdc`) | **Selective distillation only** — see [Distill candidates](#distill-candidates) |
| Already covered | Idiom present in Gforth manual / Brodie distill — treat as **reference impl**, do not duplicate in rules |

**Coverage legend**

| Tag | Meaning |
|-----|---------|
| `covered` | Topic already in `rules/` (Gforth manual or Brodie pass) |
| `gap` | Reusable idiom not yet spelled out in rules — distill candidate |
| `ref` | Good code to read when solving; rarely belongs in rules |
| `skip` | Demo, game, tooling, or domain-specific — index only |

**Search:** `rg -l 'pattern' sources/theforth.net-packages/<pkg>/current/`

---

## By frules topic

Quick map from `rules/frules-index.mdc` topics to packages (prefer `current/` paths).

| Topic / rule file | Packages | Notes |
|-------------------|----------|-------|
| `forth-stack` | `stack`, `stringstack`, `mrot` | Auxiliary stacks; `-rot` shim |
| `forth-control` | `break`, `tail-jump`, `co`, `callec` | Advanced control; mostly `ref`/`gap` |
| `forth-defining` | `priority-queue`, `bit-arrays`, `compat/struct.fs`, `objects` | `Create`/`does>` field layouts, queues |
| `forth-memory` | `ll`, `dynamic-memory-allocation`, `bounds`, `compat/struct.fs` | Lists, heap, Schleisiek allocator |
| `forth-strings` | `stringstack`, `base64`, `sprintf`, `compat/strcomp.fs` | String stack, encode/format |
| `forth-io` | `screens`, `zip`, `libcurl`, `lcd-hd44780`, `i2c` | Files, blocks, embedded I/O |
| `forth-meta` | `interpretive`, `immediate`, `minimal`, `compat/macros.fs`, `compat/defer.fs` | Compile state, immediacy, shims |
| `forth-wordlists` | `modules`, `package`, `mwords`, `interpretive` | MODULE/EXPORT, search tools |
| `forth-numeric` | `fixed`, `CRC-8`, `sprintf`, `euler303` | Fixed-point, table algorithms |
| `forth-floating-point` | `matmul`, `sfp`, `compat` (float fields) | FP matrix, soft float |
| `forth-debugging` | `break`, `compat/assert.fs`, `testy` | Assertions, debug control |
| `forth-portability` | `compat/*`, `minimal`, `swoop-compat` | ANS shims, multi-system harnesses |
| `forth-oof` | `objects`, `swoop-compat` | Ertl objects; portable Swoop |
| `forth-c-bindings` | `libcurl`, `gencon` | Foreign calls, generated libs |
| `forth-factoring` / `forth-style` | (prose sources) | Use Brodie, not these libs |

---

## Distill candidates

Packages worth a **selective** pass into existing `rules/*.mdc` (not a full Brodie-style sweep). **Done 2026-05-29** for high/medium rows below → see `docs/SOURCES.md`.

| Priority | Package | Target rule(s) | Idiom | Status |
|----------|---------|----------------|-------|--------|
| high | `compat/struct.fs` | `forth-defining`, `forth-memory` | `+field`, `field:`, aligned struct layout | **done** |
| high | `ll` | `forth-memory`, `forth-control` | `ll-traverse`, `ll,`, exception on nil | **done** |
| high | `priority-queue` | `forth-defining`, `forth-memory` | `Priority-Queue:` header + `q!` insert pattern | **done** |
| high | `modules` | `forth-wordlists`, `forth-defining` | `MODULE` / `EXPORT` / `does>` export thunk | **done** |
| medium | `interpretive` | `forth-meta`, `forth-wordlists` | `interpretive{ … }interpretive` search-order trick | **done** |
| medium | `immediate` | `forth-meta` | `[IMMEDIATE]` before `;` — compile-state pitfall | **done** |
| medium | `stack` | `forth-stack` | Separate cell stack (`STACK`, `SET-STACK`) | **done** |
| medium | `stringstack` | `forth-strings` | `"push` / `"th` string stack for parsing | **done** |
| medium | `fixed` | `forth-numeric` | `PLACES`, implied decimal (non-FP-stack fixed point) | **done** |
| low | `break` | `forth-control` | `BREAK`/`CONTINUE` as immediate wrappers | pending |
| low | `bounds` | `forth-memory` | One-liner `( c-addr u -- end start )` | **done** (with `ll`) |
| low | `dynamic-memory-allocation` | `forth-memory` | Portable `allocate`/`free`/`resize` block list | pending (covered by manual) |
| ref only | `objects`, `recognizers`, `callec`, `tail-jump`, `co` | various | Deep/specialist — cite in challenges, distill only if topic gets new `.mdc` | ref |

---

## Package catalog

44 top-level packages. **Current** = contents of `current-version`.

### Data structures & memory

| Package | Cur | Main files (`current/`) | Topics | Idioms | Coverage |
|---------|-----|---------------------------|--------|--------|----------|
| `ll` | 1.0.2 | `ll.fs` | memory, control | singly-linked list, `ll-traverse`, `ll-remove` | **gap** |
| `priority-queue` | 1.0.0 | `priority-queue.fs` | defining, memory | `Priority-Queue:`, sorted insert in array | **gap** |
| `stack` | 1.0.0 | `Stack.4th` | stack | auxiliary cell stack region | **gap** |
| `stringstack` | 1.0.3 | `stringstack.fs` | strings | `"push`, `(" …`)`, `"th` pick from string stack | **gap** |
| `bit-arrays` | 3.0.2 | `bit_arrays.f` | memory, numeric | `BIT@`, `BIT!`, `BOOL@` on packed bits | ref |
| `bounds` | 1.0.0 | `bounds.4th` | memory | `: bounds ( c-addr u -- end start )` | covered / tiny supplement |
| `dynamic-memory-allocation` | 1.0.2 | `dynamic.fs` | memory | Schleisiek-style `allocate`/`free`/`resize` | ref (ANS heap in rules) |
| `objects` | 1.1.1 | `objects.fs`, `struct.fs` | defining, oof, memory | Ertl object model; needs `compat/struct.fs` | ref (+ `forth-oof`) |
| `compat` | 1.1.0 | `struct.fs`, `defer.fs`, `assert.fs`, … | portability, defining, meta | Gforth features back-ported to ANS | **gap** (struct/defer) |

### Control flow & continuations

| Package | Cur | Main files | Topics | Idioms | Coverage |
|---------|-----|------------|--------|--------|----------|
| `break` | 1.0.0 | `break.fs` | control, meta | `BREAK`/`CONTINUE` redefining `BEGIN`/`DO` | gap (advanced) |
| `tail-jump` | 0.0.1 | `tail-jump.fs` | control, meta | `::` labels, `;;` tail-call, compile-stack save | ref |
| `callec` | 0.0.2 | `callec.fs` | control, dialect | `CALL/EC:` escape continuation (uses `RP@`) | ref / Gforth |
| `co` | 0.0.1 | `co.fs`, `synco.fs` | control | coroutines `CO:` / `GO`, ring buffer | ref |
| `mrot` | 1.0.0 | `mrot.4th` | stack | `-rot` when missing | covered |

### Meta, wordlists, compilation

| Package | Cur | Main files | Topics | Idioms | Coverage |
|---------|-----|------------|--------|--------|----------|
| `modules` | 1.0.2 | `modules.fs` | wordlists, defining | `MODULE`, `EXPORT` (`does>`), `END-MODULE` | **gap** |
| `package` | 0.1.2 | `package-iforth.fs`, … | wordlists | SwiftForth `PACKAGE`/`PUBLIC`/`PRIVATE` | ref |
| `interpretive` | 1.0.2 | `interpretive.fs` | meta, wordlists | Words visible only in interpret state | **gap** |
| `immediate` | 0.9.0 | `immediate.fs` | meta | `[IMMEDIATE]` early marking | **gap** |
| `recognizers` | 2.1.0 | `Recognizer.4th`, `rec-*.4th` | meta | Recognizer playground (RFD rev 4) | covered + ref examples |
| `mwords` | 1.0.1 | `mwords.fs` | meta, wordlists | `mwords`, `voc-mwords` filtered `WORDS` | ref |
| `minimal` | 1.1.1 | `primitives.fs`, `secondaries.fs` | meta, portability | Minimal Forth workbench bootstrap | ref |

### Strings, encoding, formatting

| Package | Cur | Main files | Topics | Idioms | Coverage |
|---------|-----|------------|--------|--------|----------|
| `base64` | 1.0.0 | `base64.f` | strings, io | Base64 encode/decode | ref |
| `sprintf` | 1.0.2 | `sprintf.fth` | strings, numeric | `SPRINTF`, `PRINTF`, format subset | ref (`forth-strings`) |
| `CRC-8` | 0.1.0 | `CRC-8.4th` | numeric | table-driven CRC-8 at run time | ref |

### Numeric & floating point

| Package | Cur | Main files | Topics | Idioms | Coverage |
|---------|-----|------------|--------|--------|----------|
| `fixed` | 1.0.0 | `fixed_vfx.fth` | numeric | `PLACES`, fixed-point in single cell | **gap** |
| `matmul` | 2.0.2 | `matmul.4th` | floating-point | `matmul ( a b c ncols nrows -- )` | ref |
| `sfp` | 1.0.0 | `sfp_vfx.fth`, … | floating-point | Soft float implementations | ref |
| `euler303` | 1.0.0 | `euler303.fs` | numeric | Project Euler #303 reference solution | skip |

### I/O, files, embedded

| Package | Cur | Main files | Topics | Idioms | Coverage |
|---------|-----|------------|--------|--------|----------|
| `screens` | 1.0.0 | `screens.fs`, `screenfile.fs` | io | Block/screen load, `+LOAD`, `slurp-file` shims | ref (legacy) |
| `zip` | 0.1.1 | `zip.4th`, `selfzip.4th` | io, memory | PKZip store-only archive writer | ref |
| `libcurl` | 1.0.0 | `libcurl.4th` | io, c-bindings | libcurl wrapper | ref |
| `lcd-hd44780` | 0.1.0 | `lcd-hd44780.4th` | io | HD44780 LCD bit-bang driver | skip |
| `i2c` | 1.0.3 | `package.4th` + driver | io | Generic I2C words | skip |
| `forthvector` | 0.0.1 | `demo*.fs`, `sincos.fs` | io | Tek 4014 vector graphics | skip |

### Crypto, games, tooling

| Package | Cur | Main files | Topics | Idioms | Coverage |
|---------|-----|------------|--------|--------|----------|
| `keccak` | 1.1.2 | `keccak.4th` | numeric | SHA-3 / Keccak sponge | skip |
| `nige-zapper` | 0.1.0 | `zapper.4th` | — | N.I.G.E. space shooter demo | skip |
| `forever-continuation-riddle` | — | `0.1.0/*.fs~` only | control | Incomplete upstream snapshot | skip |
| `gencon` | 0.1.0 | `gencon.fs` | c-bindings | Generate C → Forth constant libs | skip |
| `f` | 0.2.4 | `api.4th`, `versions.4th` | — | theForthNet package manager | skip |
| `testy` | 0.2.7 | (internal) | debugging | Package manager test harness | skip |
| `ttester` | 1.1.0 | `ttester.4th` | — | Duplicate of [`tests/ttester.4th`](../../tests/ttester.4th) | skip (use `tests/`) |
| `swoop-compat` | 0.9.1 | `Gforthharness.fs`, tests | oof, portability | Portable Swoop OOP harness | ref |

### Concurrency

| Package | Cur | Main files | Topics | Idioms | Coverage |
|---------|-----|------------|--------|--------|----------|
| `multi-tasking` | 0.4.0 | `spinlock.fs`, `clh.fs`, … | — | Spinlocks, Linux task support | skip (embedded/host-specific) |

---

## Challenge-oriented hints

Train bank `001`–`139` is integer/scalar-heavy. Packages most often useful when **inlining patterns** (not whole-library `include`):

| Pattern in challenges | Look at |
|----------------------|---------|
| Linked lists, reorder, partition | `ll` |
| Heap / priority / scheduling | `priority-queue` |
| Bit tricks, sets | `bit-arrays` |
| String building / parsing | `stringstack`, `sprintf` |
| Separate evaluation stack | `stack` |
| Wordlist isolation / hide helpers | `modules`, `mwords-hide` pattern in `mwords` |
| `CREATE`/`DOES>` field access | `compat/struct.fs`, `priority-queue` |
| Exception on empty structure | `ll`, `priority-queue` (`throw` constants) |

No gold solution in `data/challenge-solutions/` currently cites these paths by name — agents should discover via this index or `rg`.

---

## Version layout

```
<pkg>/
  current-version    # e.g. "1.0.2"
  current -> 1.0.2/  # symlink (when present)
  recent-version
  <semver>/
    package.4th
    *.4th | *.fs | *.fth
```

Prefer **`/<pkg>/current/`** in docs and agent prompts. Multiple semver dirs are retained for reproducibility; do not index every old version separately.

---

## Related frules docs

| File | Role |
|------|------|
| [`docs/SOURCES.md`](../../docs/SOURCES.md) | Provenance row for vendored tree |
| [`docs/DISTILL-PROMPT.md`](../../docs/DISTILL-PROMPT.md) | Template when pulling idioms into `rules/` |
| [`docs/AGENT-SOLVE-CHALLENGES.md`](../../docs/AGENT-SOLVE-CHALLENGES.md) | How agents may use `sources/` |
| [`TODO.md`](../../TODO.md) | Selective distillation follow-up after this index |

**Status:** indexed 2026-05-29 · **selective distillation done** (high/medium candidates → `rules/*.mdc`, see `docs/SOURCES.md`).

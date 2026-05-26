# tests/ — Forth-level regression tests

Each file under `tests/ans/` and `tests/gforth/` is a self-contained Forth program that defines a word, runs assertions via the vendored Hayes/Ertl `ttester` (loaded through `_tester.fs`), and prints either `TESTS OK` or `TESTS FAILED: N`.

The top-level `./test.sh` runs every file with the appropriate engine and reports a single line per case.

## Harness

- `ttester.4th` — verbatim upstream `T{ <code> -> <expected stack> }T` from John Hayes (JHU/APL 1995) with subsequent revisions by Anton Ertl, David N. Williams, Krishna Myneni and C. G. Montgomery. Public domain. Source: `http://www.complang.tuwien.ac.at/cvsweb/cgi-bin/cvsweb/gforth/test/ttester.fs`.
- `ttester-ext.4th` — VitaSound extensions (`expect-true`, `expect-false`, `expect-eq`, `expect-not-eq`, `expect-depth`, `expect-stack-clean`, `expect-stack-balanced`, `expect-str-eq`, plus `TS{ ... }ST` fixture hooks routed through `DEFER test-setup` / `DEFER test-teardown`). Public domain. Source: `https://github.com/VitaSound/ttester`.
- `_tester.fs` — thin wrapper that `include`s both files and defines `report` (`TESTS OK` / `TESTS FAILED: N`, reading `#errors @`).

## Layout

```
tests/
  _tester.fs                 # wrapper around ttester + `report`
  ttester.4th                # vendored Hayes/Ertl upstream
  ttester-ext.4th            # vendored VitaSound extensions
  ans/                       # pure DPANS94 — must pass on gforth + pforth
    _tester.fs       -> ../_tester.fs
    ttester.4th      -> ../ttester.4th
    ttester-ext.4th  -> ../ttester-ext.4th
    factorial.fs
    gcd.fs
    safe-divide.fs
    count-char.fs
    fizzbuzz.fs
    parse-int.fs
    sum-array.fs
    palindrome.fs
  gforth/                    # Gforth-only — uses { } locals etc.
    _tester.fs       -> ../_tester.fs
    ttester.4th      -> ../ttester.4th
    ttester-ext.4th  -> ../ttester-ext.4th
    gcd-locals.fs
    clamp-locals.fs
```

## Coverage map

| Test | Exercises |
|------|-----------|
| `factorial`     | `forth-stack`, `forth-control`, `forth-defining` (RECURSE) |
| `gcd`           | `forth-control` (BEGIN/WHILE), tuck/mod stack discipline |
| `gcd-locals`    | `forth-dialect-gforth` (locals + TO) |
| `clamp-locals`  | `forth-dialect-gforth`, `forth-factoring` |
| `safe-divide`   | `forth-anti-patterns`, THROW/CATCH, wrapper word for `[']` |
| `count-char`    | address/length string handling, no R: / DO conflict |
| `fizzbuzz`      | `forth-style` (no magic numbers), nested IF |
| `parse-int`     | `>NUMBER` plumbing, flag conventions, two-output contract |
| `sum-array`     | `forth-defining` (CREATE/DOES>), portable CELLS scaling |
| `palindrome`    | address/length, char access, recursion on shrinking range |

## Adding a new test

1. Decide ANS-portable or Gforth-specific.
2. Create `tests/<dialect>/<name>.fs` with:
   ```forth
   include _tester.fs
   : your-word ( ... -- ... ) ... ;
   T{ <inputs> your-word -> <expected stack> }T
   report bye
   ```
   Expected results are listed in stack order, bottom-to-top — for a word with stack effect `( -- n flag )` write `-> n flag`. Use `expect-*` predicates from `ttester-ext.4th` when you want named assertions (`T{ 1 2 + 3 expect-eq -> }T`).
3. Add a row to the coverage map above and to `docs/SOURCES.md` if it exercises a freshly added rule.
4. `./test.sh` — must end with exit code 0.

## Engine quirks to know

- **gforth** loads files in batch only with `-e bye` appended; otherwise it falls into the interactive REPL. `test.sh` handles this for load-only checks of `examples/`. Test files end with `report bye` and run via `gforth file.fs`.
- **pforth** always prints `INCLUDE error on line #N` after `bye` at the end of a file. This is benign noise; `test.sh` ignores it and grep's for `TESTS OK`.
- **`[char] x`** is compile-only — at interpret level use `char x` (see `rules/forth-anti-patterns.mdc`).
- **`R@` inside `DO`/`?DO`** returns the loop index, not what you pushed via `>R` (see `rules/forth-control.mdc`).

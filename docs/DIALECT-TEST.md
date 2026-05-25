# Dialect switching — verification

Two Forth engines on this machine:

| Engine | Where | Used for |
|--------|-------|----------|
| `gforth` 0.7.9 | `/usr/local/bin/gforth` | `examples/gforth/*.fs` and `examples/ans/*.fs` |
| `pforth` 2.0.1 | `/usr/bin/pforth` | `examples/ans/*.fs` (portability check) |

## Example layout

```
examples/
  gforth/     # Gforth idioms: { locals }, s\", bin file mode, $@ …
  ans/        # Pure DPANS94: no Gforth-only words; runs on both engines
```

`test.sh` runs Gforth-only examples on `gforth`, and ANS examples on **both** engines.

## Dialect-switch matrix

| Scenario | Command | Expected `.cursor/rules/` |
|----------|---------|---------------------------|
| Fresh ANS install | `./install.sh <proj> ans` | base rules + `frules-dialect.mdc` → ans template, **no** `forth-dialect-gforth.mdc` |
| Fresh Gforth install | `./install.sh <proj> gforth` | base rules + ans→**gforth** marker + `forth-dialect-gforth.mdc` |
| ANS → Gforth | re-run with `gforth` | marker swapped, gforth file linked |
| Gforth → ANS | re-run with `ans` | marker swapped, gforth file **removed** |
| `core` profile | add `core` arg | only `forth-{stack,style,anti-patterns}.mdc` (+ marker + index + dialect) |

`install.sh` only removes symlinks that point back into this `frules` checkout — your own rules in `.cursor/rules/` are never touched.

## How to verify after changes

```bash
./test.sh                                  # examples compile on both engines
./install.sh /tmp/probe-ans  ans          >/dev/null
./install.sh /tmp/probe-gf   gforth       >/dev/null
diff <(ls /tmp/probe-ans/.cursor/rules) <(ls /tmp/probe-gf/.cursor/rules)
# Expected diff: gforth side has the extra `forth-dialect-gforth.mdc`
```

## Adding a third dialect (later)

1. New rule file: `rules/forth-dialect-<name>.mdc`.
2. New marker: `templates/frules-dialect-<name>.mdc` (`alwaysApply: true`).
3. Update `install.sh`:
   - allowed value in `DIALECT` case;
   - branch that appends `forth-dialect-<name>.mdc` to `DIALECT_TOPICS`.
4. Add a folder `examples/<name>/` with engine-specific samples.
5. Extend `test.sh` to run them with the appropriate binary.
6. Update `docs/SOURCES.md` and this file.

## What this does NOT prove

The matrix verifies that the **install machinery** swaps files correctly. It does not yet verify that a model **prompted with the ANS profile actually avoids Gforth-isms** — that is the next loop (see `tests/README.md` for the assertion suite that codifies the rules).

## Engine quirks observed during build-out

- `gforth file.fs` stays interactive without `-e bye` appended.
- `pforth -q file.fs` prints a benign `INCLUDE error on line #N` after `bye` and exits 0; ignore it.
- `[char] x` is compile-only — use `char x` at interpret level.
- `R@` inside `?DO` returns the loop index, not what you saved via `>R`.

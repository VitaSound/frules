# Changelog

All notable changes to `frules` are recorded here.

Format: [Keep a Changelog](https://keepachangelog.com/en/1.1.0/) · Versioning: [SemVer](https://semver.org/).

## [0.1.1] — 2026-05-27

### Changed

- **Test harness:** the ad-hoc `t=` / `report` pair was replaced by the vendored Hayes/Ertl `ttester` (`tests/ttester.4th` upstream verbatim + `tests/ttester-ext.4th` with VitaSound `expect-*` predicates and `TS{ … }ST` fixture hooks; both public domain, taken from `https://github.com/VitaSound/ttester`). `tests/_tester.fs` is now a thin wrapper that includes both files and defines `report` against `#errors @`. All 10 existing test files migrated to `T{ … -> … }T`. This makes the suite drop-in compatible with the upstream Hayes test sets (gforth's own `test/`, FSL test files, etc.).

## [0.1.0] — 2026-05-25

First usable cut. AI rules for Forth, Gforth-oriented with portable ANS fallback. Validated against `gforth 0.7.9` and `pforth 2.0.1`.

### Added

- **Rules** (`rules/`, English-only bodies):
  - `forth-stack.mdc` — postfix, stack-effect comments, balance.
  - `forth-style.mdc` — naming, layout, magic numbers, variables, structured programming.
  - `forth-factoring.mdc` — small words, bottom-up, rule of three, components.
  - `forth-control.mdc` — flags, IF/loops, return stack discipline (with `R@` vs `?DO` warning).
  - `forth-defining.mdc` — `CREATE/DOES>`, IMMEDIATE, `xt`, `postpone`, `recurse`.
  - `forth-portability.mdc` — `CELL`/`CHARS`, address units, double-cell word set, `ior` checks.
  - `forth-anti-patterns.mdc` — imperative habits, PICK/ROLL, string literal mistakes, `[char]` at interpret level.
  - `forth-dialect-gforth.mdc` — Gforth strings, locals `{ … }`, includes/require, FP, structs, tooling.
  - `frules-index.mdc` — precedence policy on conflicting rules.
- **Dialect markers** (`templates/`): `frules-dialect-gforth.mdc`, `frules-dialect-ans.mdc` (`alwaysApply: true`).
- **Installer** (`install.sh`): symlink-based, profiles `full` / `core`, dialect from `frules.conf` or CLI; prunes stale links it owns and never touches manual user rules.
- **Examples**:
  - `examples/gforth/{good,bad}.fs` — Gforth idiomatic / anti-pattern showcase.
  - `examples/ans/portable.fs` — DPANS94, passes on both engines.
- **Tests** (`tests/`, 22 cases green on both engines):
  - portable ANS: `factorial`, `gcd`, `safe-divide`, `count-char`, `fizzbuzz`, `parse-int`, `sum-array`, `palindrome`.
  - Gforth-only: `gcd-locals`, `clamp-locals`.
  - `_tester.fs` — minimal portable `t=` / `report` harness.
- **Test runner** `test.sh` — examples in load mode, tests in assertion mode; recognises and ignores pforth's harmless post-`bye` "INCLUDE error" noise; uses `-e bye` for gforth load mode.
- **Docs**:
  - `README.md` (RU, человеческий обзор) and `AGENTS.md` (EN, для агента).
  - `docs/RULES-ARCHITECTURE.md` — как Cursor реально собирает правила в контекст; bundling vs path-scoped vs manual.
  - `docs/DIALECT-TEST.md` — матрица переключения диалектов и engine quirks.
  - `docs/SOURCES.md` — происхождение каждого правила и набора тестов.
  - `docs/DISTILL-PROMPT.md` — English-промпт для перегонки книги из `sources/` в `.mdc`.
  - `tests/README.md` — карта «тест → правило».
- **Config**: `frules.conf` с `dialect=gforth`, `frules.conf.example` шаблон.
- **VCS hygiene**: `.gitignore` (artifacts `.cursor/rules/`, локальные конфиги, бинарные книги в `sources/`).
- **Roadmap**: `TODO.md`.

### Verified

- 22/22 tests green via `./test.sh` (gforth 0.7.9 + pforth 2.0.1 on Ubuntu).
- Dialect switching ANS↔Gforth in throw-away project directories: marker swap and prune verified (see `docs/DIALECT-TEST.md`).
- Reproducible across separate Cursor chat sessions on the same workspace.

### Known quirks

- `pforth` emits a benign `INCLUDE error on line #N` after `bye` at file end. Ignored by `test.sh`.
- `gforth file.fs` without `-e bye` stays in the REPL — `test.sh` handles this for load-mode checks.

[0.1.1]: https://github.com/VitaSound/frules/releases/tag/v0.1.1
[0.1.0]: https://github.com/VitaSound/frules/releases/tag/v0.1.0

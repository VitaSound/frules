# Changelog

All notable changes to `frules` are recorded here.

Format: [Keep a Changelog](https://keepachangelog.com/en/1.1.0/) · Versioning: [SemVer](https://semver.org/).

## [Unreleased]

### Added

- **Five Gforth manual topic rules** — `forth-numeric.mdc`, `forth-wordlists.mdc`, `forth-debugging.mdc`, `forth-oof.mdc`, `forth-c-bindings.mdc`.
- **Gforth Tutorial distillation** (`sources/gforth-manual-tutorial/` → `rules/`):
  - **`forth-memory.mdc`** — `variable`, `create`, `allot`, `here`, `aligned`, `allocate`.
  - **`forth-io.mdc`** — `open-file`, `read-line`, `write-line`, ior/`throw`, `Value fd`.
  - **`forth-meta.mdc`** — interpret vs compile state, `immediate`, `postpone`, `[`/`]`.
  - **`forth-strings.mdc`** — `( c-addr u )`, `s"`, `c"`, counted strings, `c,`/`c@`.
  - **`forth-floating-point.mdc`** — separate FP stack, `1e` literals, `f~abs`/`f~rel`.
- **`sources/gforth-manual-tutorial/`** — Gforth manual ch.3 Tutorial (§3.1–§3.37) as per-section Markdown; `extract.sh` for refresh from [gforth.org/manual/Tutorial.html](https://gforth.org/manual/Tutorial.html).
- **`sources/gforth-manual/`** — full Gforth manual ([gforth.org/manual/](https://gforth.org/manual/)); ~304 HTML nodes → Markdown (`index.md`, `pages.list`, `extract.sh`; honours `http(s)_proxy`; `upstream/` gitignored).
- **`tests/challenges/`** — 139 bank (`001`–`139`) + 6 seeds = **145** hold-out; `eval-slices.yaml`, [`docs/BENCHMARK-SIZING.md`](docs/BENCHMARK-SIZING.md).
- **14 training-oriented tasks** (126–139): linked, parse, graph topo, DP knapsack/edit, LRU, Collatz, etc.
- **`scripts/_build_catalog.py`**, **`scripts/challenge_catalog.py`**, **`scripts/challenge_scaffolds.py`**, **`scripts/gen_challenges.py`**, **`scripts/check_manifest_dedup.py`**, **`scripts/verify_challenges.sh`** — generate and smoke-test the bank.

### Changed

- **Gforth manual — full distillation** (`sources/gforth-manual/` → `rules/`) — five new topics plus expanded stack/control/defining/meta/memory/io/strings/portability/dialect; covers ch.2–§9 actionable idioms (errors, exceptions, structs, assertions, numeric, wordlists, debugging, OOP/C basics); skip Word Index and engine/assembler internals; `install.sh` FULL_TOPICS, `frules-index.mdc` routing, `docs/SOURCES.md` provenance.
- **Gforth Tutorial distillation (updated rules)** — `forth-stack` (manipulation, designing stack effects), `forth-control` (exit/leave, recursion, flags), `forth-defining` (simple-field, defer/is), `forth-dialect-gforth` (locals, try/endtry; strings/FP moved to dedicated topics), `forth-style`, `forth-portability`, `forth-anti-patterns`, `forth-naming` (type prefixes).
- **`docs/SOURCES.md`** — per-file provenance from Gforth Tutorial §3.x and Gforth manual ch.5–9; skip lists documented.
- **`TODO.md`** — full manual vendored, distilled, and documented; open: index theForthNet packages.

## [0.1.2] — 2026-05-27

### Added

- **`docs/MODEL-TRAINING.md`** — пошаговые инструкции: датасет JSONL, Трек A (Qwen2.5-Coder-0.5B песочница), Трек B (7B LoRA → Ollama), Ubuntu 24 / WSL2, hold-out для `tests/challenges/`.
- **`docs/TRAINING-RUNS.md`** — журнал прогонов обучения (как `CHALLENGE-RUNS.md` для inference).
- **`scripts/build-dataset.py`** — сборка ShareGPT JSONL из `tests/ans`, `tests/gforth`, `examples/`; флаги `--sandbox`, `--validate`.
- **`data/sandbox.jsonl`** (33 пары), **`data/train.jsonl`** (41 пара), **`data/README.md`**.
- **`training/`** — `configs/sandbox.yaml`, `configs/prod-7b.yaml`, `requirements-train.txt`, `Modelfile.example`, `run-sandbox.sh`.

### Changed

- **`README.md`** — ссылки на MODEL-TRAINING, TRAINING-RUNS, `data/`, `scripts/`, `training/`.
- **`docs/CHALLENGE-RUNS.md`** — ссылка на обучение своей LoRA.
- **`TODO.md`** — отмечены инструкции по train; открыт пункт расширения датасета до 500+.
- **`.gitignore`** — `output/`, `.venv-train/`, промежуточные JSONL.

### Fixed

- **`tests/challenges/01-clamp.fs`**, **`04-caesar-shift.fs`** — удалены черновые решения между маркерами (честный eval / hold-out).

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

[0.1.2]: https://github.com/VitaSound/frules/releases/tag/v0.1.2
[0.1.1]: https://github.com/VitaSound/frules/releases/tag/v0.1.1
[0.1.0]: https://github.com/VitaSound/frules/releases/tag/v0.1.0

# Changelog

All notable changes to `frules` are recorded here.

Format: [Keep a Changelog](https://keepachangelog.com/en/1.1.0/) · Versioning: [SemVer](https://semver.org/).

## [Unreleased]

Work since **0.1.2** (mostly **2026-05-28 … 2026-05-31**): ~85 commits, one author — challenge bank + **98 verified train solutions**, source distillation, Track A ML pipeline (closed), and AI-platform knowledge base. See [`docs/AI-KNOWLEDGE-INDEX.md`](docs/AI-KNOWLEDGE-INDEX.md).

### Added

#### Challenge bank and train gold (eval culture)

- **`tests/challenges/`** — **151** total (**6** seeds + **145** bank `001`–`145`); split in [`eval-slices.yaml`](tests/challenges/eval-slices.yaml): **`train_for_sft` 98** + **`eval_holdout` 53** (blind eval only).
- **`data/challenge-solutions/`** — **98/98** train solutions (`SOLVE-QUEUE.md` complete); ~6500 lines verified Forth; each `TESTS OK` via gforth before queue mark.
- **6 Rosetta distill challenges** — `140`–`145` (holder, dict-list, find-idx, sq-brackets, expect-match, arr-sum); map [`ROSETTA-DISTILL-15.md`](tests/challenges/ROSETTA-DISTILL-15.md).
- **`data/challenge-solutions/_tester.fs`** — wrapper to run gold solutions with ttester.
- **Agent solve workflow** — [`docs/AGENT-SOLVE-CHALLENGES.md`](docs/AGENT-SOLVE-CHALLENGES.md), progress tracking in `SOLVE-QUEUE.md` (28 → 77 → 98).
- **Rosetta Code** — `sources/rosettacode-forth/` (569 tasks), `INDEX.md`, `challenge-links.yaml`, `taxonomy-keywords.yaml`, `scripts/rosettacode-hint.py`; **15/15** distill candidates → `rules/`.
- **theForthNet packages** — vendored `sources/theforth.net-packages/`, [`INDEX.md`](sources/theforth.net-packages/INDEX.md), selective distill → `rules/`.

#### FORTH architecture and research docs

- **`docs/FORTH-SYSTEM-ARCHITECTURE.md`** (+ EN), **`FORTH-HARDWARE-CODESIGN`**, **`FORTH-FMAP-GUIDE`**, **`FORTH-DIALECT-LAYERS`**, **`FORTH-ANS-PORTABILITY-LAYER`**, **`FORTH-THREADING`**, **`FORTH-FEATURE-COMPLEXITY`**, **`FORTH-STACK-CPU-RESEARCH`** (RU + EN).
- **`data/forth-fmap-profiles.json`**, **`forth-threading-models.json`**, **`forth-use-case-templates.json`**.

#### Track A 0.5B LoRA — pipeline fixed, experiment **closed**

- **Short SYSTEM for SFT** — `scripts/sft_prompts.py` (`TRAIN_SYSTEM_SHORT` ~50 tok); `--system short|full` in `build-dataset.py`, `build-challenge-dataset.py`.
- **Token validation** — `scripts/validate-train-tokens.py`; `build-train-merged.sh` guards truncation.
- **Infer parity** — `training/infer-sandbox.py` `--system short`, `--from-jsonl`, `--word`.
- **One-shot final run** — `training/run-track-a-final.sh`, `scripts/track-a-smoke-infer.sh`.
- **Docs** — [`docs/TRACK-A-FINAL.md`](docs/TRACK-A-FINAL.md), [`docs/TRACK-A-LESSONS.md`](docs/TRACK-A-LESSONS.md) (0.5B **not a mistake** — pipeline bugs found, honest negative result on logic), [`docs/ML-GLOSSARY-FORTH.md`](docs/ML-GLOSSARY-FORTH.md).
- **Conclusion:** LoRA 0.5B gives Forth-shaped output but fails algorithms; path forward = **rules + IR transpiler + gforth judge**, not more 0.5B postfix training.

#### AI platform knowledge base (May 31)

- **Hub** — [`docs/AI-KNOWLEDGE-INDEX.md`](docs/AI-KNOWLEDGE-INDEX.md): how to build AI-containing automation for Forth systems.
- [`docs/AI-VS-TOOLS.md`](docs/AI-VS-TOOLS.md) — LLM vs static tools (transpiler, stack-glue, fhdlgen).
- [`docs/EXTERNAL-LLM-ARCHITECTURE.md`](docs/EXTERNAL-LLM-ARCHITECTURE.md) — Opus/cloud LLM as **orchestrator** (Tier 0–3), MCP sketch, cost gate.
- [`docs/NOTATION-AND-TRANSPILER.md`](docs/NOTATION-AND-TRANSPILER.md) — why LLM is overkill for notation/postfix.
- [`docs/MULTI-AGENT-ARCHITECTURE.md`](docs/MULTI-AGENT-ARCHITECTURE.md) — explicit agents + thinking as internal dialogue.
- [`docs/ROADMAP-AI-PLATFORM.md`](docs/ROADMAP-AI-PLATFORM.md) — Lisp/WASM IR tests, RAG, Track B, infra, **XCKU5P** primary FPGA.
- [`docs/PROOFREAD-AI-GENERATED.md`](docs/PROOFREAD-AI-GENERATED.md) — selective human proofread checklist.

#### Track A 0.5B training pipeline (earlier Unreleased items)

- **Track A 0.5B training pipeline** — `training/train-sandbox.py`, `infer-sandbox.py`, `merge-sandbox.py`; wrappers `run-sandbox.sh`, `run-sandbox-merged.sh`, `run-sandbox-long.sh`, `run-sandbox-merge.sh`; configs `sandbox-long.yaml`, `sandbox-merged.yaml`.
- **SFT datasets** — `data/train-simple.jsonl`, `train-core-validated.jsonl`, `train-merged.jsonl`, `train-repeated.jsonl`; `scripts/build-train-merged.sh`, `scripts/repeat-jsonl.py`.
- **Ollama + frules rules** — [`docs/OLLAMA-FRULES.md`](docs/OLLAMA-FRULES.md), `scripts/build-ollama-system.sh`, `training/write-modelfile-with-rules.sh`, `training/Modelfile.example2` (short SYSTEM).
- **Training docs** — [`docs/TRAINING-NEXT-STEPS.md`](docs/TRAINING-NEXT-STEPS.md); expanded [`README.md`](README.md), [`training/README.md`](training/README.md).
- **Examples with `T{ }T`** — `examples/gforth/good.fs`, `examples/ans/portable.fs`.

#### Rules and sources (distillation)

- **Thinking Forth (Brodie)** — `sources/brodie-thinking-forth/` → `forth-factoring`, `forth-style`, `forth-anti-patterns`, `forth-naming`.
- **Five Gforth manual topic rules** — `forth-numeric.mdc`, `forth-wordlists.mdc`, `forth-debugging.mdc`, `forth-oof.mdc`, `forth-c-bindings.mdc`.
- **Gforth Tutorial distillation** — `forth-memory`, `forth-io`, `forth-meta`, `forth-strings`, `forth-floating-point`.
- **`sources/gforth-manual-tutorial/`**, **`sources/gforth-manual/`** (~304 nodes) — full manual distill into `rules/`.
- **Stack-debugging rules** — from solve-session fixes (`forth-control`, queue progress).
- **WebAssembly / WAForth** — §11.2 in `FORTH-SYSTEM-ARCHITECTURE` (RU+EN), FMAP profile `waforth`.
- **Challenge tooling** — `scripts/_build_catalog.py`, `challenge_catalog.py`, `challenge_scaffolds.py`, `gen_challenges.py`, `check_manifest_dedup.py`, `verify_challenges.sh`.

### Changed

- **[`docs/BENCHMARK-SIZING.md`](docs/BENCHMARK-SIZING.md)** — **151 / 98 train / 53 hold-out** (was wrongly «145 hold-out only»).
- **[`docs/CHALLENGE-TO-TRAIN.md`](docs/CHALLENGE-TO-TRAIN.md)**, **[`MODEL-TRAINING.md`](docs/MODEL-TRAINING.md)**, **README** — aligned counts with `eval-slices.yaml`.
- **[`docs/TRAINING-RUNS.md`](docs/TRAINING-RUNS.md)** — Track A sandbox, merged, simple, long; final honest run (`train_loss` ~1.8, infer logic fail).
- **`TODO.md`** — train solve complete; Track A closed; AI knowledge base marked done; proofread open.
- **Gforth manual / Tutorial distillation** — expanded stack/control/defining/meta/memory/io/strings/portability/dialect; `install.sh` FULL_TOPICS, `frules-index.mdc`, `docs/SOURCES.md`.

### Fixed

- **Track A data pipeline** — full `system` (~4000 tok) + `MAX_SEQ=1024` truncated assistant from loss; old adapters invalid. Fixed with short system + validation.
- **`training/merge-sandbox.py`** — `NotImplementedError` on transformers 5.5: call `unsloth_generic_save` / `unsloth_save_pretrained_gguf` on **PeftModel** explicitly.
- **Train solutions (human-verified after AI draft)** — e.g. `072` word-ladder BFS stack/queue; `135` LRU warnings; `014`–`016` dual-buffer scaffolds; `020` seen-table segfault path.
- **Stale doc counts** — 94→**98** train, 145→**53** hold-out, 131→**151** total (see `PROOFREAD-AI-GENERATED.md`).
- **`tests/lint.sh`** — English-only grep for `rules/*.mdc` (in `./test.sh`).

### Human work summary (from git history, not LOC)

| Phase | Calendar | What happened |
|-------|----------|----------------|
| Bootstrap | May 25–27 | v0.1.0 rules, ttester, MODEL-TRAINING, challenge seeds, Gemma benchmark docs |
| Sources + early solve | May 28 | Gforth manual vendored/distilled; solve queue started (gcd…); blocked string tasks after segfault |
| **Solve sprint** | **May 29** | **~60 commits** — solutions 034–145 tier, FORTH arch docs, queue **98/98** closed |
| Hardening | May 30–31 | Rosetta/theForthNet; word-ladder fix; Track A final + AI platform docs; proofread P0 |

**Note:** Most `.fs` solutions and distill text are AI-assisted; **human role** = architecture, gforth verification, queue discipline, pipeline debugging, and honest Track A closure. Public write-up: [FMix on DEV](https://dev.to/ua3mqj/fmix-a-package-manager-for-forth-37ld) (sibling repo; same author/session era).

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

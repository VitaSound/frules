# Roadmap

Status legend: `[ ]` open · `[~]` in progress · `[x]` done

## Near term (next 1–2 sessions)

- [x] **`train_for_sft` solve queue** — **98/98** в [`data/challenge-solutions/SOLVE-QUEUE.md`](data/challenge-solutions/SOLVE-QUEUE.md); дальше `build-challenge-dataset.py`, **валидация моделей** на `eval_holdout` (не train).
- [x] **`tests/challenges/`** — 6 seeds + 145 bank = **151** total; `manifest.yaml`, `INDEX.md`, `taxonomy-coverage.md`; генераторы `scripts/_build_catalog.py`, `gen_challenges.py`, `verify_challenges.sh`. Hold-out slice **53** — без решений между маркерами.
    - [x] Seed: `01`–`06` + `_tester.fs`. Bank: LeetCode Top 100 + Codewars/kata/PE/Rosetta, unique `pattern_key`, cognitive 0–10.
    - [x] Добить набор seed `07`–`10` — **заменено банком `001`–`139`** (parse/anagram/RLE/binary-search в банке; taxonomy OK). Defining words / FP / double — см. «Среднесрочно» ниже.
    - [~] Бенчмарковый прогон: `docs/CHALLENGE-RUNS.md` (Cursor) + `docs/LOCAL-GEMMA-BENCHMARK.md` (Gemma 4 / Ollama, rules on/off). Первая строка в CHALLENGE-RUNS — Composer 2.5 / Agent на `01-clamp`.
- [x] **Дистилляция источников в `rules/`.** Vendored-текст в `sources/` → `docs/DISTILL-PROMPT.md` → обновить `rules/*.mdc` и `docs/SOURCES.md` (как для Brodie).
    - [x] Thinking Forth: исходники в `sources/brodie-thinking-forth/chapter*.md` + `appendix*.md` + `epilog.md` (`extract.sh`). Картинки в `figures/` — только для человека.
    - [x] Прогнать `docs/DISTILL-PROMPT.md` по главам Brodie; обновить `rules/*.mdc` (`forth-factoring`, `forth-style`, `forth-anti-patterns`, `forth-naming`; `docs/SOURCES.md` отмечает источник).
    - [x] Gforth manual Tutorial vendored: `sources/gforth-manual-tutorial/` (§3.1–§3.37, `extract.sh`).
    - [x] Gforth manual (полный) vendored: `sources/gforth-manual/` (~304 HTML-узла, `extract.sh`, `http(s)_proxy`).
    - [x] **Ссылки на полный мануал** — `gforth-manual/` в AGENT-SOLVE, CHALLENGE-RUNS (deny), SOURCES, README, rules/templates, training docs.
    - [x] **Дистилляция Gforth Tutorial** — прогнать `docs/DISTILL-PROMPT.md` по разделам `gforth-manual-tutorial/*.md`; дополнить `rules/*.mdc` (`forth-memory`, `forth-io`, `forth-meta`, `forth-strings`, `forth-floating-point` + updates); обновить `docs/SOURCES.md`.
    - [x] **Дистилляция Gforth manual (полный)** — все темы ch.2–§9, §7 → `rules/*.mdc` (+5 новых: numeric, wordlists, debugging, oof, c-bindings); skip: словарь Word Index, assembler per-CPU, engine ch.14, cross ch.15, Emacs ch.12.
    - [x] theForthNet packages vendored: `sources/theforth.net-packages/` (`.4th` / `.fs`).
    - [x] **Индексация theForthNet packages** — [`sources/theforth.net-packages/INDEX.md`](sources/theforth.net-packages/INDEX.md): каталог по пакетам и темам frules, distill candidates, challenge hints.
    - [x] **Выборочная дистилляция theForthNet** — high/medium из INDEX → `rules/{defining,memory,wordlists,meta,stack,strings,numeric}.mdc` + `docs/SOURCES.md`.
    - [x] **Rosetta Code vendored** — `sources/rosettacode-forth/` (569 задач, `fetch.sh`).
    - [x] **Индексация Rosetta** — [`INDEX.md`](sources/rosettacode-forth/INDEX.md) (taxonomy, frules topics, challenge cross-ref), [`challenge-links.yaml`](sources/rosettacode-forth/challenge-links.yaml), [`taxonomy-keywords.yaml`](sources/rosettacode-forth/taxonomy-keywords.yaml), `scripts/rosettacode-hint.py`; подключено в `AGENTS.md`, `frules-index.mdc`, `AGENT-SOLVE`, `CHALLENGE-TO-TRAIN`, `CHALLENGE-RUNS`, `SOURCES.md`.
    - [ ] **Расширить challenge-links** — добавлять пары bank↔Rosetta по мере ревью gold solutions (сейчас 36 curated).
    - [x] **Выборочная дистилляция Rosetta** — **15/15** distill candidates → `rules/` (verbatim ok + `gforth/` fixes); smoke `bash sources/rosettacode-forth/gforth/smoke-all.sh`.
    - [x] **Челленджи из Rosetta (15 distill)** — 9 уже были в bank; добавлены `140`–`145` (6 новых). Карта: [`ROSETTA-DISTILL-15.md`](tests/challenges/ROSETTA-DISTILL-15.md). Решения: `data/challenge-solutions/140`–`145`.
- [x] **Track A 0.5B LoRA** — pipeline OK; short system fix; финальный прогон `sandbox-adapter-fixed-merged`: Forth-форма, логика fail → **Track A закрыт**. См. [`docs/TRACK-A-FINAL.md`](docs/TRACK-A-FINAL.md), [`docs/ML-GLOSSARY-FORTH.md`](docs/ML-GLOSSARY-FORTH.md).
- [ ] **Track B — большая модель (7B+).** `Qwen2.5-Coder-7B-Instruct` + `training/configs/prod-7b.yaml`; short system jsonl; curriculum (микро-примеры `1 2 +` …); eval на `eval_holdout`. См. [`docs/MODEL-TRAINING.md`](docs/MODEL-TRAINING.md), [`docs/TRAINING-NEXT-STEPS.md`](docs/TRAINING-NEXT-STEPS.md).
- [ ] **IR-пайплайн (LLM → transpiler → Forth).** Opus / 7B локально генерирует IR; backend детерминированный. Опробовать варианты:
    - [ ] **Lisp / S-expr** — `(+ a (* b c))` → post-order → Gforth; прототип `scripts/lisp-to-forth.py` (или аналог).
    - [ ] **JSON AST** — жёсткая схема `{ "op": "+", "args": [...] }`; парсер + codegen; промпт «only JSON».
    - [ ] **Python → `ast`** — LLM пишет subset Python; `ast.parse` → обход → Forth (надёжнее, чем AST «из головы» LLM).
    - [ ] **WASM text (.wat)** — стековая IR; таблица замены `i32.add` → `+`, `local.get` → `@`.
    - [ ] **Stack glue / scheduler** — склеить последовательность IR-операций **без `variable`/`value`**: симуляция стека + подбор `dup`/`swap`/`rot`/`over`/`nip`/`>r` между словами с известным `( before -- after )`; минимизировать глубину и число manipulations; отдельно ветки `if` (одинаковый depth). Прототип: `scripts/stack-glue.py` или слой в transpiler. См. frules `forth-anti-patterns` (rot rot) — для **генератора** допустимо, для ручного кода — factoring.
    - [ ] Сравнить: качество / галлюцинации / gforth `TESTS OK` на 3–5 задачах из `tests/ans/` (gcd, factorial, fizzbuzz).
    - [ ] Зафиксировать вывод в `docs/` (какой IR выбрать для аппаратной платформы).
    - [x] **ИИ vs статика:** [`docs/AI-VS-TOOLS.md`](docs/AI-VS-TOOLS.md) — таблица задач продукта, pipeline v1.
    - [x] **Opus / облачный LLM как оркестратор:** [`docs/EXTERNAL-LLM-ARCHITECTURE.md`](docs/EXTERNAL-LLM-ARCHITECTURE.md) — tier model, toolchain, MCP sketch, cost gate.
- [x] **База знаний ИИ-платформы (2026-05-31).** Рефлексия сессии → MD:
    - [x] Hub: [`docs/AI-KNOWLEDGE-INDEX.md`](docs/AI-KNOWLEDGE-INDEX.md)
    - [x] Track A: 0.5B не ошибка — [`docs/TRACK-A-LESSONS.md`](docs/TRACK-A-LESSONS.md)
    - [x] LLM ≠ transpiler нотации — [`docs/NOTATION-AND-TRANSPILER.md`](docs/NOTATION-AND-TRANSPILER.md)
    - [x] Multi-agent + внутренний диалог — [`docs/MULTI-AGENT-ARCHITECTURE.md`](docs/MULTI-AGENT-ARCHITECTURE.md)
    - [x] Roadmap: Lisp/WASM, RAG, train, infra, KU5P — [`docs/ROADMAP-AI-PLATFORM.md`](docs/ROADMAP-AI-PLATFORM.md)
- [ ] **Вычитка AI-generated** — [`docs/PROOFREAD-AI-GENERATED.md`](docs/PROOFREAD-AI-GENERATED.md); P0 цифры частично поправлены 2026-05-31.
- [ ] **Pre-commit hook** (`.git/hooks/pre-commit` или husky): запускать `./test.sh`, блокировать коммит при FAIL.
- [ ] **CI.** GitHub Actions: установка `gforth` + `pforth` через apt, запуск `./test.sh` на каждый PR/push.
- [x] **Lint English-only.** `tests/lint.sh` — grep `[А-Яа-яЁё]` в `rules/*.mdc` и `templates/*.mdc`; вызывается из `./test.sh`.

## Среднесрочно (правила и покрытие)

**Пробелы после train `001`–`139`:** банк челленджей **намеренно** integer/scalar-heavy; почти нет `does>`, FP и double (см. Style guard «No floating point»). В `rules/*.mdc` добавлены идиомы из gold solutions (naming/create+`-`, `ch!`, stubs/redefined, `variable`-handle); **покрытие тем** — отдельными задачами ниже, не доработкой train-банка.

- [ ] **Defining words (`does>`)** — `tests/ans/` или eval-challenge на `create … does>` (compile-time vs run-time); сейчас `forth-defining.mdc` почти не иллюстрируется челленджами.
- [ ] **FP стек (Gforth)** — отдельный `tests/` или challenge с `f+` / `fdup` / `f~`; train-банк FP не требует → `forth-floating-point.mdc` без практики в бенчмарке.
- [ ] **Double (`d+`, `m*/`, …)** — отдельный `tests/` или challenge; проверить двухячейечный стек без утечек; train-банк double избегает.
- [ ] **Тесты на ошибки compile state** — антипаттерн «забыли `]` после `[`», ловить `compile-only` слова на интерпретаторе.
- [ ] **Examples cross-reference.** Под каждое правило `rules/forth-X.mdc` иметь хотя бы один пример в `examples/` или `tests/`, который его реально иллюстрирует.

## Долгосрочно (расширение системы)

- [ ] **Per-target dialect config.** `install.sh` смотрит `<target>/.frules.conf` (в дополнение к глобальному `frules.conf` источника). Удобно для нескольких проектов с разными диалектами.
- [ ] **Третий диалект.** SwiftForth / Mecrisp / VFX. Шаги в `docs/DIALECT-TEST.md`, добавить `examples/<name>/` и `tests/<name>/`.
- [ ] **Профиль `dialect-only`.** `install.sh . gforth dialect-only` — только маркер + dialect-файл, без общих правил (для случая, когда у проекта уже свои общие правила).
- [ ] **Профиль `strict`.** Включает дополнительный `rules/forth-strict.mdc` с жёсткими запретами (нет `value`, нет `pick`, нет `>r r>` в публичных словах).
- [ ] **MCP server / Cursor skill** для `frules` — `/frules install`, `/frules check` прямо из чата.
- [ ] **Книжная база.** Когда `sources/` наполнится — добавить `docs/BOOK-INDEX.md` с разделами «откуда какая идиома пришла».

## Качество и гигиена

- [ ] **Семантика версионирования.** Пока v0.1.x — пока меняются формулировки правил. v0.2.0 после первой реальной обкатки чужой моделью. v1.0.0 — когда покрытие книг закроет основные темы.
- [ ] **CONTRIBUTING.md.** Чек-лист «как добавлять правило» (заголовок, длина, пример, тест, обновление `docs/SOURCES.md`).
- [ ] **Стандартизация формата stack-effect комментариев** — короткое решение (`( before -- after )`) и зафиксировать в `forth-stack.mdc` как единственно допустимый.
- [ ] **English-only audit.** Один раз пройти все `rules/*.mdc` свежей моделью с запросом «найти non-English тексты, fix-описание».
- [ ] **Сравнение с реальными codebases.** Прогнать правила против известных Forth-проектов (Gforth own, Mecrisp tools), посмотреть, что модель делает не так, что хорошо.

## Идеи без приоритета

- [x] Свой `T{ … -> … }T` совместимый с Hayes test suite (вместо текущего `t=`), чтобы интегрироваться с готовыми наборами. Подключён `ttester.4th` + `ttester-ext.4th` из `VitaSound/ttester`, все 10 тестов переведены.
- [ ] Конвертер: `.mdc` → одиночный markdown для системных промптов другим IDE (не-Cursor).
- [ ] Бенчмарки модели на `tests/challenges/`: процент зелёных под разными моделями (Composer, Sonnet, Opus, GPT) — публиковать таблицу.
- [x] **Инструкции по обучению модели:** `docs/MODEL-TRAINING.md`, `docs/TRAINING-RUNS.md`, `scripts/build-dataset.py`, `data/sandbox.jsonl`, `training/configs/`.
- [x] **Track A final + глоссарий ML:** `docs/TRACK-A-FINAL.md`, `docs/ML-GLOSSARY-FORTH.md`, `scripts/validate-train-tokens.py`, `training/run-track-a-final.sh`.
- [ ] Расширить `data/train.jsonl` до 500+ (curriculum + внешний Gforth); **Track B 7B** — см. MODEL-TRAINING.md и пункт «Track B» выше.

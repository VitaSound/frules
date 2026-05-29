# Roadmap

Status legend: `[ ]` open · `[~]` in progress · `[x]` done

## Near term (next 1–2 sessions)

- [x] **`train_for_sft` solve queue** — 94/94 в [`data/challenge-solutions/SOLVE-QUEUE.md`](data/challenge-solutions/SOLVE-QUEUE.md); дальше `build-challenge-dataset.py`, **валидация моделей** на `eval_holdout` (не train).
- [x] **`tests/challenges/`** — 6 seeds + 125 bank (`001`–`125`), 131 total; `manifest.yaml`, `INDEX.md`, `taxonomy-coverage.md`; генераторы `scripts/_build_catalog.py`, `gen_challenges.py`, `verify_challenges.sh`. Hold-out, без решений между маркерами.
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
- [ ] Расширить `data/train.jsonl` до 500+ (внешний Gforth + синтетика); Track A/B на GPU — см. MODEL-TRAINING.md.

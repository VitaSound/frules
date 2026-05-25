# Roadmap

Status legend: `[ ]` open · `[~]` in progress · `[x]` done

## Near term (next 1–2 sessions)

- [ ] **`tests/challenges/`** — задачи без решений (только условие + ассерты + ожидаемый стек). Скармливать свежему чату Cursor, смотреть, что модель напишет «вслепую». Это единственный честный сигнал «правила работают».
- [ ] **Дистилляция первой книги.** Положить в `sources/` (например, *Thinking Forth* / *Starting Forth* / конспект), прогнать `docs/DISTILL-PROMPT.md`, обновить `rules/*.mdc` и `docs/SOURCES.md`.
- [ ] **Pre-commit hook** (`.git/hooks/pre-commit` или husky): запускать `./test.sh`, блокировать коммит при FAIL.
- [ ] **CI.** GitHub Actions: установка `gforth` + `pforth` через apt, запуск `./test.sh` на каждый PR/push.
- [ ] **Lint English-only.** Скрипт в `tests/lint.sh`: грепает `[А-Яа-яЁё]` в `rules/*.mdc` и `templates/*.mdc`, фейлит при попадании.

## Среднесрочно (правила и покрытие)

- [ ] **Покрытие defining words** — отдельный тест на `: word create … does> …` с проверкой compile-time vs run-time контракта.
- [ ] **Тесты на ошибки compile state** — антипаттерн «забыли `]` после `[`», ловить `compile-only` слова на интерпретаторе.
- [ ] **Тесты на FP стек** — Gforth-only, `f+ fdup` и т.п., чтобы прибить раздел "Floating point" в `forth-dialect-gforth.mdc`.
- [ ] **Тесты на double** — `d+ d* m*/`, проверить, что нет утечек одной ячейки.
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

- [ ] Свой `T{ … -> … }T` совместимый с Hayes test suite (вместо текущего `t=`), чтобы интегрироваться с готовыми наборами.
- [ ] Конвертер: `.mdc` → одиночный markdown для системных промптов другим IDE (не-Cursor).
- [ ] Бенчмарки модели на `tests/challenges/`: процент зелёных под разными моделями (Composer, Sonnet, Opus, GPT) — публиковать таблицу.

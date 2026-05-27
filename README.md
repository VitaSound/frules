# frules — правила Forth для ИИ

Набор сжатых, структурированных правил для Cursor (и других ассистентов), чтобы код на Forth был идиоматичнее и с меньшим числом типичных ошибок.

## Подключение к проекту

**Cursor** — скопируйте или ссылайтесь на каталог `rules/`:

```bash
# из корня вашего Forth-проекта
./path/to/frules/install.sh .              # диалект из frules.conf (по умолчанию gforth)
./path/to/frules/install.sh . gforth       # явно Gforth
./path/to/frules/install.sh . ans         # только переносимый ANS
./path/to/frules/install.sh . gforth core # меньше файлов = меньше контекста
```

В `.cursor/rules/` попадают общие `forth-*.mdc`, маркер `frules-dialect.mdc` (`alwaysApply: true`) и при `gforth` — `forth-dialect-gforth.mdc`.

**Выбор диалекта в этом репозитории:** отредактируйте `frules.conf`:

```ini
dialect=gforth
```

Файлы `.mdc` с `globs: **/*.{fth,fs,4th,forth}` подхватываются при работе с исходниками Forth.

**Другие инструменты** — подключайте содержимое `rules/*.mdc` (без YAML frontmatter) или `AGENTS.md` как system prompt / project instructions.

## Темы и подгрузка правил

Как Cursor собирает контекст из нескольких файлов, почему «ссылка на другой .mdc» сама ничего не подгружает, и как сузить правила по темам — **`docs/RULES-ARCHITECTURE.md`** (English).

Кратко: при открытии `.fs` подтягиваются все `.mdc` с тем же `globs`; `frules-index.mdc` подсказывает модели, **какой** файл главный для задачи. Тела правил для ИИ — **только на английском**.

## Структура

| Путь | Назначение |
|------|------------|
| `rules/` | Модули для ИИ (`.mdc`, English) |
| `rules/frules-index.mdc` | Приоритеты при конфликте правил |
| `examples/` | Эталоны `good.fs` / `bad.fs` для модели |
| `sources/` | Исходники: книги, главы, выписки (PDF, txt, md) |
| `docs/SOURCES.md` | Откуда взята каждая тема в `rules/` |
| `docs/RULES-ARCHITECTURE.md` | Как работает подгрузка с ИИ |
| `docs/DISTILL-PROMPT.md` | Промпт для перегонки книги в правила |
| `data/` | JSONL для SFT (`sandbox.jsonl`, `train.jsonl`) |
| `data/challenge-solutions/SOLVE-QUEUE.md` | Чеклист ~94 train-челленджей (`- [ ]` / `- [x]`) для агента |
| `scripts/build-dataset.py` | Сборка датасета из tests/examples |
| `training/` | Конфиги LoRA, Modelfile |
| `AGENTS.md` | Краткая сводка для любого агента |

## Как добавлять книги

1. Положите текст в `sources/` (имя: `автор-название.ext`, например `brodie-thinking-forth.txt`).
2. Попросите ассистента: «извлеки из `sources/...` правила в `rules/`, без воды».
3. Обновите `docs/SOURCES.md`.

Предпочтительный формат исходника: **plain text / markdown** (из PDF — OCR или экспорт). ИИ плохо «читает» сканы без текста.

## Уже заложенные источники (без ваших файлов)

Стартовый набор собран из публичных канонов:

- [Starting Forth](https://www.forth.com/starting-forth/) — стек, постфикс, нотация `( … -- … )`
- [Forth coding rules](https://www.forth.org/forth_coding.txt) (Paul E. Bennett)
- [DPANS94](http://lars.nocrew.org/dpans/dpanse.htm) — переносимость, ячейки, стеки
- Общепринятые идиомы сообщества (факторизация, осторожность с `PICK`/`ROLL`)

В каталоге [`sources/`](sources/) уже vendored: *Thinking Forth* (`brodie-thinking-forth/`), [Gforth manual](https://gforth.org/manual/) (`gforth-manual/`), [Gforth Tutorial](https://gforth.org/manual/Tutorial.html) (глава 3 в `gforth-manual-tutorial/`), [theForthNet packages](sources/theforth.net-packages/) — см. [`sources/README.md`](sources/README.md).

После добавления других книг (Forth Application Techniques, …) правила в `rules/` следует дополнять и при необходимости сужать под ваш диалект (Gforth, SwiftForth, …).

## Диалект

| `dialect=` | Что ставит `install.sh` |
|------------|-------------------------|
| `gforth` (по умолчанию в `frules.conf`) | ANS-идиомы + `forth-dialect-gforth.mdc` + маркер «пишем для Gforth» |
| `ans` | только общие правила, без Gforth-специфики |

Переключение проверяется автоматически — см. `docs/DIALECT-TEST.md`. На моей машине `test.sh` гоняет `examples/gforth/*.fs` через `gforth` и `examples/ans/*.fs` через **gforth + pforth** (`apt install pforth`), что подтверждает портабельность ANS-примеров.

Другие системы (SwiftForth, Mecrisp, …) — позже отдельный `forth-dialect-*.mdc` и значение в `frules.conf` (шаги в `docs/DIALECT-TEST.md`).

## Проверка: работают ли правила?

Челленджи без эталонных решений — честный замер для **свежей** модели:

| Документ | Содержание |
|----------|------------|
| [`docs/CHALLENGE-RUNS.md`](docs/CHALLENGE-RUNS.md) | Cursor / Composer / Agent: новый чат, промпт, `gforth`, таблица результатов |
| [`docs/LOCAL-GEMMA-BENCHMARK.md`](docs/LOCAL-GEMMA-BENCHMARK.md) | **Gemma 4 через Ollama**: включить/выключить правила, A/B baseline |
| [`docs/MODEL-TRAINING.md`](docs/MODEL-TRAINING.md) | **Своя LoRA для Forth**: датасет, песочница 0.5B, train 7B, Ollama |
| [`docs/TRAINING-RUNS.md`](docs/TRAINING-RUNS.md) | Журнал прогонов обучения |
| [`tests/challenges/`](tests/challenges/) | 145 hold-out (6 seeds + 139 bank), `eval-slices.yaml`, [`docs/BENCHMARK-SIZING.md`](docs/BENCHMARK-SIZING.md) |

```bash
./install.sh . gforth          # правила ВКЛ  → .cursor/rules/
cd tests/challenges && gforth 01-clamp.fs   # или 052-two-sum.fs — без решения → Undefined word (норма)
```

Отключить правила для baseline: см. раздел «Отключить frules» в `docs/LOCAL-GEMMA-BENCHMARK.md`.

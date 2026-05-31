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
| `rules/forth-system-context.mdc` | Маршрутизация: архитектура vs код/challenges |
| `examples/` | Эталоны `good.fs` / `bad.fs` для модели |
| `sources/` | Исходники: книги, главы, выписки (PDF, txt, md) |
| `docs/SOURCES.md` | Откуда взята каждая тема в `rules/` |
| `docs/DOC-AUTHORSHIP.md` | Оговорки: AI-assisted FORTH-docs · [eng](docs/DOC-AUTHORSHIP-eng.md) |
| `docs/FORTH-*-eng.md` | English copies of FORTH architecture docs (paired with Russian `FORTH-*.md`) |
| `docs/FORTH-ANS-PORTABILITY-LAYER.md` | ANS as portable algorithm layer (RU) · [eng](docs/FORTH-ANS-PORTABILITY-LAYER-eng.md) |
| `docs/FORTH-DIALECT-LAYERS.md` | Domain dialects FORTH-X, layer 0 (RU) · [eng](docs/FORTH-DIALECT-LAYERS-eng.md) |
| `docs/FORTH-HARDWARE-CODESIGN.md` | Co-design hardware + Forth (RU) · [eng](docs/FORTH-HARDWARE-CODESIGN-eng.md) |
| `docs/FORTH-FMAP-GUIDE.md` | Using FMAP to choose Forth (RU) · [eng](docs/FORTH-FMAP-GUIDE-eng.md) |
| `docs/FORTH-SYSTEM-ARCHITECTURE.md` | Forth system architecture, FMAP (RU) · [eng](docs/FORTH-SYSTEM-ARCHITECTURE-eng.md) |
| `docs/FORTH-THREADING.md` | Threaded code ITC/DTC/STC (RU) · [eng](docs/FORTH-THREADING-eng.md) |
| `docs/FORTH-FEATURE-COMPLEXITY.md` | Feature implementation cost (RU) · [eng](docs/FORTH-FEATURE-COMPLEXITY-eng.md) |
| `data/forth-fmap-profiles.json` | Машиночитаемые профили систем (для SFT / retrieval) |
| `data/forth-threading-models.json` | Модели threading (EX-C), связь с профилями |
| `data/forth-use-case-templates.json` | Шаблоны use case → FMAP (embedded, ECU, hosted, …) |
| `docs/RULES-ARCHITECTURE.md` | Как работает подгрузка с ИИ |
| `docs/DISTILL-PROMPT.md` | Промпт для перегонки книги в правила |
| `data/` | JSONL для SFT (`sandbox.jsonl`, `train.jsonl`) |
| `data/challenge-solutions/SOLVE-QUEUE.md` | Train solve **завершён** (98/98); дальше SFT + валидация на `eval_holdout` |
| `scripts/build-dataset.py` | Сборка JSONL из `tests/ans`, `examples/` |
| `scripts/build-challenge-dataset.py` | JSONL из `data/challenge-solutions/` (только `train_for_sft`) |
| `training/` | Track A/B: train, infer, конфиги LoRA — см. **глоссарий ниже** |
| `AGENTS.md` | Краткая сводка для любого агента |
| `docs/AI-KNOWLEDGE-INDEX.md` | **База знаний:** ИИ + Forth automation, hub всех AI-доков |

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
| [`docs/OLLAMA-FRULES.md`](docs/OLLAMA-FRULES.md) | **Ollama + все rules `.mdc`**: Qwen 0.5B, full/core SYSTEM |
| [`docs/TRACK-A-FINAL.md`](docs/TRACK-A-FINAL.md) | финальный прогон Track A (short system) |
| [`docs/AI-KNOWLEDGE-INDEX.md`](docs/AI-KNOWLEDGE-INDEX.md) | **Hub:** база знаний ИИ-содержащих решений для Forth |
| [`docs/TRACK-A-LESSONS.md`](docs/TRACK-A-LESSONS.md) | 0.5B не ошибка; Track A закрыт; что получили |
| [`docs/NOTATION-AND-TRANSPILER.md`](docs/NOTATION-AND-TRANSPILER.md) | Почему LLM — не transpiler нотации (overkill) |
| [`docs/MULTI-AGENT-ARCHITECTURE.md`](docs/MULTI-AGENT-ARCHITECTURE.md) | Multi-agent, thinking = внутренний диалог |
| [`docs/ROADMAP-AI-PLATFORM.md`](docs/ROADMAP-AI-PLATFORM.md) | План: Lisp/WASM, RAG, train, infra, KU5P |
| [`docs/PROOFREAD-AI-GENERATED.md`](docs/PROOFREAD-AI-GENERATED.md) | **Вычитка AI-generated:** чеклист, приоритеты, типичные ошибки |
| [`docs/AI-VS-TOOLS.md`](docs/AI-VS-TOOLS.md) | **ИИ vs статика**: transpiler, stack-glue, gforth как судья |
| [`docs/EXTERNAL-LLM-ARCHITECTURE.md`](docs/EXTERNAL-LLM-ARCHITECTURE.md) | **Opus / облачный LLM + toolchain**: tier model, MCP, cost gate |
| [`docs/ML-GLOSSARY-FORTH.md`](docs/ML-GLOSSARY-FORTH.md) | **глоссарий ML**: pretrain, LoRA, reasoning, curriculum |
| [`docs/MODEL-TRAINING.md`](docs/MODEL-TRAINING.md) | **Своя LoRA для Forth**: датасет, песочница 0.5B, train 7B, Ollama |
| [`docs/TRAINING-RUNS.md`](docs/TRAINING-RUNS.md) | Журнал прогонов обучения |
| [`docs/TRAINING-NEXT-STEPS.md`](docs/TRAINING-NEXT-STEPS.md) | После train: infer, eval, long-run |
| [`training/README.md`](training/README.md) | Скрипты train/infer, `run-sandbox-long.sh` |
| [`tests/challenges/`](tests/challenges/) | **151** total (6 seeds + 145 bank); **53** hold-out (`eval_holdout`); `eval-slices.yaml`, [`docs/BENCHMARK-SIZING.md`](docs/BENCHMARK-SIZING.md) |

```bash
./install.sh . gforth          # правила ВКЛ  → .cursor/rules/
cd tests/challenges && gforth 01-clamp.fs   # или 052-two-sum.fs — без решения → Undefined word (норма)
```

Отключить правила для baseline: см. раздел «Отключить frules» в `docs/LOCAL-GEMMA-BENCHMARK.md`.

## Обучение локальной модели: термины

Краткий словарь того, что делает frules с ИИ **помимо** правил в Cursor. Подробные шаги — [`docs/MODEL-TRAINING.md`](docs/MODEL-TRAINING.md).

| Термин | Что это | Что делаем в frules |
|--------|---------|---------------------|
| **Правила / frules** | Текст в `rules/*.mdc` (~130 KB) | `./install.sh` → Cursor подставляет в контекст. Это **не обучение**, а «шпаргалка» при каждом запросе. |
| **RAG** | Retrieval-Augmented Generation: перед ответом в промпт подмешивают **найденные** куски базы (векторный индекс, поиск по `sources/`, или уже готовые `.mdc`). | В Cursor правила ≈ статический RAG. Отдельный векторный индекс по всему `sources/` (6+ MB) в репо **не обязателен** — тяжёлые справочники подтягивают выборочно. |
| **SFT** | Supervised Fine-Tuning: учим на парах «промпт → правильный ответ» (`*.jsonl`). | `sandbox.jsonl`, `train.jsonl`, `challenge-train.jsonl`. |
| **Train (обучение)** | GPU долго меняет **LoRA-веса** по JSONL. | Track A: `bash training/run-sandbox.sh` → `output/sandbox-adapter/`. Track B: 7B, когда `train.jsonl` ≥ 500 строк. |
| **Inference (инференс)** | GPU только **генерирует** текст, веса не меняет. | `python3 training/infer-sandbox.py` (с LoRA или `--no-adapter`). Судья Forth — всегда **gforth**, не модель. |
| **LoRA** | Маленький **адаптер** поверх одной базовой модели (~17 MB для 0.5B), не вторая полная модель. | После train лежит в `output/sandbox-adapter/`. **Нельзя** переставить на другую модель (Gemma 7B) — нужен **новый** train под ту базу. |
| **QLoRA** | LoRA + база в 4-bit в VRAM. | Track A/B на RTX 4070 (~8 GB в WSL). |
| **Merge (веса)** | Склеить LoRA + базу в **одни** полные веса (CPU/RAM, минуты). | [`training/merge-sandbox.py`](training/merge-sandbox.py) — см. раздел **«Merge LoRA»** ниже. Для infer в venv **не нужен** (`infer-sandbox.py` грузит adapter). Нужен для **GGUF / Ollama / LM Studio**. |
| **merged (датасет)** | Не путать с merge весов: `train-merged.jsonl` = ans + 98 challenge. | [`scripts/build-train-merged.sh`](scripts/build-train-merged.sh), [`training/run-sandbox-merged.sh`](training/run-sandbox-merged.sh) |
| **GGUF / Ollama** | Сжатый формат для локального чата. | После merge+export; LM Studio на Windows обычно ест GGUF, не папку adapter из WSL. |
| **Hold-out** | Данные/задачи, которые модель **не видела** при SFT — только для оценки. | **53** файла (`eval_holdout` в `eval-slices.yaml`): зоны paste **пустые**. |
| **Eval / бенчмарк** | Прогон модели на hold-out, `gforth` → TESTS OK. | [`docs/CHALLENGE-RUNS.md`](docs/CHALLENGE-RUNS.md), срез `eval_holdout` в `eval-slices.yaml`. |

**Train vs inference на GPU:** обучение жрёт VRAM дольше и тяжелее; чат (inference) на той же карте обычно легче, но большую модель в Ollama лучше не грузить **во время** train 7B.

## Почему ~33 строки sandbox, а челленджей 151?

Это **разные роли**, не «мы собрали банк и забыли в train».

```text
rules/*.mdc          →  RAG / Cursor (всегда в контексте, не JSONL)
tests/ans + examples →  sandbox.jsonl / train.jsonl  (малый SFT, с тестами gforth)
train_for_sft (98)   →  challenge-train.jsonl  (gold в data/challenge-solutions/)
eval_holdout (53)    →  tests/challenges/ пустые  (слепая оценка ПОСЛЕ обучения)
full (151)           →  6 seeds + 145 bank  (см. eval-slices.yaml)
```

| Набор | ~Размер | Зачем |
|-------|--------|--------|
| **`data/sandbox.jsonl`** | **33** строки (24 с `--validate`, только `TESTS OK`) | **Track A:** откатать цепочку dataset → QLoRA → adapter за минуты. Не про качество на всём банке. |
| **`data/train.jsonl`** | **~24–41** из `tests/ans` + `examples` | **Track B (ядро):** цель **≥ 500** строк (внешний Gforth, синтетика). |
| **`data/challenge-train.jsonl`** | **98** из `train_for_sft` | **Track B (челленджи):** эталонные решения большой модели; не смешивать с hold-out. |
| **`eval_holdout`** | **53** задачи | **Слепой экзамен** — stubs в `tests/challenges/` без gold. |

98 train + 53 hold-out = **151** total. Решения для обучения — в `data/challenge-solutions/`, не в paste зонах hold-out.

**Итого «мало данных» для train сейчас — намеренно:** песочница 33/24 — проверка пайплайна; полный объём для 7B — `train.jsonl` 500+ + `challenge-train.jsonl` 98; **53** hold-out — экзамен, не учебник.

Срезы и цифры: [`tests/challenges/eval-slices.yaml`](tests/challenges/eval-slices.yaml), [`docs/CHALLENGE-TO-TRAIN.md`](docs/CHALLENGE-TO-TRAIN.md), [`docs/BENCHMARK-SIZING.md`](docs/BENCHMARK-SIZING.md).

## Локальное обучение 0.5B — статус (май 2026)

**База:** `Qwen/Qwen2.5-Coder-0.5B-Instruct` (4-bit, Unsloth). **Окружение:** WSL, RTX 4070, `source .venv-train/bin/activate`, `export HF_HOME="$HOME/frules/output/hf-cache"`.

**Solve train закрыт:** 98/98 в `data/challenge-solutions/` → `challenge-train.jsonl`. **Hold-out:** ~53 файла в `eval_holdout` — **не** в train.

### Rules vs без rules

| | **С rules** | **Без rules** |
|---|-------------|----------------|
| Где | Cursor: `./install.sh . gforth` → `rules/*.mdc` в контекст | `training/infer-sandbox.py`, LM Studio без frules |
| Смысл | шпаргалка Forth в каждом запросе | только LoRA + короткий промпт |

**LoRA ≠ rules.** Обучение меняет веса; rules — текст в промпте. Проверки `infer-sandbox.py` были **без rules** — gcd остаётся псевдокодом; это ожидаемый потолок 0.5B, не сломанный train.

### Лог train: loss, grad_norm, learning_rate, epoch

Пример строки Unsloth на шаге:

```text
{'loss': '0.0001788', 'grad_norm': '0.001894', 'learning_rate': '2.583e-05', 'epoch': '8.854'}
```

| Поле | Что это |
|------|---------|
| **loss** | Ошибка угадывания **следующих токенов** в учебном jsonl (не `TESTS OK`). На long-run с повторами может упасть до **10⁻⁴** — зазубривание train, не «идеальный Forth». |
| **grad_norm** | Норма градиента (стабильность шага). Малые значения (~0.002) — норма; огромные скачки — повод остановиться / взять ранний checkpoint. |
| **learning_rate** | Текущий **LR** (скорость обучения), не «рейт». Пик **2e-4**, к концу эпох линейно → ~0. |
| **epoch** | Дробный счётчик эпох: **8.854** при 10 ep ≈ 88% плана. |

**До какого loss учить:** целевого числа нет — закончить запланированные ep → **infer + gforth**. Подробная таблица полей и все параметры запуска — [`training/README.md`](training/README.md#строка-лога-при-train-что-значит-каждое-поле).

### Прогоны уже сделаны

| Adapter | Датасет | Train | train_loss | Infer gcd / factorial (без rules) |
|---------|---------|-------|------------|-----------------------------------|
| `output/sandbox-adapter/` | sandbox ~24 val | 3 шага, 1 ep, ~45 с | ~4.04 | плохо |
| `output/sandbox-adapter-merged/` | train-merged 122 | 32 шага, 2 ep, ~144 с | ~2.61 (шаги ~1.05) | плохо |
| `output/sandbox-adapter-simple/` | train-simple ~24, **3 ep** | 18 шагов, ~78 s | ~3.26 | плохо |
| `output/sandbox-adapter-long/` | train-simple ×5, **10 ep** | 260 шагов, ~19 мин; шаги ~**1.7×10⁻⁴**, итог `train_loss` **0.344** | **плохо** (см. ниже) |

Журнал: [`docs/TRAINING-RUNS.md`](docs/TRAINING-RUNS.md). Подробнее после train: [`docs/TRAINING-NEXT-STEPS.md`](docs/TRAINING-NEXT-STEPS.md).

### Выводы после `sandbox-adapter-long` (infer, май 2026)

**Train завершился штатно** (`run-sandbox-long.sh`: 205 строк × 10 ep, 260 шагов). Loss на шагах упал до ~**0.00017** и вышел на плато — модель **зазубрила** повторённый `train-simple`, не «научилась gforth в целом».

**Infer без rules** (`infer-sandbox.py`, только `user`-промпт — в jsonl при train ещё огромный `system` с frules; см. [`training/README.md`](training/README.md)):

| Запрос | Что выдала LoRA | Вердикт |
|--------|-----------------|--------|
| `gcd` `( a b -- g )` | Много лишних `: help-gcd`, `: flush`, `: factor`…; нет `( a b -- g )` в заголовке; `return.`, `b a r`, хвосты `-- Gforth only -- g d1 d2` | **Не Forth**, в gforth не компилируется |
| `factorial` `( n -- n! )` | Блок ` ```forth `, `factorial : n -- n!`, `n : result`, `while -- next`, спам `throw` | **Не Forth**, не эталон из jsonl |

**Главные выводы:**

1. **Низкий step-loss ≠ рабочий Forth.** Long хуже не стал и лучше не стал относительно merged/simple на smoke-infer — гонять ещё ep/REPEAT на 0.5B **бессмысленно**, если цель — gcd/challenges.
2. **Переобучение на train-текст** возможно даёт **более странный** вывод (обрывки `throw`, `return.`, чужие имена слов), а не копию эталона `: gcd … begin …`.
3. **Судья** — только `gforth` + TESTS OK; для сравнения адаптеров достаточно 2–3 слов из `train-simple` (`gcd`, `factorial`, `count-char`).
4. **Дальше по Track A 0.5B:** Cursor + `./install.sh . gforth`, или **7B** + больше jsonl, или hold-out smoke — не четвёртый круг long train.

Проверка (уже сделанная):

```bash
python3 training/infer-sandbox.py --adapter output/sandbox-adapter-long \
  --prompt "Implement the Forth word \`gcd\` with stack effect ( a b -- g ). Gforth only. Output only colon definition(s)."
```

Эталон из train для сравнения: `: gcd  ( a b -- g )` + `begin dup while tuck mod repeat drop` (см. `tests/ans/gcd.fs`).

### Следующая сессия — с чего начать

Long train **сделан**; следующий шаг — не «ещё 10 ep», а одно из:

- **Cursor + rules** на задачу из `tests/challenges/` (без LoRA);
- **Track B 7B** — [`training/configs/prod-7b.yaml`](training/configs/prod-7b.yaml), `train-merged` или `train.jsonl` ≥500;
- **Eval hold-out** — протокол [`docs/CHALLENGE-RUNS.md`](docs/CHALLENGE-RUNS.md);
- опционально: merge LoRA → GGUF ([раздел Merge LoRA](#merge-lora--полная-модель-и-ollama)) для чата, не для ожидания верного gcd.

### Merge LoRA → полная модель и Ollama

**Два разных «merge» в репо:**

| Что | Команда | Результат |
|-----|---------|-----------|
| **Датасет merged** | `bash scripts/build-train-merged.sh` | `data/train-merged.jsonl` → train → `output/sandbox-adapter-merged/` |
| **Веса merged** | `bash training/run-sandbox-merge.sh` | LoRA **вшит** в полные веса → `output/merged-0.5b/` |

**Когда нужен merge весов:** чат в **Ollama**, **LM Studio**, llama.cpp — им нужен **GGUF** или папка **merged HF**, а не отдельная папка `sandbox-adapter-*` (~17 MB). Для проверки gcd в том же venv достаточно `infer-sandbox.py --adapter …` **без** merge.

**Перед merge:** train уже завершён, папка adapter содержит `adapter_config.json`. Остановите Ollama и другие задачи на GPU. Нужно **~4–8 GB свободной RAM** (0.5B); на 16 GB ноутбуке обычно хватает. Для **7B** merge лучше на машине с **32–64 GB RAM** или swap 16 GB+ ([`docs/MODEL-TRAINING.md`](docs/MODEL-TRAINING.md) §4.1).

```bash
cd ~/frules
source .venv-train/bin/activate
export HF_HOME="$HOME/frules/output/hf-cache"
unset ALL_PROXY all_proxy

# 1) только HF merged (safetensors, для Hugging Face / дальнейший export)
bash training/run-sandbox-merge.sh
# по умолчанию: adapter=output/sandbox-adapter-merged  out=output/merged-0.5b

# другой adapter:
ADAPTER=output/sandbox-adapter-long OUT=output/merged-0.5b-long \
  bash training/run-sandbox-merge.sh

# 2) HF + GGUF за один прогон (дольше, нужен llama.cpp в окружении Unsloth)
ADAPTER=output/sandbox-adapter-merged \
  GGUF=output/forth-gforth-q4_K_M.gguf \
  bash training/run-sandbox-merge.sh

# или напрямую:
python3 training/merge-sandbox.py --adapter output/sandbox-adapter-merged --out output/merged-0.5b
python3 training/merge-sandbox.py --adapter output/sandbox-adapter-merged \
  --gguf output/forth-gforth-q4_K_M.gguf --quant q4_k_m
# только GGUF, без папки merged HF:
python3 training/merge-sandbox.py --adapter output/sandbox-adapter-merged \
  --gguf output/forth-gforth-q4_K_M.gguf --no-merged-hf
```

**Ollama после GGUF:**

1. В [`training/Modelfile.example`](training/Modelfile.example) замените `FROM` на ваш `.gguf` (абсолютный путь или относительный от каталога Modelfile).
2. `ollama create forth-gforth -f training/Modelfile.example`
3. Правила frules в чат: `./install.sh . gforth` (Cursor) или `SYSTEM` в Modelfile — см. [`docs/OLLAMA-FRULES.md`](docs/OLLAMA-FRULES.md) (full/core rules, LoRA+GGUF); baseline Gemma — [`docs/LOCAL-GEMMA-BENCHMARK.md`](docs/LOCAL-GEMMA-BENCHMARK.md).

**Track B (7B):** тот же порядок — adapter из prod-train → `output/merged-7b/` → GGUF → Ollama; см. [`docs/MODEL-TRAINING.md`](docs/MODEL-TRAINING.md) §4.1 (отдельный скрипт под 7B можно добавить по аналогии с `merge-sandbox.py`).

**Ошибка merge `NotImplementedError` (transformers 5.5):** если в логе `Saving full fine-tuned model` и падение в `revert_weight_conversion` — старый вызов `model.save_pretrained_merged()` шёл на **базу без LoRA**. Обновите `training/merge-sandbox.py` из репо и повторите; скрипт вызывает `unsloth_generic_save` / `unsloth_save_pretrained_gguf` с **PeftModel** явно.

### Сборка датасетов

```bash
python3 scripts/build-dataset.py --sandbox --validate     # sandbox.jsonl (33 / 24 val)
python3 scripts/build-dataset.py --validate --out data/train-simple.jsonl
python3 scripts/build-challenge-dataset.py --validate   # challenge-train.jsonl (98)
bash scripts/build-train-merged.sh                        # train-merged.jsonl (~122–139)
python3 scripts/repeat-jsonl.py data/train-simple.jsonl data/train-repeated.jsonl -n 5
```

`build-train-merged.sh` при повторном запуске: долгий шаг = 98× `gforth` на challenge. Если `train-merged.jsonl` уже есть — `FORCE_MERGE_BUILD=1` только при пересборке. `run-sandbox-merged.sh` **не** пересобирает, если merged уже на диске.

### Train / infer (все скрипты)

| Скрипт | Назначение |
|--------|------------|
| [`training/run-sandbox.sh`](training/run-sandbox.sh) | Track A, `sandbox.jsonl` |
| [`training/run-sandbox-merged.sh`](training/run-sandbox-merged.sh) | 0.5B, `train-merged.jsonl`, 2 ep |
| [`training/run-sandbox-long.sh`](training/run-sandbox-long.sh) | repeat ×N + много ep → `sandbox-adapter-long` |
| [`training/train-sandbox.py`](training/train-sandbox.py) | `--dataset` `--out` `--epochs` |
| [`training/infer-sandbox.py`](training/infer-sandbox.py) | `--adapter` `--no-adapter` `--prompt` |
| [`training/merge-sandbox.py`](training/merge-sandbox.py) | LoRA → `merged-0.5b/` и/или GGUF |
| [`training/run-sandbox-merge.sh`](training/run-sandbox-merge.sh) | обёртка merge (`ADAPTER`, `OUT`, `GGUF`) |
| [`scripts/build-ollama-system.sh`](scripts/build-ollama-system.sh) | `rules/*.mdc` → один `.txt` для Ollama SYSTEM |
| [`training/write-modelfile-with-rules.sh`](training/write-modelfile-with-rules.sh) | `.txt` + `FROM` → `Modelfile.<name>` |

Прокси: `ALL_PROXY=socks5` без `socksio` ломает скачивание HF — `run-sandbox*.sh` сбрасывает `ALL_PROXY`, оставляет `HTTP_PROXY`.

### Артефакты на диске (не коммитить)

| Путь | Содержимое |
|------|------------|
| `output/hf-cache/` | база 0.5B |
| `output/sandbox-adapter*` | LoRA (несколько экспериментов) |
| `output/merged-0.5b/` | полные веса после merge (не коммитить) |
| `output/*.gguf` | для Ollama / LM Studio |
| `data/*.jsonl` | датасеты SFT |

Полный гайд установки: [`docs/MODEL-TRAINING.md`](docs/MODEL-TRAINING.md). Скрипты: [`training/README.md`](training/README.md).

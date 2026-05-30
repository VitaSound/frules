# Что делать после обучения 0.5B (frules)

Краткая инструкция после **Track A** (песочница) и **Track A+** (merged). Полный гайд по установке — [`MODEL-TRAINING.md`](MODEL-TRAINING.md). Термины — [`README.md`](../README.md#обучение-локальной-модели-термины).

Журнал прогонов — [`TRAINING-RUNS.md`](TRAINING-RUNS.md).

---

## Что уже сделано (май 2026)

| Прогон | Датасет | Шаги | Время | Loss (итог / шаги) | Infer (без rules) | Adapter |
|--------|---------|------|-------|---------------------|-------------------|---------|
| **Track A** | `sandbox.jsonl` (~24 val) | 3 × 1 ep | ~45 с | ~4.04 | плохо | `output/sandbox-adapter/` |
| **Track A+** | `train-merged.jsonl` (122) | 32 × 2 ep | ~2.4 мин | ~2.61 (шаги ~1.05) | плохо | `output/sandbox-adapter-merged/` |
| **A simple** | `train-simple.jsonl` (~41) | 18 × 3 ep | ~78 с | ~3.26 | gcd fail | `output/sandbox-adapter-simple/` |
| **A long** | `train-simple`×5 → 205 строк | 260 × 10 ep | ~19 мин | `train_loss` 0.344; шаги ~1.7×10⁻⁴ | gcd/factorial fail | `output/sandbox-adapter-long/` |

Базовая модель: **Qwen/Qwen2.5-Coder-0.5B-Instruct** (4-bit, Unsloth).  
Кэш весов: `output/hf-cache/` (переменная `HF_HOME`).

**Вывод long-run:** низкий step-loss = зазубривание повторённого jsonl, **не** рабочий Forth на новом промпте. Ещё ep/REPEAT на 0.5B не приоритет — см. [`README.md`](../README.md#выводы-после-sandbox-adapter-long-infer-май-2026).

**Не в train:** файлы из `eval_holdout` в [`tests/challenges/eval-slices.yaml`](../tests/challenges/eval-slices.yaml) (~53) — только для проверки после обучения.

---

## 1. Окружение (каждая новая сессия WSL)

```bash
cd ~/frules
source .venv-train/bin/activate
export HF_HOME="$HOME/frules/output/hf-cache"
```

Если снова ошибка Hugging Face / «No config file»:

```bash
unset ALL_PROXY all_proxy   # оставьте HTTP_PROXY, если нужен интернет
# или: pip install 'httpx[socks]'
```

---

## 2. Сравнить три режима (smoke, ~5 мин)

Один и тот же промпт, смотрите, похож ли ответ на Forth (`: word ( -- ) … ;`), а не на Python.

```bash
python3 training/infer-sandbox.py --no-adapter
python3 training/infer-sandbox.py --adapter output/sandbox-adapter
python3 training/infer-sandbox.py --adapter output/sandbox-adapter-merged
```

Пример промпта (встроен в скрипт): `Implement : gcd ( a b -- g ). Gforth only.`

**Судья качества — не глаз:** скопировать вывод в файл, прогнать `gforth` с `T{ }T` (как в челленджах), или сравнить с эталоном в `tests/ans/gcd.fs`.

---

## 3. Пересобрать merged (если обновили examples / ans)

После правок `good.fs` / `portable.fs` с `T{ }T` ядро даёт **~41** строку → merged **~139** (было 122):

```bash
FORCE_MERGE_BUILD=1 bash scripts/build-train-merged.sh
# только сборка:
# bash scripts/build-train-merged.sh

# повторный train (другая папка adapter уже по умолчанию):
bash training/run-sandbox-merged.sh
```

Без `FORCE_MERGE_BUILD=1` скрипт **не** перегоняет 98 challenge через gforth, если `data/train-merged.jsonl` уже есть.

---

## 4. Записать прогон в журнал

В [`TRAINING-RUNS.md`](TRAINING-RUNS.md) добавьте строки с датой, loss, путём adapter. Не коммитьте `output/*.safetensors` (гигабайты в `.gitignore`).

Опционально зафиксировать зависимости:

```bash
pip freeze > training/requirements-train.lock.txt
```

---

## 5. Честная оценка (hold-out)

**Только** задачи из среза `eval_holdout` — не из `train_for_sft` (модель их уже видела в merged).

| Срез | Когда |
|------|--------|
| `smoke` | быстрая проверка |
| `eval_holdout` | основная метрика после LoRA |
| `full` (145) | редко, долго |

Протокол:

1. [`docs/CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) — Cursor + frules (`./install.sh . gforth`).
2. [`docs/LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) — Gemma в LM Studio, rules on/off.

Сравнивать: база без LoRA · LoRA merged · LoRA + правила в system.

Файлы в `tests/challenges/` между маркерами paste **пустые**; эталоны hold-out не подглядывать в `data/challenge-solutions/` для тех же slug.

---

## 6. Что дальше по трекам

| Цель | Действие |
|------|----------|
| Понять, помог ли merged 0.5B | holdout smoke + infer (§2–5) |
| Сильнее Forth без смены размера | **Cursor:** `./install.sh . gforth` · **Ollama:** [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md) (`build-ollama-system.sh`, `write-modelfile-with-rules.sh`) |
| LoRA + rules в чате | merge → GGUF → `write-modelfile-with-rules.sh` с `FROM` = `.gguf` |
| Серьёзный train | **Track B:** `Qwen2.5-Coder-7B`, `train-merged` или `train.jsonl` **≥500**, конфиг `training/configs/prod-7b.yaml` |
| Чат в LM Studio с LoRA | merge adapter → GGUF → Ollama ([`README.md`](../README.md#merge-lora--полная-модель-и-ollama)); на Xeon 64 GB — merge на CPU |
| Ещё данные из репо | `challenge-train` уже 98; добить 500+ — внешний Gforth / Rosetta с `gforth TESTS OK` |

**Не делать сейчас без нужды:** ещё long train на 0.5B (long **сделан**, infer не улучшился); подключать LoRA 0.5B к Gemma 7B (нужен новый train).

---

## 7. Быстрая справка команд

```bash
# Датасеты
python3 scripts/build-dataset.py --sandbox --validate
python3 scripts/build-challenge-dataset.py --validate
bash scripts/build-train-merged.sh

# Train
bash training/run-sandbox.sh              # мало данных, 1 epoch
bash training/run-sandbox-merged.sh       # merged, 2 epochs

# Infer
python3 training/infer-sandbox.py --adapter output/sandbox-adapter-merged
python3 training/infer-sandbox.py --adapter output/sandbox-adapter-long

# Merge LoRA → HF / GGUF
ADAPTER=output/sandbox-adapter-long OUT=output/merged-0.5b-long \
  bash training/run-sandbox-merge.sh

# Ollama + frules rules (без LoRA или после merge)
bash scripts/build-ollama-system.sh gforth core -o output/frules-ollama-system-core.txt
bash training/write-modelfile-with-rules.sh forth-qwen-core qwen2.5-coder:0.5b-instruct \
  --system output/frules-ollama-system-core.txt --num-ctx 8192
ollama create forth-qwen-core -f training/Modelfile.forth-qwen-core

# Проверка репо
./test.sh
```

---

## 8. Где лежат артефакты

| Путь | Содержимое |
|------|------------|
| `data/sandbox.jsonl` | Track A (~24–33) |
| `data/train-simple.jsonl` | ans + examples (~41 validated) |
| `data/train-core-validated.jsonl` | только `tests/ans` + `tests/gforth` (~24) |
| `data/train-merged.jsonl` | core-validated + 98 challenge (**122**) |
| `data/train-repeated.jsonl` | `train-simple` × REPEAT (205 при ×5) |
| `data/challenge-train.jsonl` | только challenge train split (gitignored, генерируется) |
| `output/sandbox-adapter/` | LoRA после песочницы |
| `output/sandbox-adapter-merged/` | LoRA после merged |
| `output/sandbox-adapter-simple/` | LoRA после train-simple, 3 ep |
| `output/sandbox-adapter-long/` | LoRA long-run (10 ep, repeat ×5) |
| `output/merged-0.5b*/` | полные веса после merge (gitignored) |
| `output/frules-ollama-system*.txt` | rules → один SYSTEM для Ollama (gitignored) |
| `output/hf-cache/` | скачанная база 0.5B |

---

## 9. Интерпретация loss (ваш merged)

- Старт ~**4.0** — норма для короткого Forth в токенах.
- Падение до ~**1.0** к концу 2-й эпохи — модель **подстроилась под текст** `train-merged.jsonl`.
- Это **не гарантия** верного Forth на новых задачах — только снижение ошибки на учебных парах.

Успех на hold-out = `gforth` → **TESTS OK** на задачах, которых не было в JSONL.

---

## 10. Длинный train (loss ещё падал — не плато)

Пока loss **вниз** в конце прогона, можно **дольше** и **чаще те же строки** jsonl:

```bash
source .venv-train/bin/activate
export HF_HOME="$HOME/frules/output/hf-cache"

# train-simple (~24) x5, 10 эпох -> output/sandbox-adapter-long (~20–40 мин)
bash training/run-sandbox-long.sh

# вариант: merged x3, 15 эпох
BASE=data/train-merged.jsonl REPEAT=3 EPOCHS=15 OUT=sandbox-adapter-long \
  bash training/run-sandbox-long.sh

python3 training/infer-sandbox.py --adapter output/sandbox-adapter-long
```

`REPEAT` — сколько раз продублировать каждую строку (`scripts/repeat-jsonl.py`).  
`EPOCHS` — сколько раз пройти весь файл. Итого gcd встречается в обучении **чаще**.

Если после long-run loss **&lt; 1** а gcd всё ещё псевдокод — упираетесь в **0.5B**, не в число эпох.

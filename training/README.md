# training/

LoRA / QLoRA для Forth (Gforth). **Глоссарий и зачем 145 челленджей vs 33 строк sandbox** — [`../README.md`](../README.md#обучение-локальной-модели-термины).

**Пошагово:** [`docs/MODEL-TRAINING.md`](../docs/MODEL-TRAINING.md) · **после train:** [`docs/TRAINING-NEXT-STEPS.md`](../docs/TRAINING-NEXT-STEPS.md) · журнал: [`docs/TRAINING-RUNS.md`](../docs/TRAINING-RUNS.md)

| Path | Purpose |
|------|---------|
| `configs/sandbox.yaml` | Track A — Qwen2.5-Coder-0.5B, `data/sandbox.jsonl` |
| `configs/prod-7b.yaml` | Track B — 7B, `data/train.jsonl` (≥ 500 rows) |
| `requirements-train.txt` | Python deps; after first OK run: `pip freeze > requirements-train.lock.txt` |
| `run-sandbox.sh` | Track A: `sandbox.jsonl` (~24–33) → `sandbox-adapter/` |
| `run-sandbox-merged.sh` | **Same 0.5B**, `train-merged.jsonl` (~120+) → `sandbox-adapter-merged/` |
| `run-sandbox-long.sh` | Repeat jsonl ×N + many epochs → `sandbox-adapter-long/` |
| `../scripts/repeat-jsonl.py` | Oversample: `repeat-jsonl.py data/train-simple.jsonl out.jsonl -n 5` |
| `configs/sandbox-long.yaml` | Defaults for long run (10 ep, repeat 5) |
| `../scripts/build-train-merged.sh` | `train-core` + `challenge-train` → `data/train-merged.jsonl` |
| `train-sandbox.py` | QLoRA; `--dataset` / `--out` / `--epochs` |
| `infer-sandbox.py` | `--adapter output/sandbox-adapter-merged` or `--no-adapter` |
| `merge-sandbox.py` | LoRA → `output/merged-0.5b/` and/or `--gguf` |
| `run-sandbox-merge.sh` | `ADAPTER`, `OUT`, optional `GGUF=...` |
| `Modelfile.example` | Ollama template after GGUF export |
| `Modelfile.example2` | Ollama + short SYSTEM; use with rules scripts below |
| `../scripts/build-ollama-system.sh` | All `rules/*.mdc` → one text file for Ollama SYSTEM |
| `write-modelfile-with-rules.sh` | Build `Modelfile.<name>` with embedded rules (local `Modelfile.forth-qwen-*` gitignored — regenerate) |
| [`../docs/OLLAMA-FRULES.md`](../docs/OLLAMA-FRULES.md) | **Ollama:** full/core rules, Qwen 0.5B, LoRA+GGUF |

Weights under `../output/` (gitignored). WSL: if `ALL_PROXY=socks5` breaks Hugging Face, `run-sandbox.sh` unsets it when `socksio` is missing.

## Строка лога при train (что значит каждое поле)

Unsloth / Hugging Face `Trainer` печатает **одну строку на шаг** (у нас `logging_steps=1`), например:

```text
{'loss': '0.0001788', 'grad_norm': '0.001894', 'learning_rate': '2.583e-05', 'epoch': '8.854'}
```

| Поле | Русское | Смысл |
|------|---------|--------|
| **`loss`** | потери (loss) | Насколько модель **ошибается**, предсказывая следующие токены в **учебном** батче (кросс-энтропия по jsonl). **Меньше** — лучше подгонка под **тот** текст, что в `train-repeated.jsonl`. **Не** означает «Forth верный в gforth» и **не** сравнивать напрямую между разными датасетами (merged ~1.0 vs long ~0.0002 — разный объём и повторы). |
| **`grad_norm`** | норма градиента | Длина вектора градиентов (L2) перед шагом оптимизатора. **~0.002–0.01** на поздних шагах — обычно спокойно. Резкие **скачки** (десятки+) — нестабильность; можно остановить и взять более ранний `checkpoint-*`. |
| **`learning_rate`** | скорость обучения (LR) | **Текущий** шаг по весам LoRA **сейчас** (не путать с «рейтингом»). Старт после разогрева до пика **`2e-4`** (`--learning-rate`), затем **линейно падает** к ~0 к концу всех эпох (`lr_scheduler_type=linear`). На эпохе ~8.8 LR уже **~2.5e-05** — это нормально. |
| **`epoch`** | эпоха (дробная) | Сколько раз прошли весь датасет: **`8.854`** при `num_train_epochs=10` ≈ **88.5%** плана. **`10.0`** — конец train. |

**Прогресс-бар** `190/260` — номер **шага** (step), не эпоха. Число шагов ≈  
`строки_в_jsonl × epochs ÷ (batch × grad_accum)` → для long: 205×10÷8 ≈ **260**.

**Чекпоинты** `output/sandbox-adapter-long/checkpoint-182/` — сохранение раз в эпоху (`save_strategy=epoch`); финальные веса — в `output/sandbox-adapter-long/` после `done ->`.

### До какого loss учить

**Нет целевого числа.** Критерий: закончили запланированные эпохи → **infer + gforth**. На повторённом малом jsonl loss может уйти в **10⁻⁴** — это зазубривание train, не «ещё надо учить». Подробнее — [`../README.md`](../README.md#локальное-обучение-05b--статус-май-2026).

---

## Параметры запуска обучения

### Окружение (перед любым `run-sandbox*.sh`)

| Переменная | Зачем |
|------------|--------|
| `source .venv-train/bin/activate` | Python с Unsloth, torch, trl |
| `HF_HOME=.../output/hf-cache` | Кэш базы `Qwen2.5-Coder-0.5B` |
| `unset ALL_PROXY all_proxy` | SOCKS без `socksio` ломает скачивание HF (скрипты сбрасывают сами) |

### Обёртки `run-sandbox*.sh`

| Скрипт | Датасет | Эпохи по умолчанию | Выход |
|--------|---------|-------------------|--------|
| `run-sandbox.sh` | `data/sandbox.jsonl` | 1 | `output/sandbox-adapter/` |
| `run-sandbox-merged.sh` | `data/train-merged.jsonl` | 2 | `output/sandbox-adapter-merged/` |
| `run-sandbox-long.sh` | `data/train-repeated.jsonl` (см. ниже) | 10 | `output/sandbox-adapter-long/` |

**Переменные только для `run-sandbox-long.sh`:**

| Переменная | По умолчанию | Смысл |
|------------|--------------|--------|
| `BASE` | `data/train-simple.jsonl` | Исходный jsonl перед повтором |
| `REPEAT` | `5` | Сколько раз продублировать каждую строку (`repeat-jsonl.py`) |
| `EPOCHS` | `10` | Сколько раз пройти весь повторённый файл |
| `OUT` | `sandbox-adapter-long` | Имя папки под `output/` |

Пример: `BASE=data/train-merged.jsonl REPEAT=3 EPOCHS=15 OUT=sandbox-adapter-long bash training/run-sandbox-long.sh`

`run-sandbox-merged.sh`: `FORCE_MERGE_BUILD=1` — пересобрать `train-merged.jsonl`.

### Аргументы `train-sandbox.py`

| Аргумент | По умолчанию | Смысл |
|----------|--------------|--------|
| `--dataset` | `data/sandbox.jsonl` | JSONL с `messages[]` (system / user / assistant) |
| `--out` | `output/sandbox-adapter` | Куда писать LoRA + tokenizer |
| `--epochs` | `1` | `num_train_epochs` |
| `--learning-rate` | `2e-4` | Пик LR после warmup |

Вызов из скриптов: `python3 training/train-sandbox.py --dataset … --out output/… --epochs …`

### Зашито в `train-sandbox.py` (менять в коде / позже в yaml)

| Параметр | Значение | Смысл |
|----------|----------|--------|
| `MODEL` | `Qwen/Qwen2.5-Coder-0.5B-Instruct` | Базовая модель |
| `load_in_4bit` | да | QLoRA: база в VRAM в 4-bit |
| `MAX_SEQ_LENGTH` | 1024 | Обрезка длины примера |
| `LORA_R` / `LORA_ALPHA` | 8 / 16 | Ранг и масштаб LoRA |
| `target_modules` | q,k,v,o + MLP | Куда вешать адаптер |
| `per_device_train_batch_size` | 2 | Примеров на GPU за микро-шаг |
| `gradient_accumulation_steps` | 4 | **Эффективный** batch = 2×4 = **8** строк |
| `optim` | `adamw_8bit` | Оптимизатор |
| `warmup_steps` | ~10% датасета | LR с 0 до пика |
| `lr_scheduler_type` | `linear` | Пик → 0 к концу |
| `logging_steps` | 1 | Строка loss каждый шаг |
| `save_strategy` | `epoch` | Чекпоинт раз в эпоху |
| `packing` | false | Каждая строка jsonl — отдельный пример |

Справочник в yaml (документация, скрипт читает не всё): `configs/sandbox.yaml`, `configs/sandbox-long.yaml`, `configs/sandbox-merged.yaml`.

### Infer после train (не train-параметры)

```bash
python3 training/infer-sandbox.py --adapter output/sandbox-adapter-long
python3 training/infer-sandbox.py --adapter output/… --prompt "Implement …"
python3 training/infer-sandbox.py --no-adapter   # только база
```

**Расхождение train vs infer:** в jsonl три роли (`system` + `user` + `assistant`, system = сжатые frules rules). `infer-sandbox.py` шлёт **только** `user` — модель видит другой формат, чем при SFT. Плюс `max_new_tokens=256` — может генерировать много лишних `: word` после первого `;`.

**Результат long (2026-05-30):** step-loss ~10⁻⁴, но gcd/factorial — псевдо-Forth (`return.`, markdown, лишние слова). Выводы — [`../README.md`](../README.md#выводы-после-sandbox-adapter-long-infer-май-2026).

### Merge / GGUF: сбой `NotImplementedError`

Симптом: после `merge -> ...` сообщение `Saving full fine-tuned model` и traceback в `transformers...revert_weight_conversion`.

Причина: у `PeftModel` метод `save_pretrained_merged` проброшен на **4-bit базу**; Unsloth не видит LoRA.

Исправление в `merge-sandbox.py`: прямой вызов `unsloth_generic_save(model=peft, …)` и `unsloth_save_pretrained_gguf(peft, …)`. Перезапустите:

```bash
ADAPTER=output/sandbox-adapter-long \
OUT=output/merged-0.5b-long \
GGUF=output/forth-gforth-long-q4_K_M.gguf \
bash training/run-sandbox-merge.sh
```

См. также [`../README.md`](../README.md) (статус Track A, merge, датасеты).

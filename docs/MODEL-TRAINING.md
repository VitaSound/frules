# Обучение модели Forth (frules)

Пошаговые инструкции: от нуля до своей LoRA в Ollama и бенчмарка [`tests/challenges/`](../tests/challenges/).

**Железо (ориентир):** RTX 4070 Laptop 16 GB VRAM, 16 GB RAM, Intel i7-13650HX.

**Политика:** всё открыто, без продаж; лицензии не блокируют шаги (атрибуция в [`SOURCES.md`](SOURCES.md)).

| Документ | Когда |
|----------|--------|
| Этот файл | train + датасет + Ollama |
| [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) | baseline Gemma 4 без train |
| [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) | ручной прогон челленджей |
| [`TRAINING-RUNS.md`](TRAINING-RUNS.md) | журнал ваших прогонов |
| [`TRAINING-NEXT-STEPS.md`](TRAINING-NEXT-STEPS.md) | после Track A / merged / long: infer, eval, дальше |
| [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md) | Ollama + frules rules (full/core SYSTEM, Qwen 0.5B, LoRA+GGUF) |

---

## 0. Глоссарий

| Термин | Смысл |
|--------|--------|
| **SFT** | Supervised fine-tuning: пары «промпт → код» |
| **LoRA** | Маленький адаптер поверх базовой модели |
| **QLoRA** | LoRA + 4-bit база (влезает в 16 GB VRAM) |
| **Merge** | слить adapter в полные веса |
| **GGUF** | формат для llama.cpp / Ollama |
| **Hold-out** | **`eval_holdout`** — **53** файла (слепой eval); **151** total в каталоге (6 seeds + 145 bank) |

---

## 1. Окружение

### 1a. Ubuntu 24 (рекомендуется, внешний диск)

Раздел **ext4** для репо и кэша (не NTFS для Hugging Face).

```bash
sudo apt update
sudo apt install -y gforth git python3-venv python3-pip build-essential

# NVIDIA (если nvidia-smi нет)
sudo ubuntu-drivers install
# перезагрузка
nvidia-smi

# Ollama
curl -fsSL https://ollama.com/install.sh | sh

# frules
git clone <your-repo-url> ~/frules
cd ~/frules
./test.sh

# Кэш моделей на быстром диске
export HF_HOME="$HOME/frules/output/hf-cache"
mkdir -p "$HF_HOME"

# Swap 8–16 GB перед merge 7B (16 GB RAM тесно)
# sudo fallocate -l 16G /swapfile && sudo chmod 600 /swapfile && sudo mkswap /swapfile && sudo swapon /swapfile
```

### 1b. WSL2 (опционально)

Драйвер NVIDIA в **Windows**. В WSL: `nvidia-smi` без отдельного драйвера Linux.

Репозиторий на `\\wsl$\...` или ext4 VHD. При нехватке RAM — `~/.wslconfig` (`memory`, `swap`).

### 1c. Проверка GPU

```bash
nvidia-smi
python3 -c "import torch; print(torch.cuda.is_available(), torch.cuda.get_device_name(0))"
```

Ожидаемо: `True`, `NVIDIA GeForce RTX 4070 Laptop GPU`.

### 1d. Python venv для train

```bash
cd ~/frules
python3 -m venv .venv-train
source .venv-train/bin/activate
pip install -U pip
pip install -r training/requirements-train.txt
```

После первого успешного прогона зафиксируйте версии: `pip freeze > training/requirements-train.lock.txt`

---

## 2. Датасет

### Текущее состояние frules

| Источник | ~пар | В sandbox/train |
|----------|------|-----------------|
| `tests/ans/` | ~25 | да |
| `tests/gforth/` | ~2 | да |
| `examples/gforth/good.fs` | ~9 | да (без `gforth` тестов в файле) |
| `tests/challenges/` | 0 в train | **только eval** (см. [`BENCHMARK-SIZING.md`](BENCHMARK-SIZING.md), [`eval-slices.yaml`](../tests/challenges/eval-slices.yaml)) |
| Внешний Gforth `.fs` | 0 | **вы добавляете** для Track B (500+) |

### Сборка JSONL

```bash
cd ~/frules
python3 scripts/build-dataset.py --sandbox    # -> data/sandbox.jsonl (~33 строк)
python3 scripts/build-dataset.py              # -> data/train.jsonl (~41 + portable)

# Только строки, чей исходный .fs даёт TESTS OK (без good.fs)
python3 scripts/build-dataset.py --sandbox --validate
```

Формат: [`data/README.md`](../data/README.md).

### Hold-out и челленджи

- **Не** включайте `tests/challenges/` в train.
- В `01-clamp.fs` и `04-caesar-shift.fs` между маркерами могут быть черновики — **очистите** перед честным бенчмарком или не используйте эти файлы как эталон в train.
- Решения для **обучения**: срез `train_for_sft` (**98/98 готово**) → [`data/challenge-solutions/`](../data/challenge-solutions/) → [`CHALLENGE-TO-TRAIN.md`](CHALLENGE-TO-TRAIN.md). **Не** в `tests/challenges/*.fs`. Фаза batch-solve закрыта — см. [`SOLVE-QUEUE.md`](../data/challenge-solutions/SOLVE-QUEUE.md).
- **Eval / валидация моделей:** только `eval_holdout` (6 seeds + ~39 bank) — не попадают в `challenge-train.jsonl`, не подглядывать в gold solutions hold-out slug.

### Расширение датасета (Track B)

1. Клон Gforth upstream, нарезка `: … ;` + комментарии → `build-dataset.py` (расширить скрипт или второй pass).
2. Синтетика (Cursor/Composer): spec + frules → код → **только** если `gforth` PASS.
3. Опционально: chunk из `sources/brodie-thinking-forth/*.md`, `sources/gforth-manual-tutorial/*.md`, `sources/gforth-manual/*.md`, фрагмент из `sources/theforth.net-packages/`, или адаптированный сниппет из `sources/rosettacode-forth/` + промпт «напиши Gforth-пример к идиоме».
4. Цель: **≥ 500** строк в `data/train.jsonl`.

Приоритет: **код с gforth** > rules в system > prose (Brodie, Gforth tutorial).

### Embedded и портирование (FMAP)

Пошаговый выбор системы под задачу — [`FORTH-FMAP-GUIDE.md`](FORTH-FMAP-GUIDE.md); шаблоны — [`data/forth-use-case-templates.json`](../data/forth-use-case-templates.json).

Для пар «промпт → Forth под конкретное железо» добавляйте в **system** или **user** контекст:

1. Целевую систему (`stm8ef`, `Mecrisp-Stellaris`, …).
2. Краткий **FMAP** (MM, EX-C, RP) — см. [`FORTH-SYSTEM-ARCHITECTURE.md`](FORTH-SYSTEM-ARCHITECTURE.md) §13, [`FORTH-THREADING.md`](FORTH-THREADING.md) §11 для EX-C.
3. Профиль из [`data/forth-fmap-profiles.json`](../data/forth-fmap-profiles.json) (поле `id`) + модель из [`data/forth-threading-models.json`](../data/forth-threading-models.json) (join по `ex_c` = `fmap_ex_c`).

Пример system-фрагмента:

```text
Target: stm8ef (STM8 Harvard). FMAP: MM=D EX-C=S RP=4 — STC, not bytecode VM.
No Gforth { locals } unless shim documented. Flash compile uses NVM path, not HERE ,.
```

**Hold-out:** не смешивать Gforth desktop idioms с embedded без явной метки dialect/FMAP в записи JSONL.

---

## 3. Трек A — песочница (~30–60 мин)

**Цель:** понять цепочку dataset → QLoRA → ответ. **Не** ждите качества Forth на `06-roman`.

| Параметр | Значение |
|----------|----------|
| Модель | `Qwen/Qwen2.5-Coder-0.5B-Instruct` |
| Данные | `data/sandbox.jsonl` |
| LoRA | rank 8, alpha 16, 1 эпоха, seq 1024 |
| VRAM | ~2–4 GB |

Конфиг: [`training/configs/sandbox.yaml`](../training/configs/sandbox.yaml).

### 3.1 Unsloth (рекомендуется)

Следуйте [Unsloth QLoRA docs](https://docs.unsloth.ai/) — notebook или скрипт:

1. Загрузить `Qwen2.5-Coder-0.5B-Instruct`, 4-bit.
2. Подключить LoRA (rank 8).
3. Загрузить JSONL: поле `messages` → chat template.
4. `train` 1 эпоха, сохранить adapter в `output/sandbox-adapter/`.

Подсказка: [`training/run-sandbox.sh`](../training/run-sandbox.sh) — проверка наличия `data/sandbox.jsonl`.

### 3.2 Проверка без merge

```python
# После train в том же venv (псевдокод — см. Unsloth FastLanguageModel)
# prompt: "Implement : gcd ( a b -- g ). Gforth only. Stack effect on : word."
```

Успех Трека A:

- [ ] loss падал
- [ ] ответ похож на Forth (не Python)
- [ ] запись в [`TRAINING-RUNS.md`](TRAINING-RUNS.md)

Merge → Ollama для 0.5B **опционально**.

---

## 4. Трек B — Forth LoRA 7B

После успешной песочницы и **≥ 500** строк в `data/train.jsonl`.

| Параметр | Значение |
|----------|----------|
| Модель | `Qwen/Qwen2.5-Coder-7B-Instruct` |
| QLoRA | 4-bit, rank 32, alpha 64 |
| batch | 1–2, grad accum 16, seq 2048 |
| VRAM | ~10–14 GB |

Конфиг: [`training/configs/prod-7b.yaml`](../training/configs/prod-7b.yaml).

**Не** запускайте Ollama с Gemma на той же GPU во время train.

### 4.1 Merge и Ollama

1. Остановить train.
2. Merge adapter → полные веса (или сразу GGUF):
   - **0.5B:** [`training/merge-sandbox.py`](../training/merge-sandbox.py) / `bash training/run-sandbox-merge.sh` — см. [`README.md`](../README.md) раздел **«Merge LoRA»**.
   - **7B:** тот же Unsloth API (`save_pretrained_merged`, `save_pretrained_gguf`) → `output/merged-7b/`; при нехватке RAM — только infer с adapter, без merge.
3. GGUF по умолчанию `q4_k_m`: `--gguf output/forth-gforth-q4_K_M.gguf`.
4. `ollama create forth-gforth -f training/Modelfile.example` (путь `FROM` → ваш `.gguf`).

### 4.2 frules в inference

```bash
./install.sh . gforth   # Cursor rules
```

В Modelfile / API — system из `rules/`:

- **Полный гайд:** [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md) — `build-ollama-system.sh`, `write-modelfile-with-rules.sh`, full/core, `num_ctx`.
- **Кратко (curl):** [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) §5.
- **Cursor:** `./install.sh . gforth` (rules в `.cursor/rules/`, LoRA отдельно через Ollama).

---

## 5. Оценка

### Трек A

Smoke: один промпт `: gcd`. Опционально вставка в копию `tests/ans/gcd.fs` → `gforth`.

### Трек B — матрица 4 прогонов

| Прогон | frules | LoRA |
|--------|--------|------|
| Base Ollama | off | off |
| +frules | on | off |
| +LoRA | off | on |
| +LoRA+frules | on | on |

Hold-out: **53** файла (`eval_holdout`: часть seeds + bank). Полный банк **151** (6 seeds + 145 bank). Полный прогон hold-out не обязателен — используйте срезы из [`eval-slices.yaml`](../tests/challenges/eval-slices.yaml): `smoke` (~12), `standard` (~24), `stratified_20`. Протокол: [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md), размер: [`BENCHMARK-SIZING.md`](BENCHMARK-SIZING.md).

Заполнить [`TRAINING-RUNS.md`](TRAINING-RUNS.md) и таблицу в `CHALLENGE-RUNS.md`.

---

## 6. Хранение артефактов

| Путь | Содержимое |
|------|------------|
| `output/hf-cache/` | Hugging Face download |
| `output/sandbox-adapter/` | LoRA 0.5B |
| `output/merged-7b/` | merged weights |
| `output/*.gguf` | для Ollama |

Всё под `output/` в `.gitignore` — **не коммитить** гигабайты.

Короткая карточка модели (опционально): `output/forth-gforth/README.md` — база, датасет N, challenges score.

---

## 7. Дорожная карта по сессиям

| Сессия | Действие |
|--------|----------|
| 0 | Прочитать этот файл; `build-dataset.py --sandbox` |
| 1 | Ubuntu + GPU + Трек A (0.5B) |
| 2 | Gemma baseline — [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) |
| 3 | Датасет 500+, внешний Gforth |
| 4 | Трек B 7B → Ollama → eval на challenges (seeds + stratified sample из 125) |
| 5+ | Больше данных, повтор train, опционально DPO |

---

## 8. Troubleshooting

| Симптом | Действие |
|---------|----------|
| `torch.cuda False` | драйвер NVIDIA, перезагрузка, не Intel iGPU |
| OOM 7B | batch 1, rank 16, seq 1024; только adapter без merge |
| Модель пишет Python | усилить system; больше Forth в train |
| `good.fs` нет в `--validate` | норма — в файле нет `T{ }T`; без `--validate` в sandbox |
| NTFS медленно | `HF_HOME` на ext4 |
| Unsloth `No config file found` | HF не скачал модель: пустой `output/hf-cache`. Часто **ALL_PROXY=socks5** без `socksio` — `unset ALL_PROXY` (оставить `HTTP_PROXY`) или `pip install 'httpx[socks]'`; перезапустить `bash training/run-sandbox.sh` |
| Перегрев ноутбука | `nvidia-smi -l 1`, паузы, power limit |

---

## 9. Чек-листы

### Песочница пройдена

- [ ] `data/sandbox.jsonl` ≥ 25 строк
- [ ] `nvidia-smi` OK
- [ ] train 0.5B завершился
- [ ] smoke inference на `: gcd`
- [ ] строка в `TRAINING-RUNS.md`

### Forth-модель готова

- [ ] `data/train.jsonl` ≥ 500
- [ ] QLoRA 7B завершился
- [ ] `ollama run forth-gforth` отвечает
- [ ] challenges: N/M записан (seeds 6 + stratified bank sample)
- [ ] hold-out: challenges не в train

---

## 10. Фаза 3 (позже)

- DPO: пары pass/fail по одному челленджу, reward = `gforth`
- `scripts/run-challenge.sh` — автопрогон
- Публикация на Hugging Face Hub
- Челленджи 07–10 из [`TODO.md`](../TODO.md)

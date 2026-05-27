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

---

## 0. Глоссарий

| Термин | Смысл |
|--------|--------|
| **SFT** | Supervised fine-tuning: пары «промпт → код» |
| **LoRA** | Маленький адаптер поверх базовой модели |
| **QLoRA** | LoRA + 4-bit база (влезает в 16 GB VRAM) |
| **Merge** | слить adapter в полные веса |
| **GGUF** | формат для llama.cpp / Ollama |
| **Hold-out** | `tests/challenges/` — не в train, только оценка |

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
| `tests/challenges/` | 0 в train | **только eval** |
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
- Эталоны для eval: решить 02–06, `gforth` → `TESTS OK`, хранить в `data/labels/` (отдельно от train).

### Расширение датасета (Track B)

1. Клон Gforth upstream, нарезка `: … ;` + комментарии → `build-dataset.py` (расширить скрипт или второй проход).
2. Синтетика (Cursor/Composer): spec + frules → код → **только** если `gforth` PASS.
3. Опционально: chunk из `sources/brodie-thinking-forth/*.md` + промпт «напиши Gforth-пример к идиоме».
4. Цель: **≥ 500** строк в `data/train.jsonl`.

Приоритет: **код с gforth** > rules в system > prose Brodie.

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
2. Merge adapter → `output/merged-7b/` (или inference только с adapter при нехватке RAM).
3. Конвертация в GGUF `q4_K_M` (llama.cpp / Unsloth export).
4. `ollama create forth-gforth -f training/Modelfile.example` (путь `FROM` → ваш `.gguf`).

### 4.2 frules в inference

```bash
./install.sh . gforth   # Cursor rules
```

В Modelfile / API — system из `rules/` (см. [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) §5, сборка system prompt).

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

По каждому из 6 челленджей — протокол [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md): новый чат, промпт, `cd tests/challenges && gforth NN-name.fs` → `TESTS OK`.

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
| 4 | Трек B 7B → Ollama → 6 challenges |
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
- [ ] challenges: N/6 записан
- [ ] hold-out: challenges не в train

---

## 10. Фаза 3 (позже)

- DPO: пары pass/fail по одному челленджу, reward = `gforth`
- `scripts/run-challenge.sh` — автопрогон
- Публикация на Hugging Face Hub
- Челленджи 07–10 из [`TODO.md`](../TODO.md)

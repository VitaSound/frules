# Ollama + frules rules (все `.mdc`)

Как подключить правила Forth из `rules/*.mdc` к локальной модели в **Ollama**. Cursor делает это через `./install.sh` → `.cursor/rules/`; Ollama **не читает** `.mdc` сам — нужен один текстовый **SYSTEM**.

| Документ | Когда |
|----------|--------|
| Этот файл | Ollama + frules (база, LoRA, core/full rules) |
| [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) | Gemma 4, A/B с rules |
| [`MODEL-TRAINING.md`](MODEL-TRAINING.md) | LoRA train, merge → GGUF |
| [`training/Modelfile.example`](../training/Modelfile.example) | GGUF после merge LoRA |
| [`training/Modelfile.example2`](../training/Modelfile.example2) | Короткий SYSTEM без полного набора rules |

---

## 1. Собрать rules в один файл

Скрипт повторяет набор файлов из [`install.sh`](../install.sh) (dialect + profile).

| Профиль | Файлов rules | ~Размер | Куда |
|---------|--------------|---------|------|
| **core** | index, system-context, anti-patterns, stack, style, dialect-gforth | ~25 KB | `output/frules-ollama-system-core.txt` |
| **full** | core + все `forth-*.mdc` темы | ~74 KB | `output/frules-ollama-system.txt` |

```bash
cd ~/frules

# полный объём (как install.sh gforth full)
bash scripts/build-ollama-system.sh gforth full -o output/frules-ollama-system.txt

# урезанный (как install.sh gforth core)
bash scripts/build-ollama-system.sh gforth core -o output/frules-ollama-system-core.txt

# только ANS, без Gforth-диалекта
bash scripts/build-ollama-system.sh ans full -o output/frules-ollama-system-ans.txt
```

Проверка размера: `wc -c output/frules-ollama-system.txt`

---

## 2. Необученный Qwen 0.5B + **полный** frules

База из Ollama Hub, без LoRA.

```bash
ollama pull qwen2.5-coder:0.5b-instruct
cd ~/frules

# Modelfile с вшитым SYSTEM из полного файла rules
bash training/write-modelfile-with-rules.sh forth-qwen-full qwen2.5-coder:0.5b-instruct \
  --system output/frules-ollama-system.txt \
  --num-ctx 16384

ollama create forth-qwen-full -f training/Modelfile.forth-qwen-full
ollama run forth-qwen-full
```

Имя модели (`forth-qwen-full`) можно заменить на своё. После правок в `rules/` пересоберите txt и снова `write-modelfile-with-rules.sh` + `ollama create` (или новое имя версии).

**Контекст:** ~74 KB system ≈ 15–20k токенов. Для **full** нужен `num_ctx` **16384** (или больше). На 0.5B с 4096 full rules **не влезут** вместе с длинным промптом.

---

## 3. Необученный Qwen 0.5B + **core** frules

Тот же порядок, меньший SYSTEM (~25 KB), `num_ctx 8192` обычно достаточно:

```bash
ollama pull qwen2.5-coder:0.5b-instruct
cd ~/frules

bash training/write-modelfile-with-rules.sh forth-qwen-core qwen2.5-coder:0.5b-instruct \
  --system output/frules-ollama-system-core.txt \
  --num-ctx 8192

ollama create forth-qwen-core -f training/Modelfile.forth-qwen-core
ollama run forth-qwen-core
```

---

## 4. Варианты без полного SYSTEM

| Вариант | Команда |
|---------|---------|
| Короткий SYSTEM (1 абзац) | `ollama create forth-qwen-base -f training/Modelfile.example2` → `ollama run forth-qwen-base` |
| Чистый Qwen, без frules | `ollama run qwen2.5-coder:0.5b-instruct` |
| Своя LoRA (GGUF) + rules | merge → [`MODEL-TRAINING.md`](MODEL-TRAINING.md); `write-modelfile-with-rules.sh` с `FROM` = путь к `.gguf` |

Пример LoRA + full rules:

```bash
# после merge: output/forth-gforth-long-q4_K_M.gguf
bash training/write-modelfile-with-rules.sh forth-gforth-long \
  /home/sea/frules/output/forth-gforth-long-q4_K_M.gguf \
  --system output/frules-ollama-system.txt \
  --num-ctx 16384
ollama create forth-gforth-long -f training/Modelfile.forth-gforth-long
ollama run forth-gforth-long
```

---

## 5. API без пересоздания модели

SYSTEM из файла на каждый запрос (удобно при частых правках `rules/`):

```bash
curl -s http://localhost:11434/api/chat -d "$(jq -n \
  --rawfile sys output/frules-ollama-system.txt \
  --arg usr "Implement : gcd ( a b -- g ). Gforth only. Output only colon definitions." \
  '{model:"forth-qwen-full", stream:false,
    messages:[{role:"system",content:$sys},{role:"user",content:$usr}]}')" \
  | jq -r '.message.content'
```

Baseline без rules — уберите сообщение `system` из `messages`.

---

## 6. Скрипты

| Скрипт | Назначение |
|--------|------------|
| [`scripts/build-ollama-system.sh`](../scripts/build-ollama-system.sh) | `rules/*.mdc` → один `.txt` |
| [`training/write-modelfile-with-rules.sh`](../training/write-modelfile-with-rules.sh) | `.txt` + `FROM` → `training/Modelfile.<name>` |

`write-modelfile-with-rules.sh` без `--system` сам вызывает `build-ollama-system.sh`:

```bash
bash training/write-modelfile-with-rules.sh forth-qwen-full qwen2.5-coder:0.5b-instruct gforth full
# эквивалентно --system output/frules-ollama-system.txt после сборки full
```

Опции: `--system PATH`, `--num-ctx N`.

---

## 7. GPU: Ollama «как будто на CPU»

Обучение (Unsloth) у вас уже шло на **RTX 4070** — это отдельно от Ollama. Если в чате Ollama не растёт загрузка GPU, чаще всего **рантайм Ollama не видит CUDA**, а не «модель слишком маленькая».

### Как проверить (два терминала)

**Терминал 1** — пока идёт ответ в `ollama run …`, задайте длинный промпт и смотрите GPU:

```bash
watch -n0.5 nvidia-smi
```

**Терминал 2:**

```bash
ollama ps
```

В колонке **Processor** должно быть что-то вроде `100% GPU` или `GPU`, не только `CPU`. Пока модель в памяти после `ollama run`, в `nvidia-smi` появится процесс **`ollama`** и рост **VRAM** (0.5B — порядка сотен MB–1 GB весов + KV под `num_ctx`).

У **Qwen 0.5B** всплеск на GPU **короткий** — легко пропустить в диспетчере задач Windows, если смотреть не в момент генерации.

### Частые причины CPU-only

| Причина | Что сделать |
|---------|-------------|
| **Ollama из Snap** (`/snap/bin/ollama`) | Snap часто **без GPU** в WSL/Linux. Удалить snap, поставить с [ollama.com](https://ollama.com): `curl -fsSL https://ollama.com/install.sh \| sh`, перезапустить `sudo systemctl restart ollama` |
| **WSL2 без GPU** | Драйвер NVIDIA на **Windows** (не только в Ubuntu). В WSL: `nvidia-smi` должен работать **до** Ollama. Обновить WSL: `wsl --update` |
| **Сервис стартовал без CUDA** | `sudo systemctl restart ollama`, снова `ollama run …` |
| Смотрите не тот процесс | Грузится **`ollama`**, не `python` из `.venv-train` |
| Весь контекст в RAM | Огромный SYSTEM (full rules ~74 KB) + `num_ctx` — KV в RAM; **веса** всё равно обычно на GPU. Для проверки: `ollama run qwen2.5-coder:0.5b-instruct` без вашего Modelfile |

### Логи и принудительный GPU

```bash
# при установке из install.sh — лог сервиса
journalctl -u ollama -e --no-pager | tail -30
# ищите: CUDA, GPU, library=cuda, offloaded ... layers to GPU
# плохо: CPU, llama.cpp CPU backend

# сколько слоёв на GPU (если переменная поддерживается вашей версией)
OLLAMA_NUM_GPU=999 ollama run forth-qwen-full "test"
```

Переменные (экспорт перед `ollama serve` или в `systemctl edit ollama`):

```bash
export OLLAMA_NUM_GPU=999          # максимум слоёв на GPU
export CUDA_VISIBLE_DEVICES=0
```

### WSL2 + Windows

- Task Manager → Performance → GPU смотрит **хост**; в WSL нагрузка идёт через **CUDA в Linux** — надёжнее **`nvidia-smi` внутри WSL** во время `ollama run`.
- Если `nvidia-smi` в WSL падает, Ollama будет на **CPU**, даже когда PyTorch/Unsloth на GPU работали (разные пути к драйверу у snap vs venv).

### Отличие от train

| | Unsloth / `infer-sandbox.py` | Ollama |
|---|------------------------------|--------|
| Бинарник | Python + torch в `.venv-train` | демон `ollama` (часто snap/systemd) |
| Проверка | `nvidia-smi` во время train | `nvidia-smi` + `ollama ps` во время `ollama run` |

---

## 8. Частые проблемы (прочее)

| Симптом | Что сделать |
|---------|-------------|
| Ответ обрывается | Поднять `num_ctx`; для full — 16384 |
| Модель «не видит» rules | Проверить, что чат идёт через `ollama run forth-qwen-full`, а не голый `qwen2.5-coder:0.5b-instruct` |
| Пишет C/Python | В system уже есть запрет; уточнить user: «Gforth only, postfix» |
| `ollama create` после правок rules | Пересобрать `.txt` + снова `write-modelfile-with-rules.sh` + `ollama create` |
| Merge LoRA падает `NotImplementedError` | Обновить [`training/merge-sandbox.py`](../training/merge-sandbox.py), см. [`README.md`](../README.md) раздел Merge |

---

## 9. Сравнение с Cursor

| | Cursor | Ollama |
|---|--------|--------|
| Подключение rules | `./install.sh . gforth` | SYSTEM в Modelfile или API |
| Полный набор | все `.mdc` по globs | `build-ollama-system.sh gforth full` |
| LoRA frules | отдельно (train) | `FROM` ваш `.gguf` + тот же SYSTEM |

См. также [`RULES-ARCHITECTURE.md`](RULES-ARCHITECTURE.md).

# Track A — финальный прогон (исправленная длина примеров)

Закрываем Track A **честно**: после фикса короткого `system` и parity infer/train.

**0.5B — не ошибка:** эксперимент дал fix pipeline + честный отрицательный результат → см. [`TRACK-A-LESSONS.md`](TRACK-A-LESSONS.md). **Проехали дальше** к IR + transpiler + rules.

Полный гайд по train: [`MODEL-TRAINING.md`](MODEL-TRAINING.md). Журнал: [`TRAINING-RUNS.md`](TRAINING-RUNS.md). База знаний: [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md).

---

## Что было сломано (старые прогоны merged/long)

| Проблема | Следствие |
|----------|-----------|
| `system` = AGENTS.md + `.mdc` (~4000 токенов) | при `MAX_SEQ_LENGTH=1024` **assistant (Forth-код) обрезан** — LoRA учила rules, не gcd |
| `infer-sandbox.py` без `system` | другой формат, чем при SFT |
| Короткий user в infer vs длинный в jsonl | ещё один сдвиг |

**Старые adapter** (`sandbox-adapter-merged`, `sandbox-adapter-long`) — результаты **невалидны** для выводов о Forth; их не сравнивать с новым прогоном.

---

## Что исправлено

| Файл | Изменение |
|------|-----------|
| `scripts/sft_prompts.py` | короткий `TRAIN_SYSTEM_SHORT` (~50 токенов) |
| `scripts/build-dataset.py` | `--system short` (default) / `full` |
| `scripts/build-challenge-dataset.py` | то же |
| `scripts/build-train-merged.sh` | short + `validate-train-tokens.py` |
| `scripts/validate-train-tokens.py` | проверка: все строки ≤ 1024 токенов |
| `training/infer-sandbox.py` | `--system short`, `--from-jsonl`, `--word` |
| `scripts/track-a-smoke-infer.sh` | smoke gcd / factorial / divisible? |
| `training/run-track-a-final.sh` | один скрипт: rebuild → validate → train → smoke |

---

## Протокол (выполнить самому)

### Окружение

```bash
cd ~/frules
source .venv-train/bin/activate
export HF_HOME="$HOME/frules/output/hf-cache"
```

### Шаг 0 — проверить, что старый jsonl был обрезан (опционально)

```bash
# если ещё есть старый train-simple с full system — покажет TRUNCATED
python3 scripts/validate-train-tokens.py data/train-simple.jsonl || true
```

После пересборки (шаг 1) та же команда должна вывести `OK`.

### Шаг 1 — пересобрать датасеты

```bash
python3 scripts/build-dataset.py --validate --system short --out data/train-simple.jsonl
python3 scripts/validate-train-tokens.py data/train-simple.jsonl

FORCE_MERGE_BUILD=1 SYSTEM=short bash scripts/build-train-merged.sh
```

Ожидание для `train-simple.jsonl`: `OK`, max **~150–400 tok** (не 4000+).

Merged (~139 строк): часть challenge длиннее 1024 tok — скрипт merge проверяет **2048** и печатает  
`note: train-merged needs --max-seq 2048`.

### Шаг 2 — train (новый adapter)

**Рекомендуемый финальный прогон** — core 41 строка, `max_seq=1024`:

```bash
bash training/run-track-a-final.sh
```

Опционально merged (длинные challenge, `max_seq=2048`):

```bash
DATASET=data/train-merged.jsonl ADAPTER=output/sandbox-adapter-fixed-merged \
  bash training/run-track-a-final.sh
```

Переменные:

```bash
ADAPTER=output/sandbox-adapter-fixed EPOCHS=3 bash training/run-track-a-final.sh
SKIP_TRAIN=1 bash training/run-track-a-final.sh   # только rebuild + infer smoke
MAX_SEQ=2048 DATASET=data/train-merged.jsonl bash training/run-track-a-final.sh
```

Время: ~2–5 мин train на RTX 4070 (simple); merged дольше из‑за 2048.

### Шаг 3 — infer вручную (parity)

```bash
# точно как в jsonl (system + user из train):
python3 training/infer-sandbox.py \
  --adapter output/sandbox-adapter-fixed \
  --from-jsonl data/train-simple.jsonl \
  --word gcd

python3 training/infer-sandbox.py \
  --adapter output/sandbox-adapter-fixed \
  --from-jsonl data/train-simple.jsonl \
  --word factorial

# база без LoRA (контроль):
python3 training/infer-sandbox.py --no-adapter \
  --from-jsonl data/train-simple.jsonl --word gcd
```

Сравнить с эталоном:

```bash
grep -A5 '^: gcd' tests/ans/gcd.fs
```

### Шаг 4 — smoke-скрипт

```bash
bash scripts/track-a-smoke-infer.sh output/sandbox-adapter-fixed
```

Проверяет: есть `: word`, есть `;`, нет markdown / `return.`.

### Шаг 5 — gforth (строгий судья)

Сохранить вывод infer в файл и прогнать с тестами, если слово есть в `tests/ans/`:

```bash
python3 training/infer-sandbox.py \
  --adapter output/sandbox-adapter-fixed \
  --from-jsonl data/train-simple.jsonl --word gcd \
  | sed -n '/^:/,$p' > /tmp/gcd-gen.fs

# эталонный файл уже содержит T{ }T:
gforth tests/ans/gcd.fs -e bye
# для сгенерированного — только компиляция:
gforth /tmp/gcd-gen.fs -e bye
```

Hold-out **не** трогать для train; для финального вердикta — 2–3 слова из `eval_holdout` через Cursor/rules, не через этот adapter.

### Шаг 6 — записать в журнал

В [`TRAINING-RUNS.md`](TRAINING-RUNS.md):

```markdown
| 2026-05-31 | A final | Qwen2.5-Coder-0.5B | train-merged short system | N ep, loss X | gcd/factorial infer | output/sandbox-adapter-fixed/ |
```

---

## Как интерпретировать результат

| Исход | Вывод по Track A |
|-------|------------------|
| loss ↓, infer ≈ эталон gcd/factorial | 0.5B **может** зазубрить простые слова из train; hold-out всё равно проверить |
| loss ↓, infer форма Forth OK, но логика неверна | pipeline исправлен; потолок 0.5B / мало данных |
| loss ↓, infer всё ещё Python/markdown | даже с fix — 0.5B не тянет; **закрыть Track A**, Track B / rules |
| base и LoRA одинаково плохи | LoRA не добавляет; rules или 7B |

**Итог 2026-05-31:** pipeline OK; logic fail → **Track A закрыт, не ошибка** — см. [`TRACK-A-LESSONS.md`](TRACK-A-LESSONS.md), [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md).

**Критерий закрытия Track A:** после **этого** прогона вы документируете факт. Низкий loss на старых adapter **не считается**.

---

## Не путать с Ollama rules

| Режим | system |
|-------|--------|
| **SFT jsonl** | `TRAIN_SYSTEM_SHORT` (~3 строки) |
| **Ollama** `Modelfile.forth-qwen-core` | full rules (~560+ строк) — **runtime**, не train |

Rules в Ollama + большая модель — отдельный путь, не Track A LoRA.

---

## Быстрая справка

```bash
python3 scripts/validate-train-tokens.py data/train-merged.jsonl
bash training/run-track-a-final.sh
bash scripts/track-a-smoke-infer.sh output/sandbox-adapter-fixed
```

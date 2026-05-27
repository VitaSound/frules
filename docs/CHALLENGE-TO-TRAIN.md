# Challenges → training data (большая модель)

Как превратить решения челленджей в `train.jsonl`, **не ломая** честный eval.

## Главное

| Вопрос | Ответ |
|--------|--------|
| Нужно 500+ **решённых челленджей**? | **Нет.** Нужно **~100** проверенных решений для train-split + остальное из `tests/ans` / внешний Forth до **500+** всего. |
| Писать решение в `tests/challenges/*.fs`? | **Нет.** Файлы в каталоге остаются **пустыми** (hold-out). |
| Куда класть решения? | [`data/challenge-solutions/`](../data/challenge-solutions/) — копия файла **с кодом между маркерами**. |
| Что остаётся «вслепую»? | **eval_holdout** (~45): 6 seeds + ~39 bank — **никогда** в train. |

## Разбиение (уже в `eval-slices.yaml`)

| Срез | ~Файлов | Назначение |
|------|--------|------------|
| `train_for_sft` | **~100** | Большая модель решает → `challenge-train.jsonl` |
| `eval_holdout` | **~45** | Только оценка после обучения |
| `full` | 145 | Справочно |

Перегенерация срезов: `python3 scripts/gen_challenges.py` (поле `split` в `manifest.yaml`).

## Пошагово (новый чат, большая модель)

### 1. Установить frules

```bash
./install.sh . gforth
```

### 2. Взять список train (не holdout!)

```bash
# Только файлы для обучения (~100)
grep -A200 'train_for_sft:' tests/challenges/eval-slices.yaml | head -110
```

Или: все `001–139`, **кроме** списка `eval_holdout`.

### 3. Один челлендж = один новый чат

Промпт (подставить путь к файлу):

```
Build a verified Gforth solution for tests/challenges/NNN-slug.fs (training dataset, not blind eval).

- Implement ONLY the word named in the CHALLENGE header.
- Paste the definition(s) BETWEEN the two "=== paste your solution ===" lines.
- Stack-effect comment on every colon definition.
- Follow Style guard in the file header.
- You MAY read and reuse tests/ans/, tests/gforth/, examples/, data/challenge-solutions/, sources/theforth.net-packages/, similar .fs files.
- Verify spec and T{ }T; fix obvious errors in tests/challenges/ if needed (see AGENT-SOLVE-CHALLENGES.md).
```

Открыть `@tests/challenges/NNN-slug.fs` + правила frules.

### 4. Сохранить решение отдельно

```bash
cp tests/challenges/042-foo.fs data/challenge-solutions/042-foo.fs
# В challenge-solutions вставить код модели между маркерами (не коммитить в tests/challenges/)
```

### 5. Проверить gforth

```bash
cd tests/challenges
gforth ../../data/challenge-solutions/042-foo.fs
# Должно быть: TESTS OK
```

(Путь: скрипт ниже делает это из корня репо.)

### 6. Собрать JSONL

```bash
python3 scripts/build-challenge-dataset.py --validate
# -> data/challenge-train.jsonl  (только train_for_sft, только TESTS OK)
```

### 7. Объединить с остальным train

```bash
python3 scripts/build-dataset.py --out data/train-core.jsonl
cat data/train-core.jsonl data/challenge-train.jsonl > data/train.jsonl
wc -l data/train.jsonl   # цель >= 500
```

## Что попадает в JSONL

Пара «промпт → код»:

- **user:** заголовок CHALLENGE из файла (условие, stack effect, style guard)
- **assistant:** только тело между маркерами (ваше решение большой модели)
- **source:** `data/challenge-solutions/NNN-slug.fs`

Формат как в [`data/README.md`](../data/README.md).

## Eval после обучения

Только **`eval_holdout`** (и срезы `smoke` / `standard` / `stratified_20`).

Не гонять на файлах из `train_for_sft` — модель их уже видела в SFT (утечка).

## Ожидаемые объёмы

| Источник | Пар в train |
|----------|-------------|
| `tests/ans` + examples | ~40 сейчас |
| challenge-solutions (train split) | **~100** (по 1 слову на файл) |
| внешний Gforth | добить до **500+** |

100 challenge-пар + 400 из upstream/синтетики ≈ цель Track B.

## Автоматизация агента (по одной задаче)

Полный протокол (очередь → решение → тест → галочка → commit → push):

**[`docs/AGENT-SOLVE-CHALLENGES.md`](AGENT-SOLVE-CHALLENGES.md)** (English — full agent protocol)

Очередь: [`data/challenge-solutions/SOLVE-QUEUE.md`](../data/challenge-solutions/SOLVE-QUEUE.md)  
Следующий файл: `bash scripts/next-challenge-to-solve.sh`

Пакетный прогон через Ollama/API — отдельный скрипт (см. `TODO` в MODEL-TRAINING «run-challenge»). Для качества: **новый чат на файл** и правила выше.

## Чеклист

- [ ] Решены только файлы из `train_for_sft`
- [ ] Каждый файл: `TESTS OK` в `data/challenge-solutions/`
- [ ] `tests/challenges/*.fs` между маркерами **пустые**
- [ ] `build-challenge-dataset.py --validate` без warn
- [ ] `train.jsonl` ≥ 500 строк перед QLoRA
- [ ] Eval только на `eval_holdout`

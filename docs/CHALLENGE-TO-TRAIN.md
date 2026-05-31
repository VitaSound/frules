# Challenges → training data (большая модель)

Как превратить решения челленджей в `train.jsonl`, **не ломая** честный eval.

## Главное

| Вопрос | Ответ |
|--------|--------|
| Нужно 500+ **решённых челленджей**? | **Нет.** Нужно **~100** проверенных решений для train-split + остальное из `tests/ans` / внешний Forth до **500+** всего. |
| Писать решение в `tests/challenges/*.fs`? | **Нет.** Файлы в каталоге остаются **пустыми** (hold-out). |
| Куда класть решения? | [`data/challenge-solutions/`](../data/challenge-solutions/) — копия файла **с кодом между маркерами**. |
| Что остаётся «вслепую»? | **eval_holdout** (**53**): часть seeds + bank — **никогда** в train. |

## Разбиение (уже в `eval-slices.yaml`)

| Срез | Файлов | Назначение |
|------|--------|------------|
| `train_for_sft` | **98** | **Готово:** решения в `data/challenge-solutions/` → `challenge-train.jsonl` (не для слепого eval) |
| `eval_holdout` | **53** | Только оценка после обучения |
| `full` | **151** | Все seeds + bank (справочно) |

Перегенерация срезов: `python3 scripts/gen_challenges.py` (поле `split` в `manifest.yaml`).

## Пошагово (solve train — **завершено**)

Все **98** файла `train_for_sft` решены и отмечены в [`SOLVE-QUEUE.md`](../data/challenge-solutions/SOLVE-QUEUE.md). Ниже — **архив** процесса; для новых чатов используйте **eval_holdout** (валидация моделей), не train.

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
- You MAY read and reuse tests/ans/, tests/gforth/, examples/, data/challenge-solutions/, sources/theforth.net-packages/, sources/rosettacode-forth/, sources/brodie-thinking-forth/, sources/gforth-manual-tutorial/, sources/gforth-manual/, similar .fs files.
- Optional Rosetta hint: `python3 scripts/rosettacode-hint.py tests/challenges/NNN-slug.fs`
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

## Автоматизация агента (архив solve)

Фаза solve **закончена** (`next-challenge-to-solve.sh` → `QUEUE_EMPTY`).

**Архив протокола:** [`docs/AGENT-SOLVE-CHALLENGES.md`](AGENT-SOLVE-CHALLENGES.md) (English — отладка `T{ }T`, редкие правки train).

**Дальше:** валидация обученных моделей на **`eval_holdout`** (слепые `tests/challenges/`, без подглядывания в `data/challenge-solutions/` для hold-out slug). Пакетный прогон через Ollama/API — см. `TODO` в MODEL-TRAINING («run-challenge»).

## Чеклист

- [x] Решены только файлы из `train_for_sft` (**98/98**, [`SOLVE-QUEUE.md`](../data/challenge-solutions/SOLVE-QUEUE.md))
- [x] Каждый train-файл: `TESTS OK` в `data/challenge-solutions/`
- [x] `tests/challenges/*.fs` на train: между маркерами **пустые**
- [ ] `build-challenge-dataset.py --validate` без warn
- [ ] `train.jsonl` ≥ 500 строк перед QLoRA
- [ ] Eval только на `eval_holdout` (валидация моделей)

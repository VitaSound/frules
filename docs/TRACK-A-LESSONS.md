# Track A: 0.5B LoRA — не ошибка, эксперимент закрыт

**Статус:** Track A **закрыт** (2026-05-31). Переход к IR-pipeline + rules + Tier architecture.

Протокол прогона: [`TRACK-A-FINAL.md`](TRACK-A-FINAL.md). ML-термины: [`ML-GLOSSARY-FORTH.md`](ML-GLOSSARY-FORTH.md).

---

## Главный вывод

**0.5B LoRA на Forth postfix — не «ошибка выбора модели», а необходимый эксперимент**, который:

1. Выявил **баги data pipeline** (без этого любой размер модели давал бы ложные выводы).
2. Дал **честную нижнюю границу** — что LoRA на 0.5B **не** заменяет rules, transpiler, gforth.
3. **Снял FOMO** «надо было сразу 7B / Opus fine-tune» — без fix truncation мы бы учили rules, не Forth.

**Проехали дальше** — не возвращаться к «дожать 0.5B ещё 3 epoch».

---

## Что было сломано (и почему старые run невалидны)

| Баг | Следствие |
|-----|-----------|
| `system` = full rules (~4000 tok) + `MAX_SEQ=1024` | **Assistant (Forth) вне окна loss** — LoRA учила начало rules |
| Infer без `system`, другой user format | Train ≠ infer |
| Fake низкий loss на старых adapter | Иллюзия успеха |

После fix (`TRAIN_SYSTEM_SHORT`, `validate-train-tokens.py`, infer parity):

- `train_loss` ~**1.819** — честный, не 10⁻⁴.
- Infer gcd/factorial: **Forth-shaped, logic wrong** — gforth fail.

**Вывод pipeline:** исправлен. **Вывод ёмкости 0.5B:** алгоритмы Forth — не её задача.

---

## 0.5B — не ошибка: что мы **получили**

| Результат | Ценность |
|-----------|----------|
| `scripts/sft_prompts.py`, short system | Шаблон для Track B / любого SFT |
| `validate-train-tokens.py` | Guardrail против truncation |
| `build-train-merged.sh` + token checks | Reproducible datasets |
| `infer-sandbox.py --from-jsonl --system short` | Parity train/infer |
| `run-track-a-final.sh`, smoke scripts | One-command regression |
| Документация TRACK-A-FINAL, ML-GLOSSARY | База знаний для команды и статей |
| **Отрицательный результат** | Не тратить месяцы на 0.5B postfix |

Negative results in ML — **актив**, не провал.

---

## 0.5B — что **не** получили (и не ожидали после fix)

| Цель | Исход |
|------|-------|
| Надёжный gcd / factorial на infer | Fail logic |
| Hold-out generalization (53) | Вне scope 0.5B |
| Замена Opus + frules rules | Нет (~100× параметров) |
| Замена transpiler / stack-glue | Нет |

---

## Чем заменяем Track A (стратегия v2)

```text
Не:  LLM → Forth postfix → надеяться
Да:  LLM → IR → transpiler + stack-glue → Forth → gforth
     + frules rules (SYSTEM)
     + Opus Tier 3 только для architecture / hard IR
     + локальная модель Tier 1 для cheap loop
```

| Путь | Роль |
|------|------|
| **frules rules** | Runtime «шпаргалка» — сильнее 0.5B LoRA для стиля |
| **Transpiler** | 100% на нотации и stack между ops |
| **Track B 7B** (опционально) | IR→JSON, micro-SFT — **после** выбора IR |
| **RAG manual** | § Gforth по запросу — не hold-out |
| **Eval hold-out** | Метрика Opus+toolchain, не adapter |

---

## Track B — когда имеет смысл

**Не** «LoRA Forth algorithms on 7B» как главная ставка.

Track B оправдан, если:

- curriculum **короткий IR** (Lisp/JSON), не длинный `: word`;
- eval — **compile_ir → gforth**, не raw Forth от модели;
- сравнение с **rules-only baseline** (Gemma + frules core).

См. [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md), [`MODEL-TRAINING.md`](MODEL-TRAINING.md).

---

## Для статей и публичности

Формулировка для dev.to / коллег:

> We fine-tuned Qwen2.5-Coder-0.5B on Forth. The pipeline was broken; we fixed it. The honest run still failed on logic. **That was the point.** Forth automation needs rules + a deterministic backend, not a smaller LLM pretending to be a compiler.

RU: *0.5B — не ошибка; ошибка была бы продолжать верить в postfix-LoRA после честного fail.*

---

## См. также

- [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md)
- [`NOTATION-AND-TRANSPILER.md`](NOTATION-AND-TRANSPILER.md)
- [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md)

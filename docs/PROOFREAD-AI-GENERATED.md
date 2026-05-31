# Выборочная вычитка AI-generated контента

Чеклист для **человека** (Alexey): что проверить в frules после интensive-сессии с Cursor/Opus.  
Автоматическая ревизия: **2026-05-31** — см. раздел «Уже найдено».

Hub: [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md).

---

## Канонические цифры (не путать)

Источник истины: [`tests/challenges/eval-slices.yaml`](../tests/challenges/eval-slices.yaml), [`tests/challenges/INDEX.md`](../tests/challenges/INDEX.md).

| Что | Число |
|-----|------:|
| **Всего** челленджей | **151** (6 seeds + 145 bank) |
| **train_for_sft** (gold в `data/challenge-solutions/`) | **98** |
| **eval_holdout** (слепой eval, stubs пустые) | **53** |
| Bank size | 145 (`001`–`145`) |

**Частая ошибка ИИ:** «145 hold-out» или «94 train» — **устарело**.

---

## Приоритеты вычитки

### P0 — факты и цифры (быстро, grep)

- [x] `94/94` → **98/98** — TODO, MODEL-TRAINING, CHALLENGE-TO-TRAIN, AGENT-SOLVE (2026-05-31)
- [x] «145 hold-out» в README / MODEL-TRAINING — → **53** hold-out, **151** total
- [x] `131 total`, `125 bank` в TODO — исправлено
- [ ] Прогнать `rg` ещё раз — CHANGELOG, stray `~45`
- [ ] `eval-slices.yaml` vs текст docs — сверить вручную

**Команда:**

```bash
rg '94/94|145 hold|131 total|125 bank|139 bank|~45|~94' --glob '*.md'
```

### P1 — docs сессии 2026-05-31 (смысл + стиль RU)

Файлы: `AI-KNOWLEDGE-INDEX`, `TRACK-A-LESSONS`, `NOTATION-AND-TRANSPILER`, `MULTI-AGENT-ARCHITECTURE`, `ROADMAP-AI-PLATFORM`, `EXTERNAL-LLM-ARCHITECTURE`, `AI-VS-TOOLS`.

- [ ] Тезисы совпадают с твоим опытом (Opus cost, Track A, IR)?
- [ ] Нет лишнего «нейросетевого пафоса»
- [ ] Опечатки: ~~эксперiment~~ → **эксперимент**, ~~Арtefact~~ → **Артефакт**
- [ ] Ссылки на sibling repos (fmix, fhdlgen) — URL актуальны
- [ ] Hardware: KU5P primary, x480t secondary — верно

### P2 — `data/challenge-solutions/*.fs` (98 файлов)

**Не вычитывать все подряд.** Выборка по риску:

| Риск | Файлы (пример) | Что смотреть |
|------|----------------|--------------|
| Segfault / blocked history | `020`, `014`–`016` | `gforth`, утечки стека |
| AI + ручной fix | `072` word-ladder, `135` LRU | коммиты `Fix …` |
| Trie / DFS | `109`, `110`, `111` | return stack, `>r` |
| DP hard | `133`, `134`, `135` | T{ }T, edge cases |
| Rosetta new | `140`–`145` | стиль vs bank |

```bash
# прогнать выборку
for f in 020-first-missing-pos.fs 072-word-ladder-len.fs 135-lru-get.fs 133-knapsack01.fs; do
  echo "=== $f ==="
  gforth "data/challenge-solutions/$f" -e bye
done
```

- [ ] Stack effects в комментариях правдивы
- [ ] Нет `pick`/`roll` без необходимости (rules)
- [ ] Имена слов = CHALLENGE header

### P3 — `rules/*.mdc` (distill from AI)

- [ ] English-only (`tests/lint.sh`)
- [ ] Примеры компилируют (`./test.sh`)
- [ ] Нет выдуманных Gforth-слов — сверка с manual
- [ ] Выборочно: `forth-stack`, `forth-control`, `forth-strings` (где было больше AI)

### P4 — training / jsonl

- [ ] `validate-train-tokens.py` на всех train jsonl — OK
- [ ] Не коммитить adapter weights случайно (`output/` в .gitignore?)
- [ ] TRAINING-RUNS.md — даты и loss правдивы

### P5 — не трогать без нужды

- `sources/gforth-manual/` — vendored HTML
- `sources/rosettacode-forth/` — upstream mirror
- `Modelfile.*` — автоген из rules

---

## Уже найдено (авто-ревизия 2026-05-31)

| Проблема | Где | Действие |
|----------|-----|----------|
| `94/94` train | TODO, MODEL-TRAINING, CHALLENGE-TO-TRAIN, AGENT-SOLVE | **исправлено** → 98/98 |
| «145 hold-out» | README, MODEL-TRAINING | **исправлено** → 53 / 151 |
| `~45` hold-out | CHALLENGE-TO-TRAIN | **исправлено** → 53 |
| `131 total`, `125 bank` | TODO | **исправлено** |
| `эксперiment` | TRACK-A-*, AI-KNOWLEDGE-INDEX, ML-GLOSSARY | **исправлено** → эксперимент |
| `Арtefact` | ROADMAP-AI-PLATFORM | **исправлено** → Артефакт |
| BENCHMARK-SIZING «145 = hold-out only» | устарела концепция | **обновлено** header |
| CHANGELOG «145 hold-out» | историческая запись | вычитать при релизе |

---

## Ритм (чтобы не выгореть)

1. **День 1 (30 мин):** P0 grep + fix цифр — один коммит `docs: fix challenge counts`.
2. **День 2 (1 ч):** P1 — прочитать hub + ROADMAP вслух, карандашом.
3. **По вечерам:** P2 — по 5 challenge solutions + `gforth`.
4. **Потом:** P3 rules — только файлы, которые цитируешь в статьях.

Воскресенье — **можно не начинать**. Достаточно P0 в понедельник-вторник.

---

## После вычитки

- [ ] Одна строка в CHANGELOG
- [ ] `docs/BENCHMARK-SIZING.md` привести к 151/98/53
- [ ] Статья frules (dev.to) — только после P0+P1

---

## См. также

- [`DOC-AUTHORSHIP.md`](DOC-AUTHORSHIP.md) — что AI-assisted, что human-directed
- [`CHALLENGE-TO-TRAIN.md`](CHALLENGE-TO-TRAIN.md) — train vs hold-out

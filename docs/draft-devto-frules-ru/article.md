# Forth заставил поскрипеть шестерёнки нейросетей (и мой Cursor-счёт). Fail недели и frules

*Часть 2 после [fmix — package manager for Forth (EN)](https://dev.to/ua3mqj/fmix-a-package-manager-for-forth-37ld). Postfix, gforth и честный eval вместо «ещё одного LoRA».*

---

У Python есть Copilot. У Forth — нет. Я проверил это на Cursor Opus, LoRA 0.5B и **gforth** как судье. Forth — **крепкий орешек** для нейросетей: топовые модели что-то выдают, но долго, мучительно, и чаще не то. Forth заставил **как следует поскрипеть железные шестерёнки** — и кошелёк тоже. Это не история «Forth победил AI». Это история о postfix, стеке и отсутствии Copilot: Agent на полных оборотах, а на выходе — **frules**: rules, 151 challenge и честный eval.

Я удивился: программировать на Forth сети почти не умеют. Хорошо, что к этому моменту уже была библиотека тестов — можно попросить модель **запускать gforth**, а не «верить на слово». Полез в интернет: какие домашние модели вообще учили Forth — ничего внятного не нашёл.

Ну я-то думал иначе. Но об этом — ниже, в Track A.

---

## Что такое frules (punchline, не реклама)

**[frules](https://github.com/VitaSound/frules)** — не «ещё один prompt для ChatGPT». Это:

- **rules** (`.mdc`) — дистилляция Gforth manual, Brodie, Rosetta, theForthNet;
- **eval** — **151** challenge (**98** train / **53** hold-out blind);
- **gforth** — судья: каждый gold solution помечен `TESTS OK`.

Установка в свой проект:

```bash
./install.sh . gforth
```

Cursor подхватывает rules из `.cursor/rules/`; для Ollama — SYSTEM через Modelfile ([OLLAMA-FRULES.md](https://github.com/VitaSound/frules/blob/main/docs/OLLAMA-FRULES.md)).

frules — **база знаний**, как строить ИИ-содержащие решения для Forth ([AI-KNOWLEDGE-INDEX.md](https://github.com/VitaSound/frules/blob/main/docs/AI-KNOWLEDGE-INDEX.md)). Fail-story на dev.to — про то, **зачем** она вообще понадобилась.

Если вы не пишете на Forth — смысл тот же: **eval culture** вместо «модель сказала ок». 151 задача — не vanity metric; каждая с gold solution и `T{ }T`. Train **98** — то, на чем калибруем rules и workflow. Hold-out **53** — слепой экзамен: не смотрим gold, пока не готовим публикацию метрик. Смешать slices — классическая ошибка ML-петли «подогнали под тест».

В прошлом спринте для экосистемы VitaSound уже собрались **flint** и **fcov**; в этом — ещё и *Thinking Forth* Brodie: из TeX в markdown (`sources/brodie-thinking-forth/`), дистилляция в rules. Цифры побочного toolchain — в § ниже.

---

## Fail → R&D → активы

Схема всей недели:

```text
Fail (Track A, Opus-loop) ──► R&D ──► понял / узнал / вывод
                                      │
                                      ├── f* toolchain (flint, fcov, …)
                                      ├── docs + rules + датасет
                                      └── локальный «завод» (§ в конце)
```

Negative result — не ноль, если задокументирован ([CHANGELOG.md](https://github.com/VitaSound/frules/blob/main/docs/CHANGELOG.md)).

### Хронология (без git log на полстраницы)

| Этап | Суть |
|------|------|
| Rules | Manual, Brodie, Rosetta → `rules/*.mdc` |
| Brodie → markdown | *Thinking Forth* → `sources/brodie-thinking-forth/chapter*.md` через `extract.sh`; дистилляция в `forth-factoring`, `forth-style`, … |
| Challenge bank | **151** задача, split **98** / **53** ([eval-slices.yaml](https://github.com/VitaSound/frules/blob/main/tests/challenges/eval-slices.yaml)) |
| Solve sprint | 29 мая — **98/98** train, каждый `TESTS OK` через gforth |
| Track A | LoRA 0.5B — pipeline баг → fix → честный fail → **закрыт** |
| Docs | Tier 0–3, IR-pipeline ([ROADMAP-AI-PLATFORM.md](https://github.com/VitaSound/frules/blob/main/docs/ROADMAP-AI-PLATFORM.md)) |

Hold-out **53** — экзамен. Train **98** — учебник. Смешать — самообман.

### Побочные продукты (May sprint)

Пока копал eval, экосистема VitaSound собралась снизу. Цифры из CHANGELOG, порядок величины:

| Repo | Период | Версии | Одной строкой | Код* |
|------|--------|--------|---------------|------|
| **fmix** | 2024 → 24.05 | 0.7.x | Part 1 на dev.to; package manager | ~1.2k LOC `.4th` |
| **fsemver** | 24.05, 1 день | 0.1.x | Semver-движок из fmix/flint | ~360 LOC |
| **fcov** | 24.05, 1 день | 0.1→**0.3** | Coverage: console/JSON/LCOV/HTML | ~2.8k LOC |
| **flint** | 24.05, 1 день | 0.1→**0.2.2** | Lint дубликатов `: word` | ~825 LOC |
| **fenum** | 22.05 | 0.1.x | `ulist` для flint/fcov | ~750 LOC |
| **fhdlgen** | 20–24.05 | 0.3.1 | DSL→Verilog (teaser части 3) | ~2k LOC |
| **frules** | 25–31.05 | 0.1.x | 151/98/53, Track A closed, docs hub | gold ~6.5k; rules ~2.1k md |

\*LOC без `forth-packages/` — не аудит, для масштаба.

**24 мая** — flint, fcov, fsemver за один день: когда eval culture уже есть, quality tools рождаются быстро. **frules** — ещё шесть дней: challenge bank, gold, честный Track A, hub доков. Это не «планировали экосистему» — это **побочный эффект** того, что gforth каждый вечер говорил PASS или FAIL, а не «выглядит нормально».

Обычно меня душит жаба, когда трачу на облако. Здесь — нет: ни денег, ни бессонных ночей не жалею. Слишком много осознанного за шесть дней.

**Понял:** postfix + stack — не для «голой» генерации. **Узнал:** LoRA ≠ RAG ≠ rules. **Вывод:** LLM → IR; tools → Forth; gforth → судья.

---

## Пять стадий принятия ИИ (адаптация)

| Стадия | У меня |
|--------|--------|
| **Отрицание** | «20 лет в IT, Cursor не нужен» |
| **Гнев** | Счёт Opus, `WRONG NUMBER OF RESULTS`, segfault в generated Forth |
| **Торг** | «Ладно, только autocomplete» → Agent на весь репо |
| **Депрессия** | «Сжёг бюджет, 0.5B всё равно тупит» |
| **Принятие** | ИИ — инструмент; роль — **не** postfix-компилятор |

**Vibe coding:** до — гамак и «промпт готов»; после — Agent, десятки итераций, `WRONG NUMBER OF RESULTS`, commit в 03:11. Forth без судьи (тестов) — лотерея; на Python та же галлюцинация маскируется дольше. **gforth не врёт**: либо `TESTS OK`, либо конкретная ошибка — и ты знаешь, что чинить.

![Cursor billing / Opus invoice — on-demand ~$102, thinking-xhigh. Замазать личное.](images/cursor-invoice.png)

*Шестерёнки скрипят — в буквальном смысле счёта.*

---

## Словарь: «сети учат по-разному»

Наивная картина: скормил Brodie + manual + jsonl → модель **программирует**. Реальность: **несколько разных рычагов**, и LoRA — только один.

| Способ | Что меняется |
|--------|--------------|
| **Pretrain** | Веса на терабайтах — не наш путь; Forth ≈ 0% в pretrain |
| **SFT / Instruct** | Уже внутри Qwen-Instruct |
| **LoRA** | Adapter на jsonl — **Track A**, закрыт |
| **RAG** | **Не веса** — индекс, chunk, top-k в prompt |
| **Rules (frules)** | Static SYSTEM — сильнее 0.5B LoRA для **стиля** |
| **Tools / IR** | Transpiler + gforth — не ML |

```text
         pretrain (не мы)
              ↓
    instruct-модель (уже есть)
         ↙    ↓    ↘
     LoRA   RAG   rules
         ↘    ↓    ↙
      IR + transpiler + gforth
```

**LoRA** — доучить **веса**. **RAG** — «обучить» **поиск** (индекс, не gradient). **Rules** — вообще без весов.

> RAG съел контекст в Cursor — потому что к запросу **добавились** KB-куски. frules rules — то же семейство «добавить к словам», но статически.

Подробнее: [ML-GLOSSARY-FORTH.md](https://github.com/VitaSound/frules/blob/main/docs/ML-GLOSSARY-FORTH.md).

---

## Postfix, псевдокод и «из пушки по воробьям»

Forth — **лупа**: на нём видно то, что в Python маскирует Copilot.

### Почему ОПН чужда LLM «пишущим напрямую»

| | LLM |
|--|-----|
| Pretrain | Infix, Python, JS, C |
| Генерация | Слева направо — **имитация**, не исполнение стека |
| Thinking | Перебор без stack machine → `WRONG NUMBER OF RESULTS` |
| Track A | Forth-**форма**, **логика fail** |

Задача `(a+b)*c`. LLM в Forth: `: foo … rot rot dup … ;` — форма есть, `T{ }T` падает. Это не «Forth сложный» — **не та работа** для генератора текста.

Пример из challenge bank — word ladder, BFS. Agent выдал что-то вроде:

```forth
: seen? ( addr u -- flag ) 2dup rot rot over = ;
```

`gforth` отвечает не «syntax error», а **`WRONG NUMBER OF RESULTS`**: стек после `: seen?` не совпадает с `( -- flag )`. Agent видит fail, добавляет ещё `rot`, thinking-xhigh крутится снова — invoice растёт, алгоритм не меняется.

### Целевой Forth напрямую — ошибка

| Задача | Кто |
|--------|-----|
| Алгоритм, trade-offs | LLM / architect |
| `dup swap rot`, баланс стека | **Transpiler + stack-glue** |
| Имена, факторинг | LLM + frules + **flint** |
| Правильность | **gforth** |

Три антипаттерна, которые я наступил:

1. «Пусть Opus напишет весь `: word`» — overkill + invoice (F3).
2. «LoRA научит postfix» — закрыто Track A (F2).
3. Ждать от 0.5B «завода» (F5).

**Из пушки по воробьям** — reasoning-tokens там, где хватит parser + симулятора стека.

### Решение: IR → transpiler → Forth

```text
ТЗ ──► LLM ──► IR (Lisp / JSON / псевдокод)
                    │
                    ▼
              transpiler + stack-glue
                    │
                    ▼
              .fs ──► gforth ──► PASS | FAIL
                    │
                    └── FAIL logic ──► правим IR, не rot
```

![IR vs Forth напрямую: две колонки ❌ LLM→.fs vs ✓ LLM→IR→tools→gforth](images/ir-vs-forth.svg)

На FAIL — «исправь алгоритм в IR», не «Agent, перепиши Forth». IR может быть Lisp-подобным: `(loop (while queue) (if (not seen? word) …))` — transpiler сам расставит `begin … while … repeat`, locals, `( -- )`.

**Голая нейросеть не программирует.** Программирует **система**: LLM(и) + transpiler + gforth + flint/fcov + человек. Монолит «AGI напишет всё» — маркетинг; **завод с инспекцией** — инженерия.

[NOTATION-AND-TRANSPILER.md](https://github.com/VitaSound/frules/blob/main/docs/NOTATION-AND-TRANSPILER.md)

---

## Cursor: «внутренний диалог» — это сервис

У модели один примитив: **вопрос → ответ**. Никакого «второго Я» в weights нет. То, что в UI выглядит как Agent с «размышлениями», — **Cursor** под капотом: несколько скрытых Q→A, пока вы не остановили. Откройте invoice: десятки строк `thinking` по $0.05–0.15 — это не глубина души модели, а **оплаченные дополнительные ходы** того же чата. Aha-moment для меня: «диалог» — продуктовая упаковка loop, не новая сущность.

Вывод: loops можно проектировать **самому** — но со **static tools** внутри (gforth, transpiler), не только LLM.

```text
User → Cursor → [Q1→A1→Q2→A2] → gforth → PASS|FAIL
```

![Схема Cursor loop](images/cursor-loop.svg)

[MULTI-AGENT-ARCHITECTURE.md](https://github.com/VitaSound/frules/blob/main/docs/MULTI-AGENT-ARCHITECTURE.md)

---

## Завод вместо монолита

```text
Human (ТЗ, guardrails)
    → Architect LLM (алгоритм, IR)
    → Coder LLM (Lisp/JSON/псевдокод)
    → Static tools (transpiler, stack-glue, flint)
    → gforth (TESTS OK)
    → FAIL → architect; PASS → human
```

Дома одна «моно» 0.5B «тупит» — потому что ждали **завод**, а запустили **стажёра**.

Tier 0–3: [EXTERNAL-LLM-ARCHITECTURE.md](https://github.com/VitaSound/frules/blob/main/docs/EXTERNAL-LLM-ARCHITECTURE.md)

![Factory pipeline](images/factory.svg)

---

## Track A — главный fail недели

> Ну я-то думал: скормлю нейронке **всё**, что найду по Forth — и она начнёт программировать.

Скормили: `sources/`, rules, `train-merged.jsonl`, **98** gold solutions. Pipeline починили. На infer — Forth-форма, gcd **fail**. Условно **«пук»** — один раз, по-разговорному: шум вместо инженерии.

Track A = рычаг **LoRA**; параллельно понял про **RAG**, **rules**, pretrain — не одна кнопка.

### F1 — fake loss

**Fail:** В первых прогонах loss падал красиво — почти как в tutorial. Я поверил. На infer — не Forth: **рандомные слова**, повторённые куски, вообще не похоже на код. Потом выяснилось: `system` = full frules rules (~**4000** tok), а `MAX_SEQ=1024`. В окно loss попадало **начало rules**, не assistant с Forth. LoRA буквально **зазубрила шпаргалку**, а не gcd.

**Learn:** fake loss хуже честного ~1.8. Смотреть не на красоту графика, а на **что** внутри окна. Запустить `validate-train-tokens.py` до каждого train.

**Built:** `TRAIN_SYSTEM_SHORT` (~50 tok), guardrails в `build-train-merged.sh`, infer parity (`--system short`, `--from-jsonl`).

### F2 — честный fail

**Fail:** Починили pipeline. `train_loss` ~**1.819** — честный. Infer на gcd — уже **похоже на Forth**: двоеточия, `( -- )`, `begin`/`while`. **gforth** — нет. Логика wrong. Оболочка без семантики стека.

Пример (сокращённо, long-adapter smoke; полный лог — [`README.md`](https://github.com/VitaSound/frules#выводы-после-sandbox-adapter-long-infer-май-2026)):

```forth
: help-gcd
: flush
: factor
  return.
  b a r
-- Gforth only -- g d1 d2
```

Эталон из train для контраста: `: gcd  ( a b -- g )  begin dup while tuck mod repeat drop ;`

**Learn:** 0.5B QLoRA — не postfix-компилятор и не замена rules. Negative result в ML — **актив** ([TRACK-A-LESSONS.md](https://github.com/VitaSound/frules/blob/main/docs/TRACK-A-LESSONS.md)). Track A **закрыт** — не «ещё 3 epoch».

**Built:** документация эксперимента, smoke scripts, путь forward = IR + tools, not weights.

*Мы починили pipeline. Модель всё равно fail. В этом и был смысл.*

### F3 — Opus и стек

**Fail:** Пока jsonl не давал логику, я отдал postfix **Opus** в Agent mode. Word ladder, BFS, стек. Agent крутит `rot`, `swap`, thinking-xhigh, переписывает `: word` снова. **gforth**: `WRONG NUMBER OF RESULTS`. Деньги текут рекой: закидываю счёт, читаю новости — гиганты IT получили такие же огромные счета при скромном результате и вводят лимиты. Приятно чувствовать себя **мейнстримом**, хоть и больно. On-demand за май — порядка **$100+** (invoice выше). **Tier 0 tools** дешевле loop.

**Learn:** LLM вместо transpiler — **из пушки по воробьям**.

**Built:** Tier model, IR-pipeline, cost gate — Opus только escalation.

### F6 — gforth как судья

**Fail:** Не драма и не segfault-ужасы — я спокойно воспринимал каждый fail **gforth**. Самый частый удар — не «модель глупая», а **`WRONG NUMBER OF RESULTS`**: стек после `: word` не сходится с `( -- )`, Agent добавляет ещё `rot`, счёт растёт, алгоритм тот же.

**Learn:** **gforth** — не линтер, а **исполнитель с тестами**. PASS/FAIL измерим; без этого Forth в Agent-режиме — лотерея. Человек после Agent — не vanity, а gate перед commit.

**Built:** frules gold с `TESTS OK` на каждый train; `eval_holdout` blind на 53; docs про stack depth ([AGENT-SOLVE-CHALLENGES.md](https://github.com/VitaSound/frules/blob/main/docs/AGENT-SOLVE-CHALLENGES.md) §5b).

### Ещё грабли недели (коротко)

| | |
|--|--|
| **F4 RAG** | Прикрутил RAG к Cursor — «пук-среньк», токены кончились; коллега предупреждал |
| **F5 mono 0.5B** | Ждали **завод** — получили **стажёра** (одна 0.5B не тянет конвейер) |
| **F7 траты** | Потратился «немножечко»; активы §3 и честный Track A перевешивают |

[TRACK-A-FINAL.md](https://github.com/VitaSound/frules/blob/main/docs/TRACK-A-FINAL.md)

---

## Роль инженера

ИИ — черновик. **Я** — architect, verifier, product owner. Git log: word-ladder BFS, seen-table segfault, LRU warnings — **человек после Agent**.

20 лет опыта = eval culture **до** модели. Без gforth frules был бы «красивый markdown»; с gforth — **измеримость**. Hold-out **53** не трогаем при настройке rules — иначе экзамен превращается в шпаргалку.

Opus — Tier 3 escalation, не default transpiler. Когда IR уже есть, а нужен refactor имен — да. Когда нужен BFS с нуля — architect + transpiler, не Agent на `rot`.

---

## Что дальше: локальный завод

Не «ещё одна LoRA», а **конвейер дома** (WSL / home lab):

```text
База знаний (sources, rules, manual chunks)
        │  ← scripts: chunk, индекс, RAG v0, denylist hold-out
        ▼
LLM (Ollama / иногда облако) → IR / псевдокод
        ▼
Transpiler + stack-glue → .fs
        ▼
fmix test · flint · fcov · gforth    ← уже есть
        ▼
commit / hold-out eval
```

| Направление | План | Уже есть |
|-------------|------|----------|
| KB локально | `build-rag-index.py`, chunk manual | sources, rules |
| Lint/test/cov | Единый прогон | flint, fmix, fcov |
| Псевдокод→Forth | **wasm-to-forth** первым (Phase 1), lisp-to-forth следом | Phase 1 TODO |
| Orchestration | MCP `compile_ir → run_gforth` | sketch в docs |
| HDL | fhdlgen, KU5P | часть 3 серии |

Вероятно, соберу **scripts**, которые **локально** крутят базу знаний — не «магия RAG в облаке», а свой конвейер. Chunk manual → индекс → top-k с denylist hold-out id. LLM в Ollama для IR — cents, не dollars. Transpiler и gforth — ноль tokens. Opus остаётся для эскалации, когда IR застрял на архитектуре, а не когда забыл `swap`.

Это и есть «локальный завод»: не один монолитный LLM, а **линия** с инспекцией на каждом этапе. WSL + home lab достаточно; облако — опция, не зависимость.

`./install.sh . gforth` — star [frules](https://github.com/VitaSound/frules).

---

## Вместо эпилога

Fail недели — **актив**, если в CHANGELOG. frules — open-source ответ на ошибки, не триумф.

Forth + AI = **toolchain с судьёй**, не «научить postfix». **Дальше** — локальный завод: scripts, transpiler, flint/fcov/gforth.

Задокументировали фейлы, закрыли Track A, выложили frules — «научились не делать» LoRA на postfix и Opus-loop на `rot`. Индустрия всё равно продаёт «одна модель напишет всё».

![«После прочтения сжечь» — Palmer. Финал поста.](images/palmer-burn-after-reading.png)

> — Чему мы научились, Палмер?  
> — Мы научились **этого не делать**.  
> — Да, сэр.  
> — Понять бы ещё **чего** не делать…  
> — Да, сэр.  
> — Чёрт возьми, это какая-то фигня.

---

## Источники

**VitaSound:** [frules](https://github.com/VitaSound/frules) · [fmix](https://github.com/VitaSound/fmix) · [flint](https://github.com/VitaSound/flint) · [fcov](https://github.com/VitaSound/fcov) · [fsemver](https://github.com/VitaSound/fsemver) · [fhdlgen](https://github.com/VitaSound/fhdlgen)

**Docs frules:** [AI-KNOWLEDGE-INDEX](https://github.com/VitaSound/frules/blob/main/docs/AI-KNOWLEDGE-INDEX.md) · [TRACK-A-LESSONS](https://github.com/VitaSound/frules/blob/main/docs/TRACK-A-LESSONS.md) · [NOTATION-AND-TRANSPILER](https://github.com/VitaSound/frules/blob/main/docs/NOTATION-AND-TRANSPILER.md) · [ROADMAP-AI-PLATFORM](https://github.com/VitaSound/frules/blob/main/docs/ROADMAP-AI-PLATFORM.md)

**Forth:** [Gforth manual](https://gforth.org/manual/) · [Thinking Forth / Brodie](https://www.forth.com/thinking-forth/)

**ML:** [Qwen2.5-Coder-0.5B](https://huggingface.co/Qwen/Qwen2.5-Coder-0.5B-Instruct) · [Unsloth](https://github.com/unslothai/unsloth) · [Cursor](https://cursor.com) · [Ollama](https://ollama.com)

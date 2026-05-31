# ИИ vs статические инструменты (frules + VitaSound)

Куда в вашей экосистеме отдавать **LLM** (Cursor, Ollama, Gemma 4 + frules), а где — **детерминированный код** (transpiler, stack-glue, gforth, fmix, fhdlgen).

Связано: [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md) (**Opus / облачный LLM как оркестратор, tier model, MCP, cost gate**), [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md) (**hub базы знаний**), [`TODO.md`](../TODO.md), [`ML-GLOSSARY-FORTH.md`](ML-GLOSSARY-FORTH.md), [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md), [`CHALLENGE-TO-TRAIN.md`](CHALLENGE-TO-TRAIN.md).

---

## Правило одной строкой

| LLM | Статический инструмент |
|-----|------------------------|
| Неоднозначная постановка, выбор алгоритма, домен (железо, протокол) | Фиксированная грамматика, stack effects, синтаксис, проверка |
| «Что сделать?» | «Перевести A → B без ошибки» |
| Черновик + итерация с человеком | **Судья:** `gforth`, `T{ }T`, golden `.v`, flint |

**Гибрид (рекомендуется):** LLM → IR (Lisp / mini-C / WASM text) → **transpiler + stack-glue** → Forth → **gforth**.

---

## Таблица задач продукта

| # | Задача | ИИ (LLM + frules) | Статический инструмент | Гибрид |
|---|--------|-------------------|------------------------|--------|
| 1 | Понять ТЗ: «антидребезг кнопки», «LRU кэш», «конечный автомат» | **Да** — формулировка, выбор паттерна, edge cases | — | IR-схема от LLM, код — transpiler |
| 2 | Выбор слов и факторинг `: word` под Gforth/frules | **Да** — с `./install.sh . gforth` (rules) | `flint` — дубликаты имён | LLM черновик → flint → правки |
| 3 | **Postfix / порядок стека** между известными ops | Слабо / ненадёжно | **stack-glue** (симуляция + `dup swap rot …`) | LLM даёт список ops → glue → Forth |
| 4 | Infix → RPN (`(a+b)*c` → `a b + c *`) | Иногда с thinking | **Transpiler** (AST, shunting-yard, обход Lisp) | LLM → S-expr → обход |
| 5 | Lisp / JSON AST → Forth | LLM может нарисовать дерево | **Post-order emit** — 100% | **Лучший путь для алгоритмов** |
| 6 | WASM text / стековый IR → Forth | LLM хорошо пишет `.wat` | Таблица замены инструкций | LLM → WASM → mapper |
| 7 | Python subset → Forth | LLM пишет Python | `ast.parse` → codegen | LLM → Python → ast backend |
| 8 | Решить **train** challenge (98, gold в `challenge-solutions/`) | **Да** — Cursor + rules; можно RAG по похожим | `gforth`, `./test.sh`, `fmix test` | ИИ + обязательный gforth |
| 9 | **Hold-out** eval (53, `eval_holdout`) | **Да** — но **без** gold/RAG по slug | **gforth** — единственный судья | метрика только TESTS OK |
| 10 | Smoke / regression (6 seeds, 12 smoke) | Да, быстрая проверка модели | `verify_challenges.sh`, gforth | A/B rules on/off |
| 11 | HDL: модули, порты, Verilog (`fhdlgen`) | **Да** — DSL/API черновик, `AGENTS.md` | **fhdlgen** IR + emit, golden `.v` | LLM → fhdlgen API → emit |
| 12 | Старый `fhdl build` (.4th DSL) | Подсказки по DSL | `fhdl build` → `.v` | постепенно → fhdlgen |
| 13 | Lint дерева `.4th` | Нет | **flint** | — |
| 14 | Coverage после тестов | Нет | **fcov** | — |
| 15 | Пакеты, deps, CI test | Нет | **fmix** `packages.get`, `test` | — |
| 16 | Semver tooling | Нет | **fsemver** | — |
| 17 | Контейнеры / enum dispatch (`fenum`) | Редко — объяснение API | **fenum** библиотека | — |
| 18 | Справка Gforth manual (§ struct, exception) | Короткий ответ | **RAG** по `sources/gforth-manual/` | core rules в SYSTEM + RAG § |
| 19 | Стиль, anti-patterns, stack-effect комментарии | **rules** в SYSTEM (не train) | — | — |
| 20 | LoRA / своя 0.5B–7B Forth | Эксперiment (Track A закрыт) | jsonl, validate-tokens, gforth | не замена rules |
| 21 | Локальный чат без API | **Gemma 4 e4b** + frules SYSTEM; `thinking` на algo | Ollama, Modelfile | — |
| 22 | Веб-страница / UI (не Forth) | Gemma/Qwen сильны | — | вне scope Forth toolchain |
| 23 | Дистилляция источников → `rules/*.mdc` | **Да** — `DISTILL-PROMPT`, человек ревью | git, `./test.sh` | человек в контуре |
| 24 | RAG: «похожий challenge / § manual» | retrieve top-k | chunker, embed, **exclude hold-out** | inject в prompt |
| 25 | Merge LoRA → GGUF → Ollama | Нет | `merge-sandbox.py`, Modelfile | — |

---

## По типу входа: куда что

| Вход | Предпочтительно |
|------|-----------------|
| Естественный язык (RU/EN) | **ИИ** → IR или черновик Forth |
| Lisp S-expr / JSON AST | **Статический** emit; ИИ только генерирует IR |
| Infix / псевдокод C | **Статический** parser; ИИ — если parser не покрывает |
| WASM text | **Статический** mapper; ИИ — генерация `.wat` |
| Уже Forth с ошибкой стека | **ИИ** + rules + `.s`; glue — если IR известен |
| Verilog структура | **fhdlgen**; ИИ — заполнение IR |
| «Как в manual» | **RAG** или rules |

---

## Челленджи: train vs hold-out (151)

| | Train `train_for_sft` (98) | Hold-out `eval_holdout` (53) |
|--|---------------------------|------------------------------|
| Gold | `data/challenge-solutions/` | **нет** (пустые stubs) |
| ИИ + rules | решать, учиться, RAG по pattern | **только eval** |
| LoRA / RAG index | можно | **нельзя** |
| Судья | gforth | gforth |

---

## Рекомендуемый pipeline продукта (v1)

```text
User intent
    → LLM (Cursor / Gemma + frules core SYSTEM)
    → IR: Lisp или mini-C  [ИИ]
    → lisp-to-forth / ast-to-forth  [статика]
    → stack-glue (если линейные ops)  [статика]
    → : word … ;  [Forth]
    → gforth + T{ }T / fmix test  [статика]
    → flint / fcov  [статика]
```

Для **fhdlgen** — заменить последние шаги на `fhdlgen run-tests` и golden `.v`.

---

## Что не отдавать ИИ

- Финальный postfix между ops с гарантией баланса стека → **stack-glue**
- Infix/RPN/AST walk → **transpiler**
- Компиляция и TESTS OK → **gforth**
- Duplicate words → **flint**
- Emit Verilog → **fhdlgen**
- Hold-out «успех» без gforth → **запрещено** (самообман)

---

## Следующие шаги (из TODO)

1. Архитектура Tier 0–3 и MCP — [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md)
2. Gemma 4 + frules — hold-out smoke (`LOCAL-GEMMA-BENCHMARK.md`)
3. Прототип `lisp-to-forth` + stack-glue на `tests/ans/gcd.fs`
4. RAG v0 — только manual, **без** hold-out
5. fhdlgen — LLM заполняет IR, emit статический

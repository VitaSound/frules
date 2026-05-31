# База знаний: ИИ-содержащие автоматизированные решения для Forth

**frules** — не только rules для Cursor, а **репозиторий-школа**: как строить системы, где LLM и детерминированный код работают вместе, с **gforth** (и golden Verilog) как судьёй.

Целевая область: **hosted Gforth-экосистема** (VitaSound: fmix, flint, fcov, fhdlgen, …) + embedded/FPGA co-design.

---

## Карта документов (читать по теме)

| Тема | Документ |
|------|----------|
| **Hub (этот файл)** | [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md) |
| Track A: 0.5B — не ошибка, проехали | [`TRACK-A-LESSONS.md`](TRACK-A-LESSONS.md) |
| Почему LLM — не transpiler нотации | [`NOTATION-AND-TRANSPILER.md`](NOTATION-AND-TRANSPILER.md) |
| Tier model, Opus, cost, MCP | [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md) |
| Таблица «ИИ vs статика» | [`AI-VS-TOOLS.md`](AI-VS-TOOLS.md) |
| Multi-agent, внутренний диалог | [`MULTI-AGENT-ARCHITECTURE.md`](MULTI-AGENT-ARCHITECTURE.md) |
| **План: IR, RAG, train, infra, hardware** | [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md) |
| **Вычитка AI-generated** | [`PROOFREAD-AI-GENERATED.md`](PROOFREAD-AI-GENERATED.md) |
| ML-термины, потолок 0.5B | [`ML-GLOSSARY-FORTH.md`](ML-GLOSSARY-FORTH.md) |
| Протокол финального прогона Track A | [`TRACK-A-FINAL.md`](TRACK-A-FINAL.md) |
| Eval 151 challenge | [`CHALLENGE-TO-TRAIN.md`](CHALLENGE-TO-TRAIN.md) |
| Rules в Cursor vs Ollama | [`RULES-ARCHITECTURE.md`](RULES-ARCHITECTURE.md), [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md) |
| Co-design железо + Forth | [`FORTH-HARDWARE-CODESIGN.md`](FORTH-HARDWARE-CODESIGN.md) |

---

## Одна страница: что мы поняли (2026-05-31)

### 1. Track A (0.5B LoRA) — **не ошибка**, эксперимент закрыт

- Нашли **баги pipeline** (truncation system, train≠infer) — это ценность.
- Честный прогон: Forth-**форма**, логика **fail** → **0.5B не тянет алгоритмы Forth**.
- **Не** «надо было сразу 7B» — без Track A мы бы месяцами верили fake loss.
- Дальше: **rules + IR + transpiler + Opus как оркестратор**, не LoRA postfix.

### 2. LLM — плохой transpiler нотации (overkill)

- Infix→RPN, postfix, stack glue — **детерминированная** работа (parser, симуляция стека).
- Платить Opus/thinking за `dup swap rot` — **overkill**: дорого, ненадёжно, бесконечный Agent-loop.
- LLM силён: **смысл → IR** (Lisp, JSON AST, WASM text, Python subset).
- Подробно: [`NOTATION-AND-TRANSPILER.md`](NOTATION-AND-TRANSPILER.md).

### 3. Архитектура Tier 0–3

- **Tier 0:** gforth, transpiler, stack-glue, fmix, fhdlgen.
- **Tier 1:** локальная модель + frules SYSTEM (Gemma/Qwen).
- **Tier 2:** Composer — bulk code/docs.
- **Tier 3:** Opus — escalation, архитектура, IR design.
- Подробно: [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md).

### 4. Multi-agent и «внутренний диалог»

- **Thinking / extended reasoning** моделей ≈ **внутренний диалог**: модель задаёт себе под-вопросы под капотом.
- В продукте это **не заменяет** gforth; это Tier 3 для **выбора алгоритма**, не для postfix.
- Явная **multi-agent** схема: оркестратор (Opus) → codegen agent (Composer) → **tool agent** (compile/test) → judge (gforth).
- Подробно: [`MULTI-AGENT-ARCHITECTURE.md`](MULTI-AGENT-ARCHITECTURE.md).

### 5. RAG ≠ SYSTEM rules

- **SYSTEM (frules):** статические `.mdc` в промпте — стиль, habits, anti-patterns.
- **RAG:** retrieve по запросу — manual §, pattern library, **не** hold-out slug.
- LoRA/SFT — только для узких задач (IR JSON, micro-pairs); **не** для 98 challenges hold-out generalization на 0.5B.

### 6. Репозиторий как продукт

- 151 challenge + eval slices = **измеримость**.
- Gold train (98) = pattern library + SFT, **не** для слепого eval.
- Публичная серия (dev.to → Hackaday) = та же архитектура для людей.
- Дальнейший план: [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md).

---

## Принципы (не нарушать)

1. **Судья всегда вне LLM** — `gforth`, `T{ }T`, golden `.v`.
2. **Hold-out (53) не в train/RAG** — иначе метрика врёт.
3. **Алгоритм → IR → transpiler** — не «Opus пишет `: word` для нетривиальной логики».
4. **Opus — orchestrator**, не compiler loop.
5. **Документировать выводы** — этот индекс и связанные MD, не только чат.

---

## Живой roadmap

См. [`../TODO.md`](../TODO.md) и [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md).

Ближайшие шаги:

1. Прототип **Lisp + WASM** → Forth на `tests/ans/` (gcd, factorial, fizzbuzz).
2. Сравнить IR-варианты; зафиксировать выбор для VitaSound.
3. RAG v0 — `gforth-manual/` only.
4. Gemma + frules hold-out smoke.
5. MCP sketch → `compile_ir` + `run_gforth`.
6. Hardware bring-up **XCKU5P** (primary); x480t — secondary.

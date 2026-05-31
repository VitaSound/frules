# Multi-agent и «внутренний диалог» в ИИ-системе Forth

Зафиксировано: 2026-05-31. Связано: [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md), [`NOTATION-AND-TRANSPILER.md`](NOTATION-AND-TRANSPILER.md).

---

## Два разных «multi-agent»

Не путать:

| Конcept | Что это | Где в продукте |
|---------|---------|----------------|
| **A. Внутренний диалог модели** | Thinking / extended reasoning — модель генерирует скрытые под-вопросы и ответы **в одном inference** | Tier 3 Opus, Gemma `thinking: true` |
| **B. Явная multi-agent система** | Несколько **ролей** с разными промптами/tools: planner, coder, tester | Целевой MCP / Cursor Agent + tools |

Оба нужны; **ни один** не заменяет **gforth**.

---

## A. Внутренний диалог (thinking under the hood)

### Что это

Современные модели с **thinking / reasoning** перед видимым ответом выполняют неявный цикл:

```text
[hidden]  Какой алгоритм? Edge cases? Структура данных?
[hidden]  Если LRU — нужен порядок + map…
[visible] Вот IR / план / объяснение
```

Это **не** multi-process — один API call, **дополнительные tokens** на «разговор с собой».

### Где полезно (Tier 3)

- Неоднозначное ТЗ на RU/EN.
- Выбор алгоритма (LRU vs LFU, FS vs heap на embedded).
- Архитектура модулей: Forth words + fhdlgen blocks.
- **Один** короткий thinking-turn **дешевле**, чем 10 Agent-turns с сырым Forth.

### Где **overkill**

- Postfix, stack glue, infix→RPN — thinking **не исполняет** стек.
- Regression loop «fix rot again» — **Tier 0 tool**, не thinking marathon.

### Практика cost gate

- **Thinking-xhigh** — только architecture / IR design.
- Не включать thinking для «прогони gforth ещё раз».

---

## B. Явная multi-agent architecture (целевая)

```text
┌──────────────────────────────────────────────────────────┐
│ Orchestrator (Tier 3: Opus / human)                      │
│  — intent, acceptance criteria, escalation               │
└────────────┬─────────────────────────────────────────────┘
             │
    ┌────────┴────────┬─────────────────┐
    ▼                 ▼                 ▼
┌─────────┐   ┌─────────────┐   ┌──────────────┐
│ Planner │   │ IR Author   │   │ Integrator   │
│ Tier 1  │   │ Tier 1–3    │   │ Tier 2       │
│ local   │   │ Lisp/JSON   │   │ fmix, deps   │
└────┬────┘   └──────┬──────┘   └──────┬───────┘
     │               │                  │
     └───────────────┼──────────────────┘
                     ▼
            ┌─────────────────┐
            │ Tool Agent (T0) │
            │ compile_ir      │
            │ run_gforth      │
            │ flint, fhdlgen  │
            └────────┬────────┘
                     ▼
            ┌─────────────────┐
            │ Judge (T0)      │
            │ gforth TESTS OK │
            │ golden .v       │
            └─────────────────┘
```

### Роли

| Agent | Tier | Делает | Не делает |
|-------|------|--------|-----------|
| **Orchestrator** | 3 | Разбивает задачу, решает escalation | Postfix вручную |
| **IR Author** | 1–3 | Lisp/JSON/WASM/Python IR | Final Forth emit |
| **Bulk Coder** | 2 | Scripts, CI, docs, fmix | Algorithm IR без review |
| **Tool Agent** | 0 | Deterministic tools | «Думать» про алгоритм |
| **Judge** | 0 | gforth, golden | Generative text |

**Ключ:** Tool Agent возвращает **structured JSON** (`status`, `word`, `stack`, `line`) — Orchestrator / IR Author правят **IR**, не переписывают `.fs` вслепую.

---

## Внутренний диалог vs явные агенты

| | Internal (thinking) | Explicit multi-agent |
|--|---------------------|----------------------|
| Latency | Один call, длиннее | Несколько calls / tools |
| Cost | Hidden tokens | Видимые per-agent |
| Debug | Чёрный ящик | Логи per role |
| Лучше для | Single hard decision | **Compile/test loop** |

**Продукт:** thinking для **plan once**; explicit tools для **iterate many**.

---

## Cursor Agent сегодня ≈ proto multi-agent

Cursor Agent уже:

- читает rules (frules);
- вызывает shell (gforth);
- иногда застревает в loop (overkill на notation).

**Целевое улучшение (MCP):**

- Agent **обязан** вызвать `compile_ir` вместо raw Forth;
- `run_gforth` — единственный источник PASS/FAIL;
- Opus подключается **skill escalation**, не default.

См. [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md) — MCP tools draft.

---

## Eval и multi-agent

Метрика продукта:

```text
P(TESTS OK | orchestrator + toolchain, eval_holdout slug)
```

Не:

```text
P(looks like Forth | single model raw output)
```

A/B:

- rules on/off;
- IR pipeline on/off;
- Tier 3 on/off при fixed Tier 0.

---

## Для статей

История «как работает мозг инженера» = **Orchestrator + tools + judge**, не «нейросеть выучила Forth».

Thinking — **внутренний монолог** перед чертежом; fmix/frules/gforth — **внешняя память и совесть**.

---

## См. также

- [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md) — MCP, infra
- [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md)

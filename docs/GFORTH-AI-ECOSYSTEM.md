# Экосистема: эффективное программирование на Gforth с LLM

Практическая шпаргалка: **что подключить, в каком порядке, зачем**. Hub: [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md).

**Статус:** v1 (2026-06). Отражает выводы Track A, tier model, fmcp, Phase 2 roadmap.

---

## Одна строка

> **Rules** учат привычкам, **RAG** даёт § manual, **MCP** даёт PASS/FAIL, **skills** задают рецепт работы. **gforth** — единственный судья. LoRA на postfix не нужен; Opus — для смысла и IR, не для `rot rot`.

---

## Главный вывод (не переучивать модель на Forth)

| Подход | Вердикт |
|--------|---------|
| LoRA 0.5B → postfix Forth | ❌ Track A закрыт |
| Opus пишет `: word` для алгоритмов | ❌ дорого, ненадёжно |
| **Rules + MCP + IR + transpiler** | ✅ целевая архитектура |
| LoRA 7B → **IR JSON / Lisp** | ⚠️ опционально (Track B) |
| RAG по `gforth-manual/` | ✅ Phase 2 |
| Cursor Skills (workflow) | ✅ следующий практический шаг |

Модели **не надо** учить postfix. Надо **обвешать** их правилами, справочником, инструментами и заставить **проверять** gforth.

---

## Четыре слоя

```text
┌─────────────────────────────────────────────────────────┐
│ 1. RULES (frules)     — КАК писать (стиль, habits)      │
│ 2. RAG                — ЧТО говорит manual (факты)       │
│ 3. MCP (fmcp)         — ПРОВЕРИТЬ (compile, test, lint) │
│ 4. SKILLS             — КОГДА и В КАКОМ ПОРЯДКЕ        │
└─────────────────────────────────────────────────────────┘
                              ↓
                    gforth = судья PASS/FAIL
```

### 1. Rules — frules (уже есть)

```bash
./install.sh <target-project> gforth    # full rules
./install.sh <target-project> gforth core   # меньше контекста
```

| | Rules | RAG |
|---|-------|-----|
| Когда | в SYSTEM / по glob на `*.fs` | по запросу |
| Содержание | habits, stack effects, anti-patterns | § manual, rare words |
| Размер | ~25–74 KB | manual на MB |

Подробно: [`RULES-ARCHITECTURE.md`](RULES-ARCHITECTURE.md), [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md).

### 2. RAG — справочник по требованию

- Corpus v0: `sources/gforth-manual/` only.
- Pattern library (98 train): similarity по `pattern_key`, **не** verbatim paste.
- **Не класть:** hold-out slug (53), gold eval solutions.

Planned: `scripts/build-rag-index.py`, MCP tool `rag_manual(query)`.

Подробно: [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md) § Phase 2.

### 3. MCP — fmcp (руки и судья)

Cursor MCP `vitasound-forth`: `gforth_eval`, `fmix_test`, `flint_lint`, `fcov_run`, …

**Без MCP** агент галлюцинирует «должно работать». **С MCP** — замкнутый контур:

```text
правка → gforth_eval → FAIL → правка → PASS
```

Repo: [VitaSound/fmcp](https://github.com/VitaSound/fmcp).

### 4. Skills — рецепты workflow

**Skills** — markdown-инструкции в `.cursor/skills/<name>/SKILL.md`. Агент читает их, когда задача подходит.

| | Rules | Skills |
|---|-------|--------|
| Что | знания языка | порядок действий |
| Пример | «пиши `( before -- after )`» | «challenge: spec → IR → fmcp → flint» |
| Где | `rules/*.mdc` → install | `.cursor/skills/` (в frules — canonical; копировать в целевой репо) |

Canonical skills в frules: [`../.cursor/skills/`](../.cursor/skills/) — **29 skills** (P0–P3). Полный каталог: [`GFORTH-SKILLS-CATALOG.md`](GFORTH-SKILLS-CATALOG.md). Установка: `./install.sh <target> gforth` (rules + skills symlinks).

---

## Tier model (какие модели для чего)

```text
Tier 3 — Opus / thinking
  алгоритм, неоднозначное ТЗ, IR design
  НЕ: цикл «fix rot» × 10

Tier 2 — Cursor Auto / Composer
  bulk: docs, yaml, refactor, простые words + fmcp

Tier 1 — Ollama (Qwen/Gemma + frules SYSTEM)
  черновик IR, smoke train challenges ($0 API)

Tier 0 — детерминированно
  gforth, flint, fcov, fmix, lisp-to-forth, stack-glue
```

Подробно: [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md).

---

## Pipeline v1

### Нетривиальная логика

```text
1. Intent + edge cases        (Tier 3 или человек)
2. IR: Lisp / JSON AST        (Tier 1–3) — не длинный raw Forth
3. transpiler + stack-glue    (Tier 0)
4. fmcp gforth_eval           (Tier 0)
5. FAIL → править IR, снова 4
6. flint / fcov               (Tier 0)
```

### Простые слова в проекте

```text
frules rules + fmcp в цикле — достаточно, Opus не нужен
```

Подробно: [`AI-VS-TOOLS.md`](AI-VS-TOOLS.md), [`NOTATION-AND-TRANSPILER.md`](NOTATION-AND-TRANSPILER.md).

---

## Чеклист сборки экосистемы (порядок)

| # | Статус | Действие | Зачем |
|---|--------|----------|-------|
| 1 | ✅ | `./install.sh` в целевой проект | habits в контексте |
| 2 | ✅ | fmcp в Cursor MCP + PATH | судья в каждой сессии |
| 3 | ✅ | project skills в `.cursor/skills/` | workflow без «угадывания» |
| 4 | [ ] | RAG v0 (manual only) | редкие Gforth-слова |
| 5 | [ ] | IR prototype (`lisp-to-forth`) | алгоритмы без Opus-postfix |
| 6 | [ ] | Ollama + frules core | локально без API |
| 7 | ⚠️ | Track B LoRA на IR | только если 1–6 мало |

RLM / RLM-MCP — **Phase 2b**, после RAG; навигация по большому corpus, не замена fmcp. См. обсуждение в [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md).

---

## Ежедневная настройка Cursor

- [ ] `./install.sh ~/project gforth` (или `core`)
- [ ] MCP `vitasound-forth` включён; `gforth`, `fmix`, `flint` на `PATH`
- [ ] В AGENTS.md проекта: «алгоритм → IR; после правки — gforth_eval»
- [ ] Opus — только если Auto застрял на **алгоритме**; один thinking-turn
- [ ] Hold-out (53): не подсказывать slug, не RAG по gold; eval только через gforth

---

## Skills: canonical set (29)

Установка в target-проект:

```bash
./install.sh /path/to/project gforth
```

| Bundle | Skills |
|--------|--------|
| Minimal (7) | solve-gforth-challenge, add-gforth-word, frules-topic-routing, debug-gforth-stack, gforth-verify-loop, lookup-gforth-manual, tier-escalation-cost-gate |
| VitaSound (12) | Minimal + fmix-project-workflow, flint-fcov-quality-gate, gforth-ir-pipeline, eval-holdout-integrity, setup-frules-ecosystem |
| Full | все 29 — см. catalog |

**P** vs bundle: см. [GFORTH-SKILLS-CATALOG.md](GFORTH-SKILLS-CATALOG.md) § Bundles — приоритет rollout ≠ состав Minimal.

README: [`.cursor/skills/README.md`](../.cursor/skills/README.md). Catalog: [`GFORTH-SKILLS-CATALOG.md`](GFORTH-SKILLS-CATALOG.md).

**Не входят:** fhdl / fhdlgen skills.

---

## Что не отдавать LLM

| Задача | Кто |
|--------|-----|
| Postfix glue между ops | stack-glue (Tier 0) |
| Infix → RPN, AST walk | transpiler |
| TESTS OK / PASS | gforth |
| Duplicate words | flint |
| Hold-out «успех» без gforth | запрещено |

---

## Eval и честность метрик

| Slice | Slug | Gold | RAG / LoRA |
|-------|------|------|------------|
| train | 98 | `data/challenge-solutions/` | pattern library OK |
| hold-out | 53 | нет | **запрещено** |

Судья всегда: gforth. Подробно: [`CHALLENGE-TO-TRAIN.md`](CHALLENGE-TO-TRAIN.md).

---

## Связанные документы

| Тема | Файл |
|------|------|
| Hub | [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md) |
| ИИ vs статика (таблица задач) | [`AI-VS-TOOLS.md`](AI-VS-TOOLS.md) |
| Tier, Opus, cost | [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md) |
| Roadmap IR, RAG, MCP | [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md) |
| Решение challenges агентом | [`AGENT-SOLVE-CHALLENGES.md`](AGENT-SOLVE-CHALLENGES.md) |
| A/B benchmark | [`BENCHMARK-AB-98.md`](BENCHMARK-AB-98.md) |
| Track A уроки | [`TRACK-A-LESSONS.md`](TRACK-A-LESSONS.md) |
| Ollama + rules | [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md) |
| Живой TODO | [`../TODO.md`](../TODO.md) |
| Skills catalog | [`GFORTH-SKILLS-CATALOG.md`](GFORTH-SKILLS-CATALOG.md) |

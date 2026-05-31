# Roadmap: ИИ-платформа frules + VitaSound

План действий после рефлексии 2026-05-31. Hub: [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md).

**Миссия репозитория:** база знаний о том, как строить **ИИ-содержащие автоматизированные решения**, в частности для **Forth-систем** — с измеримым eval, детерминированным backend и честным разделением ролей LLM vs tools.

---

## Фазы (overview)

```text
Phase 0  ✓  rules, challenges, Track A closed, docs hub
Phase 1  →  IR prototypes (Lisp, WASM) + stack-glue + gforth judge
Phase 2  →  RAG v0 + Gemma baseline + MCP compile/run
Phase 3  →  Track B (optional) IR-SFT on 7B + cost metrics
Phase 4  →  fhdlgen + KU5P bring-up + Hackaday
Phase 5  →  inference engine on FPGA (quantized NN) — long term
```

---

## Phase 1 — IR: протестировать Lisp и WASM (ближайшие 1–2 сессии)

### Цель

Выбрать **primary IR** для VitaSound codegen: сравнить **Lisp S-expr** и **WASM text** (JSON AST и Python `ast` — Phase 1b).

### Задачи

| # | Задача | Артефакт |
|---|--------|----------|
| 1.1 | `scripts/lisp-to-forth.py` — post-order emit + locals hook | prototype |
| 1.2 | `scripts/wasm-to-forth.py` — subset `.wat` → Forth ops | prototype |
| 1.3 | `scripts/stack-glue.py` — симуляция стека между ops | shared layer |
| 1.4 | Benchmark harness: `gcd`, `factorial`, `fizzbuzz` из `tests/ans/` | `scripts/ir-benchmark.sh` |
| 1.5 | LLM генерирует **только IR** (prompt template в `docs/` или `templates/`) | reproducible prompts |
| 1.6 | Записать сравнение в `docs/IR-CHOICE.md` (создать после прогона) | decision doc |

### Критерии выбора IR

| Критерий | Lisp | WASM |
|----------|------|------|
| LLM hallucination rate | | |
| Parser strictness | loose → need validate | strict grammar |
| Control flow (`if`, loop) | natural | ok in .wat |
| Связь с **fhdlgen** / hardware | indirect | **stack machine kinship** |
| Lines of backend code | | |

### Как корректируется проект после Phase 1

- **TODO IR-пайплайн:** отметить winner / hybrid (Lisp for algo, WASM for stack-native).
- **rules:** добавить `templates/ir-lisp.md` / `ir-wasm.md` — «Agent MUST output IR, not raw Forth».
- **AGENTS.md:** ссылка на chosen IR.
- **Track B** (если будет): SFT на **IR pairs**, не Forth `: word`.
- **MCP `compile_ir`:** backend = winner transpiler.

---

## Phase 2 — RAG, infra, MCP

### RAG: что кладём и что **не** кладём

| Corpus | RAG? | Назначение |
|--------|------|------------|
| `sources/gforth-manual/` | **Да v0** | § struct, exception, word-specific |
| `sources/gforth-manual-tutorial/` | Да (optional) | beginner idioms |
| `rules/*.mdc` | **Нет** — уже SYSTEM | static in prompt |
| `data/challenge-solutions/` (98 train) | **Pattern library**, не verbatim paste | similarity by `pattern_key`, **exclude slug** in eval |
| `tests/challenges/` hold-out (53) | **Нет** | eval only |
| `sources/rosettacode-forth/` | Selective | hints, not full dump |
| `sources/theforth.net-packages/` | INDEX-driven | package API snippets |

**Script (planned):** `scripts/build-rag-index.py` — chunk manual, embed, manifest with `eval_holdout` denylist from `eval-slices.yaml`.

### Infra (home lab)

| Компонент | Назначение |
|-----------|------------|
| **Ollama** | Gemma 4 e4b, Qwen; `Modelfile.forth-qwen-core` |
| **gforth 0.7.9** | Judge (not Snap) |
| **fmix** | Project structure, `fmix test` in loop |
| **flint / fcov** | Quality after codegen |
| **WSL2 Linux** | Dev host (fmix TTY lessons) |
| **Cursor** | Tier 2–3; cost cap |
| **GitHub Actions** | CI `./test.sh` (TODO) |

### MCP / Cursor skill (Phase 2)

Минимальный набор:

```
compile_ir(source, format=lisp|wasm|json)
run_gforth(file | inline)
run_challenge(slug, slice=eval_holdout|train)
rag_manual(query, top_k=3)
fmix_test(path?)
```

Skill text: «Algorithm → compile_ir; never long raw Forth for logic».

---

## Phase 3 — Обучение ИИ (что имеет смысл)

### Не учим

| | Почему |
|--|--------|
| 0.5B LoRA → Forth postfix | Track A closed |
| Hold-out solutions | Cheat |
| «Forth algorithms» end-to-end on small model | No capacity |

### Учим (optional Track B 7B)

| Dataset | Content | Goal |
|---------|---------|------|
| **IR micro-pairs** | spec → Lisp/JSON (50–500 lines) | IR shape |
| **Curriculum** | `1 2 +` level → small functions | format compliance |
| **challenge-train IR** | 98 gold → **IR translation** (human or transpiler reverse) | pattern |
| Short system | `TRAIN_SYSTEM_SHORT` | parity Track A lessons |

**Eval всегда:** `compile_ir(model_output) → gforth`, не raw model Forth.

### Rules vs LoRA vs RAG (итоговая таблица)

| Mechanism | Когда |
|-----------|-------|
| **frules SYSTEM** | Daily coding, style, stack habits |
| **RAG** | Deep manual § on demand |
| **LoRA 7B** | IR JSON compliance, optional |
| **Transpiler** | Notation, stack glue |
| **Opus Tier 3** | Architecture, hard specs |

---

## Phase 4 — Hardware (домашняя ориентация)

### Primary: **Xilinx XCKU5P** dev board

| Resource | Значение для проекта |
|----------|----------------------|
| ~475K LC | VitaSound-scale synth, many cores |
| ~1824 DSP | FIR, MAC arrays, **inference** |
| Memory, peripherals | DDR, high-speed IO |

**Роль:** основная плата для fhdlgen → bitstream → Hackaday articles.

«Не хватает LUT» для текущих замыслов — **закрыто**.

### Secondary: **Virtex-7 x480t**

| Роль |
|------|
| Legacy 7-series flow, сравнение, тяжёлые legacy designs |
| Не primary для новых статей (фокус KU5P) |

### Software stack на железе

```text
Forth (hosted, fmix) ──► algo, bring-up scripts
fhdlgen IR ──► Verilog ──► Vivado ──► KU5P
Future: quantized inference IP (DSP+BRAM) co-designed with Forth orchestration layer
```

См. [`FORTH-HARDWARE-CODESIGN.md`](FORTH-HARDWARE-CODESIGN.md).

### Phase 4 milestones (контент)

1. Bitstream + LED/UART — Hackaday «board arrived».
2. fhdlgen module on chip — dev.to/Hackaday bridge.
3. Tiny MAC array / int8 dot product — путь к «сетям на железе».

---

## Phase 5 — Сети на FPGA (long term)

Не «обучить ResNet в Vivado», а:

- **Quantized inference** (int8/int4), weights in BRAM;
- Forth или minimal orchestrator on soft CPU / state machine;
- **fhdlgen** emits datapath;
- Opus fills **graph IR**, not Verilog by hand.

Связь с frules: eval culture переносится — **golden vectors**, не «модель сказала OK».

---

## Публичность (параллельный track)

| # | Площадка | Тема |
|---|----------|------|
| 1 ✓ | [dev.to fmix](https://dev.to/ua3mqj/fmix-a-package-manager-for-forth-37ld) | Package manager |
| 2 | dev.to EN + RU | frules — rules beat 0.5B LoRA |
| 3 | dev.to | IR pipeline + notation |
| 4 | Hackaday | KU5P bring-up |
| 5 | Hackaday | fhdlgen + tiny inference |

---

## Экономика (cost gate) — operational plan

| Rule | Action |
|------|--------|
| Monthly on-demand cap | Cursor settings — комфортный порог |
| Agent on repo | Composer default; Opus Ask 1–2 turns |
| Thinking-xhigh | IR/architecture only |
| Compile loop | Ollama Tier 1 + Tier 0 tools |
| Measure | Log turns before/after `compile_ir` on gcd |

---

## Как обновлять этот roadmap

После каждой фазы:

1. Создать/обновить decision doc (`IR-CHOICE.md`, benchmark numbers).
2. Отметить `[x]` в [`TODO.md`](../TODO.md).
3. Одна строка в [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md) «что поняли».
4. При необходимости — [`TRAINING-RUNS.md`](TRAINING-RUNS.md), [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md).

---

## Checklist ближайшей недели

- [ ] `lisp-to-forth.py` — gcd PASS via gforth
- [ ] `wasm-to-forth.py` — same 3 ans tasks
- [ ] `stack-glue.py` — integrated
- [ ] `docs/IR-CHOICE.md` — decision
- [ ] Gemma + frules — 3 hold-out smoke (`LOCAL-GEMMA-BENCHMARK.md`)
- [ ] `build-rag-index.py` — manual only, hold-out denylist
- [ ] Draft MCP tool schemas in `docs/MCP-TOOLS-DRAFT.md` (optional next file)

---

## См. также

- [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md)
- [`TRACK-A-LESSONS.md`](TRACK-A-LESSONS.md)
- [`NOTATION-AND-TRANSPILER.md`](NOTATION-AND-TRANSPILER.md)
- [`MULTI-AGENT-ARCHITECTURE.md`](MULTI-AGENT-ARCHITECTURE.md)
- [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md)
- [`../TODO.md`](../TODO.md)

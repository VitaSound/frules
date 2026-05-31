# Почему LLM — не transpiler нотации (и почему это overkill)

Зафиксировано: 2026-05-31. Связано: [`AI-VS-TOOLS.md`](AI-VS-TOOLS.md), [`TRACK-A-LESSONS.md`](TRACK-A-LESSONS.md).

---

## Тезис

**Преобразование нотации** (infix → RPN, AST → post-order, WASM stack → Forth, **stack glue** между ops) — **не задача для LLM**.

Это задача для **parser + симулятор стека + codegen** — детерминированного, тестируемого, дешёвого.

Платить **Opus / thinking** или **учить LoRA** на postfix — **overkill**: дорого, медленно, ненадёжно, не верифицируемо без gforth anyway.

---

## Что такое «преобразование нотации»

| Задача | Вход → выход | Тип работы |
|--------|--------------|------------|
| Infix → RPN | `(a+b)*c` → `a b + c *` | Parsing |
| Lisp → Forth | `(+ a (* b c))` → post-order emit | Tree walk |
| JSON AST → Forth | `{ "op":"+", "args":[…] }` | Schema + emit |
| WASM text → Forth | `i32.add` → `+` | Table lookup |
| Stack glue | ops `[+, *, if]` → `… dup swap rot …` | **Stack simulation** |
| Python subset | `ast.parse` → walk | Deterministic |

Все эти задачи имеют:

- **Фиксированную грамматику**
- **Известные stack effects** `( before -- after )` на каждый op
- **Единственный правильный ответ** (modulo factoring style — отдельный слой)

LLM здесь добавляет **стochastic noise** без выигрыша в выразительности.

---

## Почему LLM кажется «умным» для нотации

1. **В претрейне много кода** — модель *имитирует* RPN и Forth в тексте.
2. **Короткие примеры** (`2 3 +`) — часто верны (memorization / pattern).
3. **Thinking** — внутренний перебор, но **без исполнения** на реальном стеке.
4. **Rules (frules)** улучшают стиль, **не** гарантируют баланс стека.

Track A: после fix pipeline 0.5B давала **Forth-shaped wrong logic** — форма без семантики.

Opus в Agent-loop: **WRONG NUMBER OF RESULTS** → переписывание → **сотни тысяч tokens** на ту же детерминированную работу.

---

## Overkill: экономика и архитектура

| Подход | Стоимость | Надёжность | Верификация |
|--------|-----------|------------|-------------|
| Opus Agent пишет postfix | $$$, много turns | Низкая | gforth post-hoc |
| 0.5B LoRA on Forth | GPU + время | Очень низкая | gforth |
| **Transpiler + stack-glue** | CPU ms | **Высокая** | gforth + unit tests on IR |
| LLM только **генерирует IR** | $ один short turn | Средняя (логика) | gforth на output |

**Overkill** = использовать **general reasoning** там, где достаточно **algorithm from 1970s** (shunting-yard, post-order traversal).

---

## Где LLM **уместен** в pipeline

| Этап | LLM | Почему |
|------|-----|--------|
| Понять ТЗ RU/EN | **Да** | Неоднозначность, домен |
| Выбрать алгоритм | **Да** | Trade-offs |
| Нарисовать **IR** (Lisp/JSON/WASM/Python) | **Да** | Модели сильны в familiar syntax |
| Infix → RPN | **Нет** | Parser |
| IR → Forth emit | **Нет** | Transpiler |
| Stack glue | **Нет** | Simulator |
| TESTS OK | **Нет** | gforth |

**Гибрид (v1):**

```text
User ──► LLM ──► IR (Lisp / JSON / .wat)
              ──► transpiler ──► stack-glue ──► .fs
              ──► gforth ──► PASS | structured FAIL
              ──► LLM правит IR (не postfix), если FAIL logic
```

---

## Stack glue — отдельно от «стиля Forth»

`dup swap rot over nip >r r>` между словами с известным stack effect — **combinatorial search** на малом пространстве.

- Для **генератора** — допустимо «ugly glue» (см. `forth-anti-patterns` — rot rot в **ручном** коде плохо, в **emit** — OK).
- Для **LLM** — пространство ошибок огромно при малой пользе.

План: `scripts/stack-glue.py` или слой в transpiler — см. [`ROADMAP-AI-PLATFORM.md`](ROADMAP-AI-PLATFORM.md).

---

## IR-кандидаты (что тестируем)

| IR | LLM генерирует? | Backend |
|----|-----------------|---------|
| **Lisp S-expr** | Отлично | Post-order walk |
| **JSON AST** | Хорошо (schema) | Strict parse + emit |
| **WASM text** | Хорошо | Opcode table |
| **Python subset** | Отлично | `ast.parse` — **не доверять** LLM-AST «из головы» |

**Следующий шаг:** сравнить на `gcd`, `factorial`, `fizzbuzz` — галлюцинации IR vs `TESTS OK` после transpile.

---

## Антипаттерны (записать в AGENTS / rules)

1. «Пусть Opus напишет весь `: word` для алгоритма» — **запрещено** для нетривиальной логики.
2. «LoRA научит postfix» — **закрыто** Track A.
3. «Thinking заменит gforth» — **нет**.
4. «RAG подставит правильный stack order» — **нет**, только transpiler.

---

## См. также

- [`EXTERNAL-LLM-ARCHITECTURE.md`](EXTERNAL-LLM-ARCHITECTURE.md) — Tier 0 vs Opus
- [`AI-KNOWLEDGE-INDEX.md`](AI-KNOWLEDGE-INDEX.md)

# Стековый CPU: исследовательские тезисы (суперскаляр, co-design)

> **English:** [FORTH-STACK-CPU-RESEARCH-eng.md](FORTH-STACK-CPU-RESEARCH-eng.md)  
> **Авторство:** [DOC-AUTHORSHIP.md](DOC-AUTHORSHIP.md) — AI-assisted (human-directed); дистилляция из статей zzeng (Habr) и связанного контекста, не канон Forth-сообщества.  
> **Hub:** [FORTH-SYSTEM-ARCHITECTURE.md](FORTH-SYSTEM-ARCHITECTURE.md) · **Co-design:** [FORTH-HARDWARE-CODESIGN.md](FORTH-HARDWARE-CODESIGN.md)

Сжатые **рабочие тезисы** для базы знаний frules: почему стековый внешний ISA может сосуществовать с внутренним регистровым суперскаляром, как это связано с Forth, J1 и историческими машинами.

**Первоисточники (zzeng / Б. Муратшин, Habr):**

| Тема | URL |
|------|-----|
| Вызовы, volatile/non-volatile, регистровые окна | [267771](https://habr.com/ru/articles/267771/) |
| Loop fracking (широкие деревья выражений) | [271905](https://habr.com/ru/articles/271905/) |
| Модель: стековый фронтенд + мопы + OoO | [278575](https://habr.com/ru/articles/278575/) |
| Вызовы: register windows, FILL/SPILL | [279123](https://habr.com/ru/articles/279123/) |
| Вызовы изнутри: сериализация мопов | [280087](https://habr.com/ru/articles/280087/) |
| Закладки (bookmarks), оптимизация памяти | [281352](https://habr.com/ru/articles/281352/) |
| Эльбрус-1/2: исторический прототип | [313376](https://habr.com/ru/articles/313376/) |

---

## Содержание

1. [Зачем этот документ в frules](#1-зачем-этот-документ-в-frules)
2. [Проблема, которую адресуют статьи](#2-проблема-которую-адресуют-статьи)
3. [Архитектурный тезис: два «стека»](#3-архитектурный-тезис-два-стека)
4. [Вызов функций и контекст](#4-вызов-функций-и-контекст)
5. [Оптимизация: fracking и закладки](#5-оптимизация-fracking-и-закладки)
6. [Историческая линия](#6-историческая-линия)
7. [Сопоставление с FMAP и J1](#7-сопоставление-с-fmap-и-j1)
8. [Тезисы для агентов и датасета](#8-тезисы-для-агентов-и-датасета)
9. [Заблуждения (дополнение к §12 hub)](#9-заблуждения-дополнение-к-12-hub)

---

## 1. Зачем этот документ в frules

| Вопрос | Где ответ |
|--------|-----------|
| Какой Forth / CPU выбрать сегодня? | [FORTH-FMAP-GUIDE.md](FORTH-FMAP-GUIDE.md) |
| Оси FMAP, класс 0, J1 | [FORTH-SYSTEM-ARCHITECTURE.md](FORTH-SYSTEM-ARCHITECTURE.md) §9–§11 |
| Строить своё железо под задачу? | [FORTH-HARDWARE-CODESIGN.md](FORTH-HARDWARE-CODESIGN.md) |
| **Зачем вообще стековый ISA, если внутри всё равно регистры?** | **этот документ** |
| **Был ли «суперскалярный стек» в железе?** | **§6 (Эльбрус), §7 (J1)** |

Документ **не** описывает готовую реализацию CPU в frules — только карту идей для architecture-вопросов и co-design.

---

## 2. Проблема, которую адресуют статьи

**Снаружи (ISA / компилятор):**

- Регистровые имена в asm — **интерфейс связей** между инструкциями, не обязательно физические регистры.
- Компилятор статически размещает «виртуальные» регистры (NP-полная задача); число регистров в ABI **фиктивно** и не масштабируется с железом.
- Стековый код **компактнее**: нет имён регистров в каждой инструкции; зависимости **неявны** через порядок на стеке.

**Внутри (суперскаляр):**

- Последовательный входной код нужно **распаковать** в параллельные микрооперации — дорого на decode/rename.
- Стековая машина **кажется** строго последовательной → ILP «спрятан» до runtime.

**Требования zzeng к новому интерфейсу:**

1. Весь известный компилятору параллелизм должен **дойти до железа** без потерь.
2. Издержки на разбор зависимостей — **минимальны** (зависимости уже в структуре стека / дерева).

Forth/postfix попадает в эту картину как **естественный компактный фронтенд**; см. [Koopman stack computers](https://users.ece.cmu.edu/~koopman/stack_computers/sections.html) для классического обзора стековых машин.

---

## 3. Архитектурный тезис: два «стека»

```text
Внешний ISA:  push / + / @ / call     ← то, что видит компилятор (Forth, стековый C backend)
       ↓ декодер
Внутренний:   мопы (lload, ladd, …)   ← регистровые μops, OoO dispatch
       ↓
Физика:       пул регистров + конвейеры (ALU, память)
```

**Ключевой трюк:** «вершина стека» снаружи — это **стек индексов мопов** (очередь операций), не обязательно стек данных в памяти.

| Механизм | Смысл |
|----------|--------|
| **Моп** | Внутренняя трёхадресная заготовка (`add r1 r2 r3`); links на родительские мопы |
| **Стек индексов** | Декодер снимает N верхних мопов как аргументы бинарной операции |
| **Готовность** | Моп исполняется, когда счётчик предков = 0; регистр назначается при **постановке в конвейер**, не при decode |
| **OoO** | Независимые load и add из разных веток дерева — параллельно (пример: FFT, сбалансированная сумма) |

**Тезис для frules:** postfix Forth описывает **дерево выражения**; глубина стека данных ≈ глубина дерева; **параллелизм** — в **ширину** дерева, не в «глубину» цепочки `+`.

**Следствие для кода на Gforth (слой 1):** линейная цепочка `a b + c + d +` — худший случай для ILP; явные скобки / locals / factoring — аналог «fracking» на уровне языка (см. §5).

---

## 4. Вызов функций и контекст

Статьи [279123](https://habr.com/ru/articles/279123/), [280087](https://habr.com/ru/articles/280087/) + фундамент [267771](https://habr.com/ru/articles/267771/).

### Внешняя модель (как SPARC / AMD29K, не MIPS fixed ABI)

| Идея | Деталь |
|------|--------|
| **Register windows** | Нумерация локальных регистров **с нуля в каждой функции**; in/out пересекаются при call |
| **Два стека** | Register stack (быстрый) + memory stack (большие данные, spill) — образец **AMD29K** |
| **FILL / SPILL** | По **фрейму вызова**, с **маской занятых** регистров — не сохранять пустые слоты |
| **Call как μop** | Аргументы должны быть **вычислены** до call; call блокирует сериализацию контекста |

### Внутренняя модель (суперскаляр + рекурсия)

| Проблема | Подход |
|----------|--------|
| Мопы родителя «висят» при вложенном call | Сериализация ожидающих мопов в stack (альтернатива L0μ-cache) |
| Глубина рекурсии (Ackermann) | Per-function нумерация мопов; компилятор разбивает `f(a, g(b))` через temps |
| Код после call | Порции decode с **одним** безусловным выходом (урок Sandy Bridge) |

**Тезис для frules:** на **register MCU + STC Forth** (stm8ef, Mecrisp) контекст call — **явный** (стек, saved regs); на **гипотетическом суперскалярном стековом CPU** компилятор Forth **может не знать** о регистрах — сохранение **аппаратное**. Это **не** текущий J1 (см. §7).

**Связь с C++ EH ([267771](https://habr.com/ru/articles/267771/)):** при обычных call/unwind данные для восстановления контекста **уже в стеке** — zero-cost exceptions через статические таблицы; параллельно объясняет volatile vs callee-saved.

---

## 5. Оптимизация: fracking и закладки

Источник: [271905](https://habr.com/ru/articles/271905/), [281352](https://habr.com/ru/articles/281352/).

### Loop fracking

| Форма суммы | Дерево | ILP |
|-------------|--------|-----|
| `sum += x[i]` | левый список | нет (цепочка зависимостей) |
| nesting ×2, ×4 | два/четыре аккумулятора | частичный |
| пирамида / popadd | сбалансированное | log₂(N) «уровней», масштаб по числу ALU |

**Тезис:** широкое дерево выражения — **переносимая** оптимизация (не привязана к SIMD); `/fp:fast` на x86 может обойти ручной nesting, на другом железе — нет.

### Bookmarks (закладки)

Компилятор помечает «ценное» значение: `bmk N` / `add_bmk N` — именованный слот, живёт до return, участвует в FILL/SPILL.

| Аналог в Forth (слой 1) | Аналог в ISA zzeng |
|-------------------------|-------------------|
| `{ locals }`, `VALUE` | bookmark N |
| factoring в `: helper` | отдельный bmk |
| `VARIABLE` + `@`/`!` | memory stack (медленно) |

**Тезис:** слабое место **наивного** стекового codegen — лишние `push`/`@`; закладки — **явные temps в быстром стеке**, как locals без изменения внешнего postfix-стиля.

---

## 6. Историческая линия

| Система | Что общего с тезисами zzeng | Статус |
|---------|----------------------------|--------|
| **Burroughs B5000** | стековый ISA, compact code | historical |
| **Эльбрус-1/2** ([313376](https://habr.com/ru/articles/313376/)) | безадресный стек + **СтОп** (32 reg + маска) + **OoO** (~2 insn/takt) + scoreboard | реализовано ~1973–80 |
| **AMD29K** | dual stack, register windows, SPILL/FILL | commercial |
| **SPARC / Itanium RSE** | register windows | commercial |
| **J1** | postfix ISA, **без** OoO rename, fixed shallow stack | open soft-CPU |
| **Проект zzeng** | стековый фронтенд + мопы + bookmarks | **исследование**, не silicon |

**Эльбрус (важно для frules):**

- **СтОп** — циклический буфер регистров под «вершину стека»; битовая маска занятости; регистр назначается при decode, освобождается после exec.
- **Не** register renaming в современном смысле — **scoreboarding**.
- Автор [313376](https://habr.com/ru/articles/313376/) прямо: идея суперскалярного стекового CPU **концептуально стройнее**, но **не прижилась** commercially.

---

## 7. Сопоставление с FMAP и J1

| Ось | J1 (frules §11.1) | Эльбрус | zzeng (гипотеза) |
|-----|-------------------|---------|------------------|
| **MM** | V | unified + tagged VM | V-like internal |
| **Внешний ISA** | postfix insn | безадресный стек | стековый push/pop |
| **EX-C** | V (colon→insn на host) | native decode | мопы + OoO |
| **Стек данных** | fixed ~33, **no spill** | СтОп + spill в RAM | register window + mem |
| **Параллелизм** | minimal (1 ALU) | multi-EU, OoO | multi-EU, OoO |
| **Call/return** | hardware R stack ~32 | многофазный (МС→ВХОД) | serialized mops + windows |
| **Forth runtime** | RP=0, cross-only | full OS + tagged | compiler может не знать regs |

**Тезис:** J1 — **практичный L2 co-design** (простота, Verilog); линия zzeng/Эльбрус — **другой trade-off**: сложнее железо, богаче ILP, компактнее код. Не смешивать при рекомендациях агенту.

**Register MCU + Gforth** — третья ветка: стеки **в RAM**, STC/ITC, суперскаляр **в CPU x86/ARM**, не в Forth-ISA. Доминирующий путь для прикладного Forth сегодня.

---

## 8. Тезисы для агентов и датасета

При architecture-промптах включать **provenance**: «research thesis from zzeng distill, not verified silicon».

| # | Тезис | Действие агента |
|---|--------|-----------------|
| T1 | Postfix = компактное описание **DAG** выражения | Не equate «стек» только с RAM PSP |
| T2 | Глубокий линейный стек = мало ILP | Factoring, locals, сбалансированные формы — ok |
| T3 | «Стековый CPU» ≠ один дизайн | Уточнять: fixed internal (J1) vs RAM-backed vs internal OoO (Эльбрус) |
| T4 | J1 **не** суперскалярный стек zzeng | Не обещать OoO/bookmarks на J1 |
| T5 | Bookmarks ≈ **named temps** / locals | На Gforth — `{ }`, не выдумывать ISA `bmk` |
| T6 | Call на windowed CPU — frame SPILL | На STM8/Mecrisp — явный stack frame, не «магия» |
| T7 | Эльбрус — proof that **stack frontend + OoO** existed | Цитировать как historical, не as shipping target |
| T8 | Co-design today | J1/Mecrisp-Ice path в [FORTH-HARDWARE-CODESIGN.md](FORTH-HARDWARE-CODESIGN.md); zzeng — **research map** |

### Промпт-шаблон (research context)

```text
Topic: superscalar stack CPU (research, zzeng distill).
Not a shipping frules target. Contrast with J1: fixed stack, no OoO.
For application code: use Gforth + forth-*.mdc, not fictional bmk ISA.
Historical precedent: Elbrus-1 operand stack (СтОп) + OoO.
```

---

## 9. Заблуждения (дополнение к §12 hub)

| Утверждение | Верно? |
|-------------|--------|
| Стековый ISA ⇒ данные только на аппаратном стеке | **нет** — zzeng/Эльбрус: внутренние регистры |
| Суперскалярный стек zzeng = J1 | **нет** |
| Forth на MCU медленный, потому что «стековый» | **нет** — STC + RAM stacks; узкое место — MCU, не модель |
| Loop nesting всегда быстрее | **нет** — может мешать `/fp:fast` vectorizer |
| Bookmarks — стандартное слово Forth | **нет** — ISA research; аналог — locals |
| Эльбрус = Burroughs clone | **нет** — tagged VM, segments, свой call protocol |
| Register renaming обязателен для OoO стека | **нет** — Эльбрус: scoreboard |

Полный список заблуждений про J1/REPL/VM: [FORTH-SYSTEM-ARCHITECTURE.md](FORTH-SYSTEM-ARCHITECTURE.md) §12.

---

## Связанный стек

| Вопрос | Документ |
|--------|----------|
| Класс 0, оси ISA/Forth/runtime | [FORTH-SYSTEM-ARCHITECTURE.md](FORTH-SYSTEM-ARCHITECTURE.md) §9.1 |
| J1 контракт | §11.1 |
| Исторические CPU (NC4016, J1, …) | [FORTH-HARDWARE-CODESIGN.md](FORTH-HARDWARE-CODESIGN.md) §11 |
| Shallow stack в коде | `rules/forth-stack.mdc`, `forth-factoring.mdc` |

---

*Дистилляция для frules. Обновлять при добавлении первоисточников в `sources/` или новых case studies.*

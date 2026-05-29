# Доменные диалекты (слой 0)

> **English:** [FORTH-DIALECT-LAYERS-eng.md](FORTH-DIALECT-LAYERS-eng.md)

Forth **изначально** допускает поверх postfix-ядра **другой синтаксис** — не как «другой язык», а как **именованный, версионированный фасад**, который на этапе загрузки/компиляции разворачивается в обычные слова словаря.

Типичное именование: **FORTH-&lt;домен&gt;** — например **FORTH-BASIC**, **FORTH-Pascal**, **FORTH-HDL** — где префикс `FORTH-` означает «диалект, реализованный средствами Forth», а не отдельный runtime.

**Связанные документы:** [FORTH-ANS-PORTABILITY-LAYER](FORTH-ANS-PORTABILITY-LAYER.md) (слои 1–3) · [FORTH-SYSTEM-ARCHITECTURE](FORTH-SYSTEM-ARCHITECTURE.md) · [`forth-meta.mdc`](../rules/forth-meta.mdc) · [`forth-defining.mdc`](../rules/forth-defining.mdc) · [`forth-system-context.mdc`](../rules/forth-system-context.mdc)

---

## Содержание

1. [Идея](#1-идея)
2. [Место в модели слоёв](#2-место-в-модели-слоёв)
3. [Как это делается в Forth](#3-как-это-делается-в-forth)
4. [Три глубины (не путать)](#4-три-глубины-не-путать)
5. [Дисциплина: спецификация FORTH-X](#5-дисциплина-спецификация-forth-x)
6. [ANS и environmental dependencies](#6-ans-и-environmental-dependencies)
7. [Снижение «нишевости» без подмены ядра](#7-снижение-нишевости-без-подмены-ядра)
8. [Для агента и датасета](#8-для-агента-и-датасета)

---

## 1. Идея

Postfix и стек — **нотация ядра** и **лицо реализации**. Для предметной области или для аудитории, которой postfix мешает, принят приём:

> **внешний синтаксис → parsing / compile words → colon definitions / prim / IR**

«Мета» на поверхности выглядит **чужеродно** (как макросы в других языках), но в Forth это **штатный механизм**: `IMMEDIATE`, parsing words, `[`/`]`, recognizers, defining words — не хак библиотеки, а часть системы.

**FORTH-&lt;домен&gt;** — не обязательство клонировать чужой язык целиком. Это **контракт**: какой текст принимается, во что он компилируется, какие environmental dependencies объявлены.

---

## 2. Место в модели слоёв

Полная схема (см. [FORTH-ANS-PORTABILITY-LAYER](FORTH-ANS-PORTABILITY-LAYER.md)):

```mermaid
flowchart TB
    subgraph L0 ["Слой 0 — Доменный диалект (FORTH-X)"]
        DIAL["Parsing / compile facade\nFORTH-HDL, FORTH-BASIC, …"]
    end
    subgraph L1 ["Слой 1 — Алгоритмы (ANS)"]
        ALG["`: sort` `: crc16` …"]
    end
    subgraph L2 ["Слой 2 — Адаптеры / shim"]
        SHIM["compat/*.fs, I/O glue"]
    end
    subgraph L3 ["Слой 3 — Платформа (FMAP + железо)"]
        PLAT["MM, EX-C, RP, prim, cross"]
    end
    L0 --> L1 --> L2 --> L3
```

| Слой | Содержание | Переносимость |
|------|------------|---------------|
| **0. Доменный диалект** | Синтаксис-фасад, compile-time развёртывание | **По спецификации FORTH-X** (environmental dependency) |
| **1. Алгоритмы** | ANS colon definitions | Между target с теми же wordsets |
| **2. Адаптеры** | Thin shims, compat | Редко меняется |
| **3. Платформа** | FMAP, драйверы, prim | Меняется при смене железа |

**FMAP** по-прежнему описывает **слой 3**. Диалект слоя 0 **не отменяет** Harvard, STC или cross — он только задаёт, **как пользователь или генератор** попадает в слои 1–3.

---

## 3. Как это делается в Forth

Механизмы (подробнее — [`forth-meta.mdc`](../rules/forth-meta.mdc), [`forth-defining.mdc`](../rules/forth-defining.mdc)):

| Механизм | Роль в FORTH-X |
|----------|----------------|
| **Parsing words** | Читают чужой или декларативный текст до маркера конца блока |
| **`IMMEDIATE` / compile-only** | Разная семантика на load-time и run-time |
| **`POSTPONE`, `[`/`]`** | Встраивание вычислений на этапе компиляции |
| **Defining words** | Шаблон «создать сущность домена → слово в словаре» |
| **Recognizers** (Gforth) | Альтернативная лексика без ломки outer interpreter |

Итог всегда один: **словарь Forth** (colon defs, иногда prim или таблицы данных). Отдельной VM для «FORTH-BASIC» не требуется — требуется **компилятор подмножества** или **транспилятор** в слой 1.

---

## 4. Три глубины (не путать)

| Глубина | Суть | Типичный исход |
|---------|------|----------------|
| **A. Фасад синтаксиса** | Другой текст → те же colon words | Снижение порога входа; стек скрыт внутри сгенерированного кода |
| **B. Доменное подмножество** | Фиксированная грамматика под задачу (HDL, конфиг ECU, таблицы) | Спецификация + golden-тесты на развёртывание |
| **C. Полный хост чужого языка** | Семантика, типы, GC как у оригинала | Обычно **не** цель Forth; слишком дорого |

Идеологически Forth силён в **A** и **B**. Имя **FORTH-Pascal** чаще означает **B** (lite), а не Free Pascal.

---

## 5. Дисциплина: спецификация FORTH-X

Без спецификации каждый проект изобретает свой «BASIC» — **Вавилон в одном словаре**. Минимум для любого **FORTH-X**:

1. **Идентификатор и версия** — `FORTH-HDL v0.3`, не «просто слова в проекте».
2. **Границы блока** — какие слова открывают/закрывают диалект.
3. **Развёртывание** — во что компилируется (colon, data, IR); stack effects **на границе** блока.
4. **Environmental dependencies** — что должно быть в словаре до загрузки.
5. **Golden / regression** — исходник диалекта → ожидаемый слой 1 или артефакт.

Один **стандарт на домен** важнее десяти ad-hoc синтаксисов.

---

## 6. ANS и environmental dependencies

**ANS** — контракт **слоя 1** (алгоритмы, control, memory model words).

**FORTH-X** — **environmental dependency** слоя 0, по той же логике, что wordsets в ANS Appendix C:

```text
Environmental dependencies: FORTH-HDL v0.3
Required before load: hdl-module, hdl-assign, …
```

Переносимость **исходника на FORTH-X** = наличие той же спецификации FORTH-X на target, а не «любой Forth понимает этот текст».

Переносимость **алгоритмов после развёртывания** — по правилам [FORTH-ANS-PORTABILITY-LAYER](FORTH-ANS-PORTABILITY-LAYER.md).

---

## 7. Снижение «нишевости» без подмены ядра

| Роль | Что видит | Что остаётся Forth |
|------|-----------|-------------------|
| Доменный автор | синтаксис FORTH-X, декларативные блоки | развёрнутый словарь |
| Автор системы | postfix, cross, prim, FMAP | ядро |
| Порт-автор | platform.fs, MM, EX-C | слой 3 |

Стековая нотация перестаёт быть **единственным UI** языка, но не исчезает из **реализации** и **отладки**.

**Риск:** слой 0 без версий и тестов. **Лекарство:** spec + golden, как для любого компилятора.

---

## 8. Для агента и датасета

- Вопрос **«как написать `: gcd`»** → `rules/forth-*.mdc`, не этот документ.
- Вопрос **«нужен ли FORTH-X / как устроены слои / ниша embedded»** → этот документ + [FORTH-SYSTEM-ARCHITECTURE](FORTH-SYSTEM-ARCHITECTURE.md), [FORTH-FMAP-GUIDE](FORTH-FMAP-GUIDE.md), [`forth-system-context.mdc`](../rules/forth-system-context.mdc).
- В SFT: учить **правила развёртывания** (слой 0 → 1), не смешивать синтаксис FORTH-X с ANS-challenges без метки dialect.

См. также [MODEL-TRAINING.md](MODEL-TRAINING.md) § Embedded и FMAP.

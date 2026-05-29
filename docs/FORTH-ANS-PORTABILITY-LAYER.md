# ANS как переносимый слой алгоритмов

> **English:** [FORTH-ANS-PORTABILITY-LAYER-eng.md](FORTH-ANS-PORTABILITY-LAYER-eng.md)

Тезис: если **алгоритмический код** держать в **ANS-подмножестве**, наработки переносятся между **любым** target — старым 6502, STM8, Cortex-M, Gforth на Linux или **новым** soft-CPU на FPGA. FMAP описывает **платформу**; ANS — **общий язык алгоритмов** поверх неё.

**Связанные документы:** [FORTH-DIALECT-LAYERS](FORTH-DIALECT-LAYERS.md) (слой 0) · [`forth-portability.mdc`](../rules/forth-portability.mdc) · [FORTH-FMAP-GUIDE](FORTH-FMAP-GUIDE.md) · [FORTH-HARDWARE-CODESIGN](FORTH-HARDWARE-CODESIGN.md) · [FORTH-FEATURE-COMPLEXITY](FORTH-FEATURE-COMPLEXITY.md)

---

## Содержание

1. [Идея](#1-идея)
2. [Слои 0–3](#2-слои-03)
3. [Что переносится](#3-что-переносится)
4. [Что остаётся на платформе](#4-что-остаётся-на-платформе)
5. [FMAP и ANS: разделение ответственности](#5-fmap-и-ans-разделение-ответственности)
6. [Co-design не ломает переносимость](#6-co-design-не-ломает-переносимость)
7. [Дисциплина разработки](#7-дисциплина-разработки)
8. [Примеры переноса](#8-примеры-переноса)
9. [Ограничения (честно)](#9-ограничения-честно)
10. [Для обучения модели](#10-для-обучения-модели)

---

## 1. Идея

Forth на разных системах **выглядит** по-разному (ITC vs STC, REPL vs frozen, Harvard vs unified). Но **постфиксные алгоритмы** — сортировка, парсинг, CRC, PID, finite-state logic — **не зависят** от того, как inner interpreter делает `NEXT` или `CALL`.

**ANS Forth** (DPANS94 и профили wordsets) задаёт:

- семантику стандартных слов;
- модель стеков и чисел;
- контракт «если слово есть, оно ведёт себя так».

Если прикладной код использует только согласованное **подмножество wordsets**, его можно:

1. Разработать на **Gforth** (RP=5, MM=U).
2. Прогнать на **FlashForth** (RP=4, STC, Harvard).
3. Cross-собрать под **custom FPGA** (RP=0, MM=V) — *если* target реализует те же wordsets.
4. Перенести на **6502** через TaliForth2 — с тем же ядром `.fs`.

**Плюс экосистемы frules:** один стиль алгоритмов (`rules/forth-*.mdc`) + явная маркировка platform-specific слоя.

---

## 2. Слои 0–3

```mermaid
flowchart TB
    subgraph L0 ["Слой 0 — Доменный диалект (FORTH-X)"]
        DIAL["Parsing / compile facade\nопционально"]
    end
    subgraph L1 ["Слой 1 — Алгоритмы (ANS)"]
        ALG["`: sort` `: crc16`\n`: pid-step` …"]
    end
    subgraph L2 ["Слой 2 — Адаптеры / shim"]
        SHIM["Environmental deps\ncompat/*.fs\nусловная компиляция"]
    end
    subgraph L3 ["Слой 3 — Платформа (FMAP + железо)"]
        PLAT["MM, EX-C, RP\nUART, PWM@, `@`/`!`\nboot, cross"]
    end
    L0 --> L1 --> L2 --> L3
```

| Слой | Содержание | Меняется при смене target? |
|------|------------|----------------------------|
| **0. Доменный диалект** | **FORTH-X** — синтаксис-фасад, развёртывание в словарь (см. [FORTH-DIALECT-LAYERS](FORTH-DIALECT-LAYERS.md)) | **По спецификации FORTH-X**; опционален |
| **1. Алгоритмы** | ANS colon definitions, структуры данных на `@`/`!` | **Нет** (если wordsets те же) |
| **2. Адаптеры** | Заголовки зависимостей, `compat/`, обёртки I/O | **Редко** (тонкий glue) |
| **3. Платформа** | FMAP, драйверы, prim, cross, карта памяти | **Да** |

**FMAP** относится только к **слою 3**. Переносимость алгоритмов — **слой 1 + дисциплина слоя 2**. Слой 0 не заменяет ANS: это **environmental dependency** поверх слоя 1.

---

## 3. Что переносится

При совпадающих **Environmental dependencies** без изменений переносятся:

| Категория | Примеры ANS-слов | Заметки |
|-----------|------------------|---------|
| Стек, факторинг | `dup` `swap` `rot` `nip` … | Универсально |
| Арифметика целая | `+` `-` `*` `/` `mod` `*/` … | Проверить размер cell |
| Логика, сравнение | `=` `<>` `<` `>` `and` `or` … | |
| Управление потоком | `if` `else` `then` `begin` `until` `case` … | |
| Циклы | `do` `loop` `+loop` | |
| Память (модель данных) | `@` `!` `c@` `c!` `+!` `create` `,` `allot` | Адреса — через слой 2 |
| Строки (если есть STRING) | `place` `count` `find` … | Подмножество на embedded |
| Double (если есть DOUBLE) | `d+` `d*` … | См. `forth-numeric.mdc` |
| Locals ANS (если есть LOCALS) | `(local)` `locals|` | Не Gforth `{ }` |
| Исключения (если есть EXCEPTION) | `throw` `catch` | Коды согласовать |

**Алгоритмы frules-challenges** (gcd, sort, parse) — типичный **слой 1**: они не знают про STM8 и J1.

---

## 4. Что остаётся на платформе

| Не переносится «как есть» | Почему | Где жить |
|---------------------------|--------|----------|
| `KEY` / `EMIT` vs `?RX` / `TX!` | Разный I/O | Слой 2: `io.fs` |
| `open-file`, paths | Нет FILE на MCU | Слой 2 или `#ifdef` wordset |
| `{ locals }` Gforth | Не ANS | Только Gforth или shim |
| `CODE` / asm inline | CPU-specific | Слой 3 |
| `PWM@` / custom prim | Ваше железо | Слой 3; алгоритм вызывает через слой 2 |
| `HERE ,` в Flash | Harvard / NVM path | Слой 3; compile policy |
| Threading (ITC/STC) | Engine internal | **Не виден** слою 1 |
| REPL / QUIT | RP | Слой 3 |

**Правило:** если слово **не в ANS** и **не в declared wordsets** — оно **не** в слое 1.

---

## 5. FMAP и ANS: разделение ответственности

```
FMAP отвечает на:  «КАК устроена система?»
ANS отвечает на:   «ЧТО означает этот алгоритм?»
```

| Вопрос | Инструмент |
|--------|------------|
| Нужен ли REPL в поле? | FMAP **RP** |
| STC или ITC? | FMAP **EX-C** (алгоритму всё равно) |
| Есть ли FILE? | ANS wordset + FMAP **RP**/Flash |
| Перенесётся ли `: heapsort`? | ANS CORE + ARRAY/STRING deps |
| Custom ECU registers? | FMAP **+HW**; алгоритм через `: read-rpm` shim |

Таблица «target → FMAP» ([profiles JSON](../data/forth-fmap-profiles.json)) **не заменяет** ANS-профиль wordsets вашего приложения.

### ANS-профиль приложения (рекомендуется в README проекта)

```text
Required wordsets: CORE CORE-EXT STRING EXT
Optional: EXCEPTION DOUBLE
Forbidden extensions: Gforth { } (use LOCALS| or stack)
Environmental: cell=16 on AVR targets; cell=32 on ARM
```

---

## 6. Co-design не ломает переносимость

Custom железо ([HARDWARE-CODESIGN](FORTH-HARDWARE-CODESIGN.md)) меняет **слой 3**, не **семантику** `: +` или `: find-tag`.

Стратегия:

1. **Prim / MMIO** — только в `platform.fs` (слой 3).
2. **Драйверы** — thin colon words с ANS stack effects (слой 2).
3. **Стратегия ECU / NN schedule** — ANS алгоритмы (слой 1).

```forth
\ platform.fs (слой 3 — custom FPGA)
: inj!  ( n ch -- )  ... hardware ... ;

\ engine.fs (слой 1 — переносимо, если числа те же)
: fire-cylinder  ( ch duty -- )
    inj!  ;
```

На **Gforth** для симуляции `inj!` пишется как `drop drop` или mock — **тот же** `engine.fs` гоняется в CI.

**Co-design + ANS:** вы проектируете **узкое железо**, но **широкий** алгоритмический словарь стандартными словами — переносимость сохраняется.

---

## 7. Дисциплина разработки

### 7.1 Структура каталогов (рекомендация)

```
src/
  algo/           \ слой 1 — только ANS
  compat/         \ слой 2 — shims
  platform/
    gforth/       \ слой 3
    flashforth/
    my-fpga/
```

### 7.2 Заголовок каждого файла слоя 1

```forth
\ Environmental dependencies: CORE EXT STRING
\ No implementation-defined words beyond ANS usage notes.
```

### 7.3 Проверка перед переносом

```forth
include ans-report.fs
include src/algo/heapsort.fs
print-ans-report
```

См. [`forth-portability.mdc`](../rules/forth-portability.mdc).

### 7.4 Разработка «сверху вниз»

1. Алгоритм на **Gforth** + ans-report → зелёный.
2. Mock platform (stdio вместо UART).
3. Целевой target: только **platform/** меняется.
4. FMAP фиксирует, **какой** target (не содержание алгоритма).

---

## 8. Примеры переноса

### Один модуль — три target

| Target | FMAP (кратко) | Меняется |
|--------|---------------|----------|
| Gforth Linux | U / RP=5 | `platform/gforth/io.fs` |
| FlashForth AVR | S / RP=4 / STC | `platform/flashforth/io.fs` |
| J1 FPGA | V / RP=0 | `platform/j1/io.fs` + cross |

**Общее:** `algo/*.fs` — **идентично** (при 16-bit cell на AVR — проверить numeric range).

### Старый и новый target

| «Старый» | «Новый» | Что общее |
|----------|---------|-----------|
| 6502 TaliForth2 | Cortex Mecrisp | ANS CORE алгоритмы |
| stm8ef | custom ECU FPGA | слой 1 если wordsets + cell size |
| FIG-Forth 1979 | Gforth 2026 | идея переноса; wordsets уточнить |

**Историческая связь:** ANS formalized то, что сообщество **уже** практиковало — factor words, portable core.

---

## 9. Ограничения (честно)

ANS **не** делает переносимым автоматически:

| Ограничение | Следствие |
|-------------|-----------|
| Embedded **не полный ANS** | Declare minimum wordsets; `#require` или `environment?` |
| **Cell size** 16 vs 32 vs 64 | Алгоритмы с битами — `cells`, тесты на обоих |
| **Отсутствие FP / FILE / LOCALS** | Упростить algo или добавить compat |
| **Timing / IRQ** | Real-time — слой 3; ANS не про microseconds |
| **Семантика implementation-defined** | `@`/`!` alignment — `forth-memory.mdc` |
| **Gforth habits** | `{ }`, `s\"`, dynamic strings — не ANS по умолчанию |

**ANS — не «write once run anywhere» как JVM**, а **«one algorithm, explicit dependencies, swap platform dir»**.

FMAP помогает **не путать** platform constraints с algorithm bugs.

---

## 10. Для обучения модели

При SFT разделять в контексте:

```text
Layer 1 (portable): ANS CORE+STRING — implement heapsort, no platform words.
Layer 3 (target): FMAP stm8ef MM=D EX-C=S — only if generating platform/io.fs.
```

**Модель не должна:**

- смешивать `{ locals }` в «portable algo» без пометки;
- генерировать HAL-стиль C в Forth для переносимого слоя;
- assume FILE на embedded без `environment?`.

**Модель должна:**

- документировать **Environmental dependencies**;
- предлагать **platform/** отдельно от **algo/**;
- использовать FMAP только для слоя 3.

---

## Резюме

| Утверждение | Верно? |
|-------------|--------|
| ANS делает алгоритмы переносимыми между target | **Да**, при дисциплине слоёв и wordsets |
| FMAP мешает переносимости | **Нет** — описывает другой слой |
| Co-design = уникальный непереносимый код | **Нет** — железо в слое 3, algo в ANS |
| Gforth-challenges = universal algo layer | **Да** для CORE; dialect — Gforth |
| Старый 6502 и новый FPGA делят algo | **Да**, если оба реализуют нужные wordsets |

**Практический вывод frules:** держите **алгоритмическую библиотеку в ANS**, **platform adapters** тонкими, **FMAP** — для выбора и документирования железа, не для переписывания sort/gcd на каждом MCU.

---

*Hand-authored для frules. Правила кода: [`forth-portability.mdc`](../rules/forth-portability.mdc).*

# Макет dev.to — frules RU (Part 2)

Визуальная карта поста после вычитки [`theses.md`](theses.md). Текст: [`article.md`](article.md) → paste: [`devto-publish.md`](devto-publish.md).

**Цель длины:** ~2500–4000 слов (`wc -w article.md`).

---

## Above the fold (первый экран)

```
┌─────────────────────────────────────────────────────────────┐
│ H0  Forth заставил поскрипеть шестерёнки… (title dev.to)    │
├─────────────────────────────────────────────────────────────┤
│ Subtitle (курсив, 1 абзац)                                  │
│   Часть 2 после fmix EN · postfix · eval не LoRA            │
├─────────────────────────────────────────────────────────────┤
│ § Hook — 3 абзаца                                           │
│   • Copilot vs Forth · Opus · LoRA · gforth                 │
│   • «Орешек» для нейросетей · искал Forth-SFT дома — нет    │
│   • frules + тесты как судья · F0 tease → Track A           │
└─────────────────────────────────────────────────────────────┘
```

**Теги:** `#forth` `#ai` `#cursor` `#tooling` `#opensource` `#machinelearning`  
**Series:** fmix Part 1 (EN)  
**Canonical:** https://github.com/VitaSound/frules

---

## Поток скролла (секции ↔ медиа)

| # | Секция | ~абзацев | Медиа | Статус |
|---|--------|----------|-------|--------|
| — | Hook | 4 | — | текст ✓ |
| 2 | frules punchline | 5 + bash | — | текст ✓ |
| 3 | Fail → R&D | 2 + table×2 + text diagram | — | текст ✓ |
| 4 | 5 стадий + vibe | 3 | **invoice** | PNG автор |
| 5 | Словарь ML | 2 + table + diagram | — | мемы **вырезаны** |
| 6 | Postfix / IR | 6 | **ir-vs-forth.svg** | SVG ✓ |
| 7 | Cursor = сервис | 2 + diagram | **cursor-loop.svg** | SVG ✓ |
| 8 | Завод | 2 + diagram | **factory.svg** | SVG ✓ |
| 9 | Track A F0–F7 | 8 + table sidebar | — | текст ✓ |
| 10 | Роль инженера | 2 | — | текст ✓ |
| 11 | Локальный завод | 3 + table + diagram | — | WASM Phase 1 ✓ |
| 13 | **Вторая неделя** | 6 + table eco + A/B шаблон | — | devto-publish ✓ |
| 13a | V100 / NVLink / verify-before-buy | 3 | — | внутри §13 |
| 12 | Palmer | цитата | **palmer**.png | PNG автор |
| — | Источники | списки ссылок | — | текст ✓ |

**Итого картинок в макете: 5** (3 SVG + 2 PNG must-have). Optional мемы/hero/stages/vibe — **не в макете** (убраны из `article.md`).

---

## Размещение картинок (wireframe)

```
Hook
  │
frules + install.sh
  │
Fail → R&D ──────────────── [таблица хронология]
  │                        [таблица May sprint]
  │                        «6 дней — не жалею»
  │
5 стадий ────────────────── [cursor-invoice.png]  ← must-have
  │   vibe текст (без мемов)
  │
Словарь LoRA/RAG/rules ──── [text diagram only]
  │
Postfix ─────────────────── [ir-vs-forth.svg]
  │   BFS / rot пример (код)
  │
Cursor ──────────────────── [cursor-loop.svg]
  │
Завод ───────────────────── [factory.svg]
  │
Track A ─────────────────── F0 «пук» → F1 → F2 (код infer) → F3 → F6 → sidebar
  │
Инженер
  │
Локальный завод ─────────── Phase 1: WASM
  │
Побочные продукты (май) ─── таблица repos
  │
коротко (антипаттерны)
  │
§13 Вторая неделя ───────── экосистема feco/fmcp · Auto · V100 · A/B TBD
  │
Palmer ──────────────────── [palmer-burn-after-reading.png]  ← must-have
  │
Источники
```

---

## Track A — блок-схема в тексте

```
F0  «скормлю всё» ──► пук
         │
F1  fake loss (random words, не код)
         │
F2  честный fail (Forth-форма, gforth FAIL) + пример infer
         │
F3  Opus + invoice + «мейнстрим» с гигантами IT
         │
F6  gforth судья (без драмы segfault) — спокойный fail
         │
sidebar: F4 RAG · F5 mono=стажёр · F7 траты vs активы
```

---

## Что автор добавляет вручную (`images/`)

| Файл | Где вставить | Действие |
|------|--------------|----------|
| `cursor-invoice.png` | После § «5 стадий», перед «Словарь» | Скрин Billing, замазать личное |
| `palmer-burn-after-reading.png` | Финал перед «Источники» | Кадр Palmer |

SVG уже в репо — на dev.to: drag-drop или export PNG 1200px.

---

## dev.to editor checklist

1. Title = H0 из [`PUBLISH.md`](PUBLISH.md) (без сокращения или осознанно).
2. Вставить `devto-publish.md` целиком.
3. Заменить `![](images/…)` на CDN URL после upload (или drag-drop — dev.to перепишет).
4. Preview mobile: таблицы §3 и §11 — узкие экраны; при ломании — сократить колонку «Код*».
5. [`PROOFREAD-CHECKLIST.md`](PROOFREAD-CHECKLIST.md) — финальный прогон.

---

## Синхронизация файлов

```bash
cp docs/draft-devto-frules-ru/article.md docs/draft-devto-frules-ru/devto-publish.md
wc -w docs/draft-devto-frules-ru/article.md
```

---

## После RU

EN по [`en-outline.md`](en-outline.md) — перевод автором, cross-link RU ↔ EN ↔ fmix.

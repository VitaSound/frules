# Публикация на dev.to (frules RU, Part 2)

## Файлы

| Файл | Назначение |
|------|------------|
| [`article.md`](article.md) | Рабочий черновик (редактировать здесь) |
| [`devto-publish.md`](devto-publish.md) | Paste-ready копия для dev.to |
| [`theses.md`](theses.md) | Тезисы §1–§12 + F0–F7 для личного голоса |
| [`PROOFREAD-CHECKLIST.md`](PROOFREAD-CHECKLIST.md) | Чеклист перед публикацией |
| [`images/`](images/) | SVG + placeholders (см. README) |
| [`en-outline.md`](en-outline.md) | Outline для EN-перевода автором |

## Шаги

### 1. Вычитка

1. Пройти [`PROOFREAD-CHECKLIST.md`](PROOFREAD-CHECKLIST.md).
2. Личный голос — в [`theses.md`](theses.md) (влит в `article.md`); макет: [`LAYOUT.md`](LAYOUT.md).
3. Синхронизировать: `cp article.md devto-publish.md`.

### 2. Картинки

**Must-have** (добавить в `images/`):

- `cursor-invoice.png` — billing, замазать личное
- `palmer-burn-after-reading.png` — финал

**Уже в репо:** `ir-vs-forth.svg`, `cursor-loop.svg`, `factory.svg`

На dev.to: Settings → Upload image → заменить `![](images/…)` на CDN URL **или** drag-drop в редакторе (dev.to перепишет URL).

Optional мемы — см. [`images/README.md`](images/README.md). Без файла — удалить строку `![…]` из текста.

### 3. Создать пост

1. https://dev.to/new
2. **Title:** `Forth заставил поскрипеть шестерёнки нейросетей (и мой Cursor-счёт). Fail недели и frules`
3. Вставить содержимое [`devto-publish.md`](devto-publish.md) (Markdown).
4. **Tags:** `forth`, `ai`, `cursor`, `tooling`, `opensource`, `machinelearning`
5. **Series:** связать с [fmix Part 1](https://dev.to/ua3mqj/fmix-a-package-manager-for-forth-37ld) если доступно.
6. **Canonical URL:** `https://github.com/VitaSound/frules` (optional)
7. Preview → Publish

### 4. После публикации

- Добавить ссылку RU-поста в README frules / CHANGELOG
- EN-версия — по [`en-outline.md`](en-outline.md), cross-link RU ↔ EN ↔ fmix EN

## Title / subtitle для dev.to

**Title (H0):** Forth заставил поскрипеть шестерёнки нейросетей (и мой Cursor-счёт). Fail недели и frules

**Subtitle (первая строка курсива):** Часть 2 после fmix. Postfix, gforth и честный eval вместо «ещё одного LoRA».

## Не включать в пост

- Meta про «зачем fail-format»
- West vs Russia postmortem
- Секцию «Для публикации» — она только в этом README

# Иллюстрации для dev.to (frules RU)

Путь относительно [`article.md`](../article.md): `images/…`

## Must-have (автор добавляет вручную)

| Файл | Описание | Источник |
|------|----------|----------|
| `cursor-invoice.png` | Cursor billing, on-demand ~$102, thinking-xhigh | Скрин из Cursor Settings → Billing; **замазать** личные данные |
| `palmer-burn-after-reading.png` | Кадр «После прочтения сжечь» (Palmer) | Кадр из фильма или мем; финал поста |

## SVG (готовы в репо)

| Файл | Где в тексте |
|------|--------------|
| `ir-vs-forth.svg` | § Postfix — две колонки ❌ vs ✓ |
| `cursor-loop.svg` | § Cursor — User → Agent loop → gforth |
| `factory.svg` | § Завод — pipeline Human → … → TESTS OK |

На dev.to: загрузить SVG как есть или экспортировать в PNG 1200px wide.

## Optional (вне макета v1)

Мемы и hero **не** в [`LAYOUT.md`](../LAYOUT.md) — строки `![…]` убраны из `article.md`. Если позже добавите файл — вставьте картинку вручную в нужную секцию по макету.

## dev.to upload

1. New post → Markdown mode.
2. Drag-drop images или `![alt](uploaded_url)` после upload.
3. GitHub raw URLs для SVG работают, но dev.to CDN надёжнее для финала.

# Чеклист вычитки (автор)

Перед публикацией RU на dev.to. Источник: [`article.md`](article.md), тезисы: [`theses.md`](theses.md).

## Голос и тон

- [ ] Прочитать вслух §1 и § Track A — звучит как **ты**, не как AI?
- [ ] Заполнить `[…]` в [`theses.md`](theses.md) или перенести в `article.md` и удалить placeholders
- [ ] «Пук» (F0) — один раз, по-разговорному; не повторяется?
- [ ] Нет meta про «зачем fail-format» и West vs Russia postmortem?

## Факты и цифры

- [ ] **151** challenge, **98** train, **53** hold-out (не 94/145)
- [ ] Track A **закрыт**; fake loss → TRAIN_SYSTEM_SHORT
- [ ] Invoice ~$100+ — сверить с реальным скрином
- [ ] LOC в таблице §3 — порядок величины, ок?

## Картинки

- [ ] `cursor-invoice.png` — личное замазано
- [ ] `palmer-burn-after-reading.png` — финал
- [ ] SVG или PNG: ir-vs-forth, cursor-loop, factory
- [ ] Optional мемы: добавить или **вырезать** строки `![…]` из статьи

## Ссылки

- [ ] fmix EN: https://dev.to/ua3mqj/fmix-a-package-manager-for-forth-37ld
- [ ] GitHub frules + docs links открываются
- [ ] Canonical repo в bio поста: https://github.com/VitaSound/frules

## dev.to мета

- [ ] Title H0 без изменений (или осознанно сократил)
- [ ] Теги: `#forth` `#ai` `#cursor` `#tooling` `#opensource` `#machinelearning`
- [ ] Series: связать с fmix Part 1 если dev.to series доступна

## После RU

- [ ] EN — перевод **автором** по [`en-outline.md`](en-outline.md)
- [ ] Cross-link RU ↔ EN ↔ fmix EN

## Финальный прогон

```bash
wc -w docs/draft-devto-frules-ru/article.md   # цель ~2500–4000 слов
# Paste-ready: docs/draft-devto-frules-ru/devto-publish.md
```

- [ ] Скопировать из `devto-publish.md` в dev.to editor
- [ ] Preview на mobile — таблицы не ломаются?

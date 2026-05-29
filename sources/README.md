# Исходники для дистилляции

Сюда кладите книги и главы в **текстовом** виде.

## Уже добавлено

- **theForthNet packages** — [`theforth.net-packages/`](theforth.net-packages/)
  (vendored-копия репозитория [theforth.net-packages](https://github.com/theforth/theforth.net-packages)
  или аналог с [theforth.net/packages](https://theforth.net/packages)).
  Лицензии — в `package.4th` каждого пакета. Для челленджей — см.
  [`docs/AGENT-SOLVE-CHALLENGES.md`](../docs/AGENT-SOLVE-CHALLENGES.md).

  Если каталог склонирован как отдельный репозиторий (`git clone …` внутрь frules),
  Git видит **embedded repository** и добавляет gitlink вместо файлов. Исправление
  (обратно в upstream не коммитим — только vendored-копия в frules):

  ```bash
  git rm --cached -f sources/theforth.net-packages 2>/dev/null || true
  rm -rf sources/theforth.net-packages/.git
  git add sources/theforth.net-packages
  ```

- **Gforth manual — Forth Tutorial** (GNU GPL) — [`gforth-manual-tutorial/`](gforth-manual-tutorial/)
  (chapter 3 of the [Gforth manual](https://gforth.org/manual/Tutorial.html)).
  Markdown per section; refresh: `bash gforth-manual-tutorial/extract.sh`.

- **Gforth manual — full** (GNU GPL) — [`gforth-manual/`](gforth-manual/)
  ([gforth.org/manual/](https://gforth.org/manual/)); one `.md` per HTML node.
  Refresh: `bash gforth-manual/extract.sh` (uses `http(s)_proxy` when set).

- **Thinking Forth** (Leo Brodie, CC BY-NC-SA 2.0) — `brodie-thinking-forth/`,
  главы `chapter1.md` … `chapter8.md` + `appendix{a..e}.md` + `epilog.md`.
  Пересборка: `bash brodie-thinking-forth/extract.sh` (требует `pandoc`,
  `perl`, `git`). Картинки лежат в `brodie-thinking-forth/figures/` —
  они для чтения человеком; AI игнорирует, см. `docs/DISTILL-PROMPT.md`.

## Рекомендуемые имена для новых источников

```
brodie-thinking-forth.txt        (одиночный файл — для коротких выписок)
leo-forth-application-techniques-ch03.txt
starting-forth-ch01-stack.txt
```

Для целой книги с конвейером пересборки — отдельный подкаталог по образцу
`brodie-thinking-forth/` с `extract.sh` / `preprocess.pl` и `.gitignore`,
который скрывает `upstream/`.

## Что извлекать в `rules/`

- нотация стека, контракты слов;
- факторизация, структура модулей;
- defining words, состояние компиляции;
- переносимость ANS, работа с памятью;
- анти-паттерны и типичные ошибки ИИ (императивный стиль, лишние переменные, «стек как массив»).

## Что не переносить в правила

- бытовые аналогии и «истории из офиса»;
- упражнения для читателя без переноса в идиомы;
- юмор, дискуссии форума, исторические отступления;
- дублирование полного словаря ANS (есть в справочниках реализации).

После добавления файла обновите `docs/SOURCES.md` и соответствующие `.mdc` в `rules/`.

Справочники (hand-authored, не distill из `sources/`):

Hand-authored references (not distilled from `sources/`). Each has an **English** `-eng.md` twin:

- **ANS portable algorithm layer** — [`docs/FORTH-ANS-PORTABILITY-LAYER.md`](../docs/FORTH-ANS-PORTABILITY-LAYER.md) · [eng](../docs/FORTH-ANS-PORTABILITY-LAYER-eng.md)
- **Hardware + Forth co-design** — [`docs/FORTH-HARDWARE-CODESIGN.md`](../docs/FORTH-HARDWARE-CODESIGN.md) · [eng](../docs/FORTH-HARDWARE-CODESIGN-eng.md)
- **Using FMAP** — [`docs/FORTH-FMAP-GUIDE.md`](../docs/FORTH-FMAP-GUIDE.md) · [eng](../docs/FORTH-FMAP-GUIDE-eng.md)
- **System architecture, FMAP** — [`docs/FORTH-SYSTEM-ARCHITECTURE.md`](../docs/FORTH-SYSTEM-ARCHITECTURE.md) · [eng](../docs/FORTH-SYSTEM-ARCHITECTURE-eng.md); profiles — [`data/forth-fmap-profiles.json`](../data/forth-fmap-profiles.json)
- **Threaded code** — [`docs/FORTH-THREADING.md`](../docs/FORTH-THREADING.md) · [eng](../docs/FORTH-THREADING-eng.md); models — [`data/forth-threading-models.json`](../data/forth-threading-models.json)
- **Feature implementation cost** — [`docs/FORTH-FEATURE-COMPLEXITY.md`](../docs/FORTH-FEATURE-COMPLEXITY.md) · [eng](../docs/FORTH-FEATURE-COMPLEXITY-eng.md)

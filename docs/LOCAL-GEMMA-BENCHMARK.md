# Локальный бенчмарк: Gemma 4 + frules

Как прогнать `tests/challenges/` через **локальную** Gemma 4 (Ollama) и сравнить
результат **с правилами** и **без**. Общий протокол челленджей —
[`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md).

## Что понадобится

| Компонент | Зачем |
|-----------|--------|
| **Gforth** | Единственный судья: `TESTS OK` / `TESTS FAILED` |
| **Ollama ≥ 0.20** | Локальный рантайм Gemma 4 |
| **Модель `gemma4:e4b`** (или крупнее) | Рекомендуемый старт для ноутбука (~9.6 GB) |
| **Cursor** (или другой клиент с OpenAI API) | Чат с подключёнными `.mdc` правилами |
| **frules** | `./install.sh` → симлинки в `.cursor/rules/` |

Проверка Gforth:

```bash
command -v gforth && gforth -e "bye"
```

## 1. Развернуть Gemma 4 (Ollama)

### Установка Ollama

- Linux: `curl -fsSL https://ollama.com/install.sh | sh`
- macOS / Windows: установщик с [ollama.com](https://ollama.com)

Убедитесь, что версия поддерживает Gemma 4:

```bash
ollama --version   # нужно 0.20.0 или новее
```

### Скачать и проверить модель

```bash
ollama pull gemma4:e4b
ollama list | grep gemma4
```

Быстрый smoke-test (без Cursor):

```bash
ollama run gemma4:e4b "Reply with exactly: OK"
```

API (должен отвечать JSON):

```bash
curl -s http://localhost:11434/api/chat -d '{
  "model": "gemma4:e4b",
  "stream": false,
  "messages": [{"role": "user", "content": "Say OK"}]
}' | head -c 400
echo
```

Сервис по умолчанию: `http://localhost:11434` (OpenAI-совместимый префикс `/v1`).

### Варианты по железу

| Тег | RAM/VRAM (ориентир) | Когда брать |
|-----|---------------------|-------------|
| `gemma4:e2b` | ~8 GB | слабый ноутбук |
| `gemma4:e4b` | ~8–16 GB | **старт для бенчмарка** |
| `gemma4:26b` | ~18 GB+ | десктоп с GPU |
| `gemma4:31b` | ~20 GB+ | максимум качества |

На Apple Silicon при зависаниях на длинных ответах см. [ollama#15368](https://github.com/ollama/ollama/issues/15368) (Flash Attention / streaming) — для Forth-челленджей обычно хватает коротких ответов.

---

## 2. Подключить frules (правила **ВКЛ**)

Из корня репозитория (или вашего Forth-проекта):

```bash
cd /path/to/frules    # или ваш проект с челленджами
./install.sh . gforth
```

Проверка:

```bash
ls -la .cursor/rules/
# должны быть симлинки на rules/forth-*.mdc и frules-dialect.mdc
```

В Cursor:

1. Откройте репозиторий как workspace.
2. Откройте любой `.fs` (например `tests/challenges/01-clamp.fs`) — сработают `globs` у `.mdc`.
3. **Settings → Models** (или **Cursor Settings → Models**):
   - включите использование **custom / OpenAI-compatible** endpoint;
   - **Base URL:** `http://localhost:11434/v1`
   - **API Key:** `ollama` (любая непустая строка; Ollama не проверяет)
   - **Model name:** точно как в `ollama list`, например `gemma4:e4b`
4. В чате выберите эту модель (не облачный Composer/GPT).

> Если в UI нет поля Base URL: обновите Cursor или используйте раздел
> **«OpenAI API Key» + Override OpenAI Base URL** (название пункта меняется
> между версиями). Смысл один: запросы уходят на `localhost:11434/v1`.

Правила **не** подгружаются автоматически из текста «см. forth-style.mdc» —
их даёт только каталог `.cursor/rules/` после `install.sh`.

---

## 3. Отключить frules (правила **ВЫКЛ**, baseline)

Нужен для сравнения «модель сама» vs «модель + frules». Любой **один** способ:

### A. Переименовать каталог (надёжно)

```bash
cd /path/to/frules
mv .cursor/rules .cursor/rules.frules-off
```

Включить обратно:

```bash
./install.sh . gforth
# или: mv .cursor/rules.frules-off .cursor/rules
```

### B. Удалить только симлинки frules

```bash
rm -f .cursor/rules/frules-dialect.mdc .cursor/rules/forth-*.mdc .cursor/rules/frules-index.mdc
```

Восстановление: `./install.sh . gforth`

### C. Профиль `core` (меньше правил, не «ноль»)

```bash
./install.sh . gforth core
```

Остаются `forth-anti-patterns`, `forth-stack`, `forth-style` — это **не** полный baseline.

### D. Отключить в Cursor UI

**Cursor Settings → Rules** — выключить *Project Rules* / *Include .cursor/rules*
(формулировка зависит от версии). Удобно для одного прогона без трогания диска.

### E. Отдельный клон без `install.sh`

Скопировать репозиторий, **не** запускать `install.sh`, открыть в Cursor — правил нет.

---

## 4. Прогон одного челленджа (Gemma + Cursor)

1. **Новый чат** (не продолжение старого).
2. Убедитесь, что выбрана модель **gemma4:e4b** (Ollama), не облако.
3. Откройте файл `tests/challenges/01-clamp.fs` или приложите `@tests/challenges/01-clamp.fs`.
4. Вставьте промпт (из [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md)):

```
Solve the Forth challenge in tests/challenges/01-clamp.fs.

- Implement only the word named in the CHALLENGE header.
- Paste the definition between the two "=== paste your solution ===" lines.
- Follow stack-effect comments on every colon definition you add.
- Obey the Style guard lines in the file header.
- Do not read tests/ans/, tests/gforth/, or examples/.
- Do not change the T{ }T assertions or scaffold.
- Gforth; ANS + Gforth locals allowed where the challenge allows it.
```

5. **Не ждите** конца «мышления». Как только в логе есть правка файла — **Stop**.
6. Проверка **всегда** вручную:

```bash
cd tests/challenges
gforth 01-clamp.fs
```

| Вывод | Засчитывать |
|--------|-------------|
| `TESTS OK` | Pass |
| `Undefined word` | Fail (решение не вставлено или не то имя) |
| `INCORRECT RESULT` / `STRINGS NOT EQUAL` | Fail |
| `TESTS FAILED: N` | Fail |

7. Запишите строку в [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) (таблица Run).

Повторите для `02` … `06` — **отдельный чат на файл**.

### A/B: с правилами vs без

| Прогон | Действие перед чатом |
|--------|----------------------|
| **A (frules on)** | `./install.sh . gforth` |
| **B (baseline)** | `mv .cursor/rules .cursor/rules.frules-off` |

Одинаковый промпт, та же модель `gemma4:e4b`, те же челленджи. Сравните счёт `N/6`.

---

## 5. Без Cursor: только Ollama API (опционально)

Если Cursor не видит локальную модель, можно собрать system prompt из правил
и слать `curl` (менее удобно, но воспроизводимо).

Сборка system prompt (frules on):

```bash
cd /path/to/frules
{
  echo "You are a Forth expert. Follow these rules:"
  for f in rules/frules-index.mdc rules/forth-*.mdc templates/frules-dialect-gforth.mdc; do
    [ -f "$f" ] && sed '1,/^---$/d;/^---$/d' "$f"
  done
} > /tmp/frules-system.txt
```

Запрос (подставьте тело челленджа без решения):

```bash
CHALLENGE=$(sed -n '1,30p' tests/challenges/01-clamp.fs)
curl -s http://localhost:11434/api/chat -d "$(jq -n \
  --arg sys "$(cat /tmp/frules-system.txt)" \
  --arg usr "Solve this challenge. Output only Forth code between paste markers.\n\n$CHALLENGE" \
  '{model:"gemma4:e4b", stream:false,
    messages:[{role:"system",content:$sys},{role:"user",content:$usr}]}')" \
  | jq -r '.message.content'
```

Ответ вставьте между маркерами вручную → `gforth 01-clamp.fs`.

Для baseline не передавайте `$sys` (только user message).

---

## 6. Ожидаемая сложность (калибровка)

| # | Слово | Gemma 4 e4b (типично) |
|---|--------|------------------------|
| 01 | `clamp` | легко с locals |
| 02 | `min-max` | легко; ловушка «два MIN» |
| 03 | `reverse` | часто долго / ошибки индексов |
| 04 | `caesar` | часто долго / mod + два регистра |
| 05 | `balanced?` | средне |
| 06 | `roman` | тяжело (таблица / лексикон) |

Уже зафиксировано (Cursor, не Gemma): Composer 2.5 и Agent — `01` зелёный;
Agent на `02`–`04` — см. таблицу в `CHALLENGE-RUNS.md`.

---

## 7. Частые проблемы

| Симптом | Что сделать |
|---------|-------------|
| Cursor игнорирует Ollama | Проверить `curl localhost:11434/api/tags`; перезапустить Ollama; Base URL с `/v1` |
| Модель не видит правила | `ls .cursor/rules/`; открыт `.fs`; не переименован каталог |
| `include _tester.fs` not found | `cd tests/challenges` перед `gforth` |
| Gemma пишет C/Python | Уточнить в промпте: «Gforth only, postfix Forth» |
| Ответ обрывается | Увеличить `num_ctx` в Modelfile или взять `e4b`; челленджи короткие |
| Читает `tests/ans/` | Запретить в промпте; новый чат |

---

## 8. Чек-лист перед пушем результатов

- [ ] Ollama: `gemma4:e4b` отвечает в терминале
- [ ] Прогон A (rules on): `__/6` по `gforth`
- [ ] Прогон B (rules off): `__/6` по `gforth`
- [ ] Таблица в `docs/CHALLENGE-RUNS.md` обновлена (модель, дата, заметки)
- [ ] Решения **не** закоммичены в `tests/challenges/*.fs` (между маркерами пусто)

---

## См. также

- [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) — промпт, матрица, протокол Stop + `gforth`
- [`tests/challenges/README.md`](../tests/challenges/README.md) — формат файлов
- [`RULES-ARCHITECTURE.md`](RULES-ARCHITECTURE.md) — как Cursor подхватывает `.mdc`
- [`../README.md`](../README.md) — `install.sh` и диалекты

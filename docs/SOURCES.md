# Происхождение правил

> **AI-assisted FORTH docs:** блок `docs/FORTH-*.md`, `data/forth-*.json`, `rules/forth-system-context.mdc` — см. [DOC-AUTHORSHIP.md](DOC-AUTHORSHIP.md). Статус **`AI-assisted (human-directed)`**, не полная вычитка человеком.

| Файл правила | Источник | Статус |
|--------------|----------|--------|
| `forth-stack.mdc` | Starting Forth (стек, постфикс); Gforth Tutorial §3.4–§3.6, §3.11, §3.14; Gforth manual §5.1 (notation), §4.2 | seed + distilled |
| `forth-style.mdc` | forth.org/forth_coding.txt; Gforth Tutorial §3.8, §3.11 | seed + distilled |
| `forth-factoring.mdc` | Thinking Forth (Leo Brodie), главы 1, 3, 4, 6, 7, 8 | distilled |
| `forth-style.mdc` (Brodie pass) | Thinking Forth, главы 4, 5, 7 + Appendix E | distilled |
| `forth-anti-patterns.mdc` (Brodie pass) | Thinking Forth, главы 6, 7, 8; Gforth Tutorial §3.6, §3.15, §3.17, §3.22 | seed + distilled |
| `forth-naming.mdc` | Thinking Forth, глава 5 + Appendix E; Gforth Tutorial §3.12; Gforth manual §5.22.3 | distilled |
| `forth-control.mdc` | ANS / Starting Forth; Gforth Tutorial §3.16–§3.21; Gforth manual §5.4, §5.8.1–§5.8.8, §5.8.6.1 | seed + distilled |
| `forth-defining.mdc` | Starting Forth / ANS; Gforth Tutorial §3.9, §3.31–§3.32, §3.37; Gforth manual §5.9 (CREATE…alias, quotations) | seed + distilled |
| `forth-meta.mdc` | Gforth Tutorial §3.28–§3.29, §3.33–§3.34; Gforth manual §5.10–§5.12, §5.13–§5.14, §5.13.5 (recognizers), ch.8 compile-only | distilled |
| `forth-memory.mdc` | Gforth Tutorial §3.23, §3.25, §3.24; Gforth manual §5.7 (model, heap, blocks copy) | distilled |
| `forth-io.mdc` | Gforth Tutorial §3.27, §3.7; Gforth manual §5.17, §5.20, §5.17.5 (search paths) | distilled |
| `forth-strings.mdc` | Gforth Tutorial §3.24; Gforth manual §5.19.3–§5.19.5, §5.19.10 (xchars) | distilled |
| `forth-floating-point.mdc` | Gforth Tutorial §3.26; Gforth manual §5.5.6, §5.6.2 | distilled |
| `forth-numeric.mdc` | Gforth manual §5.5.1–§5.5.5, §5.19.2 (pictured output), §5.13.2 (input formats) | distilled |
| `forth-wordlists.mdc` | Gforth Tutorial §3.37; Gforth manual §5.15, §5.15.3, ch.8 search-order | distilled |
| `forth-debugging.mdc` | Gforth manual §5.24.1–§5.24.3, §5.24.5, ch.6, §7.2 | distilled |
| `forth-oof.mdc` | Gforth manual §5.23.3 (`objects.fs` basics) | distilled |
| `forth-c-bindings.mdc` | Gforth manual §5.26.1–§5.26.2 (calling/declaring C) | distilled |
| `forth-defining.mdc` (+field, queue header) | theForthNet `compat/struct.fs`, `priority-queue` | distilled (selective) |
| `forth-memory.mdc` (linked lists, bounds) | theForthNet `ll`, `bounds` | distilled (selective) |
| `forth-wordlists.mdc` (MODULE/EXPORT) | theForthNet `modules` | distilled (selective) |
| `forth-meta.mdc` ([IMMEDIATE], interpretive) | theForthNet `immediate`, `interpretive`, `recognizers` (ref) | distilled (selective) |
| `forth-stack.mdc` (auxiliary stacks) | theForthNet `stack` | distilled (selective) |
| `forth-strings.mdc` (string stack) | theForthNet `stringstack` | distilled (selective) |
| `forth-numeric.mdc` (fixed-point) | theForthNet `fixed` | distilled (selective) |
| `forth-portability.mdc` | DPANS94; Gforth Tutorial §3.25, §3.27; Gforth manual ch.8–§9, §5.16, §5.18 (legacy note), §7.1 | seed + distilled |
| `forth-dialect-gforth.mdc` | Gforth manual ch.2, ch.6, §5.8.8, §5.21–§5.22, §5.24.4; Gforth Tutorial §3.1–§3.2, §3.15, §3.30 | seed + distilled |
| `sources/brodie-thinking-forth/*.md` | Thinking Forth (Leo Brodie, CC BY-NC-SA 2.0), upstream [forthy42/thinking-forth@ans_tf](https://github.com/forthy42/thinking-forth/tree/ans_tf), конвертер `sources/brodie-thinking-forth/extract.sh` (+ `preprocess.pl`). Фигуры в `figures/` — только для глаз человека, см. `docs/DISTILL-PROMPT.md`. | vendored; дистилляция в `rules/forth-{factoring,style,anti-patterns,naming}.mdc` выполнена |
| `sources/gforth-manual-tutorial/*.md` | Gforth manual ch.3 Tutorial (GNU GPL), https://gforth.org/manual/Tutorial.html, `extract.sh` | vendored; дистилляция в `rules/*.mdc` выполнена (skip: §3.3 crash-course, §3.10 decompilation, §3.35 advanced-macros, §3.36 compilation-tokens) |
| `sources/gforth-manual/*.md` | Gforth manual полностью (GNU GPL), https://gforth.org/manual/, `extract.sh` | vendored; **полная дистилляция** actionable-идиом в `rules/*.mdc` (skip: Word Index / Concept Index как словарь, per-CPU assembler §5.27, engine internals ch.14, cross-compiler detail ch.15, Emacs ch.12, appendix prose) |
| `sources/theforth.net-packages/` | [theforth.net-packages](https://github.com/theforth/theforth.net-packages); catalog [`INDEX.md`](../sources/theforth.net-packages/INDEX.md). **Selective distillation** (2026-05): `compat/struct.fs` → `forth-defining`; `ll`, `bounds` → `forth-memory`; `priority-queue` → `forth-defining`; `modules` → `forth-wordlists`; `interpretive`, `immediate`, `recognizers` → `forth-meta`; `stack` → `forth-stack`; `stringstack` → `forth-strings`; `fixed` → `forth-numeric`. Skip: crypto, games, embedded drivers, `f` PM, duplicate `ttester`. | vendored + distilled (selective) |
| `frules-index.mdc` | precedence policy | hand-authored |
| `forth-portability.mdc` (cell size discipline) | conversation distill + DPANS94 / Gforth manual | hand-authored supplement |
| `forth-stack.mdc` (typing mental model) | Gforth Tutorial §3.12; conversation distill | hand-authored supplement |
| `docs/FORTH-ANS-PORTABILITY-LAYER.md` | ANS portable algorithm layer (RU) | AI-assisted (human-directed) |
| `docs/FORTH-ANS-PORTABILITY-LAYER-eng.md` | English translation | AI-assisted (human-directed) |
| `docs/FORTH-HARDWARE-CODESIGN.md` | Hardware-software co-design (RU) | AI-assisted (human-directed) |
| `docs/FORTH-HARDWARE-CODESIGN-eng.md` | English translation | AI-assisted (human-directed) |
| `docs/FORTH-FMAP-GUIDE.md` | Using FMAP for project selection (RU) | AI-assisted (human-directed) |
| `docs/FORTH-FMAP-GUIDE-eng.md` | English translation | AI-assisted (human-directed) |
| `docs/FORTH-SYSTEM-ARCHITECTURE.md` | Forth system architecture, FMAP (RU) | AI-assisted (human-directed) |
| `docs/FORTH-SYSTEM-ARCHITECTURE.md` §9.1, §11.1, §12 (stack CPU axes, J1) | conversation distill + J1 paper/repo | AI-assisted supplement |
| `docs/FORTH-STACK-CPU-RESEARCH.md` | zzeng Habr series (267771, 271905, 278575–281352, 313376); distill for frules KB | AI-assisted (human-directed) |
| `docs/FORTH-STACK-CPU-RESEARCH-eng.md` | English translation | AI-assisted (human-directed) |
| `docs/FORTH-SYSTEM-ARCHITECTURE-eng.md` | English translation | AI-assisted (human-directed) |
| `docs/FORTH-THREADING.md` | Threaded code models (RU) | AI-assisted (human-directed) |
| `docs/FORTH-THREADING-eng.md` | English translation | AI-assisted (human-directed) |
| `docs/FORTH-FEATURE-COMPLEXITY.md` | Feature implementation cost (RU) | AI-assisted (human-directed) |
| `docs/FORTH-FEATURE-COMPLEXITY-eng.md` | English translation | AI-assisted (human-directed) |
| `docs/FORTH-DIALECT-LAYERS.md` | Domain dialects FORTH-X, layer 0 (RU) | AI-assisted (human-directed) |
| `docs/FORTH-DIALECT-LAYERS-eng.md` | English translation | AI-assisted (human-directed) |
| `docs/DOC-AUTHORSHIP.md` | Disclaimer: AI-assisted FORTH corpus | hand-authored (human) |
| `docs/DOC-AUTHORSHIP-eng.md` | English translation | hand-authored (human) |
| `data/forth-fmap-profiles.json` | FMAP system profiles | AI-assisted (human-directed) |
| `data/forth-threading-models.json` | Threading models taxonomy | AI-assisted (human-directed) |
| `data/forth-use-case-templates.json` | Use case → FMAP templates | AI-assisted (human-directed) |
| `rules/forth-system-context.mdc` | Agent routing: architecture vs coding | AI-assisted (human-directed) |
| `frules-dialect.mdc` (installed) | `templates/frules-dialect-*.mdc` | generated by install.sh |
| `examples/gforth/*.fs` | hand-written, validated with `gforth 0.7.9` | smoke-tested by `test.sh` |
| `examples/ans/*.fs` | hand-written DPANS94, validated with `gforth + pforth 2.0.1` | smoke-tested by `test.sh` |
| `tests/ans/*.fs` | rule-coverage assertions, gforth + pforth | green via `test.sh` |
| `tests/gforth/*.fs` | rule-coverage assertions, gforth-only (locals) | green via `test.sh` |
| `tests/ttester.4th` | John Hayes (JHU/APL 1995), revisions by Anton Ertl, David N. Williams, Krishna Myneni, C. G. Montgomery — upstream `http://www.complang.tuwien.ac.at/cvsweb/cgi-bin/cvsweb/gforth/test/ttester.fs` | vendored verbatim, public domain |
| `tests/ttester-ext.4th` | VitaSound fork `https://github.com/VitaSound/ttester` (`expect-*` predicates, `TS{ … }ST` fixtures) | vendored verbatim, public domain |

Когда добавите файл в `sources/`, допишите строку и укажите, какие разделы `.mdc` обновлены.

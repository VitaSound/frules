# Gforth Manual — Forth Tutorial (chapter 3)

Vendored text of the [Gforth manual Tutorial](https://gforth.org/manual/Tutorial.html)
(GNU GPL, same as Gforth). One markdown file per section; `index.md` is the chapter
intro and table of contents.

## Layout

```
index.md                    §3 Forth Tutorial (overview)
starting-gforth.md …        §3.1–§3.37 subsections
extract.sh                  fetch upstream HTML + optional MD rebuild
upstream/                   raw HTML (gitignored)
```

## Refresh

```bash
bash extract.sh    # wget/curl from gforth.org; html2text/pandoc if installed
```

Pre-built `*.md` files are checked in so agents can read them without network.

## For AI consumers

Portable Forth tutorial (Gforth-specific bits are marked in the original).
Useful for stack notation, factoring, locals, control flow, defining words.
Cross-check Gforth-only features against `rules/forth-dialect-gforth.mdc`.

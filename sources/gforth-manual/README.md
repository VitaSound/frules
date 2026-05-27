# Gforth Manual (full)

Vendored text of the [Gforth manual](https://gforth.org/manual/) (GNU GPL, same as
Gforth). One markdown file per HTML node; `index.md` is the top page and table of
contents.

Chapter 3 (Tutorial) is also vendored separately as
[`gforth-manual-tutorial/`](../gforth-manual-tutorial/) with finer-grained section
files.

## Layout

```
index.md              top / TOC
*.md                  one file per manual node (from *.html)
extract.sh            fetch upstream HTML + rebuild markdown
pages.list            HTML filenames (regenerated from index)
upstream/             raw HTML (gitignored)
```

## Refresh

Uses the environment proxy when set (e.g. `https_proxy=http://172.25.16.1:12334`).

```bash
bash extract.sh    # curl/wget via proxy; pandoc for *.md
```

Pre-built `*.md` files are checked in so agents can read them without network.

## For AI consumers

Reference for Gforth words, environment, standard conformance, engine internals.
Prefer `rules/` and `gforth-manual-tutorial/` for idioms; use this tree for word
definitions and Gforth-specific behaviour. Do not paste manual prose into `.fs`.

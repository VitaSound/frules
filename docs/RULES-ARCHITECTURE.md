# How frules topic routing works with AI (Cursor)

Human docs may be in any language; **all executable rule bodies** under `rules/` and `templates/` are **English only**.

## What the model actually receives

Cursor (and similar IDEs) do **not** implement a full hypertext system (“open section 3.2 → fetch appendix B”). Context is assembled from **whole rule files** that match activation criteria:

| Mechanism | When it loads | Typical content |
|-----------|----------------|-----------------|
| `alwaysApply: true` | Every chat in that project | Dialect marker (`frules-dialect.mdc`) — keep tiny |
| `globs: **/*.fs` | Matching Forth sources are open / in focus | Topic modules (`forth-stack.mdc`, …) |
| `description:` | Shown in rule UI; some agent versions use it to **request** extra rules | Topic hint for the agent |
| User `@path` | You explicitly attach a file | Any doc or rule, on demand |

**Important:** A line inside rule A such as “see `forth-defining.mdc`” does **not** load B automatically. B must be activated by `alwaysApply`, `globs`, agent rule selection, or `@mention`.

## Topic-based organization (recommended)

Split knowledge into **small, single-topic** `.mdc` files (under ~80 lines). One concern per file.

```
rules/
  frules-index.mdc          # topic map (routes attention, not a hyperlink loader)
  forth-stack.mdc
  forth-style.mdc
  forth-control.mdc
  forth-defining.mdc
  forth-factoring.mdc
  forth-portability.mdc
  forth-anti-patterns.mdc
  forth-dialect-gforth.mdc
```

### Three activation strategies

**1. Bundled (default `install.sh`)**  
All topic files share the same glob, e.g. `**/*.{fth,fs}`. Opening any Forth file attaches **every** topic rule. The index tells the model which file is authoritative for which task.

- Pros: simple, nothing missed  
- Cons: larger context, more tokens

**2. Path-scoped topics**  
Tighten `globs` per topic so only relevant dirs trigger rules:

```yaml
# forth-gforth-strings.mdc
globs: "**/{strings,text,parse}/**/*.fs"
description: Gforth strings — S", $@, counted strings
```

- Pros: smaller context when editing unrelated code  
- Cons: you must align repo layout with globs; wrong path = rule missing

**3. Manual / agent-requested**  
Keep `alwaysApply: false`, narrow or no globs, strong `description`. User adds `@rules/forth-defining.mdc` or the agent pulls rules when the task clearly needs them (depends on Cursor version).

## Role of `frules-index.mdc`

The index is a **routing table**, not a dynamic loader. When several rules are already in context, it says:

- which file covers which topic;
- precedence: dialect > portability > generic;
- what to do if rules conflict.

Keep the index short. Put examples and edge cases in topic files.

## Precedence (Gforth projects)

1. `frules-dialect.mdc` (dialect marker, `alwaysApply: true`)  
2. `forth-dialect-gforth.mdc` for Gforth syntax  
3. Other `forth-*.mdc` where they do not conflict  
4. On conflict, **dialect wins**; note non-ANS choices in a one-line `\` comment

## Adding a new topic from a book

1. Add source text under `sources/`.  
2. Distill one topic → one new `rules/forth-<topic>.mdc` (English).  
3. Register it in `frules-index.mdc` and `docs/SOURCES.md`.  
4. Choose activation: shared glob (bundled) or path-specific glob.  
5. Re-run `install.sh` in target projects.

## What does *not* work well

- One 500-line mega-rule (hard to maintain, burns context)  
- Assuming markdown links auto-load other rules  
- Russian (or mixed) text inside `.mdc` bodies meant for the model  
- Duplicating the ANS dictionary (use `sources/gforth-manual/` or https://gforth.org/manual/ + project words)

## Glob caveat

`.fs` is shared with F# sources. The default `globs: "**/*.{fth,fs,4th,forth,fb}"` is safe in a Forth-only repository. In mixed repos, tighten each rule's glob to your Forth folders (e.g. `"src/forth/**/*.fs"`).

## English-only policy for AI instructions

| Path | Language |
|------|----------|
| `rules/*.mdc`, `templates/*.mdc` | English |
| `AGENTS.md` | English |
| `README.md`, `sources/README.md`, this file’s human notes | Any (Russian OK) |

When distilling books, write rule bodies in English even if the source is Russian.

## Install profiles (optional)

```bash
./install.sh . gforth          # full topic set (default)
./install.sh . gforth core     # dialect marker + stack + style + anti-patterns + gforth
```

`core` reduces token use for small projects; add topic files back as the codebase grows.

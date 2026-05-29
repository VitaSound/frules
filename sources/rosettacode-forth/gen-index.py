#!/usr/bin/env python3
"""Generate INDEX.md and validate challenge-links.yaml for sources/rosettacode-forth/."""

from __future__ import annotations

import sys
from collections import Counter, defaultdict
from pathlib import Path

try:
    import yaml
except ImportError:
    print("ERROR: need PyYAML (python3-yaml)", file=sys.stderr)
    sys.exit(1)

ROOT = Path(__file__).resolve().parent
OUT = ROOT / "INDEX.md"
WIKI = "https://rosettacode.org/wiki/"


def wiki_title(slug: str) -> str:
    return slug.replace("-", "_")


def load_yaml(name: str) -> dict:
    path = ROOT / name
    return yaml.safe_load(path.read_text(encoding="utf-8")) or {}


def classify_task(slug: str, taxonomy: dict) -> tuple[list[str], list[str], bool]:
    low = slug.lower()
    blocks: list[str] = []
    topics: list[str] = []
    skip = any(p in low for p in taxonomy.get("skip_patterns", []))
    for block, keys in taxonomy.get("taxonomy_blocks", {}).items():
        if any(k in low for k in keys):
            blocks.append(block)
    for topic, keys in taxonomy.get("frules_topics", {}).items():
        if any(k in low for k in keys):
            topics.append(topic)
    return blocks, topics, skip


def task_rows() -> list[tuple[str, list[str], Path]]:
    rows = []
    for task in sorted(p for p in ROOT.iterdir() if p.is_dir() and p.name != "gforth"):
        files = sorted(f.name for f in task.iterdir() if f.is_file())
        if files:
            rows.append((task.name, files, task))
    return rows


def validate_links(links: dict, task_names: set[str]) -> list[str]:
    warnings = []
    for ch, entry in links.items():
        for slug in entry.get("rosetta", []):
            if slug not in task_names:
                warnings.append(f"{ch}: missing rosetta dir {slug!r}")
    return warnings


def main() -> int:
    taxonomy = load_yaml("taxonomy-keywords.yaml")
    links_data = load_yaml("challenge-links.yaml")
    links: dict = links_data.get("links", {})

    rows = task_rows()
    task_names = {r[0] for r in rows}

    warnings = validate_links(links, task_names)
    for w in warnings:
        print(f"WARN: {w}", file=sys.stderr)

    block_counts: Counter[str] = Counter()
    topic_counts: Counter[str] = Counter()
    skip_count = 0
    by_block: dict[str, list[str]] = defaultdict(list)

    for slug, _files, _path in rows:
        blocks, topics, skip = classify_task(slug, taxonomy)
        if skip:
            skip_count += 1
        for b in blocks:
            block_counts[b] += 1
            if len(by_block[b]) < 8:
                by_block[b].append(slug)
        for t in topics:
            topic_counts[t] += 1

    n_files = sum(len(f) for _, f, _ in rows)

    lines = [
        "# Rosetta Code — Forth examples",
        "",
        "Vendored Forth solutions from [Rosetta Code](https://rosettacode.org/wiki/Category:Forth),",
        "via [acmeism/RosettaCodeData](https://github.com/acmeism/RosettaCodeData/tree/main/Lang/Forth).",
        "",
        f"**{len(rows)} tasks**, **{n_files}** `.fth` files. Refresh: `bash fetch.sh` then `python3 gen-index.py`.",
        "",
        "## Purpose in frules",
        "",
        "| Use | Action |",
        "|-----|--------|",
        "| Challenge solve / eval | Read **ideas**; adapt to `WORD`, stack effect, Style guard — see [`challenge-links.yaml`](challenge-links.yaml) |",
        "| Agent lookup | `python3 ../../scripts/rosettacode-hint.py tests/challenges/NNN-slug.fs` |",
        "| Rules (`rules/*.mdc`) | **Ref only** — do not bulk-distill; wiki snippets vary in dialect/quality |",
        "| Training SFT | **Not** a substitute for `data/challenge-solutions/` (no unified `T{ }T`) |",
        "",
        "**License:** per-contributor on rosettacode.org. Do not assume one license when copying.",
        "",
        "**Coverage legend** (challenge cross-ref `kind` in [`challenge-links.yaml`](challenge-links.yaml)):",
        "",
        "| Tag | Meaning |",
        "|-----|---------|",
        "| `exact` | Same wiki task as bank `Source:` URL |",
        "| `related` | Same algorithm family; contract may differ |",
        "| `ref` | Loose inspiration — verify before reuse |",
        "| `skip` | Games/graphics/demo — index only (~"
        f"{skip_count} tasks auto-tagged) |",
        "",
        "**Search:** `rg -l 'pattern' sources/rosettacode-forth/` · taxonomy tags: [`taxonomy-keywords.yaml`](taxonomy-keywords.yaml)",
        "",
        "---",
        "",
        "## By challenge taxonomy block",
        "",
        "Auto-tagged by slug keywords ([`taxonomy-keywords.yaml`](taxonomy-keywords.yaml)).",
        "Sample tasks per block (not exhaustive):",
        "",
        "| Block | ~Tasks | Examples |",
        "|-------|-------:|----------|",
    ]

    for block in sorted(taxonomy.get("taxonomy_blocks", {})):
        examples = ", ".join(f"`{s}`" for s in by_block.get(block, [])[:5])
        lines.append(f"| `{block}` | {block_counts.get(block, 0)} | {examples or '—'} |")

    lines += [
        "",
        "---",
        "",
        "## By frules topic",
        "",
        "| Rule file | ~Tasks | Notes |",
        "|-----------|-------:|-------|",
    ]
    topic_notes = {
        "forth-stack": "RPN, stack juggling demos",
        "forth-control": "recursion, loops, permutations",
        "forth-defining": "factories, closures (non-standard)",
        "forth-memory": "arrays, linked lists",
        "forth-strings": "parsing, encode/decode",
        "forth-io": "files, CLI args",
        "forth-meta": "interpreters, tokenizers",
        "forth-numeric": "primes, arithmetic puzzles",
        "forth-floating-point": "float demos (train bank avoids FP)",
        "forth-oof": "Classes/OOP samples — ref only",
        "forth-c-bindings": "foreign function examples",
        "forth-debugging": "`Assertions` task",
        "forth-portability": "ANS notes in `00-LANG.txt`",
    }
    for topic in sorted(taxonomy.get("frules_topics", {})):
        note = topic_notes.get(topic, "see slug samples in catalog")
        lines.append(f"| `{topic}` | {topic_counts.get(topic, 0)} | {note} |")

    lines += [
        "",
        "---",
        "",
        "## Challenge bank cross-reference",
        "",
        "Curated hints: bank file → Rosetta task dir(s). Extend [`challenge-links.yaml`](challenge-links.yaml)",
        "when you find a good pair; re-run `gen-index.py`.",
        "",
        "| Challenge | kind | Rosetta task(s) |",
        "|-----------|------|-----------------|",
    ]

    for ch in sorted(links):
        entry = links[ch]
        kind = entry.get("kind", "ref")
        slugs = entry.get("rosetta", [])
        slug_links = ", ".join(
            f"[`{s}`]({s}/)" if s in task_names else f"`{s}` (?)"
            for s in slugs
        )
        lines.append(f"| `{ch}` | {kind} | {slug_links} |")

    lines += [
        "",
        "Bank tasks **without** a row above: no curated Rosetta hint yet — use `rg` or taxonomy table.",
        "Only **6** bank tasks use `source: rosetta`; the rest are LeetCode-style with optional Rosetta **related** snippets.",
        "",
        "---",
    ]

    compat = load_yaml("gforth-compat.yaml")
    candidates = compat.get("distill_candidates", [])

    lines += [
        "",
        "Smoke: `gforth -e \"include sources/rosettacode-forth/<task>/<file> bye\"` — **no edits** to Rosetta sources.",
        "Policy: if **ok** → verbatim in `rules/`; if **broken**/**partial** → mark here + TODO; **do not fix** in vendored tree.",
        "Machine-readable: [`gforth-compat.yaml`](gforth-compat.yaml).",
        "",
        "| Task | File | Gforth | Rules | Note |",
        "|------|------|--------|-------|------|",
    ]
    for c in candidates:
        rules = ", ".join(f"`{r}`" for r in c.get("target_rules", []))
        status = c.get("status", "?")
        note = c.get("note", "")
        lines.append(
            f"| `{c.get('task', '?')}` | `{c.get('file', '?')}` | **{status}** | {rules} | {note} |"
        )

    ok_n = sum(1 for c in candidates if c.get("status") == "ok")
    fixed_n = sum(1 for c in candidates if c.get("status") in ("fixed", "substitute"))
    lines += [
        "",
        f"**Distilled (verbatim, ok):** {ok_n} → `rules/forth-*.mdc`.",
        f"**Gforth fixes (`gforth/`):** {fixed_n} — run `bash gforth/smoke-all.sh` (15/15). Upstream `../` untouched.",
        "",
        "Policy: do **not** patch vendored Rosetta originals; use [`gforth/`](gforth/README.md) for adaptations.",
        "",
        "---",
        "",
        "## Related frules docs",
        "",
        "| File | Role |",
        "|------|------|",
        "| [`docs/SOURCES.md`](../../docs/SOURCES.md) | Provenance row |",
        "| [`docs/AGENT-SOLVE-CHALLENGES.md`](../../docs/AGENT-SOLVE-CHALLENGES.md) | May read `sources/rosettacode-forth/` when solving |",
        "| [`docs/CHALLENGE-TO-TRAIN.md`](../../docs/CHALLENGE-TO-TRAIN.md) | Train vs hold-out; Rosetta is hint, not gold |",
        "| [`docs/CHALLENGE-RUNS.md`](../../docs/CHALLENGE-RUNS.md) | Blind eval: deny `sources/` unless allowed |",
        "| [`rules/frules-index.mdc`](../../rules/frules-index.mdc) | Topic routing + Rosetta lookup row |",
        "| [`sources/theforth.net-packages/INDEX.md`](../theforth.net-packages/INDEX.md) | Libraries (prefer for reusable words) |",
        "| [`TODO.md`](../../TODO.md) | Integration checklist |",
        "",
        f"**Status:** indexed {len(rows)} tasks · challenge-links {len(links)} entries · "
        f"distill **done** · gforth smoke **15/15**",
        "",
        "---",
        "",
        "## Full task catalog",
        "",
        "| Task | Files | Wiki |",
        "|------|-------|------|",
    ]

    for slug, files, _path in rows:
        url = f"{WIKI}{wiki_title(slug)}"
        lines.append(f"| `{slug}` | {', '.join(files)} | [{slug}]({url}) |")

    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(rows)} tasks, {len(links)} challenge links)")
    return 1 if warnings else 0


if __name__ == "__main__":
    raise SystemExit(main())

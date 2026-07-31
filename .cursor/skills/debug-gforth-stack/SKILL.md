---
name: debug-gforth-stack
description: Debugs Gforth stack depth leaks, segfaults, hangs, and T{ }T WRONG NUMBER OF RESULTS using depth probes and forth-debugging habits. Use when tests fail with stack errors, invalid memory address, infinite loops, or almost-correct numeric results in challenges or project .fs files.
---

# Debug Gforth stack

## Symptom table

| Symptom | Likely cause | Action |
|---------|--------------|--------|
| `WRONG NUMBER OF RESULTS` | Stack depth after `word` ≠ expected | Check depth before/after word, not arithmetic first |
| segfault / invalid address | Bad index, `tuck` with one item | Isolate helper; verify buffer indexing |
| hang | Infinite loop | `timeout 5 gforth …`; fix exit condition |
| almost right (e.g. 5 vs 4) | off-by-one or bad test | Re-read spec; fix spec if obviously wrong |

## Probe commands

Replace `isqrt` with the challenge word name from the CHALLENGE header:

```bash
cd tests/challenges
gforth -e 'fpath path+ . include ../../data/challenge-solutions/NNN-slug.fs' \
  -e 'depth . isqrt . depth . cr bye'
```

Omit the second `-e` if the file ends with `T{ }T` (tests run on load).

Use `timeout 5 gforth …` while debugging loops. Prefer **gforth** over gforth-fast for backtraces.

## Indexed buffers

Reuse repo `ch!` / `ch@` pattern — `( value index -- )` / `( index -- value )` with `swap cells field + !` / `cells field + @`. Do not use `tuck` queue snippets unless three stack items precede `tuck`.

## Rules

- `rules/forth-control.mdc` — flags, `if`, `WHILE`/`REPEAT`
- `rules/forth-stack.mdc`, `rules/forth-debugging.mdc`
- `docs/AGENT-SOLVE-CHALLENGES.md` §5b

## Related skills

- `solve-gforth-challenge` — full challenge workflow
- `gforth-verify-loop` — re-run after fix
- `frules-topic-routing` — pick rule file

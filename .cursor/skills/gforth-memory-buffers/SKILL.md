---
name: gforth-memory-buffers
description: Implements Gforth buffers, queues, grids, and DP tables using allot, ch!, ch@, and indexed buffer idioms from forth-memory rules. Use for stack-queue, matrix, dynamic-programming, or linked-structure challenges.
---

# Gforth memory and buffers workflow

## Rule file

`rules/forth-memory.mdc` — allot, indexed `ch!`/`ch@`, linked lists, alignment.

## Indexed buffer pattern

```forth
\ ( value index -- )
: ch!  swap cells buf + ! ;

\ ( index -- value )
: ch@  cells buf + @ ;
```

Verify `( n i -- )` vs `( i -- n )` before `tuck`.

## Taxonomy examples

- `stack-queue`, `matrix`, `dynamic-programming`
- `tests/challenges/032-min-stack.fs`, `tests/challenges/088-valid-sudoku.fs`, `tests/challenges/061-climb-stairs.fs`

## Debug

segfault → `debug-gforth-stack` (bad index, off-by-one in `cells +`).

## Related skills

- `gforth-defining-word` — queue defining words with +field
- `gforth-verify-loop` — mandatory PASS
- `solve-gforth-challenge`
- `gforth-ir-pipeline` — large DP → IR

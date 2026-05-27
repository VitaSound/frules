"""Forth scaffold snippets for generated challenges (Gforth)."""

SCALAR_SCAFFOLD = ""

STRING_SCAFFOLD = r"""
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
"""

CELL_ARRAY_SCAFFOLD = r"""
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
"""

LINKED_SCAFFOLD = r"""
\ Node index i: value in ch-vals[i], next in ch-nexts[i] (0 = nil)
12 constant ch-max-nodes
create ch-vals  ch-max-nodes cells allot
create ch-nexts ch-max-nodes cells allot

: ch-val@  ( i -- n )  cells ch-vals + @ ;
: ch-next@ ( i -- n )  cells ch-nexts + @ ;
: ch-node! ( val next i -- )  >r swap r@ ch-next@!  ch-val@! ;
"""

TREE_SCAFFOLD = r"""
\ Node i: val, left, right at offsets i*3 (0 = null child)
12 constant ch-max-nodes
create ch-tree ch-max-nodes 3 * cells allot

: ch-t@  ( off -- n )  cells ch-tree + @ ;
"""

GRID_SCAFFOLD = r"""
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
"""

SCAFFOLDS = {
    "scalar": SCALAR_SCAFFOLD,
    "string": STRING_SCAFFOLD,
    "cell-array": CELL_ARRAY_SCAFFOLD,
    "linked-cells": LINKED_SCAFFOLD,
    "tree-cells": TREE_SCAFFOLD,
    "grid": GRID_SCAFFOLD,
}

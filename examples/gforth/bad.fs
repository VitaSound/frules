\ examples/gforth/bad.fs — anti-patterns frules should reject.
\ Each block is annotated with what is wrong and how to fix it.

\ BAD: no stack-effect comment, magic number, monolithic body.
: do-stuff
  80 0 do i emit loop
  42 emit ;
\ FIX: add ( -- ), name the constant 80, split per concern.

\ BAD: imperative-style global, mirrors a stack parameter unnecessarily.
variable x
: square-input  ( n -- )
  x !  x @  x @  * . ;
\ FIX: : square ( n -- n*n ) dup * ;   (no variable, no side effect)

\ BAD: deep stack juggling instead of locals/factoring.
: weighted  ( a b c d -- n )
  >r >r swap r> r> rot * swap rot * + + ;
\ FIX: use { a b c d } locals or factor into smaller words.

\ BAD: C-style "counted string" assumption + NUL terminator.
\ : print-c  ( c-addr -- )
\   begin dup c@ ?dup while emit 1+ repeat drop ;
\ FIX: use address/length pairs and TYPE: ( c-addr u -- )

\ BAD: branches with mismatched stack effect.
: maybe  ( flag -- ??? )
  if 1 2 else 3 then ;
\ FIX: every branch must leave the same shape, or document two contracts:
\   ( true -- a b )  /  ( false -- c )

\ BAD: inventing infix.
\ : add  ( a b -- n ) a + b ;
\ FIX: : add ( a b -- n ) + ;   (operands already on stack, operator after)

\ BAD: return-stack leak — only one branch restores R:.
: leaky  ( n -- m )
  >r r@ 0> if r> 1+ else 99 then ;
\ FIX: keep R: balanced on every path, or move the value off R: before branching.

\ BAD: literal string with non-portable syntax inside a definition.
\ : msg  ( -- ) "hi" type ;
\ FIX: : msg ( -- ) s" hi" type ;

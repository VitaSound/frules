\ tests/challenges/05-balanced-parens.fs
\
\ CHALLENGE: round-bracket balance
\
\ Define a word
\
\   : balanced?  ( c-addr u -- flag )
\
\ that returns TRUE iff every '(' in the buffer has a later matching ')'
\ and no ')' appears with no opener in front of it. Characters other
\ than '(' and ')' are ignored. The empty string is balanced.
\
\ Style guard (rules/forth-naming.mdc, rules/forth-control.mdc):
\   - the trailing '?' in `balanced?` is mandatory — it returns a boolean;
\   - one counter is enough; do not allocate a stack-of-parens;
\   - prefer BEGIN ... WHILE ... REPEAT over DO ... LOOP for a length-driven
\     traversal that wants an early exit on underflow;
\   - return TRUE / FALSE, not 1 / 0.

include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" "            balanced? -> true  }T
T{ s" ()"          balanced? -> true  }T
T{ s" (())"        balanced? -> true  }T
T{ s" ()()"        balanced? -> true  }T
T{ s" (foo)"       balanced? -> true  }T
T{ s" (a(b)c(d))"  balanced? -> true  }T
T{ s" no parens"   balanced? -> true  }T
T{ s" ("           balanced? -> false }T
T{ s" )"           balanced? -> false }T
T{ s" (()"         balanced? -> false }T
T{ s" ())"         balanced? -> false }T
T{ s" )("          balanced? -> false }T
T{ s" (()(()"      balanced? -> false }T

report bye

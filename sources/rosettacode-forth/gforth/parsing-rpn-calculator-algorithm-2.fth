\ Rosetta Parsing-RPN-2 — gforth fix: batch demo via s" evaluate (no interactive bl word loop)
: ^ over swap 1 ?do over * loop nip ;

: detail ( c-addr u -- )
  cr ." stack: " .s
  evaluate
  cr ." stack: " .s ;

s" 3 4 2 * 1 5 - 2 3 ^ ^ / +" detail

### 3.34 Literal

> Source: https://gforth.org/manual/Literal-Tutorial.html

You cannot `POSTPONE` numbers:

```
: [FOO] POSTPONE 500 ; immediate
```

Instead, you can use `LITERAL (compilation: n --; run-time: -- n )`:

```
: [FOO] ( compilation: --; run-time: -- n )
  500 POSTPONE literal ; immediate

: flip [FOO] ;
flip .
see flip
```

`LITERAL` consumes a number at compile-time (when it's compilation semantics are executed) and pushes it at run-time (when the code it compiled is executed). A frequent use of `LITERAL` is to compile a number computed at compile time into the current word:

```
: bar ( -- n )
  [ 2 2 + ] literal ;
see bar
```

Assignment: Write `]L` which allows writing the example above as `: bar ( -- n ) [ 2 2 + ]L ;`

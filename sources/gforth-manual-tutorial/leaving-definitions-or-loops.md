### 3.21 Leaving definitions or loops

> Source: https://gforth.org/manual/Leaving-definitions-or-loops-Tutorial.html

`EXIT` exits the current definition right away. For every counted loop that is left in this way, an `UNLOOP` has to be performed before the `EXIT`:

```
: ...
 ... u+do
   ... if
     ... unloop exit
   endif
   ...
 loop
 ... ;
```

`LEAVE` leaves the innermost counted loop right away:

```
: ...
 ... u+do
   ... if
     ... leave
   endif
   ...
 loop
 ... ;
```

Reference: Calls and returns, Counted Loops.

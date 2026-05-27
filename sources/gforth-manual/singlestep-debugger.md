> Source: https://gforth.org/manual/Singlestep-Debugger.html

<span id="Singlestep-Debugger"></span>

<div class="header">

Previous: [Assertions](Assertions.html#Assertions), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Singlestep-Debugger-1"></span>

#### 5.24.5 Singlestep Debugger

<span id="index-singlestep-Debugger"></span> <span id="index-debugging-Singlestep"></span>

The singlestep debugger works only with the engine `gforth-itc`.

When you create a new word there’s often the need to check whether it behaves correctly or not. You can do this by typing `dbg badword`. A debug session might look like this:

<div class="example">

``` example
: badword 0 DO i . LOOP ;  ok
2 dbg badword 
: badword  
Scanning code...

Nesting debugger ready!

400D4738  8049BC4 0              -> [ 2 ] 00002 00000 
400D4740  8049F68 DO             -> [ 0 ] 
400D4744  804A0C8 i              -> [ 1 ] 00000 
400D4748 400C5E60 .              -> 0 [ 0 ] 
400D474C  8049D0C LOOP           -> [ 0 ] 
400D4744  804A0C8 i              -> [ 1 ] 00001 
400D4748 400C5E60 .              -> 1 [ 0 ] 
400D474C  8049D0C LOOP           -> [ 0 ] 
400D4758  804B384 ;              ->  ok
```

</div>

Each line displayed is one step. You always have to hit return to execute the next word that is displayed. If you don’t want to execute the next word in a whole, you have to type <span class="kbd">n</span> for `nest`. Here is an overview what keys are available:

  - *`RET`*  
    Next; Execute the next word.

  - *n*  
    Nest; Single step through next word.

  - *u*  
    Unnest; Stop debugging and execute rest of word. If we got to this word with nest, continue debugging with the calling word.

  - *d*  
    Done; Stop debugging and execute rest.

  - *s*  
    Stop; Abort immediately.

Debugging large application with this mechanism is very difficult, because you have to nest very deeply into the program before the interesting part begins. This takes a lot of time.

To do it more directly put a `BREAK:` command into your source code. When program execution reaches `BREAK:` the single step debugger is invoked and you have all the features described above.

If you have more than one part to debug it is useful to know where the program has stopped at the moment. You can do this by the `BREAK" string"` command. This behaves like `BREAK:` except that string is typed out when the “breakpoint” is reached.

<span id="index-dbg--_0022name_0022-_002d_002d--gforth"></span> <span id="index-dbg"></span> <span id="index-dbg-1"></span>

<div class="format">

``` format
dbg       "name" –         gforth       “dbg”
```

</div>

<span id="index-break_003a--_002d_002d--gforth"></span> <span id="index-break_003a"></span> <span id="index-break_003a-1"></span>

<div class="format">

``` format
break:       –         gforth       “break:”
```

</div>

<span id="index-break_0022--_0027ccc_0022_0027-_002d_002d--gforth"></span> <span id="index-break_0022"></span> <span id="index-break_0022-1"></span>

<div class="format">

``` format
break"       ’ccc"’ –         gforth       “break"”
```

</div>

-----

<div class="header">

Previous: [Assertions](Assertions.html#Assertions), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

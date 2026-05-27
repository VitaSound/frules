> Source: https://gforth.org/manual/Calling-C-function-pointers.html

<span id="Calling-C-function-pointers"></span>

<div class="header">

Next: [Defining library interfaces](Defining-library-interfaces.html#Defining-library-interfaces), Previous: [Declaring C Functions](Declaring-C-Functions.html#Declaring-C-Functions), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Calling-C-function-pointers-from-Forth"></span>

#### 5.26.3 Calling C function pointers from Forth

<span id="index-C-function-pointers_002c-calling-from-Forth"></span>

If you come across a C function pointer (e.g., in some C-constructed structure) and want to call it from your Forth program, you could use the structures as described above by defining a macro. Or you use `c-funptr`.

<span id="index-c_002dfunptr--_0022forth_002dname_0022-_003c_007b_003e_0022c_002dtypecast_0022_003c_007d_003e-_0022_007btype_007d_0022-_0022_002d_002d_002d_0022-_0022type_0022-_002d_002d--gforth"></span> <span id="index-c_002dfunptr"></span> <span id="index-c_002dfunptr-1"></span>

<div class="format">

``` format
c-funptr       "forth-name" <{>"c-typecast"<}> "{type}" "—" "type" –         gforth       “c-funptr”
```

</div>

Define a Forth word *forth-name*. *Forth-name* has the specified stack effect plus the called pointer on top of stack, i.e. `( {type} ptr -- type )` and calls the C function pointer `ptr` using the typecast or struct access `c-typecast`.

Let us assume that there is a C function pointer type `func1` defined in some header file `func1.h`, and you know that these functions take one integer argument and return an integer result; and you want to call functions through such pointers. Just define

<div class="example">

``` example
\c #include <func1.h>
c-funptr call-func1 {((func1)ptr)} n -- n
```

</div>

and then you can call a function pointed to by, say `func1a` as follows:

<div class="example">

``` example
-5 func1a call-func1 .
```

</div>

The Forth word `call-func1` is similar to `execute`, except that it takes a C `func1` pointer instead of a Forth execution token, and it is specific to `func1` pointers. For each type of function pointer you want to call from Forth, you have to define a separate calling word.

# Defining DOER/MAKE

If your system doesn’t have DOER and MAKE already defined, this appendix is meant to help you install them and, if necessary, understand how they work. Because by its nature this construct is system dependent, I’ve included several different implementations at the end of this appendix in the hope that one of them will work for you. If no, and if this section doesn’t give you enough information to get them running, you probably have an unusual system. Please don’t ask me for help; ask your Forth vendor.

Here’s how it works. DOER is a defining word that creates an entry with one cell in its parameter field. That cell contains the vector address, and is initialized to point to a no-op word called NOTHING.

Children of DOER will execute that DOES\> code of DOER, which does only two things: fetch the vector address and place it on the return stack. That’s all. Forth execution then continues with this address on the return stack, which will cause the vectored function to be performed. It’s like saying (in ’83-Standard)

``` forth
' nothing >body >r <return>
```

which executes NOTHING. (This trick only works with colon definitions.)

Here’s an illustration of the dictionary entry created when we enter

| DOER JOE |                 |
|:---------|:----------------|
| JOE      | pfa of NOTHING  |
| header   | parameter field |

Now suppose we define:

``` forth
: test   make joe  cr ;
```

that is, we define a word that can vector JOE to do a carriage return.

Here’s a picture of the compiled definition of TEST:

|      |        |     |        |        |        |
|:----:|:------:|:---:|:------:|:------:|:------:|
|      | adr of |     | adr of | adr of | adr of |
| TEST | (MAKE) |  0  |  JOE   |   CR   |  EXIT  |
|      |        |     |        |        |        |

Let’s look at the code for MAKE. Since we’re using MAKE inside a colon definition, STATE will be true, and we’ll execute the phrase:

``` forth
postpone (make)  here marker !  0 ,
```

We can see how MAKE has compiled the address of the run-time routine, (MAKE), followed by a zero. (We’ll explain what the zero is for, and why we save its address in the variable MARKER, later).

Now let’s look at what (MAKE) does when we execute our new definition TEST:

|  |  |
|:---|:---|
|  |  |
|  |  |
|  |  |
|  |  |
|  |  |
|  | Now JOE points inside the definition of TEST. When we type JOE, we’ll do a carriage return. |
|  |  |

That’s the basic idea. But what about that cell containing zero? That’s for the use of ;AND. Suppose we changed TEST to read:

``` forth
: test   make joe  cr ;and space ;
```

That is, when we invoke TEST we’ll vector JOE to do a CR, and we’ll do a SPACE right now. Here’s what this new version of TEST will look like:

<div class="center">

|      |        |     |        |        |        |       |        |
|:----:|:------:|:---:|:------:|:------:|:------:|:-----:|:------:|
|      | adr of |     | adr of | adr of | adr of |       | adr of |
| TEST | (MAKE) | adr |  JOE   |   CR   |  EXIT  | SPACE |  EXIT  |
|      |        |     |        |        |        |       |        |

</div>

Here’s the definition of ;AND:

``` forth
: ;and   postpone  EXIT  here marker @ ! ;   immediate
```

We can see that ;AND has compiled an EXIT, just as semicolon would.

Next, recall that MAKE saved the address of that cell in a variable called MARKER. Now ;AND stores HERE (the location of the second string of code beginning with SPACE) into the cell previously containing zero. Now (MAKE) has a pointer to the place to resume execution. The phrase

``` forth
IF >r THEN
```

will leave on the return stack the address of the code beginning with SPACE. Thus execution will skip over the code between MAKE and ;AND and continue with the remainder of the definition up to semicolon.

The word UNDO ticks the name of a DOER word, and stores the address of NOTHING into it.

One final note: on some systems you may encounter a problem. If you use MAKE outside of a colon definition to create a forward reference, you may not be able to find the most recently defined word. For instance, if you have:

``` forth
: refrain   do-dah  do-dah ;
make song  chorus  refrain ;
```

your system might think that refrain has not been defined. The problem is due to the placement of SMUDGE. As a solution, try rearranging the order of definitions or, if necessary, put MAKE code inside a definition which you then execute:

``` forth
: setup   make song  chorus  refrain ;   setup
```

In Laboratory Microsystems PC/FORTH 2.0, the UNSMUDGE on line 9 handles the problem. This problem does not arise with the Laxen/Perry/Harris model.

The final screen is an example of using DOER/MAKE. After loading the block, enter

``` forth
recital
```

then enter

``` forth
why?
```

followed by return, as many times as you like (you’ll get a different reason each time).

``` forth
( DOER/MAKE   Shadow screen                      LPB 12/05/83 )
NOTHING   A no-opp
DOER      Defines a word whose behavior is vectorable.
marker    Saves adr for optional continuation pointer.
(MAKE)    Stuffs the address of further code into the
          parameter field of a doer word.
MAKE      Used interpretively:  MAKE doer-name  forth-code ;
          or inside a definition:
             : def   MAKE doer-name  forth-code ;
          Vectors the doer-name word to the forth-code.
;AND      Allows continuation of the "making" definition
UNDO      Usage:  UNDO doer-name ; makes it safe to execute



```

``` forth
\ DOER/MAKE   ANS Forth with real return-stack   BP 22/04/06 
: nothing ;
: Doer   Create  ['] nothing  >body ,  DOES> @ >r ;
Variable marker
: (make)  r>  dup cell+  dup cell+  swap @  >body !
   @ ?dup IF >r THEN ;
: make   state @ IF ( compiling)
   postpone (make)  here marker !  0 , ' ,
   ELSE  here '  >body !
   ]  THEN ;   immediate
: ;and   postpone EXIT  here marker @ ! ;   immediate
: undo   ['] nothing  >body  '  >body ! ;

\ The code in this screen is in the public domain.

```

``` forth
\ DOER/MAKE NC ANS Forth with real return-stack  BP 22/04/06 
: nothing ;
: Doer   Create  ['] nothing ,  DOES> @ >r ;
Variable marker
: (make)  r>  dup cell+  dup cell+  swap @  >body !
   @ ?dup IF >r THEN ;
: make   state @ IF ( compiling)
   postpone (make)  here marker !  0 , ' ,
   ELSE  here '  >body !
   ]  THEN ;   immediate
: ;and   postpone EXIT  here marker @ ! ;   immediate
: undo   ['] nothing  '  >body ! ;

\ The code in this screen is in the public domain.

```

``` forth
\ toddler: Example of DOER/MAKE                      12/01/83 )
Doer answer
: recital
  cr ." Your daddy is standing on the table.  Ask him 'WHY?' "
  make answer  ." To change the light bulb."
  BEGIN
  make answer  ." Because it's burned out."
  make answer  ." Because it was old."
  make answer  ." Because we put it in there a long time ago."
  make answer  ." Because it was dark!"
  make answer  ." Because it was night time!!"
  make answer  ." Stop saying WHY?"
  make answer  ." Because it's driving me crazy."
  make answer  ." Just let me change this light bulb!"
  AGAIN ;
: why?   cr  answer  quit ;
```

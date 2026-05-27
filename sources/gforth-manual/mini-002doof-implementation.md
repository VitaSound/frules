> Source: https://gforth.org/manual/Mini_002dOOF-Implementation.html

<span id="Mini_002dOOF-Implementation"></span>

<div class="header">

Previous: [Mini-OOF Example](Mini_002dOOF-Example.html#Mini_002dOOF-Example), Up: [Mini-OOF](Mini_002dOOF.html#Mini_002dOOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="mini_002doof_002efs-Implementation"></span>

#### 5.23.5.3 `mini-oof.fs` Implementation

Object-oriented systems with late binding typically use a “vtable”-approach: the first variable in each object is a pointer to a table, which contains the methods as function pointers. The vtable may also contain other information.

So first, let’s declare selectors:

<div class="example">

``` example
: method ( m v "name" -- m' v ) Create  over , swap cell+ swap
  DOES> ( ... o -- ... ) @ over @ + @ execute ;
```

</div>

During selector declaration, the number of selectors and instance variables is on the stack (in address units). `method` creates one selector and increments the selector number. To execute a selector, it takes the object, fetches the vtable pointer, adds the offset, and executes the method *xt* stored there. Each selector takes the object it is invoked with as top of stack parameter; it passes the parameters (including the object) unchanged to the appropriate method which should consume that object.

Now, we also have to declare instance variables

<div class="example">

``` example
: var ( m v size "name" -- m v' ) Create  over , +
  DOES> ( o -- addr ) @ + ;
```

</div>

As before, a word is created with the current offset. Instance variables can have different sizes (cells, floats, doubles, chars), so all we do is take the size and add it to the offset. If your machine has alignment restrictions, put the proper `aligned` or `faligned` before the variable, to adjust the variable offset. That’s why it is on the top of stack.

We need a starting point (the base object) and some syntactic sugar:

<div class="example">

``` example
Create object  1 cells , 2 cells ,
: class ( class -- class selectors vars ) dup 2@ ;
```

</div>

For inheritance, the vtable of the parent object has to be copied when a new, derived class is declared. This gives all the methods of the parent class, which can be overridden, though.

<div class="example">

``` example
: end-class  ( class selectors vars "name" -- )
  Create  here >r , dup , 2 cells ?DO ['] noop , 1 cells +LOOP
  cell+ dup cell+ r> rot @ 2 cells /string move ;
```

</div>

The first line creates the vtable, initialized with `noop`s. The second line is the inheritance mechanism, it copies the xts from the parent vtable.

We still have no way to define new methods, let’s do that now:

<div class="example">

``` example
: defines ( xt class "name" -- ) ' >body @ + ! ;
```

</div>

To allocate a new object, we need a word, too:

<div class="example">

``` example
: new ( class -- o )  here over @ allot swap over ! ;
```

</div>

Sometimes derived classes want to access the method of the parent object. There are two ways to achieve this with Mini-OOF: first, you could use named words, and second, you could look up the vtable of the parent object.

<div class="example">

``` example
: :: ( class "name" -- ) ' >body @ + @ compile, ;
```

</div>

Nothing can be more confusing than a good example, so here is one. First let’s declare a text object (called `button`), that stores text and position:

<div class="example">

``` example
object class
  cell var text
  cell var len
  cell var x
  cell var y
  method init
  method draw
end-class button
```

</div>

Now, implement the two methods, `draw` and `init`:

<div class="example">

``` example
:noname ( o -- )
 >r r@ x @ r@ y @ at-xy  r@ text @ r> len @ type ;
 button defines draw
:noname ( addr u o -- )
 >r 0 r@ x ! 0 r@ y ! r@ len ! r> text ! ;
 button defines init
```

</div>

To demonstrate inheritance, we define a class `bold-button`, with no new data and no new selectors:

<div class="example">

``` example
button class
end-class bold-button

: bold   27 emit ." [1m" ;
: normal 27 emit ." [0m" ;
```

</div>

The class `bold-button` has a different draw method to `button`, but the new method is defined in terms of the draw method for `button`:

<div class="example">

``` example
:noname bold [ button :: draw ] normal ; bold-button defines draw
```

</div>

Finally, create two objects and apply selectors:

<div class="example">

``` example
button new Constant foo
s" thin foo" foo init
page
foo draw
bold-button new Constant bar
s" fat bar" bar init
1 bar y !
bar draw
```

</div>

-----

<div class="header">

Previous: [Mini-OOF Example](Mini_002dOOF-Example.html#Mini_002dOOF-Example), Up: [Mini-OOF](Mini_002dOOF.html#Mini_002dOOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

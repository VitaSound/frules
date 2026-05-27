> Source: https://gforth.org/manual/Notation.html

<span id="Notation"></span>

<div class="header">

Next: [Case insensitivity](Case-insensitivity.html#Case-insensitivity), Previous: [Words](Words.html#Words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Notation-1"></span>

### 5.1 Notation

<span id="index-notation-of-glossary-entries"></span> <span id="index-format-of-glossary-entries"></span> <span id="index-glossary-notation-format"></span> <span id="index-word-glossary-entry-format"></span>

The Forth words are described in this section in the glossary notation that has become a de-facto standard for Forth texts:

<div class="format">

``` format
word     Stack effect   wordset   pronunciation
```

</div>

*Description*

  - `word`  
    The name of the word.

  - `Stack effect`  
    <span id="index-stack-effect"></span>
    
    The stack effect is written in the notation `before -- after`, where *before* and *after* describe the top of stack entries before and after the execution of the word. The rest of the stack is not touched by the word. The top of stack is rightmost, i.e., a stack sequence is written as it is typed in. Note that Gforth uses a separate floating point stack, but a unified stack notation. Also, return stack effects are not shown in *stack effect*, but in *Description*. The name of a stack item describes the type and/or the function of the item. See below for a discussion of the types.
    
    All words have two stack effects: A compile-time stack effect and a run-time stack effect. The compile-time stack-effect of most words is *–* . If the compile-time stack-effect of a word deviates from this standard behaviour, or the word does other unusual things at compile time, both stack effects are shown; otherwise only the run-time stack effect is shown.
    
    Also note that in code templates or examples there can be comments in parentheses that display the stack picture at this point; there is no `--` in these places, because there is no before-after situation.
    
    <span id="index-pronounciation-of-words"></span>

  - `pronunciation`  
    How the word is pronounced.
    
    <span id="index-wordset"></span> <span id="index-environment-wordset"></span>

  - `wordset`  
    The Forth standard is divided into several word sets. A standard system need not support all of them. Therefore, in theory, the fewer word sets your program uses the more portable it will be. However, we suspect that most Standard Forth systems on personal machines will feature all word sets. Words that are not defined in Standard Forth have `gforth` or `gforth-internal` as word set. `gforth` describes words that will work in future releases of Gforth; `gforth-internal` words are more volatile. Environmental query strings are also displayed like words; you can recognize them by the `environment` in the word set field.

  - `Description`  
    A description of the behaviour of the word.

<span id="index-types-of-stack-items"></span> <span id="index-stack-item-types"></span>

The type of a stack item is specified by the character(s) the name starts with:

  - `f`  
    <span id="index-f_002c-stack-item-type"></span>
    
    Boolean flags, i.e. `false` or `true`.

  - `c`  
    <span id="index-c_002c-stack-item-type"></span>
    
    Char

  - `w`  
    <span id="index-w_002c-stack-item-type"></span>
    
    Cell, can contain an integer or an address

  - `n`  
    <span id="index-n_002c-stack-item-type"></span>
    
    signed integer

  - `u`  
    <span id="index-u_002c-stack-item-type"></span>
    
    unsigned integer

  - `d`  
    <span id="index-d_002c-stack-item-type"></span>
    
    double sized signed integer

  - `ud`  
    <span id="index-ud_002c-stack-item-type"></span>
    
    double sized unsigned integer

  - `r`  
    <span id="index-r_002c-stack-item-type"></span>
    
    Float (on the FP stack)

  - `a-`  
    <span id="index-a_005f_002c-stack-item-type"></span>
    
    Cell-aligned address

  - `c-`  
    <span id="index-c_005f_002c-stack-item-type"></span>
    
    Char-aligned address (note that a Char may have two bytes in Windows NT)

  - `f-`  
    <span id="index-f_005f_002c-stack-item-type"></span>
    
    Float-aligned address

  - `df-`  
    <span id="index-df_005f_002c-stack-item-type"></span>
    
    Address aligned for IEEE double precision float

  - `sf-`  
    <span id="index-sf_005f_002c-stack-item-type"></span>
    
    Address aligned for IEEE single precision float

  - `xt`  
    <span id="index-xt_002c-stack-item-type"></span>
    
    Execution token, same size as Cell

  - `wid`  
    <span id="index-wid_002c-stack-item-type"></span>
    
    Word list ID, same size as Cell

  - `ior, wior`  
    <span id="index-ior-type-description"></span> <span id="index-wior-type-description"></span>
    
    I/O result code, cell-sized. In Gforth, you can `throw` iors.

  - `f83name`  
    <span id="index-f83name_002c-stack-item-type"></span>
    
    Pointer to a name structure

  - `"`  
    <span id="index-_0022_002c-stack-item-type"></span>
    
    string in the input stream (not on the stack). The terminating character is a blank by default. If it is not a blank, it is shown in `<>` quotes.

-----

<div class="header">

Next: [Case insensitivity](Case-insensitivity.html#Case-insensitivity), Previous: [Words](Words.html#Words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

# Summary of Style Conventions

The contents of this Appendix are in the public domain. We encourage publication without restriction, provided that you credit the source.

## Spacing and Indentation Guidelines

> 1 space between the colon and the name
>
> 2 spaces between the name and the comment[^1]
>
> 2 spaces, or a carriage return, after the comment and before the definition
>
> 3 spaces between the name and definition if no comment is used
>
> 3 spaces indentation on each subsequent line (or multiples of 3 for nested indentation)
>
> 1 space between words/numbers within a phrase
>
> 2 or 3 spaces between phrases
>
> 1 space between the last word and the semicolon
>
> 1 space between semicolon and IMMEDIATE (if invoked)

No blank lines between definitions, except to separate distinct groups of definitions

## Stack-Comment Abbreviations

|          |                                      |
|:---------|:-------------------------------------|
| n        | single-length signed number          |
| d        | double-length signed number          |
| u        | single-length unsigned number        |
| ud       | double-length unsigned number        |
| t        | triple-length                        |
| q        | quadruple-length                     |
| c        | 7-bit character value                |
| b        | 8-bit byte                           |
| ?        | boolean flag; or:                    |
| t=       | true                                 |
| f=       | false                                |
| a or adr | address                              |
| acf      | address of code field                |
| apf      | address of parameter field           |
| ‘        | (as prefix) address of               |
| s d      | (as a pair) source destination       |
| lo hi    | lower-limit upper-limit (inclusive)  |
| \#       | count                                |
| o        | offset                               |
| i        | index                                |
| m        | mask                                 |
| x        | don’t care (data structure notation) |

An “offset” is a difference expressed in absolute units, such as bytes.

An “index” is a difference expressed in logical units, such as elements or records.

## Input-Stream Comment Designations

|      |                                                |
|:-----|:-----------------------------------------------|
| c    | single character, blank-delimited              |
| name | sequence of characters, blank delimited        |
| text | sequence of characters, delimited by non-blank |

Follow “text” with the actual delimiter required; e.g., text” or text).

## Samples of Good Commenting Style

Here are two sample screens to illustrate good commenting style.

``` forth
\ Formatter         Data Structures -- p.2             06/06/83
 6 Constant TMARGIN \ line# where body of text begins
55 Constant BMARGIN \ line# where body of text ends

Create header 82 allot
\  { 1left-ent | 1right-cnt | 80header }
Create FOOTER 82 allot
\  { 1left-cnt | 1right-ent | 80footer }

Variable ACROSS   \ formatter's current horizontal position
Variable DOWNWARD \ formatter's current vertical position
Variable LEFT     \ current primary left margin
Variable WALL     \ current primary right margin
Variable WALL-WAS \ WALL when curr. line started being formt'd
```

``` forth
\ Formatter          positioning -- p.1               06/06/83
: skip  ( n)  ACROSS +! ;
: NEWLEFT  \ reset left margin
   LEFT @  PERMANENT @ +  TEMPORARY @ +  ACROSS ! ;
: \LINE  \ begin new line
   DOOR  CR'  1 DOWNWARD +!  NEWLEFT  WALL @  WALL-WAS ! ;
: AT-TOP?  ( -- t=at-top)  TMARGIN  DOWNWARD @ = ;
: >TMARGIN  \ move from crease to TMARGIN
   0 DOWNWARD !  BEGIN  \LINE  AT-TOP? UNTIL ;
```

## Naming Conventions

| *Meaning* | *Form* | <span class="roman">*`Example`*</span> |
|:---|:---|:---|
| <u>Arithmetic</u> |  |  |
| integer 1 | 1name | `1+` |
| integer 2 | 2name | `2*` |
| takes relative input parameters | +name | `+DRAW` |
| takes scaled input parameters | \*name | `DRAW` |
| <u>Compilation</u> |  |  |
| start of “high-level” code | name: | `CASE:` |
| end of “high-level” code | ;name | `;CODE` |
| put something into dictionary | name, | `C,` |
| executes at compile time | \[name\] | `[COMPILE]` |
| slightly different | name’ (prime) | `CR’` |
| internal form or primitive | (name) | `(TYPE)` |
|  | or \<name\> | `<TYPE>` |
| compiling word run-time part: |  |  |
|   systems with no folding | lower-case | `if` |
|   systems with folding | (NAME) | `(IF)` |
| defining word | :name | `:COLOR` |
| block-number where overlay begins | nam**ING** | `DISKING` |
| <u>Data Structures</u> |  |  |
| table or array | names | `EMPLOYEES` |
| total number of elements | \#name | `#EMPLOYEES` |
| current item number (variable) | name# | `EMPLOYEE#` |
| sets current item | ( n) name | `13 EMPLOYEE` |
| advance to next element | +name | `+EMPLOYEE` |
| size of offset to item from | name+ | `DATE +` |
|   beginning of structure |  |  |
| size of (bytes per) | /name | `/EMPLOYEE` |
|   (short for BYTES/name) |  |  |
| index pointer | \>name | `>IN` |
| convert address of structure to | \>name | `>BODY` |
|   address of item |  |  |
| file index | (name) | `(PEOPLE)` |
| file pointer | –name | `–JOB` |
| initialize structure | 0name | `0RECORD` |
| <u>Direction, Conversion</u> |  |  |
| backwards | name\< | `SLIDE<` |
| forwards | name\> | `CMOVE>` |
| from | \<name | `<TAPE` |
| to | \>name | `>TAPE` |
| convert to | name\>name | `FEET>METERS` |
| downward | $`\backslash`$name | $`\backslash`$`LINE` |
| upward | /name | `/LINE` |
| open | {name | `{FILE` |
| close | }name | `}FILE` |
| <u>Logic, Control</u> |  |  |
| return boolean value | name? | `SHORT?` |
| returns reversed boolean | -name? | `-SHORT?` |
| address of boolean | ’name? | `’SHORT?` |
| operates conditionally | ?name | `?DUP` |
|  |  | <span class="roman">`(maybe DUP)`</span> |
| enable | +name | `+CLOCK` |
|   or, absence of symbol | name | `BLINKING` |
| disable | -name | `-CLOCK` |
|  |  | `-BLINKING` |
| <u>Memory</u> |  |  |
| save value of | @name | `@CURSOR` |
| restore value of | !name | `!CURSOR` |
| store into | name! | `SECONDS!` |
| fetch from | name@ | `INDEX@` |
| name of buffer | :name | `:INSERT` |
| address of name | ’name | `’S` |
| address of pointer to name | ’name | `’TYPE` |
| exchange, especially bytes | \>name\< | `>MOVE<` |
| <u>Numeric Types</u> |  |  |
| byte length | Cname | `C@` |
| 2 cell size, 2’s complement | Dname | `D+` |
|   integer encoding |  |  |
| mixed 16 and 32-bit operator | Mname | `M*` |
| 3 cell size | Tname | `T*` |
| 4 cell size | Qname | `Q*` |
| unsigned encoding | Uname | `U.` |
| <u>Output, Printing</u> |  |  |
| print item | .name | `.S` |
| print numeric (name denotes type) | name. | `D. , U.` |
| print right justified | name.R | `U.R` |
| <u>Quantity</u> |  |  |
| “per” | /name | `/SIDE` |
| <u>Sequencing</u> |  |  |
| start | \<name | `<#` |
| end | name\> | `#>` |
| <u>Text</u> |  |  |
| string follows delimited by ” | name” | `ABORT” text”` |
| text or string operator | “name | `“COMPARE` |
|   (similar to \$ prefix in BASIC) |  |  |
| superstring array | “name” | `“COLORS”` |

*How to Pronounce the Symbols*

|                |                                                |
|:---------------|:-----------------------------------------------|
| !              | store                                          |
| @              | fetch                                          |
| \#             | sharp (or “number,” as in \#RECORDS)           |
| \$             | dollar                                         |
| %              | percent                                        |
| ^              | caret                                          |
| &              | ampersand                                      |
| \*             | star                                           |
| (              | left paren; paren                              |
| )              | right paren; paren                             |
| –              | dash; not                                      |
| \+             | plus                                           |
| =              | equals                                         |
| { }            | braces (traditionally called “curly brackets”) |
| \[ \]          | square brackets                                |
| “              | quote                                          |
| ’              | as prefix: tick; as suffix: prime              |
| ~              | tilde                                          |
| $`|`$          | bar                                            |
| $`\backslash`$ | backslash. (also “under,” “down,” and “skip”)  |
| /              | slash. (also “up”)                             |
| \<             | less-than                                      |
|                | left dart                                      |
| \>             | greater-than                                   |
|                | right dart                                     |
| ?              | question (some prefer “query”)                 |
| ,              | comma                                          |
| .              | dot                                            |

[^1]: An often-seen alternative calls for 1 space between the name and comment and 3 between the comment and the definition. A more liberal technique uses 3 spaces before and after the comment. Whatever you choose, be consistent.

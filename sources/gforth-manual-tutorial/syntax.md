### 3.2 Syntax

> Source: https://gforth.org/manual/Syntax-Tutorial.html

A word is a sequence of arbitrary characters (except white space). Words are separated by white space. E.g., each of the following lines contains exactly one word:

```
word
!@#$%^&*()
1234567890
5!a
```

A frequent beginner's error is to leave out necessary white space, resulting in an error like 'Undefined word'; so if you see such an error, check if you have put spaces wherever necessary.

```
." hello, world" \ correct
."hello, world"  \ gives an "Undefined word" error
```

Gforth and most other Forth systems ignore differences in case (they are case-insensitive), i.e., 'word' is the same as 'Word'. If your system is case-sensitive, you may have to type all the examples given here in upper case.

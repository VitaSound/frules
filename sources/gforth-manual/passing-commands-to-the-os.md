> Source: https://gforth.org/manual/Passing-Commands-to-the-OS.html

<span id="Passing-Commands-to-the-OS"></span>

<div class="header">

Next: [Keeping track of Time](Keeping-track-of-Time.html#Keeping-track-of-Time), Previous: [Threading Words](Threading-Words.html#Threading-Words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Passing-Commands-to-the-Operating-System"></span>

### 5.29 Passing Commands to the Operating System

<span id="index-operating-system-_002d-passing-commands"></span> <span id="index-shell-commands"></span>

Gforth allows you to pass an arbitrary string to the host operating system shell (if such a thing exists) for execution.

<span id="index-sh--_0022_002e_002e_002e_0022-_002d_002d--gforth"></span> <span id="index-sh"></span> <span id="index-sh-1"></span>

<div class="format">

``` format
sh       "..." –         gforth       “sh”
```

</div>

Parse a string and use `system` to pass it to the host operating system for execution in a sub-shell.

<span id="index-system--c_002daddr-u-_002d_002d--gforth"></span> <span id="index-system"></span> <span id="index-system-1"></span>

<div class="format">

``` format
system       c-addr u –         gforth       “system”
```

</div>

Pass the string specified by `c-addr u` to the host operating system for execution in a sub-shell. The value of the environment variable `GFORTHSYSTEMPREFIX` (or its default value) is prepended to the string (mainly to support using `command.com` as shell in Windows instead of whatever shell Cygwin uses by default; see [Environment variables](Environment-variables.html#Environment-variables)).

<span id="index-_0024_003f--_002d_002d-n--gforth"></span> <span id="index-_0024_003f"></span> <span id="index-_0024_003f-1"></span>

<div class="format">

``` format
$?       – n         gforth       “dollar-question”
```

</div>

`Value` – the exit status returned by the most recently executed `system` command.

<span id="index-getenv--c_002daddr1-u1-_002d_002d-c_002daddr2-u2--gforth"></span> <span id="index-getenv"></span> <span id="index-getenv-1"></span>

<div class="format">

``` format
getenv       c-addr1 u1 – c-addr2 u2        gforth       “getenv”
```

</div>

The string *c-addr1 u1* specifies an environment variable. The string *c-addr2 u2* is the host operating system’s expansion of that environment variable. If the environment variable does not exist, *c-addr2 u2* specifies a string 0 characters in length.

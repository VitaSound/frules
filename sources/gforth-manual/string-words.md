> Source: https://gforth.org/manual/String-words.html

<span id="String-words"></span>

<div class="header">

Next: [Terminal output](Terminal-output.html#Terminal-output), Previous: [Displaying characters and strings](Displaying-characters-and-strings.html#Displaying-characters-and-strings), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="String-words-1"></span>

#### 5.19.5 String words

<span id="index-string-words"></span>

The following string library stores strings in ordinary variables, which then contain a pointer to a cell-counted string allocated from the heap. The string library originates from bigFORTH.

<span id="index-delete--buffer-size-u-_002d_002d--gforth_002dstring"></span> <span id="index-delete"></span> <span id="index-delete-1"></span>

<div class="format">

``` format
delete       buffer size u –         gforth-string       “delete”
```

</div>

deletes the first `u` bytes from a buffer and fills the rest at the end with blanks.

<span id="index-insert--string-length-buffer-size-_002d_002d--gforth_002dstring"></span> <span id="index-insert"></span> <span id="index-insert-1"></span>

<div class="format">

``` format
insert       string length buffer size –         gforth-string       “insert”
```

</div>

inserts a string at the front of a buffer. The remaining bytes are moved on.

<span id="index-_0024_0021--addr1-u-_0024addr-_002d_002d--gforth_002dstring"></span> <span id="index-_0024_0021"></span> <span id="index-_0024_0021-1"></span>

<div class="format">

``` format
$!       addr1 u $addr –         gforth-string       “string-store”
```

</div>

stores a newly allocated string buffer at an address, frees the previous buffer if necessary.

<span id="index-_0024_0040--_0024addr-_002d_002d-addr2-u--gforth_002dstring"></span> <span id="index-_0024_0040"></span> <span id="index-_0024_0040-1"></span>

<div class="format">

``` format
$@       $addr – addr2 u         gforth-string       “string-fetch”
```

</div>

returns the stored string.

<span id="index-_0024_0040len--_0024addr-_002d_002d-u--gforth_002dstring"></span> <span id="index-_0024_0040len"></span> <span id="index-_0024_0040len-1"></span>

<div class="format">

``` format
$@len       $addr – u         gforth-string       “string-fetch-len”
```

</div>

returns the length of the stored string.

<span id="index-_0024_0021len--u-_0024addr-_002d_002d--gforth_002dstring"></span> <span id="index-_0024_0021len"></span> <span id="index-_0024_0021len-1"></span>

<div class="format">

``` format
$!len       u $addr –         gforth-string       “string-store-len”
```

</div>

changes the length of the stored string. Therefore we must change the memory area and adjust address and count cell as well.

<span id="index-_0024_002b_0021len--u-_0024addr-_002d_002d-addr--unknown"></span> <span id="index-_0024_002b_0021len"></span> <span id="index-_0024_002b_0021len-1"></span>

<div class="format">

``` format
$+!len       u $addr – addr         unknown       “$+!len”
```

</div>

make room for u bytes at the end of the memory area referenced by $addr; addr is the address of the first of these bytes.

<span id="index-_0024del--addr-off-u-_002d_002d--gforth_002dstring"></span> <span id="index-_0024del"></span> <span id="index-_0024del-1"></span>

<div class="format">

``` format
$del       addr off u –         gforth-string       “string-del”
```

</div>

deletes `u` bytes from a string with offset `off`.

<span id="index-_0024ins--addr1-u-_0024addr-off-_002d_002d--gforth_002dstring"></span> <span id="index-_0024ins"></span> <span id="index-_0024ins-1"></span>

<div class="format">

``` format
$ins       addr1 u $addr off –         gforth-string       “string-ins”
```

</div>

inserts a string at offset `off`.

<span id="index-_0024_002b_0021--addr1-u-_0024addr-_002d_002d--gforth_002dstring"></span> <span id="index-_0024_002b_0021"></span> <span id="index-_0024_002b_0021-1"></span>

<div class="format">

``` format
$+!       addr1 u $addr –         gforth-string       “string-plus-store”
```

</div>

appends a string to another.

<span id="index-c_0024_002b_0021--char-_0024addr-_002d_002d--gforth_002dstring"></span> <span id="index-c_0024_002b_0021"></span> <span id="index-c_0024_002b_0021-1"></span>

<div class="format">

``` format
c$+!       char $addr –         gforth-string       “c-string-plus-store”
```

</div>

append a character to a string.

<span id="index-_0024free--_0024addr-_002d_002d--gforth_002dstring"></span> <span id="index-_0024free"></span> <span id="index-_0024free-1"></span>

<div class="format">

``` format
$free       $addr –         gforth-string       “string-free”
```

</div>

free the string pointed to by addr, and set addr to 0

<span id="index-_0024init--_0024addr-_002d_002d--unknown"></span> <span id="index-_0024init"></span> <span id="index-_0024init-1"></span>

<div class="format">

``` format
$init       $addr –         unknown       “$init”
```

</div>

store an empty string there, regardless of what was in before

<span id="index-_0024split--addr-u-char-_002d_002d-addr1-u1-addr2-u2--gforth_002dstring"></span> <span id="index-_0024split"></span> <span id="index-_0024split-1"></span>

<div class="format">

``` format
$split       addr u char – addr1 u1 addr2 u2         gforth-string       “string-split”
```

</div>

divides a string into two, with one char as separator (e.g. ’?’ for arguments in an HTML query)

<span id="index-_0024iter--_002e_002e-_0024addr-char-xt-_002d_002d-_002e_002e--gforth_002dstring"></span> <span id="index-_0024iter"></span> <span id="index-_0024iter-1"></span>

<div class="format">

``` format
$iter       .. $addr char xt – ..         gforth-string       “string-iter”
```

</div>

takes a string apart piece for piece, also with a character as separator. For each part a passed token will be called. With this you can take apart arguments – separated with ’&’ – at ease.

<span id="index-_0024over--addr-u-_0024addr-off-_002d_002d--unknown"></span> <span id="index-_0024over"></span> <span id="index-_0024over-1"></span>

<div class="format">

``` format
$over       addr u $addr off –         unknown       “$over”
```

</div>

overwrite string at offset off with addr u

<span id="index-_0024exec--xt-addr-_002d_002d--unknown"></span> <span id="index-_0024exec"></span> <span id="index-_0024exec-1"></span>

<div class="format">

``` format
$exec       xt addr –         unknown       “$exec”
```

</div>

execute xt while the standard output (TYPE, EMIT, and everything that uses them) is appended to the string variable addr.

<span id="index-_0024tmp--xt-_002d_002d-addr-u--unknown"></span> <span id="index-_0024tmp"></span> <span id="index-_0024tmp-1"></span>

<div class="format">

``` format
$tmp       xt – addr u         unknown       “$tmp”
```

</div>

generate a temporary string from the output of a word

<span id="index-_0024_002e--addr-_002d_002d--unknown"></span> <span id="index-_0024_002e"></span> <span id="index-_0024_002e-1"></span>

<div class="format">

``` format
$.       addr –         unknown       “$.”
```

</div>

print a string, shortcut

<span id="index-_0024slurp--fid-addr-_002d_002d--unknown"></span> <span id="index-_0024slurp"></span> <span id="index-_0024slurp-1"></span>

<div class="format">

``` format
$slurp       fid addr –         unknown       “$slurp”
```

</div>

slurp a file `fid` into a string `addr2`

<span id="index-_0024slurp_002dfile--addr1-u1-addr2-_002d_002d--unknown"></span> <span id="index-_0024slurp_002dfile"></span> <span id="index-_0024slurp_002dfile-1"></span>

<div class="format">

``` format
$slurp-file       addr1 u1 addr2 –         unknown       “$slurp-file”
```

</div>

slurp a named file `addr1 u1` into a string `addr2`

<span id="index-_0024_005b_005d--u-_0024_005b_005daddr-_002d_002d-addr_0027--unknown"></span> <span id="index-_0024_005b_005d"></span> <span id="index-_0024_005b_005d-1"></span>

<div class="format">

``` format
$[]       u $[]addr – addr’         unknown       “$[]”
```

</div>

index into the string array and return the address at index `u` The array will be resized as needed

<span id="index-_0024_005b_005d_0021--addr-u-n-_0024_005b_005daddr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005d_0021"></span> <span id="index-_0024_005b_005d_0021-1"></span>

<div class="format">

``` format
$[]!       addr u n $[]addr –         unknown       “$[]!”
```

</div>

store a string into an array at index *n*

<span id="index-_0024_005b_005d_002b_0021--addr-u-n-_0024_005b_005daddr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005d_002b_0021"></span> <span id="index-_0024_005b_005d_002b_0021-1"></span>

<div class="format">

``` format
$[]+!       addr u n $[]addr –         unknown       “$[]+!”
```

</div>

add a string to the string at index *n*

<span id="index-_0024_005b_005d_0040--n-_0024_005b_005daddr-_002d_002d-addr-u--unknown"></span> <span id="index-_0024_005b_005d_0040"></span> <span id="index-_0024_005b_005d_0040-1"></span>

<div class="format">

``` format
$[]@       n $[]addr – addr u         unknown       “$[]’'
```

</div>

fetch a string from array index *n* — return the zero string if empty, and don’t accidentally grow the array.

<span id="index-_0024_005b_005d_0023--addr-_002d_002d-len--unknown"></span> <span id="index-_0024_005b_005d_0023"></span> <span id="index-_0024_005b_005d_0023-1"></span>

<div class="format">

``` format
$[]#       addr – len         unknown       “$[]#”
```

</div>

return the number of elements in an array

<span id="index-_0024_005b_005dmap--addr-xt-_002d_002d--unknown"></span> <span id="index-_0024_005b_005dmap"></span> <span id="index-_0024_005b_005dmap-1"></span>

<div class="format">

``` format
$[]map       addr xt –         unknown       “$[]map”
```

</div>

execute `xt` for all elements of the string array `addr`. xt is `( addr u – )`, getting one string at a time

<span id="index-_0024_005b_005dslurp--fid-addr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005dslurp"></span> <span id="index-_0024_005b_005dslurp-1"></span>

<div class="format">

``` format
$[]slurp       fid addr –         unknown       “$[]slurp”
```

</div>

slurp a file `fid` line by line into a string array `addr`

<span id="index-_0024_005b_005dslurp_002dfile--addr-u-_0024addr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005dslurp_002dfile"></span> <span id="index-_0024_005b_005dslurp_002dfile-1"></span>

<div class="format">

``` format
$[]slurp-file       addr u $addr –         unknown       “$[]slurp-file”
```

</div>

slurp a named file `addr u` line by line into a string array `$addr`

<span id="index-_0024_005b_005d_002e--addr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005d_002e"></span> <span id="index-_0024_005b_005d_002e-1"></span>

<div class="format">

``` format
$[].       addr –         unknown       “$[].”
```

</div>

print all array entries

<span id="index-_0024_005b_005dfree--addr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005dfree"></span> <span id="index-_0024_005b_005dfree-1"></span>

<div class="format">

``` format
$[]free       addr –         unknown       “$[]free”
```

</div>

addr contains the address of a cell-counted string that contains the addresses of a number of cell-counted strings; $\[\]free frees these strings, frees the array, and sets addr to 0

<span id="index-_0024save--_0024addr-_002d_002d--unknown"></span> <span id="index-_0024save"></span> <span id="index-_0024save-1"></span>

<div class="format">

``` format
$save       $addr –         unknown       “$save”
```

</div>

push string to dictionary for savesys

<span id="index-_0024_005b_005dsave--addr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005dsave"></span> <span id="index-_0024_005b_005dsave-1"></span>

<div class="format">

``` format
$[]save       addr –         unknown       “$[]save”
```

</div>

push string array to dictionary for savesys

<span id="index-_0024boot--_0024addr-_002d_002d--unknown"></span> <span id="index-_0024boot"></span> <span id="index-_0024boot-1"></span>

<div class="format">

``` format
$boot       $addr –         unknown       “$boot”
```

</div>

take string from dictionary to allocated memory. clean dictionary afterwards.

<span id="index-_0024_005b_005dboot--addr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005dboot"></span> <span id="index-_0024_005b_005dboot-1"></span>

<div class="format">

``` format
$[]boot       addr –         unknown       “$[]boot”
```

</div>

take string array from dictionary to allocated memory

<span id="index-_0024saved--addr-_002d_002d--unknown"></span> <span id="index-_0024saved"></span> <span id="index-_0024saved-1"></span>

<div class="format">

``` format
$saved       addr –         unknown       “$saved”
```

</div>

<span id="index-_0024_005b_005dsaved--addr-_002d_002d--unknown"></span> <span id="index-_0024_005b_005dsaved"></span> <span id="index-_0024_005b_005dsaved-1"></span>

<div class="format">

``` format
$[]saved       addr –         unknown       “$[]saved”
```

</div>

<span id="index-_0024Variable--_002d_002d--unknown"></span> <span id="index-_0024Variable"></span> <span id="index-_0024Variable-1"></span>

<div class="format">

``` format
$Variable       –         unknown       “$Variable”
```

</div>

A string variable which is preserved across savesystem

<span id="index-_0024_005b_005dVariable--_002d_002d--unknown"></span> <span id="index-_0024_005b_005dVariable"></span> <span id="index-_0024_005b_005dVariable-1"></span>

<div class="format">

``` format
$[]Variable       –         unknown       “$[]Variable”
```

</div>

A string variable which is preserved across savesystem

-----

<div class="header">

Next: [Terminal output](Terminal-output.html#Terminal-output), Previous: [Displaying characters and strings](Displaying-characters-and-strings.html#Displaying-characters-and-strings), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

> Source: https://gforth.org/manual/Blocks.html

<span id="Blocks"></span>

<div class="header">

Next: [Other I/O](Other-I_002fO.html#Other-I_002fO), Previous: [Files](Files.html#Files), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Blocks-1"></span>

### 5.18 Blocks

<span id="index-I_002fO-_002d-blocks"></span> <span id="index-blocks"></span>

When you run Gforth on a modern desk-top computer, it runs under the control of an operating system which provides certain services. One of these services is `file services`, which allows Forth source code and data to be stored in files and read into Gforth (see [Files](Files.html#Files)).

Traditionally, Forth has been an important programming language on systems where it has interfaced directly to the underlying hardware with no intervening operating system. Forth provides a mechanism, called *blocks*, for accessing mass storage on such systems.

A block is a 1024-byte data area, which can be used to hold data or Forth source code. No structure is imposed on the contents of the block. A block is identified by its number; blocks are numbered contiguously from 1 to an implementation-defined maximum.

A typical system that used blocks but no operating system might use a single floppy-disk drive for mass storage, with the disks formatted to provide 256-byte sectors. Blocks would be implemented by assigning the first four sectors of the disk to block 1, the second four sectors to block 2 and so on, up to the limit of the capacity of the disk. The disk would not contain any file system information, just the set of blocks.

<span id="index-blocks-file"></span>

On systems that do provide file services, blocks are typically implemented by storing a sequence of blocks within a single *blocks file*. The size of the blocks file will be an exact multiple of 1024 bytes, corresponding to the number of blocks it contains. This is the mechanism that Gforth uses.

<span id="index-blocks_002efb"></span>

Only one blocks file can be open at a time. If you use block words without having specified a blocks file, Gforth defaults to the blocks file `blocks.fb`. Gforth uses the Forth search path when attempting to locate a blocks file (see [Source Search Paths](Source-Search-Paths.html#Source-Search-Paths)).

<span id="index-block-buffers"></span>

When you read and write blocks under program control, Gforth uses a number of *block buffers* as intermediate storage. These buffers are not used when you use `load` to interpret the contents of a block.

The behaviour of the block buffers is analagous to that of a cache. Each block buffer has three states:

  - Unassigned
  - Assigned-clean
  - Assigned-dirty

Initially, all block buffers are *unassigned*. In order to access a block, the block (specified by its block number) must be assigned to a block buffer.

The assignment of a block to a block buffer is performed by `block` or `buffer`. Use `block` when you wish to modify the existing contents of a block. Use `buffer` when you don’t care about the existing contents of the block[<sup>30</sup>](#FOOT30).

Once a block has been assigned to a block buffer using `block` or `buffer`, that block buffer becomes the *current block buffer*. Data may only be manipulated (read or written) within the current block buffer.

When the contents of the current block buffer has been modified it is necessary, *before calling `block` or `buffer` again*, to either abandon the changes (by doing nothing) or mark the block as changed (assigned-dirty), using `update`. Using `update` does not change the blocks file; it simply changes a block buffer’s state to *assigned-dirty*. The block will be written implicitly when it’s buffer is needed for another block, or explicitly by `flush` or `save-buffers`.

word `Flush` writes all *assigned-dirty* blocks back to the blocks file on disk. Leaving Gforth with `bye` also performs a `flush`.

In Gforth, `block` and `buffer` use a *direct-mapped* algorithm to assign a block buffer to a block. That means that any particular block can only be assigned to one specific block buffer, called (for the particular operation) the *victim buffer*. If the victim buffer is *unassigned* or *assigned-clean* it is allocated to the new block immediately. If it is *assigned-dirty* its current contents are written back to the blocks file on disk before it is allocated to the new block.

Although no structure is imposed on the contents of a block, it is traditional to display the contents as 16 lines each of 64 characters. A block provides a single, continuous stream of input (for example, it acts as a single parse area) – there are no end-of-line characters within a block, and no end-of-file character at the end of a block. There are two consequences of this:

  - The last character of one line wraps straight into the first character of the following line
  - The word `\` – comment to end of line – requires special treatment; in the context of a block it causes all characters until the end of the current 64-character “line” to be ignored.

In Gforth, when you use `block` with a non-existent block number, the current blocks file will be extended to the appropriate size and the block buffer will be initialised with spaces.

Gforth includes a simple block editor (type `use blocked.fb 0 list` for details) but doesn’t encourage the use of blocks; the mechanism is only provided for backward compatibility.

Common techniques that are used when working with blocks include:

  - A screen editor that allows you to edit blocks without leaving the Forth environment.
  - Shadow screens; where every code block has an associated block containing comments (for example: code in odd block numbers, comments in even block numbers). Typically, the block editor provides a convenient mechanism to toggle between code and comments.
  - Load blocks; a single block (typically block 1) contains a number of `thru` commands which `load` the whole of the application.

See Frank Sergeant’s Pygmy Forth to see just how well blocks can be integrated into a Forth programming environment.

<span id="index-open_002dblocks--c_002daddr-u-_002d_002d--gforth"></span> <span id="index-open_002dblocks"></span> <span id="index-open_002dblocks-1"></span>

<div class="format">

``` format
open-blocks       c-addr u –         gforth       “open-blocks”
```

</div>

Use the file, whose name is given by *c-addr u*, as the blocks file.

<span id="index-use--_0022file_0022-_002d_002d--gforth"></span> <span id="index-use"></span> <span id="index-use-1"></span>

<div class="format">

``` format
use       "file" –         gforth       “use”
```

</div>

Use *file* as the blocks file.

<span id="index-block_002doffset--_002d_002d-addr--gforth"></span> <span id="index-block_002doffset"></span> <span id="index-block_002doffset-1"></span>

<div class="format">

``` format
block-offset       – addr         gforth       “block-offset”
```

</div>

User variable containing the number of the first block (default since 0.5.0: 0). Block files created with Gforth versions before 0.5.0 have the offset 1. If you use these files you can: `1 offset !`; or add 1 to every block number used; or prepend 1024 characters to the file.

<span id="index-get_002dblock_002dfid--_002d_002d-wfileid--gforth"></span> <span id="index-get_002dblock_002dfid"></span> <span id="index-get_002dblock_002dfid-1"></span>

<div class="format">

``` format
get-block-fid       – wfileid         gforth       “get-block-fid”
```

</div>

Return the file-id of the current blocks file. If no blocks file has been opened, use `blocks.fb` as the default blocks file.

<span id="index-block_002dposition--u-_002d_002d--block"></span> <span id="index-block_002dposition"></span> <span id="index-block_002dposition-1"></span>

<div class="format">

``` format
block-position       u –         block       “block-position”
```

</div>

Position the block file to the start of block *u*.

<span id="index-list--u-_002d_002d--block_002dext"></span> <span id="index-list"></span> <span id="index-list-1"></span>

<div class="format">

``` format
list       u –         block-ext       “list”
```

</div>

Display block *u*. In Gforth, the block is displayed as 16 numbered lines, each of 64 characters.

<span id="index-scr--_002d_002d-a_002daddr--block_002dext"></span> <span id="index-scr"></span> <span id="index-scr-1"></span>

<div class="format">

``` format
scr       – a-addr         block-ext       “s-c-r”
```

</div>

`User` variable containing the block number of the block most recently processed by `list`.

<span id="index-block--u-_002d_002d-a_002daddr--block"></span> <span id="index-block"></span> <span id="index-block-1"></span>

<div class="format">

``` format
block       u – a-addr         block       “block”
```

</div>

If a block buffer is assigned for block *u*, return its start address, *a-addr*. Otherwise, assign a block buffer for block *u* (if the assigned block buffer has been `update`d, transfer the contents to mass storage), read the block into the block buffer and return its start address, *a-addr*.

<span id="index-buffer--u-_002d_002d-a_002daddr--block"></span> <span id="index-buffer"></span> <span id="index-buffer-1"></span>

<div class="format">

``` format
buffer       u – a-addr         block       “buffer”
```

</div>

If a block buffer is assigned for block *u*, return its start address, *a-addr*. Otherwise, assign a block buffer for block *u* (if the assigned block buffer has been `update`d, transfer the contents to mass storage) and return its start address, *a-addr*. The subtle difference between `buffer` and `block` mean that you should only use `buffer` if you don’t care about the previous contents of block *u*. In Gforth, this simply calls `block`.

<span id="index-empty_002dbuffers--_002d_002d--block_002dext"></span> <span id="index-empty_002dbuffers"></span> <span id="index-empty_002dbuffers-1"></span>

<div class="format">

``` format
empty-buffers       –         block-ext       “empty-buffers”
```

</div>

Mark all block buffers as unassigned; if any had been marked as assigned-dirty (by `update`), the changes to those blocks will be lost.

<span id="index-empty_002dbuffer--buffer-_002d_002d--gforth"></span> <span id="index-empty_002dbuffer"></span> <span id="index-empty_002dbuffer-1"></span>

<div class="format">

``` format
empty-buffer       buffer –         gforth       “empty-buffer”
```

</div>

<span id="index-update--_002d_002d--block"></span> <span id="index-update"></span> <span id="index-update-1"></span>

<div class="format">

``` format
update       –         block       “update”
```

</div>

Mark the state of the current block buffer as assigned-dirty.

<span id="index-updated_003f--n-_002d_002d-f--gforth"></span> <span id="index-updated_003f"></span> <span id="index-updated_003f-1"></span>

<div class="format">

``` format
updated?       n – f         gforth       “updated?”
```

</div>

Return true if `updated` has been used to mark block *n* as assigned-dirty.

<span id="index-save_002dbuffers--_002d_002d--block"></span> <span id="index-save_002dbuffers"></span> <span id="index-save_002dbuffers-1"></span>

<div class="format">

``` format
save-buffers       –         block       “save-buffers”
```

</div>

Transfer the contents of each `update`d block buffer to mass storage, then mark all block buffers as assigned-clean.

<span id="index-save_002dbuffer--buffer-_002d_002d--gforth"></span> <span id="index-save_002dbuffer"></span> <span id="index-save_002dbuffer-1"></span>

<div class="format">

``` format
save-buffer       buffer –         gforth       “save-buffer”
```

</div>

<span id="index-flush--_002d_002d--block"></span> <span id="index-flush"></span> <span id="index-flush-1"></span>

<div class="format">

``` format
flush       –         block       “flush”
```

</div>

Perform the functions of `save-buffers` then `empty-buffers`.

<span id="index-load--i_002ax-u-_002d_002d-j_002ax--block"></span> <span id="index-load"></span> <span id="index-load-1"></span>

<div class="format">

``` format
load       i*x u – j*x         block       “load”
```

</div>

Text-interpret block *u*. Block 0 cannot be `load`ed.

<span id="index-thru--i_002ax-n1-n2-_002d_002d-j_002ax--block_002dext"></span> <span id="index-thru"></span> <span id="index-thru-1"></span>

<div class="format">

``` format
thru       i*x n1 n2 – j*x         block-ext       “thru”
```

</div>

`load` the blocks *n1* through *n2* in sequence.

<span id="index-_002bload--i_002ax-n-_002d_002d-j_002ax--gforth"></span> <span id="index-_002bload"></span> <span id="index-_002bload-1"></span>

<div class="format">

``` format
+load       i*x n – j*x         gforth       “+load”
```

</div>

Used within a block to load the block specified as the current block + *n*.

<span id="index-_002bthru--i_002ax-n1-n2-_002d_002d-j_002ax--gforth"></span> <span id="index-_002bthru"></span> <span id="index-_002bthru-1"></span>

<div class="format">

``` format
+thru       i*x n1 n2 – j*x         gforth       “+thru”
```

</div>

Used within a block to load the range of blocks specified as the current block + *n1* thru the current block + *n2*.

<span id="index-_002d_002d_003e--_002d_002d--gforth"></span> <span id="index-_002d_002d_003e"></span> <span id="index-_002d_002d_003e-1"></span>

<div class="format">

``` format
-->       –         gforth       “chain”
```

</div>

If this symbol is encountered whilst loading block *n*, discard the remainder of the block and load block *n+1*. Used for chaining multiple blocks together as a single loadable unit. Not recommended, because it destroys the independence of loading. Use `thru` (which is standard) or `+thru` instead.

<span id="index-block_002dincluded--a_002daddr-u-_002d_002d--gforth"></span> <span id="index-block_002dincluded"></span> <span id="index-block_002dincluded-1"></span>

<div class="format">

``` format
block-included       a-addr u –         gforth       “block-included”
```

</div>

Use within a block that is to be processed by `load`. Save the current blocks file specification, open the blocks file specified by *a-addr u* and `load` block 1 from that file (which may in turn chain or load other blocks). Finally, close the blocks file and restore the original blocks file.

<div class="footnote">

-----

#### Footnotes

### [(30)](#DOCF30)

The Standard Forth definition of `buffer` is intended not to cause disk I/O; if the data associated with the particular block is already stored in a block buffer due to an earlier `block` command, `buffer` will return that block buffer and the existing contents of the block will be available. Otherwise, `buffer` will simply assign a new, empty block buffer for the block.

</div>

-----

<div class="header">

Next: [Other I/O](Other-I_002fO.html#Other-I_002fO), Previous: [Files](Files.html#Files), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

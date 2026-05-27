> Source: https://gforth.org/manual/Invoking-Gforth.html

<span id="Invoking-Gforth"></span>

<div class="header">

Next: [Leaving Gforth](Leaving-Gforth.html#Leaving-Gforth), Previous: [Gforth Environment](Gforth-Environment.html#Gforth-Environment), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Invoking-Gforth-1"></span>

### 2.1 Invoking Gforth

<span id="index-invoking-Gforth"></span> <span id="index-running-Gforth"></span> <span id="index-command_002dline-options"></span> <span id="index-options-on-the-command-line"></span> <span id="index-flags-on-the-command-line"></span>

Gforth is made up of two parts; an executable “engine” (named `gforth` or `gforth-fast`) and an image file. To start it, you will usually just say `gforth` – this automatically loads the default image file `gforth.fi`. In many other cases the default Gforth image will be invoked like this:

<div class="example">

``` example
gforth [file | -e forth-code] ...
```

</div>

This interprets the contents of the files and the Forth code in the order they are given.

In addition to the `gforth` engine, there is also an engine called `gforth-fast`, which is faster, but gives less informative error messages (see [Error messages](Error-messages.html#Error-messages)) and may catch some errors (in particular, stack underflows and integer division errors) later or not at all. You should use it for debugged, performance-critical programs.

Moreover, there is an engine called `gforth-itc`, which is useful in some backwards-compatibility situations (see [Direct or Indirect Threaded?](Direct-or-Indirect-Threaded_003f.html#Direct-or-Indirect-Threaded_003f)).

In general, the command line looks like this:

<div class="example">

``` example
gforth[-fast] [engine options] [image options]
```

</div>

The engine options must come before the rest of the command line. They are:

<span id="index-_002di_002c-command_002dline-option"></span> <span id="index-_002d_002dimage_002dfile_002c-command_002dline-option"></span>

`--image-file file`

`-i file`

Loads the Forth image *file* instead of the default `gforth.fi` (see [Image Files](Image-Files.html#Image-Files)).

<span id="index-_002d_002dappl_002dimage_002c-command_002dline-option"></span>

`--appl-image file`

Loads the image *file* and leaves all further command-line arguments to the image (instead of processing them as engine options). This is useful for building executable application images on Unix, built with `gforthmi --application ...`.

<span id="index-_002d_002dpath_002c-command_002dline-option"></span> <span id="index-_002dp_002c-command_002dline-option"></span>

`--path path`

`-p path`

Uses *path* for searching the image file and Forth source code files instead of the default in the environment variable `GFORTHPATH` or the path specified at installation time and the working directory `.` (e.g., `/usr/local/share/gforth/0.2.0:.`). A path is given as a list of directories, separated by ‘`:`’ (previous versions had ‘`;`’ for other OSes, but since Cygwin now only accepts `/cygdrive/<letter>`, and we dropped support for OS/2 and MS-DOS, it is ‘`:`’ everywhere).

<span id="index-_002d_002ddictionary_002dsize_002c-command_002dline-option"></span> <span id="index-_002dm_002c-command_002dline-option"></span> <span id="index-size-parameters-for-command_002dline-options"></span> <span id="index-size-of-the-dictionary-and-the-stacks"></span>

`--dictionary-size size`

`-m size`

Allocate *size* space for the Forth dictionary space instead of using the default specified in the image (typically 256K). The *size* specification for this and subsequent options consists of an integer and a unit (e.g., `4M`). The unit can be one of `b` (bytes), `e` (element size, in this case Cells), `k` (kilobytes), `M` (Megabytes), `G` (Gigabytes), and `T` (Terabytes). If no unit is specified, `e` is used.

<span id="index-_002d_002ddata_002dstack_002dsize_002c-command_002dline-option"></span> <span id="index-_002dd_002c-command_002dline-option"></span>

`--data-stack-size size`

`-d size`

Allocate *size* space for the data stack instead of using the default specified in the image (typically 16K).

<span id="index-_002d_002dreturn_002dstack_002dsize_002c-command_002dline-option"></span> <span id="index-_002dr_002c-command_002dline-option"></span>

`--return-stack-size size`

`-r size`

Allocate *size* space for the return stack instead of using the default specified in the image (typically 15K).

<span id="index-_002d_002dfp_002dstack_002dsize_002c-command_002dline-option"></span> <span id="index-_002df_002c-command_002dline-option"></span>

`--fp-stack-size size`

`-f size`

Allocate *size* space for the floating point stack instead of using the default specified in the image (typically 15.5K). In this case the unit specifier `e` refers to floating point numbers.

<span id="index-_002d_002dlocals_002dstack_002dsize_002c-command_002dline-option"></span> <span id="index-_002dl_002c-command_002dline-option"></span>

`--locals-stack-size size`

`-l size`

Allocate *size* space for the locals stack instead of using the default specified in the image (typically 14.5K).

<span id="index-_002d_002dvm_002dcommit_002c-command_002dline-option"></span> <span id="index-overcommit-memory-for-dictionary-and-stacks"></span> <span id="index-memory-overcommit-for-dictionary-and-stacks"></span>

`--vm-commit`

Normally, Gforth tries to start up even if there is not enough virtual memory for the dictionary and the stacks (using `MAP_NORESERVE` on OSs that support it); so you can ask for a really big dictionary and/or stacks, and as long as you don’t use more virtual memory than is available, everything will be fine (but if you use more, processes get killed). With this option you just use the default allocation policy of the OS; for OSs that don’t overcommit (e.g., Solaris), this means that you cannot and should not ask for as big dictionary and stacks, but once Gforth successfully starts up, out-of-memory won’t kill it.

<span id="index-_002dh_002c-command_002dline-option"></span> <span id="index-_002d_002dhelp_002c-command_002dline-option"></span>

`--help`

`-h`

Print a message about the command-line options

<span id="index-_002dv_002c-command_002dline-option"></span> <span id="index-_002d_002dversion_002c-command_002dline-option"></span>

`--version`

`-v`

Print version and exit

<span id="index-_002d_002ddebug_002c-command_002dline-option"></span>

`--debug`

Print some information useful for debugging on startup.

<span id="index-_002d_002doffset_002dimage_002c-command_002dline-option"></span>

`--offset-image`

Start the dictionary at a slightly different position than would be used otherwise (useful for creating data-relocatable images, see [Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files)).

<span id="index-_002d_002dno_002doffset_002dim_002c-command_002dline-option"></span>

`--no-offset-im`

Start the dictionary at the normal position.

<span id="index-_002d_002dclear_002ddictionary_002c-command_002dline-option"></span>

`--clear-dictionary`

Initialize all bytes in the dictionary to 0 before loading the image (see [Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files)).

<span id="index-_002d_002ddie_002don_002dsignal_002c-command_002dline_002doption"></span>

`--die-on-signal`

Normally Gforth handles most signals (e.g., the user interrupt SIGINT, or the segmentation violation SIGSEGV) by translating it into a Forth `THROW`. With this option, Gforth exits if it receives such a signal. This option is useful when the engine and/or the image might be severely broken (such that it causes another signal before recovering from the first); this option avoids endless loops in such cases.

<span id="index-_002d_002dno_002ddynamic_002c-command_002dline-option"></span> <span id="index-_002d_002ddynamic_002c-command_002dline-option"></span>

`--no-dynamic`

`--dynamic`

Disable or enable dynamic superinstructions with replication (see [Dynamic Superinstructions](Dynamic-Superinstructions.html#Dynamic-Superinstructions)).

<span id="index-_002d_002dno_002dsuper_002c-command_002dline-option"></span>

`--no-super`

Disable dynamic superinstructions, use just dynamic replication; this is useful if you want to patch threaded code (see [Dynamic Superinstructions](Dynamic-Superinstructions.html#Dynamic-Superinstructions)).

<span id="index-_002d_002dss_002dnumber_002c-command_002dline-option"></span>

`--ss-number=N`

Use only the first `N` static superinstructions compiled into the engine (default: use them all; note that only `gforth-fast` has any). This option is useful for measuring the performance impact of static superinstructions.

<span id="index-_002d_002dss_002dmin_002d_002e_002e_002e_002c-command_002dline-options"></span>

`--ss-min-codesize`

`--ss-min-ls`

`--ss-min-lsu`

`--ss-min-nexts`

Use specified metric for determining the cost of a primitive or static superinstruction for static superinstruction selection. `Codesize` is the native code size of the primive or static superinstruction, `ls` is the number of loads and stores, `lsu` is the number of loads, stores, and updates, and `nexts` is the number of dispatches (not taking dynamic superinstructions into account), i.e. every primitive or static superinstruction has cost 1. Default: `codesize` if you use dynamic code generation, otherwise `nexts`.

<span id="index-_002d_002dss_002dgreedy_002c-command_002dline-option"></span>

`--ss-greedy`

This option is useful for measuring the performance impact of static superinstructions. By default, an optimal shortest-path algorithm is used for selecting static superinstructions. With `--ss-greedy` this algorithm is modified to assume that anything after the static superinstruction currently under consideration is not combined into static superinstructions. With `--ss-min-nexts` this produces the same result as a greedy algorithm that always selects the longest superinstruction available at the moment. E.g., if there are superinstructions AB and BCD, then for the sequence A B C D the optimal algorithm will select A BCD and the greedy algorithm will select AB C D.

<span id="index-_002d_002dprint_002dmetrics_002c-command_002dline-option"></span>

`--print-metrics`

Prints some metrics used during static superinstruction selection: `code size` is the actual size of the dynamically generated code. `Metric codesize` is the sum of the codesize metrics as seen by static superinstruction selection; there is a difference from `code size`, because not all primitives and static superinstructions are compiled into dynamically generated code, and because of markers. The other metrics correspond to the `ss-min-...` options. This option is useful for evaluating the effects of the `--ss-...` options.

<span id="index-loading-files-at-startup"></span> <span id="index-executing-code-on-startup"></span> <span id="index-batch-processing-with-Gforth"></span>

As explained above, the image-specific command-line arguments for the default image `gforth.fi` consist of a sequence of filenames and `-e forth-code` options that are interpreted in the sequence in which they are given. The `-e forth-code` or `--evaluate forth-code` option evaluates the Forth code. This option takes only one argument; if you want to evaluate more Forth words, you have to quote them or use `-e` several times. To exit after processing the command line (instead of entering interactive mode) append `-e bye` to the command line. You can also process the command-line arguments with a Forth program (see [OS command line arguments](OS-command-line-arguments.html#OS-command-line-arguments)).

<span id="index-versions_002c-invoking-other-versions-of-Gforth"></span>

If you have several versions of Gforth installed, `gforth` will invoke the version that was installed last. `gforth-version` invokes a specific version. If your environment contains the variable `GFORTHPATH`, you may want to override it by using the `--path` option.

On startup, before processing any of the image option, the user initialization file either specified in the environment variable `GFORTH_ENV` or, if not set, `~/.gforthrc0` is included, if it exists. If `GFORTH_ENV` is “`off`,” nothing is included. After processing all the image options and just before printing the boot message, the user initialization file `~/.gforthrc` from your home directory is included, unless the option `--no-rc` is given.

-----

<div class="header">

Next: [Leaving Gforth](Leaving-Gforth.html#Leaving-Gforth), Previous: [Gforth Environment](Gforth-Environment.html#Gforth-Environment), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

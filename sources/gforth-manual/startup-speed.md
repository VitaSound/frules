> Source: https://gforth.org/manual/Startup-speed.html

<span id="Startup-speed"></span>

<div class="header">

Previous: [Gforth in pipes](Gforth-in-pipes.html#Gforth-in-pipes), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Startup-speed-1"></span>

### 2.7 Startup speed

<span id="index-Startup-speed"></span> <span id="index-speed_002c-startup"></span>

If Gforth is used for CGI scripts or in shell scripts, its startup speed may become a problem. On a 3GHz Core 2 Duo E8400 under 64-bit Linux 2.6.27.8 with libc-2.7, `gforth-fast -e bye` takes 13.1ms user and 1.2ms system time (`gforth -e bye` is faster on startup with about 3.4ms user time and 1.2ms system time, because it subsumes some of the options discussed below).

If startup speed is a problem, you may consider the following ways to improve it; or you may consider ways to reduce the number of startups (for example, by using Fast-CGI). Note that the first steps below improve the startup time at the cost of run-time (including compile-time), so whether they are profitable depends on the balance of these times in your application.

An easy step that influences Gforth startup speed is the use of a number of options that increase run-time, but decrease image-loading time.

The first of these that you should try is `--ss-number=0 --ss-states=1` because this option buys relatively little run-time speedup and costs quite a bit of time at startup. `gforth-fast --ss-number=0 --ss-states=1 -e bye` takes about 2.8ms user and 1.5ms system time.

The next option is `--no-dynamic` which has a substantial impact on run-time (about a factor of 2 on several platforms), but still makes startup speed a little faster: `gforth-fast --ss-number=0 --ss-states=1 --no-dynamic -e bye` consumes about 2.6ms user and 1.2ms system time.

The next step to improve startup speed is to use a data-relocatable image (see [Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files)). This avoids the relocation cost for the code in the image (but not for the data). Note that the image is then specific to the particular binary you are using (i.e., whether it is `gforth`, `gforth-fast`, and even the particular build). You create the data-relocatable image that works with `./gforth-fast` with `GFORTHD="./gforth-fast --no-dynamic" gforthmi gforthdr.fi` (the `--no-dynamic` is required here or the image will not work). And you run it with `gforth-fast -i gforthdr.fi ... -e bye` (the flags discussed above don’t matter here, because they only come into play on relocatable code). `gforth-fast -i gforthdr.fi -e bye` takes about 1.1ms user and 1.2ms system time.

One step further is to avoid all relocation cost and part of the copy-on-write cost through using a non-relocatable image (see [Non-Relocatable Image Files](Non_002dRelocatable-Image-Files.html#Non_002dRelocatable-Image-Files)). However, this has the disadvantage that it does not work on operating systems with address space randomization (the default in, e.g., Linux nowadays), or if the dictionary moves for any other reason (e.g., because of a change of the OS kernel or an updated library), so we cannot really recommend it. You create a non-relocatable image with `gforth-fast --no-dynamic -e "savesystem gforthnr.fi bye"` (the `--no-dynamic` is required here, too). And you run it with `gforth-fast -i gforthnr.fi ... -e bye` (again the flags discussed above don’t matter). `gforth-fast -i gforthdr.fi -e bye` takes about 0.9ms user and 0.9ms system time.

If the script you want to execute contains a significant amount of code, it may be profitable to compile it into the image to avoid the cost of compiling it at startup time.

-----

<div class="header">

Previous: [Gforth in pipes](Gforth-in-pipes.html#Gforth-in-pipes), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

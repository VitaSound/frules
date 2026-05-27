> Source: https://gforth.org/manual/Keeping-track-of-Time.html

<span id="Keeping-track-of-Time"></span>

<div class="header">

Next: [Miscellaneous Words](Miscellaneous-Words.html#Miscellaneous-Words), Previous: [Passing Commands to the OS](Passing-Commands-to-the-OS.html#Passing-Commands-to-the-OS), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Keeping-track-of-Time-1"></span>

### 5.30 Keeping track of Time

<span id="index-time_002drelated-words"></span> <span id="index-ms--n-_002d_002d--unknown"></span> <span id="index-ms"></span> <span id="index-ms-1"></span>

<div class="format">

``` format
ms       n –         unknown       “ms”
```

</div>

<span id="index-time_0026date--_002d_002d-nsec-nmin-nhour-nday-nmonth-nyear--facility_002dext"></span> <span id="index-time_0026date"></span> <span id="index-time_0026date-1"></span>

<div class="format">

``` format
time&date       – nsec nmin nhour nday nmonth nyear        facility-ext       “time-and-date”
```

</div>

Report the current time of day. Seconds, minutes and hours are numbered from 0. Months are numbered from 1.

<span id="index-utime--_002d_002d-dtime--gforth"></span> <span id="index-utime"></span> <span id="index-utime-1"></span>

<div class="format">

``` format
utime       – dtime        gforth       “utime”
```

</div>

Report the current time in microseconds since some epoch.

<span id="index-cputime--_002d_002d-duser-dsystem--gforth"></span> <span id="index-cputime"></span> <span id="index-cputime-1"></span>

<div class="format">

``` format
cputime       – duser dsystem        gforth       “cputime”
```

</div>

duser and dsystem are the respective user- and system-level CPU times used since the start of the Forth system (excluding child processes), in microseconds (the granularity may be much larger, however). On platforms without the getrusage call, it reports elapsed time (since some epoch) for duser and 0 for dsystem.

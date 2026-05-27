> Source: https://gforth.org/manual/facility_002didef.html

<span id="facility_002didef"></span>

<div class="header">

Next: [facility-ambcond](facility_002dambcond.html#facility_002dambcond), Previous: [The optional Facility word set](The-optional-Facility-word-set.html#The-optional-Facility-word-set), Up: [The optional Facility word set](The-optional-Facility-word-set.html#The-optional-Facility-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Implementation-Defined-Options-3"></span>

#### 8.5.1 Implementation Defined Options

<span id="index-implementation_002ddefined-options_002c-facility-words"></span> <span id="index-facility-words_002c-implementation_002ddefined-options"></span>

  - *encoding of keyboard events (`EKEY`):*  
    <span id="index-keyboard-events_002c-encoding-in-EKEY"></span> <span id="index-EKEY_002c-encoding-of-keyboard-events"></span>
    
    Keys corresponding to ASCII characters are encoded as ASCII characters. Other keys are encoded with the constants `k-left`, `k-right`, `k-up`, `k-down`, `k-home`, `k-end`, `k1`, `k2`, `k3`, `k4`, `k5`, `k6`, `k7`, `k8`, `k9`, `k10`, `k11`, `k12`, `k-winch`, `k-eof`.

  - *duration of a system clock tick:*  
    <span id="index-duration-of-a-system-clock-tick"></span> <span id="index-clock-tick-duration"></span>
    
    System dependent. With respect to `MS`, the time is specified in microseconds. How well the OS and the hardware implement this, is another question.

  - *repeatability to be expected from the execution of `MS`:*  
    <span id="index-repeatability-to-be-expected-from-the-execution-of-MS"></span> <span id="index-MS_002c-repeatability-to-be-expected"></span>
    
    System dependent. On Unix, a lot depends on load. If the system is lightly loaded, and the delay is short enough that Gforth does not get swapped out, the performance should be acceptable. Under MS-DOS and other single-tasking systems, it should be good.

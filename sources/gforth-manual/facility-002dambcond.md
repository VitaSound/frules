> Source: https://gforth.org/manual/facility_002dambcond.html

<span id="facility_002dambcond"></span>

<div class="header">

Previous: [facility-idef](facility_002didef.html#facility_002didef), Up: [The optional Facility word set](The-optional-Facility-word-set.html#The-optional-Facility-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ambiguous-conditions-3"></span>

#### 8.5.2 Ambiguous conditions

<span id="index-facility-words_002c-ambiguous-conditions"></span> <span id="index-ambiguous-conditions_002c-facility-words"></span>

  - *`AT-XY` can’t be performed on user output device:*  
    <span id="index-AT_002dXY-can_0027t-be-performed-on-user-output-device"></span>
    
    Largely terminal dependent. No range checks are done on the arguments. No errors are reported. You may see some garbage appearing, you may see simply nothing happen.

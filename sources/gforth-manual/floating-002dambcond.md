> Source: https://gforth.org/manual/floating_002dambcond.html

<span id="floating_002dambcond"></span>

<div class="header">

Previous: [floating-idef](floating_002didef.html#floating_002didef), Up: [The optional Floating-Point word set](The-optional-Floating_002dPoint-word-set.html#The-optional-Floating_002dPoint-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ambiguous-conditions-5"></span>

#### 8.7.2 Ambiguous conditions

<span id="index-floating_002dpoint-words_002c-ambiguous-conditions"></span> <span id="index-ambiguous-conditions_002c-floating_002dpoint-words"></span>

  - *`df@` or `df!` used with an address that is not double-float aligned:*  
    <span id="index-df_0040-or-df_0021-used-with-an-address-that-is-not-double_002dfloat-aligned"></span>
    
    System-dependent. Typically results in a `-23 THROW` like other alignment violations.

  - *`f@` or `f!` used with an address that is not float aligned:*  
    <span id="index-f_0040-used-with-an-address-that-is-not-float-aligned"></span> <span id="index-f_0021-used-with-an-address-that-is-not-float-aligned"></span>
    
    System-dependent. Typically results in a `-23 THROW` like other alignment violations.

  - *floating-point result out of range:*  
    <span id="index-floating_002dpoint-result-out-of-range"></span>
    
    System-dependent. Can result in a `-43 throw` (floating point overflow), `-54 throw` (floating point underflow), `-41 throw` (floating point inexact result), `-55 THROW` (Floating-point unidentified fault), or can produce a special value representing, e.g., Infinity.

  - *`sf@` or `sf!` used with an address that is not single-float aligned:*  
    <span id="index-sf_0040-or-sf_0021-used-with-an-address-that-is-not-single_002dfloat-aligned"></span>
    
    System-dependent. Typically results in an alignment fault like other alignment violations.

  - *`base` is not decimal (`REPRESENT`, `F.`, `FE.`, `FS.`):*  
    <span id="index-base-is-not-decimal-_0028REPRESENT_002c-F_002e_002c-FE_002e_002c-FS_002e_0029"></span>
    
    The floating-point number is converted into decimal nonetheless.

  - *Both arguments are equal to zero (`FATAN2`):*  
    <span id="index-FATAN2_002c-both-arguments-are-equal-to-zero"></span>
    
    System-dependent. `FATAN2` is implemented using the C library function `atan2()`.

  - *Using `FTAN` on an argument *r1* where cos(*r1*) is zero:*  
    <span id="index-FTAN-on-an-argument-r1-where-cos_0028r1_0029-is-zero"></span>
    
    System-dependent. Anyway, typically the cos of *r1* will not be zero because of small errors and the tan will be a very large (or very small) but finite number.

  - **d* cannot be presented precisely as a float in `D>F`:*  
    <span id="index-D_003eF_002c-d-cannot-be-presented-precisely-as-a-float"></span>
    
    The result is rounded to the nearest float.

  - *dividing by zero:*  
    <span id="index-dividing-by-zero_002c-floating_002dpoint"></span> <span id="index-floating_002dpoint-dividing-by-zero"></span> <span id="index-floating_002dpoint-unidentified-fault_002c-FP-divide_002dby_002dzero"></span>
    
    Platform-dependent; can produce an Infinity, NaN, `-42 throw` (floating point divide by zero) or `-55 throw` (Floating-point unidentified fault).

  - *exponent too big for conversion (`DF!`, `DF@`, `SF!`, `SF@`):*  
    <span id="index-exponent-too-big-for-conversion-_0028DF_0021_002c-DF_0040_002c-SF_0021_002c-SF_0040_0029"></span>
    
    System dependent. On IEEE-FP based systems the number is converted into an infinity.

  - **float*\<1 (`FACOSH`):*  
    <span id="index-FACOSH_002c-float_003c1"></span> <span id="index-floating_002dpoint-unidentified-fault_002c-FACOSH"></span>
    
    Platform-dependent; on IEEE-FP systems typically produces a NaN.

  - **float*\<=-1 (`FLNP1`):*  
    <span id="index-FLNP1_002c-float_003c_003d_002d1"></span> <span id="index-floating_002dpoint-unidentified-fault_002c-FLNP1"></span>
    
    Platform-dependent; on IEEE-FP systems typically produces a NaN (or a negative infinity for *float*=-1).

  - **float*\<=0 (`FLN`, `FLOG`):*  
    <span id="index-FLN_002c-float_003c_003d0"></span> <span id="index-FLOG_002c-float_003c_003d0"></span> <span id="index-floating_002dpoint-unidentified-fault_002c-FLN-or-FLOG"></span>
    
    Platform-dependent; on IEEE-FP systems typically produces a NaN (or a negative infinity for *float*=0).

  - **float*\<0 (`FASINH`, `FSQRT`):*  
    <span id="index-FASINH_002c-float_003c0"></span> <span id="index-FSQRT_002c-float_003c0"></span> <span id="index-floating_002dpoint-unidentified-fault_002c-FASINH-or-FSQRT"></span>
    
    Platform-dependent; for `fsqrt` this typically gives a NaN, for `fasinh` some platforms produce a NaN, others a number (bug in the C library?).

  - *|*float*|\>1 (`FACOS`, `FASIN`, `FATANH`):*  
    <span id="index-FACOS_002c-_007cfloat_007c_003e1"></span> <span id="index-FASIN_002c-_007cfloat_007c_003e1"></span> <span id="index-FATANH_002c-_007cfloat_007c_003e1"></span> <span id="index-floating_002dpoint-unidentified-fault_002c-FACOS_002c-FASIN-or-FATANH"></span>
    
    Platform-dependent; IEEE-FP systems typically produce a NaN.

  - *integer part of float cannot be represented by *d* in `F>D`:*  
    <span id="index-F_003eD_002c-integer-part-of-float-cannot-be-represented-by-d"></span> <span id="index-floating_002dpoint-unidentified-fault_002c-F_003eD"></span>
    
    Platform-dependent; typically, some double number is produced and no error is reported.

  - *string larger than pictured numeric output area (`f.`, `fe.`, `fs.`):*  
    <span id="index-string-larger-than-pictured-numeric-output-area-_0028f_002e_002c-fe_002e_002c-fs_002e_0029"></span>
    
    `Precision` characters of the numeric output area are used. If `precision` is too high, these words will smash the data or code close to `here`.

-----

<div class="header">

Previous: [floating-idef](floating_002didef.html#floating_002didef), Up: [The optional Floating-Point word set](The-optional-Floating_002dPoint-word-set.html#The-optional-Floating_002dPoint-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

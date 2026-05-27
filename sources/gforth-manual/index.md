> Source: https://gforth.org/manual/index.html

# Gforth Manual

<span id="SEC_Contents"></span>

## Table of Contents

<div class="contents">

  - [1 Goals of Gforth](Goals.html#Goals)
  - [2 Gforth Environment](Gforth-Environment.html#Gforth-Environment)
      - [2.1 Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)
      - [2.2 Leaving Gforth](Leaving-Gforth.html#Leaving-Gforth)
      - [2.3 Command-line editing](Command_002dline-editing.html#Command_002dline-editing)
      - [2.4 Environment variables](Environment-variables.html#Environment-variables)
      - [2.5 Gforth files](Gforth-Files.html#Gforth-Files)
      - [2.6 Gforth in pipes](Gforth-in-pipes.html#Gforth-in-pipes)
      - [2.7 Startup speed](Startup-speed.html#Startup-speed)
  - [3 Forth Tutorial](Tutorial.html#Tutorial)
      - [3.1 Starting Gforth](Starting-Gforth-Tutorial.html#Starting-Gforth-Tutorial)
      - [3.2 Syntax](Syntax-Tutorial.html#Syntax-Tutorial)
      - [3.3 Crash Course](Crash-Course-Tutorial.html#Crash-Course-Tutorial)
      - [3.4 Stack](Stack-Tutorial.html#Stack-Tutorial)
      - [3.5 Arithmetics](Arithmetics-Tutorial.html#Arithmetics-Tutorial)
      - [3.6 Stack Manipulation](Stack-Manipulation-Tutorial.html#Stack-Manipulation-Tutorial)
      - [3.7 Using files for Forth code](Using-files-for-Forth-code-Tutorial.html#Using-files-for-Forth-code-Tutorial)
      - [3.8 Comments](Comments-Tutorial.html#Comments-Tutorial)
      - [3.9 Colon Definitions](Colon-Definitions-Tutorial.html#Colon-Definitions-Tutorial)
      - [3.10 Decompilation](Decompilation-Tutorial.html#Decompilation-Tutorial)
      - [3.11 Stack-Effect Comments](Stack_002dEffect-Comments-Tutorial.html#Stack_002dEffect-Comments-Tutorial)
      - [3.12 Types](Types-Tutorial.html#Types-Tutorial)
      - [3.13 Factoring](Factoring-Tutorial.html#Factoring-Tutorial)
      - [3.14 Designing the stack effect](Designing-the-stack-effect-Tutorial.html#Designing-the-stack-effect-Tutorial)
      - [3.15 Local Variables](Local-Variables-Tutorial.html#Local-Variables-Tutorial)
      - [3.16 Conditional execution](Conditional-execution-Tutorial.html#Conditional-execution-Tutorial)
      - [3.17 Flags and Comparisons](Flags-and-Comparisons-Tutorial.html#Flags-and-Comparisons-Tutorial)
      - [3.18 General Loops](General-Loops-Tutorial.html#General-Loops-Tutorial)
      - [3.19 Counted loops](Counted-loops-Tutorial.html#Counted-loops-Tutorial)
      - [3.20 Recursion](Recursion-Tutorial.html#Recursion-Tutorial)
      - [3.21 Leaving definitions or loops](Leaving-definitions-or-loops-Tutorial.html#Leaving-definitions-or-loops-Tutorial)
      - [3.22 Return Stack](Return-Stack-Tutorial.html#Return-Stack-Tutorial)
      - [3.23 Memory](Memory-Tutorial.html#Memory-Tutorial)
      - [3.24 Characters and Strings](Characters-and-Strings-Tutorial.html#Characters-and-Strings-Tutorial)
      - [3.25 Alignment](Alignment-Tutorial.html#Alignment-Tutorial)
      - [3.26 Floating Point](Floating-Point-Tutorial.html#Floating-Point-Tutorial)
      - [3.27 Files](Files-Tutorial.html#Files-Tutorial)
          - [3.27.1 Open file for input](Files-Tutorial.html#Open-file-for-input)
          - [3.27.2 Create file for output](Files-Tutorial.html#Create-file-for-output)
          - [3.27.3 Scan file for a particular line](Files-Tutorial.html#Scan-file-for-a-particular-line)
          - [3.27.4 Copy input to output](Files-Tutorial.html#Copy-input-to-output)
          - [3.27.5 Close files](Files-Tutorial.html#Close-files)
      - [3.28 Interpretation and Compilation Semantics and Immediacy](Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html#Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial)
      - [3.29 Execution Tokens](Execution-Tokens-Tutorial.html#Execution-Tokens-Tutorial)
      - [3.30 Exceptions](Exceptions-Tutorial.html#Exceptions-Tutorial)
      - [3.31 Defining Words](Defining-Words-Tutorial.html#Defining-Words-Tutorial)
      - [3.32 Arrays and Records](Arrays-and-Records-Tutorial.html#Arrays-and-Records-Tutorial)
      - [3.33 `POSTPONE`](POSTPONE-Tutorial.html#POSTPONE-Tutorial)
      - [3.34 `Literal`](Literal-Tutorial.html#Literal-Tutorial)
      - [3.35 Advanced macros](Advanced-macros-Tutorial.html#Advanced-macros-Tutorial)
      - [3.36 Compilation Tokens](Compilation-Tokens-Tutorial.html#Compilation-Tokens-Tutorial)
      - [3.37 Wordlists and Search Order](Wordlists-and-Search-Order-Tutorial.html#Wordlists-and-Search-Order-Tutorial)
  - [4 An Introduction to Standard Forth](Introduction.html#Introduction)
      - [4.1 Introducing the Text Interpreter](Introducing-the-Text-Interpreter.html#Introducing-the-Text-Interpreter)
      - [4.2 Stacks, postfix notation and parameter passing](Stacks-and-Postfix-notation.html#Stacks-and-Postfix-notation)
      - [4.3 Your first Forth definition](Your-first-definition.html#Your-first-definition)
      - [4.4 How does that work?](How-does-that-work_003f.html#How-does-that-work_003f)
      - [4.5 Forth is written in Forth](Forth-is-written-in-Forth.html#Forth-is-written-in-Forth)
      - [4.6 Review - elements of a Forth system](Review-_002d-elements-of-a-Forth-system.html#Review-_002d-elements-of-a-Forth-system)
      - [4.7 Where To Go Next](Where-to-go-next.html#Where-to-go-next)
      - [4.8 Exercises](Exercises.html#Exercises)
  - [5 Forth Words](Words.html#Words)
      - [5.1 Notation](Notation.html#Notation)
      - [5.2 Case insensitivity](Case-insensitivity.html#Case-insensitivity)
      - [5.3 Comments](Comments.html#Comments)
      - [5.4 Boolean Flags](Boolean-Flags.html#Boolean-Flags)
      - [5.5 Arithmetic](Arithmetic.html#Arithmetic)
          - [5.5.1 Single precision](Single-precision.html#Single-precision)
          - [5.5.2 Double precision](Double-precision.html#Double-precision)
          - [5.5.3 Bitwise operations](Bitwise-operations.html#Bitwise-operations)
          - [5.5.4 Numeric comparison](Numeric-comparison.html#Numeric-comparison)
          - [5.5.5 Mixed precision](Mixed-precision.html#Mixed-precision)
          - [5.5.6 Floating Point](Floating-Point.html#Floating-Point)
      - [5.6 Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation)
          - [5.6.1 Data stack](Data-stack.html#Data-stack)
          - [5.6.2 Floating point stack](Floating-point-stack.html#Floating-point-stack)
          - [5.6.3 Return stack](Return-stack.html#Return-stack)
          - [5.6.4 Locals stack](Locals-stack.html#Locals-stack)
          - [5.6.5 Stack pointer manipulation](Stack-pointer-manipulation.html#Stack-pointer-manipulation)
      - [5.7 Memory](Memory.html#Memory)
          - [5.7.1 Memory model](Memory-model.html#Memory-model)
          - [5.7.2 Dictionary allocation](Dictionary-allocation.html#Dictionary-allocation)
          - [5.7.3 Heap allocation](Heap-Allocation.html#Heap-Allocation)
          - [5.7.4 Memory Access](Memory-Access.html#Memory-Access)
          - [5.7.5 Address arithmetic](Address-arithmetic.html#Address-arithmetic)
          - [5.7.6 Memory Blocks](Memory-Blocks.html#Memory-Blocks)
      - [5.8 Control Structures](Control-Structures.html#Control-Structures)
          - [5.8.1 Selection](Selection.html#Selection)
          - [5.8.2 Simple Loops](Simple-Loops.html#Simple-Loops)
          - [5.8.3 Counted Loops](Counted-Loops.html#Counted-Loops)
          - [5.8.4 `Begin` loops with multiple exits](BEGIN-loops-with-multiple-exits.html#BEGIN-loops-with-multiple-exits)
          - [5.8.5 General control structures with `case`](General-control-structures-with-CASE.html#General-control-structures-with-CASE)
          - [5.8.6 Arbitrary control structures](Arbitrary-control-structures.html#Arbitrary-control-structures)
              - [5.8.6.1 Programming Style](Arbitrary-control-structures.html#Programming-Style)
          - [5.8.7 Calls and returns](Calls-and-returns.html#Calls-and-returns)
          - [5.8.8 Exception Handling](Exception-Handling.html#Exception-Handling)
      - [5.9 Defining Words](Defining-Words.html#Defining-Words)
          - [5.9.1 `CREATE`](CREATE.html#CREATE)
          - [5.9.2 Variables](Variables.html#Variables)
          - [5.9.3 Constants](Constants.html#Constants)
          - [5.9.4 Values](Values.html#Values)
          - [5.9.5 Colon Definitions](Colon-Definitions.html#Colon-Definitions)
          - [5.9.6 Anonymous Definitions](Anonymous-Definitions.html#Anonymous-Definitions)
          - [5.9.7 Quotations](Quotations.html#Quotations)
          - [5.9.8 Supplying the name of a defined word](Supplying-names.html#Supplying-names)
          - [5.9.9 User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)
              - [5.9.9.1 Applications of `CREATE..DOES>`](CREATE_002e_002eDOES_003e-applications.html#CREATE_002e_002eDOES_003e-applications)
              - [5.9.9.2 The gory details of `CREATE..DOES>`](CREATE_002e_002eDOES_003e-details.html#CREATE_002e_002eDOES_003e-details)
              - [5.9.9.3 Advanced does\> usage example](Advanced-does_003e-usage-example.html#Advanced-does_003e-usage-example)
              - [5.9.9.4 `Const-does>`](Const_002ddoes_003e.html#Const_002ddoes_003e)
          - [5.9.10 Deferred Words](Deferred-Words.html#Deferred-Words)
          - [5.9.11 Forward](Forward.html#Forward)
          - [5.9.12 Aliases](Aliases.html#Aliases)
      - [5.10 Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics)
          - [5.10.1 Combined Words](Combined-words.html#Combined-words)
      - [5.11 Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)
          - [5.11.1 Execution token](Execution-token.html#Execution-token)
          - [5.11.2 Compilation token](Compilation-token.html#Compilation-token)
          - [5.11.3 Name token](Name-token.html#Name-token)
      - [5.12 Compiling words](Compiling-words.html#Compiling-words)
          - [5.12.1 Literals](Literals.html#Literals)
          - [5.12.2 Macros](Macros.html#Macros)
      - [5.13 The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)
          - [5.13.1 Input Sources](Input-Sources.html#Input-Sources)
          - [5.13.2 Number Conversion](Number-Conversion.html#Number-Conversion)
          - [5.13.3 Interpret/Compile states](Interpret_002fCompile-states.html#Interpret_002fCompile-states)
          - [5.13.4 Interpreter Directives](Interpreter-Directives.html#Interpreter-Directives)
          - [5.13.5 Recognizers](Recognizers.html#Recognizers)
      - [5.14 The Input Stream](The-Input-Stream.html#The-Input-Stream)
      - [5.15 Word Lists](Word-Lists.html#Word-Lists)
          - [5.15.1 Vocabularies](Vocabularies.html#Vocabularies)
          - [5.15.2 Why use word lists?](Why-use-word-lists_003f.html#Why-use-word-lists_003f)
          - [5.15.3 Word list example](Word-list-example.html#Word-list-example)
      - [5.16 Environmental Queries](Environmental-Queries.html#Environmental-Queries)
      - [5.17 Files](Files.html#Files)
          - [5.17.1 Forth source files](Forth-source-files.html#Forth-source-files)
          - [5.17.2 General files](General-files.html#General-files)
          - [5.17.3 Redirection](Redirection.html#Redirection)
          - [5.17.4 Directories](Directories.html#Directories)
          - [5.17.5 Search Paths](Search-Paths.html#Search-Paths)
              - [5.17.5.1 Source Search Paths](Source-Search-Paths.html#Source-Search-Paths)
              - [5.17.5.2 General Search Paths](General-Search-Paths.html#General-Search-Paths)
      - [5.18 Blocks](Blocks.html#Blocks)
      - [5.19 Other I/O](Other-I_002fO.html#Other-I_002fO)
          - [5.19.1 Simple numeric output](Simple-numeric-output.html#Simple-numeric-output)
          - [5.19.2 Formatted numeric output](Formatted-numeric-output.html#Formatted-numeric-output)
          - [5.19.3 String Formats](String-Formats.html#String-Formats)
          - [5.19.4 Displaying characters and strings](Displaying-characters-and-strings.html#Displaying-characters-and-strings)
          - [5.19.5 String words](String-words.html#String-words)
          - [5.19.6 Terminal output](Terminal-output.html#Terminal-output)
          - [5.19.7 Single-key input](Single_002dkey-input.html#Single_002dkey-input)
          - [5.19.8 Line input and conversion](Line-input-and-conversion.html#Line-input-and-conversion)
          - [5.19.9 Pipes](Pipes.html#Pipes)
          - [5.19.10 Xchars and Unicode](Xchars-and-Unicode.html#Xchars-and-Unicode)
      - [5.20 OS command line arguments](OS-command-line-arguments.html#OS-command-line-arguments)
      - [5.21 Locals](Locals.html#Locals)
          - [5.21.1 Gforth locals](Gforth-locals.html#Gforth-locals)
              - [5.21.1.1 Where are locals visible by name?](Where-are-locals-visible-by-name_003f.html#Where-are-locals-visible-by-name_003f)
              - [5.21.1.2 How long do locals live?](How-long-do-locals-live_003f.html#How-long-do-locals-live_003f)
              - [5.21.1.3 Locals programming style](Locals-programming-style.html#Locals-programming-style)
              - [5.21.1.4 Locals implementation](Locals-implementation.html#Locals-implementation)
          - [5.21.2 Standard Forth locals](Standard-Forth-locals.html#Standard-Forth-locals)
      - [5.22 Structures](Structures.html#Structures)
          - [5.22.1 Why explicit structure support?](Why-explicit-structure-support_003f.html#Why-explicit-structure-support_003f)
          - [5.22.2 Structure Usage](Structure-Usage.html#Structure-Usage)
          - [5.22.3 Structure Naming Convention](Structure-Naming-Convention.html#Structure-Naming-Convention)
          - [5.22.4 Structure Implementation](Structure-Implementation.html#Structure-Implementation)
          - [5.22.5 Structure Glossary](Structure-Glossary.html#Structure-Glossary)
          - [5.22.6 Forth200x Structures](Forth200x-Structures.html#Forth200x-Structures)
      - [5.23 Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth)
          - [5.23.1 Why object-oriented programming?](Why-object_002doriented-programming_003f.html#Why-object_002doriented-programming_003f)
          - [5.23.2 Object-Oriented Terminology](Object_002dOriented-Terminology.html#Object_002dOriented-Terminology)
          - [5.23.3 The `objects.fs` model](Objects.html#Objects)
              - [5.23.3.1 Properties of the `objects.fs` model](Properties-of-the-Objects-model.html#Properties-of-the-Objects-model)
              - [5.23.3.2 Basic `objects.fs` Usage](Basic-Objects-Usage.html#Basic-Objects-Usage)
              - [5.23.3.3 The `object.fs` base class](The-Objects-base-class.html#The-Objects-base-class)
              - [5.23.3.4 Creating objects](Creating-objects.html#Creating-objects)
              - [5.23.3.5 Object-Oriented Programming Style](Object_002dOriented-Programming-Style.html#Object_002dOriented-Programming-Style)
              - [5.23.3.6 Class Binding](Class-Binding.html#Class-Binding)
              - [5.23.3.7 Method conveniences](Method-conveniences.html#Method-conveniences)
              - [5.23.3.8 Classes and Scoping](Classes-and-Scoping.html#Classes-and-Scoping)
              - [5.23.3.9 Dividing classes](Dividing-classes.html#Dividing-classes)
              - [5.23.3.10 Object Interfaces](Object-Interfaces.html#Object-Interfaces)
              - [5.23.3.11 `objects.fs` Implementation](Objects-Implementation.html#Objects-Implementation)
              - [5.23.3.12 `objects.fs` Glossary](Objects-Glossary.html#Objects-Glossary)
          - [5.23.4 The `oof.fs` model](OOF.html#OOF)
              - [5.23.4.1 Properties of the `oof.fs` model](Properties-of-the-OOF-model.html#Properties-of-the-OOF-model)
              - [5.23.4.2 Basic `oof.fs` Usage](Basic-OOF-Usage.html#Basic-OOF-Usage)
              - [5.23.4.3 The `oof.fs` base class](The-OOF-base-class.html#The-OOF-base-class)
              - [5.23.4.4 Class Declaration](Class-Declaration.html#Class-Declaration)
              - [5.23.4.5 Class Implementation](Class-Implementation.html#Class-Implementation)
          - [5.23.5 The `mini-oof.fs` model](Mini_002dOOF.html#Mini_002dOOF)
              - [5.23.5.1 Basic `mini-oof.fs` Usage](Basic-Mini_002dOOF-Usage.html#Basic-Mini_002dOOF-Usage)
              - [5.23.5.2 Mini-OOF Example](Mini_002dOOF-Example.html#Mini_002dOOF-Example)
              - [5.23.5.3 `mini-oof.fs` Implementation](Mini_002dOOF-Implementation.html#Mini_002dOOF-Implementation)
          - [5.23.6 Comparison with other object models](Comparison-with-other-object-models.html#Comparison-with-other-object-models)
      - [5.24 Programming Tools](Programming-Tools.html#Programming-Tools)
          - [5.24.1 Examining data and code](Examining.html#Examining)
          - [5.24.2 Forgetting words](Forgetting-words.html#Forgetting-words)
          - [5.24.3 Debugging](Debugging.html#Debugging)
          - [5.24.4 Assertions](Assertions.html#Assertions)
          - [5.24.5 Singlestep Debugger](Singlestep-Debugger.html#Singlestep-Debugger)
      - [5.25 Multitasker](Multitasker.html#Multitasker)
          - [5.25.1 Ptheads](Pthreads.html#Pthreads)
              - [5.25.1.1 Semaphores](Pthreads.html#Semaphores)
              - [5.25.1.2 Atomic operations](Pthreads.html#Atomic-operations)
              - [5.25.1.3 Message Queues](Pthreads.html#Message-Queues)
              - [5.25.1.4 Conditions](Pthreads.html#Conditions)
      - [5.26 C Interface](C-Interface.html#C-Interface)
          - [5.26.1 Calling C functions](Calling-C-Functions.html#Calling-C-Functions)
          - [5.26.2 Declaring C Functions](Declaring-C-Functions.html#Declaring-C-Functions)
          - [5.26.3 Calling C function pointers from Forth](Calling-C-function-pointers.html#Calling-C-function-pointers)
          - [5.26.4 Defining library interfaces](Defining-library-interfaces.html#Defining-library-interfaces)
          - [5.26.5 Declaring OS-level libraries](Declaring-OS_002dlevel-libraries.html#Declaring-OS_002dlevel-libraries)
          - [5.26.6 Callbacks](Callbacks.html#Callbacks)
          - [5.26.7 How the C interface works](C-interface-internals.html#C-interface-internals)
          - [5.26.8 Low-Level C Interface Words](Low_002dLevel-C-Interface-Words.html#Low_002dLevel-C-Interface-Words)
          - [5.26.9 Migrating from Gforth 0.7](Migrating-the-C-interface-from-earlier-Gforth.html#Migrating-the-C-interface-from-earlier-Gforth)
      - [5.27 Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)
          - [5.27.1 Definitions in assembly language](Assembler-Definitions.html#Assembler-Definitions)
          - [5.27.2 Common Assembler](Common-Assembler.html#Common-Assembler)
          - [5.27.3 Common Disassembler](Common-Disassembler.html#Common-Disassembler)
          - [5.27.4 386 Assembler](386-Assembler.html#g_t386-Assembler)
          - [5.27.5 AMD64 (x86\_64) Assembler](AMD64-Assembler.html#AMD64-Assembler)
          - [5.27.6 Alpha Assembler](Alpha-Assembler.html#Alpha-Assembler)
          - [5.27.7 MIPS assembler](MIPS-assembler.html#MIPS-assembler)
          - [5.27.8 PowerPC assembler](PowerPC-assembler.html#PowerPC-assembler)
          - [5.27.9 ARM Assembler](ARM-Assembler.html#ARM-Assembler)
          - [5.27.10 Other assemblers](Other-assemblers.html#Other-assemblers)
      - [5.28 Threading Words](Threading-Words.html#Threading-Words)
      - [5.29 Passing Commands to the Operating System](Passing-Commands-to-the-OS.html#Passing-Commands-to-the-OS)
      - [5.30 Keeping track of Time](Keeping-track-of-Time.html#Keeping-track-of-Time)
      - [5.31 Miscellaneous Words](Miscellaneous-Words.html#Miscellaneous-Words)
  - [6 Error messages](Error-messages.html#Error-messages)
  - [7 Tools](Tools.html#Tools)
      - [7.1 `ans-report.fs`: Report the words used, sorted by wordset](Standard-Report.html#Standard-Report)
          - [7.1.1 Caveats](Standard-Report.html#Caveats)
      - [7.2 Stack depth changes during interpretation](Stack-depth-changes.html#Stack-depth-changes)
  - [8 Standard conformance](Standard-conformance.html#Standard-conformance)
      - [8.1 The Core Words](The-Core-Words.html#The-Core-Words)
          - [8.1.1 Implementation Defined Options](core_002didef.html#core_002didef)
          - [8.1.2 Ambiguous conditions](core_002dambcond.html#core_002dambcond)
          - [8.1.3 Other system documentation](core_002dother.html#core_002dother)
      - [8.2 The optional Block word set](The-optional-Block-word-set.html#The-optional-Block-word-set)
          - [8.2.1 Implementation Defined Options](block_002didef.html#block_002didef)
          - [8.2.2 Ambiguous conditions](block_002dambcond.html#block_002dambcond)
          - [8.2.3 Other system documentation](block_002dother.html#block_002dother)
      - [8.3 The optional Double Number word set](The-optional-Double-Number-word-set.html#The-optional-Double-Number-word-set)
          - [8.3.1 Ambiguous conditions](double_002dambcond.html#double_002dambcond)
      - [8.4 The optional Exception word set](The-optional-Exception-word-set.html#The-optional-Exception-word-set)
          - [8.4.1 Implementation Defined Options](exception_002didef.html#exception_002didef)
      - [8.5 The optional Facility word set](The-optional-Facility-word-set.html#The-optional-Facility-word-set)
          - [8.5.1 Implementation Defined Options](facility_002didef.html#facility_002didef)
          - [8.5.2 Ambiguous conditions](facility_002dambcond.html#facility_002dambcond)
      - [8.6 The optional File-Access word set](The-optional-File_002dAccess-word-set.html#The-optional-File_002dAccess-word-set)
          - [8.6.1 Implementation Defined Options](file_002didef.html#file_002didef)
          - [8.6.2 Ambiguous conditions](file_002dambcond.html#file_002dambcond)
      - [8.7 The optional Floating-Point word set](The-optional-Floating_002dPoint-word-set.html#The-optional-Floating_002dPoint-word-set)
          - [8.7.1 Implementation Defined Options](floating_002didef.html#floating_002didef)
          - [8.7.2 Ambiguous conditions](floating_002dambcond.html#floating_002dambcond)
      - [8.8 The optional Locals word set](The-optional-Locals-word-set.html#The-optional-Locals-word-set)
          - [8.8.1 Implementation Defined Options](locals_002didef.html#locals_002didef)
          - [8.8.2 Ambiguous conditions](locals_002dambcond.html#locals_002dambcond)
      - [8.9 The optional Memory-Allocation word set](The-optional-Memory_002dAllocation-word-set.html#The-optional-Memory_002dAllocation-word-set)
          - [8.9.1 Implementation Defined Options](memory_002didef.html#memory_002didef)
      - [8.10 The optional Programming-Tools word set](The-optional-Programming_002dTools-word-set.html#The-optional-Programming_002dTools-word-set)
          - [8.10.1 Implementation Defined Options](programming_002didef.html#programming_002didef)
          - [8.10.2 Ambiguous conditions](programming_002dambcond.html#programming_002dambcond)
      - [8.11 The optional Search-Order word set](The-optional-Search_002dOrder-word-set.html#The-optional-Search_002dOrder-word-set)
          - [8.11.1 Implementation Defined Options](search_002didef.html#search_002didef)
          - [8.11.2 Ambiguous conditions](search_002dambcond.html#search_002dambcond)
  - [9 Should I use Gforth extensions?](Standard-vs-Extensions.html#Standard-vs-Extensions)
  - [10 Model](Model.html#Model)
  - [11 Integrating Gforth into C programs](Integrating-Gforth.html#Integrating-Gforth)
      - [11.1 Types](Integrating-Gforth.html#Types-1)
      - [11.2 Variables](Integrating-Gforth.html#Variables-2)
      - [11.3 Functions](Integrating-Gforth.html#Functions)
      - [11.4 Signals](Integrating-Gforth.html#Signals)
  - [12 Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth)
      - [12.1 Installing gforth.el](Installing-gforth_002eel.html#Installing-gforth_002eel)
      - [12.2 Emacs Tags](Emacs-Tags.html#Emacs-Tags)
      - [12.3 Hilighting](Hilighting.html#Hilighting)
      - [12.4 Auto-Indentation](Auto_002dIndentation.html#Auto_002dIndentation)
      - [12.5 Blocks Files](Blocks-Files.html#Blocks-Files)
  - [13 Image Files](Image-Files.html#Image-Files)
      - [13.1 Image Licensing Issues](Image-Licensing-Issues.html#Image-Licensing-Issues)
      - [13.2 Image File Background](Image-File-Background.html#Image-File-Background)
      - [13.3 Non-Relocatable Image Files](Non_002dRelocatable-Image-Files.html#Non_002dRelocatable-Image-Files)
      - [13.4 Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files)
      - [13.5 Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files)
          - [13.5.1 `gforthmi`](gforthmi.html#gforthmi)
          - [13.5.2 `cross.fs`](cross_002efs.html#cross_002efs)
      - [13.6 Stack and Dictionary Sizes](Stack-and-Dictionary-Sizes.html#Stack-and-Dictionary-Sizes)
      - [13.7 Running Image Files](Running-Image-Files.html#Running-Image-Files)
      - [13.8 Modifying the Startup Sequence](Modifying-the-Startup-Sequence.html#Modifying-the-Startup-Sequence)
  - [14 Engine](Engine.html#Engine)
      - [14.1 Portability](Portability.html#Portability)
      - [14.2 Threading](Threading.html#Threading)
          - [14.2.1 Scheduling](Scheduling.html#Scheduling)
          - [14.2.2 Direct or Indirect Threaded?](Direct-or-Indirect-Threaded_003f.html#Direct-or-Indirect-Threaded_003f)
          - [14.2.3 Dynamic Superinstructions](Dynamic-Superinstructions.html#Dynamic-Superinstructions)
          - [14.2.4 DOES\>](DOES_003e.html#DOES_003e)
      - [14.3 Primitives](Primitives.html#Primitives)
          - [14.3.1 Automatic Generation](Automatic-Generation.html#Automatic-Generation)
          - [14.3.2 TOS Optimization](TOS-Optimization.html#TOS-Optimization)
          - [14.3.3 Produced code](Produced-code.html#Produced-code)
      - [14.4 Performance](Performance.html#Performance)
  - [15 Cross Compiler](Cross-Compiler.html#Cross-Compiler)
      - [15.1 Using the Cross Compiler](Using-the-Cross-Compiler.html#Using-the-Cross-Compiler)
      - [15.2 How the Cross Compiler Works](How-the-Cross-Compiler-Works.html#How-the-Cross-Compiler-Works)
  - [Appendix A Bugs](Bugs.html#Bugs)
  - [Appendix B Authors and Ancestors of Gforth](Origin.html#Origin)
      - [B.1 Authors and Contributors](Origin.html#Authors-and-Contributors)
      - [B.2 Pedigree](Origin.html#Pedigree)
  - [Appendix C Other Forth-related information](Forth_002drelated-information.html#Forth_002drelated-information)
  - [Appendix D Licenses](Licenses.html#Licenses)
      - [D.1 GNU Free Documentation License](GNU-Free-Documentation-License.html#GNU-Free-Documentation-License)
          - [D.1.1 ADDENDUM: How to use this License for your documents](GNU-Free-Documentation-License.html#ADDENDUM_003a-How-to-use-this-License-for-your-documents)
      - [D.2 GNU GENERAL PUBLIC LICENSE](Copying.html#Copying)
  - [Word Index](Word-Index.html#Word-Index)
  - [Concept and Word Index](Concept-Index.html#Concept-Index)

</div>

<span id="Top"></span>

<div class="header">

Next: [Goals](Goals.html#Goals), Previous: [(dir)](../dir/index.html), Up: [(dir)](../dir/index.html)   \[[Contents](#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Gforth"></span>

# Gforth

This manual is for Gforth (version 0.7.9\_20180815, February 8, 2018), a fast and portable implementation of the Standard Forth language. It serves as reference manual, but it also contains an introduction to Forth and a Forth tutorial.

Copyright © 1995, 1996, 1997, 1998, 2000, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014,2015,2016,2017 Free Software Foundation, Inc.

> Permission is granted to copy, distribute and/or modify this document under the terms of the GNU Free Documentation License, Version 1.1 or any later version published by the Free Software Foundation; with no Invariant Sections, with the Front-Cover texts being “A GNU Manual,” and with the Back-Cover Texts as in (a) below. A copy of the license is included in the section entitled “GNU Free Documentation License.”
> 
> (a) The FSF’s Back-Cover Text is: “You have freedom to copy and modify this GNU Manual, like GNU software. Copies published by the Free Software Foundation raise funds for GNU development.”

• [Goals](Goals.html#Goals):

  

About the Gforth Project

• [Gforth Environment](Gforth-Environment.html#Gforth-Environment):

  

Starting (and exiting) Gforth

• [Tutorial](Tutorial.html#Tutorial):

  

Hands-on Forth Tutorial

• [Introduction](Introduction.html#Introduction):

  

An introduction to Standard Forth

• [Words](Words.html#Words):

  

Forth words available in Gforth

• [Error messages](Error-messages.html#Error-messages):

  

How to interpret them

• [Tools](Tools.html#Tools):

  

Programming tools

• [Standard conformance](Standard-conformance.html#Standard-conformance):

  

Implementation-defined options etc.

• [Standard vs Extensions](Standard-vs-Extensions.html#Standard-vs-Extensions):

  

Should I use extensions?

• [Model](Model.html#Model):

  

The abstract machine of Gforth

• [Integrating Gforth](Integrating-Gforth.html#Integrating-Gforth):

  

Forth as scripting language for applications

• [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth):

  

The Gforth Mode

• [Image Files](Image-Files.html#Image-Files):

  

`.fi` files contain compiled code

• [Engine](Engine.html#Engine):

  

The inner interpreter and the primitives

• [Cross Compiler](Cross-Compiler.html#Cross-Compiler):

  

The Cross Compiler

• [Bugs](Bugs.html#Bugs):

  

How to report them

• [Origin](Origin.html#Origin):

  

Authors and ancestors of Gforth

• [Forth-related information](Forth_002drelated-information.html#Forth_002drelated-information):

  

Books and places to look on the WWW

• [Licenses](Licenses.html#Licenses):

  

• [Word Index](Word-Index.html#Word-Index):

  

An item for each Forth word

• [Concept Index](Concept-Index.html#Concept-Index):

  

A menu covering many topics

``` menu-comment
```

``` menu-comment
 — The Detailed Node Listing —

Gforth Environment
```

• [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth):

  

Getting in

• [Leaving Gforth](Leaving-Gforth.html#Leaving-Gforth):

  

Getting out

• [Command-line editing](Command_002dline-editing.html#Command_002dline-editing):

  

• [Environment variables](Environment-variables.html#Environment-variables):

  

that affect how Gforth starts up

• [Gforth Files](Gforth-Files.html#Gforth-Files):

  

What gets installed and where

• [Gforth in pipes](Gforth-in-pipes.html#Gforth-in-pipes):

  

• [Startup speed](Startup-speed.html#Startup-speed):

  

When 14ms is not fast enough ...

``` menu-comment

Forth Tutorial
```

• [Starting Gforth Tutorial](Starting-Gforth-Tutorial.html#Starting-Gforth-Tutorial):

  

• [Syntax Tutorial](Syntax-Tutorial.html#Syntax-Tutorial):

  

• [Crash Course Tutorial](Crash-Course-Tutorial.html#Crash-Course-Tutorial):

  

• [Stack Tutorial](Stack-Tutorial.html#Stack-Tutorial):

  

• [Arithmetics Tutorial](Arithmetics-Tutorial.html#Arithmetics-Tutorial):

  

• [Stack Manipulation Tutorial](Stack-Manipulation-Tutorial.html#Stack-Manipulation-Tutorial):

  

• [Using files for Forth code Tutorial](Using-files-for-Forth-code-Tutorial.html#Using-files-for-Forth-code-Tutorial):

  

• [Comments Tutorial](Comments-Tutorial.html#Comments-Tutorial):

  

• [Colon Definitions Tutorial](Colon-Definitions-Tutorial.html#Colon-Definitions-Tutorial):

  

• [Decompilation Tutorial](Decompilation-Tutorial.html#Decompilation-Tutorial):

  

• [Stack-Effect Comments Tutorial](Stack_002dEffect-Comments-Tutorial.html#Stack_002dEffect-Comments-Tutorial):

  

• [Types Tutorial](Types-Tutorial.html#Types-Tutorial):

  

• [Factoring Tutorial](Factoring-Tutorial.html#Factoring-Tutorial):

  

• [Designing the stack effect Tutorial](Designing-the-stack-effect-Tutorial.html#Designing-the-stack-effect-Tutorial):

  

• [Local Variables Tutorial](Local-Variables-Tutorial.html#Local-Variables-Tutorial):

  

• [Conditional execution Tutorial](Conditional-execution-Tutorial.html#Conditional-execution-Tutorial):

  

• [Flags and Comparisons Tutorial](Flags-and-Comparisons-Tutorial.html#Flags-and-Comparisons-Tutorial):

  

• [General Loops Tutorial](General-Loops-Tutorial.html#General-Loops-Tutorial):

  

• [Counted loops Tutorial](Counted-loops-Tutorial.html#Counted-loops-Tutorial):

  

• [Recursion Tutorial](Recursion-Tutorial.html#Recursion-Tutorial):

  

• [Leaving definitions or loops Tutorial](Leaving-definitions-or-loops-Tutorial.html#Leaving-definitions-or-loops-Tutorial):

  

• [Return Stack Tutorial](Return-Stack-Tutorial.html#Return-Stack-Tutorial):

  

• [Memory Tutorial](Memory-Tutorial.html#Memory-Tutorial):

  

• [Characters and Strings Tutorial](Characters-and-Strings-Tutorial.html#Characters-and-Strings-Tutorial):

  

• [Alignment Tutorial](Alignment-Tutorial.html#Alignment-Tutorial):

  

• [Floating Point Tutorial](Floating-Point-Tutorial.html#Floating-Point-Tutorial):

  

• [Files Tutorial](Files-Tutorial.html#Files-Tutorial):

  

• [Interpretation and Compilation Semantics and Immediacy Tutorial](Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html#Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial):

  

• [Execution Tokens Tutorial](Execution-Tokens-Tutorial.html#Execution-Tokens-Tutorial):

  

• [Exceptions Tutorial](Exceptions-Tutorial.html#Exceptions-Tutorial):

  

• [Defining Words Tutorial](Defining-Words-Tutorial.html#Defining-Words-Tutorial):

  

• [Arrays and Records Tutorial](Arrays-and-Records-Tutorial.html#Arrays-and-Records-Tutorial):

  

• [POSTPONE Tutorial](POSTPONE-Tutorial.html#POSTPONE-Tutorial):

  

• [Literal Tutorial](Literal-Tutorial.html#Literal-Tutorial):

  

• [Advanced macros Tutorial](Advanced-macros-Tutorial.html#Advanced-macros-Tutorial):

  

• [Compilation Tokens Tutorial](Compilation-Tokens-Tutorial.html#Compilation-Tokens-Tutorial):

  

• [Wordlists and Search Order Tutorial](Wordlists-and-Search-Order-Tutorial.html#Wordlists-and-Search-Order-Tutorial):

  

``` menu-comment

An Introduction to Standard Forth
```

• [Introducing the Text Interpreter](Introducing-the-Text-Interpreter.html#Introducing-the-Text-Interpreter):

  

• [Stacks and Postfix notation](Stacks-and-Postfix-notation.html#Stacks-and-Postfix-notation):

  

• [Your first definition](Your-first-definition.html#Your-first-definition):

  

• [How does that work?](How-does-that-work_003f.html#How-does-that-work_003f):

  

• [Forth is written in Forth](Forth-is-written-in-Forth.html#Forth-is-written-in-Forth):

  

• [Review - elements of a Forth system](Review-_002d-elements-of-a-Forth-system.html#Review-_002d-elements-of-a-Forth-system):

  

• [Where to go next](Where-to-go-next.html#Where-to-go-next):

  

• [Exercises](Exercises.html#Exercises):

  

``` menu-comment

Forth Words
```

• [Notation](Notation.html#Notation):

  

• [Case insensitivity](Case-insensitivity.html#Case-insensitivity):

  

• [Comments](Comments.html#Comments):

  

• [Boolean Flags](Boolean-Flags.html#Boolean-Flags):

  

• [Arithmetic](Arithmetic.html#Arithmetic):

  

• [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation):

  

• [Memory](Memory.html#Memory):

  

• [Control Structures](Control-Structures.html#Control-Structures):

  

• [Defining Words](Defining-Words.html#Defining-Words):

  

• [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics):

  

• [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words):

  

• [Compiling words](Compiling-words.html#Compiling-words):

  

• [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter):

  

• [The Input Stream](The-Input-Stream.html#The-Input-Stream):

  

• [Word Lists](Word-Lists.html#Word-Lists):

  

• [Environmental Queries](Environmental-Queries.html#Environmental-Queries):

  

• [Files](Files.html#Files):

  

• [Blocks](Blocks.html#Blocks):

  

• [Other I/O](Other-I_002fO.html#Other-I_002fO):

  

• [OS command line arguments](OS-command-line-arguments.html#OS-command-line-arguments):

  

• [Locals](Locals.html#Locals):

  

• [Structures](Structures.html#Structures):

  

• [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth):

  

• [Programming Tools](Programming-Tools.html#Programming-Tools):

  

• [Multitasker](Multitasker.html#Multitasker):

  

• [C Interface](C-Interface.html#C-Interface):

  

• [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words):

  

• [Threading Words](Threading-Words.html#Threading-Words):

  

• [Passing Commands to the OS](Passing-Commands-to-the-OS.html#Passing-Commands-to-the-OS):

  

• [Keeping track of Time](Keeping-track-of-Time.html#Keeping-track-of-Time):

  

• [Miscellaneous Words](Miscellaneous-Words.html#Miscellaneous-Words):

  

``` menu-comment

Arithmetic
```

• [Single precision](Single-precision.html#Single-precision):

  

• [Double precision](Double-precision.html#Double-precision):

  

Double-cell integer arithmetic

• [Bitwise operations](Bitwise-operations.html#Bitwise-operations):

  

• [Numeric comparison](Numeric-comparison.html#Numeric-comparison):

  

• [Mixed precision](Mixed-precision.html#Mixed-precision):

  

Operations with single and double-cell integers

• [Floating Point](Floating-Point.html#Floating-Point):

  

``` menu-comment

Stack Manipulation
```

• [Data stack](Data-stack.html#Data-stack):

  

• [Floating point stack](Floating-point-stack.html#Floating-point-stack):

  

• [Return stack](Return-stack.html#Return-stack):

  

• [Locals stack](Locals-stack.html#Locals-stack):

  

• [Stack pointer manipulation](Stack-pointer-manipulation.html#Stack-pointer-manipulation):

  

``` menu-comment

Memory
```

• [Memory model](Memory-model.html#Memory-model):

  

• [Dictionary allocation](Dictionary-allocation.html#Dictionary-allocation):

  

• [Heap Allocation](Heap-Allocation.html#Heap-Allocation):

  

• [Memory Access](Memory-Access.html#Memory-Access):

  

• [Address arithmetic](Address-arithmetic.html#Address-arithmetic):

  

• [Memory Blocks](Memory-Blocks.html#Memory-Blocks):

  

``` menu-comment

Control Structures
```

• [Selection](Selection.html#Selection):

  

IF ... ELSE ... ENDIF

• [Simple Loops](Simple-Loops.html#Simple-Loops):

  

BEGIN ...

• [Counted Loops](Counted-Loops.html#Counted-Loops):

  

DO

• [BEGIN loops with multiple exits](BEGIN-loops-with-multiple-exits.html#BEGIN-loops-with-multiple-exits):

  

• [General control structures with CASE](General-control-structures-with-CASE.html#General-control-structures-with-CASE):

  

• [Arbitrary control structures](Arbitrary-control-structures.html#Arbitrary-control-structures):

  

• [Calls and returns](Calls-and-returns.html#Calls-and-returns):

  

• [Exception Handling](Exception-Handling.html#Exception-Handling):

  

``` menu-comment

Defining Words
```

• [CREATE](CREATE.html#CREATE):

  

• [Variables](Variables.html#Variables):

  

Variables and user variables

• [Constants](Constants.html#Constants):

  

• [Values](Values.html#Values):

  

Initialised variables

• [Colon Definitions](Colon-Definitions.html#Colon-Definitions):

  

• [Anonymous Definitions](Anonymous-Definitions.html#Anonymous-Definitions):

  

Definitions without names

• [Quotations](Quotations.html#Quotations):

  

• [Supplying names](Supplying-names.html#Supplying-names):

  

Passing definition names as strings

• [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words):

  

• [Deferred Words](Deferred-Words.html#Deferred-Words):

  

Allow forward references

• [Forward](Forward.html#Forward):

  

Auto-resolved forward references

• [Aliases](Aliases.html#Aliases):

  

``` menu-comment

User-defined Defining Words
```

• [CREATE..DOES\> applications](CREATE_002e_002eDOES_003e-applications.html#CREATE_002e_002eDOES_003e-applications):

  

• [CREATE..DOES\> details](CREATE_002e_002eDOES_003e-details.html#CREATE_002e_002eDOES_003e-details):

  

• [Advanced does\> usage example](Advanced-does_003e-usage-example.html#Advanced-does_003e-usage-example):

  

• [Const-does\>](Const_002ddoes_003e.html#Const_002ddoes_003e):

  

``` menu-comment

Interpretation and Compilation Semantics
```

• [Combined words](Combined-words.html#Combined-words):

  

``` menu-comment

Tokens for Words
```

• [Execution token](Execution-token.html#Execution-token):

  

represents execution/interpretation semantics

• [Compilation token](Compilation-token.html#Compilation-token):

  

represents compilation semantics

• [Name token](Name-token.html#Name-token):

  

represents named words

``` menu-comment

Compiling words
```

• [Literals](Literals.html#Literals):

  

Compiling data values

• [Macros](Macros.html#Macros):

  

Compiling words

``` menu-comment

The Text Interpreter
```

• [Input Sources](Input-Sources.html#Input-Sources):

  

• [Number Conversion](Number-Conversion.html#Number-Conversion):

  

• [Interpret/Compile states](Interpret_002fCompile-states.html#Interpret_002fCompile-states):

  

• [Interpreter Directives](Interpreter-Directives.html#Interpreter-Directives):

  

• [Recognizers](Recognizers.html#Recognizers):

  

``` menu-comment

Word Lists
```

• [Vocabularies](Vocabularies.html#Vocabularies):

  

• [Why use word lists?](Why-use-word-lists_003f.html#Why-use-word-lists_003f):

  

• [Word list example](Word-list-example.html#Word-list-example):

  

``` menu-comment

Files
```

• [Forth source files](Forth-source-files.html#Forth-source-files):

  

• [General files](General-files.html#General-files):

  

• [Redirection](Redirection.html#Redirection):

  

• [Directories](Directories.html#Directories):

  

• [Search Paths](Search-Paths.html#Search-Paths):

  

``` menu-comment

Search Paths
```

• [Source Search Paths](Source-Search-Paths.html#Source-Search-Paths):

  

• [General Search Paths](General-Search-Paths.html#General-Search-Paths):

  

``` menu-comment

Other I/O
```

• [Simple numeric output](Simple-numeric-output.html#Simple-numeric-output):

  

Predefined formats

• [Formatted numeric output](Formatted-numeric-output.html#Formatted-numeric-output):

  

Formatted (pictured) output

• [String Formats](String-Formats.html#String-Formats):

  

How Forth stores strings in memory

• [Displaying characters and strings](Displaying-characters-and-strings.html#Displaying-characters-and-strings):

  

Other stuff

• [String words](String-words.html#String-words):

  

Gforth’s little string library

• [Terminal output](Terminal-output.html#Terminal-output):

  

Cursor positioning etc.

• [Single-key input](Single_002dkey-input.html#Single_002dkey-input):

  

• [Line input and conversion](Line-input-and-conversion.html#Line-input-and-conversion):

  

• [Pipes](Pipes.html#Pipes):

  

How to create your own pipes

• [Xchars and Unicode](Xchars-and-Unicode.html#Xchars-and-Unicode):

  

Non-ASCII characters

``` menu-comment

Locals
```

• [Gforth locals](Gforth-locals.html#Gforth-locals):

  

• [Standard Forth locals](Standard-Forth-locals.html#Standard-Forth-locals):

  

``` menu-comment

Gforth locals
```

• [Where are locals visible by name?](Where-are-locals-visible-by-name_003f.html#Where-are-locals-visible-by-name_003f):

  

• [How long do locals live?](How-long-do-locals-live_003f.html#How-long-do-locals-live_003f):

  

• [Locals programming style](Locals-programming-style.html#Locals-programming-style):

  

• [Locals implementation](Locals-implementation.html#Locals-implementation):

  

``` menu-comment

Structures
```

• [Why explicit structure support?](Why-explicit-structure-support_003f.html#Why-explicit-structure-support_003f):

  

• [Structure Usage](Structure-Usage.html#Structure-Usage):

  

• [Structure Naming Convention](Structure-Naming-Convention.html#Structure-Naming-Convention):

  

• [Structure Implementation](Structure-Implementation.html#Structure-Implementation):

  

• [Structure Glossary](Structure-Glossary.html#Structure-Glossary):

  

• [Forth200x Structures](Forth200x-Structures.html#Forth200x-Structures):

  

``` menu-comment

Object-oriented Forth
```

• [Why object-oriented programming?](Why-object_002doriented-programming_003f.html#Why-object_002doriented-programming_003f):

  

• [Object-Oriented Terminology](Object_002dOriented-Terminology.html#Object_002dOriented-Terminology):

  

• [Objects](Objects.html#Objects):

  

• [OOF](OOF.html#OOF):

  

• [Mini-OOF](Mini_002dOOF.html#Mini_002dOOF):

  

• [Comparison with other object models](Comparison-with-other-object-models.html#Comparison-with-other-object-models):

  

``` menu-comment

The objects.fs model
```

• [Properties of the Objects model](Properties-of-the-Objects-model.html#Properties-of-the-Objects-model):

  

• [Basic Objects Usage](Basic-Objects-Usage.html#Basic-Objects-Usage):

  

• [The Objects base class](The-Objects-base-class.html#The-Objects-base-class):

  

• [Creating objects](Creating-objects.html#Creating-objects):

  

• [Object-Oriented Programming Style](Object_002dOriented-Programming-Style.html#Object_002dOriented-Programming-Style):

  

• [Class Binding](Class-Binding.html#Class-Binding):

  

• [Method conveniences](Method-conveniences.html#Method-conveniences):

  

• [Classes and Scoping](Classes-and-Scoping.html#Classes-and-Scoping):

  

• [Dividing classes](Dividing-classes.html#Dividing-classes):

  

• [Object Interfaces](Object-Interfaces.html#Object-Interfaces):

  

• [Objects Implementation](Objects-Implementation.html#Objects-Implementation):

  

• [Objects Glossary](Objects-Glossary.html#Objects-Glossary):

  

``` menu-comment

The oof.fs model
```

• [Properties of the OOF model](Properties-of-the-OOF-model.html#Properties-of-the-OOF-model):

  

• [Basic OOF Usage](Basic-OOF-Usage.html#Basic-OOF-Usage):

  

• [The OOF base class](The-OOF-base-class.html#The-OOF-base-class):

  

• [Class Declaration](Class-Declaration.html#Class-Declaration):

  

• [Class Implementation](Class-Implementation.html#Class-Implementation):

  

``` menu-comment

The mini-oof.fs model
```

• [Basic Mini-OOF Usage](Basic-Mini_002dOOF-Usage.html#Basic-Mini_002dOOF-Usage):

  

• [Mini-OOF Example](Mini_002dOOF-Example.html#Mini_002dOOF-Example):

  

• [Mini-OOF Implementation](Mini_002dOOF-Implementation.html#Mini_002dOOF-Implementation):

  

``` menu-comment

Programming Tools
```

• [Examining](Examining.html#Examining):

  

Data and Code.

• [Forgetting words](Forgetting-words.html#Forgetting-words):

  

Usually before reloading.

• [Debugging](Debugging.html#Debugging):

  

Simple and quick.

• [Assertions](Assertions.html#Assertions):

  

Making your programs self-checking.

• [Singlestep Debugger](Singlestep-Debugger.html#Singlestep-Debugger):

  

Executing your program word by word.

``` menu-comment

Multitasker
```

• [Pthreads](Pthreads.html#Pthreads):

  

Native Unix multitasker

``` menu-comment

C Interface
```

• [Calling C Functions](Calling-C-Functions.html#Calling-C-Functions):

  

• [Declaring C Functions](Declaring-C-Functions.html#Declaring-C-Functions):

  

• [Calling C function pointers](Calling-C-function-pointers.html#Calling-C-function-pointers):

  

• [Defining library interfaces](Defining-library-interfaces.html#Defining-library-interfaces):

  

• [Declaring OS-level libraries](Declaring-OS_002dlevel-libraries.html#Declaring-OS_002dlevel-libraries):

  

• [Callbacks](Callbacks.html#Callbacks):

  

• [C interface internals](C-interface-internals.html#C-interface-internals):

  

• [Low-Level C Interface Words](Low_002dLevel-C-Interface-Words.html#Low_002dLevel-C-Interface-Words):

  

• [Migrating the C interface from earlier Gforth](Migrating-the-C-interface-from-earlier-Gforth.html#Migrating-the-C-interface-from-earlier-Gforth):

  

``` menu-comment

Assembler and Code Words
```

• [Assembler Definitions](Assembler-Definitions.html#Assembler-Definitions):

  

Definitions in assembly language

• [Common Assembler](Common-Assembler.html#Common-Assembler):

  

Assembler Syntax

• [Common Disassembler](Common-Disassembler.html#Common-Disassembler):

  

• [386 Assembler](386-Assembler.html#g_t386-Assembler):

  

Deviations and special cases

• [AMD64 Assembler](AMD64-Assembler.html#AMD64-Assembler):

  

• [Alpha Assembler](Alpha-Assembler.html#Alpha-Assembler):

  

Deviations and special cases

• [MIPS assembler](MIPS-assembler.html#MIPS-assembler):

  

Deviations and special cases

• [PowerPC assembler](PowerPC-assembler.html#PowerPC-assembler):

  

Deviations and special cases

• [ARM Assembler](ARM-Assembler.html#ARM-Assembler):

  

Deviations and special cases

• [Other assemblers](Other-assemblers.html#Other-assemblers):

  

How to write them

``` menu-comment

Tools
```

• [Standard Report](Standard-Report.html#Standard-Report):

  

Report the words used, sorted by wordset.

• [Stack depth changes](Stack-depth-changes.html#Stack-depth-changes):

  

Where does this stack item come from?

``` menu-comment

Standard conformance
```

• [The Core Words](The-Core-Words.html#The-Core-Words):

  

• [The optional Block word set](The-optional-Block-word-set.html#The-optional-Block-word-set):

  

• [The optional Double Number word set](The-optional-Double-Number-word-set.html#The-optional-Double-Number-word-set):

  

• [The optional Exception word set](The-optional-Exception-word-set.html#The-optional-Exception-word-set):

  

• [The optional Facility word set](The-optional-Facility-word-set.html#The-optional-Facility-word-set):

  

• [The optional File-Access word set](The-optional-File_002dAccess-word-set.html#The-optional-File_002dAccess-word-set):

  

• [The optional Floating-Point word set](The-optional-Floating_002dPoint-word-set.html#The-optional-Floating_002dPoint-word-set):

  

• [The optional Locals word set](The-optional-Locals-word-set.html#The-optional-Locals-word-set):

  

• [The optional Memory-Allocation word set](The-optional-Memory_002dAllocation-word-set.html#The-optional-Memory_002dAllocation-word-set):

  

• [The optional Programming-Tools word set](The-optional-Programming_002dTools-word-set.html#The-optional-Programming_002dTools-word-set):

  

• [The optional Search-Order word set](The-optional-Search_002dOrder-word-set.html#The-optional-Search_002dOrder-word-set):

  

``` menu-comment

The Core Words
```

• [core-idef](core_002didef.html#core_002didef):

  

Implementation Defined Options

• [core-ambcond](core_002dambcond.html#core_002dambcond):

  

Ambiguous Conditions

• [core-other](core_002dother.html#core_002dother):

  

Other System Documentation

``` menu-comment

The optional Block word set
```

• [block-idef](block_002didef.html#block_002didef):

  

Implementation Defined Options

• [block-ambcond](block_002dambcond.html#block_002dambcond):

  

Ambiguous Conditions

• [block-other](block_002dother.html#block_002dother):

  

Other System Documentation

``` menu-comment

The optional Double Number word set
```

• [double-ambcond](double_002dambcond.html#double_002dambcond):

  

Ambiguous Conditions

``` menu-comment

The optional Exception word set
```

• [exception-idef](exception_002didef.html#exception_002didef):

  

Implementation Defined Options

``` menu-comment

The optional Facility word set
```

• [facility-idef](facility_002didef.html#facility_002didef):

  

Implementation Defined Options

• [facility-ambcond](facility_002dambcond.html#facility_002dambcond):

  

Ambiguous Conditions

``` menu-comment

The optional File-Access word set
```

• [file-idef](file_002didef.html#file_002didef):

  

Implementation Defined Options

• [file-ambcond](file_002dambcond.html#file_002dambcond):

  

Ambiguous Conditions

``` menu-comment

The optional Floating-Point word set
```

• [floating-idef](floating_002didef.html#floating_002didef):

  

Implementation Defined Options

• [floating-ambcond](floating_002dambcond.html#floating_002dambcond):

  

Ambiguous Conditions

``` menu-comment

The optional Locals word set
```

• [locals-idef](locals_002didef.html#locals_002didef):

  

Implementation Defined Options

• [locals-ambcond](locals_002dambcond.html#locals_002dambcond):

  

Ambiguous Conditions

``` menu-comment

The optional Memory-Allocation word set
```

• [memory-idef](memory_002didef.html#memory_002didef):

  

Implementation Defined Options

``` menu-comment

The optional Programming-Tools word set
```

• [programming-idef](programming_002didef.html#programming_002didef):

  

Implementation Defined Options

• [programming-ambcond](programming_002dambcond.html#programming_002dambcond):

  

Ambiguous Conditions

``` menu-comment

The optional Search-Order word set
```

• [search-idef](search_002didef.html#search_002didef):

  

Implementation Defined Options

• [search-ambcond](search_002dambcond.html#search_002dambcond):

  

Ambiguous Conditions

``` menu-comment

Emacs and Gforth
```

• [Installing gforth.el](Installing-gforth_002eel.html#Installing-gforth_002eel):

  

Making Emacs aware of Forth.

• [Emacs Tags](Emacs-Tags.html#Emacs-Tags):

  

Viewing the source of a word in Emacs.

• [Hilighting](Hilighting.html#Hilighting):

  

Making Forth code look prettier.

• [Auto-Indentation](Auto_002dIndentation.html#Auto_002dIndentation):

  

Customizing auto-indentation.

• [Blocks Files](Blocks-Files.html#Blocks-Files):

  

Reading and writing blocks files.

``` menu-comment

Image Files
```

• [Image Licensing Issues](Image-Licensing-Issues.html#Image-Licensing-Issues):

  

Distribution terms for images.

• [Image File Background](Image-File-Background.html#Image-File-Background):

  

Why have image files?

• [Non-Relocatable Image Files](Non_002dRelocatable-Image-Files.html#Non_002dRelocatable-Image-Files):

  

don’t always work.

• [Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files):

  

are better.

• [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files):

  

better yet.

• [Stack and Dictionary Sizes](Stack-and-Dictionary-Sizes.html#Stack-and-Dictionary-Sizes):

  

Setting the default sizes for an image.

• [Running Image Files](Running-Image-Files.html#Running-Image-Files):

  

`gforth -i file` or *file*.

• [Modifying the Startup Sequence](Modifying-the-Startup-Sequence.html#Modifying-the-Startup-Sequence):

  

and turnkey applications.

``` menu-comment

Fully Relocatable Image Files
```

• [gforthmi](gforthmi.html#gforthmi):

  

The normal way

• [cross.fs](cross_002efs.html#cross_002efs):

  

The hard way

``` menu-comment

Engine
```

• [Portability](Portability.html#Portability):

  

• [Threading](Threading.html#Threading):

  

• [Primitives](Primitives.html#Primitives):

  

• [Performance](Performance.html#Performance):

  

``` menu-comment

Threading
```

• [Scheduling](Scheduling.html#Scheduling):

  

• [Direct or Indirect Threaded?](Direct-or-Indirect-Threaded_003f.html#Direct-or-Indirect-Threaded_003f):

  

• [Dynamic Superinstructions](Dynamic-Superinstructions.html#Dynamic-Superinstructions):

  

• [DOES\>](DOES_003e.html#DOES_003e):

  

``` menu-comment

Primitives
```

• [Automatic Generation](Automatic-Generation.html#Automatic-Generation):

  

• [TOS Optimization](TOS-Optimization.html#TOS-Optimization):

  

• [Produced code](Produced-code.html#Produced-code):

  

``` menu-comment

Cross Compiler
```

• [Using the Cross Compiler](Using-the-Cross-Compiler.html#Using-the-Cross-Compiler):

  

• [How the Cross Compiler Works](How-the-Cross-Compiler-Works.html#How-the-Cross-Compiler-Works):

  

``` menu-comment

Licenses
```

• [GNU Free Documentation License](GNU-Free-Documentation-License.html#GNU-Free-Documentation-License):

  

License for copying this manual.

• [Copying](Copying.html#Copying):

  

GPL (for copying this software).

``` menu-comment
```

-----

<div class="header">

Next: [Goals](Goals.html#Goals), Previous: [(dir)](../dir/index.html), Up: [(dir)](../dir/index.html)   \[[Contents](#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

> Source: https://gforth.org/manual/Pthreads.html

<span id="Pthreads"></span>

<div class="header">

Previous: [Multitasker](Multitasker.html#Multitasker), Up: [Multitasker](Multitasker.html#Multitasker)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ptheads"></span>

#### 5.25.1 Ptheads

<span id="index-pthread"></span> <span id="index-newtask--stacksize-_002d_002d-task--unknown"></span> <span id="index-newtask"></span> <span id="index-newtask-1"></span>

<div class="format">

``` format
newtask       stacksize – task         unknown       “newtask”
```

</div>

creates a task, uses stacksize for stack, rstack, fpstack, locals

<span id="index-task--stacksize-_0022name_0022-_002d_002d--SwiftForth"></span> <span id="index-task"></span> <span id="index-task-1"></span>

<div class="format">

``` format
task       stacksize "name" –         SwiftForth       “task”
```

</div>

create a named task with stacksize `stacksize`

<span id="index-execute_002dtask--xt-_002d_002d-task--unknown"></span> <span id="index-execute_002dtask"></span> <span id="index-execute_002dtask-1"></span>

<div class="format">

``` format
execute-task       xt – task         unknown       “execute-task”
```

</div>

create a new task `task` and initiate it with `xt`

<span id="index-stacksize--_002d_002d-n--unknown"></span> <span id="index-stacksize"></span> <span id="index-stacksize-1"></span>

<div class="format">

``` format
stacksize       – n         unknown       “stacksize”
```

</div>

stacksize for data stack

<span id="index-newtask4--dsize-rsize-fsize-lsize-_002d_002d-task--unknown"></span> <span id="index-newtask4"></span> <span id="index-newtask4-1"></span>

<div class="format">

``` format
newtask4       dsize rsize fsize lsize – task         unknown       “newtask4”
```

</div>

creates a task, each stack individually sized

<span id="index-stacksize4--_002d_002d-dsize-fsize-rsize-lsize--unknown"></span> <span id="index-stacksize4"></span> <span id="index-stacksize4-1"></span>

<div class="format">

``` format
stacksize4       – dsize fsize rsize lsize         unknown       “stacksize4”
```

</div>

This gives you the system stack sizes

<span id="index-activate--task-_002d_002d--unknown"></span> <span id="index-activate"></span> <span id="index-activate-1"></span>

<div class="format">

``` format
activate       task –         unknown       “activate”
```

</div>

activates a task. The remaining part of the word calling `activate` will be executed in the context of the task.

<span id="index-pass--x1-_002e_002e-xn-n-task-_002d_002d--unknown"></span> <span id="index-pass"></span> <span id="index-pass-1"></span>

<div class="format">

``` format
pass       x1 .. xn n task –         unknown       “pass”
```

</div>

activates task, and passes n parameters from the data stack

<span id="index-initiate--xt-task-_002d_002d--unknown"></span> <span id="index-initiate"></span> <span id="index-initiate-1"></span>

<div class="format">

``` format
initiate       xt task –         unknown       “initiate”
```

</div>

pass an `xt` to a task (VFX compatible)

<span id="index-pause--_002d_002d--unknown"></span> <span id="index-pause"></span> <span id="index-pause-1"></span>

<div class="format">

``` format
pause       –         unknown       “pause”
```

</div>

voluntarily switch to the next waiting task (`pause` is the traditional cooperative task switcher; in the pthread multitasker, you don’t need `pause` for cooperation, but you still can use it e.g. when you have to resort to polling for some reason). This also checks for events in the queue.

<span id="index-restart--task-_002d_002d--unknown"></span> <span id="index-restart"></span> <span id="index-restart-1"></span>

<div class="format">

``` format
restart       task –         unknown       “restart”
```

</div>

Wake a task

<span id="index-halt--task-_002d_002d--unknown"></span> <span id="index-halt"></span> <span id="index-halt-1"></span>

<div class="format">

``` format
halt       task –         unknown       “halt”
```

</div>

Stop a task

<span id="index-stop--_002d_002d--unknown"></span> <span id="index-stop"></span> <span id="index-stop-1"></span>

<div class="format">

``` format
stop       –         unknown       “stop”
```

</div>

stops the current task, and waits for events (which may restart it)

<span id="index-stop_002dns--timeout-_002d_002d--unknown"></span> <span id="index-stop_002dns"></span> <span id="index-stop_002dns-1"></span>

<div class="format">

``` format
stop-ns       timeout –         unknown       “stop-ns”
```

</div>

Stop with timeout (in nanoseconds), better replacement for ms

<span id="index-UValue--_0022name_0022-_002d_002d--unknown"></span> <span id="index-UValue"></span> <span id="index-UValue-1"></span>

<div class="format">

``` format
UValue       "name" –         unknown       “UValue”
```

</div>

Define a per-thread value

<span id="index-UDefer--_0022name_0022-_002d_002d--unknown"></span> <span id="index-UDefer"></span> <span id="index-UDefer-1"></span>

<div class="format">

``` format
UDefer       "name" –         unknown       “UDefer”
```

</div>

Define a per-thread deferred word

<span id="index-user_0027--_0027user_0027-_002d_002d-n--unknown"></span> <span id="index-user_0027"></span> <span id="index-user_0027-1"></span>

<div class="format">

``` format
user'       ’user’ – n         unknown       “user”’
```

</div>

USER’ computes the task offset of a user variable

A cooperative multitasker can ensure that there is no other task interacting between two invocations of `pause`. Pthreads however are really concurrent tasks (at least on a multi-core CPU), and therefore, several techniques to avoid conflicts when accessing the same resources.

<span id="Semaphores"></span>

#### 5.25.1.1 Semaphores

Semaphores can only be aquired by one thread, all other threads have to wait until the semapohre is released.

<span id="index-semaphore--_0022name_0022-_002d_002d--gforth"></span> <span id="index-semaphore"></span> <span id="index-semaphore-1"></span>

<div class="format">

``` format
semaphore       "name" –         gforth       “semaphore”
```

</div>

create a named semaphore `"name"` \\\\ "name"-execution: `( – semaphore )`

<span id="index-lock--semaphore-_002d_002d--unknown"></span> <span id="index-lock"></span> <span id="index-lock-1"></span>

<div class="format">

``` format
lock       semaphore –         unknown       “lock”
```

</div>

lock the semaphore

<span id="index-unlock--semaphore-_002d_002d--unknown"></span> <span id="index-unlock"></span> <span id="index-unlock-1"></span>

<div class="format">

``` format
unlock       semaphore –         unknown       “unlock”
```

</div>

unlock the semaphore

The other approach to prevent concurrent access is the critical section. Here, we implement a critical section with a semaphore, so you have to specify the semaphore which is used for the critical section. Only those critical sections which use the same semaphore are mutually exclusive.

<span id="index-critical_002dsection--xt-semaphore-_002d_002d--unknown"></span> <span id="index-critical_002dsection"></span> <span id="index-critical_002dsection-1"></span>

<div class="format">

``` format
critical-section       xt semaphore –         unknown       “critical-section”
```

</div>

implement a critical section that will unlock the semaphore even in case there’s an exception within.

<span id="Atomic-operations"></span>

#### 5.25.1.2 Atomic operations

Experimental atomic operations

<span id="index-_0021_0040--u1-a_002daddr-_002d_002d-u2--gforth"></span> <span id="index-_0021_0040"></span> <span id="index-_0021_0040-1"></span>

<div class="format">

``` format
!@       u1 a-addr – u2        gforth       “store-fetch”
```

</div>

load u2\< from a\_addr\<, and store u1\< there, as atomic operation

<span id="index-_002b_0021_0040--u1-a_002daddr-_002d_002d-u2--gforth"></span> <span id="index-_002b_0021_0040"></span> <span id="index-_002b_0021_0040-1"></span>

<div class="format">

``` format
+!@       u1 a-addr – u2        gforth       “add-store-fetch”
```

</div>

load u2\< from a\_addr\<, and increment this location by u1\<, as atomic operation

<span id="index-_003f_0021_0040--unew-uold-a_002daddr-_002d_002d-uprev--gforth"></span> <span id="index-_003f_0021_0040"></span> <span id="index-_003f_0021_0040-1"></span>

<div class="format">

``` format
?!@       unew uold a-addr – uprev        gforth       “question-store-fetch”
```

</div>

load uprev\< from a\_addr\<, compare it to uold\<, and if equal, store unew\< there, as atomic operation

<span id="index-barrier--_002d_002d--gforth"></span> <span id="index-barrier"></span> <span id="index-barrier-1"></span>

<div class="format">

``` format
barrier       –        gforth       “barrier”
```

</div>

Insert a memory barrier

<span id="Message-Queues"></span>

#### 5.25.1.3 Message Queues

Gforth implements executable message queues for event driven programs: you send instructions to other tasks, enclosed in `<event` and `event>`; the entire event sequence is executed atomically. You can pass integers, floats, and strings (only the addresses, so treat the string as read-only after you have send it to another task). The messages you send are defined with `event:` `name`, which, when invoked, will add the code for its execution to the message queue, and when recieved, will execute the code following. The message queue is queried when you `stop` a task, or when you check for events with `?events`. You can define a maximum of 256 different events.

<span id="index-_003cevent--_002d_002d--unknown"></span> <span id="index-_003cevent"></span> <span id="index-_003cevent-1"></span>

<div class="format">

``` format
<event       –         unknown       “<event”
```

</div>

starts a sequence of events.

<span id="index-event_003e--task-_002d_002d--unknown"></span> <span id="index-event_003e"></span> <span id="index-event_003e-1"></span>

<div class="format">

``` format
event>       task –         unknown       “event>”
```

</div>

ends a sequence and sends it to the mentioned task

<span id="index-event_003a--_0022name_0022-_002d_002d--unknown"></span> <span id="index-event_003a"></span> <span id="index-event_003a-1"></span>

<div class="format">

``` format
event:       "name" –         unknown       “event:”
```

</div>

defines an event and the reaction to it as Forth code. If `name` is invoked, the event gets assembled to the event buffer. If the event `name` is received, the Forth definition that follows the event declaration is executed.

<span id="index-_003fevents--_002d_002d--unknown"></span> <span id="index-_003fevents"></span> <span id="index-_003fevents-1"></span>

<div class="format">

``` format
?events       –         unknown       “?events”
```

</div>

checks for events and executes them

<span id="index-event_002dloop--_002d_002d--unknown"></span> <span id="index-event_002dloop"></span> <span id="index-event_002dloop-1"></span>

<div class="format">

``` format
event-loop       –         unknown       “event-loop”
```

</div>

Tasks that are controlled by sending events to them should go into an event-loop

<span id="index-elit_002c--x-_002d_002d--unknown"></span> <span id="index-elit_002c"></span> <span id="index-elit_002c-1"></span>

<div class="format">

``` format
elit,       x –         unknown       “elit,”
```

</div>

sends a literal

<span id="index-e_0024_002c--addr-u-_002d_002d--unknown"></span> <span id="index-e_0024_002c"></span> <span id="index-e_0024_002c-1"></span>

<div class="format">

``` format
e$,       addr u –         unknown       “e$,”
```

</div>

sends a string (actually only the address and the count, because it’s shared memory

<span id="index-eflit_002c--x-_002d_002d--unknown"></span> <span id="index-eflit_002c"></span> <span id="index-eflit_002c-1"></span>

<div class="format">

``` format
eflit,       x –         unknown       “eflit,”
```

</div>

sends a float

The naming conventions for events is `:>``name`.

<span id="Conditions"></span>

#### 5.25.1.4 Conditions

The pthreads library also provides conditional variables, which allow to wait for a condition. Using the message queue is generally preferred.

<span id="index-cond--_0022name_0022-_002d_002d--gforth"></span> <span id="index-cond"></span> <span id="index-cond-1"></span>

<div class="format">

``` format
cond       "name" –         gforth       “cond”
```

</div>

create a named condition

<span id="index-pthread_005fcond_005fsignal--unknown--unknown"></span> <span id="index-pthread_005fcond_005fsignal"></span> <span id="index-pthread_005fcond_005fsignal-1"></span>

<div class="format">

``` format
pthread_cond_signal       unknown         unknown       “pthread_cond_signal”
```

</div>

<span id="index-pthread_005fcond_005fbroadcast--unknown--unknown"></span> <span id="index-pthread_005fcond_005fbroadcast"></span> <span id="index-pthread_005fcond_005fbroadcast-1"></span>

<div class="format">

``` format
pthread_cond_broadcast       unknown         unknown       “pthread_cond_broadcast”
```

</div>

<span id="index-pthread_005fcond_005fwait--unknown--unknown"></span> <span id="index-pthread_005fcond_005fwait"></span> <span id="index-pthread_005fcond_005fwait-1"></span>

<div class="format">

``` format
pthread_cond_wait       unknown         unknown       “pthread_cond_wait”
```

</div>

<span id="index-pthread_005fcond_005ftimedwait--unknown--unknown"></span> <span id="index-pthread_005fcond_005ftimedwait"></span> <span id="index-pthread_005fcond_005ftimedwait-1"></span>

<div class="format">

``` format
pthread_cond_timedwait       unknown         unknown       “pthread_cond_timedwait”
```

</div>

-----

<div class="header">

Previous: [Multitasker](Multitasker.html#Multitasker), Up: [Multitasker](Multitasker.html#Multitasker)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

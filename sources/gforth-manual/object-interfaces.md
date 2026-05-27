> Source: https://gforth.org/manual/Object-Interfaces.html

<span id="Object-Interfaces"></span>

<div class="header">

Next: [Objects Implementation](Objects-Implementation.html#Objects-Implementation), Previous: [Dividing classes](Dividing-classes.html#Dividing-classes), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Object-Interfaces-1"></span>

#### 5.23.3.10 Object Interfaces

<span id="index-object-interfaces"></span> <span id="index-interfaces-for-objects"></span>

In this model you can only call selectors defined in the class of the receiving objects or in one of its ancestors. If you call a selector with a receiving object that is not in one of these classes, the result is undefined; if you are lucky, the program crashes immediately.

<span id="index-selectors-common-to-hardly_002drelated-classes"></span>

Now consider the case when you want to have a selector (or several) available in two classes: You would have to add the selector to a common ancestor class, in the worst case to `object`. You may not want to do this, e.g., because someone else is responsible for this ancestor class.

The solution for this problem is interfaces. An interface is a collection of selectors. If a class implements an interface, the selectors become available to the class and its descendents. A class can implement an unlimited number of interfaces. For the problem discussed above, we would define an interface for the selector(s), and both classes would implement the interface.

As an example, consider an interface `storage` for writing objects to disk and getting them back, and a class `foo` that implements it. The code would look like this:

<span id="index-interface-usage"></span> <span id="index-end_002dinterface-usage"></span> <span id="index-implementation-usage"></span>

<div class="example">

``` example
interface
  selector write ( file object -- )
  selector read1 ( file object -- )
end-interface storage

bar class
  storage implementation

... overrides write
... overrides read1
...
end-class foo
```

</div>

(I would add a word `read` *( file – object )* that uses `read1` internally, but that’s beyond the point illustrated here.)

Note that you cannot use `protected` in an interface; and of course you cannot define fields.

In the Neon model, all selectors are available for all classes; therefore it does not need interfaces. The price you pay in this model is slower late binding, and therefore, added complexity to avoid late binding.

-----

<div class="header">

Next: [Objects Implementation](Objects-Implementation.html#Objects-Implementation), Previous: [Dividing classes](Dividing-classes.html#Dividing-classes), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

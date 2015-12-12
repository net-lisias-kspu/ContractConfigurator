List types are a list of another type (which can be any of the supported types).  In this document, lists types are denoted by `List<T>` where `T` is the type of the elements of the list.  If instead, the list is of a specific type, then the that type will be specified (ie. `List<string>`).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `T Random()` | Returns a random value from the list. |
| `T Random(`[`int`](Numeric-Type)` count)` | Returns a random list containing `count` elements of the original list.  If the list has fewer than `count` elements, the entire original list is returned.. |
| `T Random(`[`int`](Numeric-Type)` minCount, `[`int`](Numeric-Type)` maxCount)` | Returns a random list containing between `minCount` and `maxCount` elements of the original list.  If the list has fewer than the selectd number of elements, the entire original list is returned. |
| `T First()` | Returns the first value in the list. |
| `T Last()` | Returns the last value in the list. |
| `T ElementAt(`[`int`](Numeric-Type)` index)` | Returns the element at the given index (or null if the index is out of range). |
| [`bool`](Boolean-Type) `Contains(T value)` | Returns true if the requested value is in the list, false otherwise. |
| [`int`](Numeric-Type) `Count()` | Returns the number of items in the list. |
| [`List`](List-Type)`<T> Concat(`[`List`](List-Type)`<T> list)` | Adds the elements in `list` to the current list and returns it. |
| [`List`](List-Type)`<T> Add(T item)` | Adds the given item to the current list and returns it. |
| [`List`](List-Type)`<T> Exclude(T item)` | Removes the given item from the current list and returns it. |
| [`List`](List-Type)`<T> ExcludeAll(`[`List`](List-Type)`<T> item)` | Removes all the given item from the current list and returns it. |

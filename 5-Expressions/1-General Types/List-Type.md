List types are a list of another type (which can be any of the supported types).  In this document, lists types are denoted by `List<T>` where `T` is the type of the elements of the list.  If instead, the list is of a specific type, then the that type will be specified (ie. `List<string>`).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `T Random()` | Returns a random value from the list. |
| `T Random(int count)` | Returns a random list containing `count` elements of the original list.  If the list has fewer than `count` elements, the entire original list is returned.. |
| `T First()` | Returns the first value in the list. |
| `T Last()` | Returns the last value in the list. |
| `T ElementAt(int index)` | Returns the element at the given index (or null if the index is out of range). |
| `bool Contains(T value)` | Returns true if the requested value is in the list, false otherwise. |
| `int Count()` | Returns the number of items in the list. |
| `List<T> Concat(List<T> list)` | Adds the elements in `list` to the current list and returns it. |
| `List<T> Add(T item)` | Adds the given item to the current list and returns it. |
| `List<T> Exclude(T item)` | Removes the given item from the current list and returns it. |
| `List<T> ExcludeAll(List<T> item)` | Removes all the given item from the current list and returns it. |

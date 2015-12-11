## Table of Contents

* [[Table of Contents|Iterators#table-of-contents]]
* [[The ITERATOR node|Iterators#the-iterator-node]]

## The ITERATOR node

The ITERATOR node is used to indicate that the parent node and all its children will be repeated for each value in the list defined by the iterator.  The syntax of an iterator node is as follows:
```
PARAMETER
{
    type = ReachState

    ITERATOR
    {
        type = CelestialBody
        targetBody = AllBodies().Where(cb => cb.IsPlanet())
    }
}
```
Iterator nodes may existing within [[PARAMETER|Parameters]] nodes.

Within the ITERATOR node, the following fields can be specified:

| Field | Description |
| :--- | :--- |
| `type` | The data type for elements within the ITERATOR node.  Supports any data type listed on the [[Expressions|Expressions]] page. |
| `<identifier>` | An identifier that contains the expression.  The expression itself should be a List<> of the type specified by `type`.  It can be an identifier that is defined by the parent node (as with the example above) or any arbitrary identifier. |

Identifiers created in a ITERATOR node are accessed as if they were a part of the parent node (by referencing them as `@<identifier>` within that node).

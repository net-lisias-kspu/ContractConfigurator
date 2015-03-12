## Table of Contents

* [[Table of Contents|Function-&-Method-Reference-Guide#table-of-contents]]

## Functions & Methods

This guide lists the functions and methods that are available in the Contract Configurator expression language.  The sections are grouped by data type.

### Numeric Data Types

The numeric data types include types such as `int`, `short`, `float` and `double`.  For this section, they are together referred to as `numeric`.

#### Functions

| Function Name | Parameters | Return Type | Description |
| :--- | :--- | :--- | :--- |
| `Random` | *none* | `numeric` | Returns a random number that is greater than or equal to 0.0, but less than 1.0.  Note for integer types this will *always* return 0 - use the second interface instead. |
| `Random` | **`numeric`** `min,` **`numeric`** `max` | `numeric` | Returns a random number that is greater than or equal to *min*, but less than *max*. |
| `Min` | **`numeric`** `a,` **`numeric`** `b` | `numeric` | Returns whichever is smallest out of `a` and `b`. |
| `Max` | **`numeric`** `a,` **`numeric`** `b` | `numeric` | Returns whichever is largest out of `a` and `b`. |
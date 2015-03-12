## Table of Contents

* [[Table of Contents|Function-Reference-Guide#table-of-contents]]
* [[Functions & Methods|Function-Reference-Guide#functions-&-methods]]
  * [[Numeric Data Types|Function-Reference-Guide#numeric-data-types]]
    * [[Functions|Function-Reference-Guide#functions]]

## Functions & Methods

This guide lists the functions and methods that are available in the Contract Configurator expression language.  The sections are grouped by data type.

### Numeric Data Types

The numeric data types include types such as `int`, `short`, `float` and `double`.  For this section, they are together referred to as `numeric`.

#### Local Functions

| Function Name | Parameters | Return Type | Description |
| :--- | :--- | :--- | :--- |
| `Random` | *none* | `numeric` | Returns a random number that is greater than or equal to 0.0, but less than 1.0.  Note for integer types this will *always* return 0 - use the second interface instead. |
| `Random` | **`numeric`** `min,` **`numeric`** `max` | `numeric` | Returns a random number that is greater than or equal to *min*, but less than *max*. |
| `Min` | **`numeric`** `a,` **`numeric`** `b` | `numeric` | Returns whichever is smallest out of `a` and `b`. |
| `Max` | **`numeric`** `a,` **`numeric`** `b` | `numeric` | Returns whichever is largest out of `a` and `b`. |

[ [[Top|Function-Reference-Guide]] ]

### Enumeration Types

Enumerations include all types that have a list of values (typically, the full list of values is documented in the appropriate Contract Configurator parameter.  The type will vary based on the type of enumeration, but is generically referred to as `enum` in this section.

#### Local Functions

| Function Name | Parameters | Return Type | Description |
| :--- | :--- | :--- | :--- |
| `Random` | *none* | `enum` | Returns a random value from the enumeration. |
| `AllEnumValues` | *none* | `List<enum>` | Returns all the valid values for the enumeration. |

[ [[Top|Function-Reference-Guide]] ]
## Table of Contents

* [[Table of Contents|Function-Reference-Guide#table-of-contents]]
* [[Functions & Methods|Function-Reference-Guide#functions-&-methods]]
  * [[Numeric Data Types|Function-Reference-Guide#numeric-data-types]]
    * [[Local Functions|Function-Reference-Guide#local-functions]]
  * [[Enumeration Types|Function-Reference-Guide#enumeration-types]]
    * [[Local Functions|Function-Reference-Guide#local-functions]]

## Functions & Methods

This guide lists the functions and methods that are available in the Contract Configurator expression language.  The sections are grouped by data type.

### Numeric Data Types

The numeric data types include types such as `int`, `short`, `float` and `double`.  For this section, they are together referred to as `numeric`.

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Numeric Data Types|Function-Reference-Guide#numeric-data-types]] ]</sub>

#### Local Functions

| Function Name | Parameters | Return Type | Description |
| :--- | :--- | :--- | :--- |
| `Random` | *none* | `numeric` | Returns a random number that is greater than or equal to 0.0, but less than 1.0.  Note for integer types this will *always* return 0 - use the second interface instead. |
| `Random` | **`numeric`** `min,` **`numeric`** `max` | `numeric` | Returns a random number that is greater than or equal to *min*, but less than *max*. |
| `Min` | **`numeric`** `a,` **`numeric`** `b` | `numeric` | Returns whichever is smallest out of `a` and `b`. |
| `Max` | **`numeric`** `a,` **`numeric`** `b` | `numeric` | Returns whichever is largest out of `a` and `b`. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Enumeration Types|Function-Reference-Guide#enumeration-types]] / [[Local Functions|Function-Reference-Guide#local-functions]] ]</sub>

#### Methods

| Method Name | Parameters | Return Type | Description |
| :--- | :--- | :--- | :--- |
| `Print` | *none* | `string` | Returns the pretty-printed string value of the number, using the following rules:<ol><li>Integer numbers less than 10 are printed in english ("one", "two", etc.)</li><li>Numbers greater than 1000 use the number grouping separator (not sure if KSP respects locale in this).  For example "1,000", "1,000,000".</li><li>Real numbers are printed with two decimal places.</li><li>Real numbers less than 1.0 are printed with five decimal places.</li></ol> |

### Enumeration Types

Enumerations include all types that have a list of values (typically, the full list of values is documented in the appropriate Contract Configurator parameter.  The type will vary based on the type of enumeration, but is generically referred to as `enum` in this section.

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Enumeration Types|Function-Reference-Guide#enumeration-types]] ]</sub>

#### Local Functions

| Function Name | Parameters | Return Type | Description |
| :--- | :--- | :--- | :--- |
| `Random` | *none* | `enum` | Returns a random value from the enumeration. |
| `AllEnumValues` | *none* | `List<enum>` | Returns all the valid values for the enumeration. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Enumeration Types|Function-Reference-Guide#enumeration-types]] / [[Local Functions|Function-Reference-Guide#local-functions]] ]</sub>

### List Types
List types are a list of another type (which can be any of the supported types).  In this document, lists types are denoted by `List<T>` where `T` is the type of the elements of the list.  If instead, the list is of a specific type, then the that type will be specified (ie. `List<string>`).

#### Methods

| Method Name | Parameters | Return Type | Description |
| :--- | :--- | :--- | :--- |
| `Random` | *none* | `T` | Returns a random value from the list. |
| `First` | *none* | `T` | Returns the first value in the list. |
| `Last` | *none* | `T` | Returns the last value in the list. |
| `Contains` | `T value` | `boolean` | Returns true if the requested value is in the list, false otherwise. |
| `Count` | *none* | `int` | Returns the number of items in the list. |

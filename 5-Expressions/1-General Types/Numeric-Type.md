The numeric data types include types such as `int`, `short`, `float` and `double`.  For this section, they are together referred to as `numeric`.

**Local Functions**

| Function Signature | Description |
| :--- | :--- |
| [`numeric`](Numeric-Type) `Random()` | Returns a random number that is greater than or equal to 0.0, but less than 1.0.  Note for integer types this will *always* return 0 - use the second interface instead. |
| [`numeric`](Numeric-Type) `Random(`[`numeric`](Numeric-Type)` min, `[`numeric`](Numeric-Type)` max)` | Returns a random number that is greater than or equal to *min*, but less than *max*. |
| [`numeric`](Numeric-Type) `Min(`[`numeric`](Numeric-Type)` a, `[`numeric`](Numeric-Type)` b)` | Returns whichever is smallest out of `a` and `b`. |
| [`numeric`](Numeric-Type) `Max(`[`numeric`](Numeric-Type)` a, `[`numeric`](Numeric-Type)` b)` | Returns whichever is largest out of `a` and `b`. |
| [`numeric`](Numeric-Type) `Pow(`[`numeric`](Numeric-Type)` a, `[`numeric`](Numeric-Type)` b)` | Returns a to the power of b. |
| [`numeric`](Numeric-Type) `Log(`[`numeric`](Numeric-Type)` a, `[`numeric`](Numeric-Type)` b)` | Returns the logarithm of a in base b. |
| [`numeric`](Numeric-Type) `Round(`[`numeric`](Numeric-Type)` value)` | Rounds the number to the nearest full integer value (uses bankers rounding). |
| [`numeric`](Numeric-Type) `Round(`[`numeric`](Numeric-Type)` value, `[`numeric`](Numeric-Type)` precision)` | Rounds the number to the nearest multiple of `precision`.  For example `Round(113.0, 5.0)` would return `115.0`. |

**Global Functions**

| Function Signature | Description |
| :--- | :--- |
| [`int`](Numeric-Type)` int(`[`numeric`](Numeric-Type)` val)` | Converts the value to an integer representation. |
| [`long`](Numeric-Type)` long(`[`numeric`](Numeric-Type)` val)` | Converts the value to a long integer representation. |
| [`uint`](Numeric-Type)` uint(`[`numeric`](Numeric-Type)` val)` | Converts the value to an unsigned integer representation. |
| [`ulong`](Numeric-Type)` ulong(`[`numeric`](Numeric-Type)` val)` | Converts the value to an unsigned long integer representation. |
| [`float`](Numeric-Type)` float(`[`numeric`](Numeric-Type)` val)` | Converts the value to a float (single precision) representation. |
| [`double`](Numeric-Type)` double(`[`numeric`](Numeric-Type)` val)` | Converts the value to a float (double precision) representation. |

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`string`](String-Type) `Print()` | Returns the pretty-printed string value of the number, using the following rules:<ol><li>Integer numbers less than 10 are printed in english ("one", "two", etc.)</li><li>Numbers greater than 1000 use the number grouping separator (not sure if KSP respects locale in this).  For example "1,000", "1,000,000".</li><li>Real numbers are printed with two decimal places.</li><li>Real numbers less than 1.0 are printed with five decimal places.</li></ol> |

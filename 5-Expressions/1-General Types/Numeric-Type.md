The numeric data types include types such as `int`, `short`, `float` and `double`.  For this section, they are together referred to as `numeric`.

**Local Functions**

| Function Signature | Description |
| :--- | :--- |
| `numeric Random()` | Returns a random number that is greater than or equal to 0.0, but less than 1.0.  Note for integer types this will *always* return 0 - use the second interface instead. |
| `numeric Random(numeric min, numeric max)` | Returns a random number that is greater than or equal to *min*, but less than *max*. |
| `numeric Min(numeric a, numeric b)` | Returns whichever is smallest out of `a` and `b`. |
| `numeric Max(numeric a, numeric b)` | Returns whichever is largest out of `a` and `b`. |

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `string`&nbsp;`Print()` | Returns the pretty-printed string value of the number, using the following rules:<ol><li>Integer numbers less than 10 are printed in english ("one", "two", etc.)</li><li>Numbers greater than 1000 use the number grouping separator (not sure if KSP respects locale in this).  For example "1,000", "1,000,000".</li><li>Real numbers are printed with two decimal places.</li><li>Real numbers less than 1.0 are printed with five decimal places.</li></ol> |

The duration data type is used anywhere that a contract parameter requests a duration of time.  Can be specified with units of y, d, h, m, s.

Example: `2d 4h` is 2 days and 4 hours.

Durations can also be used in arithmatic (30d - 2h 30m) or comparisons (30d > 2h 30m).

**Local Functions**

| Function Signature | Description |
| :--- | :--- |
| [`Duration`](Duration-Type) `Random(`[`Duration`](Duration-Type)` min, `[`Duration`](Duration-Type)` max)` | Returns a random `Duration` that is greater than or equal to *min*, but less than *max*. |
| [`Duration`](Duration) `Round(`[`Duration`](Duration)` value, `[`Duration`](Duration)` precision)` | Rounds the number to the nearest multiple of `precision`.  For example `Round(4d 2h, 1d)` would return `4d`. |
| [`double`](Numeric-Type)` ToDouble()` | Returns the Duration as a double value in seconds. |

**Global Functions**

| Function Signature | Description |
| :--- | :--- |
| [`Duration`](Duration-Type)` Duration(val)` | Casts the given value to a Duration. |

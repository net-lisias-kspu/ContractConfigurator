The duration data type is used anywhere that a contract parameter requests a duration of time.  Can be specified with units of y, d, h, m, s.

Example: `2d 4h` is 2 days and 4 hours.

**Local Functions**

| Function Signature | Description |
| :--- | :--- |
| [`Duration`](Duration-Type) `Random(`[`Duration`](Duration-Type)` min, `[`Duration`](Duration-Type)` max)` | Returns a random `Duration` that is greater than or equal to *min*, but less than *max*. |
| [`Duration`](Duration-Type) `Round(`[`Duration`](Duration-Type)` value, `[`Duration`](Duration-Type)` precision)` | Rounds the duration to the nearest multiple of `precision`.  For example `Round(5d 2m, 1d)` would return `5d`. |

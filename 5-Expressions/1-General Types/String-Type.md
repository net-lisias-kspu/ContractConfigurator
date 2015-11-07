The string data type represents all textual strings.  This data type is parsed differently than other data types - the expression syntax is limited to a "search and replace" of special identifiers and function calls.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`string`](String-Type) `ToUpper()` | Uppercase version of the string. |
| [`string`](String-Type) `ToLower()` | Lowercase version of the string. |
| [`string`](String-Type) `FirstCap()` | Returns the string with the first letter capitalized. |
| [`string`](String-Type) `FirstWord()` | Returns the first word in a space-seperate list (ie. pull Jebediah out of Jebediah Kerman). |
| [`bool`](Boolean-Type)` Contains(`[`string`](String-Type)` value)` | Checks if the string contains the given sub-string. |
| [`bool`](Boolean-Type)` StartsWith(`[`string`](String-Type)` value)` | Checks if the string starts with the given sub-string. |
| [`bool`](Boolean-Type)` EndsWith(`[`string`](String-Type)` value)` | Checks if the string ends with the given sub-string. |

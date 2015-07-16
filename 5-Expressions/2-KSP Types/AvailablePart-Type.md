The AvailablePart class represents the definition of a part.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`PartCategories`](Enumeration-Type) `Category()` | Returns the category of part (corresponds to the listings in the VAB). |
| [`float`](Numeric-Type) `Cost()` | The cost of the part in funds. |
| [`string`](String-Type) `Description()` | The textual description of the part. |
| [`string`](String-Type) `Manufacturer()` | The manufacturer of the part. |
| [`float`](Numeric-Type) `Size()` | The size of the part. |
| [`string`](String-Type) `TechRequired()` | The name of the technology that is required to unlock this part. |
| [`bool`](Boolean-Type) `IsUnlocked()` | Whether the player has unlocked this part or not. |
| [`int`](Numeric-Type) `CrewCapacity()` | The crew capacity of the given part. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<AvailablePart> AllParts()` | Returns a list of all parts. |
| [`AvailablePart`](AvailablePart-Type) `AvailablePart(`[`string`](String-Type)` identifier)` | Returns the AvailablePart for the given identifier. |

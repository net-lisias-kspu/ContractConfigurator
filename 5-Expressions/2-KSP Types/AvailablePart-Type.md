The AvailablePart class represents the definition of a part.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `PartCategories Category()` | Returns the category of part (corresponds to the listings in the VAB). |
| `float Cost()` | The cost of the part in funds. |
| `string Description()` | The textual description of the part. |
| `string Manufacturer()` | The manufacturer of the part. |
| `float Size()` | The size of the part. |
| `string TechRequired()` | The name of the technology that is required to unlock this part. |
| `bool IsUnlocked()` | Whether the player has unlocked this part or not. |
| `int CrewCapacity()` | The crew capacity of the given part. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<AvailablePart> AllParts()` | Returns a list of all parts. |
| `AvailablePart AvailablePart(string identifier)` | Returns the AvailablePart for the given identifier. |

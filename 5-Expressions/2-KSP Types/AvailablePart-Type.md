The AvailablePart class represents the definition of a part.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`PartCategories`](Enumeration-Type) `Category()` | Returns the category of part (corresponds to the listings in the VAB). |
| [`float`](Numeric-Type) `Cost()` | The cost of the part in funds. |
| [`string`](String-Type) `Description()` | The textual description of the part. |
| [`string`](String-Type) `Manufacturer()` | The manufacturer of the part. |
| [`float`](Numeric-Type) `Size()` | The size of the part. |
| [`Tech`](Tech-Type)` TechRequired()` | The technology that is required to unlock this part. |
| [`bool`](Boolean-Type) `IsUnlocked()` | Whether the player has unlocked this part or not. |
| [`int`](Numeric-Type) `UnlockCost()` | The cost to unlock a part when part entry purchase is required. |
| [`int`](Numeric-Type) `CrewCapacity()` | The crew capacity of the given part. |
| [`float`](Numeric-Type) `EngineVacuumThrust()` | The thrust in vacuum for this part.  Returns 0.0 if the part isn't an engine. |
| [`float`](Numeric-Type) `EngineAtmosphereThrust()` | The thrust in one atmosphere of pressure for this part.  Returns 0.0 if the part isn't an engine. |
| [`float`](Numeric-Type) `EngineVacuumISP()` | The ISP in vacuum for this part.  Returns 0.0 if the part isn't an engine. |
| [`float`](Numeric-Type) `EngineAtmosphereISP()` | The ISP in one atmosphere of pressure for this part.  Returns 0.0 if the part isn't an engine. |
| [`List`](List-Type)`<`[`Resource`](Resource-Type)`> Resources()` | Returns a list of all resources that this part can hold. |
| [`double`](Numeric-Type) `ResourceCapacity(`[`Resource`](Resource-Type)`)` | The part's capacity for holding the given type of resource. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| [`List`](List-Type)`<`[`AvailablePart`](AvailablePart-Type)`> AllParts()` | Returns a list of all parts. |
| [`AvailablePart`](AvailablePart-Type) `AvailablePart(`[`string`](String-Type)` identifier)` | Returns the AvailablePart for the given identifier. |

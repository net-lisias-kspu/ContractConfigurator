The Tech class represents a technology that can be researched.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`float`](Numeric-Type) `Cost()` | The cost to unlock the tech in science. |
| [`bool`](Boolean-Type) `IsUnlocked()` | Whether the player has unlocked this tech or not. |
| [`string`](String-Type) `Description()` | The textual description of the tech. |
| [`int`](Numeric-Type) `Level()` | What level in the tree this tech is at (the start node is considered level 0). |
| [`List`](List-Type)`<`[`Tech`](Tech-Type)`> Children()` | A list of all children of this node in the tech tree. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| [`List`](List-Type)`<`[`Tech`](Tech-Type)`> AllTech()` | Returns a list of all technology nodes. |
| [`List`](List-Type)`<`[`Tech`](Tech-Type)`> UnlockedTech()` | Returns a list of all technology nodes the player has unlocked. |
| [`Tech`](Tech-Type) `Tech(`[`string`](String-Type)` identifier)` | Returns the Tech for the given identifier. |
| [`int`](Numeric-Type) `MaxTechLevelUnlocked()` | Returns the maximum tech level the player has unlocked. |

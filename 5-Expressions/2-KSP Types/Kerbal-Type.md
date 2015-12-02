The Kerbal class represents a Kerbal in the game.  This includes ship crew, EVA Kerbals, Kerbals at the astronaut complex and applicants.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`float`](Numeric-Type) `Experience()` | Gets the Kerbal's experience. |
| [`int`](Numeric-Type) `ExperienceLevel()` | Gets the Kerbal's experience level. |
| `ExperienceTrait ExperienceTrait()` | Gets the Kerbal's experience trait.  Valid values in stock KSP are Pilot, Engineer and Scientist. |
| [`RosterStatus`](Enumeration-Type) `RosterStatus()` | Get's the Kerbal's status on the roster.  Valid values are Available, Assigned, Dead, and Missing. |
| [`KerbalType`](Enumeration-Type) `Type()` | Gets the Kerbal's type.  Valid values are Crew, Applicant, Unowned, Tourist. |
| [`Gender`](Enumeration-Type) `Gender()` | Gets the Kerbal's gender.  Valid values are Male and Female. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| [`List`](List-Type)`<`[`Kerbal`](Kerbal-Type)`> AllKerbals()` | Returns a list of all Kerbals in the game. |
| [`Kerbal`](Kerbal-Type) `Kerbal(`[`string`](String-Type)` identifier)` | Returns the Kerbal for the given identifier. |
| [`Kerbal`](Kerbal-Type) `NewKerbal()` | Generates a new random Kerbal. |
| [`Kerbal`](Kerbal-Type) `NewKerbal(`[`Gender`](Enumeration-Type)` gender)` | Generates a new random Kerbal with the given gender. |
| [`Kerbal`](Kerbal-Type) `NewKerbal(`[`Gender`](Enumeration-Type)` gender, `[`string`](String-Type)` name)` | Generates a new random Kerbal with the given name and gender. |
| [`Kerbal`](Kerbal-Type) `NewKerbalWithTrait(`[`string`](String-Type)` trait)` | Generates a new random Kerbal with the given trait. |
| [`Kerbal`](Kerbal-Type) `NewKerbal(`[`Gender`](Enumeration-Type)` gender, `[`string`](String-Type)` name, `[`string`](String-Type)` trait)` | Generates a new Kerbal with the given name, gender and trait. |

The Kerbal class (ProtoCrewMember in actuality) represents a Kerbal in the game.  This includes ship crew, Kerbals at the astronaut complex and applicants.

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
| [`List`](List-Type)`<Kerbal> AllKerbals()` | Returns a list of all Kerbals in the game. |
| [`Kerbal`](Kerbal-Type) `Kerbal(`[`string`](String-Type)` identifier)` | Returns the Kerbal for the given identifier. |

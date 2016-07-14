The ScienceExperiment class represents a science experiment that can be run.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`string`](String-Type) `Name()` | Returns the name of the experiment. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| [`List`](List-Type)`<`[`ScienceExperiment`](ScienceExperiment-Type)`> AllExperiments()` | Returns a list of all science experiments. |
| [`List`](List-Type)`<`[`ScienceExperiment`](ScienceExperiment-Type)`> AvailableExperiments(`[`CelestialBody`](CelestialBody-Type)` body)` | Returns a list of all science experiments that are available (that have the appropriate tech unlocked) and can be run on the given celestial body. |

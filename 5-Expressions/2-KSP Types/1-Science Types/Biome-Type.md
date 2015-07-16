The Biome class represents a biome for a planet or moon.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`string`](../String-Type) `Name()` | The short name of the biome (eg. Highlands). |
| [`string`](../String-Type) `FullName()` | The full name of the biome (eg. Kerbin's Highlands). |
| [`CelestialBody`](../CelestialBody-Type) `CelestialBody()` | The CelestialBody that the given biome belongs to. |
| [`bool`](../Boolean-Type) `IsKSC()` | Whether the given biome is one of the special KSC biomes. |
| [`float`](../Numeric-Type) `RemainingScience()` | The remaining science in the biome across all subjects. |
| `List<Location> DifficultLocations()` | A list containing a number of "difficult" locations for the biome (eg. splashed down in the mountains). |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<Biome> KSCBiomes()` | A list containing all the KSC biomes. |
| `List<Biome> MainKSCBiomes()` | A list containing all the "main" KSC biomes. |

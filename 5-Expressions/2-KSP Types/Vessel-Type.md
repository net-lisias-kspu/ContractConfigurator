The Vessel class represents anything that is made up of parts (which includes ships, satellites, stations, bases, EVA kerbals, and asteroids).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`bool`](Boolean-Type) `IsLanded()` | Indicates whether the given vessel is landed. |
| [`bool`](Boolean-Type) `IsSplashed()` | Indicates whether the given vessel is splashed down. |
| [`bool`](Boolean-Type) `IsOrbiting()` | Indicates whether the given vessel is in orbit. |
| [`List`](List-Type)`<`[`Kerbal`](Kerbal-Type)`> Crew()` | Gets all the Kerbals that are on board the vessel. |
| [`List`](List-Type)`<`[`AvailablePart`](AvailablePart-Type)`> Parts()` | Gets a listing of all the parts that make up the vessel. |
| [`CelestialBody`](CelestialBody-Type) `CelestialBody()` | Gets the body whose sphere of influence the vessel is in. |
| [`VesselType`](Enumeration-Type) `VesselType()` | Gets the type of vessel (Base, Station, Ship, Lander, Rover, Probe, Debris, SpaceObject , Unknown). |
| [`double`](Numeric-Type) `Altitude()` | Gets the altitude of the vessel. |
| [`int`](Numeric-Type) `CrewCount()` | Gets the number of crew on board the vessel. |
| [`int`](Numeric-Type) `CrewCapacity()` | Gets the number of spots for crew on the vessel. |
| [`int`](Numeric-Type) `EmptyCrewSpace()` | Gets the number of spots for crew on the vessel that are currently empty. |
| [`int`](Numeric-Type) `FreeDockingPorts()` | Gets the number of docking ports that are currently free. |
| [`double`](Numeric-Type) `ResourceQuantity(`[`Resource`](Resource-Type)` r)` | Gets the amount of the given resource that is on board. |
| [`double`](Numeric-Type) `ResourceCapacity(`[`Resource`](Resource-Type)` r)` | Gets the capacity for the given resource that is on board. |
| [`float`](Numeric-Type) `Mass()` | The mass of the vessel in tons. |
| [`double`](Numeric-Type) `OrbitApoapsis()` | The apoapsis of the vessel's orbit. |
| [`double`](Numeric-Type) `OrbitPeriapsis()` | The periapsis of the vessel's orbit. |
| [`double`](Numeric-Type) `OrbitInclination()` | The inclination of the vessel's orbit. |
| [`double`](Numeric-Type) `OrbitEccentricity()` | The eccentricity of the vessel's orbit. |
| [`double`](Numeric-Type) `XDimension()` | The approximate size (estimated) of the vessel along the x dimension. |
| [`double`](Numeric-Type) `YDimension()` | The approximate size (estimated) of the vessel along the y dimension. |
| [`double`](Numeric-Type) `ZDimension()` | The approximate size (estimated) of the vessel along the z dimension. |
| [`double`](Numeric-Type) `SmallestDimension()` | The approximate size (estimated) of the vessel along its smallest dimension. |
| [`double`](Numeric-Type) `LargestDimension()` | The approximate size (estimated) of the vessel along its largest dimension. |
| [`Location`](Location-Type) `Location()` | The location of the vessel as an object. |
| [`List`](List-Type)`<`[`Kerbal`](Kerbal-Type)`> Crew()` | Gets a list containing all the crew on board the vessel. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| [`List`](List-Type)`<`[`Vessel`](Vessel-Type)`> AllVessels()` | Returns a list of all vessels. |
| [`Vessel`](Vessel-Type) `Vessel(`[`string`](String-Type)` identifier)` | Returns the vessel for the given identifier. |

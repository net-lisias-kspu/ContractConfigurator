The Vessel class represents anything that is made up of parts (which includes ships, satellites, stations, bases, EVA kerbals, and asteroids).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `bool IsLanded()` | Indicates whether the given vessel is landed. |
| `bool IsSplashed()` | Indicates whether the given vessel is splashed down. |
| `bool IsOrbiting()` | Indicates whether the given vessel is in orbit. |
| `List<Kerbal> Crew()` | Gets all the Kerbals that are on board the vessel. |
| `List<AvailablePart> Parts()` | Gets a listing of all the parts that make up the vessel. |
| `CelestialBody CelestialBody()` | Gets the body whose sphere of influence the vessel is in. |
| `VesselType VesselType()` | Gets the type of vessel (Base, Station, Ship, Lander, Rover, Probe, Debris, SpaceObject , Unknown). |
| `double Altitude()` | Gets the altitude of the vessel. |
| `int CrewCount()` | Gets the number of crew on board the vessel. |
| `int CrewCapacity()` | Gets the number of spots for crew on the vessel. |
| `int EmptyCrewSpace()` | Gets the number of spots for crew on the vessel that are currently empty. |
| `int FreeDockingPorts()` | Gets the number of docking ports that are currently free. |
| `double ResourceQuantity(Resource r)` | Gets the amount of the given resource that is on board. |
| `double ResourceCapacity(Resource r)` | Gets the capacity for the given resource that is on board. |
| `float Mass()` | The mass of the vessel in tons. |
| `double XDimension()` | The approximate size (estimated) of the vessel along the x dimension. |
| `double YDimension()` | The approximate size (estimated) of the vessel along the y dimension. |
| `double ZDimension()` | The approximate size (estimated) of the vessel along the z dimension. |
| `double SmallestDimension()` | The approximate size (estimated) of the vessel along its smallest dimension. |
| `double LargestDimension()` | The approximate size (estimated) of the vessel along its largest dimension. |
| `Location Location()` | The location of the vessel as an object. |
| `List<Kerbal> Crew()` | Gets a list containing all the crew on board the vessel. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<Vessel> AllVessels()` | Returns a list of all vessels. |
| `Vessel Vessel(string identifier)` | Returns the vessel for the given identifier. |

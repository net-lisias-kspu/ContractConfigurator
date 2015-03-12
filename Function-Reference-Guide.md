## Table of Contents

* [[Table of Contents|Function-Reference-Guide#table-of-contents]]
* [[Functions & Methods|Function-Reference-Guide#functions-&-methods]]
  * [[Numeric Data Types|Function-Reference-Guide#numeric-data-types]]
    * [[Local Functions|Function-Reference-Guide#local-functions]]
  * [[Enumeration Types|Function-Reference-Guide#enumeration-types]]
    * [[Local Functions|Function-Reference-Guide#local-functions]]

## Functions & Methods

This guide lists the functions and methods that are available in the Contract Configurator expression language.  The sections are grouped by data type.

### Numeric Data Types

The numeric data types include types such as `int`, `short`, `float` and `double`.  For this section, they are together referred to as `numeric`.

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Numeric Data Types|Function-Reference-Guide#numeric-data-types]] ]</sub>

#### Local Functions

| Function Signature | Description |
| :--- | :--- |
| `numeric Random()` | *none* | `numeric` | Returns a random number that is greater than or equal to 0.0, but less than 1.0.  Note for integer types this will *always* return 0 - use the second interface instead. |
| `numeric Random(numeric min, numeric max)` | Returns a random number that is greater than or equal to *min*, but less than *max*. |
| `numeric Min(numeric a, numeric b)` | Returns whichever is smallest out of `a` and `b`. |
| `numeric Max(numeric a, numeric b)` | Returns whichever is largest out of `a` and `b`. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Enumeration Types|Function-Reference-Guide#enumeration-types]] / [[Local Functions|Function-Reference-Guide#local-functions]] ]</sub>

#### Methods

| Method Signature | Description |
| :--- | :--- |
| `string`&nbsp;`Print()` | Returns the pretty-printed string value of the number, using the following rules:<ol><li>Integer numbers less than 10 are printed in english ("one", "two", etc.)</li><li>Numbers greater than 1000 use the number grouping separator (not sure if KSP respects locale in this).  For example "1,000", "1,000,000".</li><li>Real numbers are printed with two decimal places.</li><li>Real numbers less than 1.0 are printed with five decimal places.</li></ol> |

### Enumeration Types

Enumerations include all types that have a list of values (typically, the full list of values is documented in the appropriate Contract Configurator parameter.  The type will vary based on the type of enumeration, but is generically referred to as `enum` in this section.

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Enumeration Types|Function-Reference-Guide#enumeration-types]] ]</sub>

#### Local Functions

| Function Signature | Description |
| :--- | :--- |
| `enum Random()` | Returns a random value from the enumeration. |
| `List<enum> AllEnumValues()` | Returns all the valid values for the enumeration. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Enumeration Types|Function-Reference-Guide#enumeration-types]] / [[Local Functions|Function-Reference-Guide#local-functions]] ]</sub>

### List Types
List types are a list of another type (which can be any of the supported types).  In this document, lists types are denoted by `List<T>` where `T` is the type of the elements of the list.  If instead, the list is of a specific type, then the that type will be specified (ie. `List<string>`).

#### Methods

| Method Signature | Description |
| :--- | :--- |
| `T Random()` | Returns a random value from the list. |
| `T First()` | Returns the first value in the list. |
| `T Last()` | Returns the last value in the list. |
| `boolean Contains(T value)` | Returns true if the requested value is in the list, false otherwise. |
| `int Count()` | Returns the number of items in the list. |

### CelestialBody

The CelestialBody class represents a planet, moon or start in KSP.

#### Methods

| Method Signature | Description |
| :--- | :--- |
| `bool HasAtmosphere()` | Indicates whether the given body has an atmosphere. |
| `bool HasOcean()` | Indicates whether the given body has an ocean. |
| `bool HasSurface()` | Indicates whether the given body has a surface (ie. isn't a gas giant). |
| `bool IsHomeWorld()` | Indicates whether the given body is the home world (ie. Kerbin). |
| `bool IsPlanet()` | Indicates whether the given body is a planet (not a moon or star). |
| `bool IsMoon()` | Indicates whether the given body is a moon. |
| `CelestialBody Parent()` | Returns the body's parent body (ex. The Mun's parent body is Kerbin). |
| `List<CelestialBody> Children()` | Returns the body's child bodies (ex. Kerbin's child bodies are the Mun and Minmus). |
| `double Radius()` | Returns the planet's radius (in meters). |
| `float AtmosphereAltitude()` | Returns the altitude of planet's atmosphere (in meters). |
| `double SphereOfInfluence()` | Returns the radius of the planet's sphere of influence (in meters). |

#### Global Functions

| Function Signature| Description |
| :--- | :--- |
| `CelestialBody HomeWorld()` | Returns the home world (ie. Kerbin). |
| `List<CelestialBody> AllBodies()` | Returns a list of all celestial bodies. |

### Vessel

The Vessel class represents anything that is made up of parts (which includes ships, satellites, stations, bases, and asteroids).

#### Methods

| Method Signature | Description |
| :--- | :--- |
| `bool IsLanded()` | Indicates whether the given vessel is landed. |
| `bool IsSplashed()` | Indicates whether the given vessel is splashed down. |
| `bool IsOrbiting()` | Indicates whether the given vessel is in orbit. |
| `CelestialBody CelestialBody()` | Gets the body whose sphere of influence the vessel is in. |
| `VesselType VesselType()` | Gets the type of vessel (Base, Station, Ship, Lander, Rover, Probe, Debris, SpaceObject , Unknown). |
| `double Altitude()` | Gets the altitude of the vessel. |
| `int CrewCount()` | Gets the number of crew on board the vessel. |
| `int CrewCapacity()` | Gets the number of spots for crew on the vessel. |
| `int EmptyCrewSpace()` | Gets the number of spots for crew on the vessel that are currently empty. |
| `int FreeDockingPorts()` | Gets the number of docking ports that are currently free. |

#### Global Functions

| Function Signature| Description |
| :--- | :--- |
| `List<Vessel> AllVessels()` | Returns a list of all vessels. |

### Miscellaneous 

#### Global Functions

| Function Signature| Description |
| :--- | :--- |
| `ContractPrestige Prestige()` | Gets the prestige value of the current contract (Trivial, Significant, Exceptional). |
## Table of Contents

* [[Table of Contents|Function-Reference-Guide#table-of-contents]]
* [[Functions & Methods|Function-Reference-Guide#functions-&-methods]]
  * [[General Data Types|Function-Reference-Guide#general-data-types]]
    * [[Numeric Data Types|Function-Reference-Guide#numeric-data-types]]
    * [[Enumeration Types|Function-Reference-Guide#enumeration-types]]
    * [[List Types|Function-Reference-Guide#list-types]]
  * [[KSP Classes|Function-Reference-Guide#ksp-classes]]
    * [[AvailablePart|Function-Reference-Guide#availablepart]]
    * [[CelestialBody|Function-Reference-Guide#celestialbody]]
    * [[Kerbal|Function-Reference-Guide#kerbal]]
    * [[Location|Function-Reference-Guide#location]]
    * [[Resource|Function-Reference-Guide#resource]]
    * [[Vessel|Function-Reference-Guide#vessel]]
    * [[Waypoint Class|Function-Reference-Guide#waypoint-class]]
    * [[Science|Function-Reference-Guide#science]]
      * [[Biome|Function-Reference-Guide#biome]]
      * [[ScienceSubject|Function-Reference-Guide#sciencesubject]]
  * [[Contract Configurator Objects|Function-Reference-Guide#contract-configurator-objects]]
    * [[WaypointGenerator Behaviour|Function-Reference-Guide#waypointgenerator-behaviour]]
    * [[SpawnKerbal Behaviour|Function-Reference-Guide#spawnkerbal-behaviour]]
  * [[Other|Function-Reference-Guide#other]]
    * [[Duration|Function-Reference-Guide#duration]]
    * [[Miscellaneous |Function-Reference-Guide#miscellaneous-]]

## Functions & Methods

This guide lists the functions and methods that are available in the Contract Configurator expression language.  The sections are grouped by data type.

### General Data Types

This section contains the basic data types.

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[General Data Types|Function-Reference-Guide#general-data-types]] ]</sub>

#### Numeric Data Types

The numeric data types include types such as `int`, `short`, `float` and `double`.  For this section, they are together referred to as `numeric`.

**Local Functions**

| Function Signature | Description |
| :--- | :--- |
| `numeric Random()` | Returns a random number that is greater than or equal to 0.0, but less than 1.0.  Note for integer types this will *always* return 0 - use the second interface instead. |
| `numeric Random(numeric min, numeric max)` | Returns a random number that is greater than or equal to *min*, but less than *max*. |
| `numeric Min(numeric a, numeric b)` | Returns whichever is smallest out of `a` and `b`. |
| `numeric Max(numeric a, numeric b)` | Returns whichever is largest out of `a` and `b`. |

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `string`&nbsp;`Print()` | Returns the pretty-printed string value of the number, using the following rules:<ol><li>Integer numbers less than 10 are printed in english ("one", "two", etc.)</li><li>Numbers greater than 1000 use the number grouping separator (not sure if KSP respects locale in this).  For example "1,000", "1,000,000".</li><li>Real numbers are printed with two decimal places.</li><li>Real numbers less than 1.0 are printed with five decimal places.</li></ol> |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[General Data Types|Function-Reference-Guide#general-data-types]] / [[Numeric Data Types|Function-Reference-Guide#numeric-data-types]] ]</sub>

#### Enumeration Types

Enumerations include all types that have a list of values (typically, the full list of values is documented in the appropriate Contract Configurator parameter.  The type will vary based on the type of enumeration, but is generically referred to as `enum` in this section.

**Local Functions**

| Function Signature | Description |
| :--- | :--- |
| `enum Random()` | Returns a random value from the enumeration. |
| `List<enum> AllEnumValues()` | Returns all the valid values for the enumeration. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[General Data Types|Function-Reference-Guide#general-data-types]] / [[Enumeration Types|Function-Reference-Guide#enumeration-types]] ]</sub>

#### List Types
List types are a list of another type (which can be any of the supported types).  In this document, lists types are denoted by `List<T>` where `T` is the type of the elements of the list.  If instead, the list is of a specific type, then the that type will be specified (ie. `List<string>`).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `T Random()` | Returns a random value from the list. |
| `T Random(int count)` | Returns a random list containing `count` elements of the original list.  If the list has fewer than `count` elements, the entire original list is returned.. |
| `T First()` | Returns the first value in the list. |
| `T Last()` | Returns the last value in the list. |
| `T ElementAt(int index)` | Returns the element at the given index (or null if the index is out of range). |
| `bool Contains(T value)` | Returns true if the requested value is in the list, false otherwise. |
| `int Count()` | Returns the number of items in the list. |
| `List<T> Concat(List<T> list)` | Adds the elements in `list` to the current list and returns it. |
| `List<T> Add(T item)` | Adds the given item to the current list and returns it. |
| `List<T> Exclude(T item)` | Removes the given item from the current list and returns it. |
| `List<T> Exclude(List<T> item)` | Removes all the given item from the current list and returns it. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[General Data Types|Function-Reference-Guide#general-data-types]] / [[List Types|Function-Reference-Guide#list-types]] ]</sub>

### KSP Classes

This section contains the supported classes of common objects in KSP.

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] ]</sub>

#### AvailablePart

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

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<AvailablePart> AllParts()` | Returns a list of all parts. |
| `AvailablePart AvailablePart(string identifier)` | Returns the AvailablePart for the given identifier. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[AvailablePart|Function-Reference-Guide#availablepart]] ]</sub>

#### CelestialBody

The CelestialBody class represents a planet, moon or star in KSP.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `bool HasAtmosphere()` | Indicates whether the given body has an atmosphere. |
| `bool HasOcean()` | Indicates whether the given body has an ocean. |
| `bool HasSurface()` | Indicates whether the given body has a surface (ie. isn't a gas giant). |
| `bool IsHomeWorld()` | Indicates whether the given body is the home world (ie. Kerbin). |
| `bool IsPlanet()` | Indicates whether the given body is a planet (not a moon or star). |
| `bool IsMoon()` | Indicates whether the given body is a moon. |
| `bool IsOrbitalSurveyComplete()` | Indicates whether an orbital survey has been complete for the body. |
| `CelestialBody Parent()` | Returns the body's parent body (ex. The Mun's parent body is Kerbin). |
| `List<CelestialBody> Children()` | Returns the body's child bodies (ex. Kerbin's child bodies are the Mun and Minmus). |
| `double Radius()` | Returns the planet's radius (in meters). |
| `float AtmosphereAltitude()` | Returns the altitude of planet's atmosphere (in meters). |
| `double SphereOfInfluence()` | Returns the radius of the planet's sphere of influence (in meters). |
| `List<Biome> Biomes()` | Returns all the biomes for the given celestial body. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `CelestialBody HomeWorld()` | Returns the home world (ie. Kerbin). |
| `List<CelestialBody> AllBodies()` | Returns a list of all celestial bodies. |
| `List<CelestialBody> OrbitedBodies()` | Returns a list of all celestial bodies that the player has orbited. |
| `List<CelestialBody> LandedBodies()` | Returns a list of all celestial bodies that the player has landed on. |
| `CelestialBody CelestialBody(string identifier)` | Returns the CelestialBody for the given identifier. |
| `double UniversalTime()` | Gets the universal time (number of game seconds since the game started). |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[CelestialBody|Function-Reference-Guide#celestialbody]] ]</sub>

#### Kerbal

The Kerbal class (ProtoCrewMember in actualituality) represents a Kerbal in the game.  This includes ship crew, Kerbals at the astronaut complex and applicants.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `float Experience()` | Gets the Kerbal's experience. |
| `int ExperienceLevel()` | Gets the Kerbal's experience level. |
| `ExperienceTrait ExperienceTrait()` | Gets the Kerbal's experience trait.  Valid values in stock KSP are Pilot, Engineer and Scientist. |
| `RosterStatus RosterStatus()` | Get's the Kerbal's status on the roster.  Valid values are Available, Assigned, Dead, and Missing. |
| `KerbalType Type()` | Gets the Kerbal's type.  Valid values are Crew, Applicant, Unowned, Tourist. |
| `Gender Gender()` | Gets the Kerbal's gender.  Valid values are Male and Female. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<Kerbal> AllKerbals()` | Returns a list of all Kerbals in the game. |
| `Kerbal Kerbal(string identifier)` | Returns the Kerbal for the given identifier. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[Kerbal|Function-Reference-Guide#kerbal]] ]</sub>

#### Location

The Location class represents a set of latitude/longitude coordinates.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `double Latitude()` | The latitude of the given location. |
| `double Longitude()` | The longitude of the given location. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[Location|Function-Reference-Guide#location]] ]</sub>

#### Resource

The Resource class represents a resource in KSP (eg. ElectricCharge, LiquidFuel, etc.).

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| Resource Resource(string identifier)` | Returns the resource for the given identifier. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[Resource|Function-Reference-Guide#resource]] ]</sub>

#### Vessel

The Vessel class represents anything that is made up of parts (which includes ships, satellites, stations, bases, and asteroids).

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
| `List<Kerbal> Crew()` | Gets a list containing all the crew on board the vessel. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<Vessel> AllVessels()` | Returns a list of all vessels. |
| `Vessel Vessel(string identifier)` | Returns the vessel for the given identifier. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[Vessel|Function-Reference-Guide#vessel]] ]</sub>

#### Waypoint Class

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `string Name()` | The name of the waypoint. |
| `double Longitude()` | The longitude of the waypoint. |
| `double Latitude()` | The latitude of the waypoint. |
| `double Altitude()` | The altitude of the waypoint. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[Waypoint Class|Function-Reference-Guide#waypoint-class]] ]</sub>

#### Science

The following category contains science related classes.

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[Science|Function-Reference-Guide#science]] ]</sub>

##### Biome

The Biome class represents a biome for a planet or moon.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `CelestialBody CelestialBody()` | The CelestialBody that the given biome belongs to. |
| `bool IsKSC()` | Whether the given biome is one of the special KSC biomes. |
| `List<Location> DifficultLocations()` | A list containing a number of "difficult" locations for the biome (eg. splashed down in the mountains). |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[Science|Function-Reference-Guide#science]] / [[Biome|Function-Reference-Guide#biome]] ]</sub>

##### ScienceSubject

The ScienceSubject class represents a subject for which science can be performed.  It is made up of a celestial body, an experiment, a situation (landed/splashed/flying low/etc.) and possibly a biome (if applicable for the given combination).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `ScienceExperiment Experiment()` | The experiment the given subject is applicable to. |
| `ExperimentSituations Situation()` | The situation the given subject is applicable to. |
| `CelestialBody CelestialBody()` | The celestial body the given subject is applicable to. |
| `Biome Biome()` | The biome the given subject is applicable to (null if not applicable). |
| `float CollectedScience()` | The amount of science collected for the given subject. |
| `float RemainingScience()` | The amount of science remaining for the given subject. |
| `float TotalScience()` | The total amount of science available for the given subject. |
| `float NextScienceReportValue()` | The value of the next science report for the given subject. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<ScienceSubject> AllScienceSubjects()` | The list of all currently available science subjects (except "difficult" ones). |
| `List<ScienceSubject> AllScienceSubjectsByBody(List<CelestialBody>)` | Same as AllScienceSubjects, but filtered by CelestialBody. |
| `List<ScienceSubject> AllScienceSubjectsByExperiment(List<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by ScienceExperiment. |
| `List<ScienceSubject> AllScienceSubjectsByBiome(List<Biome>)` | Same as AllScienceSubjects, but filtered by Biome. |
| `List<ScienceSubject> AllScienceSubjectsByBodyExperiment(List<CelestialBody>, List<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by CelestialBody and ScienceExperiment. |
| `List<ScienceSubject> AllScienceSubjectsByBiomeExperiment(List<Biome>, List<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by Biome and ScienceExperiment. |
| `List<ScienceSubject> DifficultScienceSubjects()` | The list of all "difficult" subjects (such as "splashed down in the mountains"). |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[KSP Classes|Function-Reference-Guide#ksp-classes]] / [[Science|Function-Reference-Guide#science]] / [[ScienceSubject|Function-Reference-Guide#sciencesubject]] ]</sub>

### Contract Configurator Objects

This section contains the supported classes for Contract Congfigurator objects (Parameters, Requirements and Behaviours).  To access these via an expression, simply reference them using an `@` special identifier.  Example:
```
CONTRACT_TYPE
{
    name = MyContractType
    
    title = @/MySpawnKerbal.Kerbals().ElementAt(2) is the name of the Kerbal.

    BEHAVIOUR
    {
        name = MySpawnKerbal
        type = SpawnKerbal

        KERBAL
        {
            ...
        }
    }
}
```

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Contract Configurator Objects|Function-Reference-Guide#contract-configurator-objects]] ]</sub>

#### WaypointGenerator Behaviour

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `List<Waypoint> Waypoints()` | Retrieves a list of all Waypoints generated by this behaviour. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Contract Configurator Objects|Function-Reference-Guide#contract-configurator-objects]] / [[WaypointGenerator Behaviour|Function-Reference-Guide#waypointgenerator-behaviour]] ]</sub>

#### SpawnKerbal Behaviour

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `List<Kerbal> Kerbals()` | Retrieves a list of all Kerbals spawned by this behaviour. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Contract Configurator Objects|Function-Reference-Guide#contract-configurator-objects]] / [[SpawnKerbal Behaviour|Function-Reference-Guide#spawnkerbal-behaviour]] ]</sub>

### Other

All other classes fall into this section.

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Other|Function-Reference-Guide#other]] ]</sub>

#### Duration
The duration data type is used anywhere that a contract parameter requests a duration in the form "1d 2h 5s".

**Local Functions**

| Function Signature | Description |
| :--- | :--- |
| `Duration Random(Duration min, Duration max)` | Returns a random `Duration` that is greater than or equal to *min*, but less than *max*. |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Other|Function-Reference-Guide#other]] / [[Duration|Function-Reference-Guide#duration]] ]</sub>

#### Miscellaneous 

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `ContractPrestige Prestige()` | Gets the prestige value of the current contract (Trivial, Significant, Exceptional). |

<sub>[ [[Top|Function-Reference-Guide]] ] [ [[Other|Function-Reference-Guide#other]] / [[Miscellaneous |Function-Reference-Guide#miscellaneous-]] ]</sub>


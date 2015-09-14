The CelestialBody class represents a planet, moon or star in KSP.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`string`](String-Type) `Name()` | The name of the celestial body. |
| [`bool`](Boolean-Type) `HasAtmosphere()` | Indicates whether the given body has an atmosphere. |
| [`bool`](Boolean-Type) `HasOcean()` | Indicates whether the given body has an ocean. |
| [`bool`](Boolean-Type) `HasSurface()` | Indicates whether the given body has a surface (ie. isn't a gas giant). |
| [`bool`](Boolean-Type) `IsHomeWorld()` | Indicates whether the given body is the home world (ie. Kerbin). |
| [`bool`](Boolean-Type) `IsSun()` | Indicates whether the given body is the Sun. |
| [`bool`](Boolean-Type) `IsPlanet()` | Indicates whether the given body is a planet (not a moon or star). |
| [`bool`](Boolean-Type) `IsMoon()` | Indicates whether the given body is a moon. |
| [`bool`](Boolean-Type) `HaveReached()` | Whether the player has reached the given celestial body. |
| [`bool`](Boolean-Type) `HaveOrbited()` | Whether the player has orbited the given celestial body. |
| [`bool`](Boolean-Type) `HaveLandedOn()` | Whether the player has landed on the given celestial body. |
| [`bool`](Boolean-Type) `HaveEscaped()` | Whether the player has escaped from the given celestial body. |
| [`bool`](Boolean-Type) `HaveReturnedFrom()` | Whether the player has returned from the given celestial body. |
| [`bool`](Boolean-Type) `IsOrbitalSurveyComplete()` | Indicates whether an orbital survey has been complete for the body. |
| [`CelestialBody`](CelestialBody-Type) `Parent()` | Returns the body's parent body (ex. The Mun's parent body is Kerbin). |
| [`List`](List-Type)`<`[`CelestialBody`](CelestialBody-Type)`> Children()` | Returns the body's child bodies (ex. Kerbin's child bodies are the Mun and Minmus). |
| [`double`](Numeric-Type) `Mass()` | Returns the planet's mass (in kg). |
| [`double`](Numeric-Type) `RotationalPeriod()` | Returns the planet's rotational period (in s). |
| [`double`](Numeric-Type) `Radius()` | Returns the planet's radius (in meters). |
| [`double`](Numeric-Type) `SemiMajorAxis()` | Returns the semi-major axis of the planet (in meters). |
| [`float`](Numeric-Type) `FlyingAltitudeThreshold()` | The altitude threshold between 'flying low' and 'flying high'. |
| [`float`](Numeric-Type) `AtmosphereAltitude()` | Returns the altitude of planet's atmosphere (in meters). |
| [`float`](Numeric-Type) `SpaceAltitudeThreshold()` | The altitude threshold between 'low in space' and 'high in space'. |
| [`double`](Numeric-Type) `SphereOfInfluence()` | Returns the radius of the planet's sphere of influence (in meters). |
| [`List`](List-Type)`<`[`Biome`](Biome-Type)`> Biomes()` | Returns all the biomes for the given celestial body. |
| [`double`](Numeric-Type) `RemoteTechCoverage()` | (RemoteTech only) Indicates the commsat coverage percentage of the given body. |
| [`double`](Numeric-Type) `Multiplier()` | Gets the science/contract reward multiplier for this body. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| [`CelestialBody`](CelestialBody-Type) `HomeWorld()` | Returns the home world (ie. Kerbin). |
| [`List`](List-Type)`<`[`CelestialBody`](CelestialBody-Type)`> AllBodies()` | Returns a list of all celestial bodies. |
| [`List`](List-Type)`<`[`CelestialBody`](CelestialBody-Type)`> ReachedBodies()` | Returns a list of all celestial bodies that the player has reached. |
| [`List`](List-Type)`<`[`CelestialBody`](CelestialBody-Type)`> OrbitedBodies()` | Returns a list of all celestial bodies that the player has orbited. |
| [`List`](List-Type)`<`[`CelestialBody`](CelestialBody-Type)`> LandedBodies()` | Returns a list of all celestial bodies that the player has landed on. |
| [`List`](List-Type)`<`[`CelestialBody`](CelestialBody-Type)`> EscapedBodies()` | Returns a list of all celestial bodies that the player has escaped from. |
| [`List`](List-Type)`<`[`CelestialBody`](CelestialBody-Type)`> ReturnedFromBodies()` | Returns a list of all celestial bodies that the player has returned from. |
| [`CelestialBody`](CelestialBody-Type) `CelestialBody(`[`string`](String-Type)` identifier)` | Returns the CelestialBody for the given identifier. |
| [`double`](Numeric-Type) `UniversalTime()` | Gets the universal time (number of game seconds since the game started). |

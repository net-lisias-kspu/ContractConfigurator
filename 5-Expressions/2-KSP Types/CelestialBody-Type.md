The CelestialBody class represents a planet, moon or star in KSP.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `string Name()` | The name of the celestial body. |
| `bool HasAtmosphere()` | Indicates whether the given body has an atmosphere. |
| `bool HasOcean()` | Indicates whether the given body has an ocean. |
| `bool HasSurface()` | Indicates whether the given body has a surface (ie. isn't a gas giant). |
| `bool IsHomeWorld()` | Indicates whether the given body is the home world (ie. Kerbin). |
| `bool IsPlanet()` | Indicates whether the given body is a planet (not a moon or star). |
| `bool IsMoon()` | Indicates whether the given body is a moon. |
| `bool IsOrbitalSurveyComplete()` | Indicates whether an orbital survey has been complete for the body. |
| `CelestialBody Parent()` | Returns the body's parent body (ex. The Mun's parent body is Kerbin). |
| `List<CelestialBody> Children()` | Returns the body's child bodies (ex. Kerbin's child bodies are the Mun and Minmus). |
| `double Mass()` | Returns the planet's mass (in kg). |
| `double RotationalPeriod()` | Returns the planet's rotational period (in s). |
| `double Radius()` | Returns the planet's radius (in meters). |
| `double SemiMajorAxis()` | Returns the semi-major axis of the planet (in meters). |
| `float AtmosphereAltitude()` | Returns the altitude of planet's atmosphere (in meters). |
| `double SphereOfInfluence()` | Returns the radius of the planet's sphere of influence (in meters). |
| `List<Biome> Biomes()` | Returns all the biomes for the given celestial body. |
| `double RemoteTechCoverage()` | (RemoteTech only) Indicates the commsat coverage percentage of the given body. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `CelestialBody HomeWorld()` | Returns the home world (ie. Kerbin). |
| `List<CelestialBody> AllBodies()` | Returns a list of all celestial bodies. |
| `List<CelestialBody> OrbitedBodies()` | Returns a list of all celestial bodies that the player has orbited. |
| `List<CelestialBody> LandedBodies()` | Returns a list of all celestial bodies that the player has landed on. |
| `CelestialBody CelestialBody(string identifier)` | Returns the CelestialBody for the given identifier. |
| `double UniversalTime()` | Gets the universal time (number of game seconds since the game started). |

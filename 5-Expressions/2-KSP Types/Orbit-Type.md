The Orbit class represents an orbit in KSP.  Currently there are no methods that work on orbits (although that will likely change in future).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`double`](Numeric-Type) `Apoapsis()` | The apoapsis of the orbit. |
| [`double`](Numeric-Type) `Periapsis()` | The periapsis of the orbit. |
| [`double`](Numeric-Type) `Inclination()` | The inclination of the orbit. |
| [`double`](Numeric-Type) `Eccentricity()` | The eccentricity of the orbit. |
| [`double`](Numeric-Type) `LAN()` | The longitude of ascending node of the orbit. |
| [`double`](Numeric-Type) `Period()` | The period of the orbit (in seconds). |
| [`Orbit`](Orbit-Type) `Orbit(`[`string`](String-Type)` identifier)` | Casts the given identifier to an Orbit (if possible). |

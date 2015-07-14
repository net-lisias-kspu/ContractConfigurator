Checks that the vessel is in a specific state.  Use any combination of the attributes below.

<pre>
PARAMETER
{
    name = ReachState
    type = ReachState

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Duna

    // Minimum altitude above the reference altitude (sea-level or the lowest
    // point on the body).
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minAltitude = 20000

    // Maximum altitude above the reference altitude (sea-level or the lowest
    // point on the body).
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   float.MaxValue
    //
    maxAltitude = 50000

    // Minimum altitude above terrain.
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minTerrainAltitude = 500

    // Maximum altitude above terrain.
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   0.0
    //
    maxTerrainAltitude = 1000

    // Minimum speed (surface speed if flying/landed, orbital speed ortherwise).
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minSpeed = 1000

    // Maximum speed (surface speed if flying/landed, orbital speed ortherwise).
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   float.MaxValue
    //
    maxSpeed = 5000

    // The name of the biome to reach.
    //
    // Type:      <a href="Biome-Type">Biome</a>
    // Required:  No
    //
    biome = Shores

    // The situation to check for.
    //
    // Type:      <a href="Enumeration-Type">Vessel.Situations</a>
    // Required:  No
    // Values:
    //     ESCAPING
    //     FLYING
    //     LANDED
    //     ORBITING
    //     PRELAUNCH
    //     SPLASHED
    //     SUB_ORBITAL
    //
    situation = FLYING

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Vessel State: &lt;state details&gt;
    //
    //title =
}
</pre>

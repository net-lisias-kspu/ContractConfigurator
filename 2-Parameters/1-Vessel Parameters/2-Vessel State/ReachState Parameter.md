Checks that the vessel is in a specific state.  Use any combination of the attributes below.

<pre>
PARAMETER
{
    name = ReachState
    type = ReachState

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      CelestialBody
    // Required:  No (defaulted)
    //
    targetBody = Duna

    // Minimum altitude above the reference altitude (sea-level or the lowest
    // point on the body).
    //
    // Type:      float
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minAltitude = 20000

    // Maximum altitude above the reference altitude (sea-level or the lowest
    // point on the body).
    //
    // Type:      float
    // Required:  No (defaulted)
    // Default:   float.MaxValue
    //
    maxAltitude = 50000

    // Minimum altitude above terrain.
    //
    // Type:      float
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minTerrainAltitude = 500

    // Maximum altitude above terrain.
    //
    // Type:      float
    // Required:  No (defaulted)
    // Default:   0.0
    //
    maxTerrainAltitude = 1000

    // Minimum speed (surface speed if flying/landed, orbital speed ortherwise).
    //
    // Type:      float
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minSpeed = 1000

    // Maximum speed (surface speed if flying/landed, orbital speed ortherwise).
    //
    // Type:      float
    // Required:  No (defaulted)
    // Default:   float.MaxValue
    //
    maxSpeed = 5000

    // The name of the biome to reach.
    //
    // Type:      Biome
    // Required:  No
    //
    biome = Shores

    // The situation to check for.
    //
    // Type:      Vessel.Situations
    // Required:  No
    // Values:
    //     ESCAPING
    //     FLYING
    //     LANDED
    //     ORBITING
    //     PRELAUNCH
    //     SPLASHED
    //     SUB_ORBITAL
    situation = FLYING

    // Text to use for the parameter
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Vessel State: <state details>
    //
    //title =
}
</pre>

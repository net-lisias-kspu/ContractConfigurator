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
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minSpeed = 1000

    // Maximum speed (surface speed if flying/landed, orbital speed ortherwise).
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxSpeed = 5000

    // Minimum rate of climb (rate at which an aircraft is increasing its altitude).
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   double.MinValue
    //
    minRateOfClimb = 1000

    // Maximum rate of climb (rate at which an aircraft is increasing its altitude).
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxRateOfClimb = 5000

    // The name of the biome to reach.
    //
    // Type:      <a href="Biome-Type">Biome</a>
    // Required:  No
    //
    biome = Shores

    // The situation to check for.  If multiple situations are provided, will
    // check for any of the situations listed.
    //
    // Type:      <a href="Enumeration-Type">Vessel.Situations</a>
    // Required:  No (multiples allowed)
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

    // Minimum acceleration (in gees) that the vessel must be at.
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minAcceleration = 0.0

    // Maximum acceleration (in gees) that the vessel must be at.
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   float.MaxValue
    //
    maxAcceleration = 5.0

    // Set to true to fail the contract if the vessel doesn't meet the
    // conditions.  Take care that the contract doesn't get written in such a
    // way that the player's other vessels cause the contract to faile (for
    // example, if you say "don't go above 10,000m, but the player has another
    // vessel in orbit, make sure that there are other parameters that prevent
    // the orbiting vessel from triggering the failure - the completeInSequence
    // is useful for this).
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   false
    //
    failWhenUnmet = false

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Vessel State: &lt;state details&gt;
    //
    //title =
}
</pre>

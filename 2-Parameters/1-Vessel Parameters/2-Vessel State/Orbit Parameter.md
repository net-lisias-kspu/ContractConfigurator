Orbital parameter to specify required orbital details.
<pre>
PARAMETER
{
    name = Orbit
    type = Orbit

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      CelestialBody
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // Situation to check for.
    //
    // Type:      Vessel.Situations
    // Required:  No (defaulted)
    // Values:
    //     ESCAPING
    //     ORBITAL (default)
    //     SUB_ORBITAL
    //
    situation = SUB_ORBITAL

    // Minimum orbit altitude in meters.  The vessel's apoapsis and
    // periapsis must both be above this number.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minAltitude = 100000

    // Maximum orbit altitude in meters.  The vessel's apoapsis and
    // periapsis must both be below this number.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxAltitude = 250000

    // Minimum apoapsis in meters.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minApA = 100000

    // Maximum apoapsis in meters.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxApA = 250000

    // Minimum periapsis in meters.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minPeA = 100000

    // Maximum periapsis in meters.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxPeA = 250000

    // Minimum eccentricity.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minEccentricity = 0.0

    // Maximum eccentricity.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxEccentricity = 0.1

    // Minimum inclination in degrees
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minInclination = 0

    // Maximum inclination in degrees
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   180.0
    //
    maxInclination = 1

    // Duration of the minimum orbital period.  Specify values in years (y),
    // days (d), hours (h), minutes (m), seconds (s) or any combination of
    // those.
    //
    // Type:      <a href="Duration-Type">Duration</a>
    // Required:  No (defaulted)
    // Default:   0s
    //
    minPeriod = 6h 0m 50s

    // Duration of the maximum orbital period.  Specify values in years (y),
    // days (d), hours (h), minutes (m), seconds (s) or any combination of
    // those.
    //
    // Type:      <a href="Duration-Type">Duration</a>
    // Required:  No (defaulted)
    // Default:   infinite
    //
    maxPeriod = 6h 0m 52s

    // Text to use for the parameter
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Orbit: <orbit details>
    //
    //title =
}
</pre>
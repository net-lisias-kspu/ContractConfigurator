Orbital parameter to specify required orbital details.

    PARAMETER
    {
        name = Orbit
        type = Orbit

        // Target body, defaulted from the contract if not supplied.
        targetBody = Kerbin

        // Situation to check for.  Valid list is a subset of Vessel.Situations:
        //     ESCAPING
        //     ORBITAL (default)
        //     SUB_ORBITAL
        situation = SUB_ORBITAL

        // Minimum orbit altitude in meters.  The vessel's apoapsis and
        // periapsis must both be above this number.
        // Default = 0
        minAltitude = 100000

        // Maximum orbit altitude in meters.  The vessel's apoapsis and
        // periapsis must both be below this number.
        // Default = double.MaxValue
        maxAltitude = 250000

        // Minimum apoapsis in meters.
        // Default = 0
        minApA = 100000

        // Maximum apoapsis in meters.
        // Default = double.MaxValue
        maxApA = 250000

        // Minimum periapsis in meters.
        // Default = 0
        minPeA = 100000

        // Maximum periapsis in meters.
        // Default = double.MaxValue
        maxPeA = 250000

        // Minimum eccentricity.
        // Default = 0
        minEccentricity = 0.0

        // Maximum eccentricity.
        // Default = double.MaxValue
        maxEccentricity = 0.1

        // Minimum inclination in degrees
        // Default = 0
        minInclination = 0

        // Maximum inclination in degrees
        // Default = 180
        maxInclination = 1

        // Duration of the minimum orbital period.  Specify values in years (y),
        // days (d), hours (h), minutes (m), seconds (s) or any combination of
        // those.
        minPeriod = 6h 0m 50s

        // Duration of the maximum orbital period.  Specify values in years (y),
        // days (d), hours (h), minutes (m), seconds (s) or any combination of
        // those.
        minPeriod = 6h 0m 52s

        // Text to use for the parameter
        // Default Orbit: <orbit details>
        //title =
    }

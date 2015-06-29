The ReachSpecificOrbit parameter is used with the [[OrbitGenerator|OrbitGenerator-Behaviour]] behaviour to indicate that a generated orbit must be reached by a vessel.

    PARAMETER
    {
        name = ReachSpecificOrbit
        type = ReachSpecificOrbit

        // The index (0-based) in the OrbitGenerator behaviour of the orbit we
        // wish to reference.
        // Default = 0
        index = 0

        // The deviation window for how close we must match the given orbit.
        // wish to reference.  Higher values give more room for error.  Note: More
        // testing is required to better document the realistic range of values.
        // Default = 3.0
        deviationWindow = 10.0
    }

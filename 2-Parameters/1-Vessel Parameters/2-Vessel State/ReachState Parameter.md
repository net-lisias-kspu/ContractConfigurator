Checks that the vessel is in a specific state.  Use any combination of the attributes below.

    PARAMETER
    {
        name = ReachState
        type = ReachState

        // Minimum and maximum altitudes.
        minAltitude = 20000
        maxAltitude = 50000

        // Minimum and maximum altitudes above terrain.
        minTerrainAltitude = 500
        maxTerrainAltitude = 1000

        // Minimum and maximum speeds
        minSpeed = 1000
        maxSpeed = 5000

        // The name of the biome to reach.
        biome = Shores

        // (Optional) Target body.  Note that this is not defaulted
        // from the contract.
        targetBody = Duna

        // The situation.  Valid values from Vessel.Situations:
        //    ESCAPING
        //    FLYING
        //    LANDED
        //    ORBITING
        //    PRELAUNCH
        //    SPLASHED
        //    SUB_ORBITAL
        situation = FLYING

        // Text to use for the parameter
        // Default Vessel State: <state details>
        //title =
    }

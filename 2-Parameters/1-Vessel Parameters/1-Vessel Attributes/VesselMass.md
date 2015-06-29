##### VesselMass
The VesselMass parameter requires a player's vessel to be within the specified mass range.

    PARAMETER
    {
        name = VesselMass
        type = VesselMass

        // (Optional) Minimum and maximum mass.  Defaults are 0.0
        // and float.MaxValue for (min/max) respectively.
        minMass = 1.0
        maxMass = 10.0

        // Text for the contract parameter.
        // Default = Vessel mass: <mass>
        //title =
    }

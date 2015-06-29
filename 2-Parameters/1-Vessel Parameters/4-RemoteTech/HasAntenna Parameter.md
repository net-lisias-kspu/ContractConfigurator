The HasAntenna parameter requires that the vessel has an antenna that meets the specified criteria.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = HasAntenna
        type = HasAntenna

        // The minimum number of antenna that must meet the criteria.
        // Default = 1
        minCount = 1

        // The minimum number of antenna that can meet the criteria.
        // Default = int.MaxValue
        maxCount = 3

        // The minimum range in meters that the antenna must have
        // Default = 0.0
        minRange = 36000000000

        // The maximum range in meters that the antenna must have
        // Default = double.MaxValue
        maxRange = 100000000000

        // The type of antenna.  Dish or Omni.
        // Optional
        antennaType = Omni

        // This can be inherited from the the contract type if necessary
        // Optional
        targetBody = Duna

        // Specifies whether we are looking for a connection to the active
        // vessel.  Cannot be true if targetBody is specified.
        // Default = false
        activeVessel = True

        // Text to use for the parameter's title.
        // Default = Active vessel antenna range: <range>
        //title =
    }

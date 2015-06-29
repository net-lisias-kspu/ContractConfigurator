The ActiveVesselRange requirement checks that the given celestial body has a satellite with sufficient range (achievable either via an omni antenna or dish set to active vessel).

    REQUIREMENT:NEEDS[RemoteTech]
    {
        name = ActiveVesselRange
        type = ActiveVesselRange

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Kerbin

        // The range that is required, in meters.
        range = 48000000
    }

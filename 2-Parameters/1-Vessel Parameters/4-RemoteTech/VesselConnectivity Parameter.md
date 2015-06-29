The VesselConnectivity parameter requires that the vessel has direct connectivity to another vessel.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = VesselConnectivity
        type = VesselConnectivity

        // The vessel to check connectivity against.
        vessel = CommSat I

        // Whether to check for connectivity or the lack of connectivity.
        // Default = true
        hasConnectivity = true

        // Text to use for the parameter's title.
        // Default = Direct connection to: <vessel>
        //title =
    }	

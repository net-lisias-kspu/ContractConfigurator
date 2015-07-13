The VesselConnectivity parameter requires that the vessel has direct connectivity to another vessel.

<pre>
PARAMETER:NEEDS[RemoteTech]
{
    name = VesselConnectivity
    type = VesselConnectivity

    // The vessel to check connectivity against.
    //
    // Type:      VesselIdentifier
    // Required:  Yes
    //
    vessel = CommSat I

    // Whether to check for connectivity or the lack of connectivity.
    //
    // Type:      bool
    // Required:  No (defaulted)
    // Default:   true
    //
    hasConnectivity = true

    // Text to use for the parameter's title.
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Direct connection to: <vessel>
    //
    //title =
}
</pre>

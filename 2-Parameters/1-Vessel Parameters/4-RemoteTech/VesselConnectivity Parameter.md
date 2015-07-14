The VesselConnectivity parameter requires that the vessel has direct connectivity to another vessel.

<pre>
PARAMETER:NEEDS[RemoteTech]
{
    name = VesselConnectivity
    type = VesselConnectivity

    // The vessel to check connectivity against.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  Yes
    //
    vessel = CommSat I

    // Whether to check for connectivity or the lack of connectivity.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    hasConnectivity = true

    // Text to use for the parameter's title.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Direct connection to: &lt;vessel&gt;
    //
    //title =
}
</pre>

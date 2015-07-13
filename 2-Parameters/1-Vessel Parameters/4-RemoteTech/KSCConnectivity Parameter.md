The KSCConnectivity parameter requires that a vessel has connectivity to the Kerbal Space Center (ie. Mission Control).

<pre>
PARAMETER:NEEDS[RemoteTech]
{
    name = KSCConnectivity
    type = KSCConnectivity

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
    // Default:   Connected to KSC
    //
    //title =
}
</pre>

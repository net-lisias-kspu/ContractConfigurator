The NoStaging parameter is used to either prevent a VesselParameterGroup from completing or to fail a contract outright when a vessel is staged.  Note that the following are considered staging events:
1. Decoupling using a decoupler (either through the right click menu or a staging event).
2. Undocking/decoupling two docking nodes.

The following are not considered staging events:
1. A part breaking off
2. Launch clamps releasing.

<pre>
PARAMETER
{
    name = NoStaging
    type = NoStaging

    // Whether the entire contract should fail or just the parameter when
    // the timer reaches zero.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    failContract = true
}
</pre>

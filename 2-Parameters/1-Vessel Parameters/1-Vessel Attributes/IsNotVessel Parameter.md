The IsNotVessel parameter is used to create mutually exclusive groups within a contract.  Use the define attribute in the VesselParameterGroup parameter to define names, and then use the IsNotVessel within those to make the other vessel(s) invalid for completing the other group.

<pre>
PARAMETER
{
    name = IsNotVessel
    type = IsNotVessel

    // The key of the vessel that cannot complete this parameter.  This should
    // be a printable name, as it can be displayed to players if the key does
    // not yet point to a real craft.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  Yes
    //
    vessel = Vessel Key

    // Text for the contract parameter.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Vessel: Not &lt;vessel&gt;
    //
    //title =
}
</pre>

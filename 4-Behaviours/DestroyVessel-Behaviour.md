Behaviour for destroying a vessel after certain conditions are met.

<pre>
BEHAVIOUR
{
    name = DestroyVessel
    type = DestroyVessel

    // Indicates the state where the vessel should be destroyed.
    //
    // Type:      <a href="Enumeration-Type">TriggeredBehaviour.State</a>
    // Required:  Yes
    // Values:
    //     CONTRACT_ACCEPTED
    //     CONTRACT_FAILED
    //     CONTRACT_SUCCESS
    //     CONTRACT_COMPLETED
    //     PARAMETER_COMPLETED
    //
    onState = CONTRACT_SUCCESS

    // When the onState attribute is set to PARAMETER_COMPLETED, a value
    // must also be supplied for the parameter attribute.  This is the name
    // of the parameter that we are checking for completion.  This can be
    // specified multiple times.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Sometimes (multiples allowed)
    //
    parameter = TheParameterName

    // The vessel to be destroyed. This should either be derived via an
    // expression, or match the define name of a previous <a href="VesselParameterGroup-Parameter">VesselParameterGroup</a>
    // parameter.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  Yes (multiples allowed)
    //
    vessel = TheVesselName
}
</pre>

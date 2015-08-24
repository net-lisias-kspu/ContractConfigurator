Behaviour for changing the ownership of a vessel after certain conditions are met.

<pre>
BEHAVIOUR
{
    name = ChangeVesselOwnership
    type = ChangeVesselOwnership

    // Indicates the state where the vessel ownership should be changed.
    //
    // Type:      <a href="Enumeration-Type">ChangeVesselOwnership.State</a>
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

    // The vessel for which we will be changing the ownership of.  This
    // should either be derived via an expression, or match the define
    // name of a previous <a hrefVesselParameterGroup-Parameter>VesselParameterGroup</A> parameter.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  Yes (multiples allowed)
    //
    vessel = TheVesselName

    // Whether to make the vessel owned or unowned.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    owned = false
}
</pre>

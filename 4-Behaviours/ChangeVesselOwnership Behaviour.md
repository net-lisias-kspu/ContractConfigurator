Behaviour for changing the ownership of a vessel after certain conditions are met.

<pre>
BEHAVIOUR
{
    name = ChangeVesselOwnership
    type = ChangeVesselOwnership

    // Indicates the state where the vessel ownership should be changed.
    //
    // Type:      ChangeVesselOwnership.State
    // Required:  Yes
    // Values:
    //     ContractAccepted
    //     ContractCompletedFailure
    //     ContractCompletedSuccess
    //     ParameterCompleted
    //
    onState = ContractCompletedSuccess

    // When the onState attribute is set to ParameterCompleted, a value
    // must also be supplied for the parameter attribute.  This is the name
    // of the parameter that we are checking for completion.  This can be
    // specified multiple times.
    //
    // Type:      string
    // Required:  See above
    //
    parameter = TheParameterName

    // The vessel for which we will be changing the ownership of.  This
    // should either be derived via an expression, or match the define
    // name of a previous <a hrefVesselParameterGroup-Parameter>VesselParameterGroup</A> parameter.
    //
    // Type:      VesselIdentifier
    // Required:  Yes (multiples allowed)
    //
    vessel = TheVesselName

    // Whether to make the vessel owned or unowned.
    //
    // Type:      bool
    // Required:  No (defaulted)
    // Default:   true
    //
    owned = false
}
</pre>

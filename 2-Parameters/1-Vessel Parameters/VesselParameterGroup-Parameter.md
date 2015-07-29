#### VesselParameterGroup
The VesselParameterGroup parameter is used to group several child vessel parameters together.  It can also be used to specify a duration for which the parameters must be true, and will track across non-active vessels.  Note that when used without a VesselParameterGroup parent parameter, vessel parameters will only track the current active vessel.

<pre>
PARAMETER
{
    name = VesselParameterGroup
    type = VesselParameterGroup

    // The duration that the conditions must be satisfied for.  Can specify
    // values in years (y), days (d), hours (h), minutes (m), seconds (s) or
    // any combination of those.
    //
    // Type:      <a href="Duration-Type">Duration</a>
    // Required:  No
    //
    duration = 10d 2h

    // Define the name of the craft that will complete this parameter group.
    // Once a craft completes the group, it will be associated with the
    // given key, which can then be referenced in other parameters.  The
    // Vessel <=> key association is persistent, and can be used in future
    // contracts.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No
    //
    define = Vessel Key

    // Lock this parameter so that it can only be accomplished by the
    // specified craft.  Note that the name is a "define" name set via
    // the define key in a *different* VesselParameterGroup parameter
    // (which can be in the same contract, or a different one).  This
    // attribute can be specified multiple times to allow multiple vessel
    // to be available to complete the parameter.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  No (multiples allowed)
    //
    vessel = Vessel Key
    vessel = Some other vessel

    // If the contract completes successfully, whether to remove any associated
    // vessels set via the define attribute.  Use this for contracts where you
    // don't want the vessel tracked into other contracts (especially true if
    // you want the contract to be repeatable).
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defauled)
    // Default:   false
    //
    dissassociateVesselsOnContractCompletion = false

    // If the contract fails, whether to remove any associated vessels
    // set via the define attribute.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defauled)
    // Default:   true
    //
    dissassociateVesselsOnContractFailure = true

    // The title text to display.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Vessel: Any; Duration: &lt;duration&gt;
    //
    //title =

    // Examples of typical child parameters used with VesselParameterGroup
    PARAMETER
    {
        name = ReachState
        type = ReachState

        situation = ORBITING
    }

    PARAMETER
    {
        name = HasCrew
        type = HasCrew
    }
}
</pre>

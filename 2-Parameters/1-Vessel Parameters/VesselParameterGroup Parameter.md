#### VesselParameterGroup
The VesselParameterGroup parameter is used to group several child vessel parameters together.  It can also be used to specify a duration for which the parameters must be true, and will track across non-active vessels.  Note that when not used with a VesselParameterGroup parent parameter, the other vessel parameters on this page will only work with the active vessel.

    PARAMETER
    {
        name = VesselParameterGroup
        type = VesselParameterGroup

        // The title text to display.
        // Default - Vessel: Any; Duration: <duration>
        // Note in future this will be expanded to support setting the parameters to
        // be for a specific vessel
        //title =

        // The duration that the conditions must be satisfied for.  Can specify
        // values in years (y), days (d), hours (h), minutes (m), seconds (s) or
        // any combination of those.
        duration = 10d 2h

        // Define the name of the craft that will complete this parameter group.
        // Once a craft completes the group, it will be associated with the
        // given key, which can then be referenced in other parameters.  The
        // Vessel <=> key association is persistent, and can be used in future
        // contracts.
        define = Vessel Key

        // Lock this parameter so that it can only be accomplished by the
        // specified craft.  Note that the name is a "define" name set via
        // the define key in a *different* VesselParameterGroup parameter
        // (which can be in the same contract, or a different one).  This
        // attribute can be specified multiple times to allow multiple vessel
        // to be available to complete the parameter.
        vessel = Vessel Key
        vessel = Some other vessel

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

The VesselNotDestroyed parameter is a negative parameter - it will cause the contract to fail if a specified vessel (or any vessel in some cases) is destroyed.

    PARAMETER
    {
        name = VesselNotDestroyed
        type = VesselNotDestroyed

        // The vessel attribute is the *defined* name of the vessel that should
        // not be destroyed.  This is a name of a vessel defined either with
        // the define attribute of a VesselParameterGroup parameter, or via a
        // SpawnVessel.
        //
        // It can be specified multiple times, and if *no* vessel is specified,
        // then the parameter applies to all vessels.
        //
        // If this parameter is a child of a VesselParameterGroup parameter,
        // and no vessel is provided, *and* the VesselParameterGroup does have
        // vessels specified, then the list of vessels that cannot be destroyed
        // is automatically derived from the parent parameter.
        vessel = Vessel not to be destroyed
        vessel = Another vessel that should not be destroyed

        // Text for the contract parameter.
        // Default varies depending on the situation.
        //title =
    }

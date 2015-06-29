The TargetDestroyed indicates that a specific target vessel (or vessels) must be destroyed.  Use it for setting up targets for weapons mods.

    PARAMETER
    {
        name = TargetDestroyed
        type = TargetDestroyed

        // The vessel attribute is the *defined* name of the vessel that should
        // not be destroyed.  This is a name of a vessel defined either with
        // the define attribute of a VesselParameterGroup parameter, or via a
        // SpawnVessel.
        //
        // It can be specified multiple times, but there must be at least one.
        vessel = First Target
        vessel = Second Target

        // Text for the contract parameter.
        // Default: Target destroyed
        //title =
    }

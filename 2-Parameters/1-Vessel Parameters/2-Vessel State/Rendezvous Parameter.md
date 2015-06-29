Rendezvous parameters require that a vessel performs a rendezvous with another vessel.

    PARAMETER
    {
        name = Rendezvous
        type = Rendezvous

        // The vessel attribute is the *defined* name of the vessel that must
        // participate in the rendezvous event.  This is a name of a vessel
        // defined either with the define attribute of a VesselParameterGroup
        // parameter, or via a SpawnVessel.
        //
        // If this Rendezvous parameter is a child of a VesselParameterGroup
        // parameter, then no more than *one* vessel should be provided (the
        // other is the vessel being tracked under the VesselParameterGroup).
        // If no vessel attributes are provided, the second vessel will match
        // any vessel.
        //
        // If this Rendezvous parameter is NOT a child of a VesselParameterGroup,
        // then *at least one* vessel must be provided.  If only one vessel is
        // provided, then the second vessel will match any vessel.
        vessel = First Vessel to Rendezvous
        vessel = Second Vessel to Rendezvous

        // Distance in meters that defines a rendezvous as having occurred.
        // Default = 2000.0
        distance = 2500.0

        // Text for the contract parameter.
        // Default varies depending on the situation.
        //title =
    }

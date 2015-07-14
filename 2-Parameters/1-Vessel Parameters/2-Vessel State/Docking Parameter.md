The Docking parameter require that a vessel docks with another vessel.

<pre>
PARAMETER
{
    name = Docking
    type = Docking

    // The vessel attribute is the *defined* name of the vessel that must
    // participate in the docking event.  This is a name of a vessel
    // defined either with the define attribute of a VesselParameterGroup
    // parameter, or via a SpawnVessel.
    //
    // If this Docking parameter is a child of a VesselParameterGroup
    // parameter, then no more than *one* vessel should be provided (the
    // other is the vessel being tracked under the VesselParameterGroup).
    // If no vessel attributes are provided, the second vessel will match
    // any vessel.
    //
    // If this Docking parameter is NOT a child of a VesselParameterGroup,
    // then *at least one* vessel must be provided.  If only one vessel is
    // provided, then the second vessel will match any vessel.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  Yes (multiples allowed)
    //
    vessel = First Vessel to Dock
    vessel = Second Vessel to Dock

    // New defined name by which to refer to the docked vessel.  Use this
    // to chain docking parameters, but require them to be done in a certain
    // order.  Generally this name will never be displayed to the player.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No
    //
    defineDockedVessel = My New Vessel

    // Text for the contract parameter.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   (differs based on scenario)
    // 
    //title =
}
</pre>

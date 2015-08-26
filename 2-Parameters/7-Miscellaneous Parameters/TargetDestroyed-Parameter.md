The TargetDestroyed indicates that a specific target vessel (or vessels) must be destroyed.  Use it for setting up targets for weapons mods.

<pre>
PARAMETER
{
    name = TargetDestroyed
    type = TargetDestroyed

    // The vessel attribute is the *defined* name of the vessel that should
    // not be destroyed.  This is a name of a vessel defined either with
    // the define attribute of a <a href=VesselParameterGroup-Parameter>VesselParameterGroup</a> parameter, or via the
    // <a href=SpawnVessel-Behaviour>SpawnVessel</a> behaviour.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  Yes (multiples allowed)
    //
    vessel = First Target
    vessel = Second Target

    // Text for the contract parameter.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Target destroyed
    //
    //title =
}
</pre>

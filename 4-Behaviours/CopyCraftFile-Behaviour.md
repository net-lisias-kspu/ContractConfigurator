Behaviour to copy a craft file from GameData into the player's save file.

<pre>
BEHAVIOUR
{
    name = CopyCraftFile
    type = CopyCraftFile

    // Path to the .craft file (relative to the GameData/ directory).
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Yes
    //
    url = ContractPacks/MyContractPack/SomeVessel.craft

    // The type of craft file.  This will determine whether the craft is
    // available to the player under the VAB or SPH tabs.
    //
    // Type:      <a href="Enumeration-Type">CopyCraftFile.CraftType</a>
    // Required:  Yes
    // Values:
    //     VAB
    //     SPH
    //     SubAssembly
    //
    craftType = VAB

    // The condition under which the craft file is copied.
    //
    // Type:      <a href="Enumeration-Type">TriggeredBehaviour.State</a>
    // Required:  No (defaulted)
    // Values:
    //     CONTRACT_ACCEPTED
    //     CONTRACT_FAILED
    //     CONTRACT_SUCCESS (default)
    //     CONTRACT_COMPLETED
    //     PARAMETER_COMPLETED
    //     PARAMETER_FAILED
    //
    onState = PARAMETER_COMPLETED

    // When the onState attribute is set to PARAMETER_COMPLETED, a value
    // must also be supplied for the parameter attribute.  This is the name
    // of the parameter that we are checking for completion.  This can be
    // specified multiple times.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Sometimes (multiples allowed)
    //
    parameter = MyParameterName
}
</pre>

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
    // Type:      <a href="Enumeration-Type">EditorFacility</a>
    // Required:  Yes
    // Values:
    //     VAB
    //     SPH
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

    // The *name* of the parameter to which this condition applies.
    // Required if the condition is one of the PARAMETER_ ones.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  See above
    //
    parameter = MyParameterName
}
</pre>

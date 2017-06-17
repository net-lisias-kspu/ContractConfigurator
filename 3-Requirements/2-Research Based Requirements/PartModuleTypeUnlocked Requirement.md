Requirement for having a "type" of PartModule unlocked from the tech tree.

<pre>
REQUIREMENT
{
    name = PartModuleTypeUnlocked
    type = PartModuleTypeUnlocked

    // Type of PartModule that needs to be unlocked.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Yes (multiples allowed)
    // Values (defined in <a href="https://kerbalspaceprogram.com/api/class_fine_print_1_1_contract_defs.html">ContractDefs</a>):
    //     Antenna
    //     Battery
    //     Dock
    //     Generator
    //     Grapple
    //     Wheel
    partModuleType = Antenna
    partModuleType = Power
}
</pre>

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
    // Values (defined in Squad/Contracts/Contracts.cfg under
    // MODULE_DEFINITIONS):
    //     Antenna
    //     Dock
    //     Grapple
    //     Power
    //     Wheel
    partModuleType = Antenna
    partModuleType = Power
}
</pre>

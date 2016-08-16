Requirement for having researched a technology.

<pre>
REQUIREMENT
{
    name = TechResearched
    type = TechResearched

    // Use one of the two following methods to identifier the tech(s).

    // The technology that needs to have been researched.  Take special
    // note that this does not get validated - if you make a typo, the
    // requirement will always return false.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (multiples allowed)
    //
    tech = basicRocketry

    // A part that needs to have its technology unlocked.  Note that if the
    // player is playing with part unlocking, that that is only checking for
    // the tech being unlocked  (the player may have the technology, but not
    // the part).  Use <a href=PartUnlocked-Requirement>PartUnlocked</a> to check for part unlocking.
    //
    // Type:      <a href="AvailablePart-Type">AvailablePart</a>
    // Required:  No (multiples allowed)
    //
    part = SmallGearBay

    // PartModule that needs to have its tech unlocked.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (multiples allowed)
    //
    partModule = ModuleReactionWheel

    // Type of PartModule that needs to have its tech unlocked.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (multiples allowed)
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

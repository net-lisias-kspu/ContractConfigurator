Requirement for having researched a technology.

<pre>
REQUIREMENT
{
    name = TechResearched
    type = TechResearched

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
}
</pre>

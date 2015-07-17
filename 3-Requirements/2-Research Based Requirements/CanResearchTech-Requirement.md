Requirement to check whether a player has the pre-requisites to research a tech.  Note that this will also be met if the tech itself is researched, use with a negated [[TechResearched|TechResearched-Requirement]] if this is undesirable.

<pre>
REQUIREMENT
{
    name = CanResearchTech
    type = CanResearchTech

    // Use one of the two following methods to identifier the tech(s).

    // The technology that needs to be available to research.  Take special
    // note that this does not get validated - if you make a typo, the
    // requirement will always return false.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (multiples allowed)
    //
    tech = engineering101

    // A part that needs to have its technology available to research.
    //
    // Type:      <a href="AvailablePart-Type">AvailablePart</a>
    // Required:  No (multiples allowed)
    //
    part = SmallGearBay
}
</pre>

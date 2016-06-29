If at most the given number of child requirements are met, then the requirement is met.

<pre>
REQUIREMENT
{
    name = AtMost
    type = AtMost

    // Maximum number of requirements that can match.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  Yes
    //
    count = 2

    REQUIREMENT
    {
        name = ReachSpace
        type = ReachSpace
    }

    REQUIREMENT
    {
        name = TechResearched
        type = TechResearched

        tech = basicRocketry
    }

    REQUIREMENT
    {
        name = Science
        type = Science

        minScience = 50
    }
}
</pre>

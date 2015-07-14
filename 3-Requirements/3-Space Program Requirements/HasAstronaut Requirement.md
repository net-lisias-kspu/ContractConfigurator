Requirement that checks whether the player has Kerbals in their space program matching the given criteria.

<pre>
REQUIREMENT
{
    name = HasAstronaut
    type = HasAstronaut

    // The type of trait required.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No
    // Values (for stock KSP):
    //     Pilot
    //     Engineer
    //     Scientist
    //
    trait = Engineer

    // Minimum experience level required.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0
    //
    minExperience = 2

    // Maximum experience level allowed.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   5
    //
    maxExperience = 5

    // Minimum count.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   1
    //
    minCount = 1

    // Maximum count.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   int.MaxValue
    //
    maxCount = 5
}
</pre>

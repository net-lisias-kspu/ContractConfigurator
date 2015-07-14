Parameter to require a certain number/type of hired astronauts.
<pre>
PARAMETER
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
    trait = Pilot

    // Minimum experience level.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0
    //
    minExperience = 1

    // Maximum experience level.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   5
    //
    maxExperience = 2

    // Minimum count of astronauts that must match the attributes above.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   1
    //
    minCount = 1

    // Maximum count of astronauts that must match the attributes above.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   int.MaxValue
    //
    maxCount = 10

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   (differs based on scenario)
    // 
    //title =
}
</pre>

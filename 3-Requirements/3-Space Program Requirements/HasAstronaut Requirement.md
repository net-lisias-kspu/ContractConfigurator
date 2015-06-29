Requirement that checks whether the player has Kerbals in their space program matching the given criteria.

    REQUIREMENT
    {
        name = HasAstronaut
        type = HasAstronaut

        // (Optional) The type of trait required.  Valid values are:
        //    Pilot
        //    Engineer
        //    Scientist
        trait = Engineer

        // (Optional) Minimum and maximum experience level.  Default values are
        // 0 and 5 (for min/max).
        minExperience = 2
        maxExperience = 5

        // (Optional) Minimum and maximum count.  Default values are 1 and
        // int.MaxValue (for min/max).
        minCount = 1
        maxCount = 5
    }

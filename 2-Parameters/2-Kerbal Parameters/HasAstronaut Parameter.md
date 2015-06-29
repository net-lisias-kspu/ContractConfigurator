Parameter to require a certain number/type of hired astronauts.

    PARAMETER
    {
        name = HasAstronaut
        type = HasAstronaut

        // (Optional) The type of trait required.  Valid values are:
        //    Pilot
        //    Engineer
        //    Scientist
        trait = Pilot

        // (Optional) Minimum and maximum experience level.  Default values are
        // 0 and 5 (for min/max).
        minExperience = 1
        maxExperience = 2

        // (Optional) Minimum and maximum count.  Default values are 1 and
        // int.MaxValue (for min/max).
        minCount = 1
        maxCount = 10

        // Text to use for the parameter
        // Default (maxCrew = int.MAXVALUE) = Astronauts: At least <minCrew>
        // Default (minCrew = 0) = Astronauts: At most <maxCrew>
        // Default (minCrew = maxCrew) = Astronauts: Exactly <minCrew>
        // Default (else) = Astronauts: Between <minCrew> and <maxCrew>
        //title =
    }

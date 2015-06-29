##### HasCrew
Parameter to indicate that the Vessel in question must have a certain number of crew members (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasCrew
        type = HasCrew

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
        minCrew = 1
        maxCrew = 10

        // (Optional) Specific Kerbal(s) that must be on board.  Can be
        // specified multiple times, but cannot be used with the other
        // attributes on this parameter.
        kerbal = Jebediah Kerman

        // Text to use for the parameter
        // Default (maxCrew = 0) = Crew: Unmanned
        // Default (maxCrew = int.MAXVALUE) = Crew: At least <minCrew> Kerbals
        // Default (minCrew = 0) = Crew: At most <maxCrew> Kerbals
        // Default (minCrew = maxCrew) = Crew: Exactly <minCrew> Kerbals
        // Default (else) = Crew: Between <minCrew> and <maxCrew> Kerbals
        //title =
    }

Requirement for having researched a technology.

    REQUIREMENT
    {
        name = TechResearched
        type = TechResearched

        // The technology that needs to have been researched.  Take special
        // note that this does not get validated - if you make a typo, the
        // requirement will always return false.  May be specified multiple
        // times.
        tech = basicRocketry

        // A part that needs to have its technology unlocked.  Note that if the
        // player is playing with part unlocking, that that is only checking for
        // the tech being unlocked  (the player may have the technology, but not
        // the part).  May be specified multiple times.
        part = SmallGearBay
    }

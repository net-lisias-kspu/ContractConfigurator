Requirement that checks whether the player has the given facility upgraded (or not upgraded) to the specified level.

    REQUIREMENT
    {
        name = Facility
        type = Facility

        // The facility.  Valid values are:
        //    LaunchPad
        //    Runway
        //    VehicleAssemblyBuilding
        //    SpaceplaneHangar
        //    TrackingStation
        //    AstronautComplex
        //    MissionControl
        //    ResearchAndDevelopment
        //    Administration
        facility = Administration

        // (Optional) Minimum and maximum facility level.  Default values are
        // 0 and 2 (for min/max).
        minLevel = 2
        maxLevel = 2
    }

Requirement that checks whether the player has the given facility upgraded (or not upgraded) to the specified level.

<pre>
REQUIREMENT
{
    name = Facility
    type = Facility

    // The facility.
    //
    // Type:      string
    // Required:  Yes
    // Values:
    //     LaunchPad
    //     Runway
    //     VehicleAssemblyBuilding
    //     SpaceplaneHangar
    //     TrackingStation
    //     AstronautComplex
    //     MissionControl
    //     ResearchAndDevelopment
    //     Administration
    facility = Administration

    // Minimum facility level required.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   0
    //
    minLevel = 2

    // Maximum facility level allowed.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   2
    //
    maxLevel = 2
}
</pre>

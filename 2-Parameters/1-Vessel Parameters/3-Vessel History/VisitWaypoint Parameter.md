The VisitWaypoint parameter is used with the [[WaypointGenerator|Behaviours#waypointgenerator]] behaviour to indicate that a generated waypoint must be visited by a vessel.

    PARAMETER
    {
        name = VisitWaypoint
        type = VisitWaypoint

        // Index of the waypoint in the WaypointGenerator behaviour.
        // Default = 0
        index = 0

        // Distance tolerance to be considered at the waypoint.
        // Default = 500.0 (if on the surface).
        //         = <waypoint altitude> / 5.0 (if in the air).
        distance = 500.0

        
        // Text to use for the parameter
        // Default = Location: <waypoint>
        //title =
    }

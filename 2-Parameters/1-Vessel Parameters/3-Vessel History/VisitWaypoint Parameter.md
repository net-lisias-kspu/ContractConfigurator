The VisitWaypoint parameter is used with the [[WaypointGenerator|WaypointGenerator-Behaviour]] behaviour to indicate that a generated waypoint must be visited by a vessel.

<pre>
PARAMETER
{
    name = VisitWaypoint
    type = VisitWaypoint

    // The index (0-based) in the WaypointGenerator behaviour of the waypoint we
    // wish to reference.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   0
    //
    index = 0

    // Distance tolerance to be considered at the waypoint.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   500.0 (if on the surface).
    //            <waypoint altitude> / 5.0 (if not on the surface).
    //
    distance = 500.0

    // Whether the waypoint should get automatically hidden after completing
    // the contract objective.
    //
    // Type:      bool
    // Required:  No (defaulted)
    // Default:   true
    //
    hideOnCompletion = true
    
    // Text to use for the parameter
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Location: <waypoint>
    // 
    //title =
}
</pre>

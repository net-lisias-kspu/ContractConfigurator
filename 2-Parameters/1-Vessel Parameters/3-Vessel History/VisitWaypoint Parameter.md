The VisitWaypoint parameter is used with the [[WaypointGenerator|WaypointGenerator-Behaviour]] behaviour to indicate that a generated waypoint must be visited by a vessel.

<pre>
PARAMETER
{
    name = VisitWaypoint
    type = VisitWaypoint

    // The index (0-based) in the <a href="WaypointGenerator-Behaviour">WaypointGenerator</a> behaviour of the waypoint we
    // wish to reference.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0
    //
    index = 0

    // Distance tolerance to be considered at the waypoint.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   500.0 (if on the surface).
    //            <waypoint altitude> / 5.0 (if not on the surface).
    //
    distance = 500.0

    // Whether the waypoint should get automatically hidden after completing
    // the contract objective.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    hideOnCompletion = true

    // Whether to show the "Entering/Leaving $waypointName." messages when a player gets within the
    // distance tolerance of the waypoint.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   false
    //
    showMessages = false
    
    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Location: &lt;waypoint&gt;
    // 
    //title =
}
</pre>

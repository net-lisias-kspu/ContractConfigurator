The ReachSpecificOrbit parameter is used with the [[OrbitGenerator|OrbitGenerator-Behaviour]] behaviour to indicate that a generated orbit must be reached by a vessel.

<pre>
PARAMETER
{
    name = ReachSpecificOrbit
    type = ReachSpecificOrbit

    // By default, will display stock notes about the orbit details.  Set to
    // false to disable this display.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    displayNotes = true

    // The index (0-based) in the <a href="OrbitGenerator-Behaviour">OrbitGenerator</a> behaviour of the orbit we
    // wish to reference.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0
    //
    index = 0

    // The deviation window for how close we must match the given orbit.
    // wish to reference.  Higher values give more room for error.  Note: More
    // testing is required to better document the realistic range of values.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   3.0
    //
    deviationWindow = 10.0
}
</pre>

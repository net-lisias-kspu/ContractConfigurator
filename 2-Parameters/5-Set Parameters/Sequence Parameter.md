The Sequence parameter is one of two ways to define parameters that need to be completed in sequence.  For this variant, use Sequence as a parent node for all nodes that must be completed in order.  If any parameter completes out of order, this parameter will fail - causing the contract to fail.

<pre>
// In this example of the Sequence parameter, the player must orbit the Mun,
// then orbit Minmus.  If the player orbits Minmus first, the parameter fails.
PARAMETER
{
    name = Sequence
    type = Sequence

    // Hide the parameter(s) with the given name until it is the next one in
    // the list to be completed.
    //
    // Type:      bool
    // Required:  No (multiples allowed)
    //
    hiddenParameter = OrbitMinmus

    // By default, parameters that are prevented from completing if they
    // are out of order.  To cause a failure instead, set this to true.
    //
    // Type:      bool
    // Required:  No (defaulted)
    // Default:   false
    //
    failWhenCompleteOutOfOrder = true

    // The text to display.  Highly recommended not to use the default text, as
    // when the parameter is complete the text of the children disappears (and
    // the default text doesn't give the player a very good idea what the
    // parameter was about).
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Complete the following in order
    //
    //title =

    PARAMETER
    {
        name = OrbitMun
        type = VesselParameterGroup

        title = Orbit the Mun

        PARAMETER
        {
            name = ReachState
            type = ReachState

            situation = ORBITING
        }

        PARAMETER
        {
            name = ReachState
            type = ReachState

            targetBody = Mun
        }
    }

    PARAMETER
    {
        name = OrbitMinmus
        type = VesselParameterGroup

        title = Orbit Minmus

        PARAMETER
        {
            name = ReachSituation
            type = ReachSituation

            situation = ORBITING
        }

        PARAMETER
        {
            name = ReachDestination
            type = ReachDestination

            targetBody = Minmus
        }
    }
}
</pre>

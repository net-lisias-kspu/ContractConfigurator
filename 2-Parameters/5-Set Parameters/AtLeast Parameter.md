The AtLeast parameter is completed if a specified number of its child parameters are completed.

    PARAMETER
    {
        name = AtLeast
        type = AtLeast

        // The minimum number that must be completed.
        count = 1

        // The text to display.  Highly recommended that you do not use the default -
        // when the parameter is complete the text of the children disappears (and
        // the default text doesn't give the player a very good idea what the
        // parameter was about).
        //
        // Default - Complete at least <count> of the following
        //title =

        PARAMETER
        {
            name = ReachSpace
            type = ReachSpace
        }

        PARAMETER
        {
            name = ReachState
            type = ReachState

            minSpeed = 1000
            maxSpeed = 5000
        }
    }

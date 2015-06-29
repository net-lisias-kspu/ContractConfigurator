The All parameter is completed once all its child parameters are completed.

    PARAMETER
    {
        name = All
        type = All

        // The text to display.  Highly recommended that you do not use the default -
        // when the parameter is complete the text of the children disappears (and
        // the default text doesn't give the player a very good idea what the
        // parameter was about).
        //
        // Default - Complete ALL of the following
        title = Do these things

        // Child parameters look just like a regular parameter (and can be infinitely
        // nested)
        PARAMETER
        {
            name = ReachState
            type = ReachState

            minAltitude = 20000
            maxAltitude = 50000

            minSpeed = 1000
            maxSpeed = 5000
        }

        PARAMETER
        {
            name = HasCrew
            type = HasCrew
        }
    }

The None parameter will fail if any of its child parameters are completed.  Note that the correct way to use this is to set the completeInSequence to true and to place this parameter at the bottom of the appropriate group of parameters.  Otherwise, the parameter will get marked as completed almost immediately, which hides the child parameters.

    PARAMETER
    {
        name = None
        type = None

        // The text to display.  Highly recommended that you do not use the default -
        // when the parameter is complete the text of the children disappears (and
        // the default text doesn't give the player a very good idea what the
        // parameter was about).
        //
        // Default - Prevent ALL of the following
        //title =

        // Generally need completeInSequence set to true for this.
        completeInSequence = true

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

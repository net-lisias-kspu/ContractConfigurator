The All parameter is completed once all its child parameters are completed.

<pre>
PARAMETER
{
    name = All
    type = All

    // The text to display.  Highly recommended not to use the default text, as
    // when the parameter is complete the text of the children disappears (and
    // the default text doesn't give the player a very good idea what the
    // parameter was about).
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Complete ALL of the following
    //
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
</pre>

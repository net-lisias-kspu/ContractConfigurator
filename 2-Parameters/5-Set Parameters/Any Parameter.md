The Any parameter is completed if any one of its child parameters are completed.

<pre>
PARAMETER
{
    name = Any
    type = Any

    // The text to display.  Highly recommended not to use the default text, as
    // when the parameter is complete the text of the children disappears (and
    // the default text doesn't give the player a very good idea what the
    // parameter was about).
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Complete any ONE of the following
    //
    title = Do this or that

    // Child parameters look just like a regular parameter (and can be infinitely
    // nested)
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
</pre>

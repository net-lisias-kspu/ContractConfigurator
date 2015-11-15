The Not parameter inverts the state of its child parameter.  This frequently is used with the completeInSequence flag.

<pre>
PARAMETER
{
    name = Not
    type = Not

    // The text to display.  Highly recommended not to use the default text, as
    // when the parameter is complete the text of the children disappears (and
    // the default text doesn't give the player a very good idea what the
    // parameter was about).
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Is not true
    //title =

    // Generally need completeInSequence set to true for the Not parameter.
    // See the <a href=Parameters>Parameters</a> page for more details.
    completeInSequence = true

    PARAMETER
    {
        name = ReachState
        type = ReachState

        situation = LANDED
    }
}
</pre>

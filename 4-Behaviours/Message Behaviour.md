Behaviour for displaying a message within the messaging system in the top right corner.

<pre>
BEHAVIOUR
{
    name = Message
    type = Message

    // Title of the message.  This will be displayed in the title bar.
    title = A message

    // The actual message, can be more or less as long as desired.
    message = This is a message that informs the player of something.

    // Conditions on which the message will be displayed, can have multiple
    // conditions, and the message will get displayed once for *each*
    // condition.
    CONDITION
    {
        // The type of condition.
        //
        // Type:      Message.Condition
        // Required:  Yes
        // Values:
        //     CONTRACT_COMPLETED
        //     CONTRACT_FAILED
        //     PARAMETER_COMPLETED
        //     PARAMETER_FAILED
        //
        condition = PARAMETER_COMPLETED

        // The *name* of the parameter to which this condition applies.
        // Required if the condition is one of the PARAMETER_ ones.
        //
        // Type:      string
        // Required:  See above
        //
        parameter = MyParameterName
    }
}
</pre>

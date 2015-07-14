The SignalDelay parameter specifies min/max values for the signal delay back to the KSC.

<pre>
PARAMETER:NEEDS[RemoteTech]
{
    name = SignalDelay
    type = SignalDelay

    // Minimum signal delay in seconds.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   1.0
    //
    minSignalDelay = 1.0

    // Maximum signal delay in seconds.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxSignalDelay = 70.0

    // Text to use for the parameter's title.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Signal delay: Between &lt;min&gt; and &lt;max&gt;.
    //
    //title =
}
</pre>

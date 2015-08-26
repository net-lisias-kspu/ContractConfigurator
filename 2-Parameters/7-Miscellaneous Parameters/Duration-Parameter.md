The Duration parameter sets up a timer.  Once the timer expires, the parameter is completed.  The timer will start when all sibling parameters that are *higher* than the Duration parameter in the contract are completed.  The Duration parameter can also be used as a child parameter to prevent a parent parameter from completing until the duration is reached.
<pre>
PARAMETER
{
    name = Duration
    type = Duration

    // The duration the timer is set to. Can specify values in years (y),
    // days (d), hours (h), minutes (m), seconds (s) or any combination of
    // those.
    //
    // Type:      <a href="Duration-Type">Duration</a>
    // Required:  Yes
    //
    duration = 30m 10s

    // The preWaitText overrides the text that is displayed when waiting
    // for the other parameters to complete.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Waiting time required
    //
    //preWaitText =

    // The waitingText overrides the text that is displayed when waiting
    // for the timer to expire.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Time to completion
    //
    //waitingText =

    // The completionText is displayed when the timer completes.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Wait time over
    //
    //completionText =
}
</pre>
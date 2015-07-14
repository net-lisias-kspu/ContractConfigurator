The Timer parameter sets up a timer that starts when the contract is accepted.  The player only has the specified duration before the timer expires and the contract fails!

<pre>
PARAMETER
{
    name = Timer
    type = Timer

    // The duration the timer is set to. Can specify values in years (y),
    // days (d), hours (h), minutes (m), seconds (s) or any combination of
    // those.
    //
    // Type:      <a href="Duration-Type">Duration</a>
    // Required:  Yes
    //
    duration = 30m

    // The type of timer (indicates what will trigger the timer to start).
    //
    // Type:      <a href="Enumeration-Type">Timer.TimerType</a>
    // Required:  No (defaulted)
    // Values:
    //     CONTRACT_ACCEPTANCE (default)
    //     NEXT_LAUNCH
    //     PARAMETER_COMPLETION
    //
    timerType = CONTRACT_ACCEPTANCE

    // If the timerType is set to PARAMETER_COMPLETION, the name of the
    // parameter that must be completed to trigger the timer start.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  See above
    //
    parameter = TheParameter

    // Whether the entire contract should fail or just the parameter when
    // the timer reaches zero.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    failContract = true
}
</pre>

The Timer parameter sets up a timer that starts when the contract is accepted.  The player only has the specified duration before the timer expires and the contract fails!

    PARAMETER
    {
        name = Timer
        type = Timer

        // The duration the timer is set to. Can specify values in years (y),
        // days (d), hours (h), minutes (m), seconds (s) or any combination of
        // those.
        duration = 30m

        // The type of timer (indicates what will trigger the timer to start).
        // Default = CONTRACT_ACCEPTANCE
        // Valid values:
        //     CONTRACT_ACCEPTANCE
        //     NEXT_LAUNCH
        //     PARAMETER_COMPLETION
        timerType = CONTRACT_ACCEPTANCE

        // If the timerType is set to PARAMETER_COMPLETION, the name of the
        // parameter that must be completed to trigger the timer start.
        parameter = TheParameter

        // Whether the entire contract should fail or just the parameter when
        // the timer reaches zero.
        // Default = true
        failContract = true
    }

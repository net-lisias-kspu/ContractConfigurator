A timer for tracking mission time.  Unlike the [[Timer|Timer-Parameter]] and [[Duration|Duration-Parameter]] parameters, this timer is purely cosmetic.  It starts counting up at a specified condition, and stops counting at another specified condition.  This can be used to create challenge or race contracts to get a best time for doing something.

<pre>
PARAMETER
{
    name = MissionTimer
    type = MissionTimer

    // The timer's starting conditions.
    //
    // Type:      <a href="Enumeration-Type">MissionTimer.StartCriteria</a>
    // Required:  No (defaulted)
    // Values:
    //     CONTRACT_ACCEPTANCE (default)
    //     NEXT_LAUNCH
    //     PARAMETER_COMPLETION
    //
    startCriteria = CONTRACT_ACCEPTANCE

    // If the startCriteria is set to PARAMETER_COMPLETION, the name of the
    // parameter that must be completed to trigger the timer start.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  See above
    //
    startParameter = TheParameter

    // The timer's ending conditions.
    //
    // Type:      <a href="Enumeration-Type">MissionTimer.EndCriteria</a>
    // Required:  No (defaulted)
    // Values:
    //     CONTRACT_COMPLETION (default)
    //     PARAMETER_COMPLETION
    //
    endCriteria = CONTRACT_COMPLETION

    // If the endCriteria is set to PARAMETER_COMPLETION, the name of the
    // parameter that must be completed to trigger the timer end.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  See above
    //
    endParameter = TheParameter
}
</pre>

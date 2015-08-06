Behaviour for adding and removing experimental parts.  Note that if a part is added using this behaviour, it will also be removed on contract failure/cancellation.  It will only be removed on normal contract completion if requested using the lockCriteria (see below).
<pre>
BEHAVIOUR
{
    name = ExperimentalPart
    type = ExperimentalPart

    // The name of the part to add/remove.
    //
    // Type:      <a href="AvailablePart-Type">AvailablePart</a>
    // Required:  Yes (multiples allowed)
    //
    part = largeSolarPanel
    part = cupola

    // When (or if) the part should be added as an experimental part.
    //
    // Type:      <a href="Enumeration-Type">ExperimentalPart.UnlockCriteria</a>
    // Required:  No (defaulted)
    // Values:
    //     DO_NOT_UNLOCK
    //     CONTRACT_ACCEPTANCE (default)
    //     CONTRACT_COMPLETION
    //     PARAMETER_COMPLETION
    //
    unlockCriteria = CONTRACT_ACCEPTANCE

    // If the unlockCriteria is set to PARAMETER_COMPLETION, the name of the
    // parameter that must be completed to trigger the part unlock.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  See above
    //
    unlockParameter = TheParameter

    // When (or if) the part should be removed as an experimental part.
    //
    // Type:      <a href="Enumeration-Type">ExperimentalPart.LockCriteria</a>
    // Required:  No (defaulted)
    // Values:
    //     DO_NOT_LOCK
    //     CONTRACT_ACCEPTANCE
    //     CONTRACT_COMPLETION (default)
    //     PARAMETER_COMPLETION
    //
    lockCriteria = CONTRACT_ACCEPTANCE

    // If the lockCriteria is set to PARAMETER_COMPLETION, the name of the
    // parameter that must be completed to trigger the part lock.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  See above
    //
    lockParameter = TheParameter
}
</pre>

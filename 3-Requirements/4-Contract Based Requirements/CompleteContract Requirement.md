Requirement for having a certain number of contracts completed of the given type.

<pre>
REQUIREMENT
{
    name = CompleteContract
    type = CompleteContract

    // The type of contract being checked.  This can either be a
    // ContractConfigurator contract type or a standard contract type (class).
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Yes
    //
    contractType = SimpleTestContract

    // The minimum number of times the given contract type must have been
    // completed before the requirement is met.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   1
    //
    minCount = 1

    // The maximum number of times the given contract type can be completed
    // before the requirement will no longer be met.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   int.MaxValue
    //
    maxCount = 5

    // The amount of time after the last instance of the contract was
    // complete before we can attempt again. Can specify
    // values in years (y), days (d), hours (h), minutes (m), seconds (s)
    // or any combination of those.
    //
    // Type:      <a href="Duration-Type">Duration</a>
    // Required:  No
    //
    cooldownDuration = 10d
}
</pre>

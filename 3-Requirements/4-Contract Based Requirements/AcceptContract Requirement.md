Requirement for having a certain number of contracts accepted of the given type.

<pre>
REQUIREMENT
{
    name = AcceptContract
    type = AcceptContract

    // The type of contract being checked.  This can either be a
    // ContractConfigurator contract type or a standard contract type (class).
    //
    // Type:      string
    // Required:  Yes
    //
    contractType = SimpleTestContract

    // The minimum number of times the given contract type must have been
    // accepted before the requirement is met.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   1
    //
    minCount = 1

    // The maximum number of times the given contract type can be accepted
    // before the requirement will no longer be met.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   int.MaxValue
    //
    maxCount = 5
}
</pre>

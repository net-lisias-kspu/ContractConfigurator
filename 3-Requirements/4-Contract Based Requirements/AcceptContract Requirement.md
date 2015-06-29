Requirement for having a certain number of contracts accepted of the given type.

    REQUIREMENT
    {
        name = AcceptContract
        type = AcceptContract

        // The type of contract being checked.  This can either be a
        // ContractConfigurator contract type or a standard contract type (class).
        contractType = SimpleTestContract

        // The minimum number of times the given contract type must have been
        // accpted before the requirement is met.
        // Default = 1
        minCount = 1

        // The maximum number of times the given contract type can be accepted
        // before the requirement will no longer be met.
        // Default = Infinite
        maxCount = 5
    }

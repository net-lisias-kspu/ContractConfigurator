Requirement for having a certain number of contracts completed of the given type.

    REQUIREMENT
    {
        name = CompleteContract
        type = CompleteContract

        // The type of contract being checked.  This can either be a
        // ContractConfigurator contract type or a standard contract type (class).
        contractType = SimpleTestContract

        // The minimum number of times the given contract type must have been
        // completed before the requirement is met.
        // Default = 1
        minCount = 1

        // The maximum number of times the given contract type can be completed
        // before the requirement will no longer be met.
        // Default = Infinite
        maxCount = 5

        // The amount of time after the last instance of the contract was
        // complete before we can attempt again. Can specify
        // values in years (y), days (d), hours (h), minutes (m), seconds (s)
        // or any combination of those.
        cooldownDuration = 10d
    }

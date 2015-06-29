Requirement that checks whether the player has enough (or not too much) funds.

    REQUIREMENT
    {
        name = Funds
        type = Funds

        // Minimum amount of funds the player must have before this contract
        // can show up.
        // Default = 0.0
        minFunds = 100000

        // Maximum amount of funds the player can have before this contract
        // no longer shows up.
        // Default = double.MaxValue
        maxFunds = 1000000
    }

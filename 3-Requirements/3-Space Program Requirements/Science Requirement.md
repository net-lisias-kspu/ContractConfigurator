Requirement that checks whether the player has enough (or not too much) science.

    REQUIREMENT
    {
        name = Science
        type = Science

        // Minimum amount of science the player must have before this contract
        // can show up.
        // Default = 0.0
        minScience = 100

        // Maximum amount of science the player can have before this contract
        // no longer shows up.
        // Default = float.MaxValue
        maxScience = 10000
    }

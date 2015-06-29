Behaviour for adding and removing experimental parts.

    BEHAVIOUR
    {
        name = ExperimentalPart
        type = ExperimentalPart

        // The name of the part to add/remove.  Can be specified multiple
        // times.
        part = largeSolarPanel
        part = cupola

        // Whether the part should be added as an experimental part (when the
        // contract is accepted).  Also controls whether the part is removed
        // if the contract fails or is withdrawn.
        // Default = True
        add = True

        // Whether the part should be removed as an experimental part (when the
        // contract completes successfully).
        // Default = True
        remove = True
    }

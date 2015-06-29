Parameter to provide validation over a vessel's parts.  The PartValidation module can be used in two different modes - simple and extende.  In the simple mode, simply provide the parameters to filter on, as in the following example:

    PARAMETER
    {
        name = PartValidation
        type = PartValidation

        // The name of the part to check for.  Optional.
        part = mk1pod

        // PartModule(s) to check for.  Optional, and can be specified multiple times.
        partModule = ModuleReactionWheel
        partModule = ModuleSAS

        // Part manufacturer to check for.  Optional.
        manufacturer = Kerbodyne

        // Part category to check for.  Optional.
        // List of valid values from PartCategories:
        //   Aero
        //   Control
        //   Engine
        //   FuelTank
        //   Pods
        //   Science
        //   Structural
        //   Utility
        category = Engine

        // Minimum count, default = 1
        minCount = 1

        // Maximum count, default = int.MAXVALUE
        maxCount = 10

        // Text to use for the parameter
        // Default (maxCount = 0) = Part: <attributes>: None
        // Default (maxCount = int.MAXVALUE) = Part: <attributes>: At least <minCount>
        // Default (minCount = 0) = Part: <attributes>: At most <maxCount>
        // Default (minCount = maxCount ) = Part: <attributes>: Exactly <minCount>
        // Default (else) = Part: <attributes>: Between <minCount> and <maxCount>
        //title =
    }

For the extended mode, parameters may be group into three types of nodes FILTER, VALIDATE_ALL and NONE.  The blocks are applied in order.  Typically, the FILTER blocks should be placed first.
* FILTER - This will filter the list of parts down to the ones that match the given criteria.
* VALIDATE_ALL - All remaining parts (after filtering) must match the given criteria.
* NONE - None of the remaining parts (after filtering) should match the given criteria.
* VALIDATE - Some of the remaining parts must match (only supports part, minCount and maxCount)

The blocks can contain any of the attributes listed in the simple model, **except** minCount, maxCount and title.

*Examples:*

This validates that all engines must be manufactured by Rockomax, and there must be at least two of them.

    PARAMETER
    {
        name = PartValidation4
        type = PartValidation

        FILTER
        {
            category = Engine
        }

        VALIDATE_ALL
        {
            manufacturer = Rockomax
        }

        minCount = 2
    }

This verifies that all parts that have a reaction wheel must not also have a SAS and must not be manufactured by Nightingale Engineering.

    PARAMETER
    {
        name = PartValidation
        type = PartValidation

        FILTER
        {
            partModule = ModuleReactionWheel
        }

        NONE
        {
            partModule = ModuleSAS
            manufacturer = Nightingale Engineering
        }
    }

This verifies that the listed parts in the given quantities are present.

    PARAMETER
    {
        name = PartValidation
        type = PartValidation

        VALIDATE
        {
            part = fuelTank3-2
            minCount = 1
        }

        VALIDATE
        {
            part = largeSolarPanel
            minCount = 4
        }

        VALIDATE
        {
            part = cupola
            minCount = 2
            maxCount = 2
        }
    }

Parameter to provide validation over a vessel's parts.  The PartValidation module can be used in two different modes - simple and extende.  In the simple mode, simply provide the parameters to filter on, as in the following example:

<pre>
PARAMETER
{
    name = PartValidation
    type = PartValidation

    // The name of the part to check for.
    //
    // Type:      AvailablePart
    // Required:  No
    //
    part = mk1pod

    // PartModule(s) to check for.
    //
    // Type:      string
    // Required:  No (multiples allowed)
    //
    partModule = ModuleReactionWheel
    partModule = ModuleSAS

    // Part manufacturer to check for.
    //
    // Type:      string
    // Required:  No
    //
    manufacturer = Kerbodyne

    // Part category to check for.
    //
    // Type:      PartCategories
    // Required:  No
    // Values:
    //   Aero
    //   Control
    //   Engine
    //   FuelTank
    //   Pods
    //   Science
    //   Structural
    //   Utility
    //
    category = Engine

    // Minimum and maximum count of matching parts.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   1 (minCount)
    //            int.MaxValue (maxCount)
    //
    minCount = 1
    maxCount = 10

    // Text to use for the parameter
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default (maxCount: 0) = Part: <attributes>: None
    // Default (maxCount: int.MAXVALUE) = Part: <attributes>: At least <minCount>
    // Default (minCount: 0) = Part: <attributes>: At most <maxCount>
    // Default (minCount: maxCount ) = Part: <attributes>: Exactly <minCount>
    // Default (else): Part: <attributes>: Between <minCount> and <maxCount>
    //
    //title =
}
</pre>

For the extended mode, parameters may be group into three types of nodes FILTER, VALIDATE_ALL and NONE.  The blocks are applied in order.  Typically, the FILTER blocks should be placed first.
* FILTER - This will filter the list of parts down to the ones that match the given criteria.
* VALIDATE_ALL - All remaining parts (after filtering) must match the given criteria.
* NONE - None of the remaining parts (after filtering) should match the given criteria.
* VALIDATE - Some of the remaining parts must match (only supports part, minCount and maxCount)

The blocks can contain any of the attributes listed in the simple model, **except** minCount, maxCount and title.

*Examples:*

This validates that all engines must be manufactured by Rockomax, and there must be at least two of them.

<pre>
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
</pre>

This verifies that all parts that have a reaction wheel must not also have a SAS and must not be manufactured by Nightingale Engineering.

<pre>
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
</pre>

This verifies that the listed parts in the given quantities are present.

<pre>
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
</pre>

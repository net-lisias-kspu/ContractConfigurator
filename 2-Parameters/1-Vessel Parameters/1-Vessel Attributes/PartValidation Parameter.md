Parameter to provide validation over a vessel's parts.  The PartValidation module can be used in two different modes - simple and extended.  In the simple mode, simply provide the parameters to filter on, as in the following example:

<pre>
PARAMETER
{
    name = PartValidation
    type = PartValidation

    // The name of the part to check for.  If multiple are specified, will
    // match on <strong>ANY</strong> of the parts listed.
    //
    // Type:      <a href="AvailablePart-Type">AvailablePart</a>
    // Required:  No (multiples allowed)
    //
    part = mk1pod
    part = mk1-2pod

    // PartModule(s) to check for.  If multiple are specified, requires that
    // the given parts have <strong>ALL</strong> the partModules listed.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (multiples allowed)
    //
    partModule = ModuleReactionWheel
    partModule = ModuleSAS

    // Type of PartModule to check for.  Similar to partModule, but more
    // generic.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (multiples allowed)
    // Values (defined in <a href="https://kerbalspaceprogram.com/api/class_fine_print_1_1_contract_defs.html">ContractDefs</a>):
    //     Antenna
    //     Battery
    //     Dock
    //     Generator
    //     Grapple
    //     Wheel
    partModuleType = Antenna

    // Extended PartModule check.  This is used to look for very specific part
    // module attributes.  The MODULE node may contain any attribute, and those
    // attributes will be matched against the part modules in the parts.
    //
    // Required:  No (multiples allowed)
    //
    MODULE
    {
        name = ModuleScienceExperiment
        experimentID = mysteryGoo
    }

    // Part manufacturer to check for.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No
    //
    manufacturer = Kerbodyne

    // Part category to check for.
    //
    // Type:      <a href="Enumeration-Type">PartCategories</a>
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
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   1 (minCount)
    //            int.MaxValue (maxCount)
    //
    minCount = 1
    maxCount = 10

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default (maxCount: 0) = Part: &lt;attributes&gt;: None
    // Default (maxCount: int.MAXVALUE) = Part: &lt;attributes&gt;: At least &lt;minCount&gt;
    // Default (minCount: 0) = Part: &lt;attributes&gt;: At most &lt;maxCount&gt;
    // Default (minCount: maxCount ) = Part: &lt;attributes&gt;: Exactly &lt;minCount&gt;
    // Default (else): Part: &lt;attributes&gt;: Between &lt;minCount&gt; and &lt;maxCount&gt;
    //
    //title =
}
</pre>

For the extended mode, parameters may be grouped into found types of nodes: FILTER, VALIDATE_ALL, VALIDATE and NONE.  The blocks are applied in order.  Typically, the FILTER blocks should be placed first.
* FILTER - This will filter the list of parts down to the ones that match the given criteria.
* VALIDATE_ALL - All remaining parts (after filtering) must match the given criteria.
* NONE - None of the remaining parts (after filtering) should match the given criteria.
* VALIDATE - Some of the remaining parts must match (only supports part, minCount and maxCount)

The FILTER, VALIDATE_ALL and NONE blocks can contain any of the attributes listed in the simple model, **except** minCount, maxCount and title.  THe VALIDATE block can only contain part, minCount and maxCount.

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

The makes sure that the vessel has at least one part that has the mystery goo experiment module (which could be through the stock mystery goo canister or a modded part adding the mystery goo experiment.

<pre>
PARAMETER
{
    name = PartValidation8
    type = PartValidation

    FILTER
    {
        MODULE
        {
            name = ModuleScienceExperiment
            experimentID = mysteryGoo
        }
    }

    minCount = 1
}
</pre>

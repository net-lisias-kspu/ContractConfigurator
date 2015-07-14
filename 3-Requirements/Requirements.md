## The REQUIREMENT node

The REQUIREMENT node defines a contract requirement - the pre-requisites that are required for the contract to be offered.

Requirements all follow the same general structure - the following attributes are available for all requirements:

<pre>
REQUIREMENT
{
    // The requirement name is not used, but should be provided to allow
    // for the possibility of other mods modifying contracts via
    // ModuleManager.
    name = Requirement

    // The type defines the type of Requirement.  See below for a list of
    // all supported ContractConfigurator requirements.
    type = ReachSpace

    // The invertRequirement is a logical NOT.  In this example, the
    // requirement becomes that the player must not yet have reached space.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   false
    //
    invertRequirement = true

    // Most requirements are not checked for active contracts (to
    // prevent the contract from being withdrawn while the player is
    // actively working to complete it).  Use this to change that
    // behaviour.  Note in some cases it's a lot nicer to do that
    // as a PARAMETER so the player knows what's required of them.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   (dependent on requirement)
    //
    checkOnActiveContract = true
}
</pre>

The requirements listed in the navigation pane to the right are natively supported by ContractConfigurator.

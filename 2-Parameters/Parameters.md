## The PARAMETER node

The PARAMETER node defines a contract parameter - what needs to be accomplished to successfully complete the contract.

Parameters all follow the same general structure - the following attributes are available for all parameters:

<pre>
PARAMETER
{
    // The parameter name is not used, but should be provided to allow for
    // the possibility of other mods modifying contracts via ModuleManager.
    name = Param1

    // The type defines the type of Parameter.  See below for all supported
    // ContractConfigurator parameters.
    type = ReachState

    // Target body, defaulted from the contract if not supplied.  Many
    // parameters use this in some way, but even if not explicitly used it will
    // add multipliers for the reward amounts below.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // The various parameter-level rewards and penalties.
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No
    //
    rewardScience = 100.0
    rewardReputation = 20.0
    rewardFunds = 100000.0
    failureReputation = 10.0
    failureFunds = 10000.0

    // When the parameter's state changes to completed or failed, disable
    // the parameter.  Use a value of false if you are trying to make
    // something behave like the Squad part test contract.  Example, if the
    // parameter says you need to be between 1000 and 2000 meters altitude
    // then setting this to false will make the parameter go back to
    // incomplete if you enter and leave the altitude window.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No
    // Default:   (differs per parameter)
    //
    disableOnStateChange = true

    // Parameter level notes that may be supplied.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No
    //
    notes = These are the notes.

    // The completedMessage is the message that is displayed when the
    // parameter completes.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No
    //
    completedMessage = You have done the thing.

    // Optional parameters do not need to be completed.  This can be used to
    // set up bonus rewards for doing extra things beyond the main goal of the
    // contract.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   false
    //
    optional = true

    // Indicates that this parameter needs to be complete "in sequence".
    // All parameters that are before this parameter in the list (and at
    // the same level) must be completed before this parameter is allowed
    // to complete.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   false
    //
    completeInSequence = true

    // Causes the parameter to be hidden.  Typically used for a parameter
    // that isn't meant to be part of the contract but is instead used to
    // trigger a behaviour.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   false
    //
    hidden = true

    // Causes children of the parameter to be hidden.
    // Use with caution - as hiding the child parameters may in some
    // cases make it more difficult for players to know what to do.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   false
    //
    hideChildren = true
}
</pre>

Some parameters can have child parameters.  This is only supported for certain parameters, and the details of what the child parameters do is documented on those parameters:

    PARAMETER
    {
        name = Param1
        type = ParamWithChildren

        PARAMETER
        {
            ...
        }
    }

All parameters can have child requirements.  Child requirements control whether the particular parameter shows up in the contract.  Care must be taken when using this - all contracts must have at least one parameter.  See the [[requirements|Requirements]] page for details on the REQUIREMENT node.


    PARAMETER
    {
        name = Param1
        type = ParamWithRequirements

        REQUIREMENT
        {
            ...
        }
    }

Parameters support the ITERATOR construct, which allows a parameter to get duplicated for every value in a list.

    PARAMETER
    {
        type = ReachState

        ITERATOR
        {
            type = Biome
            biome = @/biomes
        }
    }

For more details on the ITERATOR node, see the [[iterators|Iterators]] page.

The navigation bar on the right contains all the parameters natively supported by ContractConfigurator.

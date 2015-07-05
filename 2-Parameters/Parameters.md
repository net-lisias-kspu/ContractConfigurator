## The PARAMETER node

The PARAMETER node defines a contract parameter - what needs to be accomplished to successfully complete the contract.

Parameters all follow the same general structure - the following attributes are available for all parameters:

    PARAMETER
    {
        // The parameter name is not used, but should be provided to allow for
        // the possibility of other mods modifying contracts via ModuleManager.
        name = Param1

        // The type defines the type of Parameter.  See below for all supported
        // ContractConfigurator parameters.
        type = ReachState

        // Target celestial body.  Defaults to the targetBody of the contract.
        // For most  parameters this only has an impact on the reward/failure
        // amounts.
        targetBody = Kerbin

        // Parameter rewards
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
        // Default = <differs per parameter, see detailed documentation below>
        disableOnStateChange = true

        // Parameter level notes that may be supplied.
        notes = These are the notes.

        // The completedMessage is the message that is displayed when the
        // parameter completes.
        completedMessage = You have done the thing.

        // Optional parameters do not need to be completed (mainly for use with
        // composite parameters)
        optional = true

        // Indicates that this parameter needs to be complete "in sequence".
        // All parameters that are before this parameter in the list (and at
        // the same level) must be completed before this parameter is allowed
        // to complete.
        // Default = false
        completeInSequence = true

        // Causes children of the parameter to be hidden.
        // Use with caution - as hiding the child parameters may in some
        // cases make it more difficult for players to know what to do.
        hideChildren = true
    }

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

The navigation bar on the right contains all the parameters natively supported by ContractConfigurator.

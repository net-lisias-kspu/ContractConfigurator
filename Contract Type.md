## The CONTRACT_TYPE node

The CONTRACT_TYPE node is the main node for all ContractConfigurator contracts.  This node is what defines a contract that will be offered by ContractConfigurator.

Also see the detailed pages for the listing of all possible values for PARAMETER, REQUIREMENT and BEHAVIOUR nodes:
* [[Parameters|Parameters]]
* [[Requirements|Requirements]]
* [[Behaviours|Behaviours]]

_Sample CONTRACT_TYPE (can be downloaded [here](https://raw.githubusercontent.com/jrossignol/ContractConfigurator/master/test/SampleContract.cfg)):_

    // Each CONTRACT_TYPE node represents a type of contract that can be offered
    CONTRACT_TYPE
    {
        // Unique name of the contract type (required)
        name = SimpleTestContract

        // Contract title is displayed in the window in the corner, shoudl be short
        // and descritive
        title = Simple Test Contract

        // Two options for specifying the description:
        // 1) Supply the full text here in the description field
        //description = A more detailed description of the contract.

        // 2) Supply the following fields, which will be fed into the text
        //    generator.  Use of the CoherentContracts mod is highly recommended,
        //    as it generates far more meaningful text.
        topic = ContractConfigurator  // Topic of the contract.  Should be a
                                      // singular noun.
        subject = Kerbal              // Subject of the contract.  See
                                      // CoherentContracts for some possible values.
                                      // Includes stuff like Kerbal, Experiment,
                                      // Parts, Mun, MunSrf, etc.
        motivation = test             // Motivation for why we are doing the
                                      // contract.  See CoherentContracts for some
                                      // possible values.  Some values used are:
                                      // flags, test, rescue.

        // Contract notes are displayed in mission control.  Use it to give 
        // any special instructions.
        //
        // Optional
        notes = These are the contract level notes.

        // The contract synopsis appears in bold.  Give a quick summary of the
        // contract objective.
        synopsis = We want you to do a thing.

        // The completedMessage is the message that is displayed when the contract
        // completes.
        completedMessage = You have done the thing.

        // Agent (agency).  If not populated, a random agent will be selected.
        agent = Integrated Integrals

        // Contract min/max expiry in days.  Default is a contract that does not
        // expire.
        minExpiry = 500.0
        maxExpiry = 1000.0

        // Contract deadline in days.  Default is no deadline.
        deadline = 500

        // Controls for whether a contract can be declined or cancelled, default is
        // true for both
        cancellable = true
        declinable = true

        // Prestige.  If not specified, this contract type will be available at any
        // prestige level.  Otherwise, locked to the level specified.  Values from
        // Contract.ContractPrestige:
        //     Trivial
        //     Significant
        //     Exceptional
        prestige = Significant

        // Target Celestial body - controls where the contract must be completed,
        // has some automated effects on numeric values (increasing science, etc.).
        // Also gets used in some of the parameter classes.
        //
        // Default = null (no celestial body)
        targetBody = Kerbin

        // The maximum number of times this contract type can be completed (0 being
        // unlimited).
        // Default = 0
        maxCompletions = 3

        // The maximum instances of this contract that can be active at one time (0
        // being unlimited).
        // Default = 0
        maxSimultaneous = 1

        // Contract rewards
        rewardScience = 100.0
        rewardReputation = 20.0
        rewardFunds = 100000.0
        failureReputation = 10.0
        failureFunds = 10000.0
        advanceFunds = 10000.0

        // The weight is used in the contract generation process.  Each contract
        // type that is available to be offered is added to a weighted list.
        // Contract types with a higher value are more likely to be chosen.
        //
        // Default = 1.0
        weight = 10.0

        // The PARAMETER node defines a contract parameter.  The following parameter
        // displays all the fields that are supported for a parameter across all
        // types.  See the Parameters page for examples of all supported parameters.
        PARAMETER
        {
            // The parameter name is not used, but should be provided to allow for
            // the possibility of other mods modifying contracts via ModuleManager.
            name = Param1

            // The type defines the type of Parameter.  See below for all supported
            // ContractConfigurator parameters
            type = AltitudeRecord

            // This is a parameter specific to the AltituteRecord parameter type.
            // Each parameter type can have include its own custom fields.
            altitude = 45000

            // Target celestial body.  Defaults to the targetBody of the contract.
            // For most  parameters this only has an impacton the reward/failure
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
            // Default = true
            disableOnStateChange = true

            // Optional parameters do not need to be completed (mainly for use with
            // composite parameters)
            optional = true
        }

        REQUIREMENT
        {
            // The requirement name is not used, but should be provided to allow
            // for the possibility of other mods modifying contracts via
            // ModuleManager.
            name = Requirement1

            // The type defines the type of Requirement.  See the Requirements page
            // for all supported ContractConfigurator requirements.
            type = ReachSpace

            // The invertRequirement is a logical NOT.  In this example, the
            // requirement becomes that the player must not yet have reached space.
            //
            // Default = false
            invertRequirement = true

            // NEW!
            // Most requirements are not checked for active contracts (to
            // prevent the contract from being withdrawn while the player is
            // actively working to complete it).  Use this to change that
            // behaviour.  Note in some cases it's a lot nicer to do that
            // as a PARAMETER so the player knows what's required of them.
            //
            // Default = mostly false, true for a few requirements
            checkOnActiveContract = true
        }
    }

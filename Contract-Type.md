## Table of Contents

* [[Table of Contents|Contract-Type#table-of-contents]]
* [[The CONTRACT_TYPE node|Contract-Type#the-contract_type-node]]
* [[Contract Reward Modifiers|Contract-Type#contract-reward-modifiers]]

## The CONTRACT_TYPE node

The CONTRACT_TYPE node is the main node for all Contract Configurator contracts.  This node is what defines a contract that will be offered by Contract Configurator.

Also see the detailed pages for the listing of all possible values for PARAMETER, REQUIREMENT and BEHAVIOUR nodes:
* [[Parameters|Parameters]]
* [[Requirements|Requirements]]
* [[Behaviours|Behaviours]]

_Sample CONTRACT_TYPE (can be downloaded [here](https://raw.githubusercontent.com/jrossignol/ContractConfigurator/master/test/SampleContract.cfg)):_

    CONTRACT_TYPE
    {
        // Unique name of the contract type (required)
        name = SimpleTestContract

        // Contract title is displayed in the window in the corner, should be
        // short and descritive
        title = Simple Test Contract

        // Reference to a CONTRACT_GROUP node which supplies additional rules
        // for limiting the number of contracts within a given group.
        group = ContractGroup

        // Two options for specifying the description:
        // 1) Supply the full text here in the description field
        //description = A more detailed description of the contract.

        // 2) Supply the following fields, which will be fed into the text
        //    generator.  Use of the CoherentContracts mod is highly
        //    recommended, as it generates far more meaningful text.
        topic = Contract Configurator // Topic of the contract.  Should be a
                                      // singular noun.
        subject = Kerbal              // Subject of the contract.  See
                                      // CoherentContracts for some possible
                                      // values.  Includes stuff like Kerbal,
                                      // Experiment, Parts, Mun, MunSrf, etc.
        motivation = test             // Motivation for why we are doing the
                                      // contract.  See CoherentContracts for
                                      // some possible values.  Some values
                                      // used are: flags, test, rescue.

        // Contract notes are displayed in mission control.  Use it to give 
        // any special instructions.
        //
        // Optional
        notes = These are the contract level notes.

        // The contract synopsis appears in bold.  Give a quick summary of the
        // contract objective.
        synopsis = We want you to do a thing.

        // The completedMessage is the message that is displayed when the
        // contract completes.
        completedMessage = You have done the thing.

        // Agent (agency).  If not populated, a random agent will be selected.
        agent = Integrated Integrals

        // Contract min/max expiry in days.  If both are set to 0.0, it will
        // result in a contract that never expires.
        // Default = 1.0 and 7.0 days, respectively
        minExpiry = 500.0
        maxExpiry = 1000.0

        // Contract deadline in days.  Default is no deadline.
        deadline = 500

        // Controls for whether a contract can be declined or cancelled, default
        // is true for both
        cancellable = true
        declinable = true

        // Prestige.  If not specified, this contract type will be available at
        // any prestige level.  Otherwise, locked to the level specified.  Can
        // be specified multiple times.
        // Values from Contract.ContractPrestige:
        //     Trivial
        //     Significant
        //     Exceptional
        prestige = Significant

        // Target Celestial body - controls where the contract must be
        // completed, has some automated effects on numeric values (increasing
        // science, etc.).  Also gets used in some of the parameter classes.
        //
        // Default = null (no celestial body)
        targetBody = Kerbin

        // The maximum number of times this contract type can be completed (0
        // being unlimited).
        // Default = 0
        maxCompletions = 3

        // The maximum instances of this contract that can be active at one
        // time (0 being unlimited).
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

        // The PARAMETER node defines a contract parameter.  The following
        // shows an example parameter.  See the Parameters page for examples of
        // all supported parameters.
        PARAMETER
        {
            name = AltitudeRecord1

            // The type defines the type of Parameter.  See the Parameters page
            // for a list of all supported Contract Configurator parameters
            type = AltitudeRecord

            // This is a parameter specific to the AltituteRecord parameter
            // type.  Each parameter type can have include its own custom
            // fields.
            altitude = 45000
        }

        // The PARAMETER node defines a contract requirement - a prerequisite
        // that needs to be met before the contract can be offered.  The
        // following shows an example requirement.  See the Requirements page
        // for examples of all supported requirements.
        REQUIREMENT
        {
            name = ReachSpace1

            // The type defines the type of Requirement.  See the Requirements
            // page for all supported Contract Configurator requirements.
            type = ReachSpace
        }

        // The BEHAVIOUR node adds additional special contract level behaviour.
        // See the Behaviours page for examples of all supported behaviours.
        BEHAVIOUR
        {
            name = Behaviour1

            // The type defines the type of Behaviour.  See the Behaviours page
            // for all supported Contract Configurator behaviours.
            type = Behaviour
        }
    }

## Contract Reward Modifiers

Thanks to DMagic - these values are pulled from [this forum post] (http://forum.kerbalspaceprogram.com/showthread.php?p=1315411#post1315411).

Contract rewards, advances, and penalties are all affected by a multiplier which is dependent on both the contract prestige and the celestial body.  The multipliers are

Body | Multiplier
--- | ---:
*Sun* | 4.0
&nbsp;&nbsp;**Moho** | 7.0
&nbsp;&nbsp;**Eve** | 5.0
&nbsp;&nbsp;&nbsp;&nbsp;Gilly | 6.0
&nbsp;&nbsp;**Kerbin** | 1.0
&nbsp;&nbsp;&nbsp;&nbsp;Mun | 2.0
&nbsp;&nbsp;&nbsp;&nbsp;Minmus | 2.0
&nbsp;&nbsp;**Duna** | 5.0
&nbsp;&nbsp;&nbsp;&nbsp;Ike | 5.0
&nbsp;&nbsp;**Jool** | 6.0
&nbsp;&nbsp;&nbsp;&nbsp;Laythe | 8.0
&nbsp;&nbsp;&nbsp;&nbsp;Vall | 8.0
&nbsp;&nbsp;&nbsp;&nbsp;Bop | 8.0
&nbsp;&nbsp;&nbsp;&nbsp;Tylo | 8.0
&nbsp;&nbsp;&nbsp;&nbsp;Pol | 8.0
&nbsp;&nbsp;**Dres** | 6.0
&nbsp;&nbsp;**Eeloo** | 10.0

Prestige | Multiplier
--- | ---:
Trivial | 1.00
Significant | 1.25
Exceptional | 1.50
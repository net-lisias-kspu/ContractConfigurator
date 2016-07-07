## Table of Contents

* [[Table of Contents|Contract-Type#table-of-contents]]
* [[The CONTRACT_TYPE node|Contract-Type#the-contract_type-node]]
* [[Contract Reward Modifiers|Contract-Type#contract-reward-modifiers]]

## The CONTRACT_TYPE node

The CONTRACT_TYPE node is the main node for all Contract Configurator contracts.  This node is what defines a contract that will be offered by Contract Configurator.

Also see the detailed pages for the listing of all possible values for DATA, PARAMETER, REQUIREMENT and BEHAVIOUR nodes:
* [[Data Node|Data-Node]]
* [[Parameters|Parameters]]
* [[Requirements|Requirements]]
* [[Behaviours|Behaviours]]

_Sample CONTRACT_TYPE (can be downloaded [here](https://raw.githubusercontent.com/jrossignol/ContractConfigurator/master/test/SampleContract.cfg)):_

    CONTRACT_TYPE
    {
        // Unique name of the contract type (required)
        name = SimpleTestContract

        // The title of the contract, which is displayed in Mission Control
        // when a player is selecting a mission.  Also gets displayed in the
        // contract app.
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        title = Simple Test Contract

        // Generic version of the contract title that is displayed in Mission
        // Control when no contract is currently generated.  This defaults to
        // the title, but only if it is deterministic (ie. the value can be
        // determined at parse time).
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes (unless can be defauled from title).
        //
        genericTitle = Simple Test Contract

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

        // Generic version of the contract description that is displayed in
        // Mission Control when no contract is currently generated.  This
        // defaults to the description, but only if it is deterministic (ie.
        // the value can be determined at parse time).
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes (unless can be defauled from description).
        //
        genericDescription = This is the generic description.

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

        // Agent (agency).  If not populated, the agent from the contract group
        // will be used.  If there is no group or no agent on the group, a
        // random agent will be selected.
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

        // When set to true, this contract is automatically accepted when
        // offered.  Use it to make a contract like the stock World-Firsts
        // Record contracts.
        // Default = false
        autoAccept = false

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
        // time.
        // Default = 4 (unless maxCompletions is set).
        maxSimultaneous = 1

        // Contract rewards.  Note that advanceFunds are automatically added to the
        // failureFunds.
        rewardScience = 100.0
        rewardReputation = 20.0
        rewardFunds = 100000.0
        failureReputation = 10.0
        failureFunds = 10000.0
        advanceFunds = 10000.0

        // The weight is used in the contract generation process.  Each contract
        // type that is available to be offered is added to a weighted list.
        // Contract types with a higher value are more likely to be chosen.
        // Note that the weight is applied per contract group.
        //
        // Default = 1.0
        weight = 10.0

        // The DATA node is a special node that is not used by contracts
        // or parameters directly, but provide storage for generic values
        // that can be used as part of expressions.
        DATA
        {
            type = Vessel
            targetVessel = AllVessels().Where(v => v.isOrbiting()).First()
        }

        // The PARAMETER node defines a contract parameter.  The following
        // shows an example parameter.  See the Parameters page for examples of
        // all supported parameters.
        PARAMETER
        {
            name = ReachState1

            // The type defines the type of Parameter.  See the Parameters page
            // for a list of all supported Contract Configurator parameters.
            type = ReachState

            // This is a parameter specific to the ReachState parameter type.
            // Each parameter type can have include its own custom fields.
            minAltitude = 45000
        }

        // The REQUIREMENT node defines a contract requirement - a prerequisite
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

<sub>[ [[Top|Contract-Type]] ] [ [[The CONTRACT_TYPE node|Contract-Type#the-contract_type-node]] ]</sub>

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

<sub>[ [[Top|Contract-Type]] ] [ [[Contract Reward Modifiers|Contract-Type#contract-reward-modifiers]] ]</sub>


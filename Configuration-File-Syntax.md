## The CONTRACT_TYPE node

The CONTRACT_TYPE node is the main node for all ContractConfigurator contracts.  This node is what defines a contract that will be offered by ContractConfigurator.

_Sample CONTRACT_TYPE:_

    // Each CONTRACT_TYPE node represents a type of contract that can be offered
    CONTRACT_TYPE
    {
        // Unique name of the contract type (required)
        name = SimpleTestContract

        // Contract text details
        title = Simple Test Contract
        description = A more detailed description of the contract.  This is where you come in.
        synopsis = We want you to do a thing.
        completedMessage = You have done the thing.

        // Agent (agency).  If not populated, a random agent will be selected.
        agent = Integrated Integrals

        // Contract min/max expiry in days.  Default is a contract that does not expire.
        minExpiry = 500.0
        maxExpiry = 1000.0

        // Contract deadline in days.  Default is no deadline.
        deadline = 500

        // Controls for whether a contract can be declined or cancelled, default is true for both
        cancellable = true
        declinable = true

        // Prestige.  If not specified, this contract type will be available at any prestige level.
        // Otherwise, locked to the level specified.  Values from Contract.ContractPrestige:
        //     Trivial
        //     Significant
        //     Exceptional
        prestige = Significant

        // Target Celestial body - controls where the contract must be completed, has some automated
        // effects on numeric values (increasing science, etc.).  Also gets used in some of the
        // parameter classes.
        //
        // Default = null (no celestial body)
        targetBody = Kerbin

        // The maximum number of times this contract type can be completed (0 being unlimited).
        // Default = 0
        maxCompletions = 3

        // The maximum instances of this contract that can be active at one time (0 being unlimited).
        // Default = 0
        maxSimultaneous = 1

        // Contract rewards
        rewardScience = 100.0
        rewardReputation = 20.0
        rewardFunds = 100000.0
        failureReputation = 10.0
        failureFunds = 10000.0
        advanceFunds = 10000.0

        // The PARAMETER node defines a contract parameter.  The following parameter displays all the
        // fields that are supported for a parameter across all types.  See the ParameterTestContract
        // for examples of all supported parameters.
        PARAMETER
        {
            // The parameter name is not used, but should be provided to allow for the possibility of
            // other mods modifying contracts via ModuleManager.
            name = Param1

            // The type defines the type of Parameter.  See below for all supported
            // ContractConfigurator parameters
            type = AltitudeRecord

            // This is a parameter specific to the AltituteRecord parameter type.  Each parameter type
            // can have include its own custom fields.
            altitude = 45000

            // Target celestial body.  Defaults to the targetBody of the contract.  For most
            // parameters this only has an impacton the reward/failure amounts
            targetBody = Kerbin

            // Parameter rewards
            rewardScience = 100.0
            rewardReputation = 20.0
            rewardFunds = 100000.0
            failureReputation = 10.0
            failureFunds = 10000.0

            // When the parameter's state changes to completed or failed, disable the parameter.  Use
            // a value of false if you are trying to make something behave like the Squad part test
            // contract.  Example, if the parameter says you need to be between 1000 and 2000 meters
            // altitude then setting this to false will make the parameter go back to incomplete if you
            // enter and leave the altitude window.
            //
            // Default = true
            disableOnStateChange = true

            // Optional parameters do not need to be completed (mainly for use with composite
            // parameters)
            optional = true
        }

        REQUIREMENT
        {
            // The requirement name is not used, but should be provided to allow for the possibility of
            // other mods modifying contracts via ModuleManager.
            name = Requirement1

            // The type defines the type of Requirement.  See below for all supported
            // ContractConfigurator requirements.
            type = ReachSpace

            // The invertRequirement is a logical NOT.  In this example, the requirement becomes that
            // the player must not yet have reached space.
            //
            // Default = false
            invertRequirement = true
        }
    }

## The PARAMETER node

The PARAMETER node defines a contract parameter - what needs to be accomplished to successfully complete the contract.

The following parameters are natively supported by ContractConfigurator:

* [[Vessel Parameters|Configuration-File-Syntax#vessel-parameters]]
 * [[ReachAltitudeEnvelope|Configuration-File-Syntax#reachaltitudeenvelope]]
 * [[ReachSpeedEnvelope|Configuration-File-Syntax#reachspeedenvelope]]
 * [[ReachBiome|Configuration-File-Syntax#reachbiome]]
 * [[ReachDestination|Configuration-File-Syntax#reachdestination]]
 * [[ReachSitutation|Configuration-File-Syntax#reachsitutation]]
* [[Kerbal Parameters|Configuration-File-Syntax#kerbal-parameters]]
 * [[BoardAnyVessel|Configuration-File-Syntax#boardanyvessel]]
 * [[RecoverKerkbal|Configuration-File-Syntax#recoverkerkbal]]
* [[Progression Parameters|Configuration-File-Syntax#progression-parameters]]
 * [[LaunchVessel|Configuration-File-Syntax#launchvessel]]
 * [[AltitudeRecord|Configuration-File-Syntax#altituderecord]]
 * [[ReachSpace|Configuration-File-Syntax#reachspace]]
 * [[EnterOrbit|Configuration-File-Syntax#enterorbit]]
 * [[EnterSOI|Configuration-File-Syntax#entersoi]]
 * [[LandOnBody|Configuration-File-Syntax#landonbody]]
* [[Negative Parameters|Configuration-File-Syntax#negative-parameters]]
 * [[KerbalDeaths|Configuration-File-Syntax#kerbaldeaths]]
* [[Set Parameters|Configuration-File-Syntax#set-parameters]]
 * [[Any|Configuration-File-Syntax#any]]
 * [[All|Configuration-File-Syntax#all]]
* [[Miscellaneous Parameters|Configuration-File-Syntax#miscellaneous-parameters]]
 * [[CollectScience|Configuration-File-Syntax#collectscience]]
 * [[PlantFlag|Configuration-File-Syntax#plantflag]]
 * [[PartTest|Configuration-File-Syntax#parttest]]

### Vessel Parameters
These are parameters that operator on vessels (manned or unmanned).

#### ReachAltitudeEnvelope
Get to a specific altitude envelope.  Note that this is not tied to a specific celestial body - to do that you need to use multiple parameters together (and set the disableOnStateChange flag to false).

    PARAMETER
    {
        name = ReachAltitudeEnvelope1
        type = ReachAltitudeEnvelope

        // Minimum and maximum altitudes, required
        minAltitude = 20000
        maxAltitude = 50000

        // Text to use for the parameter
        // Default = Altitude: Between <minAltitude> and <maxAltitude> meters
        //title =
    }

#### ReachSpeedEnvelope
Get to a specific speed envelope.  Note that this is not tied to a specific celestial body - to do that you need to use multiple parameters together (and set the disableOnStateChange flag to false).

    PARAMETER
    {
        name = ReachSpeedEnvelope1
        type = ReachSpeedEnvelope

        // Minimum and maximum speeds, required
        minSpeed = 1000
        maxSpeed = 5000

        // Text to use for the parameter
        // Default = Speed: Between <minSpeed> and <maxSpeed> m/s
        //title =
    }

#### ReachBiome
Reach a specific Biome.
*NOTE - I can't seem to get this one working!  If someone does get this to work for them, let me know.*

    PARAMETER
    {
        name = ReachBiome1
        type = ReachBiome

        // The name of the biome to reach.
        biome = Shores

        // Text for the contract parameter.  Note that the biome name is always
        // appended.
        //
        // Default = Biome: <biome>
        title = Relax on Kerbin's
    }

#### ReachDestination
Reach a specific celestial object.

    PARAMETER
    {
        name = ReachDestination1
        type = ReachDestination

        // This can be inherited from the the contract type if necessary
        targetBody = Duna

        // Text for the contract parameter.  The name of the target body is always
        // appended to this text (blame Squad!).
        // Default = Destination: <targetBody>
        //title =
    }

#### ReachSitutation
Reach a specific situation.

    PARAMETER
    {
        name = ReachSituation1
        type = ReachSituation

        // The situation.  Valid values from Vessel.Situations:
        //    DOCKED
        //    ESCAPING
        //    FLYING
        //    LANDED
        //    ORBITING
        //    PRELAUNCH
        //    SPLASHED
        //    SUB_ORBITAL
        situation = FLYING

        // Text for the contract parameter.  The name of the situation is always
        // appended to this text.
        // Default = Situation: <situation>
        //title =
    }

### Kerbal Parameters
These are parameters that operate on Kerbals.

#### BoardAnyVessel
The BoardAnyVessel parameter is met when the named Kerbal boards a vessel (this one is from the Squad "rescue" contracts and is a little bit less useful on its own.

    PARAMETER
    {
        name = BoardAnyVessel1
        type = BoardAnyVessel

        // The Kerbal that needs to board a vessel
        kerbal = Jebediah Kermin

        // Text to use for the parameter
        // Default = <kerbal>: Board a vessel
        //title =
    }

#### RecoverKerkbal
The RecoverKerbal parameter is met when the named Kerbal is "recovered" (ie. goes back in to the available list at the astronaut complex).  This is from the Squad "rescue" contracts.

    PARAMETER
    {
        name = RecoverKerbal1
        type = RecoverKerbal

        // The Kerbal to be recovered
        kerbal = Jebediah Kermin

        // Text to use for the parameter
        // Default = <kerbal>: Recovered
        //title =
    }

### Progression Parameters
Although not tied directly to the acheivement/progression system, these are paramters that are typically used for progression type rewards (do something for the first time).

#### LaunchVessel
To meet this parameter, the player simply needs to launch a vessel.

    PARAMETER
    {
        name = LaunchVessel1
        type = LaunchVessel
    }

#### AltitudeRecord
The AltituteRecord parameter is met when a craft reaches the given altitude on Kerbin.

    PARAMETER
    {
        name = AltitudeRecord1
        type = AltitudeRecord
        altitude = 55000
    }

#### ReachSpace
Go to space.

    PARAMETER
    {
        name = ReachSpace1
        type = ReachSpace
    }

#### EnterOrbit
The EnterOrbit parameter is met when a craft enters an orbit of the given celestial body.

    PARAMETER
    {
        name = EnterOrbit1
        type = EnterOrbit

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

#### EnterSOI
The EnterSOI parameter is met when a craft enters the sphere of influence of the given celestial body.

    PARAMETER
    {
        name = EnterSOI1
        type = EnterSOI

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

#### LandOnBody
The LandOnBody parameter is met when a craft lands on the given celestial body.

    PARAMETER
    {
        name = LandOnBody1
        type = LandOnBody

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

### Negative Parameters
These parameters are ones that give a failure condition to a contract.  Note that when the contract fails, the player can't re-attempt it (unless it's set up to be offered again after failure).

#### KerbalDeaths
The KerbalDeaths parameter _fails_ if more Kerbals than the countMax die.

    PARAMETER
    {
        name = KerbalDeaths1
        type = KerbalDeaths

        // Maximum Number of Kerbals that can die before this contract is considered
        // failed.
        //
        // Default = 0
        countMax = 1
    }

### Set Parameters
Set parameters are special - they do not typically do anything on their own, but work with their child parameters.  Many of them are best used with disableOnStateChange = false on the child parameters.

#### Any
The Any parameter is be completed if any one of its child parameters are completed.

    PARAMETER
    {
        name = Any1
        type = Any

        // The text to display.  Highly recommended that you do not use the default -
        // when the parameter is complete the text of the children disappears (and
        // the default text doesn't give the player a very good idea what the
        // parameter was about).
        //
        // Default - Complete any ONE of the following
        title = Do this or that

        // Child parameters look just like a regular parameter (and can be infinitely
        // nested)
        PARAMETER
        {
            name = ReachSpace1
            type = ReachSpace
        }

        PARAMETER
        {
            name = ReachSpeedEnvelope1
            type = ReachSpeedEnvelope

            minSpeed = 1000
            maxSpeed = 5000
        }
    }

#### All
The All parameter is completed once all its child parameters are completed.

    PARAMETER
    {
        name = All1
        type = All

        // The text to display.  Highly recommended that you do not use the default -
        // when the parameter is complete the text of the children disappears (and
        // the default text doesn't give the player a very good idea what the
        // parameter was about).
        //
        // Default - Complete ALL of the following
        title = Do these things

        // Child parameters look just like a regular parameter (and can be infinitely nested)
        PARAMETER
        {
            name = ReachAltitudeEnvelope1
            type = ReachAltitudeEnvelope

            disableOnStateChange = false

            minAltitude = 20000
            maxAltitude = 50000
        }

        PARAMETER
        {
            name = ReachSpeedEnvelope1
            type = ReachSpeedEnvelope

            disableOnStateChange = false

            minSpeed = 1000
            maxSpeed = 5000
        }
    }
}

### Miscellaneous Parameters

Other parameters that didn't fit in elsewhere.

#### CollectScience
The CollectScience parameter is met when science is sent home from the given location and celestial body.

    PARAMETER
    {
        name = CollectScience1
        type = CollectScience

        // This can be inherited from the the contract type if necessary
        targetBody = Duna

        // Valid values are "Surface" and "Space"
        location = Space
    }

#### PlantFlag
The PlantFlag parameter is met when planting a flag on the given body.

    PARAMETER
    {
        name = PlantFlag1
        type = PlantFlag

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

#### PartTest
PartTest is for testing parts (or just activating them, for staged parts).  This parameter supports child parameters - you will only be able to complete the part test if all child parameters are also completed.

    PARAMETER
    {
        name = PartTest1
        type = PartTest

        // The Kerbal to be recovered
        part = SmallGearBay

        // Additional notes to display (in the Squad PartTest contract, this is where they say
        // "Activate through the staging system", etc.
        // Optional
        notes = Test this part anywhere, no other requirements!
    }

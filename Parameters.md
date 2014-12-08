## The PARAMETER node

The PARAMETER node defines a contract parameter - what needs to be accomplished to successfully complete the contract.

The following parameters are natively supported by ContractConfigurator:

* [[Vessel Parameters|Parameters#vessel-parameters]]
 * [[VesselParameterGroup|Parameters#vesselparametergroup]]
 * [[HasCrew|Parameters#hascrew]]
 * [[HasPart|Parameters#haspart]]
 * [[ReachAltitudeEnvelope|Parameters#reachaltitudeenvelope]]
 * [[ReachSpeedEnvelope|Parameters#reachspeedenvelope]]
 * [[ReachBiome|Parameters#reachbiome]]
 * [[ReachDestination|Parameters#reachdestination]]
 * [[ReachSitutation|Parameters#reachsitutation]]
 * [[ReturnHome|Parameters#returnhome]]
 * [[VesselHasVisited|Parameters#vesselhasvisited]]
* [[Kerbal Parameters|Parameters#kerbal-parameters]]
 * [[BoardAnyVessel|Parameters#boardanyvessel]]
 * [[RecoverKerkbal|Parameters#recoverkerkbal]]
* [[Progression Parameters|Parameters#progression-parameters]]
 * [[LaunchVessel|Parameters#launchvessel]]
 * [[AltitudeRecord|Parameters#altituderecord]]
 * [[ReachSpace|Parameters#reachspace]]
 * [[EnterOrbit|Parameters#enterorbit]]
 * [[EnterSOI|Parameters#entersoi]]
 * [[LandOnBody|Parameters#landonbody]]
* [[Negative Parameters|Parameters#negative-parameters]]
 * [[KerbalDeaths|Parameters#kerbaldeaths]]
* [[Set Parameters|Parameters#set-parameters]]
 * [[Any|Parameters#any]]
 * [[All|Parameters#all]]
* [[Miscellaneous Parameters|Parameters#miscellaneous-parameters]]
 * [[CollectScience|Parameters#collectscience]]
 * [[PlantFlag|Parameters#plantflag]]
 * [[PartTest|Parameters#parttest]]

### Vessel Parameters
These are parameters that operator on vessels (manned or unmanned).

#### VesselParameterGroup
**_NEW!_** The VesselParameterGroup parameter is used to group several child vessel parameters together.  It can also be used to specify a duration for which the parameters must be true, and will track across non-active vessels.  Note that when not used with a VesselParameterGroup parent parameter, the other vessel parameters on this page will only work with the active vessel.

    PARAMETER
    {
        name = VesselParameterGroup1
        type = VesselParameterGroup

        // The title text to display.
        // Default - Vessel: Any; Duration: <duration>
        // Note in future this will be expanded to support setting the parameters to
        // be for a specific vessel
        //title = 

        // The duration that the conditions must be satisfied for.  Can specify
        // values in years (y), days (d), hours (h), minutes (m), seconds (s) or
        // any combination of those.
        duration = 10d 2h

        // Examples of typical child parameters used with VesselParameterGroup
        PARAMETER
        {
            name = ReachSituation1
            type = ReachSituation

            disableOnStateChange = false

            situation = ORBITING
        }

        PARAMETER
        {
            name = ReachDestination1
            type = ReachDestination

            disableOnStateChange = false

            targetBody = Kerbin
        }

        PARAMETER
        {
            name = HasCrew1
            type = HasCrew

            disableOnStateChange = false
        }
    }

#### HasCrew
**_NEW!_** Parameter to indicate that the Vessel in question must have a certain number of crew members (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasCrew1
        type = HasCrew

        // Minimum crew count, default = 1
        minCrew = 1

        // Maximum crew count, default = int.MAXVALUE
        maxCrew = 10

        // Text to use for the parameter
        // Default (maxCrew = 0) = Crew: Unmanned
        // Default (maxCrew = int.MAXVALUE) = Crew: At least <minCrew> Kerbals
        // Default (minCrew = 0) = Crew: At most <maxCrew> Kerbals
        // Default (minCrew = maxCrew) = Crew: Exactly <minCrew> Kerbals
        // Default (else) = Crew: Between <minCrew> and <maxCrew> Kerbals
        //title =
    }

#### HasPart
**_NEW!_** Parameter to indicate that the Vessel in question must have a certain number of a certain part (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasPart1
        type = HasPart

        // The name of the part to check for
        part = mk1pod

        // Minimum count, default = 1
        minCount = 1

        // Maximum count, default = int.MAXVALUE
        maxCount = 10

        // Text to use for the parameter
        // Default (maxCount = 0) = <part>: None
        // Default (maxCount = int.MAXVALUE) = <part>: At least <minCount>
        // Default (minCount = 0) = <part>: At most <maxCount>
        // Default (minCount = maxCount ) = <part>: Exactly <minCount>
        // Default (else) = <part>: Between <minCount> and <maxCount>
        //title =
    }

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

    PARAMETER
    {
        name = ReachBiome1
        type = ReachBiome

        // The name of the biome to reach.
        biome = Shores

        // Text for the contract parameter.
        // Default = Biome: <biome>
        title = Relax on Kerbin's Shores
    }

#### ReachDestination
Reach a specific celestial object.

    PARAMETER
    {
        name = ReachDestination1
        type = ReachDestination

        // This can be inherited from the the contract type if necessary
        targetBody = Duna

        // Text for the contract parameter.
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

        // Text for the contract parameter.
        // Default = Situation: <situation>
        //title =
    }

#### ReturnHome
**_NEW!_** The ReturnHome parameter requires a player to return home (ideally after meeting their other contract objectives).

    PARAMETER
    {
        name = ReturnHome1
        type = ReturnHome

        // Text for the contract parameter.
        // Default = Return home.
        //title = 
    }

#### VesselHasVisited
**_NEW!_** The VesselHasVisited parameter requires a player to go to visit a celestial body under specific circumstances.

    PARAMETER
    {
        name = VesselHasVisited1
        type = VesselHasVisited

        // The target to visit.  If not specified will defaulted from the contract.
        targetBody = Mun

        // The situation.  Valid values from KSPAchievements.ReturnFrom
        //    Flight
        //    FlyBy
        //    Orbit
        //    SubOrbit
        //    Surface
        situation = Surface

        // Text for the contract parameter.
        // Default = Perform <situation> on <targetBody>.
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

        // Child parameters look just like a regular parameter (and can be infinitely
        // nested)
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

        // Additional notes to display (in the Squad PartTest contract, this is where
        // they say "Activate through the staging system", etc.
        // Optional
        notes = Test this part anywhere, no other requirements!
    }
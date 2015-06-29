#### Vessel History
These parameters pertain to the history of a vessel.

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel History|Parameters#vessel-history]] ]</sub>

##### CollectScience
The CollectScience parameter is used to require a player to collect science under specific circumstances.  It also supports settings to require the player to either transmit or recover the data.

    PARAMETER
    {
        name = CollectScience
        type = CollectScience

        // Defaulted from the contract type if not provided
        targetBody = Duna

        // (Optional) Specifies the biome for which science should be collected.
        // This can be any biome that is valid for the target body, but note that
        // it is not currently validated.
        biome = Craters

        // (Optional) Specifies the situation under which science should be
        // collected.
        // Valid values are:
        //    SrfLanded
        //    SrfSplashed
        //    FlyingLow
        //    FlyingHigh
        //    InSpaceLow
        //    InSpaceHigh
        situation = SrfLanded

        // (Optional) Specifies where the experiment should take place.
        // Valid values are "Surface" and "Space"
        location = Space

        // (Optional) Specifies the experiment to be run, can be any valid
        // experiment in stock KSP or added by mods.  This can be specified
        // multiple times.  The stock list is:
        //    asteroidSample
        //    crewReport
        //    evaReport
        //    mysteryGoo
        //    surfaceSample
        //    mobileMaterialsLab
        //    temperatureScan
        //    barometerScan
        //    seismicScan
        //    gravityScan
        //    atmosphereAnalysis
        experiment = evaReport

        // (Optional) Specifies the subject that should be run.  This can be
        // used in place of the biome/situation/experiment (it contains the
        // same information).  It is recommened to only use this with
        // expressions, rather than adding the subject manually.  This can be
        // specified multiple times.
        subject = evaReport@MunSrfLandedCraters


        // (Optional) The method for which the science must be recovered.
        // Defaults to None if not specified.  Note the Ideal recovery method
        // is special - it will automatically change to either Recover or
        // RecoverOrTransmit, depending whether the experiment can have all its
        // science recovered through transmission.
        // Valid values are:
        //    None
        //    Recover
        //    Transmit
        //    RecoverOrTransmit
        //    Ideal
        recoveryMethod = Recover
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel History|Parameters#vessel-history]] / [[CollectScience|Parameters#collectscience]] ]</sub>

##### VisitWaypoint
The VisitWaypoint parameter is used with the [[WaypointGenerator|Behaviours#waypointgenerator]] behaviour to indicate that a generated waypoint must be visited by a vessel.

    PARAMETER
    {
        name = VisitWaypoint
        type = VisitWaypoint

        // Index of the waypoint in the WaypointGenerator behaviour.
        // Default = 0
        index = 0

        // Distance tolerance to be considered at the waypoint.
        // Default = 500.0 (if on the surface).
        //         = <waypoint altitude> / 5.0 (if in the air).
        distance = 500.0

        
        // Text to use for the parameter
        // Default = Location: <waypoint>
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel History|Parameters#vessel-history]] / [[VisitWaypoint|Parameters#visitwaypoint]] ]</sub>

#### RemoteTech
These are parameters that are specific to the RemoteTech module.

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[RemoteTech|Parameters#remotetech]] ]</sub>

##### CelestialBodyCoverage
The CelestialBodyCoverage parameter requires that a minimum communication coverage of the given celestial body is reached.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = CelestialBodyCoverage
        type = CelestialBodyCoverage

        // The percentage (0.0 to 1.0) of communication coverage that is
        // needed to meet the contract parameter.
        coverage = 0.80

        // This can be inherited from the the contract type if necessary
        targetBody = Duna

        // Text to use for the parameter's title.
        // Default = <body>: Communication coverage: <coverage> %
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[RemoteTech|Parameters#remotetech]] / [[CelestialBodyCoverage|Parameters#celestialbodycoverage]] ]</sub>

##### KSCConnectivity
The KSCConnectivity parameter requires that a vessel has connectivity to the Kerbal Space Center (ie. Mission Control).

    PARAMETER:NEEDS[RemoteTech]
    {
        name = KSCConnectivity
        type = KSCConnectivity

        // Whether to check for connectivity or the lack of connectivity.
        // Default = true
        hasConnectivity = true

        // Text to use for the parameter's title.
        // Default = Connected to KSC
        //title =
    }	

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[RemoteTech|Parameters#remotetech]] / [[KSCConnectivity|Parameters#kscconnectivity]] ]</sub>

##### HasAntenna
The HasAntenna parameter requires that the vessel has an antenna that meets the specified criteria.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = HasAntenna
        type = HasAntenna

        // The minimum number of antenna that must meet the criteria.
        // Default = 1
        minCount = 1

        // The minimum number of antenna that can meet the criteria.
        // Default = int.MaxValue
        maxCount = 3

        // The minimum range in meters that the antenna must have
        // Default = 0.0
        minRange = 36000000000

        // The maximum range in meters that the antenna must have
        // Default = double.MaxValue
        maxRange = 100000000000

        // The type of antenna.  Dish or Omni.
        // Optional
        antennaType = Omni

        // This can be inherited from the the contract type if necessary
        // Optional
        targetBody = Duna

        // Specifies whether we are looking for a connection to the active
        // vessel.  Cannot be true if targetBody is specified.
        // Default = false
        activeVessel = True

        // Text to use for the parameter's title.
        // Default = Active vessel antenna range: <range>
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[RemoteTech|Parameters#remotetech]] / [[HasAntenna|Parameters#hasantenna]] ]</sub>

##### SignalDelay
The SignalDelay parameter specifies min/max values for the signal delay back to the KSC.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = SignalDelay
        type = SignalDelay

        // Minimum signal delay in seconds.
        // Default = 0.0
        minSignalDelay = 1.0

        // Maximum signal delay in seconds.
        // Default = double.MaxValue
        maxSignalDelay = 70.0

        // Text to use for the parameter's title.
        // Default = Signal delay: Between <min> and <max>.
        //title =
    }	

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[RemoteTech|Parameters#remotetech]] / [[SignalDelay|Parameters#signaldelay]] ]</sub>

##### VesselConnectivity
The VesselConnectivity parameter requires that the vessel has direct connectivity to another vessel.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = VesselConnectivity
        type = VesselConnectivity

        // The vessel to check connectivity against.
        vessel = CommSat I

        // Whether to check for connectivity or the lack of connectivity.
        // Default = true
        hasConnectivity = true

        // Text to use for the parameter's title.
        // Default = Direct connection to: <vessel>
        //title =
    }	

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[RemoteTech|Parameters#remotetech]] / [[VesselConnectivity|Parameters#vesselconnectivity]] ]</sub>

### Kerbal Parameters
These are parameters that operate on Kerbals.

<sub>[ [[Top|Parameters]] ] [ [[Kerbal Parameters|Parameters#kerbal-parameters]] ]</sub>

##### HasAstronaut
Parameter to require a certain number/type of hired astronauts.

    PARAMETER
    {
        name = HasAstronaut
        type = HasAstronaut

        // (Optional) The type of trait required.  Valid values are:
        //    Pilot
        //    Engineer
        //    Scientist
        trait = Pilot

        // (Optional) Minimum and maximum experience level.  Default values are
        // 0 and 5 (for min/max).
        minExperience = 1
        maxExperience = 2

        // (Optional) Minimum and maximum count.  Default values are 1 and
        // int.MaxValue (for min/max).
        minCount = 1
        maxCount = 10

        // Text to use for the parameter
        // Default (maxCrew = int.MAXVALUE) = Astronauts: At least <minCrew>
        // Default (minCrew = 0) = Astronauts: At most <maxCrew>
        // Default (minCrew = maxCrew) = Astronauts: Exactly <minCrew>
        // Default (else) = Astronauts: Between <minCrew> and <maxCrew>
        //title =
    }


<sub>[ [[Top|Parameters]] ] [ [[Kerbal Parameters|Parameters#kerbal-parameters]] / [[|Parameters#]] / [[HasAstronaut|Parameters#hasastronaut]] ]</sub>

#### RecoverKerbal
The RecoverKerbal parameter is met when the named Kerbal is "recovered" (ie. goes back in to the available list at the astronaut complex).  This is from the Squad "rescue" contracts.

    PARAMETER
    {
        name = RecoverKerbal
        type = RecoverKerbal

        // The Kerbal to be recovered
        kerbal = Jebediah Kermin

        // Alternate method of identifying the Kerbal - zero based index of the
        // entry in a SpawnKerbal or SpawnVessel BEHAVIOUR node.
        //index = 0

        // Text to use for the parameter
        // Default = <kerbal>: Recovered
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Kerbal Parameters|Parameters#kerbal-parameters]] / [[RecoverKerbal|Parameters#recoverkerbal]] ]</sub>

### Progression Parameters
Although not tied directly to the achievement/progression system, these are parameters that are typically used for progression type rewards (do something for the first time).  Note that some of these parameters are very similar to the [[vessel parameters|Parameters#vessel-parameters]], but work differently.  The progreession parameters only require you to have done the thing once before, rather than doing it with a specific vessel.

<sub>[ [[Top|Parameters]] ] [ [[Progression Parameters|Parameters#progression-parameters]] ]</sub>

#### ReachSpace
Go to space.

    PARAMETER
    {
        name = ReachSpace
        type = ReachSpace
    }

<sub>[ [[Top|Parameters]] ] [ [[Progression Parameters|Parameters#progression-parameters]] / [[ReachSpace|Parameters#reachspace]] ]</sub>

### Negative Parameters
These parameters are ones that give a failure condition to a contract.  Note that when the contract fails, the player can't re-attempt it (unless it's set up to be offered again after failure).

<sub>[ [[Top|Parameters]] ] [ [[Negative Parameters|Parameters#negative-parameters]] ]</sub>

#### KerbalDeaths
The KerbalDeaths parameter _fails_ if more Kerbals than the countMax die.

    PARAMETER
    {
        name = KerbalDeaths
        type = KerbalDeaths

        // Maximum Number of Kerbals that can die before this contract is considered
        // failed.
        //
        // Default = 1
        countMax = 1
    }

<sub>[ [[Top|Parameters]] ] [ [[Negative Parameters|Parameters#negative-parameters]] / [[KerbalDeaths|Parameters#kerbaldeaths]] ]</sub>

### Set Parameters
Set parameters are special - they do not typically do anything on their own, but work with their child parameters.

<sub>[ [[Top|Parameters]] ] [ [[Set Parameters|Parameters#set-parameters]] ]</sub>

#### Any
The Any parameter is completed if any one of its child parameters are completed.

    PARAMETER
    {
        name = Any
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
            name = ReachSpace
            type = ReachSpace
        }

        PARAMETER
        {
            name = ReachState
            type = ReachState

            minSpeed = 1000
            maxSpeed = 5000
        }
    }

<sub>[ [[Top|Parameters]] ] [ [[Set Parameters|Parameters#set-parameters]] / [[Any|Parameters#any]] ]</sub>

#### All
The All parameter is completed once all its child parameters are completed.

    PARAMETER
    {
        name = All
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
            name = ReachState
            type = ReachState

            minAltitude = 20000
            maxAltitude = 50000

            minSpeed = 1000
            maxSpeed = 5000
        }

        PARAMETER
        {
            name = HasCrew
            type = HasCrew
        }
    }

<sub>[ [[Top|Parameters]] ] [ [[Set Parameters|Parameters#set-parameters]] / [[All|Parameters#all]] ]</sub>

#### AtLeast
The AtLeast parameter is completed if a specified number of its child parameters are completed.

    PARAMETER
    {
        name = AtLeast
        type = AtLeast

        // The minimum number that must be completed.
        count = 1

        // The text to display.  Highly recommended that you do not use the default -
        // when the parameter is complete the text of the children disappears (and
        // the default text doesn't give the player a very good idea what the
        // parameter was about).
        //
        // Default - Complete at least <count> of the following
        //title =

        PARAMETER
        {
            name = ReachSpace
            type = ReachSpace
        }

        PARAMETER
        {
            name = ReachState
            type = ReachState

            minSpeed = 1000
            maxSpeed = 5000
        }
    }


<sub>[ [[Top|Parameters]] ] [ [[Set Parameters|Parameters#set-parameters]] / [[AtLeast|Parameters#atleast]] ]</sub>

#### AtMost
The AtMost parameter will fail if more than the specified number of its child parameters are completed.  Note that the correct way to use this is to set the completeInSequence to true and to place this parameter at the bottom of the appropriate group of parameters.  Otherwise, the parameter will get marked as completed almost immediately, which hides the child parameters.

    PARAMETER
    {
        name = AtMost
        type = AtMost

        // The maximum number that can be completed.  Any more than this and
        // the contract fails.
        count = 1

        // The text to display.  Highly recommended that you do not use the default -
        // when the parameter is complete the text of the children disappears (and
        // the default text doesn't give the player a very good idea what the
        // parameter was about).
        //
        // Default - Allow no more than <count> of the following
        //title =

        // Generally need completeInSequence set to true for this.
        completeInSequence = true

        PARAMETER
        {
            name = ReachSpace
            type = ReachSpace
        }

        PARAMETER
        {
            name = ReachState
            type = ReachState

            minSpeed = 1000
            maxSpeed = 5000
        }
    }

<sub>[ [[Top|Parameters]] ] [ [[Set Parameters|Parameters#set-parameters]] / [[AtMost|Parameters#atmost]] ]</sub>

#### None
The None parameter will fail if any of its child parameters are completed.  Note that the correct way to use this is to set the completeInSequence to true and to place this parameter at the bottom of the appropriate group of parameters.  Otherwise, the parameter will get marked as completed almost immediately, which hides the child parameters.

    PARAMETER
    {
        name = None
        type = None

        // The text to display.  Highly recommended that you do not use the default -
        // when the parameter is complete the text of the children disappears (and
        // the default text doesn't give the player a very good idea what the
        // parameter was about).
        //
        // Default - Prevent ALL of the following
        //title =

        // Generally need completeInSequence set to true for this.
        completeInSequence = true

        PARAMETER
        {
            name = ReachSpace
            type = ReachSpace
        }

        PARAMETER
        {
            name = ReachState
            type = ReachState

            minSpeed = 1000
            maxSpeed = 5000
        }
    }
<sub>[ [[Top|Parameters]] ] [ [[Set Parameters|Parameters#set-parameters]] / [[None|Parameters#none]] ]</sub>

#### Sequence
The Sequence parameter is one of two ways to define parameters that need to be completed in sequence.  For this variant, use Sequence as a parent node for all nodes that must be completed in order.  If any parameter completes out of order, this parameter will fail - causing the contract to fail.

    // In this example of the Sequence parameter, the player must orbit the Mun,
    // then orbit Minmus.  If the player orbits Minmus first, the parameter fails.
    PARAMETER
    {
        name = Sequence
        type = Sequence

        // Hide the parameter with the given name until it is the next one in
        // the list to be completed.  Can be specified multiple times.
        hiddenParameter = OrbitMinmus

        // By default, parameters that are prevented from completing if they
        // are out of order.  To cause a failure instead, set this to true.
        // Default = false
        failWhenCompleteOutOfOrder = true

        // The title to display
        // Default: Complete the following in order
        //title =

        PARAMETER
        {
            name = OrbitMun
            type = VesselParameterGroup

            title = Orbit the Mun

            PARAMETER
            {
                name = ReachState
                type = ReachState

                situation = ORBITING
            }

            PARAMETER
            {
                name = ReachState
                type = ReachState

                targetBody = Mun
            }
        }

        PARAMETER
        {
            name = OrbitMinmus
            type = VesselParameterGroup

            title = Orbit Minmus

            PARAMETER
            {
                name = ReachSituation
                type = ReachSituation

                situation = ORBITING
            }

            PARAMETER
            {
                name = ReachDestination
                type = ReachDestination

                targetBody = Minmus
            }
        }
    }


<sub>[ [[Top|Parameters]] ] [ [[Set Parameters|Parameters#set-parameters]] / [[Sequence|Parameters#sequence]] ]</sub>

### Planetary Parameters

Parameters specific to doing something related to a planetary body.

<sub>[ [[Top|Parameters]] ] [ [[Planetary Parameters|Parameters#planetary-parameters]] ]</sub>

#### PerformOrbitalSurvey
The PerformOrbitalSurvey parameter is met when an orbital scan of the given body is performed.

    PARAMETER
    {
        name = PerformOrbitalSurvey
        type = PerformOrbitalSurvey

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

<sub>[ [[Top|Parameters]] ] [ [[Planetary Parameters|Parameters#planetary-parameters]] / [[PerformOrbitalSurvey|Parameters#performorbitalsurvey]] ]</sub>

#### PlantFlag
The PlantFlag parameter is met when planting a flag on the given body.

    PARAMETER
    {
        name = PlantFlag
        type = PlantFlag

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

<sub>[ [[Top|Parameters]] ] [ [[Planetary Parameters|Parameters#planetary-parameters]] / [[PlantFlag|Parameters#plantflag]] ]</sub>

#### SCANsatCoverage
The SCANsatCoverage parameter is met when there is sufficient SCANsat coverage for the given planet/type.

    PARAMETER:NEEDS[SCANsat]
    {
        name = SCANsatCoverage
        type = SCANsatCoverage

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Kerbin

        // Coverage percentage that must be reached
        coverage = 65.0

        // The type of scan to perform.  Valid values are from SCANdata.SCANtype.
        // Some possible values are:
        //    AltimetryLoRes
        //    AltimetryHiRes
        //    Altimetry
        //    Biome
        //    Anomaly
        //    AnomalyDetail
        //    Kethane
        //    Ore
        //    Uranium
        //    Thorium
        //    Alumina
        //    Water
        //    Aquifer
        //    Minerals
        //    Substrate
        //    Karbonite
        scanType = Biome
    }

<sub>[ [[Top|Parameters]] ] [ [[Planetary Parameters|Parameters#planetary-parameters]] / [[SCANsatCoverage|Parameters#scansatcoverage]] ]</sub>

### Miscellaneous Parameters

Other parameters that didn't fit in elsewhere.

<sub>[ [[Top|Parameters]] ] [ [[Miscellaneous Parameters|Parameters#miscellaneous-parameters]] ]</sub>

#### PartTest
PartTest is for testing parts (or just activating them, for staged parts).  This parameter supports child parameters - you will only be able to complete the part test if all child parameters are also completed.

    PARAMETER
    {
        name = PartTest
        type = PartTest

        // The Kerbal to be recovered
        part = SmallGearBay

        // Additional notes to display (in the Squad PartTest contract, this is where
        // they say "Activate through the staging system", etc.
        // Default = Test this part anywhere, no other requirements!
        // notes =
    }

<sub>[ [[Top|Parameters]] ] [ [[Miscellaneous Parameters|Parameters#miscellaneous-parameters]] / [[PartTest|Parameters#parttest]] ]</sub>

#### Duration
The Duration parameter sets up a timer that starts when all sibling parameters are completed.  Once the timer expires, the parameter is completed.

    PARAMETER
    {
        name = Duration
        type = Duration

        // The duration the timer is set to. Can specify values in years (y),
        // days (d), hours (h), minutes (m), seconds (s) or any combination of
        // those.
        duration = 30m 10s

        // The preWaitText overrides the text that is displayed when waiting
        // for the other parameters to complete.
        // Default = Waiting time required
        //preWaitText =

        // The waitingText overrides the text that is displayed when waiting
        // for the timer to expire.
        // Default = Time to completion
        //waitingText =

        // The completionText is displayed when the timer completes.
        // Default = Wait time over
        //completionText =
    }

<sub>[ [[Top|Parameters]] ] [ [[Miscellaneous Parameters|Parameters#miscellaneous-parameters]] / [[Duration|Parameters#duration]] ]</sub>

#### Timer
The Timer parameter sets up a timer that starts when the contract is accepted.  The player only has the specified duration before the timer expires and the contract fails!

    PARAMETER
    {
        name = Timer
        type = Timer

        // The duration the timer is set to. Can specify values in years (y),
        // days (d), hours (h), minutes (m), seconds (s) or any combination of
        // those.
        duration = 30m
    }

<sub>[ [[Top|Parameters]] ] [ [[Miscellaneous Parameters|Parameters#miscellaneous-parameters]] / [[Timer|Parameters#timer]] ]</sub>

#### TargetDestroyed
The TargetDestroyed indicates that a specific target vessel (or vessels) must be destroyed.  Use it for setting up targets for weapons mods.

    PARAMETER
    {
        name = TargetDestroyed
        type = TargetDestroyed

        // The vessel attribute is the *defined* name of the vessel that should
        // not be destroyed.  This is a name of a vessel defined either with
        // the define attribute of a VesselParameterGroup parameter, or via a
        // SpawnVessel.
        //
        // It can be specified multiple times, but there must be at least one.
        vessel = First Target
        vessel = Second Target

        // Text for the contract parameter.
        // Default: Target destroyed
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Miscellaneous Parameters|Parameters#miscellaneous-parameters]] / [[TargetDestroyed|Parameters#targetdestroyed]] ]</sub>


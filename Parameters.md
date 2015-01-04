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
        type = AltitudeRecord

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

        // Optional parameters do not need to be completed (mainly for use with
        // composite parameters)
        optional = true
    }

The following parameters are natively supported by ContractConfigurator:

* [[Vessel Parameters|Parameters#vessel-parameters]]
  * [[VesselParameterGroup|Parameters#vesselparametergroup]]
  * [[Vessel Attributes|Parameters#vessel-attributes]]
    * [[HasCrew|Parameters#hascrew]]
    * [[HasPassengers|Parameters#haspassengers]]
    * [[HasPart|Parameters#haspart]]
    * [[HasPartModule|Parameters#haspartmodule]]
    * [[HasResource|Parameters#hasresource]]
    * [[PartValidation|Parameters#partvalidatin]]
    * [[IsNotVessel|Parameters#isnotvessel]]
    * [[VesselMass|Parameters#vesselmass]]
  * [[Orbit Attributes|Parameters#orbit-attributes]]
    * [[OrbitAltitude|Parameters#orbitaltitude]]
    * [[OrbitApoapsis|Parameters#orbitapoapsis]]
    * [[OrbitPeriapsis|Parameters#orbitperiapsis]]
    * [[OrbitEccentricity|Parameters#orbiteccentricity]]
    * [[OrbitInclination|Parameters#orbitinclination]]
  * [[Vessel State|Parameters#vessel-state]]
    * [[ReachAltitudeEnvelope|Parameters#reachaltitudeenvelope]]
    * [[ReachSpeedEnvelope|Parameters#reachspeedenvelope]]
    * [[ReachBiome|Parameters#reachbiome]]
    * [[ReachDestination|Parameters#reachdestination]]
    * [[ReachSitutaion|Parameters#reachsituation]]
    * [[ReachSpecificOrbit|Parameters#reachspecificorbit]]
    * [[ReturnHome|Parameters#returnhome]]
  * [[Vessel History|Parameters#vessel-history]]
    * [[VesselHasVisited|Parameters#vesselhasvisited]]
    * [[VisitWaypoint|Parameters#visitwaypoint]]
  * [[RemoteTech|Parameters#remotetech]]
    * [[ActiveVesselConnection|Parameters#activevesselconnection]]
    * [[KSCConnectivity|Parameters#kscconnectivity]]
    * [[SignalDelay|Parameters#signaldelay]]
    * [[VesselConnectivity|Parameters#vesselconnectivity]]
* [[Kerbal Parameters|Parameters#kerbal-parameters]]
  * [[BoardAnyVessel|Parameters#boardanyvessel]]
  * [[RecoverKerbal|Parameters#recoverkerbal]]
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
  * [[Sequence|Parameters#sequence]]
  * [[SequenceNode|Parameters#sequencenode]]
* [[Planetary Parameters|Parameters#planetary-parameters]]
  * [[CollectScience|Parameters#collectscience]]
  * [[PlantFlag|Parameters#plantflag]]
  * [[SCANsatCoverage|Parameters#scansatcoverage]]
* [[Miscellaneous Parameters|Parameters#miscellaneous-parameters]]
  * [[PartTest|Parameters#parttest]]
  * [[Duration|Parameters#duration]]
  * [[Timer|Parameters#timer]]

### Vessel Parameters
These are parameters that operate on vessels (manned or unmanned).  By default, all vessel parameters have disableOnStateChange set to false.

#### VesselParameterGroup
The VesselParameterGroup parameter is used to group several child vessel parameters together.  It can also be used to specify a duration for which the parameters must be true, and will track across non-active vessels.  Note that when not used with a VesselParameterGroup parent parameter, the other vessel parameters on this page will only work with the active vessel.

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

        // COMING SOON!
        // Define the name of the craft that will complete this parameter group.
        // Once a craft completes the group, it will be associated with the 
        // given key, which can then be referenced in other parameters.  The
        // Vessel <=> key association is persistent, and can be used in future
        // contracts.
        define = Vessel Key

        // Examples of typical child parameters used with VesselParameterGroup
        PARAMETER
        {
            name = ReachSituation1
            type = ReachSituation

            situation = ORBITING
        }

        PARAMETER
        {
            name = ReachDestination1
            type = ReachDestination

            targetBody = Kerbin
        }

        PARAMETER
        {
            name = HasCrew1
            type = HasCrew
        }
    }

#### Vessel Attributes
These parameters pertain to attributes of a vessel.

##### HasCrew
Parameter to indicate that the Vessel in question must have a certain number of crew members (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasCrew1
        type = HasCrew

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
        minCrew = 1
        maxCrew = 10

        // Text to use for the parameter
        // Default (maxCrew = 0) = Crew: Unmanned
        // Default (maxCrew = int.MAXVALUE) = Crew: At least <minCrew> Kerbals
        // Default (minCrew = 0) = Crew: At most <maxCrew> Kerbals
        // Default (minCrew = maxCrew) = Crew: Exactly <minCrew> Kerbals
        // Default (else) = Crew: Between <minCrew> and <maxCrew> Kerbals
        //title =
    }

##### HasPassengers
**_NEW!_**
Parameter to indicate that the Vessel in question must have a certain number of passengers (or must have fewer than a certain number).  Passengers are represented by empty seats.

    PARAMETER
    {
        name = HasPassengers
        type = HasPassengers

        // (Optional) Minimum and maximum count.  Default values are 1 and
        // int.MaxValue (for min/max).
        minPassengers = 1
        maxPassengers = 1

        // Text to use for the parameter
        // Default (maxPassengers = int.MAXVALUE) = Passengers: At least <minPassengers > Kerbals
        // Default (minPassengers = 0) = Passengers: At most <maxPassengers > Kerbals
        // Default (minPassengers = maxPassengers ) = Passengers: Exactly <minPassengers > Kerbals
        // Default (else) = Passengers: Between <minPassengers > and <maxPassengers > Kerbals
        //title =
    }

##### HasPart
Parameter to indicate that the Vessel in question must have a certain number of a certain part (or must have fewer than a certain number).

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
        // Default (maxCount = 0) = Part: <part>: None
        // Default (maxCount = int.MAXVALUE) = Part: <part>: At least <minCount>
        // Default (minCount = 0) = Part: <part>: At most <maxCount>
        // Default (minCount = maxCount ) = Part: <part>: Exactly <minCount>
        // Default (else) = Part: <part>: Between <minCount> and <maxCount>
        //title =
    }

##### HasPartModule
Parameter to indicate that the Vessel in question must have a certain number of a certain PartModule (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasPartModule1
        type = HasPartModule

        // The name of the part module to check for
        partModule = ModuleReactionWheel

        // Minimum count, default = 1
        minCount = 1

        // Maximum count, default = int.MAXVALUE
        maxCount = 10

        // Text to use for the parameter
        // Default (maxCount = 0) = Module: <partModule>: None
        // Default (maxCount = int.MAXVALUE) = Module: <partModule>: At least <minCount>
        // Default (minCount = 0) = Module: <partModule>: At most <maxCount>
        // Default (minCount = maxCount ) = Module: <partModule>: Exactly <minCount>
        // Default (else) = Module: <partModule>: Between <minCount> and <maxCount>
        //title =
    }

##### HasResource
Parameter to indicate that the Vessel in question must have a certain quantity of a certain resource (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasResource1
        type = HasResource

        // The name of the resource to check for
        resource = LiquidFuel

        // Minimum quantity, default = 0.01
        minQuantity = 10.0

        // Maximum quantity, default = double.MAXVALUE
        maxQuantity = 1000.0

        // Text to use for the parameter
        // Default Resource: <resource>: <quantity_description>
        //title =
    }

##### PartValidation
**_COMING SOON!_**
Parameter to provide validation over a vessel's parts.  Can validate along a number of different attributes.

    PARAMETER
    {
        name = PartValidation
        type = PartValidation

        // The name of the part to check for.  Optional.
        part = mk1pod

        // PartModule(s) to check for.  Optional, and can be specified multiple times.
        partModule = ModuleReactionWheel
        partModule = ModuleSAS

        // Part manufacturer to check for.  Optional.
        manufacturer = Kerbodyne

        // Part manufacturer to exclude.  Optional.
        notManufacturer = Rockomax Conglomerate

        // Part category to check for.  Optional.
        // List of valid values from PartCategories:
        //   Aero
        //   Control
        //   Engine
        //   FuelTank
        //   Pods
        //   Science
        //   Structural
        //   Utility
        category = Engine

        // Part category to exclude.  Optional.
        notCategory = Science

        // Minimum count, default = 1
        minCount = 1

        // Maximum count, default = int.MAXVALUE
        maxCount = 10

        // Text to use for the parameter
        // Default (maxCount = 0) = Part: <attributes>: None
        // Default (maxCount = int.MAXVALUE) = Part: <attributes>: At least <minCount>
        // Default (minCount = 0) = Part: <attributes>: At most <maxCount>
        // Default (minCount = maxCount ) = Part: <attributes>: Exactly <minCount>
        // Default (else) = Part: <attributes>: Between <minCount> and <maxCount>
        //title =
    }

##### IsNotVessel
**_COMING SOON!_**
The IsNotVessel parameter is used to create mutually exclusive groups within a contract.  Use the define attribute in the VesselParameterGroup parameter to define names, and then use the IsNotVessel within those to make the other vessel(s) invalid for completing the other group.

    PARAMETER
    {
        name = IsNotVessel
        type = IsNotVessel

        // The key of the vessel that cannot complete this parameter.  This should
        // be a printable name, as it can be displayed to players if the key does
        // not yet point to a real craft.
        vesselKey = Vessel Key

        // Text for the contract parameter.
        // Default = Vessel: Not <vesselKey>
        //title = 
    }

##### VesselMass
The VesselMass parameter requires a player's vessel to be within the specified mass range.

    PARAMETER
    {
        name = VesselMass1
        type = VesselMass

        // (Optional) Minimum and maximum mass.  Defaults are 0.0
        // and float.MaxValue for (min/max) respectively.
        minMass = 1.0
        maxMass = 10.0

        // Text for the contract parameter.
        // Default = Vessel mass: <mass>
        //title = 
    }

#### Orbit Attributes
These parameters pertain to attributes of a vessel's orbit.

##### OrbitAltitude
**_COMING SOON!_**
Orbital parameter to specify a required apoapsis and periapsis.

    PARAMETER
    {
        name = OrbitAltitude
        type = OrbitAltitude

        // Target body, defaulted from the contract if not supplied.
        targetBody = Kerbin

        // Minimum orbit altitude in meters.
        // Default = 0
        minAltitude = 100000

        // Maximum orbit altitude in meters.
        // Default = double.MaxValue
        maxAltitude = 250000

        // Text to use for the parameter
        // Default Orbit: Between <min> and <max>
        //title =
    }

##### OrbitApoapsis
**_NEW!_**
Orbital parameter to specify a required apoapsis.

    PARAMETER
    {
        name = OrbitApoapsis
        type = OrbitApoapsis

        // Target body, defaulted from the contract if not supplied.
        targetBody = Kerbin

        // Minimum apoapsis in meters.
        // Default = 0
        minApA = 100000

        // Maximum apoapsis in meters.
        // Default = double.MaxValue
        maxApA = 250000

        // Text to use for the parameter
        // Default Apoapsis: Between <min> and <max>
        //title =
    }

##### OrbitPeriapsis
**_NEW!_**
Orbital parameter to specify a required periapsis.

    PARAMETER
    {
        name = OrbitPeriapsis
        type = OrbitPeriapsis

        // Target body, defaulted from the contract if not supplied.
        targetBody = Kerbin

        // Minimum periapsis in meters.
        // Default = 0
        minPeA = 100000

        // Maximum periapsis in meters.
        // Default = double.MaxValue
        maxPeA = 250000

        // Text to use for the parameter
        // Default Periapsis: Between <min> and <max>
        //title =
    }

##### OrbitEccentricity
**_NEW!_**
Orbital parameter to specify a required eccentricity.

    PARAMETER
    {
        name = OrbitEccentricity
        type = OrbitEccentricity

        // Target body, defaulted from the contract if not supplied.
        targetBody = Kerbin

        // Minimum eccentricity.
        // Default = 0
        minEccentricity = 0.0

        // Maximum eccentricity.
        // Default = double.MaxValue
        maxEccentricity = 0.1

        // Text to use for the parameter
        // Default Eccentricity: Between <min> and <max>
        //title =
    }

##### OrbitInclination
**_NEW!_**
Orbital parameter to specify a required inclination.

    PARAMETER
    {
        name = OrbitInclination
        type = OrbitInclination

        // Target body, defaulted from the contract if not supplied.
        targetBody = Kerbin

        // Minimum inclination in degrees
        // Default = 0
        minInclination = 0

        // Maximum inclination in degrees
        // Default = 180
        maxInclination = 1

        // Text to use for the parameter
        // Default Inclination: Between <min> and <max>
        //title =
    }

#### Vessel State
These parameters pertain to the state of a vessel.

##### ReachAltitudeEnvelope
Get to a specific altitude envelope.  Note that this is not tied to a specific celestial body - to do that you need to use multiple parameters together.

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

##### ReachSpeedEnvelope
Get to a specific speed envelope.  Note that this is not tied to a specific celestial body - to do that you need to use multiple parameters together.

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

##### ReachBiome
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

##### ReachDestination
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

##### ReachSituation
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

##### ReachSpecificOrbit
**_NEW!_**
The ReachSpecificOrbit parameter is used with the [[OrbitGenerator|Behaviours#orbitgenerator]] behaviour to indicate that a generated orbit must be reached by a vessel.

    PARAMETER
    {
        name = ReachSpecificOrbit1
        type = ReachSpecificOrbit

        // The index (0-based) in the OrbitGenerator behaviour of the orbit we
        // wish to reference.
        // Default = 0
        index = 0

        // The deviation window for how close we must match the given orbit.
        // wish to reference.  Higher values give more room for error.  Note: More
        // testing is required to better document the realistic range of values.
        // Default = 3.0
        deviationWindow = 10.0
    }

##### ReturnHome
The ReturnHome parameter requires a player to return home (ideally after meeting their other contract objectives).

    PARAMETER
    {
        name = ReturnHome1
        type = ReturnHome

        // Text for the contract parameter.
        // Default = Return home.
        //title = 
    }

#### Vessel History
These parameters pertain to the history of a vessel.

##### VesselHasVisited
The VesselHasVisited parameter requires a player to go to visit a celestial body under specific circumstances.

    PARAMETER
    {
        name = VesselHasVisited1
        type = VesselHasVisited

        // The target to visit.  If not specified will defaulted from the contract.
        targetBody = Mun

        // The situation.  Valid values from FlightLog.EntryType
        //    Land
        //    Flight
        //    Flyby
        //    Orbit
        //    Suborbit
        //    Escape
        //    Launch
        //    ExitVessel
        //    BoardVessel
        //    PlantFlag
        //    Recover
        //    Die
        //    Spawn
        situation = Land

        // Text for the contract parameter.
        // Default = Perform <situation> on <targetBody>.
        //title = 
    }

##### VisitWaypoint
**_NEW!_**
The VisitWaypoint parameter is used with the [[WaypointGenerator|Behaviours#waypointgenerator]] behaviour to indicate that a generated waypoint must be visited by a vessel.

    PARAMETER
    {
        name = VisitWaypoint1
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

#### RemoteTech
**_COMING SOON!_**
These are parameters that are specific to the RemoteTech module.

##### ActiveVesselConnection
**_COMING SOON!_**
The ActiveVesselConnection requires that the vessel is capable of connecting to the active vessel at a given range.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = ActiveVesselConnection
        type = ActiveVesselConnection

        // The range in meters that the vessel must be able to connect to.
        range = 48000000

        // Text to use for the parameter's title.
        // Default = Active vessel antenna range: <range>
        //title =
    }

##### KSCConnectivity
**_COMING SOON!_**
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

##### SignalDelay
**_COMING SOON!_**
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

##### VesselConnectivity
**_COMING SOON!_**
The VesselConnectivity parameter requires that the vessel has direct connectivity to another vessel.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = VesselConnectivity
        type = VesselConnectivity

        // The vessel to check connectivity against.
        vesselKey = CommSat I

        // Whether to check for connectivity or the lack of connectivity.
        // Default = true
        hasConnectivity = true

        // Text to use for the parameter's title.
        // Default = Direct connection to: <vesselKey>
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

        // Alternate method of identifying the Kerbal - zero based index of the
        // entry in a SpawnKerbal BEHAVIOUR node.
        //index = 0

        // Text to use for the parameter
        // Default = <kerbal>: Board a vessel
        //title =
    }

#### RecoverKerbal
The RecoverKerbal parameter is met when the named Kerbal is "recovered" (ie. goes back in to the available list at the astronaut complex).  This is from the Squad "rescue" contracts.

    PARAMETER
    {
        name = RecoverKerbal1
        type = RecoverKerbal

        // The Kerbal to be recovered
        kerbal = Jebediah Kermin

        // Alternate method of identifying the Kerbal - zero based index of the
        // entry in a SpawnKerbal BEHAVIOUR node.
        //index = 0

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
        // Default = 1
        countMax = 1
    }

### Set Parameters
Set parameters are special - they do not typically do anything on their own, but work with their child parameters.

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

            minAltitude = 20000
            maxAltitude = 50000
        }

        PARAMETER
        {
            name = ReachSpeedEnvelope1
            type = ReachSpeedEnvelope

            minSpeed = 1000
            maxSpeed = 5000
        }
    }

#### Sequence
The Sequence parameter is one of two ways to define parameters that need to be completed in sequence.  For this variant, use Sequence as a parent node for all nodes that must be completed in order.  If any parameter completes out of order, this parameter will fail - causing the contract to fail.

    // In this example of the Sequence parameter, the player must orbit the Mun,
    // then orbit Minmus.  If the player orbits Minmus first, the parameter fails.
    PARAMETER
    {
        name = Sequence1
        type = Sequence

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
                name = ReachSituation1
                type = ReachSituation

                situation = ORBITING
            }

            PARAMETER
            {
                name = ReachDestination1
                type = ReachDestination

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
                name = ReachSituation1
                type = ReachSituation

                situation = ORBITING
            }

            PARAMETER
            {
                name = ReachDestination1
                type = ReachDestination

                targetBody = Minmus
            }
        }
    }


#### SequenceNode
The SequenceNode parameter is the second way to define parameters that need to be completed in sequence.  For this variant, use SequenceNode as a parent node for each nodes that must be completed in order.  If any parameter completes out of order, this parameter will remain in an incomplete state.

    // In this example of the SequenceNode parameter, the player must orbit the Mun,
    // then orbit Minmus.  If the player orbits Minmus first, the Minmus portion will
    // not complete.  The player will be required to go to the Mun, then go *back*
    // to Minmus to complete the Parameter.
    PARAMETER
    {
        name = OrbitMunSeqNode
        type = SequenceNode

        // The title to display
        // Default (variable), one of:
        //     Complete the following
        //     Complete after the previous step
        //     Completed
        //title =

        PARAMETER
        {
            name = OrbitMun
            type = VesselParameterGroup

            title = Orbit the Mun

            disableOnStateChange = false

            PARAMETER
            {
                name = ReachSituation1
                type = ReachSituation

                situation = ORBITING
            }

            PARAMETER
            {
                name = ReachDestination1
                type = ReachDestination

                targetBody = Mun
            }
        }
    }

    PARAMETER
    {
        name = OrbitMinmusSeqNode
        type = SequenceNode

        // The title to display
        // Default (variable), one of:
        //     Complete the following
        //     Complete after the previous step
        //     Completed
        //title =

        PARAMETER
        {
            name = OrbitMinmus
            type = VesselParameterGroup

            title = Orbit Minmus

            disableOnStateChange = false

            PARAMETER
            {
                name = ReachSituation1
                type = ReachSituation

                situation = ORBITING
            }

            PARAMETER
            {
                name = ReachDestination1
                type = ReachDestination

                targetBody = Minmus
            }
        }
    }

### Planetary Parameters

Parameters specific to doing something related to a planetary body.

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

#### SCANsatCoverage
**_NEW!_**
The SCANsatCoverage parameter is met when there is sufficient SCANsat coverage for the given planet/type.

    PARAMETER:NEEDS[SCANsat]
    {
        name = SCANsatCoverage1
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

### Miscellaneous Parameters

Other parameters that didn't fit in elsewhere.

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

#### Duration
**_COMING SOON!_**
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

#### Timer
The Timer parameter sets up a timer that starts when the contract is accepted.  The player only has the specified duration before the timer expires and the contract fails!

    PARAMETER
    {
        name = Timer1
        type = Timer

        // The duration the timer is set to. Can specify values in years (y),
        // days (d), hours (h), minutes (m), seconds (s) or any combination of
        // those.
        duration = 30m
    }
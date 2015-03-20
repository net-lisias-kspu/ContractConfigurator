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

        // Indicates that this parameter needs to be complete "in sequence".
        // All parameters that are before this parameter in the list (and at
        // the same level) must be completed before this parameter is allowed
        // to complete.
        // Default = false
        completeInSequence = true
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

The following parameters are natively supported by ContractConfigurator:

* [[Vessel Parameters|Parameters#vessel-parameters]]
  * [[VesselParameterGroup|Parameters#vesselparametergroup]]
  * [[Vessel Attributes|Parameters#vessel-attributes]]
    * [[HasCrew|Parameters#hascrew]]
    * [[HasCrewCapacity|Parameters#hascrewcapacity]]
    * [[HasPassengers|Parameters#haspassengers]]
    * [[HasResource|Parameters#hasresource]]
    * [[PartValidation|Parameters#partvalidation]]
    * [[IsNotVessel|Parameters#isnotvessel]]
    * [[VesselIsType|Parameters#vesselistype]]
    * [[VesselMass|Parameters#vesselmass]]
  * [[Vessel State|Parameters#vessel-state]]
    * [[Docking|Parameters#docking]]
    * [[Orbit|Parameters#orbit]]
    * [[ReachState|Parameters#reachstate]]
    * [[ReachSpecificOrbit|Parameters#reachspecificorbit]]
    * [[Rendezvous|Parameters#rendezvous]]
    * [[ReturnHome|Parameters#returnhome]]
    * [[VesselDestroyed|Parameters#vesseldestroyed]]
    * [[VesselNotDestroyed|Parameters#vesselnotdestroyed]]
  * [[Vessel History|Parameters#vessel-history]]
    * [[CollectScience|Parameters#collectscience]]
    * [[VesselHasVisited|Parameters#vesselhasvisited]]
    * [[VisitWaypoint|Parameters#visitwaypoint]]
  * [[RemoteTech|Parameters#remotetech]]
    * [[CelestialBodyCoverage|Parameters#celestialbodycoverage]]
    * [[KSCConnectivity|Parameters#kscconnectivity]]
    * [[HasAntenna|Parameters#hasantenna]]
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
  * [[PlantFlag|Parameters#plantflag]]
  * [[SCANsatCoverage|Parameters#scansatcoverage]]
* [[Miscellaneous Parameters|Parameters#miscellaneous-parameters]]
  * [[PartTest|Parameters#parttest]]
  * [[Duration|Parameters#duration]]
  * [[Timer|Parameters#timer]]
  * [[TargetDestroyed|Parameters#targetdestroyed]]

### Vessel Parameters
These are parameters that operate on vessels (manned or unmanned).  By default, all vessel parameters have disableOnStateChange set to false.

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] ]</sub>

#### VesselParameterGroup
The VesselParameterGroup parameter is used to group several child vessel parameters together.  It can also be used to specify a duration for which the parameters must be true, and will track across non-active vessels.  Note that when not used with a VesselParameterGroup parent parameter, the other vessel parameters on this page will only work with the active vessel.

    PARAMETER
    {
        name = VesselParameterGroup
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

        // Define the name of the craft that will complete this parameter group.
        // Once a craft completes the group, it will be associated with the
        // given key, which can then be referenced in other parameters.  The
        // Vessel <=> key association is persistent, and can be used in future
        // contracts.
        define = Vessel Key

        // Lock this parameter so that it can only be accomplished by the
        // specified craft.  Note that the name is a "define" name set via
        // the define key in a *different* VesselParameterGroup parameter
        // (which can be in the same contract, or a different one).  This
        // attribute can be specified multiple times to allow multiple vessel
        // to be available to complete the parameter.
        vessel = Vessel Key
        vessel = Some other vessel

        // Examples of typical child parameters used with VesselParameterGroup
        PARAMETER
        {
            name = ReachState
            type = ReachState

            situation = ORBITING
        }

        PARAMETER
        {
            name = HasCrew
            type = HasCrew
        }
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[VesselParameterGroup|Parameters#vesselparametergroup]] ]</sub>

#### Vessel Attributes
These parameters pertain to attributes of a vessel.

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] ]</sub>

##### HasCrew
Parameter to indicate that the Vessel in question must have a certain number of crew members (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasCrew
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

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] / [[HasCrew|Parameters#hascrew]] ]</sub>

##### HasCrewCapacity
**_NEW!_**
Parameter to require that the Vessel in question must have a certain crew capacity.

    PARAMETER
    {
        name = HasCrewCapacity
        type = HasCrewCapacity

        // Minimum/maximum capacity required.  Defaults are 1 and int.MaxValue,
        // respectively
        minCapacity = 1
        maxCapacity = 10

        // Text to use for the parameter.
        // Default: Crew Capacity: Between <min> and <max>
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] / [[HasCrewCapacity|Parameters#hascrewcapacity]] ]</sub>

##### HasPassengers
Parameter to indicate that the Vessel in question must have a certain number of passengers (or must have fewer than a certain number).  Use with the SpawnPassengers behaviour.

    PARAMETER
    {
        name = HasPassengers
        type = HasPassengers

        // Number of passengers to load onto the ship.
        // Default = 0 (all)
        count = 1

        // Start index in the SpawnPassengers behaviour
        // Default = 0
        index = 0

        // Text to use for the parameter
        // Default Passengers loaded : <count>
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] / [[HasPassengers|Parameters#haspassengers]] ]</sub>

##### HasResource
Parameter to indicate that the Vessel in question must have a certain quantity of a certain resource (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasResource
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

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] / [[HasResource|Parameters#hasresource]] ]</sub>

##### PartValidation
Parameter to provide validation over a vessel's parts.  The PartValidation module can be used in two different modes - simple and extende.  In the simple mode, simply provide the parameters to filter on, as in the following example:

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

For the extended mode, parameters may be group into three types of nodes FILTER, VALIDATE_ALL and NONE.  The blocks are applied in order.  Typically, the FILTER blocks should be placed first.
* FILTER - This will filter the list of parts down to the ones that match the given criteria.
* VALIDATE_ALL - All remaining parts (after filtering) must match the given criteria.
* NONE - None of the remaining parts (after filtering) should match the given criteria.
* VALIDATE - Some of the remaining parts must match (only supports part, minCount and maxCount)

The blocks can contain any of the attributes listed in the simple model, **except** minCount, maxCount and title.

*Examples:*

This validates that all engines must be manufactured by Rockomax, and there must be at least two of them.

    PARAMETER
    {
        name = PartValidation4
        type = PartValidation

        FILTER
        {
            category = Engine
        }

        VALIDATE_ALL
        {
            manufacturer = Rockomax
        }

        minCount = 2
    }

This verifies that all parts that have a reaction wheel must not also have a SAS and must not be manufactured by Nightingale Engineering.

    PARAMETER
    {
        name = PartValidation
        type = PartValidation

        FILTER
        {
            partModule = ModuleReactionWheel
        }

        NONE
        {
            partModule = ModuleSAS
            manufacturer = Nightingale Engineering
        }
    }

This verifies that the listed parts in the given quantities are present.

    PARAMETER
    {
        name = PartValidation
        type = PartValidation

        VALIDATE
        {
            part = fuelTank3-2
            minCount = 1
        }

        VALIDATE
        {
            part = largeSolarPanel
            minCount = 4
        }

        VALIDATE
        {
            part = cupola
            minCount = 2
            maxCount = 2
        }
    }


<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] / [[PartValidation|Parameters#partvalidation]] ]</sub>

##### IsNotVessel
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

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] / [[IsNotVessel|Parameters#isnotvessel]] ]</sub>

##### VesselIsType
Checks the VesselType of the given vessel

    PARAMETER
    {
        name = VesselIsType
        type = VesselIsType

        // Type of vessel to check for.  Valid values are a subset from the
        // VesselType enum:
        //   Base
        //   EVA
        //   Lander
        //   Probe
        //   Rover
        //   Ship
        //   Station
        vesselType = EVA
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] / [[VesselIsType|Parameters#vesselistype]] ]</sub>

##### VesselMass
The VesselMass parameter requires a player's vessel to be within the specified mass range.

    PARAMETER
    {
        name = VesselMass
        type = VesselMass

        // (Optional) Minimum and maximum mass.  Defaults are 0.0
        // and float.MaxValue for (min/max) respectively.
        minMass = 1.0
        maxMass = 10.0

        // Text for the contract parameter.
        // Default = Vessel mass: <mass>
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel Attributes|Parameters#vessel-attributes]] / [[VesselMass|Parameters#vesselmass]] ]</sub>

#### Vessel State
These parameters pertain to the state of a vessel.

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] ]</sub>

##### Docking
Docking parameters require that a vessel docks with another vessel.

    PARAMETER
    {
        name = Docking
        type = Docking

        // The vessel attribute is the *defined* name of the vessel that must
        // participate in the docking event.  This is a name of a vessel
        // defined either with the define attribute of a VesselParameterGroup
        // parameter, or via a SpawnVessel.
        //
        // If this Docking parameter is a child of a VesselParameterGroup
        // parameter, then no more than *one* vessel should be provided (the
        // other is the vessel being tracked under the VesselParameterGroup).
        // If no vessel attributes are provided, the second vessel will match
        // any vessel.
        //
        // If this Docking parameter is NOT a child of a VesselParameterGroup,
        // then *at least one* vessel must be provided.  If only one vessel is
        // provided, then the second vessel will match any vessel.
        vessel = First Vessel to Dock
        vessel = Second Vessel to Dock

        // New defined name by which to refer to the docked vessel.  Use this
        // to chain docking parameters, but require them to be done in a certain
        // order.  Generally this name will never be displayed to the player.
        // (Optional)
        defineDockedVessel = My New Vessel

        // Text for the contract parameter.
        // Default varies depending on the situation.
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] / [[Docking|Parameters#docking]] ]</sub>

##### Orbit
Orbital parameter to specify required orbital details.

    PARAMETER
    {
        name = Orbit
        type = Orbit

        // Target body, defaulted from the contract if not supplied.
        targetBody = Kerbin

        // Situation to check for.  Valid list is a subset of Vessel.Situations:
        //     ESCAPING
        //     ORBITAL (default)
        //     SUB_ORBITAL
        situation = SUB_ORBITAL

        // Minimum orbit altitude in meters.
        // Default = 0
        minAltitude = 100000

        // Maximum orbit altitude in meters.
        // Default = double.MaxValue
        maxAltitude = 250000

        // Minimum apoapsis in meters.
        // Default = 0
        minApA = 100000

        // Maximum apoapsis in meters.
        // Default = double.MaxValue
        maxApA = 250000

        // Minimum periapsis in meters.
        // Default = 0
        minPeA = 100000

        // Maximum periapsis in meters.
        // Default = double.MaxValue
        maxPeA = 250000

        // Minimum eccentricity.
        // Default = 0
        minEccentricity = 0.0

        // Maximum eccentricity.
        // Default = double.MaxValue
        maxEccentricity = 0.1

        // Minimum inclination in degrees
        // Default = 0
        minInclination = 0

        // Maximum inclination in degrees
        // Default = 180
        maxInclination = 1

        // Duration of the minimum orbital period.  Specify values in years (y),
        // days (d), hours (h), minutes (m), seconds (s) or any combination of
        // those.
        minPeriod = 6h 0m 50s

        // Duration of the maximum orbital period.  Specify values in years (y),
        // days (d), hours (h), minutes (m), seconds (s) or any combination of
        // those.
        minPeriod = 6h 0m 52s

        // Text to use for the parameter
        // Default Orbit: <orbit details>
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] / [[Orbit|Parameters#orbit]] ]</sub>

##### ReachState
Checks that the vessel is in a specific state.  Use any combination of the attributes below.

    PARAMETER
    {
        name = ReachState
        type = ReachState

        // Minimum and maximum altitudes.
        minAltitude = 20000
        maxAltitude = 50000

        // Minimum and maximum altitudes above terrain.
        minTerrainAltitude = 500
        maxTerrainAltitude = 1000

        // Minimum and maximum speeds
        minSpeed = 1000
        maxSpeed = 5000

        // The name of the biome to reach.
        biome = Shores

        // Defaulted from the contract
        targetBody = Duna

        // The situation.  Valid values from Vessel.Situations:
        //    ESCAPING
        //    FLYING
        //    LANDED
        //    ORBITING
        //    PRELAUNCH
        //    SPLASHED
        //    SUB_ORBITAL
        situation = FLYING

        // Text to use for the parameter
        // Default Vessel State: <state details>
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] / [[ReachState|Parameters#reachstate]] ]</sub>

##### ReachSpecificOrbit
The ReachSpecificOrbit parameter is used with the [[OrbitGenerator|Behaviours#orbitgenerator]] behaviour to indicate that a generated orbit must be reached by a vessel.

    PARAMETER
    {
        name = ReachSpecificOrbit
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

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] / [[ReachSpecificOrbit|Parameters#reachspecificorbit]] ]</sub>

##### Rendezvous
Rendezvous parameters require that a vessel performs a rendezvous with another vessel.

    PARAMETER
    {
        name = Rendezvous
        type = Rendezvous

        // The vessel attribute is the *defined* name of the vessel that must
        // participate in the rendezvous event.  This is a name of a vessel
        // defined either with the define attribute of a VesselParameterGroup
        // parameter, or via a SpawnVessel.
        //
        // If this Rendezvous parameter is a child of a VesselParameterGroup
        // parameter, then no more than *one* vessel should be provided (the
        // other is the vessel being tracked under the VesselParameterGroup).
        // If no vessel attributes are provided, the second vessel will match
        // any vessel.
        //
        // If this Rendezvous parameter is NOT a child of a VesselParameterGroup,
        // then *at least one* vessel must be provided.  If only one vessel is
        // provided, then the second vessel will match any vessel.
        vessel = First Vessel to Rendezvous
        vessel = Second Vessel to Rendezvous

        // Distance in meters that defines a rendezvous as having occurred.
        // Default = 2000.0
        distance = 2500.0

        // Text for the contract parameter.
        // Default varies depending on the situation.
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] / [[Rendezvous|Parameters#rendezvous]] ]</sub>

##### ReturnHome
The ReturnHome parameter requires a player to return home (ideally after meeting their other contract objectives).

    PARAMETER
    {
        name = ReturnHome
        type = ReturnHome

        // Text for the contract parameter.
        // Default = Return home.
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] / [[ReturnHome|Parameters#returnhome]] ]</sub>

##### VesselDestroyed
**_NEW!_**
The VesselDestroyed parameter requires that the player destroys their vessel!  Khaaaaan!

    PARAMETER
    {
        name = VesselDestroyed
        type = VesselDestroyed

        // (Optional) Set to true if this vessel must be destroyed by impacting into
        // terrain (and not another vessel or a building).
        // Default = false
        mustImpactTerrain = true

        // Text for the contract parameter.
        // Default varies depending on the situation.
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] / [[VesselDestroyed|Parameters#vesseldestroyed]] ]</sub>

##### VesselNotDestroyed
The VesselNotDestroyed parameter is a negative parameter - it will cause the contract to fail if a specified vessel (or any vessel in some cases) is destroyed.

    PARAMETER
    {
        name = VesselNotDestroyed
        type = VesselNotDestroyed

        // The vessel attribute is the *defined* name of the vessel that should
        // not be destroyed.  This is a name of a vessel defined either with
        // the define attribute of a VesselParameterGroup parameter, or via a
        // SpawnVessel.
        //
        // It can be specified multiple times, and if *no* vessel is specified,
        // then the parameter applies to all vessels.
        //
        // If this parameter is a child of a VesselParameterGroup parameter,
        // and no vessel is provided, *and* the VesselParameterGroup does have
        // vessels specified, then the list of vessels that cannot be destroyed
        // is automatically derived from the parent parameter.
        vessel = First Vessel to Dock
        vessel = Second Vessel to Dock

        // Text for the contract parameter.
        // Default varies depending on the situation.
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel State|Parameters#vessel-state]] / [[VesselNotDestroyed|Parameters#vesselnotdestroyed]] ]</sub>

#### Vessel History
These parameters pertain to the history of a vessel.

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel History|Parameters#vessel-history]] ]</sub>

##### CollectScience
**_NEW!_**
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
        // expirement in stock KSP or added by mods.  The stock list is:
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

        // (Optional) The method for which the science must be recovered.
        // Defaults to None if not specified.
        // Valid values are:
        //    None
        //    Recover
        //    Transmit
        //    RecoverOrTransmit
        recoveryMethod = Recover
    }

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel History|Parameters#vessel-history]] / [[CollectScience|Parameters#collectscience]] ]</sub>

##### VesselHasVisited
The VesselHasVisited parameter requires a player to go to visit a celestial body under specific circumstances.

    PARAMETER
    {
        name = VesselHasVisited
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

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[Vessel History|Parameters#vessel-history]] / [[VesselHasVisited|Parameters#vesselhasvisited]] ]</sub>

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
        vesselKey = CommSat I

        // Whether to check for connectivity or the lack of connectivity.
        // Default = true
        hasConnectivity = true

        // Text to use for the parameter's title.
        // Default = Direct connection to: <vesselKey>
        //title =
    }	

<sub>[ [[Top|Parameters]] ] [ [[Vessel Parameters|Parameters#vessel-parameters]] / [[RemoteTech|Parameters#remotetech]] / [[VesselConnectivity|Parameters#vesselconnectivity]] ]</sub>

### Kerbal Parameters
These are parameters that operate on Kerbals.

<sub>[ [[Top|Parameters]] ] [ [[Kerbal Parameters|Parameters#kerbal-parameters]] ]</sub>

#### BoardAnyVessel
The BoardAnyVessel parameter is met when the named Kerbal boards a vessel (this one is from the Squad "rescue" contracts and is a little bit less useful on its own.

    PARAMETER
    {
        name = BoardAnyVessel
        type = BoardAnyVessel

        // The Kerbal that needs to board a vessel
        kerbal = Jebediah Kermin

        // Alternate method of identifying the Kerbal - zero based index of the
        // entry in a SpawnKerbal or SpawnVessel BEHAVIOUR node.
        //index = 0

        // Text to use for the parameter
        // Default = <kerbal>: Board a vessel
        //title =
    }

<sub>[ [[Top|Parameters]] ] [ [[Kerbal Parameters|Parameters#kerbal-parameters]] / [[BoardAnyVessel|Parameters#boardanyvessel]] ]</sub>

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

#### LaunchVessel
To meet this parameter, the player simply needs to launch a vessel.

    PARAMETER
    {
        name = LaunchVessel
        type = LaunchVessel
    }

<sub>[ [[Top|Parameters]] ] [ [[Progression Parameters|Parameters#progression-parameters]] / [[LaunchVessel|Parameters#launchvessel]] ]</sub>

#### AltitudeRecord
The AltituteRecord parameter is met when a craft reaches the given altitude on Kerbin.

    PARAMETER
    {
        name = AltitudeRecord
        type = AltitudeRecord
        altitude = 55000
    }

<sub>[ [[Top|Parameters]] ] [ [[Progression Parameters|Parameters#progression-parameters]] / [[AltitudeRecord|Parameters#altituderecord]] ]</sub>

#### ReachSpace
Go to space.

    PARAMETER
    {
        name = ReachSpace
        type = ReachSpace
    }

<sub>[ [[Top|Parameters]] ] [ [[Progression Parameters|Parameters#progression-parameters]] / [[ReachSpace|Parameters#reachspace]] ]</sub>

#### EnterOrbit
The EnterOrbit parameter is met when a craft enters an orbit of the given celestial body.

    PARAMETER
    {
        name = EnterOrbit
        type = EnterOrbit

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

<sub>[ [[Top|Parameters]] ] [ [[Progression Parameters|Parameters#progression-parameters]] / [[EnterOrbit|Parameters#enterorbit]] ]</sub>

#### EnterSOI
The EnterSOI parameter is met when a craft enters the sphere of influence of the given celestial body.

    PARAMETER
    {
        name = EnterSOI
        type = EnterSOI

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

<sub>[ [[Top|Parameters]] ] [ [[Progression Parameters|Parameters#progression-parameters]] / [[EnterSOI|Parameters#entersoi]] ]</sub>

#### LandOnBody
The LandOnBody parameter is met when a craft lands on the given celestial body.

    PARAMETER
    {
        name = LandOnBody
        type = LandOnBody

        // This can be inherited from the the contract type if necessary
        targetBody = Duna
    }

<sub>[ [[Top|Parameters]] ] [ [[Progression Parameters|Parameters#progression-parameters]] / [[LandOnBody|Parameters#landonbody]] ]</sub>

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
The Any parameter is be completed if any one of its child parameters are completed.

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

#### SequenceNode
**_TO BE REMOVED!_**
SequenceNode is obsolete - use the completeInSequence attribute on parameters instead.

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
                name = ReachSituation
                type = ReachSituation

                situation = ORBITING
            }

            PARAMETER
            {
                name = ReachDestination
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

<sub>[ [[Top|Parameters]] ] [ [[Set Parameters|Parameters#set-parameters]] / [[SequenceNode|Parameters#sequencenode]] ]</sub>

### Planetary Parameters

Parameters specific to doing something related to a planetary body.

<sub>[ [[Top|Parameters]] ] [ [[Planetary Parameters|Parameters#planetary-parameters]] ]</sub>

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


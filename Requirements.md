## The REQUIREMENT node

The REQUIREMENT node defines a contract requirement - the pre-requisites that are required for the contract to be offered.

Requirements all follow the same general structure - the following attributes are available for all requirements:

    REQUIREMENT
    {
        // The requirement name is not used, but should be provided to allow
        // for the possibility of other mods modifying contracts via
        // ModuleManager.
        name = Requirement

        // The type defines the type of Requirement.  See below for a list of
        // all supported ContractConfigurator requirements.
        type = ReachSpace

        // The invertRequirement is a logical NOT.  In this example, the
        // requirement becomes that the player must not yet have reached space.
        //
        // Default = false
        invertRequirement = true

        // Most requirements are not checked for active contracts (to
        // prevent the contract from being withdrawn while the player is
        // actively working to complete it).  Use this to change that
        // behaviour.  Note in some cases it's a lot nicer to do that
        // as a PARAMETER so the player knows what's required of them.
        //
        // Default = mostly false, true for a few requirements
        checkOnActiveContract = true
    }

The following requirements are natively supported by ContractConfigurator:

* [[Progress Based Requirements|Requirements#progress-based-requirements]]
  * [[BaseConstruction|Requirements#baseconstruction]]
  * [[Docking|Requirements#docking]]
  * [[Escape|Requirements#escape]]
  * [[FlyBy|Requirements#flyby]]
  * [[Landing|Requirements#landing]]
  * [[Orbit|Requirements#orbit]]
  * [[Rendezvous|Requirements#rendezvous]]
  * [[ReturnFromFlyBy|Requirements#returnfromflyby]]
  * [[ReturnFromOrbit|Requirements#returnfromorbit]]
  * [[ReturnFromSurface|Requirements#returnfromsurface]]
  * [[SplashDown|Requirements#splashdown]]
  * [[SurfaceEVA|Requirements#surfaceeva]]
  * [[AltitudeRecord|Requirements#altituderecord]]
  * [[FirstCrewToSurvive|Requirements#firstcrewtosurvive]]
  * [[FirstLaunch|Requirements#firstlaunch]]
  * [[KSCLanding|Requirements#ksclanding]]
  * [[RunwayLanding|Requirements#runwaylanding]]
  * [[ReachSpace|Requirements#reachspace]]
  * [[SpaceCrewTransfer|Requirements#spacecrewtransfer]]
  * [[Spacewalk|Requirements#spacewalk]]
* [[Research Based Requirements|Requirements#research-based-requirements]]
  * [[PartUnlocked|Requirements#partunlocked]]
  * [[PartModuleUnlocked|Requirements#partmoduleunlocked]]
  * [[PartModuleTypeUnlocked|Requirements#partmoduletypeunlocked]]
  * [[TechResearched|Requirements#techresearched]]
* [[RemoteTech Requirements|Requirements#remotetech-requirements]]
  * [[ActiveVesselRange|Requirements#activevesselrange]]
  * [[CelestialBodyCoverage|Requirements#celestialbodycoverage]]
* [[Space Program Requirements|Requirements#space-program-requirements]]
  * [[HasCrew|Requirements#hascrew]]
  * [[Facility|Requirements#facility]]
  * [[Funds|Requirements#funds]]
  * [[Reputation|Requirements#reputation]]
  * [[Science|Requirements#science]]
* [[Contract Based Requirements|Requirements#contract-based-requirements]]
  * [[CompleteContract|Requirements#completecontract]]
* [[Planetary Requirements|Requirements#planetary-requirements]]
  * [[SCANsatCoverage|Requirements#scansatcoverage]]
  * [[SCANsatLocationCoverage|Requirements#scansatlocationcoverage]]
* [[Miscellaneous Requirements|Requirements#miscellaneous-requirements]]
  * [[Expression|Requirements#expression]]
* [[Set Requirements|Requirements#set-requirements]]
  * [[Any|Requirements#any]]
  * [[All|Requirements#all]]

### Progress Based Requirements

#### BaseConstruction
Requirement for having built a base.

_Note that this is based on the stock ProgressNode - I'm not 100% sure what they do and do not consider a 'base'_.

    REQUIREMENT
    {
        name = BaseConstruction
        type = BaseConstruction

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Docking
Requirement for completing a docking at the specified celestial body.

    REQUIREMENT
    {
        name = Docking
        type = Docking

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Escape
Requirement for having escaped the specified celestial body.

    REQUIREMENT
    {
        name = Escape
        type = Escape

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### FlyBy
Requirement for performing a fly-by of the specified celestial body.

    REQUIREMENT
    {
        name = FlyBy
        type = FlyBy

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Landing
Requirement for landing on the specified celestial body.

    REQUIREMENT
    {
        name = Landing
        type = Landing

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Orbit
Requirement for orbiting the specified celestial body.

    REQUIREMENT
    {
        name = Orbit
        type = Orbit

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Rendezvous
Requirement for completing a rendezvous near the specified celestial body.

    REQUIREMENT
    {
        name = Rendezvous
        type = Rendezvous

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### ReturnFromFlyBy
Requirement for returning from a fly-by of the specified celestial body.

    REQUIREMENT
    {
        name = ReturnFromFlyBy
        type = ReturnFromFlyBy

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### ReturnFromOrbit
Requirement for returning from orbit of the specified celestial body.

    REQUIREMENT
    {
        name = ReturnFromOrbit
        type = ReturnFromOrbit

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### ReturnFromSurface
Requirement for returning from orbit of the specified celestial body.

    REQUIREMENT
    {
        name = ReturnFromSurface
        type = ReturnFromSurface

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Duna
    }

#### SplashDown
Requirement for splashing down on the specified celestial body.

    REQUIREMENT
    {
        name = SplashDown
        type = SplashDown

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### SurfaceEVA
Requirement for completing a surface EVA on the specified celestial body.

    REQUIREMENT
    {
        name = SurfaceEVA
        type = SurfaceEVA

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### AltitudeRecord
Requirement for having reached a minimum launch altitude.

    REQUIREMENT
    {
        name = AltitudeRecord
        type = AltitudeRecord

        // Minimum altitude that must have been reached
        minAltitude = 30000
    }

#### FirstCrewToSurvive
Requirement for having had a crew return successfully.

    REQUIREMENT
    {
        name = FirstCrewToSurvive
        type = FirstCrewToSurvive
    }

#### FirstLaunch
Requirement for having made the first launch.

    REQUIREMENT
    {
        name = FirstLaunch
        type = FirstLaunch
    }

#### KSCLanding
Requirement for having landed at the KSC.

    REQUIREMENT
    {
        name = KSCLanding
        type = KSCLanding
    }

#### RunwayLanding
Requirement for having landed on the runway.

    REQUIREMENT
    {
        name = RunwayLanding
        type = RunwayLanding
    }

#### ReachSpace
Requirement for having reached space.

    REQUIREMENT
    {
        name = ReachSpace
        type = ReachSpace
    }

#### SpaceCrewTransfer
Requirement for having done a crew transfer in space.

    REQUIREMENT
    {
        name = SpaceCrewTransfer
        type = SpaceCrewTransfer
    }

#### Spacewalk
Requirement for having done a spacewalk.

    REQUIREMENT
    {
        name = Spacewalk
        type = Spacewalk
    }

### Research Based Requirements

#### PartUnlocked
Requirement for having a certain part unlocked from the tech tree.

    REQUIREMENT
    {
        name = PartUnlocked
        type = PartUnlocked

        // Part name that needs to be unlocked.
        part = SmallGearBay
    }

#### PartModuleUnlocked
Requirement for having any part with the given PartModule unlocked from the tech tree.

    REQUIREMENT
    {
        name = PartModuleUnlocked
        type = PartModuleUnlocked

        // PartModule that needs to be unlocked.
        partModule = ModuleReactionWheel
    }

#### PartModuleTypeUnlocked
Requirement for having a "type" of PartModule unlocked from the tech tree.

    REQUIREMENT
    {
        name = PartModuleTypeUnlocked
        type = PartModuleTypeUnlocked

        // Type of PartModule that needs to be unlocked.  Can be specified
        // multiple times.  Valid values are defined in
        // Squad/Contracts/Contracts.cfg under MODULE_DEFINITIONS:
        //   Antenna
        //   Dock
        //   Grapple
        //   Power
        //   Wheel
        partModuleType = Antenna
        partModuleType = Power
    }

#### TechResearched
Requirement for having researched a technology.

    REQUIREMENT
    {
        name = TechResearched
        type = TechResearched

        // The technology that needs to have been researched.  Take special note that
        // this does not get validated - if you make a typo, the requirement will
        // always return false.
        tech = basicRocketry
    }

### RemoteTech Requirements
These are requirementsthat are specific to the RemoteTech module.

#### ActiveVesselRange
The ActiveVesselRange requirement checks that the given celestial body has a satellite with sufficient range (achievable either via an omni antenna or dish set to active vessel).

    REQUIREMENT
    {
        name = ActiveVesselRange
        type = ActiveVesselRange

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Kerbin

        // The range that is required, in meters.
        range = 48000000
    }

#### CelestialBodyCoverage
The CelestialBodyCoverage requirement checks that the given celestial body has a dish pointed to it with sufficient range.

    REQUIREMENT
    {
        name = CelestialBodyCoverage
        type = CelestialBodyCoverage

        // Minimum coverage that is required (between 0.0 and 1.0).
        // Default = 1.0
        minCoverage = 0.8

        // Maximum coverage before requirement no longer met (between 0.0 and 1.0).
        // Default = 1.0
        maxCoverage = 1.0

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Duna
    }

### Space Program Requirements

#### HasCrew
Requirement that checks whether the player has Kerbals in their crew matching the given criteria.

    REQUIREMENT
    {
        name = HasCrew
        type = HasCrew

        // (Optional) The type of trait required.  Valid values are:
        //    Pilot
        //    Engineer
        //    Scientist
        trait = Engineer

        // (Optional) Minimum and maximum experience level.  Default values are
        // 0 and 5 (for min/max).
        minExperience = 2
        maxExperience = 5

        // (Optional) Minimum and maximum count.  Default values are 1 and
        // int.MaxValue (for min/max).
        minCount = 1
        maxCount = 5
    }

#### Facility
Requirement that checks whether the player has the given facility upgraded (or not upgraded) to the specified level.

    REQUIREMENT
    {
        name = Facility
        type = Facility

        // The facility.  Valid values are:
        //    LaunchPad
        //    Runway
        //    VehicleAssemblyBuilding
        //    SpaceplaneHangar
        //    TrackingStation
        //    AstronautComplex
        //    MissionControl
        //    ResearchAndDevelopment
        //    Administration
        facility = Administration

        // (Optional) Minimum and maximum facility level.  Default values are
        // 0 and 2 (for min/max).
        minLevel = 2
        maxLevel = 2
    }

#### Funds
Requirement that checks whether the player has enough (or not too much) funds.

    REQUIREMENT
    {
        name = Funds
        type = Funds

        // Minimum amount of funds the player must have before this contract
        // can show up.
        // Default = 0.0
        minFunds = 100000

        // Maximum amount of funds the player can have before this contract
        // no longer shows up.
        // Default = double.MaxValue
        maxFunds = 1000000
    }

#### Reputation
Requirement that checks whether the player has enough (or not too much) reputation.

    REQUIREMENT
    {
        name = Reputation
        type = Reputation

        // Minimum amount of reputation the player must have before this
        // contract can show up.
        // Default = -1000.0
        minReputation = 0

        // Maximum amount of reputation the player can have before this
        // contract no longer shows up.
        // Default = 1000.0
        maxReputation = 500.0
    }

#### Science
Requirement that checks whether the player has enough (or not too much) science.

    REQUIREMENT
    {
        name = Science
        type = Science

        // Minimum amount of science the player must have before this contract
        // can show up.
        // Default = 0.0
        minScience = 100

        // Maximum amount of science the player can have before this contract
        // no longer shows up.
        // Default = float.MaxValue
        maxScience = 10000
    }

### Contract Based Requirements

#### CompleteContract
Requirement for having a certain number of contracts completed of the given type.

    REQUIREMENT
    {
        name = CompleteContract
        type = CompleteContract

        // The type of contract being checked.  This can either be a
        // ContractConfigurator contract type or a standard contract type (class).
        contractType = SimpleTestContract

        // The minimum number of times the given contract type must have been
        // completed before the requirement is met.
        // Default = 1
        minCount = 1

        // The maximum number of times the given contract type can be completed
        // before the requirement will no longer be met.
        // Default = Infinite
        maxCount = 5

        // The amount of time after the last instance of the contract was
        // complete before we can attempt again. Can specify
        // values in years (y), days (d), hours (h), minutes (m), seconds (s)
        // or any combination of those.
        cooldownDuration = 10d
    }

### Planetary Requirements

#### SCANsatCoverage
Requirement for having a certain level of SCANsat coverage for the given scan type/planet.

    REQUIREMENT:NEEDS[SCANsat]
    {
        name = SCANsatCoverage
        type = SCANsatCoverage

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Kerbin

        // Minimum coverage that must be reached before the contract is valid.
        // Default = 0.0
        minCoverage = 0.0

        // Maximum coverage that must be reached before the contract is valid.
        // Default = 100.0
        maxCoverage = 0.0

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

#### SCANsatLocationCoverage
Requirement for having a specific location covered for the given scan type/planet.

    REQUIREMENT:NEEDS[SCANsat]
    {
        name = SCANsatLocationCoverage
        type = SCANsatLocationCoverage

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Kerbin

        // Define the location via latitude/longitude...
        latitude = -0.102668048654
        longitude = -74.5753856554

        // ...OR via a PQSCity location (but not both)
        pqsCity = Monolith00

        // The type of scan to perform.  Valid values are from SCANdata.SCANtype.
        // Some possible values are:
        //    AltimetryLoRes
        //    AltimetryHiRes
        //    Altimetry
        //    Biome
        //    Anomaly (default)
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

### Miscellaneous Requirements

#### Expression
Requirement that executes an expression to check whether the requirement is met.  Can access data in the persistent data store.

    REQUIREMENT
    {
        name = Expression
        type = Expression

        // The expression to be executed is in the expression field.  It supports
        // arithmetic operators (+, -, *, /), boolean operators (&&, ||, !),
        // comparisons (<, <=, ==, !=, >=, >) and parenthesis.  It is able to
        // access data in the persistent data store.
        expression = CC_EXPTEST_Success == 1 || !CC_TestVal
    }

### Set Requirements

#### Any
If any child requirement is met, then the requirement is met.

    REQUIREMENT
    {
        name = Any
        type = Any

        REQUIREMENT
        {
            name = ReachSpace
            type = ReachSpace
        }

        REQUIREMENT
        {
            name = TechResearched
            type = TechResearched

            tech = basicRocketry
        }
    }

#### All
If all child requirements are met, then the requirement is met.

    REQUIREMENT
    {
        name = All
        type = All

        REQUIREMENT
        {
            name = ReachSpace
            type = ReachSpace
        }

        REQUIREMENT
        {
            name = TechResearched
            type = TechResearched

            tech = basicRocketry
        }
    }

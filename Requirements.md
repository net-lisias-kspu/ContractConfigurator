## The REQUIREMENT node

The REQUIREMENT node defines a contract requirement - the pre-requisites that are required for the contract to be offered.

The following requirements are natively supported by ContractConfigurator:

* [[Progress Based requirements|Requirements#progress-based-requirements]]
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
* [[Research based requirements|Requirements#research-based-requirements]]
 * [[PartUnlocked|Requirements#partunlocked]]
 * [[PartModuleUnlocked|Requirements#partmoduleunlocked]]
 * [[TechResearched|Requirements#techresearched]]
* [[Space Program requirements|Requirements#space-program-requirements]]
 * [[HasCrew|Requirements#hascrew]]
 * [[Facility|Requirements#facility]]
 * [[Funds|Requirements#funds]]
 * [[Reputation|Requirements#reputation]]
 * [[Science|Requirements#science]]
* [[Contract based requirements|Requirements#contract-based-requirements]]
 * [[CompleteContract|Requirements#completecontract]]
* [[Planetary requirements|Requirements#planetary-requirements]]
 * [[SCANsatCoverage|Requirements#scansatcoverage]]
* [[Miscellaneous requirements|Requirements#miscellaneous-requirements]]
 * [[Expression|Requirements#expression]]
* [[Set requirements|Requirements#set-requirements]]
 * [[Any|Requirements#any]]
 * [[All|Requirements#all]]

### Progress Based requirements

#### BaseConstruction
Requirement for having built a base.

_Note that this is based on the stock ProgressNode - I'm not 100% sure what they do and do not consider a 'base'_.

    REQUIREMENT
    {
        name = BaseConstruction1
        type = BaseConstruction

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Docking
Requirement for completing a docking at the specified celestial body.

    REQUIREMENT
    {
        name = Docking1
        type = Docking

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Escape
Requirement for having escaped the specified celestial body.

    REQUIREMENT
    {
        name = Escape1
        type = Escape

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### FlyBy
Requirement for performing a fly-by of the specified celestial body.

    REQUIREMENT
    {
        name = FlyBy1
        type = FlyBy

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Landing
Requirement for landing on the specified celestial body.

    REQUIREMENT
    {
        name = Landing1
        type = Landing

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Orbit
Requirement for orbiting the specified celestial body.

    REQUIREMENT
    {
        name = Orbit1
        type = Orbit

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### Rendezvous
Requirement for completing a rendezvous near the specified celestial body.

    REQUIREMENT
    {
        name = Rendezvous1
        type = Rendezvous

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### ReturnFromFlyBy
Requirement for returning from a fly-by of the specified celestial body.

    REQUIREMENT
    {
        name = ReturnFromFlyBy1
        type = ReturnFromFlyBy

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### ReturnFromOrbit
Requirement for returning from orbit of the specified celestial body.

    REQUIREMENT
    {
        name = ReturnFromOrbit1
        type = ReturnFromOrbit

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### ReturnFromSurface
Requirement for returning from orbit of the specified celestial body.

    REQUIREMENT
    {
        name = ReturnFromSurface1
        type = ReturnFromSurface

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Duna
    }

#### SplashDown
Requirement for splashing down on the specified celestial body.

    REQUIREMENT
    {
        name = SplashDown1
        type = SplashDown

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### SurfaceEVA
Requirement for completing a surface EVA on the specified celestial body.

    REQUIREMENT
    {
        name = SurfaceEVA1
        type = SurfaceEVA

        // Target celestial body.  Defaults to the targetBody of the contract.
        targetBody = Kerbin
    }

#### AltitudeRecord
Requirement for having reached a minimum launch altitude.

    REQUIREMENT
    {
        name = AltitudeRecord1
        type = AltitudeRecord

        // Minimum altitude that must have been reached
        minAltitude = 30000
    }

#### FirstCrewToSurvive
Requirement for having had a crew return successfully.

    REQUIREMENT
    {
        name = FirstCrewToSurvive1
        type = FirstCrewToSurvive
    }

#### FirstLaunch
Requirement for having made the first launch.

    REQUIREMENT
    {
        name = FirstLaunch1
        type = FirstLaunch
    }

#### KSCLanding
Requirement for having landed at the KSC.

    REQUIREMENT
    {
        name = KSCLanding1
        type = KSCLanding
    }

#### RunwayLanding
Requirement for having landed on the runway.

    REQUIREMENT
    {
        name = RunwayLanding1
        type = RunwayLanding
    }

#### ReachSpace
Requirement for having reached space.

    REQUIREMENT
    {
        name = ReachSpace1
        type = ReachSpace
    }

#### SpaceCrewTransfer
Requirement for having done a crew transfer in space.

    REQUIREMENT
    {
        name = SpaceCrewTransfer1
        type = SpaceCrewTransfer
    }

#### Spacewalk
Requirement for having done a spacewalk.

    REQUIREMENT
    {
        name = Spacewalk1
        type = Spacewalk
    }

### Research based requirements

#### PartUnlocked
Requirement for having a certain part unlocked from the tech tree.

    REQUIREMENT
    {
        name = PartUnlocked1
        type = PartUnlocked

        // Part name that needs to be unlocked.
        part = SmallGearBay
    }

#### PartModuleUnlocked
Requirement for having any part with the given PartModule unlocked from the tech tree.

    REQUIREMENT
    {
        name = PartModule Unlocked1
        type = PartModuleUnlocked

        // PartModule that needs to be unlocked.
        partModule = ModuleReactionWheel
    }

#### TechResearched
Requirement for having researched a technology.

    REQUIREMENT
    {
        name = TechResearched1
        type = TechResearched

        // The technology that needs to have been researched.  Take special note that
        // this does not get validated - if you make a typo, the requirement will
        // always return false.
        tech = basicRocketry
    }

### Space Program requirements

#### HasCrew
**_NEW!_**
Requirement that checks whether the player has Kerbals in their crew matching the given criteria.

    REQUIREMENT
    {
        name = HasCrew1
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
**_NEW!_**
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
**_NEW!_**
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
**_NEW!_**
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
**_NEW!_**
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

### Contract based requirements

#### CompleteContract
Requirement for having a certain number of contracts completed of the given type.

    REQUIREMENT
    {
        name = CompleteContract1
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

### Planetary requirements

#### SCANsatCoverage
**_NEW!_**
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

### Miscellaneous requirements

#### Expression
Requirement that executes an expression to check whether the requirement is met.  Can access data in the persistent data store.

    REQUIREMENT
    {
        name = Expression1
        type = Expression

        // The expression to be executed is in the expression field.  It supports
        // arithmetic operators (+, -, *, /), boolean operators (&&, ||, !),
        // comparisons (<, <=, ==, !=, >=, >) and parenthesis.  It is able to
        // access data in the persistent data store.
        expression = CC_EXPTEST_Success == 1 || !CC_TestVal
    }

### Set requirements

#### Any
If any child requirement is met, then the requirement is met.

    REQUIREMENT
    {
        name = Any1
        type = Any

        REQUIREMENT
        {
            name = ReachSpace1
            type = ReachSpace
        }

        REQUIREMENT
        {
            name = TechResearched1
            type = TechResearched

            tech = basicRocketry
        }
    }

#### All
If all child requirements are met, then the requirement is met.

    REQUIREMENT
    {
        name = All1
        type = All

        REQUIREMENT
        {
            name = ReachSpace1
            type = ReachSpace
        }

        REQUIREMENT
        {
            name = TechResearched1
            type = TechResearched

            tech = basicRocketry
        }
    }
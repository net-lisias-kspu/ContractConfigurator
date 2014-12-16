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
* [[Contract based requirements|Requirements#contract-based-requirements]]
 * [[CompleteContract|Requirements#completecontract]]
* [[Miscellaneous requirements|Requirements#miscellaneous-requirements]]
 * [[Expression|Requirements#expression]]
 * [[HasKerbal|Requirements#haskerbal]]
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

        // NEW!
        // The amount of time after the last instance of the contract was
        // complete before we can attempt again. Can specify
        // values in years (y), days (d), hours (h), minutes (m), seconds (s)
        // or any combination of those.
        cooldownDuration = 10d
    }

### Miscellaneous requirements

#### Expression
**_NEW!_** 
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

#### HasKerbal
**_COMING SOON!_**
Requirement that checks whether the player has Kerbals in their crew matching the given criteria.

    REQUIREMENT
    {
        name = HasKerbal1
        type = HasKerbal

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

## The BEHAVIOUR node

The BEHAVIOUR node defines a contract behaviour - any behaviour that is at the contract level.  These can provide functionality for parameters, be used to persist data from contract to contract or any number of other things.

The following behaviours are natively supported by ContractConfigurator:

* [[ExperimentalPart|Behaviours#experimentalpart]]
* [[Expression|Behaviours#expression]]
* [[OrbitGenerator|Behaviours#orbitgenerator]]
* [[Message|Behaviours#message]]
* [[SpawnKerbal|Behaviours#spawnkerbal]]
* [[SpawnPassengers|Behaviours#spawnpassengers]]
* [[SpawnVessel|Behaviours#spawnvessel]]
* [[WaypointGenerator|Behaviours#waypointgenerator]]

### ExperimentalPart
Behaviour for adding and removing experimental parts.

    BEHAVIOUR
    {
        name = ExperimentalPart
        type = ExperimentalPart

        // The name of the part to add/remove.  Can be specified multiple
        // times.
        part = largeSolarPanel
        part = cupola

        // Whether the part should be added as an experimental part (when the
        // contract is accepted).  Also controls whether the part is removed
        // if the contract fails or is withdrawn.
        // Default = True
        add = True

        // Whether the part should be removed as an experimental part (when the
        // contract completes successfully).
        // Default = True
        remove = True

    }

<sub>[ [[Top|Behaviours]] ] [ [[ExperimentalPart|Behaviours#experimentalpart]] ]</sub>

### Expression
Behaviour for executing one or more expressions and storing the results in the persistent data store.

    BEHAVIOUR
    {
        name = Expression
        type = Expression

        // The CONTRACT_ACCEPTED node gets executed when the contract is
        // accepted.
        CONTRACT_ACCEPTED
        {
            // Expressions can use arithmatic operators (+, -, *, /)
            // and parenthesis.
            CC_TestVal = 10 * 2 - 3 * 4
        }

        // The CONTRACT_COMPLETED_SUCCESS node gets executed when the
        // contract is completed successfully.
        CONTRACT_COMPLETED_SUCCESS
        {
            // Multiple expressions may be supplied in one node
            CC_TestVal = CC_TestVal * 2
            CC_EXPTEST_Success = 1
        }

        // The CONTRACT_COMPLETED_FAILURE node gets executed when the
        // contract fails, is withdrawn or the deadline expires.
        CONTRACT_COMPLETED_FAILURE
        {
            CC_TestVal = CC_TestVal / 2
            CC_EXPTEST_Success = 0
        }

        // The PARAMETER_COMPLETED node gets executed when a parameter
        // is successfully completed.
        PARAMETER_COMPLETED
        {
            // Supply the name of the parameter
            parameter = SomeParameter

            CC_TestVal = 100
        }
    }

<sub>[ [[Top|Behaviours]] ] [ [[Expression|Behaviours#expression]] ]</sub>

### OrbitGenerator
Behaviour for generating orbits.

    BEHAVIOUR
    {
        name = OrbitGenerator
        type = OrbitGenerator

        // Use this to generate an orbit with specific parameters
        FIXED_ORBIT
        {
            // Body for the orbit - defaulted from the contract if not supplied
            targetBody = Kerbin

            // Actual orbit details. Note that REF represents the reference
            // body - but will be overriden by the targetBody.
            ORBIT
            {
                SMA = 1449999.99996286
                ECC = 1.07570816555399E-05
                INC = 0
                LPE = 270.690311604893
                LAN = 1.93635924563296
                MNA = 1.55872660382504
                EPH = 31.3999999999994
                REF = 1
            }
        }

        // Use this to generate an orbit with some randomization
        RANDOM_ORBIT
        {
            // Body for the orbit - defaulted from the contract if not supplied
            targetBody = Kerbin

            // Type of orbit to generate.  Valid values are from
            // FinePrint.Utilities.OrbitType:
            //    EQUATORIAL
            //    KOLNIYA
            //    POLAR
            //    RANDOM
            //    STATIONARY
            //    SYNCHRONOUS
            //    TUNDRA
            type = KOLNIYA

            // Difficulty multiplier - generally makes the orbits harder to
            // reach if you increase it.
            // Default = 1.0
            difficulty = 10.0
        }
    }

<sub>[ [[Top|Behaviours]] ] [ [[OrbitGenerator|Behaviours#orbitgenerator]] ]</sub>

### Message
Behaviour for displaying a message within the messaging system in the top right corner.

    BEHAVIOUR
    {
        name = Message
        type = Message

        // Title of the message.  This will be displayed in the title bar.
        title = A message

        // The actual message, can be more or less as long as desired.
        message = This is a message that informs the player of something.

        // Conditions on which the message will be displayed, can have multiple
        // conditions, and the message will get displayed once for *each*
        // condition.
        CONDITION
        {
            // The type of condition, valid values in Message.Condition, and
            // are:
            //    CONTRACT_COMPLETED
            //    CONTRACT_FAILED
            //    PARAMETER_COMPLETED
            //    PARAMETER_FAILED
            condition = PARAMETER_COMPLETED

            // The *name* of the parameter to which this condition applies.
            // Required if the condition is one of the PARAMETER_ ones.
            parameter = MyParameterName
        }
    }

<sub>[ [[Top|Behaviours]] ] [ [[Message|Behaviours#message]] ]</sub>

### SpawnKerbal
Behaviour for spawning one or more Kerbals on land or in orbit.

    BEHAVIOUR
    {
        name = SpawnKerbal
        type = SpawnKerbal

        // The KERBAL node indicates a Kerbal to spawn and can be specified
        // multiple times.
        KERBAL
        {
            // If the name is not supplied, one will be autogenerated by KSP.
            name = Kerbediah Kerman

            // Whether the Kerbal should show up as owned or unowned.  If it is
            // owned, then it will be immediately selectable.
            // Default = false
            owned = true

            // Whether the Kerbal should get added to the roster on recovery.
            // Default = true
            addToRoster = true

            // Where the Kerbal should spawn - defaulted from the contract if
            // not supplied.
            targetBody = Kerbin

            // The ORBIT node indicates the orbit the Kerbal is in.  The
            // easiest way to get this information is to create the orbit
            // you want in KSP (using HyperEdit or good old fashioned
            // rocket science), and save your game.  In the persistant.sfs
            // file, search for your craft, and find the ORBIT node.
            //
            // Note that REF represents the reference body - but will be
            // overriden by the targetBody.
            ORBIT
            {
                SMA = 1449999.99996286
                ECC = 1.07570816555399E-05
                INC = 0
                LPE = 270.690311604893
                LAN = 1.93635924563296
                MNA = 1.55872660382504
                EPH = 31.3999999999994
                REF = 1
            }

            // If you wish to specify a landed Kerbal, you must also 
            // supply ALL of the following values from the persistant.sfs
            // file.  The orbit information is not needed for landed
            // Kerbals.
            lat = 10.595910968977
            lon = 239.804476675472
            alt = 387.929475510377

            // The location name
            pqsCity = KSC

            // An optional offset vector from the center of the PQS City.
            // Use this to make your Kerbal relative to the PQS City,
            // which will make it work even for RSS or other mods that may
            // move the PQS city.  To get the offset coordinates, position
            // your ship/kerbal at the desired location and go to the
            // Location tab in the Contract Configurator debug window
            // (alt-F10).
            pqsOffset = 447.307865750742, 5.14341771520321E-05, 24.9700656982985
        }
    }

<sub>[ [[Top|Behaviours]] ] [ [[SpawnKerbal|Behaviours#spawnkerbal]] ]</sub>

### SpawnPassengers
**_NEW!_**
Behaviour for spawning passengers on board vessels.

    BEHAVIOUR
    {
        name = SpawnPassengers
        type = SpawnPassengers

        // Count of passengers to spawn.
        // Default = 1
        count = 10
        
        // Names of passengers to spawn (use instead of count to spawn
        // passengers with specific names.
        passengerName = Kerman Kerman
    }


<sub>[ [[Top|Behaviours]] ] [ [[SpawnPassengers|Behaviours#spawnpassengers]] ]</sub>

### SpawnVessel
Behaviour for spawning one or more Vessels on land or in orbit.

    BEHAVIOUR
    {
        name = SpawnVessel
        type = SpawnVessel

        // The VESSEL node indicates a vessel to spawn and can be specified
        // multiple times.
        VESSEL
        {
            // If the name is not supplied, defaults from the name within the
            // craft file.  Note that this name behaves like the
            // VesselParameterGroup define field - in other words, you may
            // refer back to this vessel by this name in VesselParameterGroup
            // parameters.
            name = A vessel

            // Path to the .craft file (relative to the GameData/ directory)
            craftURL = ContractConfigurator/Little Rocket.craft

            // Location of the flag to use.
            // Default = Player's flag for the current game
            flagURL = Squad/Flags/satellite

            // The type of vessel (affects display in the tracking station).
            // Valid values from VesselType enum:
            // Base
            // Lander
            // Probe
            // Rover
            // Ship (default)
            // Station
            // Unknown
            vesselType = Rover

            // Whether the vessel should show up as owned or unowned.  If it is
            // owned, then it will be immediately selectable.
            owned = False

            // Where the vessel should spawn - defaulted from the contract if
            // not supplied.
            targetBody = Kerbin

            // The ORBIT node indicates the orbit the vessel is in.  The
            // easiest way to get this information is to create the orbit
            // you want in KSP (using HyperEdit or good old fashioned
            // rocket science), and save your game.  In the persistant.sfs
            // file, search for your craft, and find the ORBIT node.
            //
            // Note that REF represents the reference body - but will be
            // overriden by the targetBody.
            ORBIT
            {
                SMA = 1449999.99996286
                ECC = 1.07570816555399E-05
                INC = 0
                LPE = 270.690311604893
                LAN = 1.93635924563296
                MNA = 1.55872660382504
                EPH = 31.3999999999994
                REF = 1
            }

            // If you wish to specify a landed vessel, you must also 
            // supply ALL of the following values from the persistant.sfs
            // file, AS WELL AS including the ORBIT node above.  In a
            // future release, I may try to look at ways to do it using
            // only lat-lon, but it's much more complicated, so it's not
            // a high priority...
			lat = -0.096992729723051
			lon = 285.425467968966
			alt = 67.6843734193826

            // A CREW node indicates one or more crew members to add to the
            // vessel.  The CREW node may be specified multiple times.
            CREW
            {
                // Name for the crew member - if not provided, one is
                // auto-generated.
                name = Patrick R. Kerman

                // Whether or not the Kerbal should be added to the roster on 
                // recovery.
                // Default = True
                addToRoster = True

                // Number of crew to generate from this node.  Shouldn't be
                // supplied if name is supplied.
                // Default = 1
                count = 1
            }
        }
    }

<sub>[ [[Top|Behaviours]] ] [ [[SpawnVessel|Behaviours#spawnvessel]] ]</sub>

### WaypointGenerator
Behaviour for generating waypoints.

    BEHAVIOUR
    {
        name = WaypointGenerator
        type = WaypointGenerator

        // Use this to generate a waypoint with fixed coordinates
        WAYPOINT
        {
            // The name of the waypoint - displayed on the marker.  If not
            // supplied a random one is generated.
            name = Kerbal Space Center

            // Body for the waypoint - defaulted from the contract if not
            // supplied.
            targetBody = Kerbin

            // The icon to use when displaying the waypoint.  If the path
            // is not specified, the Squad/Contracts/Icons directory is
            // assumed.  Otherwise, the path must be from GameData/
            icon = thermometer

            // The altitude of the waypoint.
            // Default: A random value between 0.0 and the atmosphere ceiling.
            // If there's no atmosphere, then always 0.0
            altitude = 0.0

            // The coordinates.
            latitude = -0.102668048654
            longitude = -74.5753856554
        }

        // Use this to generate a waypoint with random coordinates
        RANDOM_WAYPOINT
        {
            // The name of the waypoint - displayed on the marker
            name = A waypoint on Kerbin

            // Body for the waypoint - defaulted from the contract if not
            // supplied.
            targetBody = Kerbin

            // The number of waypoints to generate.
            // Default = 1
            count = 1

            // The icon to use when displaying the waypoint.  If the path
            // is not specified, the Squad/Contracts/Icons directory is
            // assumed.  Otherwise, the path must be from GameData/
            icon = thermometer

            // The altitude of the waypoint.
            // Default: A random value between 0.0 and the atmosphere ceiling.
            // If there's no atmosphere, then always 0.0
            altitude = 0.0

            // Whether the waypoint generated can be on water
            // Default = true
            waterAllowed = false

            // Force the waypoint to fall along the equator.  For boring
            // contracts.
            // Default = false
            forceEquatorial = false
        }

        // Use this to generate a waypoint with random coordinates, but near
        // another waypoint.
        RANDOM_WAYPOINT_NEAR
        {
            // The name of the waypoint - displayed on the marker
            name = A waypoint near something

            // Body for the waypoint - defaulted from the contract if not
            // supplied.
            targetBody = Kerbin

            // The number of waypoints to generate.
            // Default = 1
            count = 2

            // The icon to use when displaying the waypoint.  If the path
            // is not specified, the Squad/Contracts/Icons directory is
            // assumed.  Otherwise, the path must be from GameData/
            icon = thermometer

            // The altitude of the waypoint.
            // Default: A random value between 0.0 and the atmosphere ceiling.
            // If there's no atmosphere, then always 0.0
            altitude = 0.0

            // Whether the waypoint generated can be on water
            // Default = true
            waterAllowed = false

            // Zero based index of the waypoint to generate near.  Must be a
            // waypoint with index < this waypoint.  Start counting from the
            // first waypoint in the BEHAVIOUR, and count 1 for each value of
            // the count parameter (if it exists).
            nearIndex = 1

            // Maximum distance in meters from the 'near' waypoint.
            nearDistance = 25000.0
        }

        // Use this to generate a waypoint with fixed coordinates, based on a
        // PQSCity object.
        PQS_CITY
        {
            // The name of the waypoint - displayed on the marker
            name = Monolith

            // Body for the waypoint - defaulted from the contract if not
            // supplied.
            targetBody = Kerbin

            // The icon to use when displaying the waypoint.  If the path
            // is not specified, the Squad/Contracts/Icons directory is
            // assumed.  Otherwise, the path must be from GameData/
            icon = thermometer

            // The location name
            pqsCity = KSC

            // An optional offset vector from the center of the PQS City.
            // Use this to make your waypoint relative to the PQS City,
            // which will make it work even for RSS or other mods that may
            // move the PQS city.  To get the offset coordinates, position
            // your ship/kerbal at the desired location and go to the
            // Location tab in the Contract Configurator debug window
            // (alt-F10).
            pqsOffset = 447.307865750742, 5.14341771520321E-05, 24.9700656982985
        }
    }

<sub>[ [[Top|Behaviours]] ] [ [[WaypointGenerator|Behaviours#waypointgenerator]] ]</sub>


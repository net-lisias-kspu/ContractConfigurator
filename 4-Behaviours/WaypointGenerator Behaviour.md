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

            // (Optional) The parameter that must be completed before the
            // waypoint becomes visible.  If not specified, the waypoint
            // is always visible.
            parameter = SomeParameterName

            // (Optional) Specifies that the given waypoint should be secret.
            // If this flag is used, then the icon is not required.
            // Default = false
            hidden = true

            // Body for the waypoint - defaulted from the contract if not
            // supplied.
            targetBody = Kerbin

            // The icon to use when displaying the waypoint.  If the path
            // is not specified, the Squad/Contracts/Icons directory is
            // assumed.  Otherwise, the path must be from GameData/
            icon = thermometer

            // The altitude above the terraint of the waypoint.  Note that an
            // altitude of 0.0 means "on the ground".
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

            // (Optional) The parameter that must be completed before the
            // waypoint becomes visible.  If not specific, the waypoint
            // is always visible.
            parameter = SomeParameterName

            // (Optional) Specifies that the given waypoint should be secret.
            // If this flag is used, then the icon is not required.
            // Default = false
            hidden = true

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

            // (Optional) The parameter that must be completed before the
            // waypoint becomes visible.  If not specific, the waypoint
            // is always visible.
            parameter = SomeParameterName

            // (Optional) Specifies that the given waypoint should be secret.
            // If this flag is used, then the icon is not required.
            // Default = false
            hidden = true

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

            // Minimum distance in meters from the 'near' waypoint.
            // Default = 0.0
            minDistance = 100.0

            // Maximum distance in meters from the 'near' waypoint.
            maxDistance = 25000.0
        }

        // Use this to generate a waypoint with fixed coordinates, based on a
        // PQSCity object.
        PQS_CITY
        {
            // The name of the waypoint - displayed on the marker
            name = Monolith

            // (Optional) The parameter that must be completed before the
            // waypoint becomes visible.  If not specific, the waypoint
            // is always visible.
            parameter = SomeParameterName

            // (Optional) Specifies that the given waypoint should be secret.
            // If this flag is used, then the icon is not required.
            // Default = false
            hidden = true

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

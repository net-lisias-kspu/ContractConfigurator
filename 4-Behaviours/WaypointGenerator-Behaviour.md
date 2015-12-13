Behaviour for generating waypoints.

<pre>
BEHAVIOUR
{
    name = WaypointGenerator
    type = WaypointGenerator

    // Use this to generate a waypoint with fixed coordinates
    WAYPOINT
    {
        // The name of the waypoint - displayed on the marker.  If not
        // supplied a random one is generated.
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        name = Kerbal Space Center

        // The parameter that must be completed before the waypoint becomes
        // visible.  If not specified, the waypoint is always visible.  More
        // than one can be specified when there are multiple waypoints
        // generated. 
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  No (multiples allowed)
        //
        parameter = SomeParameterName

        // Specifies that the given waypoint should be secret.  If this flag is
        // used, then the icon is not required.
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   false
        //
        hidden = true

        // Use this to specify that the waypoint is part of a cluster.  Waypoints
        // that are clustered get a roman numeral appended to the name.
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   false
        //
        clustered = false

        // Use this to specify that the waypoint is underwater.  This will
        // force randomly generated waypoints to be at a water location, and
        // change the range of random altitudes to be between the sea-floor and
        // surface.  Also, the minimum altitude is clamped to the sea-floor, so
        // to have a waypoint on the sea-floor, give a very large negative
        // value to the altitude attribute.
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   false
        //
        underwater = false

        // Body for the waypoint - defaulted from the contract if not
        // supplied.
        //
        // Type:      <a href="CelestialBody-Type">CelestialBody</a>
        // Required:  No (defaulted)
        //
        targetBody = Kerbin

        // The icon to use when displaying the waypoint.  If the path
        // is not specified, the Squad/Contracts/Icons directory is
        // assumed.  Otherwise, the path must be from GameData/
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        icon = thermometer

        // The altitude of the waypoint above the terrain.  Note that an
        // altitude of 0.0 means "on the ground".  If not specified, uses a
        // A random value between 0.0 and the atmosphere ceiling (which is zero
        // if there's no atmosphere).
        //
        // Type:      <a href="Numeric-Type">double</a>
        // Required:  No (defaulted)
        //
        altitude = 0.0

        // The coordinates.
        //
        // Type:      <a href="Numeric-Type">double</a>
        // Required:  Yes
        //
        latitude = -0.102668048654
        longitude = -74.5753856554
    }

    // Use this to generate a waypoint with random coordinates
    RANDOM_WAYPOINT
    {
        // The name of the waypoint - displayed on the marker
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        name = A waypoint on Kerbin

        // The parameter that must be completed before the waypoint becomes
        // visible.  If not specified, the waypoint is always visible.  More
        // than one can be specified when there are multiple waypoints
        // generated. 
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  No (multiples allowed)
        //
        parameter = SomeParameterName

        // Specifies that the given waypoint should be secret.  If this flag is
        // used, then the icon is not required.
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   false
        //
        hidden = true

        // Body for the waypoint - defaulted from the contract if not
        // supplied.
        //
        // Type:      <a href="CelestialBody-Type">CelestialBody</a>
        // Required:  No (defaulted)
        //
        targetBody = Kerbin

        // The number of waypoints to generate.
        //
        // Type:      <a href="Numeric-Type">int</a>
        // Required:  No (defaulted)
        // Default:   1
        //
        count = 1

        // The icon to use when displaying the waypoint.  If the path
        // is not specified, the Squad/Contracts/Icons directory is
        // assumed.  Otherwise, the path must be from GameData/
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        icon = thermometer

        // The altitude of the waypoint above the terrain.  Note that an
        // altitude of 0.0 means "on the ground".  If not specified, uses a
        // A random value between 0.0 and the atmosphere ceiling (which is zero
        // if there's no atmosphere).
        //
        // Type:      <a href="Numeric-Type">double</a>
        // Required:  No (defaulted)
        //
        altitude = 0.0

        // Whether the waypoint generated can be on water
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   true
        //
        waterAllowed = false

        // Force the waypoint to fall along the equator.  For boring
        // contracts.
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   false
        //
        forceEquatorial = false
    }

    // Use this to generate a waypoint with random coordinates, but near
    // another waypoint.
    RANDOM_WAYPOINT_NEAR
    {
        // The name of the waypoint - displayed on the marker
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        name = A waypoint near something

        // The parameter that must be completed before the waypoint becomes
        // visible.  If not specified, the waypoint is always visible.  More
        // than one can be specified when there are multiple waypoints
        // generated. 
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  No (multiples allowed)
        //
        parameter = SomeParameterName

        // Specifies that the given waypoint should be secret.  If this flag is
        // used, then the icon is not required.
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   false
        //
        hidden = true

        // Body for the waypoint - defaulted from the contract if not
        // supplied.
        //
        // Type:      <a href="CelestialBody-Type">CelestialBody</a>
        // Required:  No (defaulted)
        //
        targetBody = Kerbin

        // The number of waypoints to generate.
        //
        // Type:      <a href="Numeric-Type">int</a>
        // Required:  No (defaulted)
        // Default:   1
        //
        count = 2

        // The icon to use when displaying the waypoint.  If the path
        // is not specified, the Squad/Contracts/Icons directory is
        // assumed.  Otherwise, the path must be from GameData/
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        icon = thermometer

        // The altitude of the waypoint above the terrain.  Note that an
        // altitude of 0.0 means "on the ground".  If not specified, uses a
        // A random value between 0.0 and the atmosphere ceiling (which is zero
        // if there's no atmosphere).
        //
        // Type:      <a href="Numeric-Type">double</a>
        // Required:  No (defaulted)
        //
        altitude = 0.0

        // Whether the waypoint generated can be on water
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   true
        //
        waterAllowed = false

        // Zero based index of the waypoint to generate near.  Must be a
        // waypoint with index < this waypoint.  Start counting from the
        // first waypoint in the BEHAVIOUR, and count 1 for each value of
        // the count parameter (if it exists).
        //
        // Type:      <a href="Numeric-Type">int</a>
        // Required:  Yes
        //
        nearIndex = 1

        // Minimum distance in meters from the 'near' waypoint.
        //
        // Type:      <a href="Numeric-Type">double</a>
        // Required:  No
        // Default:   0.0
        //
        minDistance = 100.0

        // Maximum distance in meters from the 'near' waypoint.
        //
        // Type:      <a href="Numeric-Type">double</a>
        // Required:  Yes
        //
        maxDistance = 25000.0
    }

    // Use this to generate a waypoint with fixed coordinates, based on a
    // PQSCity object.
    PQS_CITY
    {
        // The name of the waypoint - displayed on the marker
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        name = Monolith

        // The parameter that must be completed before the waypoint becomes
        // visible.  If not specified, the waypoint is always visible.  More
        // than one can be specified when there are multiple waypoints
        // generated. 
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  No (multiples allowed)
        //
        parameter = SomeParameterName

        // Specifies that the given waypoint should be secret.  If this flag is
        // used, then the icon is not required.
        //
        // Type:      <a href="Boolean-Type">bool</a>
        // Required:  No (defaulted)
        // Default:   false
        //
        hidden = true

        // Body for the waypoint - defaulted from the contract if not
        // supplied.
        //
        // Type:      <a href="CelestialBody-Type">CelestialBody</a>
        // Required:  No (defaulted)
        //
        targetBody = Kerbin

        // The icon to use when displaying the waypoint.  If the path
        // is not specified, the Squad/Contracts/Icons directory is
        // assumed.  Otherwise, the path must be from GameData/
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        icon = thermometer

        // The location name.
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  Yes
        //
        pqsCity = KSC

        // An optional offset vector from the center of the PQS City.
        // Use this to make your waypoint relative to the PQS City,
        // which will make it work even for RSS or other mods that may
        // move the PQS city.  To get the offset coordinates, position
        // your ship/kerbal at the desired location and go to the
        // Location tab in the Contract Configurator debug window
        // (alt-F10).
        //
        // Type:      Vector3d
        // Required:  No
        //
        pqsOffset = 447.307865750742, 5.14341771520321E-05, 24.9700656982985
    }
}
</pre>

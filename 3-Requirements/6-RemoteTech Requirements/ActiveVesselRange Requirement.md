The ActiveVesselRange requirement checks that the given celestial body has a satellite with sufficient range (achievable either via an omni antenna or dish set to active vessel).

<pre>
REQUIREMENT:NEEDS[RemoteTech]
{
    name = ActiveVesselRange
    type = ActiveVesselRange

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // The range that is required, in meters.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  Yes
    //
    range = 48000000
}
</pre>

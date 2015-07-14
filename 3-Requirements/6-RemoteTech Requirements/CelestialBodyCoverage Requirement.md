The CelestialBodyCoverage requirement checks that the given celestial body has a dish pointed to it with sufficient range.

<pre>
REQUIREMENT:NEEDS[RemoteTech]
{
    name = CelestialBodyCoverage
    type = CelestialBodyCoverage

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // Minimum coverage that is required (between 0.0 and 1.0).
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   1.0
    //
    minCoverage = 0.8

    // Maximum coverage before requirement no longer met (between 0.0 and 1.0).
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   1.0
    //
    maxCoverage = 1.0
}
</pre>

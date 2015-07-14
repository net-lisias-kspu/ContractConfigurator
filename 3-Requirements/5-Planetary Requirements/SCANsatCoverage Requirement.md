Requirement for having a certain level of SCANsat coverage for the given scan type/planet.

<pre>
REQUIREMENT:NEEDS[SCANsat]
{
    name = SCANsatCoverage
    type = SCANsatCoverage

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // Minimum coverage percentage that must be reached before the contract is
    // valid.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minCoverage = 0.0

    // Maximum coverage percentage that can be reached before the contract is
    // no longer valid.
    // Default = 100.0
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   100.0
    //
    maxCoverage = 0.0

    // The type of scan to perform.
    //
    // Type:      SCANdata.SCANtype
    // Required:  Yes
    // Values:
    //     AltimetryLoRes
    //     AltimetryHiRes
    //     Altimetry
    //     Biome
    //     Anomaly
    //     AnomalyDetail
    //     Kethane
    //     Ore
    //     Uranium
    //     Thorium
    //     Alumina
    //     Water
    //     Aquifer
    //     Minerals
    //     Substrate
    //     Karbonite
    //
    scanType = Biome
}
</pre>

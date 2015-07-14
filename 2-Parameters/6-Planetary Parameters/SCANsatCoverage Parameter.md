The SCANsatCoverage parameter is met when there is sufficient SCANsat coverage for the given planet/type.

<pre>
PARAMETER:NEEDS[SCANsat]
{
    name = SCANsatCoverage
    type = SCANsatCoverage

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // Coverage percentage that must be reached
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  Yes
    //
    coverage = 65.0

    // The type of scan to perform.
    //
    // Type:      <a href="Enumeration-Type">SCANdata.SCANtype</a>
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
    scanType = Biome
}
</pre>

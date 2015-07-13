The SCANsatCoverage parameter is met when there is sufficient SCANsat coverage for the given planet/type.

<pre>
PARAMETER:NEEDS[SCANsat]
{
    name = SCANsatCoverage
    type = SCANsatCoverage

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      CelestialBody
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // Coverage percentage that must be reached
    //
    // Type:      double
    // Required:  Yes
    //
    coverage = 65.0

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
    scanType = Biome
}
</pre>

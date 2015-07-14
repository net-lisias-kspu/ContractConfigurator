Requirement for having a specific location covered for the given scan type/planet.

<pre>
REQUIREMENT:NEEDS[SCANsat]
{
    name = SCANsatLocationCoverage
    type = SCANsatLocationCoverage

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // Define the location via latitude/longitude...
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No
    //
    latitude = -0.102668048654
    longitude = -74.5753856554

    // ...OR via a PQSCity location (but not both)
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No
    //
    pqsCity = Monolith00

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
    //
    scanType = Biome
}
</pre>

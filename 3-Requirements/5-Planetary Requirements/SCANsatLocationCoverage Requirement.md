Requirement for having a specific location covered for the given scan type/planet.

    REQUIREMENT:NEEDS[SCANsat]
    {
        name = SCANsatLocationCoverage
        type = SCANsatLocationCoverage

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Kerbin

        // Define the location via latitude/longitude...
        latitude = -0.102668048654
        longitude = -74.5753856554

        // ...OR via a PQSCity location (but not both)
        pqsCity = Monolith00

        // The type of scan to perform.  Valid values are from SCANdata.SCANtype.
        // Some possible values are:
        //    AltimetryLoRes
        //    AltimetryHiRes
        //    Altimetry
        //    Biome
        //    Anomaly (default)
        //    AnomalyDetail
        //    Kethane
        //    Ore
        //    Uranium
        //    Thorium
        //    Alumina
        //    Water
        //    Aquifer
        //    Minerals
        //    Substrate
        //    Karbonite
        scanType = Biome
    }

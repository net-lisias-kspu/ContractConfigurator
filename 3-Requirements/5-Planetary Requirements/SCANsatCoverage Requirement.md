Requirement for having a certain level of SCANsat coverage for the given scan type/planet.

    REQUIREMENT:NEEDS[SCANsat]
    {
        name = SCANsatCoverage
        type = SCANsatCoverage

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Kerbin

        // Minimum coverage that must be reached before the contract is valid.
        // Default = 0.0
        minCoverage = 0.0

        // Maximum coverage that must be reached before the contract is valid.
        // Default = 100.0
        maxCoverage = 0.0

        // The type of scan to perform.  Valid values are from SCANdata.SCANtype.
        // Some possible values are:
        //    AltimetryLoRes
        //    AltimetryHiRes
        //    Altimetry
        //    Biome
        //    Anomaly
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

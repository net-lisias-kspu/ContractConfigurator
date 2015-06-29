The CelestialBodyCoverage requirement checks that the given celestial body has a dish pointed to it with sufficient range.

    REQUIREMENT:NEEDS[RemoteTech]
    {
        name = CelestialBodyCoverage
        type = CelestialBodyCoverage

        // Minimum coverage that is required (between 0.0 and 1.0).
        // Default = 1.0
        minCoverage = 0.8

        // Maximum coverage before requirement no longer met (between 0.0 and 1.0).
        // Default = 1.0
        maxCoverage = 1.0

        // Target body - if not supplied will be defaulted from the contract.
        targetBody = Duna
    }

The CelestialBodyCoverage parameter requires that a minimum communication coverage of the given celestial body is reached.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = CelestialBodyCoverage
        type = CelestialBodyCoverage

        // The percentage (0.0 to 1.0) of communication coverage that is
        // needed to meet the contract parameter.
        coverage = 0.80

        // This can be inherited from the the contract type if necessary
        targetBody = Duna

        // Text to use for the parameter's title.
        // Default = <body>: Communication coverage: <coverage> %
        //title =
    }

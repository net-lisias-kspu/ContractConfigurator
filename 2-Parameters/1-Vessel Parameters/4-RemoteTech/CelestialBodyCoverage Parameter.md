The CelestialBodyCoverage parameter requires that a minimum communication coverage of the given celestial body is reached.

<pre>
PARAMETER:NEEDS[RemoteTech]
{
    name = CelestialBodyCoverage
    type = CelestialBodyCoverage

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      CelestialBody
    // Required:  No (defaulted)
    //
    targetBody = Duna

    // The percentage (0.0 to 1.0) of communication coverage that is
    // needed to meet the contract parameter.
    //
    // Type:      double
    // Required:  Yes
    //
    coverage = 0.80

    // Text to use for the parameter's title.
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   <body>: Communication coverage: <coverage> %
    //
    //title =
}
</pre>

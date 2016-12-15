The HasAntenna parameter requires that the vessel has an antenna that meets the specified criteria.

<pre>
PARAMETER
{
    name = HasAntenna
    type = HasAntenna

    // The minimum antenna power that the vessel must have.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minPower = 100.0

    // The maximum antenna power that the vessel can have.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxPower = 1000.0

    // The type of antenna.
    //
    // Type:      <a href="Enumeration-Type">HasAntennaParameter.AntennaType</a>
    // Required:  No
    // Values:
    //     RELAY
    //     TRANSMIT
    //
    antennaType = TRANSMIT

    // Text to use for the parameter's title.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    //
    //title =
}
</pre>

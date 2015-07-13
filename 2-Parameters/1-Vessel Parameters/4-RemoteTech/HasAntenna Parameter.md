The HasAntenna parameter requires that the vessel has an antenna that meets the specified criteria.

<pre>
PARAMETER:NEEDS[RemoteTech]
{
    name = HasAntenna
    type = HasAntenna

    // Target body that the antenna is pointed towards, <em>NOT</em> defaulted from
    // the contract type.
    //
    // Type:      CelestialBody
    // Required:  No
    //
    targetBody = Kerbin

    // The minimum number of antenna that must meet the criteria.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   1
    //
    minCount = 1

    // The maximum number of antenna that can meet the criteria.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   int.MaxValue
    //
    maxCount = 3

    // The minimum range in meters that the antenna must have.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minRange = 36000000000

    // The maximum range in meters that the antenna can have.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxRange = 100000000000

    // The type of antenna.
    //
    // Type:      HasAntennaParameter.AntennaType
    // Required:  No
    // Values:
    //     Dish
    //     Omni
    //
    antennaType = Omni

    // Specifies whether we are looking for a connection to the active
    // vessel.  Cannot be true if targetBody is specified.
    //
    // Type:      bool
    // Required:  No (defaulted)
    // Default:   false
    //
    activeVessel = True

    // Text to use for the parameter's title.
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Active vessel antenna range: <range>
    //
    //title =
}
</pre>

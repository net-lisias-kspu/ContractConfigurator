The VesselMass parameter requires a player's vessel to be within the specified mass range.

<pre>
PARAMETER
{
    name = VesselMass
    type = VesselMass

    // Minimum and maximum mass.
    //
    // Type:      float
    // Required:  No (defaulted)
    // Default:   0.0 (minMass)
    //            float.MaxValue (maxMass)
    //
    minMass = 1.0
    maxMass = 10.0

    // Text for the contract parameter.
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Vessel mass: &lt;mass&gt;
    //title =
}
</pre>

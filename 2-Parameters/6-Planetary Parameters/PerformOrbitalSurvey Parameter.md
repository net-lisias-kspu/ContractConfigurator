The PerformOrbitalSurvey parameter is met when an orbital scan of the given body is performed.

<pre>
PARAMETER
{
    name = PerformOrbitalSurvey
    type = PerformOrbitalSurvey

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Kerbin

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Perform an orbital resource survey of &lt;targetBody&gt;
    //
    //title =
}
</pre>

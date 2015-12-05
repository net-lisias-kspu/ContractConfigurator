Parameter to indicate that the Vessel in question must have a certain number of crew members (or must have fewer than a certain number).

<pre>
PARAMETER
{
    name = HasCrew
    type = HasCrew

    // The type of trait required.  Valid values are:
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No
    // Values (for stock KSP):
    //     Pilot
    //     Engineer
    //     Scientist
    //
    trait = Pilot

    // Minimum and maximum experience level required.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0 (minExperience)
    //            5 (maxExperience)
    //
    minExperience = 1
    maxExperience = 2

    // Minimum and maximum count of matching crew required.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0 (minCrew)
    //            int.MaxValue (maxCrew)
    //
    minCrew = 1
    maxCrew = 10

    // (Optional) Specific Kerbal(s) that must be on board.  Can be
    // specified multiple times, but cannot be used with the other
    // attributes on this parameter.
    //
    // Type:      <a href="Kerbal-Type">Kerbal</a>
    // Required:  No (multiples allowed)
    //
    kerbal = Jebediah Kerman
    kerbal = Bob Kerman

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default (maxCrew = 0): Crew: Unmanned
    // Default (maxCrew: int.MAXVALUE) = Crew: At least &lt;minCrew&gt; Kerbals
    // Default (minCrew: 0) = Crew: At most &lt;maxCrew&gt; Kerbals
    // Default (minCrew: maxCrew) = Crew: Exactly &lt;minCrew&gt; Kerbals
    // Default (else): Crew: Between &lt;minCrew&gt; and &lt;maxCrew&gt; Kerbals
    //
    //title =
}
</pre>

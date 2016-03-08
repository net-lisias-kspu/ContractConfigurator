The KerbalDeaths parameter _fails_ if more Kerbals than the countMax die.

<pre>
PARAMETER
{
    name = KerbalDeaths
    type = KerbalDeaths

    // Maximum Number of Kerbals that can die before this contract is considered
    // failed.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   1
    //
    countMax = 1

    // Specific Kerbal(s) that must not be killed.  If used, overrides the count
    // and only these specific Kerbals will trigger the contract failure.
    //
    // Type:      <a href="Kerbal-Type">Kerbal</a>
    // Required:  No (multiples allowed)
    //
    kerbal = Jebediah Kerman
    kerbal = Bob Kerman

    // The vessel to check for Kerbals.  If specified, then only Kerbals who
    // have been on this vessel at one point count towards the check.  If
    // Kerbals that have never been on this vessel die, we don't care.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  No
    //
    vessel = Vessel Key

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default (countMax = 1): Kill no Kerbals
    // Default (countMax != 1) = Kill no more than &lt;countMax&gt; Kerbals
    // Default (kerbal) = Do not kill: <kerbal>
    //
    //title =
}
</pre>

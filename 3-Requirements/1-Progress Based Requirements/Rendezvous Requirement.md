Requirement for completing a rendezvous near the specified celestial body.

<pre>
REQUIREMENT
{
    name = Rendezvous
    type = Rendezvous

    // Type of check to perform (manned or unmanned).  If not specified then
    // achieving this via either an unmanned or manned will count.
    //
    // Type:      <a href="Enumeration-Type">ProgressCelestialBodyRequirement.CheckType</a>
    // Required:  No
    // Values:
    //     Manned
    //     Unmanned
    //
    checkType = Manned

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Kerbin
}
</pre>

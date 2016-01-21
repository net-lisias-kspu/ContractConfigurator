Requirement for having built a base.

_Note that this is based on the stock ProgressNode - I'm not 100% sure what they do and do not consider a 'base'_.

<pre>
REQUIREMENT
{
    name = BaseConstruction
    type = BaseConstruction

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

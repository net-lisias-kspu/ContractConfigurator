Checks the VesselType of the given vessel.

<pre>
PARAMETER
{
    name = VesselIsType
    type = VesselIsType

    // Type of vessel to check for.
    //
    // Type:      <a href="Enumeration-Type">VesselType</a>
    // Required:  Yes
    // Values:
    //   Base
    //   EVA
    //   Lander
    //   Probe
    //   Rover
    //   Ship
    //   Station
    //   SpaceObject
    //
    vesselType = EVA

    // Text for the contract parameter.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Vessel type: &lt;vesselType&gt;
    //title =
}
</pre>

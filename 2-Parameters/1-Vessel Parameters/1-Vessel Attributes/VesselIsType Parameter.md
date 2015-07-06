Checks the VesselType of the given vessel.

<pre>
PARAMETER
{
    name = VesselIsType
    type = VesselIsType

    // Type of vessel to check for.
    //
    // Type:      VesselType
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
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Vessel type: <vesselType>
    //title =
}
</pre>

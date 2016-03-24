Requirement to check if a VesselIdentifier is assigned to a valid vessel.

<pre>
REQUIREMENT
{
    name = VesselValid
    type = VesselValid

    // The vessel to check for validity.  If at any point the vessel is no
    // longer valid, this will return false and fail the contract.
    //
    // Type:      <a href="VesselIdentifier-Type">VesselIdentifier</a>
    // Required:  Yes
    //
    vessel = TheVesselName
}
</pre>

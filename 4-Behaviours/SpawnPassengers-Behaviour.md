Behaviour for spawning passengers on board vessels.

<pre>
BEHAVIOUR
{
    name = SpawnPassengers
    type = SpawnPassengers

    // Count of passengers to spawn.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   1
    //
    count = 10
    
    // Kerbal(s) to spawn (use instead of count to spawn passengers with
    // specific names.
    //
    // Type:      <a href="Kerbal-Type">Kerbal</a>
    // Required:  No (multiples allowed)
    //
    kerbal = Kerman Kerman

    // Type of the passenger(s).
    //
    // Type:      <a href="Enumeration-Type">ProtoCrewMember.KerbalType</a>
    // Required:  No (defaulted)
    // Values:
    //     Applicant
    //     Crew
    //     Tourist (Default)
    //     Unowned
    //
    kerbalType = Tourist
}
</pre>

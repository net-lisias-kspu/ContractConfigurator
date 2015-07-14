Behaviour for spawning passengers on board vessels.

<pre>
BEHAVIOUR
{
    name = SpawnPassengers
    type = SpawnPassengers

    // Count of passengers to spawn.
    //
    // Type:      int
    // Required:  No (defaulted)
    // Default:   1
    //
    count = 10
    
    // Names of passengers to spawn (use instead of count to spawn
    // passengers with specific names.
    //
    // Type:      string
    // Required:  No (multiples allowed)
    //
    passengerName = Kerman Kerman

    // Type of the passenger(s).
    //
    // Type:      ProtoCrewMember.KerbalType
    // Required:  No (defaulted)
    // Values:
    //     Applicant
    //     Crew
    //     Tourist (Default)
    //     Unowned
    //
    kerbalType = Tourist

    // Gender of the passenger(s).  If not specified each passenger is
    // assigned a random gender.
    //
    // Type:      ProtoCrewMember.Gender
    // Required:  No
    // Values:
    //     Male
    //     Female
    //
    gender = Female
}
</pre>

Behaviour for spawning passengers on board vessels.

    BEHAVIOUR
    {
        name = SpawnPassengers
        type = SpawnPassengers

        // Count of passengers to spawn.
        // Default = 1
        count = 10
        
        // Names of passengers to spawn (use instead of count to spawn
        // passengers with specific names.
        passengerName = Kerman Kerman

        // (Optional) Type of the passenger(s).  Defaults to Tourist.  Valid
        // values from ProtoCrewMember.KerbalType:
        //    Applicant
        //    Crew
        //    Tourist
        //    Unowned.
        kerbalType = Tourist

        // (Optional) Gender of the passenger(s).  If not specified each
        // passenger is assigned a random gender.  Valid values are Male and
        // Female.
        gender = Female
    }

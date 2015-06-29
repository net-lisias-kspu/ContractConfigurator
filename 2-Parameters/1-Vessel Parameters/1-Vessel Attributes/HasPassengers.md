##### HasPassengers
Parameter to indicate that the Vessel in question must have a certain number of passengers (or must have fewer than a certain number).  Use with the SpawnPassengers behaviour.

    PARAMETER
    {
        name = HasPassengers
        type = HasPassengers

        // Number of passengers to load onto the ship.
        // Default = 0 (all)
        count = 1

        // Start index in the SpawnPassengers behaviour
        // Default = 0
        index = 0

        // Text to use for the parameter
        // Default Passengers loaded : <count>
        //title =
    }

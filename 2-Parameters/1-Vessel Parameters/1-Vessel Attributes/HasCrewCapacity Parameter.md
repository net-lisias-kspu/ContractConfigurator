Parameter to require that the Vessel in question must have a certain crew capacity.

    PARAMETER
    {
        name = HasCrewCapacity
        type = HasCrewCapacity

        // Minimum/maximum capacity required.  Defaults are 1 and int.MaxValue,
        // respectively
        minCapacity = 1
        maxCapacity = 10

        // Text to use for the parameter.
        // Default: Crew Capacity: Between <min> and <max>
        //title =
    }

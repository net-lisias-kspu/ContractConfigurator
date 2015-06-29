#### RecoverKerbal
The RecoverKerbal parameter is met when the named Kerbal is "recovered" (ie. goes back in to the available list at the astronaut complex).  This is from the Squad "rescue" contracts.

    PARAMETER
    {
        name = RecoverKerbal
        type = RecoverKerbal

        // The Kerbal to be recovered
        kerbal = Jebediah Kermin

        // Alternate method of identifying the Kerbal - zero based index of the
        // entry in a SpawnKerbal or SpawnVessel BEHAVIOUR node.
        //index = 0

        // Text to use for the parameter
        // Default = <kerbal>: Recovered
        //title =
    }

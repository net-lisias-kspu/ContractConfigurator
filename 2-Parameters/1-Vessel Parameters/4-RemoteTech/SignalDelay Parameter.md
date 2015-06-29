The SignalDelay parameter specifies min/max values for the signal delay back to the KSC.

    PARAMETER:NEEDS[RemoteTech]
    {
        name = SignalDelay
        type = SignalDelay

        // Minimum signal delay in seconds.
        // Default = 0.0
        minSignalDelay = 1.0

        // Maximum signal delay in seconds.
        // Default = double.MaxValue
        maxSignalDelay = 70.0

        // Text to use for the parameter's title.
        // Default = Signal delay: Between <min> and <max>.
        //title =
    }	

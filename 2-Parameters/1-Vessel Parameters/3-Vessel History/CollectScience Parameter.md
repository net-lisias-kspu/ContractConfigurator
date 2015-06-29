The CollectScience parameter is used to require a player to collect science under specific circumstances.  It also supports settings to require the player to either transmit or recover the data.

    PARAMETER
    {
        name = CollectScience
        type = CollectScience

        // Defaulted from the contract type if not provided
        targetBody = Duna

        // (Optional) Specifies the biome for which science should be collected.
        // This can be any biome that is valid for the target body, but note that
        // it is not currently validated.
        biome = Craters

        // (Optional) Specifies the situation under which science should be
        // collected.
        // Valid values are:
        //    SrfLanded
        //    SrfSplashed
        //    FlyingLow
        //    FlyingHigh
        //    InSpaceLow
        //    InSpaceHigh
        situation = SrfLanded

        // (Optional) Specifies where the experiment should take place.
        // Valid values are "Surface" and "Space"
        location = Space

        // (Optional) Specifies the experiment to be run, can be any valid
        // experiment in stock KSP or added by mods.  This can be specified
        // multiple times.  The stock list is:
        //    asteroidSample
        //    crewReport
        //    evaReport
        //    mysteryGoo
        //    surfaceSample
        //    mobileMaterialsLab
        //    temperatureScan
        //    barometerScan
        //    seismicScan
        //    gravityScan
        //    atmosphereAnalysis
        experiment = evaReport

        // (Optional) Specifies the subject that should be run.  This can be
        // used in place of the biome/situation/experiment (it contains the
        // same information).  It is recommened to only use this with
        // expressions, rather than adding the subject manually.  This can be
        // specified multiple times.
        subject = evaReport@MunSrfLandedCraters


        // (Optional) The method for which the science must be recovered.
        // Defaults to None if not specified.  Note the Ideal recovery method
        // is special - it will automatically change to either Recover or
        // RecoverOrTransmit, depending whether the experiment can have all its
        // science recovered through transmission.
        // Valid values are:
        //    None
        //    Recover
        //    Transmit
        //    RecoverOrTransmit
        //    Ideal
        recoveryMethod = Recover
    }

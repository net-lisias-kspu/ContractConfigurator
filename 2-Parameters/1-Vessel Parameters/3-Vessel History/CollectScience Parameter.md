The CollectScience parameter is used to require a player to collect science under specific circumstances.  It also supports settings to require the player to either transmit or recover the data.

<pre>
PARAMETER
{
    name = CollectScience
    type = CollectScience

    // Target body, defaulted from the contract if not supplied.
    //
    // Type:      <a href="CelestialBody-Type">CelestialBody</a>
    // Required:  No (defaulted)
    //
    targetBody = Duna

    // Specifies the biome where science should be collected. This can be any
    // biome that is valid for the target body, but note that it is not 
    // validated due to KSP limitations (so make sure not to make a typo!).
    //
    // Type:      <a href="Biome-Type">Biome</a>
    // Required:  No
    //
    biome = Craters

    // Specifies the situation under which science should be collected.
    //
    // Type:      <a href="Enumeration-Type">ExperimentSituations</a>
    // Required:  No
    // Values:
    //     SrfLanded
    //     SrfSplashed
    //     FlyingLow
    //     FlyingHigh
    //     InSpaceLow
    //     InSpaceHigh
    situation = SrfLanded

    // Specifies where the experiment should take place.
    //
    // Type:      <a href="Enumeration-Type">BodyLocation</a>
    // Required:  No
    // Values:
    //     Surface
    //     Space
    //
    location = Space

    // Specifies the experiment to be run, can be any valid experiment in stock
    // KSP or added by mods.
    //
    // Type:      <a href="ScienceExperiment-Type">ScienceExperiment</a>
    // Required:  No (multiples allowed)
    // Values (for stock KSP):
    //     asteroidSample
    //     atmosphereAnalysis
    //     barometerScan
    //     crewReport
    //     evaReport
    //     gravityScan
    //     mobileMaterialsLab
    //     mysteryGoo
    //     seismicScan
    //     surfaceSample
    //     temperatureScan
    //
    experiment = evaReport

    // Specifies the subject(s) that should be run.  This can be used in place
    // of the biome/situation/experiment (it contains the same information).
    // It is recommened to only use this with expressions, rather than adding
    // the subject manually.
    //
    // Type:      <a href="ScienceSubject-Type">ScienceSubject</a>
    // Required:  No (multiples allowed)
    //
    subject = evaReport@MunSrfLandedCraters

    // The method for which the science must be recovered.  Note the Ideal
    // recovery method is special - it will automatically change to either
    // Recover or RecoverOrTransmit, depending whether the experiment can have
    // all its science recovered through transmission.
    //
    // Type:      <a href="Enumeration-Type">ScienceRecoveryMethod</a>
    // Required:  No
    // Values:
    //     None
    //     Recover
    //     Transmit
    //     RecoverOrTransmit
    //     Ideal
    recoveryMethod = Recover
}
</pre>

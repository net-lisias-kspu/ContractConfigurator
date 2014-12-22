## The CONTRACT_CONFIGURATOR node

**_NEW!_** The CONTRACT_CONFIGURATOR node is used for miscellaneous settings.  Currently only supports the disableContractType value - which specifies a ContractType to be disabled.

The following example disables all of the stock contract types.

    CONTRACT_CONFIGURATOR
    {
        disabledContractType = AltitudeRecord
        disabledContractType = ARMContract
        disabledContractType = BaseContract
        disabledContractType = CollectScience
        disabledContractType = ExploreBody
        disabledContractType = FirstLaunch
        disabledContractType = GrandTour
        disabledContractType = ISRUContract
        disabledContractType = OrbitKerbin
        disabledContractType = PartTest
        disabledContractType = PlantFlag
        disabledContractType = ReachSpace
        disabledContractType = RescueKerbal
        disabledContractType = SatelliteContract
        disabledContractType = StationContract
        disabledContractType = SurveyContract
    }

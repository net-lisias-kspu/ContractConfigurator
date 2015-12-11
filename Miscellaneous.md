## The CONTRACT_CONFIGURATOR node

The CONTRACT_CONFIGURATOR node is used for miscellaneous settings.  Currently only supports the disableContractType value - which specifies a ContractType to be disabled.

The following example disables all of the stock contract types.

    CONTRACT_CONFIGURATOR
    {
        disabledContractType = ARMContract
        disabledContractType = BaseContract
        disabledContractType = CollectScience
        disabledContractType = ExploreBody
        disabledContractType = GrandTour
        disabledContractType = ISRUContract
        disabledContractType = PartTest
        disabledContractType = PlantFlag
        disabledContractType = RecoverAsset
        disabledContractType = SatelliteContract
        disabledContractType = StationContract
        disabledContractType = SurveyContract
        disabledContractType = TourismContract
        disabledContractType = WorldFirstContract
    }

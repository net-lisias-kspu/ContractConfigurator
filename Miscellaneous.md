## The CONTRACT_CONFIGURATOR node

**_COMING SOON!_** The CONTRACT_CONFIGURATOR is used for miscellaneous settings.  Currently only supports the disableContractType value - which specifies a ContractType to be disabled.

The following example disables most of the stock contract types.

    CONTRACT_CONFIGURATOR
    {
        disabledContractType = AltitudeRecord
        disabledContractType = CollectScience
        disabledContractType = FirstLaunch
        disabledContractType = OrbitKerbin
        disabledContractType = PartTest
        disabledContractType = PlantFlag
        disabledContractType = ReachSpace
        disabledContractType = RescueKerbal
    }

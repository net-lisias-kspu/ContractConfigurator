## Table of Contents

* [[Table of Contents|Miscellaneous#table-of-contents]]
* [[The CONTRACT_DEFINITION node|Miscellaneous#the-contract_definition-node]]
* [[The CONTRACT_CONFIGURATOR node|Miscellaneous#the-contract_configurator-node]]

## The CONTRACT_DEFINITION node

The CONTRACT_DEFINITION node is used to define additional details for a stock contract type (or one build using the stock system).  These additional details are used in the enhanced Mission Control UI that is part of Contract Configurator.  The node looks like the following:

<pre>
CONTRACT_DEFINITION
{
    // The name of the contract type.  This needs to match the name of the class exactly.
    name = StockContract
  
    // The name that will be used to group these contracts under in Mission Control.
    displayName = Stock Contracts
  
    // The name of the agency.  This is used for deriving the image to display.  As well,
    // the agency details are displayed when clicking on the group line.  For more
    // details on agents, see the <a href="wiki/How-To#creating-an-agency">agent</a> page.
    agent = Stock Contract Agency Inc.
}
</pre>

<sub>[ [[Top|Miscellaneous]] ] [ [[The CONTRACT_DEFINITION node|Miscellaneous#the-contract_definition-node]] ]</sub>

## The CONTRACT_CONFIGURATOR node

The CONTRACT_CONFIGURATOR node is used for miscellaneous settings.  Currently only supports the disableContractType value - which specifies a ContractType to be disabled.

The following example disables all of the stock contract types.

    CONTRACT_CONFIGURATOR
    {
        disabledContractType = ARMContract
        disabledContractType = BaseContract
        disabledContractType = CollectScience
        disabledContractType = Exploration
        disabledContractType = GrandTour
        disabledContractType = ISRUContract
        disabledContractType = PartTest
        disabledContractType = PlantFlag
        disabledContractType = RecoverAsset
        disabledContractType = SatelliteContract
        disabledContractType = StationContract
        disabledContractType = SurveyContract
        disabledContractType = TourismContract
    }

<sub>[ [[Top|Miscellaneous]] ] [ [[The CONTRACT_CONFIGURATOR node|Miscellaneous#the-contract_configurator-node]] ]</sub>


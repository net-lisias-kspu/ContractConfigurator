## Table of Contents

* [[Table of Contents|Contract-Group#table-of-contents]]
* [[The CONTRACT_GROUP node|Contract-Group#the-contract_group-node]]

## The CONTRACT_GROUP node

The CONTRACT_GROUP node provides grouping for multiple Contract Configurator contracts, and allows some common attributes to be set across those groups.

    CONTRACT_GROUP
    {
        // Name of the contract group
        name = ContractGroup

        // The maximum number of times that contracts within this contract
        // group can be completed (0 being unlimited).
        // Default = 0
        maxCompletions = 3

        // The maximum instances of this contract within this contract group
        // that can be active at one time (0 being unlimited).
        // Default = 0
        maxSimultaneous = 1
    }

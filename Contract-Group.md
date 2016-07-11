## Table of Contents

* [[Table of Contents|Contract-Group#table-of-contents]]
* [[The CONTRACT_GROUP node|Contract-Group#the-contract_group-node]]

## The CONTRACT_GROUP node

The CONTRACT_GROUP node provides grouping for multiple Contract Configurator contracts, and allows some common attributes to be set across those groups.

    CONTRACT_GROUP
    {
        // Name of the contract group
        name = ContractGroup

        // Name that is displayed in the settings window (if not supplied,
        // defaulted to the name).
        displayName = The Contract Group

        // Key to use when sorting child groups in mission control.  Use this
        // if you want your contract groupss to appear in a different order.
        // Because this defaults to the displayName, the default sort is
        // alphabetical.
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  No (defaults to the displayName)
        //
        sortKey = A string to give an alternate sort order

        // Agent (agency).  It is highly recommended to create and provide a
        // custom agent, as it is used to group and display contracts in
        // Mission Control.
        agent = Integrated Integrals

        // Use this to specify the minimum version of Contract Configurator
        // That is required to run contracts in this group.
        minVersion = 0.7.0

        // The maximum number of times that contracts within this contract
        // group can be completed (0 being unlimited).
        // Default = 0
        maxCompletions = 3

        // The maximum instances of this contract within this contract group
        // that can be active at one time (0 being unlimited).
        // Default = 0
        maxSimultaneous = 1

        // List any contract types to disable as part of this contract group.
        // Multiple values can be provided.  These can be a Contract Configurator
        // CONTRAC_TYPE name, a stock contract type class name, or a mod contract
        // type class name.
        disabledContractType = ARMContract

        // Contract groups may also be nested - all the same attributes can be
        // used in the child groups.  Values like maxCompletions and
        // maxSimultaneous apply to all contracts in the group and all child
        // groups.
        CONTRACT_GROUP
        {
            // Name of the contract group
            name = ChildGroup

            // A child group with fewer completions allowed than the parent.
            maxCompletions = 1
        }

        // The DATA node is a special node that is not used by contracts
        // or parameters directly, but provide storage for generic values
        // that can be used as part of expressions.
        DATA
        {
            type = CelestialBody

            // This would be accessiable to any contracts in the ContractGroup
            // or ChildGroup groups by using:
            // @ContractGroup:orbitedBodyWithSurface
            orbitedBodyWithSurface = OrbitedBodies().Where(cb => cb.HasSurface())
        }

    }

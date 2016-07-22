## Table of Contents

* [[Table of Contents|Data-Node#table-of-contents]]
* [[The DATA node|Data-Node#the-data-node]]
* [[The DATA_EXPAND node|Data-Node#the-data_expand-node]]

## The DATA node

The DATA node is used to temporarily store the result of expressions for use in the rest of the contract definition.  The syntax of the data node is as follows:
```
CONTRACT_TYPE
{
    ...

    DATA
    {
        type = Vessel
        requiredValue = true
        targetVessel = AllVessels().Where(v => v.IsOrbiting()).Random()
    }

    ...

    PARAMETER
    {
        type = VesselParameterGroup
        vessel = @/targetVessel
    }
}
```
Data nodes may exist within [[CONTRACT_TYPE|Contract-Type]] and [[CONTRACT_GROUP|Contract-Group]] nodes.

Within the DATA node, there are a number of fields that can be specified:

| Field | Description |
| :--- | :--- |
| `type` | The data type for elements within the DATA node.  Supports any data type listed on the [[Expressions|Expressions]] page. |
| `title` | (Optional) When the value is a required value, the requirement title to display in mission control (usually of the form "Must X").  This is required for anything that can prevent the contract from generating.  |
| `hidden` | (Optional, defualt = false) Use this to hide the requirement line in mission control for entries in this data node.  This should only be used when the value can't actually prevent the contract from generating, so it doesn't need to be communicated to the player.  |
| `requiredValue` | (Optional, default = true) If true, the expression needs to return a valid (non-null) value for the contract to be offered.  If false, the contract will be offered even if the expression returns null. |
| `uniquenessCheck` | (Optional, default = NONE) Whether (and how to check uniqueness of this value).  Use this to prevent duplicate contracts (eg. for the same Kerbal, Vessel, etc.).  This can check against contracts of the same type, or contracts in the same parent group.  It can also check only active contracts or all contracts (to make it so a contract can only ever be completed once for the given value).  The valid values are NONE, CONTRACT_ACTIVE, CONTRACT_ALL, GROUP_ACTIVE and GROUP_ALL. |
| `<identifier>` | An identifier that contains the expression.  Can be any valid identifier (characters, numbers and underscores), except for names already used by the CONTRACT_TYPE node. |

Identifiers created in a DATA node are accessed as if they were a part of the CONTRACT_TYPE node (by referencing them as `@/<identifier>`).

<sub>[ [[Top|Data-Node]] ] [ [[The DATA node|Data-Node#the-data-node]] ]</sub>

## The DATA_EXPAND node

The DATA_EXPAND node is a variant on the DATA node.  It's purpose is to give a list of values that will expand into multiple duplicated contract types.  In this way, it's possible to do something like creating a duplicate contract for each Celestial Body and have the players able to see the different variants in mission control (instead of representing them as a single contract when not yet available).  Because each copy is treated as a unique contract type, it can also be used to create more complex contract dependencies (eg. "Need to complete the starter contract on *Minmus* before the advanced Minmus contract is offered").

When a DATA_EXPAND node is expanded, the duplicated contracts have a period and the value of the DATA_EXPAND node appended to the contract title.  So a CONTRACT_TYPE of "MyContractType" with values of [Mun, Minmus] would expand to "MyContractType.Mun" and "MyContractType.Minmus".

The structure of the DATA_EXPAND node is a simplified version of the DATA node.  Only a type and a value expression can be provided.  Take the following contract as an example:
```
CONTRACT_TYPE
{
    type = MyContractType
    ...

    DATA_EXPAND
    {
        type = int
        someIntValue = [ 0, 1 ]
    }
}
```
This becomes equivalent to the following configuration:
```
CONTRACT_TYPE
{
    type = MyContractType.0
    ...

    DATA
    {
        type = int
        someIntValue = 0
    }
}


CONTRACT_TYPE
{
    type = MyContractType.1
    ...

    DATA
    {
        type = int
        someIntValue = 1
    }
}
```
Note in the example above that the type is defined as an `int`, but the actual type provided must be `List<int>`.  DATA_EXPAND nodes can use expressions of arbitrary complexity.  The only restriction is that the expression must be *deterministic* - it must be possible to determine the list of values at game start.  So `HomeWorld().Children()` is a valid expression that gets all the homeworld's moons (Mun and Minmus in a stock game), whereas `AllVessels()` is not valid, because there are no vessels before a save game is loaded.

<sub>[ [[Top|Data-Node]] ] [ [[The DATA_EXPAND node|Data-Node#the-data_expand-node]] ]</sub>


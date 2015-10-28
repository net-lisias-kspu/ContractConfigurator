## Table of Contents

* [[Table of Contents|Data-Node#table-of-contents]]
* [[The DATA node|Data-Node#the-data-node]]

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
Data nodes may existing within [[CONTRACT_TYPE|Contract-Type]] and [[CONTRACT_GROUP|Contract-Group]] nodes.

Within the DATA node, there are a number of fields that can be specified:

| Field | Description |
| :--- | :--- |
| `type` | The data type for elements within the DATA node.  Supports any data type listed on the [[Expressions|Expressions]] page. |
| `requiredValue` | (Optional, default = true) If true, the expression needs to return a valid (non-null) value for the contract to be offered.  If false, the contract will be offered even if the expression returns null. |
| `uniqueValue` | (Optional, default = false) If true, this value must be unique across all contracts (active/offered/completed).  If a new contract were to be offered with a duplicate value, it will not be generated.  Use this if you want the contract to only be completeable once for each unique value. |
| `activeUniqueValue` | (Optional, default = false) If true, this value must be unique across active/offered contracts.  If a new contract were to be offered with a duplicate value, it will not be generated. Use this if you want the contract to only be simultaneously available once for each unique value. |
| `<identifier>` | An identifier that contains the expression.  Can be any valid identifier (characters, numbers and underscores), except for names already used by the CONTRACT_TYPE node. |

Identifiers created in a DATA node are accessed as if they were a part of the CONTRACT_TYPE node (by referencing them in as `@/<identifier>`.

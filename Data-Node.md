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

Within the DATA node, there are two fields that need to be specified:

| Field | Description |
| :--- | :--- |
| `type` | The data type for elements within the DATA node.  Supports any data type listed on the [[Data Types|Data-Types]] page. |
| `requiredValue` | (Optional, default = true) If true, the expression needs to return a valid (non-null) value for the contract to be offered.  If false, the contract will be offered even if the expression returns null. |
| `<identifier>` | An identifier that contains the expression.  Can be any valid identifier (characters, numbers and underscores), except for names already used by the CONTRACT_TYPE node. |

Identifiers created in a DATA node are accessed as if they were a part of the CONTRACT_TYPE node (by referencing them in as `@/<identifier>`.

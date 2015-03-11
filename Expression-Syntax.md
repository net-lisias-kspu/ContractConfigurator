## Overview
**_COMING SOON!_**
Contract Configurator has its own rich expression language.  This can be used to customize the behaviour of contracts in a number of different ways, and is the main mechanism to create "random" contracts (to create contracts like the stock part test or satellite contracts).

**All** fields in the CONTRACT_TYPE, PARAMETER, REQUIREMENT and BEHAVIOUR nodes (with the exception of name and type, which are special) support expressions.  So instead of writing:
```
targetBody = Minmus
```
You can write:
```
targetBody = HomeWorld().Children().Random()
```
Which has now changed your contract to randomly come up for either the Mun or Minmus!

## Syntax
This section documents the various syntax elements that are available.  The following general considerations apply:

1. Whitespace is not significant.  The expression '1+1' and '1 + 1' are treated identically.
1. All expressions must be on one line.  This is due to limitations of using the stock config nodes as the underlying mechanism.
1. All expressions have a data type that is inferred by context (the start context being inferred from the type for the config node attribute).   For example, `targetBody` is of type CelestialBody, and `rewardFunds` is of type Double.  This is important to understand when using methods/functions that are only availble for a certain data type.

### Operations
The following operators can be used:

| Operation | Return Type | Description | Example | Result|
| :--- | :--- | :--- | :--- | :--- |
| `<lval> + <rval>` | Same as lval/rval | Adds two values, typically only available for numeric data types. | `3 + 4` | `7` |
| `<lval> - <rval>` | Same as lval/rval | Subtracts two values, typically only available for numeric data types. | `10 - 4` | `6` |
| `<lval> * <rval>` | Same as lval/rval | Multiplies two values, typically only available for numeric data types. | `1.5 * 4.0` | `6.0` |
| `<lval> / <rval>` | Same as lval/rval| Divides two values, typically only available for numeric data types. | `10.0 / 2.5` | `4.0` |

## Table of Contents

* [[Table of Contents|Expressions#table-of-contents]]
* [[Overview|Expressions#overview]]
* [[Syntax|Expressions#syntax]]
  * [[Strings|Expressions#strings]]
  * [[Operations|Expressions#operations]]
  * [[Operator Precedence|Expressions#operator-precedence]]
* [[Identifiers|Expressions#identifiers]]
* [[Special Identifiers|Expressions#special-identifiers]]
* [[Functions/Methods|Expressions#functionsmethods]]
  * [[Functions|Expressions#functions]]
  * [[Methods|Expressions#methods]]
* [[Lists of values|Expressions#lists-of-values]]
  * [[The Where() Method|Expressions#the-where-method]]

## Overview
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

<sub>[ [[Top|Expressions]] ] [ [[Overview|Expressions#overview]] ]</sub>

## Syntax
This section documents the various syntax elements that are available.  The following general considerations apply:

1. Whitespace is not significant.  The expression '1+1' and '1 + 1' are treated identically.
1. All expressions must be on one line.  This is due to limitations of using the stock config nodes as the underlying mechanism.
1. All expressions have a data type that is inferred by context (the start context being inferred from the type for the config node attribute).   For example, `targetBody` is of type CelestialBody, and `rewardFunds` is of type Double.  This is important to understand when using methods/functions that are only availble for a certain data type.

<sub>[ [[Top|Expressions]] ] [ [[Syntax|Expressions#syntax]] ]</sub>

### Strings

String fields can be populated without any special encoding and they will be read as is.  However, strings also support automatic replacement of inline special identifiers or function calls.  Strings may also optionally be encased within double quotes (").  This is important when trying to create a list of strings, such as the following:
```
DATA
{
    type = List<string>
    theListOfStrings = [ "First string", "Second string", "Another string" ]
}
```
Failing to use double quotes in the example above causes the above to be treated as a one element list with a single string comprising of the full text given in the variable.

<sub>[ [[Top|Expressions]] ] [ [[Syntax|Expressions#syntax]] / [[Strings|Expressions#strings]] ]</sub>

### Operations
The following operators can be used:

| Operation | Return Type | Description | Example | Result|
| :--- | :--- | :--- | :--- | :--- |
| `<lval> + <rval>` | Same as lval/rval | Adds two values, typically only available for numeric data types. | `3 + 4` | `7` |
| `<lval> - <rval>` | Same as lval/rval | Subtracts two values, typically only available for numeric data types. | `10 - 4` | `6` |
| `<lval> * <rval>` | Same as lval/rval | Multiplies two values, typically only available for numeric data types. | `1.5 * 4.0` | `6.0` |
| `<lval> / <rval>` | Same as lval/rval | Divides two values, typically only available for numeric data types. | `10.0 / 2.5` | `4.0` |
| `<lval> == <rval>` | boolean | Equality comparison, return true if both values are the same. | `2 == 3` | `false` |
| `<lval> != <rval>` | boolean | Not equals comparison, return true if both values are not the same. | `2 != 3` | `true` |
| `<lval> > <rval>` | boolean | Greater than comparison, return true if the first value is greater than the second. | `2 > 3` | `false` |
| `<lval> >= <rval>` | boolean | Greater than or equal comparison, return true if the first value is greater than the second or they are equal. | `2 >= 3` | `false` |
| `<lval> <= <rval>` | boolean | Less than or equal comparison, return true if the first value is less than the second or they are equal. | `2 <= 3` | `true` |
| `<lval> < <rval>` | boolean | Less than comparison, return true if the first value is less than the second. | `2 < 3` | `true` |
| `<bool1> && <bool2>` | boolean | Logical AND. | `1 == 1 && 3 > 1` | `true` |
| `<bool1> || <bool2>` | boolean | Logical OR. | `1 == 2 || 3 > 1` | `true` |
| `<bool> ? <value_if_true> : <value_if_false>` | Same as values | Conditional ternary operator.  If the condition is true, returns the first value, otherwise returns the second value. | `1 == 2 ? Minmus : Mun` | `Mun` |
| `- <val>` | Same as val | Unary negation. | `- 10` | `-10` |
| `! <bool>` | boolean | Logical not | `!true` | false |

<sub>[ [[Top|Expressions]] ] [ [[Syntax|Expressions#syntax]] / [[Operations|Expressions#operations]] ]</sub>

### Operator Precedence
Standard operator precedence apply, based on the precedence in the table below (lowest to highest):

| Category | Operator(s) |
| :--- | :--- |
| Unary | `-  !` |
| Multiplicative | `*  /` |
| Additive | `+  -` |
| Relational | `<  <=  >=  >` |
| Equality | `==  !=` |
| Conditional AND | `&&` |
| Conditional OR | `||` |
| Conditional | `?  :` |

This means that:

1. Operators that appear higher in the table get applied first.
1. Operators in the same place in the table are applied left to right.

For example, the expression `2 * 3 + 10 / 2` gets evaluated to `6 + 5` after one pass, and then reduced to `11` on the final pass.

<sub>[ [[Top|Expressions]] ] [ [[Syntax|Expressions#syntax]] / [[Operator Precedence|Expressions#operator-precedence]] ]</sub>

## Identifiers

Identifiers are barewords (combinations of letters, numbers and underscores) that have a special meaning, depending on the variable context.  The following table lists the different types which support identifiers:

| Type | Meaning of Identifiers | Valid Values | Example |
| :--- | :--- | :--- | :--- | 
| double | Retrieves a value from the persistent data store.  See the [[Expression Requirement|Requirements#expression]] and [[Expression Behaviours|Expression-Behaviour]] for more information. | Anything | `TourismPassengerCount`  ([Tourism Contract Pack](https://github.com/jrossignol/ContractPack-Tourism))|
| boolean | The true and false constants are available for use | `true`, `false` | `true` |
| Enumerations | The constants for a given enumeration can be specified.  Most attributes that use an enumeration list the valid values in the appropriate [[Parameter|Parameters]], [[Requirement|Requirements]] or [[Behaviour|Behaviours]] page.  The valid values are dependent on the enumeration.  For example, the situation enumeration includes `FLYING`, `ORBITING` and others. | Enumeration-dependent | `FLYING` |
| CelestialBody | The name of any planet loaded in the game.  Note that this can include planets added by mods that add planets.  Also, mods that change/rename planets will have different constants.  For example, in RSS the specifying the value `Kerbin` will result in an error (it will not get translated to `Earth`) | Any valid celestial body | `Kerbin`, `Mun`, `Duna` |
| Vessel | The identifier for any vessel saved via a [[VesselParameterGroup|VesselParameterGroup-Parameter]] parameter. | Dependent on contract configurator | `CommSat I` ([RemoteTech Contract Pack](https://github.com/jrossignol/ContractPack-RemoteTech)) |

<sub>[ [[Top|Expressions]] ] [ [[Identifiers|Expressions#identifiers]] ]</sub>

## Special Identifiers

A special identifier is an identifier that starts with the `@` symbol, and refers to another node in the contract configuration.

For example:
```
rewardFunds = 10000.0
failureFunds = @rewardFunds / 2.0
```
References may include a "path" to reference a value in another part of the configuration.  The path can start with `/` to indicate the root CONTRACT_TYPE node, and can contain `..` to indicate the parent node.  The following are all valid examples (note that the contract below is for illustration purposes only and is missing mandatory fields):
```
CONTRACT_TYPE
{
    rewardFunds = @/MyGroup/CrewCheck/minCrew * 1000.0

    PARAMETER
    {
        name = MyGroup
        type = VesselParameterGroup

        PARAMETER
        {
            name = CrewCheck
            type = HasCrew

            minCrew = 2
            maxCrew = @minCrew * 2.0
        }

        PARAMETER
        {
            name = CapacityCheck
            type = HasCrewCapacity

            minCapacity = @../CrewCheck/minCrew
        }
    }
}
```
One detail that can be seen in the above example is that the referenced values can appear in the contract definition in any order.  The only exception is that a circular reference cannot be created.  The following definition would cause an error to be logged and the contract type not to be loaded:
```
rewardFunds = @rewardScience
rewardScience = @rewardFunds
```

<sub>[ [[Top|Expressions]] ] [ [[Special Identifiers|Expressions#special-identifiers]] ]</sub>

## Functions/Methods

The expression syntax language supports function calls in three different flavours.

1. Local Functions
1. Global Functions
1. Method Calls

<sub>[ [[Top|Expressions]] ] [ [[Functions/Methods|Expressions#functionsmethods]] ]</sub>

### Functions

A function takes zero, one or many parameters and returns a value.  Local functions are only available in a specific context, whereas global functions are available everywhere.  Local functions are typically only used when the return value would be unclear if made global.  Here are some example function calls:
```
rewardFunds = Random(1000.0, 2000.0)
targetBody = HomeWorld()
```
See the sidebar for a full list of classes with functions.

<sub>[ [[Top|Expressions]] ] [ [[Functions/Methods|Expressions#functionsmethods]] / [[Functions|Expressions#functions]] ]</sub>

### Methods

Methods are functions that operate on a value (or "object").  They follow the form `<value>.<MethodCall>()`.  Here are some examples of method calls:
```
targetBody = HomeWorld().GetChildren().Random()
minAltitude = @targetBody.AtmosphereAltitude()
```
See the sidebar for a full list of classes with methods.

<sub>[ [[Top|Expressions]] ] [ [[Functions/Methods|Expressions#functionsmethods]] / [[Methods|Expressions#methods]] ]</sub>

## Lists of values

Lists of values may be specified using the `[` and `]` array operators and separating the values with `,`.  For example:
```
targetBody = [ Mun, Minmus ].Random()
```
Note that fields do not directly support assigning from a list of values, but there are two very common uses of lists: the `Random()` method call returns a random value from the list, and the `Where()` method call that can filter the list of values.

<sub>[ [[Top|Expressions]] ] [ [[Lists of values|Expressions#lists-of-values]] ]</sub>

### The Where() Method

The Where() method on lists is a special method that has a slightly altered syntax.  It operates on a list, and filters that list down based on a conditional expression.  Given this example expression:
```
targetBody = AllBodies().Where(b => b.HasOcean()).Random()
```
The expression gets a list of all celestial bodies, and then filters it down to a list of all bodies that have oceans.  It then selects a random body from that list.  Note the `b =>` portion of the expression is defining a temporary variable that can be used in the filter expression (the value `b` is an example, any identifier consisting of alphanumeric characters may be used).  That expression will be executed for each value in the list, and only the values where the expression is `true` will be kept.

<sub>[ [[Top|Expressions]] ] [ [[Lists of values|Expressions#lists-of-values]] / [[The Where() Method|Expressions#the-where-method]] ]</sub>


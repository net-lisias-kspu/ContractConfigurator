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
The [[SpawnKerbal behaviour|SpawnKerbal-Behaviour]] can be accessed by referencing it by name in an expression:
```
CONTRACT_TYPE
{
    name = MyContractType
    
    title = @/MySpawnKerbal.Kerbals().ElementAt(2) is the name of the Kerbal.

    BEHAVIOUR
    {
        name = MySpawnKerbal
        type = SpawnKerbal

        KERBAL
        {
            ...
        }
    }
}
```

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`List`](List-Type)`<Kerbal> Kerbals()` | Retrieves a list of all Kerbals spawned by this behaviour. |

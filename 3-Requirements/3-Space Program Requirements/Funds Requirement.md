Requirement that checks whether the player has enough (or not too much) funds.

<pre>
REQUIREMENT
{
    name = Funds
    type = Funds

    // Minimum amount of funds the player must have before this contract
    // can show up.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   0.0
    //
    minFunds = 100000

    // Maximum amount of funds the player can have before this contract
    // no longer shows up.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   double.MaxValue
    //
    maxFunds = 1000000
}
</pre>

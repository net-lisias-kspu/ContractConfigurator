Requirement that checks whether the player has enough (or not too much) reputation.

<pre>
REQUIREMENT
{
    name = Reputation
    type = Reputation

    // Minimum amount of reputation the player must have before this
    // contract can show up.
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   -1000.0
    //
    minReputation = 0

    // Maximum amount of reputation the player can have before this
    // contract no longer shows up.
    //
    // Type:      <a href="Numeric-Type">float</a>
    // Required:  No (defaulted)
    // Default:   1000.0
    //
    maxReputation = 500.0
}
</pre>

Parameter to indicate that the Vessel in question must have a certain number of passengers (or must have fewer than a certain number).  Use with the SpawnPassengers behaviour.

<pre>
PARAMETER
{
    name = HasPassengers
    type = HasPassengers

    // Number of passengers to load onto the ship.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0 (all passengers)
    //
    count = 1

    // Start index in the SpawnPassengers behaviour
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0
    //
    index = 0

    // (Optional) Specific Kerbal(s) that must be on board.  Can be
    // specified multiple times, but cannot be used with the other
    // attributes on this parameter.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (multiples allowed)
    //
    kerbal = Jebediah Kerman
    kerbal = Bob Kerman

    // Text to use for the parameter
    // Default Passengers loaded : &lt;count&gt;
    //title =
}
</pre>

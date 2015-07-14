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

    // Text to use for the parameter
    // Default Passengers loaded : &lt;count&gt;
    //title =
}
</pre>

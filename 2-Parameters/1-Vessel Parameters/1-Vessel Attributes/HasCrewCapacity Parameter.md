Parameter to require that the Vessel in question must have a certain crew capacity.

<pre>
PARAMETER
{
    name = HasCrewCapacity
    type = HasCrewCapacity

    // Minimum and maximum crew capacity required.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No
    // Default:   1 (minCapacity)
    //            int.MaxValue (maxCapacity)
    //
    minCapacity = 1
    maxCapacity = 10

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Crew Capacity: Between &lt;min&gt; and &lt;max&gt;
    //title =
}
</pre>

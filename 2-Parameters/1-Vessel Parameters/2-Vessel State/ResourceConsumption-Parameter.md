Parameter to check consumption (or production) of a resource.

<pre>
PARAMETER
{
    name = ResourceConsumption
    type = ResourceConsumption

    // The name of the resource to check for.
    //
    // Type:      <a href="Resource-Type">Resource</a>
    // Required:  Yes
    //
    resource = LiquidFuel

    // Minimum and maximum consumption rate of the resource required.  Note that
    // if negative, this will indicate a production rate instead.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   double.MinValue (minRate)
    //            double.MaxValue (maxRate)
    //
    minRate = 10.0
    maxRate = 1000.0

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Resource <Consumption/Production>: &lt;resource&gt;: &lt;quantity_description&gt;
    //title =
}
</pre>

Parameter to indicate that the Vessel in question must have a certain quantity of a certain resource (or must have fewer than a certain number).

<pre>
PARAMETER
{
    name = HasResource
    type = HasResource

    // The name of the resource to check for.
    //
    // Type:      Resource
    // Required:  Yes
    //
    resource = LiquidFuel

    // Minimum and maximum quantity of the resource required.
    //
    // Type:      double
    // Required:  No (defaulted)
    // Default:   0.01 (minQuantity)
    //            double.MaxValue (maxQuantity)
    //
    minQuantity = 10.0
    maxQuantity = 1000.0

    // Text to use for the parameter
    //
    // Type:      string
    // Required:  No (defaulted)
    // Default:   Resource: &lt;resource&gt;: &lt;quantity_description&gt;
    //title =
}
</pre>

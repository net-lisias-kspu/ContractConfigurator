Parameter to indicate that the Vessel in question must have a certain quantity of a certain resource (or must have fewer than a certain number).  The HasResource parameter can be used in two different modes - simple and extended.  In the simple mode, simply provide the parameters to filter on, as in the following example:

<pre>
PARAMETER
{
    name = HasResource
    type = HasResource

    // The name of the resource to check for.
    //
    // Type:      <a href="Resource-Type">Resource</a>
    // Required:  Yes
    //
    resource = LiquidFuel

    // Minimum and maximum quantity of the resource required.
    //
    // Type:      <a href="Numeric-Type">double</a>
    // Required:  No (defaulted)
    // Default:   0.01 (minQuantity)
    //            double.MaxValue (maxQuantity)
    //
    minQuantity = 10.0
    maxQuantity = 1000.0

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Resource: &lt;resource&gt;: &lt;quantity_description&gt;
    //title =
}
</pre>

For the extended mode, the above parameters may instead be placed inside RESOURCE blocks (which can be repeated):

<pre>
PARAMETER
{
    name = HasResource
    type = HasResource

    RESOURCE
    {
        // The name of the resource to check for.
        //
        // Type:      <a href="Resource-Type">Resource</a>
        // Required:  Yes
        //
        resource = LiquidFuel

        // Minimum and maximum quantity of the resource required.
        //
        // Type:      <a href="Numeric-Type">double</a>
        // Required:  No (defaulted)
        // Default:   0.01 (minQuantity)
        //            double.MaxValue (maxQuantity)
        //
        minQuantity = 10.0
        maxQuantity = 1000.0
    }

    RESOURCE
    {
        resource = Oxidizer
        minQuantity = 10.0
        maxQuantity = 1000.0
    }

    // Text to use for the parameter
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   Resource: &lt;resource&gt;: &lt;quantity_description&gt;
    //title =
}
</pre>

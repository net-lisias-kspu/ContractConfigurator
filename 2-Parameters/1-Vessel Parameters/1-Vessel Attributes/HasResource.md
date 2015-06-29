##### HasResource
Parameter to indicate that the Vessel in question must have a certain quantity of a certain resource (or must have fewer than a certain number).

    PARAMETER
    {
        name = HasResource
        type = HasResource

        // The name of the resource to check for
        resource = LiquidFuel

        // Minimum quantity, default = 0.01
        minQuantity = 10.0

        // Maximum quantity, default = double.MAXVALUE
        maxQuantity = 1000.0

        // Text to use for the parameter
        // Default Resource: <resource>: <quantity_description>
        //title =
    }

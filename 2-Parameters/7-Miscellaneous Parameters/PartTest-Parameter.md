PartTest is for testing parts (or just activating them, for staged parts).  This parameter supports child parameters - you will only be able to complete the part test if all child parameters are also completed.

<pre>
PARAMETER
{
    name = PartTest
    type = PartTest

    // The part to be tested.
    //
    // Type:      <a href="AvailablePart-Type">AvailablePart</a>
    // Required:  Yes
    //
    part = SmallGearBay

    // Additional notes to display (in the Squad PartTest contract, this is 
    // where they say "Activate through the staging system", etc.)
    // Default = Test this part anywhere, no other requirements!
    // notes =
}
</pre>

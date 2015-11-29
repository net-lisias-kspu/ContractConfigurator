PartTest is for testing parts (or just activating them, for staged parts).  This parameter supports child parameters - you will only be able to complete the part test if all child parameters are also completed.

Typically, this is used in tandem with the [[ExperimentalPart Behaviour|ExperimentalPart-Behaviour]] to unlock a part as experimental so that it can be tested.

Also, for a part to work with PartTest, the part needs to have a `ModuleTestSubject` in the part configuration.  There are two relevant fields, `useStaging` (which indicates the test is done through staging), and `useEvent` (which gives a Run Test option).  The other fields are used by the stock PartTest contract.

It is possible to add `ModuleTestSubject` to parts that don't already have it using Module Manager.

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

The RecoverKerbal parameter is met when the named Kerbal is "recovered" (ie. goes back in to the available list at the astronaut complex).  This is from the Squad "rescue" contracts.

<pre>
PARAMETER
{
    name = RecoverKerbal
    type = RecoverKerbal

    // The Kerbal(s) to be recovered.
    //
    // Type:      <a href="Kerbal-Type">Kerbal</a>
    // Required:  No (multiples allowed)
    //
    kerbal = Jebediah Kerman

    // Alternate method of identifying the Kerbal - zero based index of the
    // entry in a <a href="SpawnKerbal-Behaviour">SpawnKerbal</a> or <a href="SpawnVessel-Behaviour">SpawnVessel</a> BEHAVIOUR node.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   0
    //
    //index = 0

    // Text to use for the parameter
    // Default = 
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (defaulted)
    // Default:   &lt;kerbal&gt;: Recovered
    //
    //title =
}
</pre>

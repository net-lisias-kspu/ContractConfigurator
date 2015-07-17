Behaviour for unlocking a part.  Note that if the player isn't playing with part unlocking that this behaviour does nothing!

<pre>
BEHAVIOUR
{
    name = UnlockPart
    type = UnlockPart

    // The name of the part to unlock on completion of the contract.
    //
    // Type:      <a href="AvailablePart-Type">AvailablePart</a>
    // Required:  Yes (multiples allowed)
    //
    part = mk1pod

    // Whether to also unlock the technology for this part.  Note that if the
    // technology is not already unlocked and this is set to false, the part
    // <strong>cannot</strong> be unlocked (the behaviour just won't do
    // anything).
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    unlockTech = true
}
</pre>

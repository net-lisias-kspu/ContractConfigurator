Behaviour for adding and removing experimental parts.

<pre>
BEHAVIOUR
{
    name = ExperimentalPart
    type = ExperimentalPart

    // The name of the part to add/remove.
    //
    // Type:      <a href="AvailablePart-Type">AvailablePart</a>
    // Required:  Yes (multiples allowed)
    //
    part = largeSolarPanel
    part = cupola

    // Whether the part should be added as an experimental part (when the
    // contract is accepted).  Also controls whether the part is removed
    // if the contract fails or is withdrawn.
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    add = True

    // Whether the part should be removed as an experimental part (when the
    // contract completes successfully).
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   true
    //
    remove = True
}
</pre>

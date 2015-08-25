Behaviour for unlocking a technology.  Note that this does not respect the ordering in the tech tree (it can unlock a node that doesn't have its prerequisites unlocked).  Use the [[CanResearchTech|CanResearchTech-Requirement]] requirement to guard against that condition.

<pre>
BEHAVIOUR
{
    name = UnlockTech
    type = UnlockTech

    // The ID of the technology to unlock on completion of the contract
    // this behaviour is tied to.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Yes (multiples allowed)
    //
    techId = engineering101
}
</pre>

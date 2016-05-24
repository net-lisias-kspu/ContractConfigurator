The AwardExperience contract behaviour awards a crew of a vessel (determined via a [[VesselParameterGroup|VesselParameterGroup-Parameter]] parameter), or a list of Kerbals a set amount of experience after the contract completes.

Note that there are some caveats due to the limitations of KSP's experience system:
 1. The experience will show up in the flight log as "Special experience from Kerbin" (or Earth in RSS).  This is regardless of whether the experience actually occured on another celestial body.  It must be done this way because other bodies have higher multipliers that we do not want applied to this experience.
 1. The experience will replace the 2 points of experience for orbiting Kerbin.  If a crew member has not been given points for orbiting Kerbin, they will get them for free (so a fresh crew member being given 1 XP will actually end up with a total of 3 XP).

<pre>
BEHAVIOUR
{
    name = AwardExperience
    type = AwardExperience

    // The name of the <a href="VesselParameterGroup-Parameter">VesselParameterGroup</a> parameter that defines the vessel
    // whose crew we will be awarding experience to.  The list of crew members
    // is saved at the time of the parameter's completion.  When the contract
    // completes, these crew members will be awarded the experience.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  No (multiples allowed)
    //
    parameter = VesselParameterGroupParameterName

    // Kerbal(s) to award experience to (use instead of parameter to award to
    // specific Kerbals).
    //
    // Type:      <a href="Kerbal-Type">Kerbal</a>
    // Required:  No (multiples allowed)
    //
    kerbal = Kerman Kerman

    // The name of the <a href="VesselParameterGroup-Parameter">VesselParameterGroup</a> parameter that defines the vessel
    // who's crew we will be awarding experience to.  The list of crew members
    // is saved at the time of the parameter's completion.  When the contract
    // completes, these crew members will be awarded the experience.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Yes (multiples allowed)
    //
    parameter = VesselParameterGroupParameterName

    // The amount of experience to award.
    //
    // Type:      <a href="Numeric-Type">int</a>
    // Required:  No (defaulted)
    // Default:   1
    //
    experience = 2

    // Whether the experience should be immediately awarded, or if it should
    // only take effect when the crew member returns home (ie. stock logic)
    //
    // Type:      <a href="Boolean-Type">bool</a>
    // Required:  No (defaulted)
    // Default:   false
    //
    awardImmediately = false
}
</pre>

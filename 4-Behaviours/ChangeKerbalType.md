Behaviour for changing the details of a Kerbal.

<pre>
BEHAVIOUR
{
    name = ChangeKerbalType
    type = ChangeKerbalType

    // The KERBAL_INFO node indicates the Kerbal and the changes to be made.
    // This can be specified multiple times for different Kerbals.
    KERBAL_INFO
    {
        // The Kerbal to make changes to.
        //
        // Type:      <a href="Kerbal-Type">Kerbal</a>
        // Required:  No
        //
        kerbal = Jebediah Kermin

        // The new type of the Kerbal.
        //
        // Type:      <a href="Enumeration-Type">ProtoCrewMember.KerbalType</a>
        // Required:  No
        // Values:
        //     Applicant
        //     Crew
        //     Tourist
        //     Unowned
        //
        kerbalType = Crew

        // The new experience trait for this Kerbal.
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  No
        //
        trait = Scientist
    }
}
</pre>

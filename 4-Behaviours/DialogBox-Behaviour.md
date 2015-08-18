Behaviour for creating a dialog box that supports images, rich text and animated Kerbal heads.  For details on the tags supported in the text, see the [[Unity Documentation|http://docs.unity3d.com/Manual/StyledText.html]].

<pre>
BEHAVIOUR
{
    name = DialogBox
    type = DialogBox

    // The DIALOG_BOX child node represents a single dialog box (the behaviour
    // can create multiple dialog boxes).  If multiple dialog boxes contain the
    // same conditions, they will be displayed sequentially (based on the order
    // they are defined in this file).
    DIALOG_BOX
    {
        // Title of the dialog box.  If not supplied a window without a title
        // is created
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  No
        // 
        title = This is a dialog box

        // The condition under which the dialog box should be displayed.
        //
        // Type:      <a href="Enumeration-Type">DialogBox.TriggerCondition</a>
        // Required:  Yes
        // Values:
        //     CONTRACT_ACCEPTED
        //     CONTRACT_COMPLETED
        //     CONTRACT_FAILED
        //     VESSEL_PRELAUNCH
        //     PARAMETER_COMPLETED
        //     PARAMETER_FAILED
        //
        condition = PARAMETER_COMPLETED

        // The *name* of the parameter to which this condition applies.
        // Required if the condition is one of the PARAMETER_ ones.
        //
        // Type:      <a href="String-Type">string</a>
        // Required:  See above
        //
        parameter = MyParameterName

        // The horizontal positioning of the the dialog box on the screen.
        //
        // Type:      <a href="Enumeration-Type">DialogBox.Position</a>
        // Required:  No (defaulted)
        // Values:
        //     LEFT (default)
        //     CENTER
        //     RIGHT
        //
        position = LEFT

        // Width as a percentage (between 0.0 and 1.0) of the equivalent 4:3
        // screen width.  This is calculated this way to provide a
        // relatively consistent look across a wide range of display sizes.
        //
        // Type:      <a href="Numeric-Type">float</a>
        // Required:  No (defaulted)
        // Default:   0.8
        //
        width = 0.3

        // Height as a percentage (between 0.0 and 1.0) of the screen height.
        // If the content requires more room, this will automatically grow to
        // accomodated it, so it is recommended to leave this out.
        //
        // Type:      <a href="Numeric-Type">float</a>
        // Required:  No (defaulted)
        // Default:   0.0
        //
        height = 0.3

        // Color of the title text.  This can be specified as an HTML color
        // value.
        //
        // Type:      Color
        // Required:  No (defaulted)
        // Default:   #FFFFFF (white)
        //
        titleColor = #BADA55
    }
}
</pre>

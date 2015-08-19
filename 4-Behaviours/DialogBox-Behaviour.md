Behaviour for creating a dialog box that supports images, rich text and animated Kerbal heads.  For details on the tags supported in the text, see the [Unity Documentation](http://docs.unity3d.com/Manual/StyledText.html).

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


        // The following nodes represent sections that can be in a dialog box.
        // These can be combined in any order, and any section repeated any
        // number of times

        // The TEXT section represents a block of text.
        TEXT
        {
            // Text to appear in the dialog box.  It can have embedded newlines
            // using \n, as well as rich text using the HTML tags supported by
            // Unity's <a href="http://docs.unity3d.com/Manual/StyledText.html">rich text</a>.
            //
            // Type:      <a href="String-Type">string</a>
            // Required:  Yes
            // 
            text = This is the text that appears in the dialog box.

            // Size of the text.
            //
            // Type:      <a href="Numeric-Type">int</a>
            // Required:  No (defaulted)
            // Default:   16
            //
            fontSize = 20

            // Color of the text.  This can be specified as an HTML color
            // value.
            //
            // Type:      Color
            // Required:  No (defaulted)
            // Default:   #CCCCCC (grey)
            //
            textColor = #BADA55
        }

        // The IMAGE section allows an external image to be displayed.
        IMAGE
        {
            // The URL of the image (path relative to the GameData directory).
            // This can be any type of image that KSP can load, although DDS is
            // generally recommended.
            //
            // Type:      <a href="String-Type">string</a>
            // Required:  Yes
            // 
            url = ContractPacks/SomeContractPack/SomeImage

            // If the image represents a character, the name of the character
            // to be displayed immediately below the image.  If not specified,
            // nothing is displayed beneath the image.
            //
            // Type:      <a href="String-Type">string</a>
            // Required:  No
            // 
            characterName = My Kerbal Kerman

            // Color of the character text (if being used).  This can be
            // specified as an HTML color value.
            //
            // Type:      Color
            // Required:  No (defaulted)
            // Default:   #BADA55 (badass green)
            //
            textColor = #BADA55
        }

        // The INSTRUCTOR section allows one of the special Kerbal animated
        // avatars to be displayed (such as Gene or Wernher).
        INSTRUCTOR
        {
            // The name of the instructor to display.  Specifically, this is
            // the name of the Unity asset to be loaded.
            //
            // Type:      <a href="String-Type">string</a>
            // Required:  Yes
            // Values:
            //     Instructor_Gene
            //     Instructor_Wernher
            //     Strategy_Mortimer
            //     Strategy_PRGuy (this is Walt)
            //     Strategy_ScienceGuy (this is Linus)
            //     Strategy_MechanicGuy (this is Gus)
            // 
            name = Instructor_Gene

            // Whether to display the character name below the Avatar.
            //
            // Type:      <a href="Boolean-Type">bool</a>
            // Required:  No (defaulted)
            // Default:   true
            //
            showName = true

            // A character name to use instead of the default name of the
            // character.
            //
            // Type:      <a href="String-Type">string</a>
            // Required:  No (defaulted)
            // 
            characterName = Some Other Guy Kerman

            // Color of the character text (if being used).  This can be
            // specified as an HTML color value.
            //
            // Type:      Color
            // Required:  No (defaulted)
            // Default:   #BADA55 (badass green)
            //
            textColor = #BADA55

            // The animation that should be played.  If not supplied, the
            // character's default idle animation is played
            //
            // Type:      <a href="Enumeration-Type">DialogBox.InstructorSection.Animation</a>
            // Required:  No
            // Values:
            //     idle
            //     idle_lookAround
            //     idle_sigh
            //     idle_wonder
            //     true_thumbUp
            //     true_thumbsUp
            //     true_nodA
            //     true_nodB
            //     true_smileA
            //     true_smileB
            //     false_disappointed
            //     false_disagreeA
            //     false_disagreeB
            //     false_disagreeC
            //     false_sadA
            // 
            animation = true_thumbsUp
        }

        // The KERBAL section is similar to INSTRUCTOR in that it shows an
        // avatar of a Kerbal.  However, the KERBAL avatars represent vessel
        // crew or astronauts in the astronaut complex.  The following logic
        // is used to determine which Kerbal is selected for the avatar:
        //   1) If characterName is supplied, that is the Kerbal that is used.
        //   2) Otherwise, select a character from the active vessel, based
        //      on the values of crewIndex and excludeName
        //   3) If a selection still cannot be made (the vessel is uncrewed,
        //      or the index out of range for the given crew), then a random
        //      kerbal name and gender are generated (the Kerbal is assumed to 
        //      be in the Astronaut Complex.  This is intended as a fallback to
        //      avoid empty dialog boxes and shouldn't be relied upon.
        KERBAL
        {
            // The character this dialog box should be for.  If the character
            // is a real Kerbal that can be found in the save game, they will
            // be used.  Otherwise, a generic Kerbal portrait will be displayed.
            //
            // Type:      <a href="String-Type">string</a>
            // Required:  No (defaulted)
            // 
            characterName = Valentina Kerman

            // If a characterName is not supplied, then this will be used as an
            // index into the crew list of the current active vessel.  This
            // could be used to set up a conversation between two members of a
            // vessel crew.
            //
            // Type:      <a href="Numeric-Type">int</a>
            // Required:  No (defaulted)
            // Default:   0
            //
            crewIndex = 0

            // A List of names that are to be excluded when searching a vessel
            // crew for a Kerbal to use.  This could be used to set up a
            // conversation between a known crew member and a different crew
            // member.
            //
            // Type:      <a href="String-Type">string</a>
            // Required:  No (Multiples allowed)
            // 
            excludeName = Bob Kerman
            excludeName = Bill Kerman

            // The gender of the character.  Only used if characterName is
            // specified, and the character is not one that can be found in the
            // game.
            //
            // Type:      <a href="Enumeration-Type">ProtoCrewMember.Gender</a>
            // Required:  No
            // Values:
            //     Male
            //     Female
            // 
            gender = Female

            // Whether to display the character name below the Avatar.
            //
            // Type:      <a href="Boolean-Type">bool</a>
            // Required:  No (defaulted)
            // Default:   true
            //
            showName = true

            // Color of the character text (if being used).  This can be
            // specified as an HTML color value.
            //
            // Type:      Color
            // Required:  No (defaulted)
            // Default:   #BADA55 (badass green)
            //
            textColor = #BADA55
        }
    }
}
</pre>

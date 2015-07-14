Behaviour for spawning one or more Vessels on land or in orbit.  Note that one needs to be very careful when putting together .craft files for use with this parameter:

* Be careful what parts are used in the construction of the vessel.  Using a part from an add-on effectively means that the contract will be dependent on the player having that add-on.
* Be careful of other add-ons that are installed that add part modules to parts you are using.  A couple specific examples:
 * The mod MechJeb and Engineer for all adds the MechJeb/KER PartModule to all probe cores and command modules.  This will make your mod incompatible for players not using MechJeb/KER.
 * RemoteTech replaces the stock antenna PartModule with its own.  Unfortunately, this is a two way street - building a craft without RemoteTech means that the resulting craft won't have the correct antenna modules if the player is using RemoteTech.
```
BEHAVIOUR
{
    name = SpawnVessel
    type = SpawnVessel

    // (Optional) Use this to defer the creation of the vessel until the flight scene is loaded.
    // This works around the issue that the vessel is initially loaded in the actual VAB building,
    // and if the vessel is too big will be visible as it clips outside the VAB.  However, vessels
    // with many parts (the RTG for sure) fail on a resource exception when loaded - loading them
    // earlier works around the issue slightly.  This is a stock bug that will hopefully be fixed
    // in the near future (it exists in 1.0.2 for sure).
    // Default = false
    deferVesselCreation = false

    // The VESSEL node indicates a vessel to spawn and can be specified
    // multiple times.
    VESSEL
    {
        // If the name is not supplied, defaults from the name within the
        // craft file.  Note that this name behaves like the
        // VesselParameterGroup define field - in other words, you may
        // refer back to this vessel by this name in VesselParameterGroup
        // parameters.
        name = A vessel

        // Path to the .craft file (relative to the GameData/ directory)
        craftURL = ContractConfigurator/Little Rocket.craft

        // Location of the flag to use.
        // Default = Player's flag for the current game
        flagURL = Squad/Flags/satellite

        // The type of vessel (affects display in the tracking station).
        // Valid values from VesselType enum:
        // Base
        // Lander
        // Probe
        // Rover
        // Ship (default)
        // Station
        // Unknown
        vesselType = Rover

        // Whether the vessel should show up as owned or unowned.  If it is
        // owned, then it will be immediately selectable.
        owned = False

        // Where the vessel should spawn - defaulted from the contract if
        // not supplied.
        targetBody = Kerbin

        // The ORBIT node indicates the orbit the vessel is in.  The
        // easiest way to get this information is to create the orbit
        // you want in KSP (using HyperEdit or good old fashioned
        // rocket science), and save your game.  In the persistant.sfs
        // file, search for your craft, and find the ORBIT node.
        //
        // Note that REF represents the reference body - but will be
        // overriden by the targetBody.
        // 
        // The ORBIT node is not used for landed vessels.
        ORBIT
        {
            SMA = 1449999.99996286
            ECC = 1.07570816555399E-05
            INC = 0
            LPE = 270.690311604893
            LAN = 1.93635924563296
            MNA = 1.55872660382504
            EPH = 31.3999999999994
            REF = 1
        }

        // If you wish to specify a landed vessel, you must also 
        // supply the following values from the persistant.sfs
        // file.
        lat = -0.096992729723051
        lon = 285.425467968966

        // Only applies to landed vessels, use to override the altitude.
        // If not supplied, defaults to the terrain altitude.
        alt = 67.6843734193826

        // Specifies the heading of the vessel in degrees (0 = N, 90 = E...).
        // Default = 0
        heading = 180

        // Specifies the roll of the vessel in degrees (positive = roll right).
        // Default = 0
        roll = 45

        // Specifies the pitch of the vessel in degrees (positive is nose up)
        // Default = 0.
        pitch = 30

        // A CREW node indicates one or more crew members to add to the
        // vessel.  The CREW node may be specified multiple times.
        CREW
        {
            // Name for the crew member - if not provided, one is
            // auto-generated.
            name = Patrick R. Kerman

            // Whether or not the Kerbal should be added to the roster on 
            // recovery.
            // Default = True
            addToRoster = True

            // Number of crew to generate from this node.  Shouldn't be
            // supplied if name is supplied.
            // Default = 1
            count = 1
        }
    }
}
```

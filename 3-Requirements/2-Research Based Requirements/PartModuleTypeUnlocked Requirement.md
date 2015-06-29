Requirement for having a "type" of PartModule unlocked from the tech tree.

    REQUIREMENT
    {
        name = PartModuleTypeUnlocked
        type = PartModuleTypeUnlocked

        // Type of PartModule that needs to be unlocked.  Can be specified
        // multiple times.  Valid values are defined in
        // Squad/Contracts/Contracts.cfg under MODULE_DEFINITIONS:
        //   Antenna
        //   Dock
        //   Grapple
        //   Power
        //   Wheel
        partModuleType = Antenna
        partModuleType = Power
    }

# Contract Configurator :: Change Log

* 2018-0826: 1.25.0.2 (Lisias) for KSP 1.4.x
	+ A proper fix for the ISatellite Interface. See [forum](https://forum.kerbalspaceprogram.com/index.php?/topic/91625-142-contract-configurator-v1250-2018-04-15/&do=findComment&comment=3440424) for details. 
* 2018-0826: 1.25.0.1 (Lisias) for KSP 1.4.x
	+ Updating to RemoteTech 1.9 
		+ New method on ISatellite Interface
	+ Null Reference prevented on the Experience Trait Parser
		+ This doesn't fix the component feeding the Parser with a null object, but at least keep things running.	 
		+ Corolary: this is not a proper fix.
* 2018-0416: 1.25.0 (jrossignol) for KSP 1.4.
	+ Added ExperienceTrait to parser.
	+ Kerbal.ExperienceTrait now returns an ExperienceTrait instead of a localised string.
	+ Increased max active contract multiplier slider maximum from 2.0 to 8.0.
	+ Support for RemoteTech 1.8.10.3 (thanks wraithan).
* 2018-0405: 1.24.4 (jrossignol) for KSP 1.4.
	+ Properly work around stock bug.
* 2018-0402: 1.24.3 (jrossignol) for KSP 1.4.
	+ Proper fix for last release (thanks Warezcrawler).
* 2018-0402: 1.24.2 (jrossignol) for KSP 1.4.
	+ Workaround for stock bug #18267 (contract parameters creating extra messages on completion).
* 2018-0330: 1.24.1 (jrossignol) for KSP 1.4.
	+ Recompile against KSP 1.4.2
	+ Re-enabled RemoteTech and Kerbal Konstructs integration for KSP 1.4.x.
	+ Fix error message when despawning spawned Kerbals (thanks steve_v).
	+ Added a warning message when validation errors prevent a DATA_EXPAND node from being parsed (thanks gyf1214).
	+ Fixed NRE when checking progress nodes (thanks DocMop).
	+ Fixed issue with duplicate assembly warning showing up when it shouldn't (thanks Gordon Dry).
	+ Fixed some issues with handling of newlines in config nodes (thanks inigma).
	+ Use case insensitive string comparison when loading celestial bodies in saved expressions (thanks gyf214).
* 2018-0312: 1.24.0 (jrossignol) for KSP 1.4.0
	+ Recompile for KSP 1.4.0
	+ Added back MODULE checks in simple version of PartValidation (thanks chrisl).
	+ Support RemoteTech 1.8.9 (thanks vader111).
	+ Read date/time information from dateTimeFormatter (thanks Aelfhe1m).
* 2017-1006: 1.23.3 (jrossignol) for KSP 1.3.1
	+ Recompile for KSP 1.3.1
	+ Improved display of HasAntenna parameter ratings (thanks Kerbas-ad-astra).
	+ Fixed logic for determining contract prestige (thanks sopindm).
	+ Fixed previously unlocked parts being re-locked if player tries to buy a science node they don't have sufficient funds for (thanks inigma).
	+ Fixed issue using DATA_EXPAND with values that had special characters in them.  Fixes interop issues between CatEye and Other Worlds Planet pack (thanks Chemox).
* 2017-0804: 1.23.2 (jrossignol) for KSP 1.3.0
	+ Clarified wording of ActiveVesselRangeRequirement for RemoteTech (thanks Alshain).
	+ Added check for old usage of partModuleType=Power (thanks muppet9876).
	+ Prevent Rendezvous parameter from completing when doing an EVA (thanks pap1723).
	+ Don't allow main menu to continue while still loading (prevents issues on slower systems).
	+ Made RemoteTech distance function (for coverage system) more generous (thanks NathanKell).
	+ Fixed issue with Kerbals spawned at KSC starting an extra ~60 meters in the air (thanks Keniamin).
	+ Fixed error when cancelling a contract with spawned Kerbals.
	+ Fixed exception with FlyBy and ReturnFromFlyBy requirements.
	+ Properly fixed Facility requirement in the tracking station (thanks Kerbas_ad_astra).
	+ Fixed NRE from struts breaking (thanks Alshain).
	+ Fixed multiple exceptions when using Sigma Binary (thanks Rodger).
* 2017-0611: 1.23.1 (jrossignol) for KSP 1.3.0
	+ Fixed major bug with VisitWaypoint not properly setting waypoint distances (thanks Keniamin and others).
	+ Fixed issue with FacilityRequirement in tracking station (thanks JPLRepo).
	+ Fixed issue where some requirement details weren't being saved in contracts.
	+ Fixed localisation issue with character names in dialog boxes.
	+ Fixed exception when pressing orbit buttons in tracking station (thanks doktorstick).
* 2017-0604: 1.23.0 (jrossignol) for KSP 1.3.0
	+ Support for KSP 1.3.0
	+ Fix issue with contract item sizes not always being set correctly in mission control when switching tabs.
	+ Fixed "input is null" error in Docking parameter (thanks linuxgurugamer).
	+ Fixed to not generate contracts without parameters (thanks severedsolo).
	+ Fixed Sigma Dimensions compatibility issue with atmosphere height (thanks pap1723 and Sigma88).
* 2016-1217: 1.22.2 (jrossignol) for KSP 1.2
	+ Fix possible argumentOfPeriapsis issue (thanks Intrepidrd).
* 2016-1215: 1.22.1 (jrossignol) for KSP 1.2
	+ Fixed issue with vessel identifier parsing introduced in 1.22.0 (thanks Li0n).
* 2016-1215: 1.22.0 (jrossignol) for KSP 1.2
	+ Added HasAntenna parameter (thanks Kerbas-ad-astra).
	+ Added Vessel.AntennaTransmitPower() and Vesse.AntennaRelayPower() (thanks Kerbas-ad-astra).
	+ Contract weights for celestial bodies are now set by Contract Configurator (affecting the likelihood of stock contracts generating for the given body).
	+ Added minArgumentOfPeriapsis and maxArgumentOfPeriapsis to Orbit parameter.
	+ Added horizontalDistance to VisitWaypoint.
	+ Make references to 'Sun' generic in SolarScience.cfg to fix Galileo compatibility (thanks SirBriguy).
	+ Added Sun() function to get the Sun in a non-name specific way.  Assumes a single star.
	+ Change enum parse to be case insensitive.
	+ Change Vessel Identifier parsing to allow a wider range of characters.
	+ Fixed format text for funding message in mission control (thanks JPLRepo).
	+ Fixed issue with NextUnreachedBody() call caching results (thanks severedsolo).
* 2016-1104: 1.21.0 (jrossignol) for KSP 1.2
	+ Found new workaround for GetExportedTypes reflection issue (the "toolbar" issue).
	+ Added NextUnreachedBody() and NextUnreachedBodies() methods.
	+ Added Part.MassDry() and Part.MassWet() methods.
	+ Added CelestialBody.CanHaveSynchronousOrbit() method.
	+ Recompile Kerbal Konstructs integration.
	+ Fixed contract window text not updating for dynamic text (duration timers, etc.).
* 2016-1025: 1.20.3 (jrossignol) for KSP 1.2
	+ Regenerate biome data for KSP 1.2 biomes (fixes Field Research "Rare Science" contracts, thanks FlatEric).
	+ Added RemoteTech integration back in.
	+ Fixed issue with nested contract groups not working (thanks jeisen).
* 2016-1022: 1.20.2 (jrossignol) for KSP 1.2
	+ Support for KSP 1.2
	+ Allow contract title in mission control to span two lines.
	+ Moved settings into stock settings screen.
	+ Fixed NRE when vessel's Landed At string is null (thanks SamLex).
	+ Check for sufficient funds when there are negative contract advances (thanks 5thHorseman).
	+ Fixed display issue with partially complete CollectScience parameters.
* 2016-0928: 1.20.1 (jrossignol) for KSP 1.2 PRE-RELEASE
	+ Moved settings into stock settings screen.
	+ Compatibility with latest KSP pre-releases
* 2016-0914: 1.20.0 (jrossignol) for KSP 1.2 PRE-RELEASE
	+ Support for KSP 1.2
	+ Fixed NRE when vessel's Landed At string is null (thanks SamLex).
* 2016-0905: 1.19.0 (jrossignol) for KSP 1.1.3
	+ Added Part.UnlockCost().
	+ Added Part.Resources().
	+ Added Part.ResourceCapacity().
	+ Reworked ParameterDelegate - worst source of in-flight LINQ (ie. garbage).
	+ Check contract requirements before displaying them in mission control in case something has changed.
	+ Fixed issues with part parser (thanks 5thHorseman).
	+ Fixed exception in Mission Control (thanks Conventia & AccidentalDisassembly).
	+ Fixed a NullReferenceException in PartValidation.
	+ Fixed an incorrect condition on the ReseachBodies check which caused heaps of garbage to be created (thanks xEvilReeperx).
	+ Fixed issue with Duration parameter not kicking off correctly in some circumstances (thanks 5thHorseman).
* 2016-0827: 1.18.1 (jrossignol) for KSP 1.1.3
	+ Fixed NRE on contract save (thanks CecilFF4).
* 2016-0826: 1.18.0 (jrossignol) for KSP 1.1.3
	+ New Base and ISRU agent icons from Enceos.
	+ Added Resource.Density() method.
	+ Added partModule and partModuleType to TechResearchedRequirement.
	+ Fixed problem with requirement data for offered data not getting fixed until contract save (thanks severedsolo).
	+ Fixed sorting of contract groups (thanks pap1723).
	+ Fixed Resource parsing limitations (thanks hargn).
	+ Fixed issue with DATA nodes and child contract groups (thanks hargn).
	+ Disallow DMOS Seismic Impact Hammer at KSC in science subsystem (thanks BeafSalad).
	+ Remove short-circuit in Any/All requirement texts for players aren't given incorrect information (thanks inigma).
	+ Fixed an issue that prevented expressions from working in resource loading (thanks hargn).
	+ Cycle through new contracts to generate in a random order to prevent certain contracts from getting preference.
	+ Fixed issue where contract expiries were never getting set (thanks DarkonZ).
	+ Fixed issue with some parameters combined with the All parameter causing incorrect contract failure (thanks tomf).
	+ Fixed issue with selected contract in mission control getting unselected when a new contract is generated (thanks AccidentalDisassembly).
* 2016-0809: 1.17.0 (jrossignol) for KSP 1.1.3
	+ Mission Control remembers the last visited tab when you open it, and takes you there.
	+ Added Tracking Station buttons for filtering orbits/waypoints from contracts.
	+ Added support for adding loading tool tips.
	+ Better support for Kolniya/Tundra orbits - will error if the orbit would exit the SOI.  Also added CelestialBody methods to determine if the body is allowed to have Kolniya/Tundra orbits.
	+ Fix for contracts not being offered on a brand new save until at least one stock contract is offered (thanks to all the RP-0 users who reported this).
	+ Fixed issue where parameter completion data wasn't correctly copied to newly created vessel on undock/decouple (thanks linuxgurugamer).
	+ Fixed DraftTwitchViewers support.
	+ Fixed issue with using Enter button to go to Mission Control (thanks Deimos Rast).
	+ Fixed agent for stock satellite contracts.
	+ Fixed issue with sortKey in child contract groups (thanks pap1723).
* 2016-0730: 1.16.2 (jrossignol) for KSP 1.1.3
	+ Fix exception error messaging.
* 2016-0730: 1.16.1 (jrossignol) for KSP 1.1.3
	+ Silence Research Bodies error (thanks Liondrome).
	+ Fixed problems with ResearchBodies support (it was offering some contracts that it shouldn't have).
* 2016-0729: 1.16.0 (jrossignol) for KSP 1.1.3
	+ Support for ResearchBodies - contracts won't be offered until the appropriate body has been researched (thanks JPLRepo).
	+ Integrated support for Kerbal Konstructs directly into Contract Configurator.
	+ New NoStaging parameter.
	+ Agent data for stock contracts is now defined in a cfg file, instead of hardcoded (see CONTRACT_DEFINITION in documentation).
	+ Properly factor in autoAccept contracts when deciding whether to enable the accept button in Mission Control (thanks ETM, Nightside & Aelfhe1m).
	+ Fixed issue with contract generation process starting up before the stock contract system was done loading.  This would cause contracts to be offered that weren't supposed to be offered, which could cause other issues (like a contract that can be accepted but is then removed, or an active contract that gets removed unexpectedly).  Thanks to everyone who's been very patient on this nasty & hard to track down bug.
	+ Fixed contracts that didn't properly expire once the expiry date hit.
	+ Increased default expiry dates (since long expiries no longer prevent other contracts from generating).
* 2016-0726: 1.15.5 (jrossignol) for KSP 1.1.3
	+ Updated agent icons from Enceos.
	+ Fixed issue introduced in 1.15.x with Prestige() function that incorrectly treated all contracts as Trivial.
	+ Fixed issue with text for Funds/Science/Reputation requirements.
	+ Fixed issue with sorting in Available tab of Mission Control.
	+ Fixed exception when declining/cancelling contracts in Mission Control.
* 2016-0726: 1.15.4 (jrossignol) for KSP 1.1.3
	+ Increased base contract limits.
	+ Increased contract limits based on building level.
	+ Increased contract limits even more based on building level.
	+ Fixed issue where contract limits could be exceeded in the Available tab of Mission Control (thanks severedsolo).
	+ Fixed possible exception in HasCrew (thanks cpottinger).
	+ Fixed issue with "ghost" contracts showing up as offered (thanks vardicd & severedsolo).
	+ Fixed issue with MaxTechLevelUnlocked function (thanks hargn).
	+ Removed MiniAVC.
* 2016-0723: 1.15.3 (jrossignol) for KSP 1.1.3
	+ New Mission Control layout. Now all contracts that are eligible are available all the time (players are no longer at the mercy of the RNG to get the contracts they want).  Also, can view the details of what contracts are _not yet_ available, and what it takes to make them available.
	+ New contract art (special thanks to Enceos)!
	+ Contract generation overhaul.  Overhaul to the contract generation system for massive performance improvements.  Contracts are no longer generated in-flight (no garbage, no stutters).
	+ Added title and related attributes for REQUIREMENT nodes.
	+ Added title and related attributes for DATA nodes.
	+ Added sortKey for CONTRACT_TYPE and CONTRACT_GROUP nodes.
	+ New List.SelectUnique() method for selecting unique values (replaces selecting a random value and hoping that it hasn't been used before).
	+ New DATA_EXPAND node allows a CONTRACT_TYPE to be duplicated across a list of values (eg. duplicated for each Celestial Body).
	+ New CelestialBody.Index() method to get the global index of a body (for sorting).
	+ More warnings to steer contract authors towards more performant and more player-friendly ways of writing contracts.
	+ New ResourceConsumption parameter.
	+ Fixed issue where the state of some parameters wasn't immediately reset when switching vessels, allowing erroneous contract completion (thanks NathanKell & leudaimon).
	+ Fixed bug in uniqueness checks when vessels are involved which caused the uniquness check not to work (thanks severedsolo).
	+ Fixed issue where CollectScience parameters weren't always showing the checkmarks when partially completed (thanks jlcarneiro & severedsolo).
* 2016-0720: 1.15.2 (jrossignol) for KSP 1.1.3 PRE-RELEASE
	+ Pre-release with still more functionality and bugfixes. See forum thread for more details.
* 2016-0711: 1.15.1 (jrossignol) for KSP 1.1.3 PRE-RELEASE
	+ Pre-release with more functionality and some bugfixes.  See [forum thread](http://forum.kerbalspaceprogram.com/index.php?/topic/91625-113-contract-configurator-v1140-2016-06-30/&page=125) for more details.
* 2016-0708: 1.15.0 (jrossignol) for KSP 1.1.3 PRE-RELEASE
	+ Pre-release version of Contract Configurator 1.15.x changes to aid contract authors in making early changes to their contract packs.
	+ See Contract Configurator thread for more details.
	+ Changes
		- New Mission Control layout. Now all contracts that are eligible are available all the time (players are no longer at the mercy of the RNG to get the contracts they want).  Also, can view the details of what contracts are _not yet_ available, and what it takes to make them available.
		- Contract generation overhaul.  Overhaul to the contract generation system for massive performance improvements.  Contracts are no longer generated in-flight (no garbage, no stutters).
		- Added title and related attributes for REQUIREMENT nodes.
		- Added title and related attributes for DATA nodes.
		- New List.SelectUnique() method for selecting unique values (replaces selecting a random value and hoping that it hasn't been used before).
		- New DATA_EXPAND node allows a CONTRACT_TYPE to be duplicated across a list of values (eg. duplicated for each Celestial Body).
		- More warnings to steer contract authors towards more performant and more player-friendly ways of writing contracts.
* 2016-0701: 1.14.0 (jrossignol) for KSP 1.1.3
	+ Added suppport for partModuleType in PartValidation.
	+ Added AtMost and AtLeast set requirements.
	+ Fixed issue where HasCrew was counting tourists.
	+ Fixed issue where partModuleType = Wheel wasn't picking up the LY-01 fixed landing gear (or any wheel part without a motor).
	+ Fixed issue with VisitWaypoing and WaypointGenerator not correctly update waypoint names when expressions are used.
	+ Reduced LINQ and reflection calls in expression parser for performance/garbage collection improvements.
* 2016-0622: 1.13.0 (jrossignol) for KSP 1.1.3
	+ KSP 1.1.3 compatibility.
	+ Integrated Wider Contracts App into Contract Configurator.
	+ Fixed isuse with SpawnVessels spawning vessels with incorrect rotation (thanks severedsolo).
	+ Prevent Rendenzvous parameter from triggering when a vessel performs a rendezvous with itself (thanks danielguo).
	+ Fixed NRE on contract accept when using SpawnVessel's craftPart method of spawning.
	+ Fixed PartModuleUnlocked and PartUnlocked requirements to check for part purchase and not just tech unlock (thanks inigma).
	+ Always set the CollectScience targetBody to the one from the biome if a biome is used (thanks severedsolo & enceos).
	+ Fixed exception in RecoverKerbal (thanks palleon).
	+ Fixed incorrect handling of waypoints with negative altitude on non-ocean worlds in VisitWaypoint (thanks Galenmacil).
	+ Removed extra ConfiguredContract entries from settings menu (thanks Deimos Rast).
* 2016-0527: 1.12.1 (jrossignol) for KSP 1.1.2.
	+ Fixed backwards compatibility for Wheel PartModuleType (thanks TheReadPanda).
* 2016-0527: 1.12.0 (jrossignol) for KSP 1.1.2.
	+ Added support for NextKerbalHireCost() expression function.
	+ Added HasCrew.excludeKerbal.
	+ Fixed exception in the Expression behaviour (thanks severedsolo).
	+ Fixed deriving primary situation for biomes with a space in the name.
	+ Fixed exception in science util functions (thanks Chippy the Space Dog).
	+ Fixed exception when docking (thanks Lennartos and others).
	+ Fixed logic for setting contract weights that was broken by 1.1.x changes (thanks severedsolo).
	+ Removed some broken validation (thanks linuxgurugamer).
	+ Fixed exception when removing certain contract packs (thanks rasta013).
	+ Fixed edge case where AwardExperience was late awarding the experience (thanks severedsolo).
	+ Fixed exception with Contracts Window + (thanks sidfu).
	+ Improved accuracy of VesselNotDestroyed checks (thanks inigma).
	+ Fixed bug in barycenter logic when using Sigma Binary (thanks sentania).
	+ Improved backwards compatibility with contract packs using the old Wheel module name (thanks galenmacil).
	+ Re-generate PQS offset coordinates when flight begins (workaround for Kopernicus waypoint offset issue).
* 2016-0506: 1.11.5 (jrossignol) for KSP 1.1.2.
	+ Fixed exception when recovering vessel (thanks BluK).
	+ Recompile to RemoteTech 1.7.0.
* 2016-0505: 1.11.4 (jrossignol) for KSP 1.1.2.
	+ Clean up some "Input is null" errors/warnings.
	+ Deprecated VesselParameterDelegator.
	+ Remove support for ancient versions of Module Manager.
* 2016-0430: 1.11.3 (jrossignol) for KSP 1.1.2.
	+ Revert additional check added in 1.11.0 that broke PartModuleTypeUnlocked (thanks KnotaiG).
	+ Work around upgrade issue with ReachSpecificOrbit (thansk Tossy64).
* 2016-0430: 1.11.2 (jrossignol) for KSP 1.1.2.
	+ Recompile against KSP 1.1.2.
	+ Possible fix to PartModuleUnlockedRequirement (thanks AccidentalDisassembly).
	+ Fixed exception when generating autoAccept contracts.
* 2016-0429: 1.11.1 (jrossignol) for KSP 1.1.1
	+ Update to KSP 1.1.1 (release to make CKAN happy).
	+ Compile to latest _dev_ RemoteTech.
* 2016-0428: 1.11.0 (jrossignol) for KSP 1.1)
	+ Performance fixes and improved caching of biome data.
	+ Duration values can now be used in arithmetic and comparisons in expressions.
	+ Added Duration.ToDouble() and Duration().
	+ Added Vessel.MET().
	+ Fixed issue with vessel re-assignment on undock (thanks chrisl).
	+ Improved contract window text when tracking vessels in a VesselParameterGroup.
	+ Improved API for requirement saving/loading.
	+ Add proper error handling to PartModuleTypeUnlocked.
	+ Added ReachSpecificOrbit.displayNotes back in (thanks severedsolo).
	+ Fixed so orbits for offered contract show up in the tracking station and NOT in flight.
	+ Minor bug fixes.
* 2016-0421: 1.10.4 (jrossignol) for KSP 1.1)
	+ Fixed RemoteTech exceptions (thanks HaArLiNsH, Dtgnoome and Sidelia).
* 2016-0421: 1.10.3 (jrossignol) for KSP 1.1)
	+ Fixed contract "flickering" on RemoteTech contracts (thanks Razorfang).
	+ Fixed problems with SCANsat contracts (thanks Torih).
	+ Fixed issues with child requirements not getting properly propagated to offered contracts.
	+ Fixed disabling of contract requirements in debug menu (the contract would appear then immediately disappear).
* 2016-0420: 1.10.2 (jrossignol) for KSP 1.1)
	+ Re-enabled RemoteTech support.
	+ Fixed exception on requirement load of SCANsatLocationCoverage (thanks wizisi2k).
	+ Properly fixed contract "flickering" in mission control.
* 2016-0330: 1.10.1 (jrossignol) for KSP 1.1)
	+ Fixed exception on requirement load of FundsRequirement (thanks EldrinFal).
* 2016-0330: 1.10.0 (jrossignol) for KSP 1.1)
	+ Support for KSP 1.1.
	+ Contract requirements are now saved to persistence file (fixes issues with "flickering" contracts in mission control).
	+ Added VesselValidRequirement to check if a vessel identifier is valid throughout the life of a contract.
	+ Added support for PQSCity in expressions.
	+ Added CelestialBody.PQSCities().
	+ Fixed backwards compatibility on uniqueness checks (thanks eberkain).
	+ Fixed edge case for VesselParameterGroup and completeInSequence (thanks NathanKell and stratochief).
	+ Fixed problem with loading pqsCity and targetBody out of order in WaypointGenerator (thanks severedsolo).
* 2016-0330: 1.9.11_KSP1.0.5 (jrossignol) for KSP 1.0.5)
	+ Added VesselValidRequirement to check if a vessel identifier is valid throughout the life of a contract.
	+ Added support for PQSCity in expressions.
	+ Added CelestialBody.PQSCities().
	+ Fixed backwards compatibility on uniqueness checks (thanks eberkain).
	+ Fixed edge case for VesselParameterGroup and completeInSequence (thanks NathanKell and stratochief).
	+ Fixed problem with loading pqsCity and targetBody out of order in WaypointGenerator (thanks severedsolo).
* 2016-0321: 1.9.10 (jrossignol) for KSP 1.0.5
	+ Fixed exception on undock (thanks henrybauer).
	+ Fixed KerbalDeaths to be checked off (completed) by default (thanks Inigma).
* 2016-0319: 1.9.9 (jrossignol) for KSP 1.0.5
	+ Fixed issue with SCANsat contract that keep recycling (thanks smjjames).
	+ Fixed issue with ReachState not supporting the proper defaulting for targetBody (thanks Brigadier).
	+ Fixed issue with ReachState loading (thanks berkekrkn).
* 2016-0309: 1.9.8 (jrossignol) for KSP 1.0.5
	+ Fixed problem with using multiple targetBody values via expression in ReachState (thanks NathanKell).
	+ Fixed issue with KerbalDeaths not completing correctly (thanks vardicd).
* 2016-0308: 1.9.7 (jrossignol) for KSP 1.0.5
	+ KerbalDeaths now supports a vessel identifier to only check for Kerbal deaths on a specific vessel.
	+ Added support for AlbertKermin's Surface Experiments Pack to science subsystem.
	+ Allow multiple targetBody values in ReachState.
	+ Added new Orbit class with methods.
	+ Fixed default values for RemoteTech CelestialBodyCoverage requirement (thanks severedsolo).
	+ Fixed minor bug in Sigma Binary support.
	+ Fixed possible exception when saving in ContractVesselTracker (thanks apocriva).
	+ Minor bug fixes.
* 2016-0217: 1.9.6 (jrossignol) for KSP 1.0.5
	+ Added kerbal attribute to KerbalDeaths.
	+ Added Vessel.Orbit() method.
	+ Moved Vessel.OrbitX() methods to the Orbit class, added a few new ones.
	+ Added ReachSpecificOrbit.displayNotes to allow disabling of orbit notes.
	+ Allow negative contract rewards.
	+ Added StartinFunds(), StartingReputation() and StartingScience().
	+ Changed HasCrew and HasCrewCapacity to reduce min values when it is larger than the max (thanks severedsolo).
	+ Fixed problem in CollectScience that affected bathymeter experiment from DMagic Orbital Science (thanks smjjames).
	+ Fixed warnings for newer DMagic Orbital Science experiments.
	+ Fixed (Optional) text being output when it shouldn't (thanks Keniamin).
	+ Fixed issue with passenger load dialog being shown with incorrect details (thanks smjjames).
	+ Fixed issue with defineList when the vessel id haapens to start with a number (thanks severedsolo).
	+ Fixed exception when using expressions in Rendezvous parameter (thanks severedsolo).
* 2016-0203: 1.9.5 (jrossignol) for KSP 1.0.5
	+ Output additional log files when log level is debug or higher (thanks linuxgurugamer).
	+ VesselParameterGroup now supports a defineList attribute to add a vessel to a list on contract completion.
	+ PartValidation module checks now check the parent type.  This allows mod-introduced PartModules that inherit from stock ones to count for PartValidation checks that look for the stock module (eg. ModuleEnginesFX = ModulesEngines).
	+ Added SubAssembly as a valid option for CopyCraftFile.craftType.
	+ Added NewKerbals() methods to generate lists of Kerbals.
	+ AwardExperience now supports awarding experience directly to Kerbals (instead of via a VesselParameterGroup).
	+ Limited the impact of a problem where the final Anomaly Surveyor contract causes revert to editor to leave a vessel on the pad (thanks lodestar).
	+ Fixed problem introduced in 1.9.4 where all waypoints without a name get called "site" (thanks smjjames).
	+ Fixed issue where Kerbal spawning behaviours didn't clean up properly when the Kerbal was in a command chair (thanks inigma & nobodyhasthis2).
	+ Fixed issue with Expression requirement bleeding through between different contracts (thanks Yemo, smjjames and nobodyhasthis2).
	+ Added logic to prevent duplicate Kerbal names from coming up in the same (or recent) contracts.
	+ Fixed issue with VesselParameterGroup where the vessel wasn't set correctly when loading a Kerbal into an EVA seat triggered the completion (thanks inigma).
	+ Minor bug fixes.
* 2016-0125: 1.9.4.1 (jrossignol) for KSP 1.0.5
	+ Fixed a major issue where vessel spawning would sometimes fail to spawn vessels.
* 2016-0125: 1.9.4 (jrossignol) for KSP 1.0.5
	+ Added support for lists in persistent data store values.
	+ Added checkType to all celestial body progress requirements to allow tracking back on manned/unmanned.
	+ Added support for multiple waypoint names in WaypointGenerator (when generating multiple waypoints from one node).
	+ Added support for waypoint chaining in WaypoingGenerator.RANDOM_WAYPOINT_NEAR.
	+ Duration parameter now supports a startCriteria field for more fine-grained control of starting conditions.
	+ Fixed defaulting of min/max count in PartValidation (thanks inigma).
	+ Fixed rate of climb checking to default in a way to allow checking for negative values (thanks inigma).
	+ Fixed issue with NONE and MODULE being combined in PartValidation (thanks inigma).
	+ Fixed issue with VesselDestroyed not working for splashdown or overheat (thanks DBT85).
	+ Fixed incorrect latitude/longitude when using PQS offset in SpawnVessel (thanks inigma).
	+ Fixed a bug that prevented the requiredValue DATA node check from checking for non-empty lists.
	+ Fixed WaypointGenerator not adding waypoints when a contract causes them to become visible (thanks smjjames).
	+ Fixed issue where Flats biome would count for GreatFlats in CollectScience (thanks Spheniscine).
* 2016-0111: 1.9.3.1 (jrossignol) for KSP 1.0.5
	+ Fixed MAJOR issue introduced in 1.9.3 that broke Tourism Plus (thanks Ryusho).
	+ Fixed ReachState not working with timers (thanks SoTOP).
* 2016-0111: 1.9.3 (jrossignol) for KSP 1.0.5 PRE-RELEASE
	+ Added VesselParameterGroup.hideVesselName.
	+ General improvements to behaviour of parameters with in-sequence completion (thanks inigma).
	+ Improved reliability of RemoteTech parameters.
	+ Fixed issue with some expressions being parsed twice in the Expression behaviour (thanks linuxgurugamer).
	+ Fixed problem with Duration timer contracts not working when used as a child parameter (thanks TrooperCooper & NathanKell).
	+ Fixed issue that caused disabled stock contracts to re-enable themselves on occasion (thanks Rokker).
	+ Fixed supposedly removed Kerbals going MIA (thanks inigma).
	+ Fixed major issue with RemoveKerbal (thanks inigma).
	+ Fixed issue with Sequence parameter not always firing (thanks Steven Mading).
	+ Fixed issue where CollectScience wouldn't correctly check that it needed to be completed in sequence (thanks linuxgurugamer).
	+ Fixed failWhenUnmet to actually fail contracts (thanks inigma).
	+ Fixed issue with biomes with spaces in their names in CollectScience (like "Ice Caps").
* 2016-0103: 1.9.2.1 (jrossignol) for KSP 1.0.5
	+ Fixed problem with loading waypoints from older versions of Contract Configurator (thanks SpaceNomad).
* 2016-0103: 1.9.2 (jrossignol) for KSP 1.0.5
	+ Added minRateOfClimb and maxRateOfClimb to ReachState.
	+ Support negative latitudes in ReachState.
	+ Fixed major contract pre-loader exception on startup (thanks smjjames).
	+ Fixed error handling in expression parser (thanks severedsolo).
	+ Fixed HasCrew incorrectly only handling kerbals of type 'Crew' (thanks bertibott).
	+ Fixed exception in uniqueness checks that were done at the contract group level (thanks severedsolo).
	+ Fixed issue with SpawnPassengers always spawning passengers instead of whatever the contract specified (thanks inigma).
	+ Fixed issue with Vessel values not being properly saved in the VAB/SPH for uniqueness checks (thanks severedsolo).
	+ Fixed issue with the GROUP_ALL and CONTRACT_ALL uniqueness checks not working as advertised (thanks severedsolo).
	+ Fixed FacilityRequirement breaking down in the tracking station (thanks cordilon).
	+ Fixed a number of WaypointGenerator issues (thanks linuxgurugamer).
* 2015-1216: 1.9.1 (jrossignol) for KSP 1.0.5
	+ Draft Twitch Viewers integration - when creating new random Kerbals for contracts will get names from Draft Twitch Viewers (thanks IRNifty for assisting on this one).
	+ ITERATOR nodes for automatically duplicating PARAMETER nodes for every value in a list.
	+ AutoAccept contracts now more likely get generated immediately when available.
	+ Added Biome.PrimarySituation() method.
	+ Added CelestialBody.SCANsatCoverage() method.
	+ Allow multiple parameter identifiers in WaypointGenerator (for blocks with more than one waypoint).
	+ Support for clustered waypoints in WaypoingGenerator.
	+ ReachState supports multiple vessel situations.
	+ Fixed VisitWaypoint support for contracts with multiple WaypointGenerator behaviours (thanks linuxgurugamer).
	+ Fixed further issues requiring rouding when checking for a zero speed (thanks Aelfhe1m).
	+ Fixed issue where ContractMultiplier() wasn't calculated correctly.
	+ Fixed issue where failureFunds was not being set when the contract had an advance.
	+ Fixed issue with load passenger dialog disappearing too early (thanks inigma).
	+ Fixed parsing of CelestialBody in WaypointGenerator (thanks severedsolo).
	+ Fixed some parser issues for exceptional cases (thanks inigma).
	+ Fixed major issues with CopyCraftFile behaviour (thanks inigma).
	+ Fixed default Kerbal type back to tourist in SpawnPassengers (thanks CovertJaguar).
	+ Minor bug fixes.
* 2015-1207: 1.9.0 (jrossignol) for KSP 1.0.5
	+ Improved display of some parameters with only one redundant child parameter in contract window.
	+ New functions for generating kerbals.
	+ HasCrew and RecoverKerbal will now automatically create kerbals in the astronaut complex when required.
	+ Reworked logic for specifying unique values in DATA nodes.
	+ SpawnVessel CREW nodes now support specifying a gender.
	+ SpawnVessel supports specifying a location via PQS City now (like SpawnKerbal).
	+ Added minAcceleration and maxAcceleration to ReachState.
	+ Added RemoveKerbal behaviour.
	+ Auto-close passenger loading dialog if vessel launches or scene changes (thanks inigma).
	+ Added new Funds() and Science() expression functions to get player's funds/science.
	+ Ignore USI Sounding Rocket experiments for science sub-system.
	+ Fixed bugs with using expressions in DialogBox.
	+ Fixed name duplication in RandomKerbalName() function (thanks inigma).
	+ Fixed exception using UnlockPart without part unlocking set on the current game (thanks inigma).
	+ Fixed issue with crew that aren't properly removed on contract completion (thanks inigma).
	+ Fixed issue where experimental status of parts never goes away - even when a tech is researched (thanks inigma).
	+ Fixed issue with VesselDestroy causing vessel markers to appear when invoked at KSC (thanks inigma).
	+ Fixed issue where vessel rename doesn't trigger VesselIsType (thanks CompB).
	+ Fixed issue where HasCrew counted tourists (thanks severedsolo).
	+ Fixed problems with KSCLocation() returning the wrong value (thanks Rodger).
	+ Fixed bug when despawning kerbals from vessels that are not currently loaded (thanks inigma).
	+ Fixed so Kerbals recovered via StageRecovery no longer count as killed for contracts (thanks blu3wolf).
* 2015-1124: 1.8.3 (jrossignol) for KSP 1.0.5
	+ Fixed NullReferenceException in code introduced in 1.8.2 (thanks kunok).
* 2015-1124: 1.8.2 (jrossignol) for KSP 1.0.5
	+ Added vessel highlighting (from contextual contracts) to TargetDestroyed, Docking, Rendezvous and VesselParameterGroup.
	+ Added Vessel.VesselName() method.
	+ Added support for title in KerbalDeaths parameter.
	+ Improvements to contract generation process (prevents some issues with a contract not showing up due to prestige levels).
	+ New orbit methods for Vessel (OrbitApoapsis(), OrbitPeriapsis(), OrbitInclination(), OrbitEccentricity()).
	+ Support for showMessages attribute in VisitWaypoint.
	+ Fixed issue with FacilityRequirement always thinking the player's facilities were maxed out.
	+ Fixed exception in WaypointGenerator for BaseConstruction (thanks dakakeisalie).
	+ Fixed issue where Duration timer would reset under some very specific scenarios (thanks severedsolo).
	+ Fixed some issues with facility level checks not working correctly.
* 2015-1116: 1.8.1 (jrossignol) for KSP 1.0.5
	+ Added new Not parameter.
	+ Can now specify heading in SpawnKerbal.
	+ Fixed issue with index attribute not being recognized in HasPassengers (thanks inigmatus).
	+ Fixed issue with speed in KSP never being zero for ReachState (thanks inigmatus).
	+ Fixed exception in RecoverVessel when recovering via the VAB when another vessel is on the launchpad.
	+ Fixed issue with timers getting reset in VAB/SPH (thanks chrisl).
	+ Removed long-ago deprecated CC_SCANsat.dll (this does not remove SCANsat support).
* 2015-1109: 1.8.0 (jrossignol) for KSP 1.0.5
	+ Support for KSP 1.0.5
* 2015-1107: 1.7.8 (jrossignol) for KSP 1.0.2
	+ Fixed issue with timer parameter text not always updating (thanks mer & severedsolo).
	+ Fixed issue with timer parameter not always starting up (thanks mer).
	+ Fixed issue with contracts not being correctly disabled when requested (thanks severedsolo).
	+ Fixed minTerrainAltitude and maxTerrainAltitude to check terrain altitude and not ASL (thanks space-is-hard).
	+ Fixed issue with interaction between SpawnKerbal and RecoverKerbal causing exception that didn't clean up Kerbals (thanks arilm21).
	+ Minor bug fixes.
* 2015-1022: 1.7.7 (jrossignol) for KSP 1.0.2
	+ Fixed issues with PartTest parameter not making the "Run Test" option show up on parts to be tested (thanks Sticky32).
	+ Fixed issue with double() and other cast functions not working when casting from a non-numeric type (thanks chrisl).
	+ Fixed issue with disabled contracts not actually staying disabled (thanks DeCi & Svm420).
	+ Additional fixes to Duration reset issues (thanks chrisl).
	+ Additional error handling in string parsing for expressions.
* 2015-1010: 1.7.6 (jrossignol) for KSP 1.0.2
	+ Added Reputation() function to get the player's current reputation.
	+ Fixed issue with Duration parameter possibly resetting state incorrectly when switching scenes/vessels (thanks chrisl).
	+ Minor cleanup of science experiment definitions.
	+ Improved error handling for rare contract pre-loader load exceptions (thanks Laffe).
* 2015-0926: 1.7.5 (jrossignol) for KSP 1.0.2
	+ Added HasResourceCapacity parameter.
	+ Added Round function for Duration class.
	+ Fixed issue with hidden parameters in a sequence not unhiding in Contracts Window +.
	+ Fixed issue with Duration parameter when not used with VesselParameterGroup (thanks master18).
	+ Fixed issue with handling of $ character in strings (thanks ManuxKerb).
* 2015-0914: 1.7.4 (jrossignol) for KSP 1.0.2
	+ Improved Sigma Binary support (contracts won't get offered for barycenters unless they've been specifically written with that in mind).
	+ Changed triggers for Message behaviour to make consistent with other similar behaviours.
	+ Fixed issue with loading settings when a contract pack is removed (thanks hyper1on).
	+ Fixed duplication issue with settings app launcher icon (thanks ObsessedWithKSP).
	+ Fixed issues with hidden parameters being a little to aggressive in hiding children.
	+ Fixed completely broken Exclude and ExcludeAll methods (whoops).
	+ Fixed FacilityRequirement to actually work outside the space center.
	+ Fixed rare contract load exception from part modules without a name field.
	+ Fixed issue with conversions from Vessel to VesselIdentifier (thanks severedsolo).
	+ Fixed errors in log from loading using legacy values on ChangeVesselOwnership and other behaviours.  Now correctly outputs a warning.
* 2015-0905: 1.7.3 (jrossignol) for KSP 1.0.2
	+ Added Round() function for rounding numeric values.
	+ Contracts will now expire out of the pre-loader after a few Kerbin days.  Help prevent contracts that may no longer be valid from being generated.
	+ Fixed issue with hidden parameters not actually being hidden (thanks 5thHorseman).
	+ Fixed issue with using subject with CollectScience (thanks severedsolo).
	+ Fixed issue using Biome with uniqueValue in a DATA node (thanks severedsolo).
	+ Fixed issue where disabling a contract pack doesn't save the fact that it is disabled (thanks Poodmund).
* 2015-0829: 1.7.2 (jrossignol) for KSP 1.0.2
	+ DialogBox behaviour now supports loading/unloading textures for images on the fly.
	+ Fixed issue with dialog boxes that weren't getting positioned correctly.
	+ Fixed issue with SpawnVessel when switching from editor to flight scene (introduced in 1.7.0).
	+ Fixed parser issue with early data type conversions (thanks DMagic).
	+ Fixed issue with hidden parameters in Sequence not working in Contracts Window + (thanks 5thHorseman).
	+ Misc bug fixes.
* 2015-0827: 1.7.1 (jrossignol) for KSP 1.0.2 PRE-RELEASE
	+ Fixed a backwards compatibility issue introduced in 1.7.0 (thanks Ald).
	+ When title isn't overriden, prefix optional parameters with "(Optional)".
	+ Added a hidden attribute for all parameters.
	+ VesselParameterGroups now list out vessels that can complete the contract more clearly.
	+ Fixed output text when converting a duration to a string in contracts.
	+ Improved behaviour of Duration parameter when used under VesselParameterGroup.
* 2015-0826: 1.7.0 (jrossignol) for KSP 1.0.2 PRE-RELEASE
	+ New DialogBox behaviour for creating rich text dialog boxes with images.
	+ New CopyCraftFile behaviour to reward a player with a craft file.
	+ New DestroyVessel behaviour to destroy a vessel.
	+ New RecoverVessel parameter.
	+ Support in WaypointGenerator for underwater waypoints.
	+ Duration parameter can now be used as a child of some parameters.
	+ Duration parameter now respects the vessel filter in VesselParameterGroup.
	+ Expression behaviour can now store data for types other than double.
	+ Data can now be retrived from the persistent data store in expressions using the $ symbol.
	+ Improved casting between string and VesselIdentifier (thanks Nori).
	+ Made ChageVesselOwnership onState values consistent with other behaviours.
	+ Added Crawlerway into list of KSC biomes for contracts (thanks Rokanov).
	+ Fixed issue with grandparent contract groups not being recognized properly for expressions (thanks Rokanov).
	+ Fixed issues spawning vessels with the deferredVesselCreation flag (thanks Enceos).
	+ Fixed exception in HasCrew when referencing a Kerbal that hasn't yet been spawned (thanks severedsolo).
* 2015-0818: 1.6.6 (jrossignol) for KSP 1.0.2
	+ Fixed exception in Science sub-system (happens in latest FieldResearch release).
	+ Added additional check conditions for ReturnHome (thanks Lewtz and Jirnsum).
	+ Fixed another rare exception when removing a planet pack (thanks Hlaford).
	+ Fixed exception when recovering a vessel completes a contract (thanks AccidentalDisassembly).
* 2015-0813: 1.6.5 (jrossignol) for KSP 1.0.2
	+ Fix some parsing issues with the Duration class (thanks Nori).
	+ Re-did fix to exception in ContractVesselTracker.
	+ Fixed rare exception when removing a planet pack (thanks AlonzoTG).
	+ Added support in SpawnVessel for spawning a vessel from a single part (a bit buggy, read caveats in documentation).
	+ Improved SpawnVessel validation (thanks 5thHorseman).
	+ Fixed issues with parsing identifiers with trailing spaces (thanks 5thHorseman).
	+ Minor bug fixes.
* 2015-0807: 1.6.4 (jrossignol) for KSP 1.0.2
	+ Workaround for crash issue when parsing some ternary expressions in contracts.
	+ ContractPreLoader improvements, better handling of autoAccept contracts (thanks NathanKell).
	+ Check parameter state for some parameters on contract acceptance (fixes issues with CapCom and autoAccept contracts).
	+ Contract Configurator now automatically reloaded when doing a module manager reload (thanks sarbian).
	+ Enhancements to ExperimentalPart to allow finer control over when parts are locked/unlocked.
	+ Fixes to some string expression parsing issues (thanks Nori).
	+ Fixed exception in ContractVesselTracker (thanks glilienthal).
	+ Minor bug fixes.
* 2015-0802: 1.6.3 (jrossignol) for KSP 1.0.2
	+ New Tech methods Parents() and IsReadyToUnlock().
* 2015-0731: 1.6.2 (jrossignol) for KSP 1.0.2
	+ Fixed issue with saving contract settings (thanks rasta013).
* 2015-0731: 1.6.1 (jrossignol) for KSP 1.0.2
	+ Fixed a major bug that prevented VesselParameterGroup parameters from completing in some circumstances (thanks ola).
* 2015-0731: 1.6.0 (jrossignol) for KSP 1.0.2
	+ New settings window (only available in space center) that allows contract packs to be enabled/disabled per save.  Also supports disabling of stock contract types.
	+ Support for DATA nodes within CONTRACT_GROUP (allows defining an expression once and using it in multiple contracts).
	+ Added displayName to CONTRACT_GROUP.
	+ Added new extended mode to HasResource parameter.
	+ New AwardExperience behaviour for giving extra experience to crew.
	+ FlyingAltitudeThreshold and SpaceAltitudeThreshold methods added to CelestialBody.
	+ Tweak weighting between stock contracts and Contract Configurator contracts towards Contract Configurator.
	+ Duration portion of VesselParameterGroup parameters is now displayed as a child parameter (makes it harder to miss).
	+ Added attributes to VesselParameterGroup to allow vessel definitions to elapse on contract completion/failure.
	+ New CelestialBody methods for progression attributes (whether the player has reached, orbited, landed, escaped and returned from the body).
	+ Added Tech class to expressions.
* 2015-0727: 1.5.5 (jrossignol) for KSP 1.0.2
	+ New MissionTimer parameter for displaying a count-up timer (use it for challenges!).
	+ New functions/methods related to contract multipliers - ContractMultiplier(), CelestialBody.Multiplier() ContractPrestige.Multiplier().
	+ Made contract deadline independent of targetBody multiplier (thanks NathanKell).
	+ Correctly update Contracts Window Plus when contract state + titles changes at the same time.
	+ Improved error handling in parameter generation for unexpected scenarios - fixes New Horizons issues (thanks kp0llux & kingoftheinternet).
* 2015-0720: 1.5.4 (jrossignol) for KSP 1.0.2
	+ Added new extended PartModule mode to PartValidation parameter.
	+ Added new methods for determining engine thrust and ISP in expressions.
	+ Added additional validation to WaypointGenerator.RANDOM_WAYPOINT_NEAR (thanks Xaegr).
	+ Minor changes to VesselSpawner.
	+ Fixed issue with VesselNotDestroyed firing for EVA Kerbals boarding a vessel (thanks Cooper42).
	+ Fixed Pow() and Log() expression functions to work correctly with types other than double (thanks NathanKell).
	+ Fixed major issues with CanResearchTech requirement (thanks NathanKell).
	+ Fixed holes where expressions could modify underlying KSP lists (thanks Whyren).
	+ Experiments from unsupported science mods won't show up - preventing them from showing up before the right tech has been unlocked.
	+ Added Asteroid Day experiment to experiment list (doesn't change behaviour, just quiets a warning).
* 2015-0717: 1.5.3 (jrossignol) for KSP 1.0.2
	+ Added UnlockPart behaviour.
	+ Added CanResearchTech requirement.
	+ Added AvailablePart.IsUnlocked and AvailablePart.CrewCapacity.
	+ Added Log() function for expressions.
	+ Added new basic type-conversion functions for expressions (int(), float(), double(), etc.).
	+ Fixed issue with Vessel.Parts() (thanks Whyren).
	+ Minor bug fixes.
* 2015-0714: 1.5.2 (jrossignol) for KSP 1.0.2
	+ Allow multiple parts to be specified in the PartValidation parameter.
	+ Added CelestialBody.RemoteTechCoverage() method for expressions.
	+ Added CelestialBody.Mass() and CelestialBody.RotationalPeriod() for expressions.
	+ Added KSCLocation() function for expressions.
	+ Enhancements to Timer parameter.
	+ Fixed issue in BiomeTracker when uninstalling a previously installed planet pack (thanks herman and xEvilReeperx).
	+ Fixed possible exception in VisitWaypoint (thanks AlphaAsh).
	+ Fixed bug in PartValidation where using FILTER would prevent the parameter from completing.
	+ Fixed ReachSpecificOrbit so it outputs the orbit details in a note (thanks FinnishGameBox).
	+ Fixed VesselNotDestroyed firing for debris.
	+ Minor bug fixes.
* 2015-0706: 1.5.1 (jrossignol) for KSP 1.0.2
	+ Added new ChangeVesselOwnership contract behaviour.
	+ Added new NewVessel parameter.
	+ Added support for Tarsier Space Technology in science subsystem - ChemCam only (thanks GrafZahl).
	+ Added validation for CelestialBody name in WaypointGenerator (thanks Arctic Sesquipedalian).
	+ Additional performance fixes for CollectScience (Field Research).
	+ Fixed issue where activeUniqueValue and uniqueValue flags were not checked (thanks severedsolo).
	+ Fixed asteroid science subject from being offered unless asteroid tracking is unlocked.
	+ Fixed issue with "ghosting" vessels in SpawnVessel.
	+ Fixed parameters that weren't being hidden by the hideChildren attribute (thanks CosmoBro).
	+ Minor bug fixes.
* 2015-0624: 1.5.0 (jrossignol) for KSP 1.0.2
	+ Added support for SpawnVessel in expressions.
	+ Added support for altitudeFactor, inclinationFactor, eccentricity and deviationWindow in OrbitGenerator.
	+ Change ordering of requirement check to improve contract pre-load performance.
	+ Improved logic so child REQUIREMENT nodes can hide PARAMETER nodes even when they fail validation (thanks CosmoBro).
	+ Fixed contracts that appear and disappear in mission control due to requirement issues (thanks dunadirect).
	+ Fixed issue with WaypointGenerator incorrectly requesting forceEquatorial attribute for RANDOM_WAYPOINT_NEAR (thanks AlphaAsh).
	+ Fixed an issue with stuttering in CollectScience (thanks _Zee and Yemo).
	+ Fixed issue with list expressions not expanding correctly on first parse (thanks CosmoBro).
* 2015-0619: 1.4.2 (jrossignol) for KSP 1.0.2
	+ Fixed asteroid sample showing up in KSC contracts for Field Research (thanks maculator).
	+ Fixed mirrored heading/roll/pitch in SpawnVessel (thanks Xephan).
	+ Fixed issue with RemoteTech vessel tracking (thanks johnpmayer).
	+ Fixed OrbitGenerator NRE in tracking station (thanks HarlyKin).
	+ Fixed extra orbits in tracking station (thanks KerbMav).
* 2015-0618: 1.4.1 (jrossignol) for KSP 1.0.2
	+ Add support for heading/roll/pitch in SpawnVessel.
	+ Fixed ghost icons in OrbitGenerator (thanks KerbMav).
	+ Remove warnings for Mkerb Inc. Science Instruments (worked just fine before, now is officially supported).
	+ Re-add limited support for Win64.
* 2015-0617: 1.4.0 (jrossignol) for KSP 1.0.2
	+ Move extra science experiment definition to configuration files.
	+ Add support in science modules for Station Science.
	+ Add support in science modules for Solar Science.
	+ Add support in science modules for N3h3miah's science mods.
	+ Add additional experiment validation.
	+ Fix possible NRE in vessel expressions (thanks Mulbin).
	+ De-support buggy Win64 hacked version until Unity5.
* 2015-0616: 1.3.4 (jrossignol) for KSP 1.0.2
	+ Added support in parameters for completedMessage.
	+ Fixed NRE in ContractVesselTracker (thanks Morashtak).
	+ Fixed loading of duplicate Contract Types (thanks jakkarth).
	+ Fixed issue where random orbits aren't so random (thanks KerbMav).
	+ Fixed exception loading SpawnKerbal (thanks mega_newblar).
* 2015-0613: 1.3.3 (jrossignol) for KSP 1.0.2
	+ Fixed issue with some load errors getting thrown as an exception.
	+ Fixed exception when docking with the claw (thanks SirJodelstein).
	+ Fixed experiment filtering logic for Field Research (thanks Aelfhe1m and HarlyKin).
* 2015-0613: 1.3.2 (jrossignol) for KSP 1.0.2
	+ Major rewrite of contract generation logic to improve performance and reduce latency on contract generation while in flight.
	+ Contract pre-loader now allows pausing between attributes (reduces latency during contract generation).
	+ Added Vessel.Location() method for expressions.
	+ Fixed NRE in RecoverKerbal (thanks severedsolo).
	+ Added AcceptContract requirement.
	+ Now validates for empty values when parsing contracts.
	+ Fixed issues with ContractVesselTracker logic for spawned vessels (thanks SirJodelstein).
	+ Fixed support for grappling in ContractVesselTracker (thanks SirJodelstein).
	+ Fixed incompatibility with KRPC (thanks OvermindDL1).
	+ Fixed NRE issue with RecoverKerbal (thanks severedsolo).
	+ Fixed exception in ReachSpecificOrbit (thanks KerbMav).
	+ Fixed exception when generation contracts (thanks KerbMav).
* 2015-0611: 1.3.1 (jrossignol) for KSP 1.0.2 PRE-RELEASE
	+ Contract pre-loader now allows pausing between attributes (reduces latency during contract generation).
* 2015-0610: 1.3.0 (jrossignol) for KSP 1.0.2 PRE-RELEASE
	+ Major rewrite of contract generation logic to improve performance and reduce latency on contract generation while in flight.
	+ Added Vessel.Location() method for expressions.
	+ Fixed NRE in RecoverKerbal (thanks severedsolo).
* 2015-0609: 1.2.6 (jrossignol) for KSP 1.0.2
	+ Added AvailableExperiments() expression to better filter experiments.
	+ Added Mass, XDimension, YDimension, ZDimension, SmallestDimension and LargetDimension to Vessel expressions.
	+ Fixed BioDrill experiments to only be offered where there's an atmosphere.
	+ Fixed rare NullReferenceException in contract generation logic (thanks OakTree42).
	+ Remove exploit that allows RecoverKerbal to be completed early in Tourism and other contracts (thanks veryinky).
* 2015-0603: 1.2.5 (jrossignol) for KSP 1.0.2
	+ Fixed NullReferenceException in CompleteContractRequirement (thanks severedsolo).
	+ ImpactSeismometer and ImpactSpectrometer only available for airless bodies (thanks tomf).
	+ Asteroid sample experiments are now classified as difficult (thanks tomf).
	+ Added MainKSCBiomes() function to fix Field Research KSC contract.
* 2015-0602: 1.2.4 (jrossignol) for KSP 1.0.2
	+ Support for DMagic's Orbital Science and tomf's Impact! in science stuff (Field Research Contract Pack).
	+ Fixed exception loading ContractVesselTracker (thanks GFBones).
	+ Fixed exception in BiomeTracker when generating some Field Research contracts (thanks DaniDE).
	+ Fixed contract failure when renaming vessels in RemoteTech contracts (thanks Svannon).
* 2015-0530: 1.2.3 (jrossignol) for KSP 1.0.2
	+ Added Waypoint.Location() expression method.
	+ Added Location.Biome() expression method.
	+ Added RandomKerbalName() global expression function.
	+ Added experienceTrait to SpawnPassenger.
	+ Fixed some issues with recovering from tracking station in CollectScience.
	+ Fixed null reference issue in dead contract types (thanks DMagic).
	+ Fixed issues with biome detection for KSC biomes in CollectScience.
	+ More fixes related to contracts failing unique check in SCANsat Lite (thanks nobodyhasthis).
	+ Minor bug fixes.
* 2015-0528: 1.2.2 (jrossignol) for KSP 1.0.2
	+ New UnlockTech behaviour (thanks Klefenz).
	+ Added support for specifying science by subject in CollectScience.
	+ Added CelestialBody.SemiMajorAxis() expression method.
	+ Fixes to VesselDestroyed (thanks tito13kfm).
	+ Fixes to contracts failing unexpectedly (thanks Recon777).  Affects RemoteTech Contract Pack.
	+ Fixed issues with CollectScience location (thanks severedsolo).
	+ Fixed issue with ContractGroup max checks not working correctly for parent contract groups.
	+ Fixed CollectScience to display correct experiment name.
	+ Minor bug fixes.
* 2015-0526: 1.2.1 (jrossignol) for KSP 1.0.2
	+ CompleteContract requirement now checks on active contracts too.
	+ Improved transfer of parameters from Kerbal => Vessel => Vessel, such as PlantFlag in an Apollo-style mission (thanks jordanjay29).
	+ Fixed possible exception on contract save.
	+ Fixed exception with WaypointGenerator for contracts using random waypoint names (thanks Galenmacil).
	+ Fixed CollectScience NRE issue (thanks severedsolo).
	+ Fixed orientation/height of spawned kerbals (thanks AlphaAsh).
	+ Fixed orientation/height of vessels built in the SPH.
	+ Fixed issue with HasCrew not checking traits properly when translation mods installed (thanks dureiken).
* 2015-0525: 1.2.0 (jrossignol) for KSP 1.0.2
	+ Reduced ratio of stock vs. contract configurator contracts further to favor non-contract configurator a little more.
	+ Support in CollectScience for multiple experiments.
	+ Added activeUniqueValue flag for DATA nodes to check unique values for active/offered contracts only.
	+ Misc new functions for science expressions.
	+ Lots of fixes to science expression internals.
	+ Improved error handling for contract generation failures.
	+ Fixed uniqueValue in DATA nodes to work with Vessels.
	+ Fixed issue where ContractComplete throws errors if the related contract didn't load.
	+ Fixed issue with defaulting of targetBody on behaviours when an expression was used for the main targetBody.
	+ Fixed issue with WaypointGenerator behaviour getting inititalized twice (thanks AlphaAsh).
	+ Fixed issue with SpawnKerbal/SpawnVessel not working at all for splashed Kerbals/vessels (thanks AlphaAsh).
	+ Fixed HasAstronaut to check for changes to kerbals in more scenarios (thanks Athywren).
	+ Fixed expression parser issue that prevented contract notes from showing up correctly in Tourism Plus investory contract (thanks khearn).
	+ Minor bug fixes.
* 2015-0520: 1.1.3 (jrossignol) for KSP 1.0.2
	+ Fix additional case where uniqueValue can cause an exception (thanks MikeSalvatierra).
	+ Add RemainingScience method to Biome class.
	+ Various minor science changes.
	+ Various minor bug fixes.
* 2015-0519: 1.1.2 (jrossignol) for KSP 1.0.2
	+ Fix major issue with uniqueValue in DATA nodes - again (fixes issues in ScanSat Lite).
	+ Minor fixes to ExpressionParser.
	+ Minor fixes to CollectScience.
* 2015-0519: 1.1.1 (jrossignol) for KSP 1.0.2 PRE-RELEASE
	+ Add NoRandomContractMentality to use when creating Agents to prevent them from being assigned to random contracts (thanks amorymeltzer).
	+ Fix major issue with uniqueValue in DATA nodes (fixes issues in ScanSat Lite).
* 2015-0518: 1.1.0 (jrossignol) for KSP 1.0.2
	+ Lots of support in expression language for science stuff (big thanks to xEvilReeperx and DMagic for support and sample code)
		- Added Biome as a valid expression class.
		- Added ScienceExperiment as a valid expression class.
		- Added ScienceSubject as a valid expression class.
		- Added new method for getting all biomes of a celestial body.
		- Tracking of difficult biome/situation combinations (eg. Splashed down in the mountains).
	+ Reduce amount of Contract Configurator contracts offered so to not overwhelm stock contracts quite so much.
	+ Added HasAstronaut contract parameter.
	+ Renamed HasCrew requirement to HasAstronaut.
	+ Improvements to vessel tracking for TargetDestroyed (thanks chlue).
	+ Lots of fixes/improvements to CollectScience parameter.
	+ Orbital scanning
		- Added PerformOrbitalSurvey parameter.
		- Added PerformOrbitalSurvey requirement.
		- Added IsOrbitalSurvey() method for CelestialBody.
	+ Misc expression changes
		- Added Exclude method for List.
		- Added Latitude and Longitude methods for Waypoint.
		- Added ResourceCapacity method for Vessel.
		- DATA nodes can now use the shorthand type (eg. int) instead of the full system types (eg. Int32).
		- DATA nodes support the uniqueValue attribute to prevent duplicate values/contracts.
		- Fixes to WaypointGenerator and SpawnKerbal to improve expression support (thanks AlphaAsh).
		- Fixed a bug in the expression parser that caused issues with some ternary statements.
		- Support for quoted strings in expression parser.
		- Various expression parser bug fixes.
	+ Fixed issue with TargetDestroyed state getting reset (thanks Niarro).
	+ Fixed issue where dynamic parameter text in the stock window sometimes gets leftover characters from the previous value - most noticeable when using roman numerals (thanks Munitions).
	+ Fixed issue with vessel tracking where a tracked vessel isn't disassociated properly causing major problems in the RemoteTech contract pack (thanks TheDog, Munitions and marioluigi653).
* 2015-0508: 1.0.4 (jrossignol) for KSP 1.0.2
	+ Fixed requirements that were throwing errors when expressions used in targetBody.
	+ Fixed up some invalid warnings about not loading child CONTRACT_GROUP nodes.
* 2015-0508: 1.0.3 (jrossignol) for KSP 1.0.2
	+ Waypoints now disappear once related contract requirements are met.
	+ More warnings for unexpected values in configuration (helps authors catch bugs).
	+ Add expression functions for selecting Celestial Bodies based on player progression.
	+ TargetDestroyed checks for target being marked as debris (thanks chlue).
	+ Can now use expressions in ORBIT nodes.
	+ Verified and recompiled against RemoteTech 1.6.4
	+ Fix PartModuleUnlockedRequirement that was always returning as met (thanks severedsolo).
	+ Fix validation for targetBody on some behaviours (thanks rhoark).
	+ Fix scenario where optional parameters weren't working as expected (thanks Valiant).
	+ Fix for negative timer values being displayed for count-down parameters (thanks Enceos).
	+ Fix/workaround for "ghost" issue from exceptions when spawning some vessels (thanks odin_spain).
	+ Fix for reflection load issue in CompleteContractRequirement when bad assemblies present (thanks Szara).
	+ Minor bug fixes.
* 2015-0502: 1.0.2 (jrossignol) for KSP 1.0.2
	+ Fix for exception in SpawnPassengers (thanks Jed).
* 2015-0502: 1.0.1 (jrossignol) for KSP 1.0.2
	+ KSP 1.0.2 fixes (CollectScience was broken by the update).
	+ SpawnKerbal and SpawnPassenger now support setting the Kerbal type and gender.
	+ Add Gender() method for expressions on Kerbals.
	+ Added autoAccept attribute to CONTRACT_TYPE (behaves like the stock World-Firsts record contracts).
	+ Added new ToLower and ToUpper string methods.
	+ Fixed default value for waypoint proximity trigger for VisitWaypoint.
	+ Fixed issues with expressions in WaypointGenerator behaviour.
	+ Fixed issue with waypoint distance calculation when not on the surface.
	+ Fixed boolean expressions to not try to convert values to a boolean early.
* 2015-0429: 1.0.0 (jrossignol) for KSP 1.0.
	+ Various fixes related to KSP 1.0.
	+ Deprecated parameters removed from stock in KSP 1.0 (some may get replacements in a future version of Contract Configurator).
		- AltitudeRecord
		- LaunchVessel
		- BoardAnyVessel
	+ Added new AtLeast and AtMost set parameters.
	+ Added new None set parameter.
	+ Improve validation rules for unknown attributes/child nodes (helps modders track down issues more easily).
	+ Fix issue when reloading contracts within a hierarchy of contract groups.
	+ Fix issue when loading a save game with RemoteTech when a previously installed planet pack is uninstalled (thanks Svm420 and magico13).
	+ Pop up a warning dialog when a ScenarioModule fails to load (and prevent other ScenarioModules from also failing).
	+ Improve error messaging when failing on loading types from assemblies (thanks Vladthemad).
	+ Fix default value of index for VisitWaypoint parameter (thanks AlphaAsh).
	+ Remove obsolete parameters and attributes.
	+ Empty contract groups get highlighted yellow in debug window.
* 2015-0428: 0.8.1 (jrossignol) for KSP 1.0 PRE-RELEASE
	+ Fix display of dynamic text (was broken by KSP 1.0).
* 2015-0427: 0.8.0 (jrossignol) for KSP 1.0 PRE-RELEASE
	+ Support for KSP 1.0
	+ Deprecated parameters removed from stock (some will get replacements in a future version of Contract Configurator).
		- AltitudeRecord
		- LaunchVessel
	+ Added new AtLeast and AtMost set parameters.
	+ Added new None set parameter.
	+ Improve validation rules for unknown attributes/child nodes (helps modders track down issues more easily).
	+ Fix issue when reloading contracts within a hierarchy of contract groups.
	+ Fix issue when loading a save game with RemoteTech when a previously installed planet pack is uninstalled (thanks Svm420 and magico13).
	+ Pop up a warning dialog when a ScenarioModule fails to load (and prevent other ScenarioModules from also failing).
	+ Improve error messaging when failing on loading types from assemblies (thanks Vladthemad).
	+ Fix default value of index for VisitWaypoint parameter (thanks AlphaAsh).
	+ Various fixes related to KSP 1.0.
* 2015-0419: 0.7.15 (jrossignol) for KSP 0.90
	+ Fix for re-loading passengers in tourism contracts (thanks karki and others).
* 2015-0418: 0.7.14 (jrossignol) for KSP 0.90
	+ Expressions now work in child nodes (for WaypointGenerator and other behaviours that support it).
	+ Fix issues with fairness when generating contracts (should now give appropriate consideration to all contract packs).
	+ Fix errors in Tourism contract pack introduced by 0.7.13.
	+ Minor bug fixes.
* 2015-0416: 0.7.13 (jrossignol) for KSP 0.90
	+ Fix exception when loading types from assemblies that have been improperly compiled (thanks SpacedInvader).
* 2015-0416: 0.7.12 (jrossignol) for KSP 0.90
	+ Fix issue when loading part names with non-standard characters (thanks tattagreis).
	+ Fix issue with using custom behaviours.
	+ Can now provide multiple techs, parts and part modules in PartModuleUnlocked, PartUnlocked and TechResearched requirements.
	+ TechResearched requirement now supports selecting techs by specifying parts.
	+ WaypointGenerator now supports a hidden attribute for waypoints.
	+ Hash contract configuration details, and cancel offered contracts if the hashed values do not match.  This prevents old contracts from staying on offer when a contract pack is upgraded.
	+ Improved handling of invalid vessel identifiers.
	+ SpawnVessel now properly supports landed vessels.
	+ Support for hierarchies of contract groups.
	+ Fixes for Expression requirement.
	+ Minor bug fixes.
* 2015-0407: 0.7.11 (jrossignol) for KSP 0.90
	+ Fixed possible NRE issue when loading VesselParameterGroup (thanks Monopropellant & FreakyHydra).
	+ Fix to undocking issue where KSP physics goes nuts.
* 2015-0405: 0.7.10 (jrossignol) for KSP 0.90
	+ Fixes to vessel hashing to work with unloaded vessels.  Fixes some issues with duration timers resetting.
	+ Fix SCANsat issue where number instead of name of scan gets displayed.
	+ Expressions support 'null' as a value.
	+ PlantFlag no longer uses the stock parameter and is now a VesselParameter.  Closes silly exploits.
* 2015-0404: 0.7.9 (jrossignol) for KSP 0.90
	+ Add support for Part (AvailablePart) in expressions.
	+ Fix to passengers not being seated when the capsule crew capacity is bigger than the number of seats in the IVA (thanks SpaceNomand).
	+ More fixes to vessel tracking (fixes issues with RemoteTech contract pack).  Thanks to Invader Myk.
	+ Minor bug fixes.
* 2015-0403: 0.7.8 (jrossignol) for KSP 0.90
	+ More fixes for docking/undocking and vessel tracking (thanks metl).
	+ Fixed problem where requirement status was no longer showing up in debug menu.
	+ Minor bug fixes.
* 2015-0331: 0.7.7 (jrossignol) for KSP 0.90
	+ Hotfix for loading saves from 0.7.4 or older (thanks SpaceNomad).
* 2015-0331: 0.7.6 (jrossignol) for KSP 0.90
	+ Fix a save load issue with the Sequence parameter in 0.7.5 (thanks superm18).
* 2015-0331: 0.7.5 (jrossignol) for KSP 0.90
	+ Possible fix for duration counters resetting (thanks dorin6565 and many others).
	+ Fix for HasCrew with count > 0 (thanks Yemo).
	+ Fix for undefined vessels showing up in Tourism contracts (thanks Kaa253).
	+ Improvements to tracking across docked vessels.
	+ SpawnPassengers now only spawns passengers on Kerbin (closes EPL exploit).
	+ Sequence parameter no longer fails if child parameters complete out of order.
	+ Added hideChildren attribute to contract parameters to hide children.
	+ Added requiredValue attribute to DATA nodes.
	+ Added CelestialBody(), Kerbal() and Vessel() functions to expressions.
	+ Added resources to expressions.
	+ Debug window now highlights items with warnings in yellow.
	+ Obsolete EnterOrbit.
	+ Obsolete EnterSOI.
	+ Obsolete LandOnBody.
	+ Obsolete VesselHasVisited.
	+ Minor bug fixes.
* 2015-0327: 0.7.4 (jrossignol) for KSP 0.90
	+ Fix for unmanned vessels in HasCrew.
	+ Fix to check both vessels when undocking in HasCrew (thanks severedsolo).
	+ Fix for Kerbals spawning at 0 latitude, 0 longitude (thanks Wiseman).
	+ Support for new DATA node for storing arbitrary values for use in expressions.
	+ Improvements to SpawnPassengers, including an upper limit to the number of Kerbals it will spawn before reusing them (to keep the crew roster manageable).
	+ WaypointGenerator now supports both min and max values for RANDOM_WAYPOINT_NEAR.
	+ Add parameter attribute to WaypointGenerator to make waypoints dependent on a parameter.
	+ Improved output messages when reloading contracts through the debug menu.
	+ Debug window now contains details of contract groups.
	+ Reloading in debug window no longer causes duplicate contracts to be allowed.
	+ Add close icon to debug menu.
	+ Minor bug fixes.
* 2015-0322: 0.7.3 (jrossignol) for KSP 0.90
	+ Fix problems with VesselDestroyed (big thanks to linuxgurugamer for his patience on this one).
	+ Fix HasCrew for unmanned check.  Improved parameter text slightly.
	+ Fix exceptions when planting flag (thanks Zach9236).
	+ Removing contracts (ie. uninstalling a contract pack) no longer causes exceptions in existing save games.
* 2015-0321: 0.7.2 (jrossignol) for KSP 0.90
	+ Fix zero orbit period bug (thanks SpaceNomad).
* 2015-0321: 0.7.1 (jrossignol) for KSP 0.90
	+ Better support for spawning landed Kerbals in SpawnKerbal.
	+ SpawnKerbal now supports PQS offsets.
	+ HasCrew improvements: moved to delegate system, add support for requiring a specific Kerbal.
	+ Added support for Duration datatype in expressions.
	+ Expression support for SpawnKerbal and WaypointGenerator behaviours.
	+ Improvements to location debug window.
	+ Support for notes in most contract parameters.
	+ Weight in contract types now only applies within a contract group, and all contract groups are given equal preference.  This means that one contract group (or contract pack) can't cause contract starvation in another group.
	+ Fix NullReferenceException when using TextGen without an agent specified (thanks AppoloFunghi).
	+ Fix broken completeInSequence attribute.
	+ Minor bug fixes.
* 2015-0317: 0.7.0 (jrossignol) for KSP 0.90
	+ Support for expressions in config nodes.
		- All config node attributes can now contain expressions (see wiki for syntax details).
		- Added special expression function/methods for Vessel
		- Added special expression function/methods for CelestialBody
		- Added special expression function/methods for Kerbal (ProtoCrewMember)
		- Added special expression function/methods for Lists
		- Added special expression function/methods for Enumerations
	+ New debugging window feature - contract balancing mode.
	+ Added HasCrewCapacity parameter.
	+ Added VesseLDestroyed parameter.
	+ Added SpawnPassenger behaviour.
	+ Added version check to contract groups.
	+ Major changes to CollectScience parameter.
	+ WaypointGenerate now supports a PQS offset - allows setting waypoint using a special offset from the PQSCity location.
	+ Added minTerrainAltitude and maxTerrainAltitude to ReachState.
	+ Fixed HasAntenna to work with omnis without having activeVessel attribute set (thanks Eiktyrner).
	+ Clean up "Input is null" warning messages from stock.
	+ Lots and lots of minor bug fixes.
* 2015-0313: 0.6.90 (jrossignol) for KSP 0.90 PRE-RELEASE
	+ No changelog provided
* 2015-0309: 0.6.7 (jrossignol) for KSP 0.90
	+ Added support for completeInSequence attribute (all parameters).
	+ The state of vessel parameters may now be "transferred" via EVA Kerbals.  This allows a ship to land on the Mun, have the Kerbal EVA from the ship to a new ship, and have the new ship still complete the "land on Mun" parameter.
	+ Minor bug fixes.
* 2015-0219: 0.6.6 (jrossignol) for KSP 0.90
	+ Changed to MIT license.
	+ Performance fixes for stock contracts app (mainly affects contracts with lots and lots of parameters.
	+ Bundled MiniAVC (1.0.3).
	+ Minor bug fixes.
* 2015-0209: 0.6.5 (jrossignol) for KSP 0.90
	+ Fix rare NullReference exception on VesselParameter save (thanks cupe).
	+ Fix Sun and Mun appearing as simply "the" in some parameters (thanks Invader Myk).
* 2015-0207: 0.6.4 (jrossignol) for KSP 0.90
	+ Replace buggy stock ReachSpace parameter with a custom one (thanks Yemo and SETI users).
	+ Fix NullRef issue when using PartModule in PartValidation (thanks Yemo and SETI users).
	+ Better reporting on RemoteTech version mismatch issues.
	+ Fixed issues with dependency version check code.
* 2015-0205: 0.6.3 (jrossignol) for KSP 0.90
	+ Fixed bad exception on loading from previous broken release.
* 2015-0205: 0.6.2 (jrossignol) for KSP 0.90 PRE-RELEASE
	+ New exception handling for contract load/save prevents KSP from borking up the whole contract system.
	+ Fixed issue where VisitWaypoint title didn't show up in mission control.
	+ Fixed issue where doing a module manager reload can fail some active contracts (thanks Samapico).
	+ Minor bug fixes.
* 2015-0201: 0.6.1 (jrossignol) for KSP 0.90
	+ Fix for loading 0.5.x saves killing all contracts.
* 2015-0131: 0.6.0 (jrossignol) for KSP 0.90
	+ Added SpawnVessel behaviour.
	+ Added ExperimentalPart behaviour.
	+ Added Docking parameter.
	+ Added TargetDestroyed parameter.
	+ Added VesselNotDestroyed parameter.
	+ Added VesselIsType parameter.
	+ Added SCANsatLocationCoverage requirement.
	+ Added Message behaviour.
	+ Add situation filter to Orbit parameter.
	+ Support for VALIDATION node in PartValidation to allow more terse validation for specific part recipes on a ship.
	+ Added CONTRACT_GROUP and extra logic for limiting contracts based on group.
	+ SCANsat coverage parameter now displays the current scan percentage.
	+ Improvements to HasPassengers (loads real passengers!)
	+ Fix to how contract expiry is handled - setting to 0.0 will now give a contract that never expires, similar to the way the deadline works.
	+ New debugging window that shows the underlying configurator and allows selectively disabling parts of the contract for testing.
	+ Can now add REQUIREMENT nodes as children to PARAMETER nodes.
	+ Performance fixes for requirement checks.
	+ Remove parameters that have been obsolete since Contract Configurator 0.5.0.
* 2015-0129: 0.5.12 (jrossignol) for KSP 0.90
	+ Fixed KSPAssemblyDepdency issue indirectly caused by SCANsat (but due to broken dependency checking logic in KSP).
* 2015-0124: 0.5.11 (jrossignol) for KSP 0.90
	+ Recompile for RemoteTech 1.6.2
* 2015-0124: 0.5.10 (jrossignol) for KSP 0.90
	+ Fixed issue loading SCANsatCoverage parameter (thanks whiteout1911).
* 2015-0123: 0.5.9 (jrossignol) for KSP 0.90
	+ Changes for SCANsat 9.0 (rc5)
	+ Fix for disableOnStateChange when there is no VesselGroupParameter (thanks voidheart).
* 2015-0121: 0.5.8 (jrossignol) for KSP 0.90
	+ Recompile for RemoteTech 1.6.1
	+ Fix so that failing to load a contract is less destructive.
* 2015-0119: 0.5.7 (jrossignol) for KSP 0.90
	+ Fix display of year/years and day/days in time based parameters (thanks DBT85).
	+ Fix obsolete error messages to display contract type.
	+ Fix for NullReference error when decoupling/undocking and the root part is a decoupler (thanks DaveTSG).
* 2015-0118: 0.5.6 (jrossignol) for KSP 0.90 PRE-RELEASE
	+ Changes for SCANsat 9.0
	+ Fix display of year/years and day/days in time based parameters (thanks DBT85).
* 2015-0113: 0.5.5 (jrossignol) for KSP 0.90
	+ Fixed issue in ReachState where empty situation caused issues (thanks tattagreis).
	+ Fixed problems with KerbalSpawner.
	+ Added new attribute to KerbalSpawner to have the Kerbal added to the roster (thanks scerion).
* 2015-0113: 0.5.4 (jrossignol) for KSP 0.90
	+ Workaround for stock contracts app lag issue (#3964 on Squad bugtracker).
	+ Fixed NullReference issue in HasAntenna when loading a vessel with no antennas (thanks t0chas).
* 2015-0112: 0.5.3 (jrossignol) for KSP 0.90
	+ Extensions to PartValidation to handle more varied scenarios.
	+ Added ReachState parameter.  Deprecated ReachAltitudeEnvelope, ReachBiome, ReachDestination, ReachSituation and ReachSpeedEnvelope.
	+ Fixed to work with additional changes in RemoteTech 1.6.
	+ Minor bug fixes.
* 2015-0111: 0.5.2 (jrossignol) for KSP 0.90
	+ Fixed issue with HasAntenna using ActiveTarget (was breaking the RemoteTech contract pack).  Huge thanks to Bluemoon for pointing this one out.
* 2015-0110: 0.5.1 (jrossignol) for KSP 0.90
	+ Fixed to work with RemoteTech 1.6
	+ Hide text for fake Parameters related to OrbitGenerator in mission control on active contracts.
	+ Removed ':' from the Duration parameter default text.
* 2015-0108: 0.5.0 (jrossignol) for KSP 0.90
	+ RemoteTech integration!
		- KSCConnectivity parameter - indicates that a vessel must have connectivity back to mission control.
		- HasAntenna parameter - indicates that a vessel must have one or more antenna that meet specific criteria.
		- SignalDelay parameter - requires a min/max signal delay for a connection.
		- VesselConnectivity parameter - checks for connectivity between two vessels.
		- CelestialBodyCoverage parameter - verifies that there is communication coverage of a celestial body.
		- ActiveVesselRange requirement - requires that a celestial body has a satellite with a minimum active vessel range (achievable via either an omni antenna or dish targetting active vessel).
		- CelestialBodyCoverage requiremnt - requirement for having a dish pointed at the given celestial body.
	+ Vessel tracking!
		- New define attribute of VesselParameterGroup to associate the ship that completes the parameter to the given name.
		- New vessel attribute of VesselParameterGroup to require a specific vessel (previously defined using define) to be the one to complete the parameter.
		- IsNotVessel parameter for exclusion (eg. to have two VesselParameterGroup parameters in a contract that must be met by different vessels).
	+ Added Duration parameter.
	+ Added PartValidator parameter and deprecated HasPart and HasPartModule.
	+ Merged all orbital parameters into Orbit parameter.  Thanks ttagreis for contributions on altitude and period.
	+ Added PartModuleTypeUnlocked requirement.
	+ Changed default values for disableOnStageChange in parameters to be more logical.
	+ Added new validation to check for unexpected values in config nodes - helps when developing contract configuration.
	+ Reloading contract types will also re-run module manager (which means you can now reload contract types that use module manager).
	+ Minor bug fixes
* 2015-0105: 0.4.5 (jrossignol) for KSP 0.90
	+ Fixed NullRef issue when approaching another vessel (thanks Tellion).
* 2015-0105: 0.4.4_fixed2 (jrossignol) for KSP 0.90 PRE-RELEASE
	+ Fixed NullRef issue when approaching another vessel (thanks Tellion).
* 2015-0101: 0.4.3 (jrossignol) for KSP 0.90
	+ Fixed issue where SCANsat reported 100% scanning during flight loading, causing SCANsat parameters to complete early.
* 2014-1230: 0.4.2 (jrossignol) for KSP 0.90
	+ Improved validation when loading configuration.  More checking for invalid cases and better error messaging.
	+ Added HasPassengers parameter.
	+ Added Funds requirement.
	+ Added Science requirement.
	+ Added Repuration requirement.
	+ Allow zero min speed for ReachSpeedEnvelope; improved titles.
	+ Minor bug fixes.
* 2014-1225: 0.4.1 (jrossignol) for KSP 0.90
	+ Added OrbitalInclination parameter (thanks tattagreis).
	+ Added OrbitalEccentricity parameter (thanks tattagreis).
	+ Added OrbitalApoapsis parameter (thanks tattagreis).
	+ Added OrbitalPeriapsis parameter (thanks tattagreis).
	+ Fixed defaults for SCANsatCoverage requirement.
	+ Moved debug key from Alt-F9 to Alt-F10.
	+ Added LICENSE.txt into download file.
	+ Minor bug fixes.
* 2014-1223: 0.4.0 (jrossignol) for KSP 0.90
	+ Added WaypointGenerator behaviour.  Allows creation of waypoints.
	+ Added VisitWaypoint parameter (for use with WaypointGenerator behaviour).
	+ Added OrbitGenerator behaviour.  Allows creation of orbits.
	+ Added ReachSpecificOrbit parameter (for use with OrbitGenerator behaviour).
	+ Added HasCrew requirement.  Allows filtering on trait, experience level and count.
	+ Updated HasCrew parameter to support trait and experience level filtering.
	+ Added VesselMass parameter.
	+ Added Facility requirement - requires that a player has a facility upgraded to a specified level.
	+ Added SCANsatCoverage parameter and requirement (big thanks @tattagreis on the SCANsat integration).
	+ Added support for turning up log levels through the ContractConfigurator.cfg file (thanks tattagreis).
	+ Fixed a bug in the HasPart parameter for parts with an underscore in the name (thanks tattagreis).
	+ HasCrew now errors if minCrew > maxCrew (thanks tattagreis).
	+ Most requirements are no longer checked on active contracts.  Exposed attribute to override default behaviour through config file (thanks scerion).
	+ Added ability to reload all CONTRACT_TYPE nodes on demand (via Alt-F9).
	+ Various minor bug-fixes.
* 2014-1221: 0.3.4 (jrossignol) for KSP 0.90
	+ Fixed incompatibility with Tweakscale.
* 2014-1216: 0.3.3 (jrossignol) for KSP 0.90
	+ Persistant data store can now store config nodes.
	+ Fixed an issue with maxCompletions not working correctly (thanks @tattagreis).
* 2014-1216: 0.3.2 (jrossignol) for KSP 0.90
	+ (0.90) Support for KSP 0.90
	+ (0.90) Fixed VesselHasVisited (note the valid values for situation changed)
	+ Fixed a bug in the handling of VesselParameterGroup that would cause the countdown timer to reset when switching vessels.
* 2014-1216: 0.3.1 (jrossignol) for KSP 0.90 PRE-RELEASE
	+ Pre-release of 0.90 changes.
* 2014-1215: 0.3.0 (jrossignol) for KSP 0.25
	+ Support for ContractBehaviour - extensible behaviours at the contract level.
	+ Support for a persistent data store.
	+ Support for disabling other contract types
	+ Support for contract level notes.
	+ Support for using TextGen generated descriptions.
	+ Added Timer parameter.
	+ Added Expression requirement.
	+ Added SpawnKerbal behaviour.
	+ Added Expression behaviour.
	+ Added cooldownDuration to CompleteContract requirement.
	+ Added weight to CONTRACT_TYPE to support genering some contract types with higher/lower probability.
	+ Increase the odds of a ContractConfigurator contract being generated (versus a stock or traditionally defined contract) based on the number of configured contracts.
	+ VesselParameterGroup now works with deeply nested children (previously would only work with direct children).
	+ Various minor bug-fixes.
* 2014-1208: 0.2.0 (jrossignol) for KSP 0.25
	+ Added VesselParameterGroup parameter (supports grouping Vessel parameters, tracking duration, tracking non-active vessels, works across docking/undocking/decoupling).
	+ Created new versions of all the stock parameters dealing with Vessels to add support for tracking non-active vessels.
	+ Added HasCrew parameter.
	+ Added HasResource parameter
	+ Added HasPart parameter.
	+ Added HasPartModule parameter.
	+ Added PartModuleUnlocked requirement.
	+ Added VesselHasVisited parameter.
	+ Added ReturnHome parameter.
	+ Added Sequence and SequenceNode parameters.
	+ Various minor bug-fixes
* 2014-1130: 0.1.0 (jrossignol) for KSP 0.25
	+ Initial release.

# Contract Configurator :: Change Log

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

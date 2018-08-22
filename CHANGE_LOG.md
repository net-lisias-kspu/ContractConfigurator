# Contract Configurator :: Change Log

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

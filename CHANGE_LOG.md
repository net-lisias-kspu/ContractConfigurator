# Contract Configurator :: Change Log

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

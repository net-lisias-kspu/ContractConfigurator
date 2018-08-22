# Contract Configurator :: Changes

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

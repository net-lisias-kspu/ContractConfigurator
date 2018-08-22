# Contract Configurator (Archive)

A config file based solution for creating new contracts for Kerbal Space Program. Unofficial fork by Lisias.


## In a Hurry

* [Releases](./Archive)
	* [Latest Release](https://github.com/net-lisias-kspu/ContractConfigurator/releases)
* [Source](https://github.com/net-lisias-kspu/ContractConfigurator)
* [Change Log](./CHANGE_LOG.md)
 

## Description

Contract Configurator exposes various hooks into KSP's contract system through a standard config file syntax. This means that modders using Contract Configurator can create new contracts without writing any code. The config file format has 5 basic sections:

1. Contract Summary - This contains all the summary text, expiry/deadline dates, and reward information.
2. Parameters - These are mappings to the stock ContractParameter classes which specify what the player has to do to complete the contract.
3. Requirements - This is what is required before the contract will show up. Most of the ProgressTracking information is supported, along with a few other things.
4. Behaviours - These are behaviours that are applied at the contract level. A behaviour can create additional objects related to the contract (such as spawning Kerbals), be used to store persistent data or any number of other things.
5. Data nodes - These define new data for use within the contract using Contract Configurator's powerful expression language.
And if the provided parameters and requirements aren't enough, Contract Configurator is extensible. New parameters and requirements can be added in as little as a dozen lines of code.

The user guide is hosted on the [GitHub wiki](https://github.com/net.lisias-kspu/ContractConfigurator/wiki).


## Installation

In your KSP GameData folder, delete any existing EditorExtensions folder. Download the zip file to your KSP GameData folder and unzip.﻿


### Dependencies

* [RemoteTech](https://forum.kerbalspaceprogram.com/index.php?/topic/139167-144-remotetech-v1812-2018-07-17/) (optional)
* [Kerbal Konstructs](https://forum.kerbalspaceprogram.com/index.php?/topic/151818-145-131-122-kerbal-konstructs-1454-18082018/) (optional)


## License:

Parts released under MIT license, others under GPLv2. See [here](./LICENSE).


## UPSTREAM

* [nightingale](https://forum.kerbalspaceprogram.com/index.php?/profile/119307-nightingale/) ROOT / CURRENT MAINTAINER
	+ [Forum](https://forum.kerbalspaceprogram.com/index.php?/topic/91625-142-contract-configurator-v1250-2018-04-15/)
	+ [GitHub](https://github.com/jrossignol/ContractConfigurator)

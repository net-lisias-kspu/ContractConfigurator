## Table of Contents

* [[Table of Contents|How-To#table-of-contents]]
* [[Creating a New Contract|How-To#creating-a-new-contract]]
* [[Turning On Debug|How-To#turning-on-debug]]
* [[Testing a Contract|How-To#testing-a-contract]]
* [[Miscellaneous|How-To#miscellaneous]]
  * [[Creating an Agency|How-To#creating-an-agency]]
  * [[Using TextGen|How-To#using-textgen]]

## Creating a New Contract

To create new contracts create a new .cfg file in your mod's directory.  If you're creating a new mod, then just create a sub-directory under GameData for the .cfg file(s) to live.  If you are creating a *Contract Pack* (a mod that only contains Contract Configurator contracts), then it is suggested that you place your mod's directory as a subdirectory under GameData/ContractPacks/ instead.

The file name for the .cfg files can be anything (although it must end in .cfg).  In the file, create a CONTRACT_TYPE node, like this:

    CONTRACT_TYPE
    {
    }

And then start adding to it!  See the [[Contract Type|Contract-Type]] page for the full syntax.  Or if you want to look at some examples, check out the [test directory](https://github.com/jrossignol/ContractConfigurator/tree/master/test).  One file may contain one or more of these CONTRACT_TYPE nodes - it's up to you to decide what the best way to organize it for you is.

<sub>[ [[Top|How-To]] ] [ [[Creating a New Contract|How-To#creating-a-new-contract]] ]</sub>

## Turning On Debug

To turn on debug, copy the GameData/ContractConfigurator/ContractConfigurator.cfg.default file to ContractConfigurator.cfg.  Then edit the file and change logLevel = INFO to logLevel = DEBUG.  This will spit out some additional useful information when loading contracts, as well as adding a pop-up notification saying how many contracts loaded (and how many were attempted).

<sub>[ [[Top|How-To]] ] [ [[Turning On Debug|How-To#turning-on-debug]] ]</sub>

## Testing a Contract

When creating a new contract, the first thing too look at is the Contract Configurator debug menu (Alt-F10) from the main menu.  This will display a GUI with all the Contract Configurator contracts.  If any failed to load, they will be displayed in red.  To see the details of why it failed loading, see the output in the main debug log (Alt-F12).  If there are no errors, then continue on and test your contracts as normal.

After fixing any errors, the contracts can be reloaded by pressing the the "Reload Contracts" button in the debug menu.  For reference, the debug menu is shown below:

![](http://i.imgur.com/V8lMs9F.png)

Within this menu, the following operations can be performed:
* Reload contract types
* View contract type details
* Inspect underlying ConfigNode details
* Temporarily disable parameters/requirements/behaviours

<sub>[ [[Top|How-To]] ] [ [[Testing a Contract|How-To#testing-a-contract]] ]</sub>

## Miscellaneous

<sub>[ [[Top|How-To]] ] [ [[Miscellaneous|How-To#miscellaneous]] ]</sub>

### Creating an Agency

If you wish to create your own agency, all it takes is one config file, and a couple images.  Within the config file (this can be the same as your Contract Configurator contracts), add the following node:

    AGENT
    {
        // The name of your agency
        name = Contract Configurator Inc.
      
        // Description of your agency
        description = Add a cool description here
      
        // Logo URL should be the full path to the image file for the logo (256x160)
        logoURL = ContractConfigurator/MyLogo

        // Logo URL is the full path to the scaled down image for thumbnails (64x40)
        logoScaledURL = ContractConfigurator/MyLogo_scaled
    }

<sub>[ [[Top|How-To]] ] [ [[Miscellaneous|How-To#miscellaneous]] / [[Creating an Agency|How-To#creating-an-agency]] ]</sub>

### Using TextGen

TextGen is the Squad system for generating contract descriptions.  If you would like to use this, I highly recommend making use of the [Coherent Contracts](http://forum.kerbalspaceprogram.com/threads/100098-0-25-Coherent-Contracts-v1-01-%28Nov-14%29) mod.

To use TextGen, supply the topic, subject and motivation in your [[CONTRACT_TYPE|Contract-Type]] node.

**topic** - The specific topic of the contract.  This can be any singular noun and will be displayed prominently in the text.  Here's some examples of Coherent contract phrases that use <topic>:
* ...interest in \[Topic\] systems is off the charts...
* ...we should study \[Topic\] and \[Topic\] accessories...
* ...\[Topic\] needs rescuing... (where motivation=rescue)
* ...test the \[Topic\] in service... (where motivation=test)

**subject** - The subject of the contract.  This should be from either the list of values in Coherent Contracts (which presumably matches stock KSP), or you can use your own values if you provide strings for it (see Coherent Contracts for an example of how to do that).  Some sample phrases that get used for subject:
* \[Subject\] = \[text\]
* Kerbal = all Kerbals enjoy feeling weightless
* Experiment = and felt the need to do some tests
* Mun = there was a far side to the Mun

The full list of values that is currently in Contract Configurator for the subject is (note there are also generic strings that get used if blank):
* Duna
* DunaSrf
* Eve
* EveSrf
* Experiment
* Gilly
* GillySrf
* Ike
* IkeSurface
* Kerbal
* Kerbin
* KerbinSrf,Deserts
* Minmus
* MinmusSrf
* Moho
* MohoSrf
* Mun
* MunSrf
* Orbit
* Orbit,Space
* Parts
* Sun

**motivation** - Motivation for why we are doing the contract.  Like the subject, this needs to be from a valid list if you are not providing your own values.  Examples:
* \[Motivation\] = \[text\]
* flags = decided we needed to have a flag, to make a point about how
* test = remained unsure if
* rescue = due to an unfortunate series of events, \[Topic\] needs rescuing...

Values for motivation (note there are also generic strings that get used if blank):
* flags
* rescue
* test

<sub>[ [[Top|How-To]] ] [ [[Miscellaneous|How-To#miscellaneous]] / [[Using TextGen|How-To#using-textgen]] ]</sub>


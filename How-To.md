## Creating a new contract

To create new contracts create a new .cfg file in your mod's directory (or if you're creating a new mod, create a new sub-directory under GameData).  The file name can be anything you choose.  In the file, create a CONTRACT_TYPE node, like this:

    CONTRACT_TYPE
    {
    }

And then start adding to it!  See the [[Contract Type|Contract-Type]] page for the full syntax.  Or if you want to look at some examples, check out the [test directory](https://github.com/jrossignol/ContractConfigurator/tree/master/test).

## Testing a contract

When creating a new contract, the first thing too look at is the debug menu (Alt-F12) from the main menu.  If there were any validation errors due to incorrect configuration, this is where they will likely show up.  If there are no errors there, then continue on and test your contracts as normal.

**_COMING SOON!_**
If there are contract validation errors, there is an in-game menu to allow reloading the contract type data without restarting.  To get to this menu, hit Alt-F9 from either the main menu or space center.  Note that most changes will *NOT* affect contracts that have already been offered.

## Creating an Agency

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


## Using TextGen

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

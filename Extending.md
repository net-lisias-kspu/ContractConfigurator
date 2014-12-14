## Extending ContractConfigurator

ContractConfigurator is extensible!  So if you want to use it as part of your mod, but it doesn't quite have the right parameter or requirement for your needs, then you can write a new one!

* [[Extending Parameters|Extending#extending-parameters]]
* [[Extending Requirements|Extending#extending-requirements]]
* [[Extending Behaviours|Extending#extending-behaviours]]
* [[Using the Persistent Data Store|Extending#using-the-persistent-data-store]]

### Extending Parameters

To create a new PARAMETER type, a new class should be created that extends the ParameterFactory class. In the configuration file, the value of the 'type' node needs to match the class name (unless it ends with "Factory" - in which case the "Factory" is dropped). There are two methods that need to be implemented:

> `bool Load(ConfigNode configNode)` - This method receives the PARAMETER node to be loaded. Load any additional values that are required by your class.  If you do not require additional config node values, then you do not need to implement this method.

> `ContractParameter Generate(Contract contract)` - This method is called when it is time to generate the actual ContractParameter that the config file represents.  Each time it is called, a new ContractParameter should be created and returned.

The following example shows how the CollectScience parameter is implemented:

    /*
     * ParameterFactory wrapper for CollectScience ContractParameter.
     */
    public class CollectScienceFactory : ParameterFactory
    {
        protected BodyLocation location { get; set; }

        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            // Get location
            if (!configNode.HasValue("location"))
            {
                valid = false;
                Debug.LogError("ContractConfigurator: " + ErrorPrefix(configNode) +
                    ": missing required value 'location'.");
            }
            try
            {
                string locationStr = configNode.GetValue("location");
                location = (BodyLocation)Enum.Parse(typeof(BodyLocation), locationStr);
            }
            catch (Exception e)
            {
                valid = false;
                Debug.LogError("ContractConfigurator: " + ErrorPrefix(configNode) +
                    ": error parsing location: " + e.Message);
            }

            // Validate target body
            if (targetBody == null)
            {
                valid = false;
                Debug.LogError("ContractConfigurator: " + ErrorPrefix(configNode) +
                    ": targetBody for CollectScience must be specified.");
            }

            return valid;
        }

        public override ContractParameter Generate(Contract contract)
        {
            return new CollectScience(targetBody, location);
        }
    }


### Extending Requirements
To create a new REQUIREMENT type, a new class should be created that extends the ContractRequirement class. In the configuration file, the value of the 'type' node needs to match the class name (unless it ends with "Requirement" - in which case the "Requirement" is dropped). There are two methods that may be implemented:

> `bool Load(ConfigNode configNode)` - This method receives the REQUIREMENT node to be loaded. Load any additional values that are required by your class.  If you do not require additional config node values, then you do not need to implement this method.

> `bool RequirementMet(ContractType contractType)` - This method is called to check whether the requirement is met (either when generating a new contract, or when checking that a contract is still valid). It should return true if the requirement is met, false otherwise.

The following example shows how the AltitudeRecord requirement is implemented:

    /*
     * ContractRequirement to provide requirement for player having reached a minimum altitude.
     */
    public class AltitudeRecordRequirement : ContractRequirement
    {
        protected double minAltitude { get; set; }

        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            // Get minAltitude
            if (!configNode.HasValue("minAltitude"))
            {
                valid = false;
                Debug.LogError("ContractConfigurator: " + ErrorPrefix(configNode) +
                    ": missing required value 'minAltitude'.");
            }
            else
            {
                minAltitude = Convert.ToDouble(configNode.GetValue("minAltitude"));
                if (minAltitude <= 0.0)
                {
                    valid = false;
                    Debug.LogError("ContractConfigurator: " + ErrorPrefix(configNode) +
                        ": minAltitude must be greater than zero.");
                }
            }

            return valid;
        }

        public override bool RequirementMet(ContractType contractType)
        {
            return ProgressTracking.Instance.altitudeRecords.record > minAltitude;
        }
    }

### Extending Behaviours

**COMING SOON!**
To create a new BEHAVIOUR type, two classes are required.  One that subclasses ContractBehaviour (which provides the logic for the behaviour), and one that subclasses BehaviourFactory (which loads the data from a ConfigNode and is responsible for creating the ContractBehaviour objects when requested).  In the configuration file, the value of the 'type' node needs to match the name of the BehaviourFactory class (unless it ends with "Factory" - in which case the "Factory" is dropped).

#### BehaviourFactory

For a BehaviourFactory sub-class, there are two methods that need to be implemented:

> `bool Load(ConfigNode)` - This method receives the BEHAVIOUR node to be loaded. Load any additional values that are required by your class.  If you do not require additional config node values, then you do not need to implement this method.

> `ContractBehaviour Generate(ConfiguredContract)` - This method is called when it is time to generate the actual ContractBehaviour that the config file represents.  Each time it is called, a new ContractBehaviour should be created and returned.

The following example shows a generic template for a behaviour factory:

    public class MyNewBehaviourFactory : BehaviourFactory
    {
        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            // Load class specific data
            //     ADD YOUR LOGIC HERE

            return valid;
        }

        public override ContractBehaviour Generate(ConfiguredContract contract)
        {
            return new MyNewBehaviour();
        }
    }

#### ContractBehaviour

For a ContractBehaviour sub-class, there are a large number of methods that can be implemented:

> `void OnAccepted()` - Called when the contract the behaviour is tied to is accepted.

> `void OnCancelled()` - Called when the contract the behaviour is tied to is cancelled.

> `void OnCompleted()` - Called when the contract the behaviour is tied to is completed.

> `void OnDeadlineExpired()` - Called when the deadline expires for completing the contract tied to this behaviour.

> `void OnDeclined()` - Called when the contract the behaviour is tied to is declined.

> `void OnFailed()` - Called when the contract the behaviour is tied to fails.

> `void OnFinished()` - Called when the contract the behaviour is tied to is finished (completed or failed).

> `void OnGenerateFailed()` - Called when there is an error generating the contract.

> `void OnOffered()` - Called when the contract the behaviour is tied to is offered.

> `void OnOfferExpired()` - Called when the deadline expires for accepting the contract tied to this behaviour.

> `void OnParameterStateChange(ContractParameter)` - Called when any parameter on the contract tied to this behaviour changes state.

> `void OnRegister()` - Standard function for registering Unity callbacks.

> `void OnUnregister()` - Standard function for unregistering Unity callbacks.

> `void OnUpdate()` - Called on every frame update.

> `void OnWithdrawn()` - Called when the contract the behaviour is tied to is withdrawn.

> `void OnLoad(ConfigNode)` - Standard function for loading the behaviour from a config node.

> `void OnSave(ConfigNode)` - Standard function for saving the behaviour to a config node.

The following example shows a template that can be used for a new ContractBehaviour:

    public class MyNewBehaviour : ContractBehaviour
    {
        protected override void OnAccepted() { }
        protected override void OnCancelled() { }
        protected override void OnCompleted() { }
        protected override void OnDeadlineExpired() { }
        protected override void OnDeclined() { }
        protected override void OnFailed() { }
        protected override void OnFinished() { }
        protected override void OnGenerateFailed() { }
        protected override void OnOffered() { }
        protected override void OnOfferExpired() { }
        protected override void OnParameterStateChange(ContractParameter param) { }
        protected override void OnRegister() { }
        protected override void OnUnregister() { }
        protected override void OnUpdate() { }
        protected override void OnWithdrawn() { }
        protected override void OnLoad(ConfigNode configNode) { }
        protected override void OnSave(ConfigNode configNode) { }
    }

### Using the Persistent Data Store

**COMING SOON!**
Contract Configurator contains a persistant data store that may be used by extension modules.  This is intended for storing values that need to be tracked across different contracts.  To store data for a parameter, store it using the OnLoad/OnSave functions of the ContractParameter class.  To store data for a contract, store it using the OnLoad/OnSave functions of a ContractBehaviour class.

The persistant data store is access by calling one of the two following methods on PersistantDataStore.Instance:

> `void Store<T>(string key, T value)` - This will store the value under the given key.  Try to make the key include a prefix for your module to unsure that it unique across all possible Contract Configurator modules.

> `T Retrieve<T>(string key)` - This will retrieve a previously stored value.

## Copyright statement

_All source code posted on this page is released into the public domain._
>"Yours without obligation, let or lien. A freely given gift."

>**The Wise Man's Fear**, Patrick Rothfuss
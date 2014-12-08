## Extending ContractConfigurator

ContractConfigurator is extensible!  So if you want to use it as part of your mod, but it doesn't quite have the right parameter or requirement for your needs, then you can write a new one!

* [[Extending Parameters|Extending#extending-parameters]]
* [[Extending Requirements|Extending#extending-requirements]]

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


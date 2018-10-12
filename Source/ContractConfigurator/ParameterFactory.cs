﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using KSP;
using Contracts;
using ContractConfigurator.ExpressionParser;
using ContractConfigurator.Parameters;

namespace ContractConfigurator
{
    /// <summary>
    /// Class for generating ContractParameter objects.
    /// </summary>
    public abstract class ParameterFactory : IContractConfiguratorFactory
    {
        private static Dictionary<string, Type> factories = new Dictionary<string, Type>();

        public string name;
        protected string type;
        protected virtual ContractType contractType { get; set; }
        protected CelestialBody _targetBody = null;
        public CelestialBody targetBody
        {
            get { return _targetBody ?? contractType.targetBody; }
        }
        protected float rewardScience;
        protected float rewardReputation;
        protected float rewardFunds;
        protected float failureReputation;
        protected float failureFunds;
        protected bool optional;
        protected bool? disableOnStateChange;
        protected bool completeInSequence;
        protected bool hidden;
        protected bool hideChildren;
        protected ParameterFactory parent = null;
        protected List<ParameterFactory> childNodes = new List<ParameterFactory>();
        protected List<ContractRequirement> requirements = new List<ContractRequirement>();
        protected string title;
        protected string notes;
        protected string completedMessage;

        public bool enabled = true;
        public bool hasWarnings { get; set; }
        public Type iteratorType { get; set; }
        public string iteratorKey { get; set; }
        public virtual IEnumerable<ParameterFactory> ChildParameters { get { return childNodes; } }
        public virtual IEnumerable<ContractRequirement> ChildRequirements { get { return requirements; } }
        public string config { get; private set; }
        public string log { get; private set; }
        public DataNode dataNode { get; private set; }
        public Version minVersion
        {
            get
            {
                return contractType.minVersion;
            }
        }

        /// <summary>
        /// Loads the ParameterFactory from the given ConfigNode.  The base version performs the following:
        ///   - Loads and validates the values for
        ///     - rewardScience
        ///     - rewardReputation
        ///     - rewardFunds
        ///     - failureReputation
        ///     - failureFunds
        ///     - advanceFunds
        ///     - optional
        ///     - targetBody
        ///     - disableOnStateChange
        ///     - child PARAMETER nodes
        /// </summary>
        /// <param name="configNode">The ConfigNode to load</param>
        /// <returns>Whether the load was successful</returns>
        public virtual bool Load(ConfigNode configNode)
        {
            bool valid = true;
            ConfigNodeUtil.SetCurrentDataNode(dataNode);

            // Get name and type
            valid &= ConfigNodeUtil.ParseValue<string>(configNode, "type", x => type = x, this);
            valid &= ConfigNodeUtil.ParseValue<string>(configNode, "name", x => name = x, this, type);

            // Load the iterator nodes
            valid &= DataNode.LoadIteratorNodes(configNode, this);

            if (!configNode.HasValue("targetBody"))
            {
                configNode.AddValue("targetBody", "@/targetBody");
            }
            if (!configNode.HasValue("ignoreTargetBody"))
            {
                valid &= ConfigNodeUtil.ParseValue<CelestialBody>(configNode, "targetBody", x => _targetBody = x, this);
            }
            else
            {
                configNode.RemoveValue("ignoreTargetBody");
            }

            // Load rewards
            valid &= ConfigNodeUtil.ParseValue<float>(configNode, "rewardFunds", x => rewardFunds = x, this, 0.0f, x => Validation.GE(x, 0.0f));
            valid &= ConfigNodeUtil.ParseValue<float>(configNode, "rewardReputation", x => rewardReputation = x, this, 0.0f, x => Validation.GE(x, 0.0f));
            valid &= ConfigNodeUtil.ParseValue<float>(configNode, "rewardScience", x => rewardScience = x, this, 0.0f, x => Validation.GE(x, 0.0f));
            valid &= ConfigNodeUtil.ParseValue<float>(configNode, "failureFunds", x => failureFunds = x, this, 0.0f, x => Validation.GE(x, 0.0f));
            valid &= ConfigNodeUtil.ParseValue<float>(configNode, "failureReputation", x => failureReputation = x, this, 0.0f, x => Validation.GE(x, 0.0f));

            // Load flags
            valid &= ConfigNodeUtil.ParseValue<bool>(configNode, "optional", x => optional = x, this, false);
            valid &= ConfigNodeUtil.ParseValue<bool?>(configNode, "disableOnStateChange", x => disableOnStateChange = x, this, (bool?)null);
            valid &= ConfigNodeUtil.ParseValue<bool>(configNode, "completeInSequence", x => completeInSequence = x, this, false);
            valid &= ConfigNodeUtil.ParseValue<bool>(configNode, "hidden", x => hidden = x, this, false);
            valid &= ConfigNodeUtil.ParseValue<bool>(configNode, "hideChildren", x => hideChildren = x, this, false);

            // Get title and notes
            valid &= ConfigNodeUtil.ParseValue<string>(configNode, "title", x => title = x, this, (string)null);
            valid &= ConfigNodeUtil.ParseValue<string>(configNode, "notes", x => notes = x, this, (string)null);
            valid &= ConfigNodeUtil.ParseValue<string>(configNode, "completedMessage", x => completedMessage = x, this, (string)null);

            config = configNode.ToString();
            return valid;
        }

        /// <summary>
        /// Method for generating ContractParameter objects.  Each time it is called it should
        /// generate a new parameter for the given contract.  The parameter does not need to be
        /// added to the contract, as that gets done elsewhere (the contract is simply passed
        /// to be used in parameter generation logic).  The following members also do not need to
        /// be loaded for the ContractParameter (they get handled after this method returns):
        ///   - title
        ///   - notes
        ///   - rewardScience
        ///   - rewardReputation
        ///   - rewardFunds
        ///   - failureReputation
        ///   - failureFunds
        ///   - advanceFunds
        ///   - optional
        ///   - disableOnStateChange
        ///   - completeInSequence
        ///   - child PARAMETER nodes
        /// </summary>
        /// <param name="contract">Contract to generate for</param>
        /// <returns>The created ContractParameter</returns>
        public abstract ContractParameter Generate(Contract contract);

        /// <summary>
        /// Method for generating ContractParameter objects.  This will call the Generate() method 
        /// on the sub-class, load all common parameters and load child parameters.
        /// </summary>
        /// <param name="contract">Contract to generate for</param>
        /// <param name="contractParamHost">Parent object for the ContractParameter</param>
        /// <returns>Generated ContractParameter</returns>
        public virtual ContractParameter Generate(ConfiguredContract contract, IContractParameterHost contractParamHost)
        {
            // First check any requirements
            if (!ContractRequirement.RequirementsMet(contract, contract.contractType, requirements))
            {
                LoggingUtil.LogVerbose(typeof(ParameterFactory), "Returning null for " + contract.contractType.name + "." + name + ": requirements not met.");
                return null;
            }

            // Generate a parameter using the sub-class logic
            ContractParameter parameter = Generate(contract);
            if (parameter == null)
            {
                LoggingUtil.LogWarning(this, GetType().FullName + ".Generate() returned a null ContractParameter!");
                return null;
            }

            // Add ContractParameter to the host
            contractParamHost.AddParameter(parameter);

            // Set the funds/science/reputation parameters
            parameter.SetFunds(rewardFunds, failureFunds, targetBody);
            parameter.SetReputation(rewardReputation, failureReputation, targetBody);
            parameter.SetScience(rewardScience, targetBody);

            // Set other flags
            parameter.Optional = optional;
            if (disableOnStateChange != null)
            {
                parameter.DisableOnStateChange = (bool)disableOnStateChange;
            }
            parameter.ID = name;

            // Special stuff for contract configurator parameters
            ContractConfiguratorParameter ccParam = parameter as ContractConfiguratorParameter;
            if (ccParam != null)
            {
                ccParam.completeInSequence = completeInSequence;
                ccParam.notes = notes;
                ccParam.completedMessage = completedMessage;
                ccParam.hidden = hidden;
                ccParam.hideChildren = hideChildren;
            }

            return parameter;
        }

        /// <summary>
        /// Generates all the ContractParameter objects required for the array of ConfigNodes, and 
        /// adds them to the host object.
        /// </summary>
        /// <param name="contract">Contract to generate for</param>
        /// <param name="contractParamHost">The object to use as a parent for ContractParameters</param>
        /// <param name="paramFactories">The ParameterFactory objects to use to generate parameters.</param>
        /// <returns>Whether the generation was successful.</returns>
        public static bool GenerateParameters(ConfiguredContract contract, IContractParameterHost contractParamHost, List<ParameterFactory> paramFactories)
        {
            for (int i = paramFactories.Count - 1; i >= 0; i--)
            {
                ParameterFactory paramFactory = paramFactories[i];
                if (paramFactory.enabled)
                {
                    // Set up the iterator
                    int count = 1;
                    int current = 0;
                    if (paramFactory.iteratorType != null)
                    {
                        count = (int)paramFactory.dataNode["iteratorCount"];
                    }

                    // Loop through the iterator, or do a single parameter for non-iterated parameters
                    while (current++ < count)
                    {
                        // Refresh the deterministic values
                        int oldValue = DataNode.IteratorCurrentIndex;
                        if (paramFactory.iteratorType != null)
                        {
                            DataNode.IteratorCurrentIndex = current - 1;
                            ConfigNodeUtil.UpdateNonDeterministicValues(paramFactory.dataNode, paramFactory.dataNode);
                        }

                        ContractParameter parameter = paramFactory.Generate(contract, contractParamHost);
                        if (!(parameter == null || GenerateParameters(contract, parameter, paramFactory.childNodes)))
                        {
                            return false;
                        }

                        ContractConfiguratorParameter ccParam = parameter as ContractConfiguratorParameter;
                        if (ccParam != null && ccParam.hideChildren)
                        {
                            foreach (ContractParameter child in ccParam.GetChildren())
                            {
                                ContractConfiguratorParameter ccChild = child as ContractConfiguratorParameter;
                                if (ccChild != null)
                                {
                                    ccChild.Hide();
                                }
                            }
                        }

                        // Restore the old value for the iterator list (for recursive iterations)
                        DataNode.IteratorCurrentIndex = oldValue;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Adds a new ParameterFactory to handle PARAMETER nodes with the given type.
        /// </summary>
        /// <param name="factoryType">Type of factory to register.</param>
        /// <param name="typeName">The name of the factory.</param>
        public static void Register(Type factoryType, string typeName)
        {
            LoggingUtil.LogDebug(typeof(ParameterFactory), "Registering parameter factory class " +
                factoryType.FullName + " for handling PARAMETER nodes with type = " + typeName + ".");

            // Make sure we can instantiate it (this will also run any static initializers)
            Activator.CreateInstance(factoryType);

            // Check for duplicates
            Type existingType = null;
            if (factories.TryGetValue(typeName, out existingType))
            {
                // Give priority to non-Contract Configurator types
                if (existingType.Assembly == typeof(ParameterFactory).Assembly)
                {
                    factories[typeName] = factoryType;
                }
                // If neither are the Contract Configurator type, throw an error
                else if (factoryType.Assembly != typeof(ParameterFactory).Assembly)
                {
                    LoggingUtil.LogError(typeof(ParameterFactory), "Cannot register " + factoryType.FullName + "[" + factoryType.Module +
                        "] to handle type " + typeName + ": already handled by " +
                        existingType.FullName + "[" +
                        existingType.Module + "]");
                }
            }
            else
            {
                // Add it to our list
                factories.Add(typeName, factoryType);
            }
        }


        /// <summary>
        /// Generates a new ParameterFactory from the given ConfigNode.
        /// </summary>
        /// <param name="parameterConfig">ConfigNode to use in the generation.</param>
        /// <param name="contractType">ContractType that this parameter factory falls under</param>
        /// <param name="paramFactory">The ParameterFactory object.</param>
        /// <param name="parent">ParameterFactory to use as the parent</param>
        /// <returns>Whether the load was successful</returns>
        public static bool GenerateParameterFactory(ConfigNode parameterConfig, ContractType contractType, out ParameterFactory paramFactory, ParameterFactory parent = null)
        {
            // Logging on
            LoggingUtil.CaptureLog = true;
            bool valid = true;

            // Get the type
            string type = parameterConfig.GetValue("type");
            string name = parameterConfig.HasValue("name") ? parameterConfig.GetValue("name") : type;
            if (string.IsNullOrEmpty(type))
            {
                LoggingUtil.LogError(typeof(ParameterFactory), "CONTRACT_TYPE '" + contractType.name + "'," +
                    "PARAMETER '" + parameterConfig.GetValue("name") + "' does not specify the mandatory 'type' attribute.");
                paramFactory = new InvalidParameterFactory();
                valid = false;
            }
            else if (!factories.ContainsKey(type))
            {
                LoggingUtil.LogError(typeof(ParameterFactory), "CONTRACT_TYPE '" + contractType.name + "'," +
                    "PARAMETER '" + parameterConfig.GetValue("name") + "' of type '" + parameterConfig.GetValue("type") + "': " +
                    "Unknown parameter '" + type + "'.");
                paramFactory = new InvalidParameterFactory();
                valid = false;
            }
            else
            {
                // Create an instance of the factory
                paramFactory = (ParameterFactory)Activator.CreateInstance(factories[type]);
            }

            // Set attributes
            paramFactory.parent = parent;
            paramFactory.contractType = contractType;
            paramFactory.dataNode = new DataNode(name, parent != null ? parent.dataNode : contractType.dataNode, paramFactory);

            // Load child requirements
            for (int i = ConfigNodeUtil.GetChildNodes(parameterConfig, "REQUIREMENT").Length - 1; i >= 0; i--)
            {
                ConfigNode childNode = ConfigNodeUtil.GetChildNodes(parameterConfig, "REQUIREMENT")[i];
                ContractRequirement req = null;
                valid &= ContractRequirement.GenerateRequirement(childNode, contractType, out req, paramFactory);
                if (req != null)
                {
                    paramFactory.requirements.Add(req);
                    if (req.hasWarnings)
                    {
                        paramFactory.hasWarnings = true;
                    }
                }
            }

            // Load config
            if (!paramFactory.Load(parameterConfig))
            {
                // If there was a load failure, check if there are requirements
                if (paramFactory.requirements.Count > 0)
                {
                    LoggingUtil.LogWarning(paramFactory, "Ignoring failed parameter with child requirements.");
                }
                else
                {
                    valid = false;
                }
            }

            // Late initialize for iterator keys
            valid &= DataNode.InitializeIteratorKey(parameterConfig, paramFactory);

            // Check for unexpected values - always do this last
            if (paramFactory.GetType() != typeof(InvalidParameterFactory))
            {
                valid &= ConfigNodeUtil.ValidateUnexpectedValues(parameterConfig, paramFactory);
            }

            paramFactory.log = LoggingUtil.capturedLog;
            LoggingUtil.CaptureLog = false;

            // Load child nodes
            for (int i = ConfigNodeUtil.GetChildNodes(parameterConfig, "PARAMETER").Length - 1; i >= 0; i--)
            {
                ConfigNode childNode = ConfigNodeUtil.GetChildNodes(parameterConfig, "PARAMETER")[i];
                ParameterFactory child = null;
                valid &= ParameterFactory.GenerateParameterFactory(childNode, contractType, out child, paramFactory);
                if (child != null)
                {
                    paramFactory.childNodes.Add(child);
                    if (child.hasWarnings)
                    {
                        paramFactory.hasWarnings = true;
                    }
                }
            }

            paramFactory.enabled = valid;

            return valid;
        }

        /// <summary>
        /// Standard prefix used in error messages.
        /// </summary>
        /// <returns>Prefix for error messages.</returns>
        public string ErrorPrefix()
        {
            return (contractType != null ? "CONTRACT_TYPE '" + contractType.name + "', " : "") + 
                "PARAMETER '" + name + "' of type '" + type + "'";
        }

        /// <summary>
        /// Standard prefix used in error messages.
        /// </summary>
        /// <param name="configNode">The ConfigNode to draw details from.</param>
        /// <returns>Prefix for error messages.</returns>
        public string ErrorPrefix(ConfigNode configNode)
        {
            return (contractType != null ? "CONTRACT_TYPE '" + contractType.name + "', " : "") + 
                "PARAMETER '" + configNode.GetValue("name") + "' of type '" + configNode.GetValue("type") + "'";
        }

        /// <summary>
        /// Validates whether the targetBody value has been loaded. 
        /// </summary>
        /// <param name="configNode">The ConfigNode to validate against</param>
        /// <returns>True if the targetBody has been loaded, logs an error and returns false otherwise.</returns>
        protected virtual bool ValidateTargetBody(ConfigNode configNode)
        {
            if (targetBody == null && dataNode.IsDeterministic("targetBody") && dataNode.IsInitialized("targetBody"))
            {
                LoggingUtil.LogError(this, ErrorPrefix(configNode) + ": targetBody for " + GetType() + " must be specified.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates whether the targetBody value has been loaded. 
        /// </summary>
        /// <returns>True if the targetBody has been loaded, false otherwise.</returns>
        protected virtual bool ValidateTargetBody()
        {
            return targetBody != null;
        }

        /// <summary>
        /// Gets the identifier for the parameter.
        /// </summary>
        /// <returns>String for the parameter.</returns>
        public override string ToString()
        {
            return "PARAMETER [" + type + "]" + (name != type ? ", (" + name + ")" : "");
        }
    }
}

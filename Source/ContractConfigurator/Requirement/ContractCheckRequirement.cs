﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSPAchievements;
using Contracts;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement to provide a check against contracts.
    /// </summary>
    public abstract class ContractCheckRequirement : ContractRequirement
    {
        protected string ccType;
        protected Type contractClass;
        protected uint minCount;
        protected uint maxCount;

        public override bool LoadFromConfig(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.LoadFromConfig(configNode);

            checkOnActiveContract = true;

            // Get type
            string contractType = null;
            valid &= ConfigNodeUtil.ParseValue<string>(configNode, "contractType", x => contractType = x, this);
            if (valid)
            {
                valid &= SetValues(contractType);
            }

            valid &= ConfigNodeUtil.ParseValue<uint>(configNode, "minCount", x => minCount = x, this, 1);
            valid &= ConfigNodeUtil.ParseValue<uint>(configNode, "maxCount", x => maxCount = x, this, UInt32.MaxValue);

            return valid;
        }

        private bool SetValues(string contractType)
        {
            bool valid = true;
            if (ContractType.AllContractTypes.Any(ct => contractType.StartsWith(ct.name)))
            {
                ccType = contractType;
            }
            else
            {
                ccType = null;

                IEnumerable<Type> classes = ContractConfigurator.GetAllTypes<Contract>().Where(t => t.Name == contractType);
                if (!classes.Any())
                {
                    valid = false;
                    LoggingUtil.LogError(this, "contractType '" + contractType +
                        "' must either be a Contract sub-class or ContractConfigurator contract type");
                }
                else
                {
                    contractClass = classes.First();
                }
            }
            return valid;
        }

        public override void OnSave(ConfigNode configNode)
        {
            configNode.AddValue("minCount", minCount);
            configNode.AddValue("maxCount", maxCount);
            if (ccType != null)
            {
                configNode.AddValue("contractType", ccType);
            }
            else if (contractClass != null)
            {
                configNode.AddValue("contractType", contractClass.Name);
            }
        }

        public override void OnLoad(ConfigNode configNode)
        {
            minCount = ConfigNodeUtil.ParseValue<uint>(configNode, "minCount");
            maxCount = ConfigNodeUtil.ParseValue<uint>(configNode, "maxCount");

            string contractType = ConfigNodeUtil.ParseValue<string>(configNode, "contractType");
            SetValues(contractType);
        }

        protected string ContractTitle()
        {
            string contractTitle;
            if (ccType != null)
            {
                ContractType contractType = ContractType.AllValidContractTypes.FirstOrDefault(ct => ct.name == ccType);
                if (contractType != null)
                {
                    contractTitle = contractType.genericTitle;
                }
                else
                {
                    contractTitle = ccType;
                }
            }
            else
            {
                // TODO - normalize name
                contractTitle = contractClass.Name;
            }

            return contractTitle;
        }
    }
}

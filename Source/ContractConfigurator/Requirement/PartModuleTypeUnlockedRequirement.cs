using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using FinePrint;
using FinePrint.Utilities;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement to provide requirement for a player unlocking a "type" of module.
    /// </summary>
    public class PartModuleTypeUnlockedRequirement : ContractRequirement
    {
        protected List<string> partModuleTypes;

        public override bool LoadFromConfig(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.LoadFromConfig(configNode);

            // Do not check on active contracts.
            checkOnActiveContract = configNode.HasValue("checkOnActiveContract") && checkOnActiveContract;

            valid &= ConfigNodeUtil.ParseValue<List<string>>(configNode, "partModuleType", x => partModuleTypes = x, this, x => x.All(Validation.ValidatePartModuleType));

            return valid;
        }

        public override void OnSave(ConfigNode configNode)
        {
            for (int i = partModuleTypes.Count - 1; i >= 0; i--)
            {
                string pmt = partModuleTypes[i];
                configNode.AddValue("partModuleType", pmt);
            }
        }

        public override void OnLoad(ConfigNode configNode)
        {
            partModuleTypes = ConfigNodeUtil.ParseValue<List<string>>(configNode, "partModuleType", new List<string>());
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            for (int i = partModuleTypes.Count - 1; i >= 0; i--)
            {
                string partModuleType = partModuleTypes[i];
                for (int j = PartLoader.LoadedPartsList.Count - 1; j >= 0; j--)
                {
                    AvailablePart part = PartLoader.LoadedPartsList[j];
                    if (part.partPrefab == null || part.partPrefab.Modules == null)
                    {
                        continue;
                    }

                    if (part.partPrefab.HasValidContractObjective(partModuleType) && ResearchAndDevelopment.PartTechAvailable(part) && ResearchAndDevelopment.PartModelPurchased(part))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected override string RequirementText()
        {
            string partStr = "";
            for (int i = 0; i < partModuleTypes.Count; i++)
            {
                if (i != 0)
                {
                    if (i == partModuleTypes.Count - 1)
                    {
                        partStr += " or ";
                    }
                    else
                    {
                        partStr += ", ";
                    }
                }

                partStr += partModuleTypes[i];
            }

            return "Must " + (invertRequirement ? "not " : "") + "have a part unlocked of type " + partStr;
        }
    }
}

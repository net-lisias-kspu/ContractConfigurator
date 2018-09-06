using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using ContractConfigurator.Parameters;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement to provide requirement for player having unlocked a part with a particular module.
    /// </summary>
    public class PartModuleUnlockedRequirement : ContractRequirement
    {
        protected List<string> partModules;

        public override bool LoadFromConfig(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.LoadFromConfig(configNode);

            // Do not check on active contracts.
            checkOnActiveContract = configNode.HasValue("checkOnActiveContract") && checkOnActiveContract;

            valid &= ConfigNodeUtil.ParseValue<List<string>>(configNode, "partModule", x => partModules = x, this, x => x.All(Validation.ValidatePartModule));

            return valid;
        }

        public override void OnSave(ConfigNode configNode)
        {
            for (int i = partModules.Count - 1; i >= 0; i--)
            {
                string pm = partModules[i];
                configNode.AddValue("partModule", pm);
            }
        }

        public override void OnLoad(ConfigNode configNode)
        {
            partModules = ConfigNodeUtil.ParseValue<List<string>>(configNode, "partModule", new List<string>());
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            for (int i = partModules.Count - 1; i >= 0; i--)
            {
                string partModule = partModules[i];

                // Search for a part that has our module
                bool found = false;
                for (int j = PartLoader.Instance.loadedParts.Count - 1; j >= 0; j--)
                {
                    AvailablePart p = PartLoader.Instance.loadedParts[j];
                    if (p != null && p.partPrefab != null && p.partPrefab.Modules != null)
                    {
                        for (int k = p.partPrefab.Modules.Count - 1; k >= 0; k--)
                        {
                            PartModule pm = p.partPrefab.Modules[k];
                            if (pm != null && pm.moduleName != null && pm.moduleName == partModule)
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if (found)
                    {
                        if (ResearchAndDevelopment.PartModelPurchased(p))
                            break;
                        found = false;
                    }
                }

                if (!found)
                {
                    return false;
                }
            }

            return true;
        }

        protected override string RequirementText()
        {
            string partStr = "";
            for (int i = 0; i < partModules.Count; i++)
            {
                if (i != 0)
                {
                    partStr += i == partModules.Count - 1 ? " or " : ", ";
                }

                partStr += PartValidation.ModuleName(partModules[i]);
            }

            return "Must " + (invertRequirement ? "not " : "") + "have a part unlocked with " + partStr;
        }
    }
}

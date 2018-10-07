﻿using System;
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
            checkOnActiveContract = configNode.HasValue("checkOnActiveContract") ? checkOnActiveContract : false;

            valid &= ConfigNodeUtil.ParseValue<List<string>>(configNode, "partModule", x => partModules = x, this, x => x.All(Validation.ValidatePartModule));

            return valid;
        }

        public override void OnSave(ConfigNode configNode)
        {
            foreach (string pm in partModules)
            {
                configNode.AddValue("partModule", pm);
            }
        }

        public override void OnLoad(ConfigNode configNode)
        {
            partModules = ConfigNodeUtil.ParseValue<List<string>>(configNode, "partModule", new List<string>());
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            foreach (string partModule in partModules)
            {

                // Search for a part that has our module
                bool found = false;
                foreach (AvailablePart p in PartLoader.Instance.loadedParts)
                {
                    if (p != null && p.partPrefab != null && p.partPrefab.Modules != null)
                    {
                        foreach (PartModule pm in p.partPrefab.Modules)
                        {
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
                        {
                            break;
                        }
                        else
                        {
                            found = false;
                        }
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
                    if (i == partModules.Count - 1)
                    {
                        partStr += " or ";
                    }
                    else
                    {
                        partStr += ", ";
                    }
                }

                partStr += PartValidation.ModuleName(partModules[i]);
            }

            return "Must " + (invertRequirement ? "not " : "") + "have a part unlocked with " + partStr;
        }
    }
}

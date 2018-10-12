﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSPAchievements;
using ContractConfigurator.Util;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement set requirement.  Requirement is met if any child requirement is met.
    /// </summary>
    public class AnyRequirement : ContractRequirement
    {
        public override bool RequirementMet(ConfiguredContract contract)
        {
            bool requirementMet = false;
            for (int i = childNodes.Count - 1; i >= 0; i--)
            {
                ContractRequirement requirement = childNodes[i];
                if (requirement.enabled)
                {
                    requirementMet |= requirement.CheckRequirement(contract);
                }
            }

            return requirementMet;
        }

        public override void OnLoad(ConfigNode configNode) { }
        public override void OnSave(ConfigNode configNode) { }

        protected override string RequirementText()
        {
            return "Must meet <color=#" + MissionControlUI.RequirementHighlightColor + ">any</color> of the following";
        }
    }
}

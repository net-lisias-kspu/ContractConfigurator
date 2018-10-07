﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSPAchievements;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement to provide requirement for player having made their first launch.
    /// </summary>
    public class KSCLandingRequirement : ContractRequirement
    {
        public override bool RequirementMet(ConfiguredContract contract)
        {
            return ProgressTracking.Instance.KSCLanding.IsComplete;
        }

        public override void OnLoad(ConfigNode configNode) { }
        public override void OnSave(ConfigNode configNode) { }

        protected override string RequirementText()
        {
            string output = "Must " + (invertRequirement ? "not " : "") + "have landed at KSC";
            return output;
        }
    }
}

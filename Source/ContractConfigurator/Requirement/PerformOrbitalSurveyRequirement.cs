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
    /// ContractRequirement for performing an orbital survey of a celestial body.
    /// </summary>
    public class PerformOrbitalSurveyRequirement : ContractRequirement
    {
        public override bool LoadFromConfig(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.LoadFromConfig(configNode);

            valid &= ValidateTargetBody(configNode);

            return valid;
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            // Perform another validation of the target body to catch late validation issues due to expressions
            if (!ValidateTargetBody())
            {
                return false;
            }

            return ResourceScenario.Instance == null
                ? false
                : ResourceScenario.Instance.gameSettings.GetPlanetScanInfo().Any(psd => psd.PlanetId == targetBody.flightGlobalsIndex);
        }

        public override void OnLoad(ConfigNode configNode) { }
        public override void OnSave(ConfigNode configNode) { }

        protected override string RequirementText()
        {
            string output = "Must " + (invertRequirement ? "not " : "") + "have performed an orbital survey of " + (targetBody == null ? "the target body" : targetBody.CleanDisplayName(true));
            return output;
        }
    }
}

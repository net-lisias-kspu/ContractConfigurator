﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement for SCANsat coverage.
    /// </summary>
    public class SCANsatCoverageRequirement : ContractRequirement
    {
        protected string scanType;
        protected double minCoverage;
        protected double maxCoverage;

        public override bool LoadFromConfig(ConfigNode configNode)
        {
            // Before loading, verify the SCANsat version
            if (!SCANsatUtil.VerifySCANsatVersion())
            {
                return false;
            }

            // Load base class
            bool valid = base.LoadFromConfig(configNode);

            // Do not check the requirement on active contracts.  Otherwise when they scan the
            // contract is invalidated, which is usually not what's meant.
            checkOnActiveContract = false;

            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "minCoverage", x => minCoverage = x, this, 0.0);
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "maxCoverage", x => maxCoverage = x, this, 100.0);
            valid &= ConfigNodeUtil.ParseValue<string>(configNode, "scanType", x => scanType = x, this, SCANsatUtil.ValidateSCANname);
            valid &= ValidateTargetBody(configNode);

            return valid;
        }

        public override void OnSave(ConfigNode configNode)
        {
            configNode.AddValue("minCoverage", minCoverage);
            configNode.AddValue("maxCoverage", maxCoverage);
            configNode.AddValue("scanType", scanType);
        }

        public override void OnLoad(ConfigNode configNode)
        {
            minCoverage = ConfigNodeUtil.ParseValue<double>(configNode, "minCoverage");
            maxCoverage = ConfigNodeUtil.ParseValue<double>(configNode, "maxCoverage");
            scanType = ConfigNodeUtil.ParseValue<string>(configNode, "scanType");
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            // Perform another validation of the target body to catch late validation issues due to expressions
            if (!ValidateTargetBody())
            {
                return false;
            }

            double coverageInPercentage = SCANsatUtil.GetCoverage(SCANsatUtil.GetSCANtype(scanType), targetBody);
            return coverageInPercentage >= minCoverage && coverageInPercentage <= maxCoverage;
        }

        protected override string RequirementText()
        {
            string scanName;
            if (scanType == "AltimetryLoRes")
            {
                scanName = "low resolution altimetry";
            }
            else if (scanType == "AltimetryHiRes")
            {
                scanName = "high resolution altimetry";
            }
            else
            {
                scanName = scanType.ToLower();
            }

            return "Must " + (invertRequirement ? "not " : "") + "have between " + minCoverage.ToString("N0") + "% and " + maxCoverage.ToString("N0") + "% " + scanName + " coverage of " + (targetBody == null ? "the target body" : targetBody.CleanDisplayName(true));
        }
    }
}

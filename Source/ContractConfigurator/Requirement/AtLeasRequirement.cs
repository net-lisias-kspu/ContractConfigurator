﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using ContractConfigurator.ExpressionParser;
using ContractConfigurator.Util;

namespace ContractConfigurator
{
    /// <summary>
    /// Set requirement to check if at least a given number of child requirements are met.
    /// </summary>
    public class AtLeastRequirement : ContractRequirement
    {
        protected int count;

        public override bool LoadFromConfig(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.LoadFromConfig(configNode);

            valid &= ConfigNodeUtil.ParseValue<int>(configNode, "count", x => count = x, this, x => Validation.GE<int>(x, 0));

            return valid;
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            int metCount = 0;
            for (int i = childNodes.Count - 1; i >= 0; i--)
            {
                ContractRequirement requirement = childNodes[i];
                if (requirement.enabled)
                {
                    if (requirement.CheckRequirement(contract))
                    {
                        metCount++;
                    }

                }
            }

            return metCount >= count;
        }

        public override void OnLoad(ConfigNode configNode)
        {
            count = ConfigNodeUtil.ParseValue<int>(configNode, "count");
        }

        public override void OnSave(ConfigNode configNode)
        {
            configNode.AddValue("count", count);
        }

        protected override string RequirementText()
        {
            string output = "Must meet at least <color=#" + MissionControlUI.RequirementHighlightColor + ">" + NumericValueExpressionParser<int>.PrintNumber(count) + "</color> of the following:";
            return output;
        }
    }
}

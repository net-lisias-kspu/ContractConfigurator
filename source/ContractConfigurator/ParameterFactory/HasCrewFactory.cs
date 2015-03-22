﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using Contracts;
using Contracts.Parameters;
using ContractConfigurator.Parameters;

namespace ContractConfigurator
{
    /// <summary>
    /// ParameterFactory wrapper for HasCrew ContractParameter.
    /// </summary>
    public class HasCrewFactory : ParameterFactory
    {
        protected string trait;
        protected int minExperience;
        protected int maxExperience;
        protected int minCrew;
        protected int maxCrew;

        protected List<ProtoCrewMember> kerbal;

        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            valid &= ConfigNodeUtil.ParseValue<string>(configNode, "trait", x => trait = x, this, (string)null);
            valid &= ConfigNodeUtil.ParseValue<int>(configNode, "minExperience", x => minExperience = x, this, 0, x => Validation.Between(x, 0, 5));
            valid &= ConfigNodeUtil.ParseValue<int>(configNode, "maxExperience", x => maxExperience = x, this, 5, x => Validation.Between(x, 0, 5));
            valid &= ConfigNodeUtil.ParseValue<int>(configNode, "minCrew", x => minCrew = x, this, 1, x => Validation.GE(x, 0));
            valid &= ConfigNodeUtil.ParseValue<int>(configNode, "maxCrew", x => maxCrew = x, this, int.MaxValue, x => Validation.GE(x, minCrew));

            valid &= ConfigNodeUtil.ParseValue<List<ProtoCrewMember>>(configNode, "kerbal", x => kerbal = x, this, new List<ProtoCrewMember>());

            valid &= ConfigNodeUtil.AtLeastOne(configNode, new string[] { "trait", "minExperience", "maxExperience", "minCrew", "maxCrew", "kerbal" }, this);
            valid &= ConfigNodeUtil.MutuallyExclusive(configNode, new string[] { "trait", "minExperience", "maxExperience", "minCrew", "maxCrew" },
                new string[] { "kerbal" }, this);

            return valid;
        }

        public override ContractParameter Generate(Contract contract)
        {
            // Do this late because of potential for deferred loads
            if (kerbal.Count > 0)
            {
                minCrew = 0;
            }

            return new HasCrew(title, kerbal, trait, minCrew, maxCrew, minExperience, maxExperience);
        }
    }
}
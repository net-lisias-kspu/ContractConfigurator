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
    /// ParameterFactory wrapper for Orbit ContractParameter.
    /// </summary>
    public class OrbitFactory : ParameterFactory
    {
        protected Vessel.Situations situation;
        protected double minAltitude;
        protected double maxAltitude;
        protected double minApoapsis;
        protected double maxApoapsis;
        protected double minPeriapsis;
        protected double maxPeriapsis;
        protected double minEccentricity;
        protected double maxEccentricity;
        protected double minInclination;
        protected double maxInclination;
        protected double minArgumentOfPeriapsis;
        protected double maxArgumentOfPeriapsis;
        protected Duration minPeriod;
        protected Duration maxPeriod;

        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            valid &= ConfigNodeUtil.ParseValue<Vessel.Situations>(configNode, "situation", x => situation = x, this, Vessel.Situations.ORBITING, ValidateSituations);
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "minAltitude", x => minAltitude = x, this, 0.0, x => Validation.GE(x, 0.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "maxAltitude", x => maxAltitude = x, this, double.MaxValue, x => Validation.GE(x, 0.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "minApA", x => minApoapsis = x, this, 0.0, x => Validation.GE(x, 0.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "maxApA", x => maxApoapsis = x, this, double.MaxValue, x => Validation.GE(x, 0.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "minPeA", x => minPeriapsis = x, this, 0.0, x => Validation.GE(x, 0.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "maxPeA", x => maxPeriapsis = x, this, double.MaxValue, x => Validation.GE(x, 0.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "minEccentricity", x => minEccentricity = x, this, 0.0, x => Validation.GE(x, 0.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "maxEccentricity", x => maxEccentricity = x, this, double.MaxValue, x => Validation.GE(x, 0.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "minInclination", x => minInclination = x, this, 0.0, x => Validation.Between(x, 0.0, 180.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "maxInclination", x => maxInclination = x, this, 180.0, x => Validation.Between(x, 0.0, 180.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "minArgumentOfPeriapsis", x => minArgumentOfPeriapsis = x, this, 0.0, x => Validation.Between(x, 0.0, 360.0));
            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "maxArgumentOfPeriapsis", x => maxArgumentOfPeriapsis = x, this, 360.0, x => Validation.Between(x, 0.0, 360.0));
            valid &= ConfigNodeUtil.ParseValue<Duration>(configNode, "minPeriod", x => minPeriod = x, this, new Duration(0.0));
            valid &= ConfigNodeUtil.ParseValue<Duration>(configNode, "maxPeriod", x => maxPeriod = x, this, new Duration(double.MaxValue));

            // Validate target body
            valid &= ValidateTargetBody(configNode);

            // Validation minimum and groupings
            valid &= ConfigNodeUtil.AtLeastOne(configNode, new string[] { "minAltitude", "maxAltitude", "minApA", "maxApA", "minPeA", "maxPeA",
                "minEccentricity", "maxEccentricity", "minInclination", "maxInclination", "minPeriod", "maxPeriod", "minArgumentOfPeriapsis", "maxArgumentOfPeriapsis" }, this);
            valid &= ConfigNodeUtil.MutuallyExclusive(configNode, new string[] { "minAltitude", "maxAltitude" },
                new string[] { "minApA", "maxApA", "minPeA", "maxPeA" }, this);

            return valid;
        }

        private bool ValidateSituations(Vessel.Situations situation)
        {
            if (situation != Vessel.Situations.ESCAPING &&
                situation != Vessel.Situations.ORBITING &&
                situation != Vessel.Situations.SUB_ORBITAL)
            {
                LoggingUtil.LogError(this, "Invalid situation for Orbit parameter: " + situation + ".  For non-orbital situations, use ReachState instead.");
                return false;
            }
            return true;
        }

        public override ContractParameter Generate(Contract contract)
        {
            // Perform another validation of the target body to catch late validation issues due to expressions
            if (!ValidateTargetBody())
            {
                return null;
            }

            return new OrbitParameter(situation, minAltitude, maxAltitude, minApoapsis, maxApoapsis, minPeriapsis, maxPeriapsis,
                minEccentricity, maxEccentricity, minInclination, maxInclination, minArgumentOfPeriapsis, maxArgumentOfPeriapsis, minPeriod.Value, maxPeriod.Value, targetBody, title);
        }
    }
}

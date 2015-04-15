﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using Contracts;
using Contracts.Parameters;

namespace ContractConfigurator
{
    /// <summary>
    /// ParameterFactory wrapper for LaunchVessel ContractParameter.
    /// </summary>
    public class LaunchVesselFactory : ParameterFactory
    {
        public override ContractParameter Generate(Contract contract)
        {
            return new LaunchVessel();
        }
    }
}
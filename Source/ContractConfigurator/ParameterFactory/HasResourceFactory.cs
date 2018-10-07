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
    /// ParameterFactory wrapper for HasResource ContractParameter.
    /// </summary>
    public class HasResourceFactory : ParameterFactory
    {
        protected List<HasResource.Filter> filters = new List<HasResource.Filter>();

        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            IEnumerable<ConfigNode> nodes = ConfigNodeUtil.GetChildNodes(configNode, "RESOURCE");
            if (configNode.HasValue("resource"))
            {
                nodes = nodes.Concat(new ConfigNode[]{configNode});
            }

            foreach (ConfigNode childNode in nodes)
            {
                HasResource.Filter filter = new HasResource.Filter();

                valid &= ConfigNodeUtil.ParseValue<double>(childNode, "minQuantity", x => filter.minQuantity = x, this, 0.01, x => Validation.GE(x, 0.0));
                valid &= ConfigNodeUtil.ParseValue<double>(childNode, "maxQuantity", x => filter.maxQuantity = x, this, double.MaxValue, x => Validation.GE(x, 0.0));
                valid &= ConfigNodeUtil.ParseValue<Resource>(childNode, "resource", x => filter.resource = x.res, this);

                filters.Add(filter);
            }

            return valid;
        }

        public override ContractParameter Generate(Contract contract)
        {
            return new HasResource(filters, false, title);
        }
    }
}

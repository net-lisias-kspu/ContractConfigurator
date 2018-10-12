﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using Contracts;
using Contracts.Parameters;

namespace ContractConfigurator.Parameters
{
    /// <summary>
    /// Parameter for checking whether a vessel has the given resource.
    /// </summary>
    public class HasResource : VesselParameter
    {
        public class Filter
        {
            public PartResourceDefinition resource { get; set; }
            public double minQuantity { get; set; }
            public double maxQuantity { get; set; }

            public Filter() { }
        }

        protected List<Filter> filters = new List<Filter>();
        protected bool capacity = false;

        private float lastUpdate = 0.0f;
        private const float UPDATE_FREQUENCY = 0.25f;

        public HasResource()
            : base(null)
        {
        }

        public HasResource(List<Filter> filters, bool capacity, string title = null)
            : base(title)
        {
            this.filters = filters;
            this.capacity = capacity;

            CreateDelegates();
        }

        protected override string GetParameterTitle()
        {
            if (!string.IsNullOrEmpty(title)) return title;

            string output = null;
            if (state == ParameterState.Complete || ParameterCount == 1)
            {
                hideChildren |= ParameterCount == 1;

                output = ParameterDelegate<Vessel>.GetDelegateText(this);
            }
            return output;
        }

        protected void CreateDelegates()
        {
            for (int i = filters.Count - 1; i >= 0; i--)
            {
                Filter filter = filters[i];
                string output = (capacity ? "Resource Capacity: " : "Resource: ") + filter.resource.name + ": ";
                output +=
                    filter.maxQuantity == 0
                          ? "None"
                    : filter.maxQuantity == double.MaxValue && (filter.minQuantity > 0.0 && filter.minQuantity <= 0.01)
                          ? "Not zero units"
                    : filter.maxQuantity == double.MaxValue
                          ? "At least " + filter.minQuantity + " units"
                    : filter.minQuantity == 0
                          ? "At most " + filter.maxQuantity + " units"
                    : "Between " + filter.minQuantity + " and " + filter.maxQuantity + " units";
                AddParameter(new ParameterDelegate<Vessel>(output, v => VesselHasResource(v, filter.resource, capacity, filter.minQuantity, filter.maxQuantity), ParameterDelegateMatchType.VALIDATE));
            }
        }

        protected static bool VesselHasResource(Vessel vessel, PartResourceDefinition resource, bool capacity, double minQuantity, double maxQuantity)
        {
            double quantity = capacity ? vessel.ResourceCapacity(resource) : vessel.ResourceQuantity(resource);
            return quantity >= minQuantity && quantity <= maxQuantity;
        }

        protected override void OnParameterSave(ConfigNode node)
        {
            base.OnParameterSave(node);

            node.AddValue("capacity", capacity);

            for (int i = filters.Count - 1; i >= 0; i--)
            {
                Filter filter = filters[i];
                ConfigNode childNode = new ConfigNode("RESOURCE");
                node.AddNode(childNode);

                childNode.AddValue("resource", filter.resource.name);
                childNode.AddValue("minQuantity", filter.minQuantity);
                if (filter.maxQuantity != double.MaxValue)
                {
                    childNode.AddValue("maxQuantity", filter.maxQuantity);
                }
            }
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
            try
            {
                base.OnParameterLoad(node);

                capacity = ConfigNodeUtil.ParseValue<bool?>(node, "capacity", (bool?)false).Value;

                for (int i = node.GetNodes("RESOURCE").Length - 1; i >= 0; i--)
                {
                    ConfigNode childNode = node.GetNodes("RESOURCE")[i];
                    Filter filter = new Filter
                    {
                        resource = ConfigNodeUtil.ParseValue<PartResourceDefinition>(childNode, "resource"),
                        minQuantity = ConfigNodeUtil.ParseValue<double>(childNode, "minQuantity"),
                        maxQuantity = ConfigNodeUtil.ParseValue<double>(childNode, "maxQuantity", double.MaxValue)
                    };

                    filters.Add(filter);
                }

                // Legacy
                if (node.HasValue("resource"))
                {
                    Filter filter = new Filter
                    {
                        resource = ConfigNodeUtil.ParseValue<PartResourceDefinition>(node, "resource"),
                        minQuantity = ConfigNodeUtil.ParseValue<double>(node, "minQuantity"),
                        maxQuantity = ConfigNodeUtil.ParseValue<double>(node, "maxQuantity", double.MaxValue)
                    };

                    filters.Add(filter);
                }

                CreateDelegates();
            }
            finally
            {
                ParameterDelegate<Part>.OnDelegateContainerLoad(node);
            }
        }

        protected override void OnRegister()
        {
            base.OnRegister();
        }

        protected override void OnUnregister()
        {
            base.OnUnregister();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (UnityEngine.Time.fixedTime - lastUpdate > UPDATE_FREQUENCY)
            {
                lastUpdate = UnityEngine.Time.fixedTime;
                CheckVessel(FlightGlobals.ActiveVessel);
            }
        }

        /// <summary>
        /// Whether this vessel meets the parameter condition.
        /// </summary>
        /// <param name="vessel">The vessel to check</param>
        /// <returns>Whether the vessel meets the condition</returns>
        protected override bool VesselMeetsCondition(Vessel vessel)
        {
            LoggingUtil.LogVerbose(this, "Checking VesselMeetsCondition: " + vessel.id);

            return ParameterDelegate<Vessel>.CheckChildConditions(this, vessel);
        }
    }
}

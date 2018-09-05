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
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class ResourceConsumptionChecker : MonoBehaviour
    {
        private int activeCount = 0;
        private HashSet<PartResourceDefinition> resources = new HashSet<PartResourceDefinition>();

        private static int CHECK_SIZE = 10;
        private int checks = 0;
        private Dictionary<PartResourceDefinition, double[]> checkValues = new Dictionary<PartResourceDefinition, double[]>();
        private Guid currentVessel;
        private int partCount;

        public static ResourceConsumptionChecker Instance;

        void Start()
        {
            Instance = this;
        }

        void FixedUpdate()
        {
            if (activeCount == 0 || FlightGlobals.ActiveVessel == null)
            {
                return;
            }

            if (FlightGlobals.ActiveVessel.id != currentVessel)
            {
                currentVessel = FlightGlobals.ActiveVessel.id;
                checks = 0;
                partCount = -1;
            }

            foreach (PartResourceDefinition resource in resources)
            {
                int localCount = 0;
                double quantity = 0.0;
                foreach (Part part in FlightGlobals.ActiveVessel.Parts)
                {
                    localCount++;
                    PartResource pr = part.Resources[resource.name];
                    if (pr != null)
                    {
                        quantity += pr.amount;
                    }
                }

                if (partCount == -1)
                {
                    partCount = localCount;
                }
                // Reset counter on vessel change
                if (partCount != localCount)
                {
                    checks = 0;
                }

                checkValues[resource][checks++ % CHECK_SIZE] = quantity;
            }
        }

        public static void Register(PartResourceDefinition resource)
        {
            if (Instance == null || !Instance.isActiveAndEnabled)
            {
                return;
            }

            Instance.activeCount++;
            if (!Instance.resources.Contains(resource))
            {
                Instance.resources.Add(resource);
                Instance.checkValues[resource] = new double[CHECK_SIZE];
            }
        }

        public static void UnRegister()
        {
            if (Instance == null || !Instance.isActiveAndEnabled)
            {
                return;
            }

            Instance.activeCount--;
            if (Instance.activeCount <= 0)
            {
                Instance.activeCount = 0;
                Instance.checkValues.Clear();
                Instance.resources.Clear();
            }
        }

        public static bool CanCheckVessel(Vessel vessel)
        {
            return Instance == null || !Instance.isActiveAndEnabled
                ? false
                : vessel.id == Instance.currentVessel && Instance.checks >= CHECK_SIZE;
        }

        public double Consumption(PartResourceDefinition resource)
        {
            double delta = 0;
            double[] vals = checkValues[resource];
            for (int i = 0; i < CHECK_SIZE-1; i++)
            {
                delta += vals[(i + checks) % CHECK_SIZE] - vals[(i + checks + 1) % CHECK_SIZE];
            }
            delta /= (CHECK_SIZE-1) * Time.fixedDeltaTime;

            return delta;
        }
    }

    /// <summary>
    /// Parameter for checking the consumption of the given resource
    /// </summary>
    public class ResourceConsumption : VesselParameter
    {
        public PartResourceDefinition resource { get; set; }
        public double minRate { get; set; }
        public double maxRate { get; set; }

        private float lastUpdate = 0.0f;
        private const float UPDATE_FREQUENCY = 0.25f;

        public ResourceConsumption()
            : base(null)
        {
        }

        public ResourceConsumption(double minRate, double maxRate, PartResourceDefinition resource, string title = null)
            : base(title)
        {
            if (minRate < 0 && maxRate < 0 && maxRate < minRate)
            {
                this.minRate = maxRate;
                this.maxRate = minRate;
            }
            else
            {
                this.minRate = minRate;
                this.maxRate = maxRate;
            }
            this.resource = resource;
        }

        protected override string GetParameterTitle()
        {
            if (!string.IsNullOrEmpty(title)) return title;

            string output = null;
            output = "Resource " + (minRate >= 0 ? "Consumption: " : "Production: ") + resource.name + ": ";
            if (maxRate == 0 && minRate == 0)
            {
                output += "None";
            }
            else if (maxRate == double.MaxValue)
            {
                output += "At least " + minRate.ToString("N1") + " units/s";
            }
            else if (minRate == double.MinValue)
            {
                output += "At least " + (-maxRate).ToString("N1") + " units/s";
            }
            else if (minRate >= 0)
            {
                output += "Between " + minRate.ToString("N1") + " and " + maxRate.ToString("N1") + " units/s";
            }
            else if (minRate < 0)
            {
                output += "Between " + (-maxRate).ToString("N1") + " and " + (-minRate).ToString("N1") + " units/s";
            }
            return output;
        }

        protected static bool VesselHasResource(Vessel vessel, PartResourceDefinition resource, bool capacity, double minQuantity, double maxQuantity)
        {
            double quantity = capacity ? vessel.ResourceCapacity(resource) : vessel.ResourceQuantity(resource);
            return quantity >= minQuantity && quantity <= maxQuantity;
        }

        protected override void OnParameterSave(ConfigNode node)
        {
            base.OnParameterSave(node);

            if (minRate != double.MinValue)
            {
                node.AddValue("minRate", minRate);

            }
            if (maxRate != double.MaxValue)
            {
                node.AddValue("maxRate", maxRate);
            }
            node.AddValue("resource", resource.name);
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
            base.OnParameterLoad(node);

            resource = ConfigNodeUtil.ParseValue<PartResourceDefinition>(node, "resource");
            minRate = ConfigNodeUtil.ParseValue<double>(node, "minRate", double.MinValue);
            maxRate = ConfigNodeUtil.ParseValue<double>(node, "maxRate", double.MaxValue);
        }

        protected override void OnRegister()
        {
            ResourceConsumptionChecker.Register(resource);
            base.OnRegister();
        }

        protected override void OnUnregister()
        {
            ResourceConsumptionChecker.UnRegister();
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

            if (!ResourceConsumptionChecker.CanCheckVessel(vessel))
                return false;

            double delta = ResourceConsumptionChecker.Instance.Consumption(resource);
            LoggingUtil.LogVerbose(this, "Delta for resource " + resource.name + " is: " + delta);
            return delta - minRate >= -0.001 && maxRate - delta >= -0.001;
        }
    }
}

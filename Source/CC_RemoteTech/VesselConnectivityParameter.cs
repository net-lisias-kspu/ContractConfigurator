﻿using ContractConfigurator.Parameters;
using Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using RemoteTech;
using ContractConfigurator;

namespace ContractConfigurator.RemoteTech
{
    /// <summary>
    /// Parameter to indicate that a vessel has connectivity with another vessel.
    /// </summary>
    public class VesselConnectivityParameter : RemoteTechParameter
    {
        protected bool hasConnectivity { get; set; }
        protected string vesselKey { get; set; }

        private double lastUpdate = 0.0;

        public VesselConnectivityParameter()
            : this(null)
        {
        }

        public VesselConnectivityParameter(string vesselKey, bool hasConnectivity = true, string title = null)
            : base(title)
        {
            this.vesselKey = vesselKey;
            this.hasConnectivity = hasConnectivity;
        }

        protected override string GetParameterTitle()
        {
            if (string.IsNullOrEmpty(title))
            {
                string output = (hasConnectivity ? "Direct connection to: " : "No direct connection to: ");
                output += ContractVesselTracker.GetDisplayName(vesselKey);
                return output;
            }
            return title;
        }

        protected override void OnParameterSave(ConfigNode node)
        {
            base.OnParameterSave(node);

            node.AddValue("hasConnectivity", hasConnectivity);
            node.AddValue("vesselKey", vesselKey);
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
            base.OnParameterLoad(node);

            hasConnectivity = ConfigNodeUtil.ParseValue<bool>(node, "hasConnectivity");
            vesselKey = node.GetValue("vesselKey");
        }

        protected override void OnRegister()
        {
            base.OnRegister();
            ContractVesselTracker.OnVesselAssociation.Add(new EventData<GameEvents.HostTargetAction<Vessel, string>>.OnEvent(OnVesselAssociation));
            ContractVesselTracker.OnVesselDisassociation.Add(new EventData<GameEvents.HostTargetAction<Vessel, string>>.OnEvent(OnVesselDisassociation));
        }

        protected override void OnUnregister()
        {
            base.OnUnregister();
            ContractVesselTracker.OnVesselAssociation.Remove(new EventData<GameEvents.HostTargetAction<Vessel, string>>.OnEvent(OnVesselAssociation));
            ContractVesselTracker.OnVesselDisassociation.Remove(new EventData<GameEvents.HostTargetAction<Vessel, string>>.OnEvent(OnVesselDisassociation));
        }

        protected void OnVesselAssociation(GameEvents.HostTargetAction<Vessel, string> hta)
        {
            // Force a title update if it's the vessel we're looking at
            if (vesselKey == hta.target)
            {
                GetTitle();
            }
            CheckVessel(hta.host);
        }

        protected void OnVesselDisassociation(GameEvents.HostTargetAction<Vessel, string> hta)
        {
            // Force a title update if it's the vessel we're looking at
            if (vesselKey == hta.target)
            {
                GetTitle();
            }
            CheckVessel(hta.host);
        }

        protected override void OnUpdate()
        {
            // Every second check the contract window for a title update.
            if (Time.fixedTime - lastUpdate > 1.0f)
            {
                lastUpdate = Time.fixedTime;
                GetTitle();
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
            
            // Check vessels
            Vessel vessel2 = ContractVesselTracker.Instance.GetAssociatedVessel(vesselKey);
            if (vessel == null || vessel2 == null)
            {
                return false;
            }

            // Get satellites
            VesselSatellite sat1 = RTCore.Instance.Satellites[vessel.id];
            VesselSatellite sat2 = RTCore.Instance.Satellites[vessel2.id];
            if (sat1 == null || sat2 == null)
            {
                return false;
            }

            // Check if there is a link
            return NetworkManager.GetLink(sat1, sat2) != null;
        }
    }
}

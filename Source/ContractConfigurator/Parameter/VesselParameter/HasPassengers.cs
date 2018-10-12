﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using Contracts;
using Contracts.Parameters;
using ContractConfigurator.Behaviour;

namespace ContractConfigurator.Parameters
{
    /// <summary>
    /// Parameter for checking whether a vessel has space for passengers.
    /// </summary>
    public class HasPassengers : VesselParameter, IKerbalNameStorage
    {
        protected int index = 0;
        protected int count = 0;
        private List<Kerbal> passengers = new List<Kerbal>();

        public HasPassengers()
            : base(null)
        {
        }

        public HasPassengers(string title, int index, int count)
            : base(title)
        {
            this.index = index;
            this.count = count;

            CreateDelegates();
        }

        public HasPassengers(string title, IEnumerable<Kerbal> passengers)
            : base(title)
        {
            this.passengers = passengers.ToList();

            CreateDelegates();
        }

        protected override string GetParameterTitle()
        {
            if (!string.IsNullOrEmpty(title)) return title;

            string output = "";
            if (passengers.Count == 0)
            {
                output = "Load " + (count == 0 ? "all" : count.ToString()) + " passenger" + (count != 1 ? "s" : "") + " while on the launchpad/runway";
            }
            else if (passengers.Count == 1)
            {
                output = "Passenger " + ParameterDelegate<Vessel>.GetDelegateText(this);
                hideChildren = true;
            }
            else
            {
                output = state == ParameterState.Complete ? "Passengers: " + passengers.Count : "Passengers";
            }
            return output;
        }

        protected void CreateDelegates()
        {
            // Filter for passengers
            if (passengers.Count > 0)
            {
                // Clear any pre-existing child parameters
                while (ParameterCount > 0)
                {
                    RemoveParameter(0);
                }

                for (int i = passengers.Count - 1; i >= 0; i--)
                {
                    Kerbal passenger = passengers[i];
                    AddParameter(new ParameterDelegate<Vessel>("On Board: " + passenger.name, v => passenger.pcm != null && v.GetVesselCrew().Contains(passenger.pcm), ParameterDelegateMatchType.VALIDATE_ALL));
                }
            }
        }

        protected override void OnParameterSave(ConfigNode node)
        {
            base.OnParameterSave(node);
            node.AddValue("index", index);
            node.AddValue("count", count);

            for (int i = passengers.Count - 1; i >= 0; i--)
            {
                Kerbal passenger = passengers[i];
                ConfigNode kerbalNode = new ConfigNode("KERBAL");
                node.AddNode(kerbalNode);

                passenger.Save(kerbalNode);
            }
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
            try
            {
                base.OnParameterLoad(node);
                index = Convert.ToInt32(node.GetValue("index"));
                count = Convert.ToInt32(node.GetValue("count"));

                // Legacy support from Contract Configurator 1.8.3
                if (node.HasValue("passenger"))
                {
                    passengers = ConfigNodeUtil.ParseValue<List<string>>(node, "passenger", new List<string>()).Select(
                        name => new Kerbal(name)
                    ).ToList();
                }
                else
                {
                    for (int i = node.GetNodes("KERBAL").Length - 1; i >= 0; i--)
                    {
                        ConfigNode kerbalNode = node.GetNodes("KERBAL")[i];
                        passengers.Add(Kerbal.Load(kerbalNode));
                    }
                }

                CreateDelegates();
            }
            finally
            {
                ParameterDelegate<Vessel>.OnDelegateContainerLoad(node);
            }
        }

        protected override void OnRegister()
        {
            base.OnRegister();
            GameEvents.onCrewTransferred.Add(new EventData<GameEvents.HostedFromToAction<ProtoCrewMember, Part>>.OnEvent(OnCrewTransferred));
            GameEvents.Contract.onAccepted.Add(new EventData<Contract>.OnEvent(OnContractAccepted));
            SpawnPassengers.onPassengersLoaded.Add(new EventVoid.OnEvent(OnPassengersLoaded));
        }

        protected override void OnUnregister()
        {
            base.OnUnregister();
            GameEvents.onCrewTransferred.Remove(new EventData<GameEvents.HostedFromToAction<ProtoCrewMember, Part>>.OnEvent(OnCrewTransferred));
            GameEvents.Contract.onAccepted.Remove(new EventData<Contract>.OnEvent(OnContractAccepted));
            SpawnPassengers.onPassengersLoaded.Remove(new EventVoid.OnEvent(OnPassengersLoaded));
        }

        protected void OnContractAccepted(Contract contract)
        {
            if (contract == Root)
            {
                int count = this.count == 0 && !passengers.Any()? ((ConfiguredContract)contract).GetSpawnedKerbalCount() : this.count;
                for (int i = passengers.Count(); i < count; i++)
                {
                    ProtoCrewMember kerbal = ((ConfiguredContract)contract).GetSpawnedKerbal(index+i).pcm;
                    passengers.Add(new Kerbal(kerbal));
                }
                CreateDelegates();
            }
        }

        protected void OnPassengersLoaded()
        {
            CheckVessel(FlightGlobals.ActiveVessel);
        }

        protected override void OnPartAttach(GameEvents.HostTargetAction<Part, Part> e)
        {
            base.OnPartAttach(e);
            CheckVessel(FlightGlobals.ActiveVessel);
        }

        protected override void OnVesselCreate(Vessel vessel)
        {
            base.OnVesselCreate(vessel);
            CheckVessel(vessel);
            CheckVessel(FlightGlobals.ActiveVessel);
        }

        protected override void OnCrewTransferred(GameEvents.HostedFromToAction<ProtoCrewMember, Part> a)
        {
            base.OnCrewTransferred(a);

            // Check both, as the Kerbal/ship swap spots depending on whether the vessel is
            // incoming or outgoing
            CheckVessel(a.from.vessel);
            CheckVessel(a.to.vessel);
        }

        /// <summary>
        /// Whether this vessel meets the parameter condition.
        /// </summary>
        /// <param name="vessel">The vessel to check.</param>
        /// <returns>Whether the vessel meets the conditions.</returns>
        protected override bool VesselMeetsCondition(Vessel vessel)
        {
            LoggingUtil.LogVerbose(this, "Checking VesselMeetsCondition: " + vessel.id);

            // No passengers loaded
            if (passengers.Count == 0)
            {
                return false;
            }

            return ParameterDelegate<Vessel>.CheckChildConditions(this, vessel);
        }

        public IEnumerable<string> KerbalNames()
        {
            for (int i = passengers.Count - 1; i >= 0; i--)
            {
                Kerbal kerbal = passengers[i];
                yield return kerbal.name;
            }
        }
    }
}

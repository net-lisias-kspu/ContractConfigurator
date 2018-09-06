using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSP.UI.Screens;
using Contracts;
using Contracts.Parameters;
using ContractConfigurator.Behaviour;

namespace ContractConfigurator.Parameters
{
    /// <summary>
    /// Parameter for recovering a Kerbal.
    /// </summary>
    public class RecoverKerbalCustom : ContractConfiguratorParameter, ParameterDelegateContainer, IKerbalNameStorage
    {
        protected int index;
        protected int count;
        protected List<Kerbal> kerbals = new List<Kerbal>();
        protected Dictionary<string, bool> recovered = new Dictionary<string, bool>();

        public bool ChildChanged { get; set; }
        public int kerbalKilledCheck = int.MaxValue;

        public RecoverKerbalCustom()
            : base(null)
        {
        }

        public RecoverKerbalCustom(IEnumerable<Kerbal> kerbals, int index, int count, string title)
            : base(title)
        {
            this.index = index;
            this.count = count;
            this.kerbals = kerbals.ToList();
            foreach (Kerbal kerbal in kerbals)
            {
                recovered[kerbal.name] = false;
            }

            hideChildren |= kerbals.Count() + count == 1;

            CreateDelegates();
        }

        protected override string GetParameterTitle()
        {
            if (!string.IsNullOrEmpty(title)) return title;

            string output = "";
            if (kerbals.Count == 1)
            {
                output = "Recover " + kerbals[0];
                hideChildren = true;
            }
            else
            {
                output = "Recover Kerbals";
            }
            return output;
        }

        protected void CreateDelegates()
        {
            for (int i = kerbals.Count - 1; i >= 0; i--)
            {
                Kerbal kerbal = kerbals[i];
                AddParameter(new ParameterDelegate<string>("Recover " + kerbal.name, unused => recovered[kerbal.name], ParameterDelegateMatchType.FILTER));
            }
        }

        protected override void OnParameterSave(ConfigNode node)
        {
            node.AddValue("count", count);
            node.AddValue("index", index);

            for (int i = kerbals.Count - 1; i >= 0; i--)
            {
                Kerbal kerbal = kerbals[i];
                ConfigNode kerbalNode = new ConfigNode("KERBAL");
                node.AddNode(kerbalNode);

                kerbal.Save(kerbalNode);
                kerbalNode.AddValue("recovered", recovered.ContainsKey(kerbal.name) && recovered[kerbal.name]);
            }
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
            try
            {
                count = ConfigNodeUtil.ParseValue<int>(node, "count");
                index = ConfigNodeUtil.ParseValue<int>(node, "index");

                for (int i = node.GetNodes("KERBAL").Length - 1; i >= 0; i--)
                {
                    ConfigNode kerbalNode = node.GetNodes("KERBAL")[i];
                    // Legacy support for Contract Configurator 1.8.3
                    if (kerbalNode.HasValue("kerbal"))
                    {
                        kerbalNode.AddValue("name", kerbalNode.GetValue("kerbal"));
                    }

                    kerbals.Add(Kerbal.Load(kerbalNode));
                    recovered[kerbals.Last().name] = ConfigNodeUtil.ParseValue<bool>(kerbalNode, "recovered");
                }

                CreateDelegates();
            }
            finally
            {
                ParameterDelegate<string>.OnDelegateContainerLoad(node);
            }
        }

        protected override void OnRegister()
        {
            base.OnRegister();
            GameEvents.onVesselCreate.Add(new EventData<Vessel>.OnEvent(OnVesselCreate));
            GameEvents.onCrewTransferred.Add(new EventData<GameEvents.HostedFromToAction<ProtoCrewMember, Part>>.OnEvent(OnCrewTransferred));
            GameEvents.onVesselRecovered.Add(new EventData<ProtoVessel, bool>.OnEvent(OnVesselRecovered));
            GameEvents.onCrewKilled.Add(new EventData<EventReport>.OnEvent(OnCrewKilled));
            GameEvents.Contract.onAccepted.Add(new EventData<Contract>.OnEvent(OnContractAccepted));
            ContractConfigurator.OnParameterChange.Add(new EventData<Contract, ContractParameter>.OnEvent(OnParameterChange));
        }

        protected override void OnUnregister()
        {
            base.OnUnregister();
            GameEvents.onVesselCreate.Remove(new EventData<Vessel>.OnEvent(OnVesselCreate));
            GameEvents.onCrewTransferred.Remove(new EventData<GameEvents.HostedFromToAction<ProtoCrewMember, Part>>.OnEvent(OnCrewTransferred));
            GameEvents.onVesselRecovered.Remove(new EventData<ProtoVessel, bool>.OnEvent(OnVesselRecovered));
            GameEvents.onCrewKilled.Remove(new EventData<EventReport>.OnEvent(OnCrewKilled));
            GameEvents.Contract.onAccepted.Remove(new EventData<Contract>.OnEvent(OnContractAccepted));
            ContractConfigurator.OnParameterChange.Remove(new EventData<Contract, ContractParameter>.OnEvent(OnParameterChange));
        }

        private void OnVesselCreate(Vessel v)
        {
            for (int i = v.GetVesselCrew().Count - 1; i >= 0; i--)
            {
                ProtoCrewMember crew = v.GetVesselCrew()[i];
                if (recovered.ContainsKey(crew.name))
                {
                    recovered[crew.name] = false;
                }
            }

            TestConditions();
        }

        private void OnCrewTransferred(GameEvents.HostedFromToAction<ProtoCrewMember, Part> evt)
        {
            if (recovered.ContainsKey(evt.host.name))
            {
                recovered[evt.host.name] = false;
            }

            TestConditions();
        }

        private void OnVesselRecovered(ProtoVessel v, bool quick)
        {
            // Don't check if we're not ready to complete
            if (!ReadyToComplete())
            {
                return;
            }

            // EVA vessel
            if (v.vesselType == VesselType.EVA)
            {
                if (v.protoPartSnapshots != null)
                {
                    for (int i = v.protoPartSnapshots.Count - 1; i >= 0; i--)
                    {
                        ProtoPartSnapshot p = v.protoPartSnapshots[i];
                        for (int j = p.protoModuleCrew.Count - 1; j >= 0; j--)
                        {
                            ProtoCrewMember pcm = p.protoModuleCrew[j];
                            recovered[pcm.name] = true;
                        }
                    }
                }
            }
            else
            {
                for (int i = v.GetVesselCrew().Count - 1; i >= 0; i--)
                {
                    ProtoCrewMember crew = v.GetVesselCrew()[i];
                    if (recovered.ContainsKey(crew.name))
                    {
                        recovered[crew.name] = true;
                    }
                }
            }

            TestConditions();
        }

        private void OnCrewKilled(EventReport evt)
        {
            if (recovered.ContainsKey(evt.sender))
            {
                kerbalKilledCheck = Time.frameCount + 5;
            }
        }

        protected override void OnUpdate()
        {
            if (kerbalKilledCheck <= Time.frameCount)
            {
                kerbalKilledCheck = int.MaxValue;

                IEnumerable<ProtoCrewMember> allKerbals = HighLogic.CurrentGame.CrewRoster.AllKerbals();
                foreach (string name in recovered.Keys.Where(n => !recovered[n] &&
                    (!allKerbals.Any(pcm => pcm.name == n) || allKerbals.Any(pcm => pcm.name == n &&
                        (pcm.rosterStatus == ProtoCrewMember.RosterStatus.Missing || pcm.rosterStatus == ProtoCrewMember.RosterStatus.Dead)))))
                {
                    MessageSystem.Instance.AddMessage(new MessageSystem.Message("Contract failed", name + " has been killed!",
                        MessageSystemButton.MessageButtonColor.RED, MessageSystemButton.ButtonIcons.MESSAGE));
                    SetState(ParameterState.Failed);
                    break;
                }
            }
        }

        protected void OnContractAccepted(Contract contract)
        {
            if (contract == Root && kerbals.Count == 0)
            {
                int count = this.count == 0 ? ((ConfiguredContract)contract).GetSpawnedKerbalCount() : this.count;
                for (int i = count - 1; i >= 0; i--)
                {
                    Kerbal kerbal = ((ConfiguredContract)contract).GetSpawnedKerbal(index + i);
                    kerbals.Add(kerbal);
                    recovered[kerbal.name] = false;
                }

                for (int i = 0, kerbalsCount = kerbals.Count; i < kerbalsCount; i++)
                {
                    Kerbal kerbal = kerbals[i];
                    // Instantiate the kerbals if necessary
                    if (kerbal.pcm == null)
                    {
                        kerbal.GenerateKerbal();
                    }
                }

                CreateDelegates();
            }
        }

        private void OnParameterChange(Contract contract, ContractParameter parameter)
        {
            if (contract != Root || parameter == this)
            {
                return;
            }

            TestConditions();
        }

        private void TestConditions()
        {
            // Retest the conditions
            bool success = ParameterDelegate<string>.CheckChildConditions(this, "") && ParameterCount > 0;
            if (ChildChanged || success)
            {
                ChildChanged = false;
                if (success)
                {
                    SetState(ParameterState.Complete);
                }
                else
                {
                    SetState(ParameterState.Incomplete);
                    ContractConfigurator.OnParameterChange.Fire(Root, this);
                }
            }
        }

        public IEnumerable<string> KerbalNames()
        {
            foreach (Kerbal kerbal in kerbals)
            {
                yield return kerbal.name;
            }
        }
    }
}

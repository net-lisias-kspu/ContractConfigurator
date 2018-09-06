using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using Contracts;
using Contracts.Parameters;
using Experience;

namespace ContractConfigurator.Parameters
{
    /// <summary>
    /// Parameter for checking whether a vessel has a crew.
    /// </summary>
    public class HasCrew : VesselParameter, IKerbalNameStorage
    {
        protected string trait { get; set; }
        protected int minCrew { get; set; }
        protected int maxCrew { get; set; }
        protected int minExperience { get; set; }
        protected int maxExperience { get; set; }
        protected List<Kerbal> kerbals = new List<Kerbal>();
        protected List<Kerbal> excludeKerbals = new List<Kerbal>();

        public HasCrew()
            : base(null)
        {
        }

        public HasCrew(string title, IEnumerable<Kerbal> kerbals, IEnumerable<Kerbal> excludeKerbals, string trait, int minCrew = 1, int maxCrew = int.MaxValue, int minExperience = 0, int maxExperience = 5)
            : base(title)
        {
            if (minCrew > maxCrew)
            {
                minCrew = maxCrew;
            }

            this.minCrew = minCrew;
            this.maxCrew = maxCrew;
            this.minExperience = minExperience;
            this.maxExperience = maxExperience;
            this.trait = trait;
            this.kerbals = kerbals == null ? new List<Kerbal>() : kerbals.ToList();
            this.excludeKerbals = excludeKerbals == null ? new List<Kerbal>() : excludeKerbals.ToList();

            CreateDelegates();
        }

        protected override string GetParameterTitle()
        {
            if (!string.IsNullOrEmpty(title)) return title;

            if (kerbals.Count == 0 && (state == ParameterState.Complete || ParameterCount == 1))
            {
                hideChildren |= ParameterCount == 1;

                string traitString = String.IsNullOrEmpty(trait) ? "Kerbal" : TraitTitle(trait);

                string output = "Crew: ";
                output += 
                    maxCrew == 0 
                        ? "Unmanned"
                    : maxCrew == int.MaxValue
                        ? "At least " + minCrew + " " + traitString + (minCrew != 1 ? "s" : "")
                    : minCrew == 0
                        ? "At most " + maxCrew + " " + traitString + (maxCrew != 1 ? "s" : "")
                    : minCrew == maxCrew
                        ? minCrew + " " + traitString + (minCrew != 1 ? "s" : "")
                    : "Between " + minCrew + " and " + maxCrew + " " + traitString + "s"
                ;
                if (minExperience != 0 || maxExperience != 5)
                {
                    output += 
                        minExperience == 0
                            ? " with experience level of at most " + maxExperience
                        : maxExperience == 5
                            ? " with experience level of at least " + minExperience
                        : " with experience level between " + minExperience + " and " + maxExperience
                    ;
                }
                return output;
            }

            {
                string output = "Crew";
                if (state == ParameterState.Complete || ParameterCount == 1)
                {
                    hideChildren |= ParameterCount == 1;

                    output += ": " + ParameterDelegate<ProtoCrewMember>.GetDelegateText(this);
                }
                return output;
            }
        }

        protected void CreateDelegates()
        {
            // Experience trait
            if (!string.IsNullOrEmpty(trait))
            {
                AddParameter(new ParameterDelegate<ProtoCrewMember>("Trait: " + TraitTitle(trait),
                    cm => cm.experienceTrait.Config.Name == trait));
            }

            // Filter for experience
            if (minExperience != 0 || maxExperience != 5)
            {
                string filterText = 
                    minExperience == 0
                        ? "Experience Level: At most " + maxExperience
                    : maxExperience == 5
                        ? "Experience Level: At least " + minExperience
                    : "Experience Level: Between " + minExperience + " and " + maxExperience;
                AddParameter(new ParameterDelegate<ProtoCrewMember>(filterText,
                    cm => cm.experienceLevel >= minExperience && cm.experienceLevel <= maxExperience));
            }

            // Validate count
            if (kerbals.Count == 0)
            {
                // Special handling for unmanned
                if (minCrew == 0 && maxCrew == 0)
                {
                    AddParameter(new ParameterDelegate<ProtoCrewMember>("Unmanned", pcm => true, ParameterDelegateMatchType.NONE));
                }
                else
                {
                    AddParameter(new CountParameterDelegate<ProtoCrewMember>(minCrew, maxCrew));
                }
            }

            // Validate specific kerbals
            for (int i = kerbals.Count - 1; i >= 0; i--)
            {
                Kerbal kerbal = kerbals[i];
                AddParameter(new ParameterDelegate<ProtoCrewMember>(kerbal.name + ": On board", pcm => pcm == kerbal.pcm, ParameterDelegateMatchType.VALIDATE));
            }
        }

        protected override void OnParameterSave(ConfigNode node)
        {
            base.OnParameterSave(node);
            if (trait != null)
            {
                node.AddValue("trait", trait);
            }
            node.AddValue("minCrew", minCrew);
            node.AddValue("maxCrew", maxCrew);
            node.AddValue("minExperience", minExperience);
            node.AddValue("maxExperience", maxExperience);
            for (int i = kerbals.Count - 1; i >= 0; i--)
            {
                Kerbal kerbal = kerbals[i];
                ConfigNode kerbalNode = new ConfigNode("KERBAL");
                node.AddNode(kerbalNode);

                kerbal.Save(kerbalNode);
            }

            for (int i = excludeKerbals.Count - 1; i >= 0; i--)
            {
                Kerbal kerbal = excludeKerbals[i];
                ConfigNode kerbalNode = new ConfigNode("KERBAL_EXCLUDE");
                node.AddNode(kerbalNode);

                kerbal.Save(kerbalNode);
            }
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
            try
            {
                base.OnParameterLoad(node);
                trait = ConfigNodeUtil.ParseValue<string>(node, "trait", (string)null);
                minExperience = Convert.ToInt32(node.GetValue("minExperience"));
                maxExperience = Convert.ToInt32(node.GetValue("maxExperience"));
                minCrew = Convert.ToInt32(node.GetValue("minCrew"));
                maxCrew = Convert.ToInt32(node.GetValue("maxCrew"));

                for (int i = node.GetNodes("KERBAL").Length - 1; i >= 0; i--)
                {
                    ConfigNode kerbalNode = node.GetNodes("KERBAL")[i];
                    kerbals.Add(Kerbal.Load(kerbalNode));
                }

                for (int i = node.GetNodes("KERBAL_EXCLUDE").Length - 1; i >= 0; i--)
                {
                    ConfigNode kerbalNode = node.GetNodes("KERBAL_EXCLUDE")[i];
                    excludeKerbals.Add(Kerbal.Load(kerbalNode));
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
            GameEvents.onVesselWasModified.Add(new EventData<Vessel>.OnEvent(OnVesselWasModified));
            GameEvents.Contract.onAccepted.Add(new EventData<Contract>.OnEvent(OnContractAccepted));
        }

        protected override void OnUnregister()
        {
            base.OnUnregister();
            GameEvents.onCrewTransferred.Remove(new EventData<GameEvents.HostedFromToAction<ProtoCrewMember, Part>>.OnEvent(OnCrewTransferred));
            GameEvents.onVesselWasModified.Remove(new EventData<Vessel>.OnEvent(OnVesselWasModified));
            GameEvents.Contract.onAccepted.Remove(new EventData<Contract>.OnEvent(OnContractAccepted));
        }

        private void OnContractAccepted(Contract c)
        {
            if (c != Root)
            {
                return;
            }

            foreach (Kerbal kerbal in kerbals.Union(excludeKerbals))
            {
                // Instantiate the kerbals if necessary
                if (kerbal.pcm == null)
                {
                    kerbal.GenerateKerbal();
                }
            }
        }

        protected override void OnPartAttach(GameEvents.HostTargetAction<Part, Part> e)
        {
            base.OnPartAttach(e);
            CheckVessel(FlightGlobals.ActiveVessel);
        }

        protected void OnVesselWasModified(Vessel v)
        {
            LoggingUtil.LogVerbose(this, "OnVesselWasModified: " + v);
            CheckVessel(v);
        }

        protected override void OnPartJointBreak(PartJoint p, float breakForce)
        {
            LoggingUtil.LogVerbose(this, "OnPartJointBreak: " + p);
            base.OnPartJointBreak(p, breakForce);

            if (HighLogic.LoadedScene == GameScenes.EDITOR || p.Parent.vessel == null)
            {
                return;
            }

            CheckVessel(p.Parent.vessel);
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
        /// <param name="vessel">The vessel to check</param>
        /// <returns>Whether the vessel meets the condition</returns>
        protected override bool VesselMeetsCondition(Vessel vessel)
        {
            LoggingUtil.LogVerbose(this, "Checking VesselMeetsCondition: " + vessel.id);

            // If we're a VesselParameterGroup child, only do actual state change if we're the tracked vessel
            bool checkOnly = false;
            if (Parent is VesselParameterGroup)
            {
                checkOnly = ((VesselParameterGroup)Parent).TrackedVessel != vessel;
            }

            return ParameterDelegate<ProtoCrewMember>.CheckChildConditions(this, GetVesselCrew(vessel, maxCrew == int.MaxValue), checkOnly);
        }

        protected string TraitTitle(string traitName)
        {
            ExperienceTraitConfig config = GameDatabase.Instance.ExperienceConfigs.Categories.FirstOrDefault(c => c.Name == traitName);

            return config != null ? config.Title : traitName;
        }

        /// <summary>
        /// Gets the vessel crew and works for EVAs as well
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        protected IEnumerable<ProtoCrewMember> GetVesselCrew(Vessel v, bool includeTourists)
        {
            if (v == null)
            {
                yield break;
            }

            // EVA vessel
            if (v.vesselType == VesselType.EVA)
            {
                if (v.parts == null)
                {
                    yield break;
                }

                for (int i = v.parts.Count - 1; i >= 0; i--)
                {
                    Part p = v.parts[i];
                    for (int j = p.protoModuleCrew.Count - 1; j >= 0; j--)
                    {
                        ProtoCrewMember pcm = p.protoModuleCrew[j];
                        if (!excludeKerbals.Any(k => k.pcm == pcm))
                        {
                            yield return pcm;
                        }
                    }
                }
            }
            else
            {
                // Vessel with crew
                for (int i = v.GetVesselCrew().Count - 1; i >= 0; i--)
                {
                    ProtoCrewMember pcm = v.GetVesselCrew()[i];
                    if (!excludeKerbals.Any(k => k.pcm == pcm) && (includeTourists || pcm.type == ProtoCrewMember.KerbalType.Crew))
                    {
                        yield return pcm;
                    }
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

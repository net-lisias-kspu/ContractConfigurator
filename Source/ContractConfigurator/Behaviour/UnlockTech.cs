using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using Contracts;
using ContractConfigurator;

namespace ContractConfigurator.Behaviour
{
    /// <summary>
    /// Behaviour for ulocking a tech node on contract/parameter completion/failure.
    /// Author: Klefenz
    /// </summary>
    public class UnlockTech : ContractBehaviour
    {
        protected List<string> techID;    //the tech to be unlocked

        public UnlockTech()
            : base()
        {
        }

        public UnlockTech(IEnumerable<string> techID)
        {
            this.techID = techID.ToList();
        }

        protected override void OnCompleted()
        {
            for (int i = techID.Count - 1; i >= 0; i--)
            {
                string tech = techID[i];
                UnlockTechnology(tech);
            }
        }

        protected void UnlockTechnology(string techID)
        {
            ProtoTechNode ptd = new ProtoTechNode
            {
                state = RDTech.State.Available,
                techID = techID,
                scienceCost = 9999
            };

            if (HighLogic.CurrentGame.Parameters.Difficulty.BypassEntryPurchaseAfterResearch)
            {
                ptd.partsPurchased = PartLoader.Instance.loadedParts.Where(p => p.TechRequired == techID).ToList();
            }
            else
            {
                ptd.partsPurchased = new List<AvailablePart>();
            }
                
            ResearchAndDevelopment.Instance.SetTechState(techID, ptd);
        }

        protected override void OnSave(ConfigNode configNode)
        {
            for (int i = techID.Count - 1; i >= 0; i--)
            {
                string tech = techID[i];
                configNode.AddValue("techID", tech);
            }
        }

        protected override void OnLoad(ConfigNode configNode)
        {
            techID = ConfigNodeUtil.ParseValue<List<string>>(configNode, "techID");
        }
    }
}

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
    /// Class for removing Kerbals
    /// </summary>
    public class RemoveKerbalBehaviour : ContractBehaviour
    {
        protected List<Kerbal> kerbals = new List<Kerbal>();

        public RemoveKerbalBehaviour() {}

        public RemoveKerbalBehaviour(List<Kerbal> kerbals)
        {
            this.kerbals = kerbals;
        }

        protected override void OnSave(ConfigNode node)
        {
            base.OnSave(node);

            for (int i = kerbals.Count - 1; i >= 0; i--)
            {
                Kerbal kerbal = kerbals[i];
                ConfigNode kerbalNode = new ConfigNode("KERBAL");
                node.AddNode(kerbalNode);

                kerbal.Save(kerbalNode);
            }
        }

        protected override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);

            for (int i = node.GetNodes("KERBAL").Length - 1; i >= 0; i--)
            {
                ConfigNode kerbalNode = node.GetNodes("KERBAL")[i];
                kerbals.Add(Kerbal.Load(kerbalNode));
            }
        }

        protected override void OnCompleted()
        {
            RemoveKerbals();
        }

        protected override void OnCancelled()
        {
            RemoveKerbals();
        }

        protected override void OnDeadlineExpired()
        {
            RemoveKerbals();
        }

        protected override void OnDeclined()
        {
            RemoveKerbals();
        }

        protected override void OnGenerateFailed()
        {
            RemoveKerbals();
        }

        protected override void OnOfferExpired()
        {
            RemoveKerbals();
        }

        protected override void OnWithdrawn()
        {
            RemoveKerbals();
        }

        private void RemoveKerbals()
        {
            LoggingUtil.LogDebug(this, "Removing kerbals...");

            for (int i = kerbals.Count - 1; i >= 0; i--)
            {
                Kerbal kerbal = kerbals[i];
                Kerbal.RemoveKerbal(kerbal);
            }

            kerbals.Clear();
        }
    }
}

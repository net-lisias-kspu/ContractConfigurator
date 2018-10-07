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
    /// ContractParameter that is successful when all child parameters are successful.
    /// </summary>
    public class All : ContractConfiguratorParameter
    {
        public All()
            : base(null)
        {
        }

        public All(string title)
            : base(title)
        {
        }

        protected override string GetParameterTitle()
        {
            string output = null;
            if (string.IsNullOrEmpty(title))
            {
                output = "Complete ALL of the following: ";

                if (state == ParameterState.Complete)
                {
                    bool first = true;
                    foreach (ContractParameter child in this.GetChildren())
                    {
                        if (child.State == ParameterState.Complete)
                        {
                            if (!first)
                            {
                                output += ", ";
                            }
                            output += child.Title;
                            first = false;
                        }
                    }
                }
            }
            else
            {
                output = title;
            }

            return output;
        }

        protected override string GetHashString()
        {
            return (this.Root.MissionSeed.ToString() + this.Root.DateAccepted.ToString() + this.ID);
        }

        protected override void OnParameterSave(ConfigNode node)
        {
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
        }

        protected override void OnRegister()
        {
            GameEvents.Contract.onParameterChange.Add(new EventData<Contract, ContractParameter>.OnEvent(OnAnyContractParameterChange));
            ContractConfigurator.OnParameterChange.Add(new EventData<Contract, ContractParameter>.OnEvent(OnAnyContractParameterChange));
        }

        protected override void OnUnregister()
        {
            GameEvents.Contract.onParameterChange.Remove(new EventData<Contract, ContractParameter>.OnEvent(OnAnyContractParameterChange));
            ContractConfigurator.OnParameterChange.Remove(new EventData<Contract, ContractParameter>.OnEvent(OnAnyContractParameterChange));
        }

        protected void OnAnyContractParameterChange(Contract contract, ContractParameter contractParameter)
        {
            if (contract == Root)
            {
                LoggingUtil.LogVerbose(this, "OnAnyContractParameterChange");
                if (this.GetChildren().All(p => p.State == ParameterState.Complete))
                {
                    SetState(ParameterState.Complete);
                }
                else
                {
                    SetState(ParameterState.Incomplete);
                }
            }
        }

        protected override void OnParameterStateChange(ContractParameter contractParameter)
        {
            if (System.Object.ReferenceEquals(contractParameter.Parent, this))
            {
                if (AllChildParametersComplete())
                {
                    SetState(ParameterState.Complete);
                }
                else if (AnyChildParametersFailed())
                {
                    SetState(ParameterState.Failed);
                }
            }
        }
    }
}

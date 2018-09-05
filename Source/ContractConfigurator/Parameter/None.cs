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
    /// ContractParameter that fails if any child parameters are successful.
    /// </summary>
    public class None : ContractConfiguratorParameter
    {
        public None()
            : base(null)
        {
        }

        public None(string title)
            : base(title)
        {
        }

        protected override string GetParameterTitle()
        {
            string output = string.IsNullOrEmpty(title) ? "Prevent ALL of the following" : title;
            return output;
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
                SetState(this.GetChildren().Any(p => p.State == ParameterState.Complete) ? ParameterState.Failed : ParameterState.Complete);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using KerbalKonstructs.LaunchSites;
using ContractConfigurator;

namespace KerKonConConExt
{
    public class LockBase : ContractBehaviour
    {
        public class ConditionDetail
        {
            public enum Condition
            {
                CONTRACT_ACCEPTED,
                CONTRACT_FAILED,
                CONTRACT_SUCCESS,
                CONTRACT_COMPLETED,
                PARAMETER_FAILED,
                PARAMETER_COMPLETED
            }

            public Condition condition;
            public string parameter;
            public bool disabled = false;
        }

        protected List<ConditionDetail> conditions = new List<ConditionDetail>();
        protected string basename;

        public LockBase()
            : base()
        {
        }

        public LockBase(List<ConditionDetail> conditions, string basename)
        {
            this.conditions = conditions;
            this.basename = basename;
        }

        protected override void OnParameterStateChange(ContractParameter param)
        {
            ConditionDetail.Condition cond = param.State == ParameterState.Complete ?
                ConditionDetail.Condition.PARAMETER_COMPLETED :
                ConditionDetail.Condition.PARAMETER_FAILED;
            if (param.State == ParameterState.Incomplete)
            {
                return;
            }
            LockABase(cond, param.ID, basename);
        }

        protected override void OnAccepted()
        {
            LockABase(ConditionDetail.Condition.CONTRACT_ACCEPTED, basename);
        }

        protected override void OnCompleted()
        {
            LockABase(ConditionDetail.Condition.CONTRACT_SUCCESS, basename);
            LockABase(ConditionDetail.Condition.CONTRACT_COMPLETED, basename);
        }

        protected override void OnCancelled()
        {
            LockABase(ConditionDetail.Condition.CONTRACT_FAILED, basename);
            LockABase(ConditionDetail.Condition.CONTRACT_COMPLETED, basename);
        }

        protected override void OnDeadlineExpired()
        {
            LockABase(ConditionDetail.Condition.CONTRACT_FAILED, basename);
            LockABase(ConditionDetail.Condition.CONTRACT_COMPLETED, basename);
        }

        protected override void OnFailed()
        {
            LockABase(ConditionDetail.Condition.CONTRACT_FAILED, basename);
            LockABase(ConditionDetail.Condition.CONTRACT_COMPLETED, basename);
        }

        protected override void OnLoad(ConfigNode configNode)
        {
            for (int i = configNode.GetNodes("CONDITION").Length - 1; i >= 0; i--)
            {
                ConfigNode child = configNode.GetNodes("CONDITION")[i];
                ConditionDetail cd = new ConditionDetail
                {
                    condition = ConfigNodeUtil.ParseValue<ConditionDetail.Condition>(child, "condition"),
                    parameter = ConfigNodeUtil.ParseValue<string>(child, "parameter", (string)null),
                    disabled = ConfigNodeUtil.ParseValue<bool>(child, "disabled")
                };
                conditions.Add(cd);
            }

            basename = ConfigNodeUtil.ParseValue<string>(configNode, "basename");
        }

        protected override void OnSave(ConfigNode configNode)
        {
            for (int i = conditions.Count - 1; i >= 0; i--)
            {
                ConditionDetail cd = conditions[i];
                ConfigNode child = new ConfigNode("CONDITION");
                configNode.AddNode(child);

                child.AddValue("condition", cd.condition);
                if (!string.IsNullOrEmpty(cd.parameter))
                {
                    child.AddValue("parameter", cd.parameter);
                }
                child.AddValue("disabled", cd.disabled);
            }

            configNode.AddValue("basename", basename);
        }

        protected void LockABase(ConditionDetail.Condition condition, string sbasename)
        {
            if (conditions.Any(c => c.condition == condition))
                LaunchSiteManager.setSiteLocked(sbasename);
        }

        protected void LockABase(ConditionDetail.Condition condition, string parameterID, string sbasename)
        {
            foreach (ConditionDetail cd in conditions.Where(cd => !cd.disabled && cd.condition == condition && cd.parameter == parameterID))
            {
                LaunchSiteManager.setSiteLocked(sbasename);
                cd.disabled = true;
            }
        }
    }
}
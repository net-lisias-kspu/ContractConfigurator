﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSP.UI.Screens;
using Contracts;
using ContractConfigurator;

namespace ContractConfigurator.Behaviour
{
    /// <summary>
    /// Behaviour for displaying a message box on contract/parameter completion/failure.
    /// </summary>
    public class Message : ContractBehaviour
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
        protected string title;
        protected string message;

        public Message()
            : base()
        {
        }

        public Message(List<ConditionDetail> conditions, string title, string message)
        {
            this.conditions = conditions;
            this.title = title;
            this.message = message;
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

            DisplayMessages(cond, param.ID,param.State == ParameterState.Complete ?
                MessageSystemButton.MessageButtonColor.GREEN : MessageSystemButton.MessageButtonColor.RED);
        }

        protected override void OnAccepted()
        {
            DisplayMessages(ConditionDetail.Condition.CONTRACT_ACCEPTED);
        }

        protected override void OnCompleted()
        {
            DisplayMessages(ConditionDetail.Condition.CONTRACT_SUCCESS);
            DisplayMessages(ConditionDetail.Condition.CONTRACT_COMPLETED);
        }

        protected override void OnCancelled()
        {
            DisplayMessages(ConditionDetail.Condition.CONTRACT_FAILED, MessageSystemButton.MessageButtonColor.RED);
            DisplayMessages(ConditionDetail.Condition.CONTRACT_COMPLETED);
        }

        protected override void OnDeadlineExpired()
        {
            DisplayMessages(ConditionDetail.Condition.CONTRACT_FAILED, MessageSystemButton.MessageButtonColor.RED);
            DisplayMessages(ConditionDetail.Condition.CONTRACT_COMPLETED);
        }

        protected override void OnFailed()
        {
            DisplayMessages(ConditionDetail.Condition.CONTRACT_FAILED, MessageSystemButton.MessageButtonColor.RED);
            DisplayMessages(ConditionDetail.Condition.CONTRACT_COMPLETED);
        }

        protected void DisplayMessages(ConditionDetail.Condition condition, MessageSystemButton.MessageButtonColor color = MessageSystemButton.MessageButtonColor.GREEN)
        {
            DisplayMessages(condition, "", color);
        }

        protected void DisplayMessages(ConditionDetail.Condition condition, string parameterID, MessageSystemButton.MessageButtonColor color = MessageSystemButton.MessageButtonColor.GREEN)
        {
            foreach (ConditionDetail cd in conditions.Where(cd => !cd.disabled && cd.condition == condition && cd.parameter == parameterID))
            {
                DisplayMessage(title, message, color);
                cd.disabled = true;
            }
        }

        protected void DisplayMessage(string title, string message, MessageSystemButton.MessageButtonColor color = MessageSystemButton.MessageButtonColor.GREEN)
        {
            MessageSystem.Instance.AddMessage(new MessageSystem.Message(title, message, color,
                MessageSystemButton.ButtonIcons.MESSAGE));
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

            configNode.AddValue("title", title);
            configNode.AddValue("message", message);
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

            message = ConfigNodeUtil.ParseValue<string>(configNode, "message");
            title = ConfigNodeUtil.ParseValue<string>(configNode, "title");
        }
    }
}

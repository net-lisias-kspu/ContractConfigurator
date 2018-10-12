﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Contracts;
using ContractConfigurator;

namespace ContractConfigurator.Parameters
{
    /// <summary>
    /// Base class for all Contract Configurator parameters (where possible)
    /// </summary>
    public abstract class ContractConfiguratorParameter : ContractParameter
    {
        protected string title;
        public string completedMessage;
        public string notes;
        public bool completeInSequence;
        public bool hideChildren;
        public bool hidden { get; set; }
        protected bool fakeFailures = false;
        public bool fakeOptional = false;
        private TitleTracker titleTracker;
        protected string lastTitle = null;
        public CelestialBody targetBody;

        public ContractConfiguratorParameter()
            : this(null)
        {
            titleTracker = new TitleTracker(this);
        }

        public ContractConfiguratorParameter(string title)
        {
            this.title = title;
            titleTracker = new TitleTracker(this);
        }

        protected override string GetTitle()
        {
            if (hidden)
            {
                return "";
            }
            
            if (Parent != null)
            {
                ContractConfiguratorParameter ccpParent = Parent as ContractConfiguratorParameter;
                if (ccpParent != null && ccpParent.hideChildren)
                {
                    return "";
                }
            }

            string output = (optional && !fakeOptional && string.IsNullOrEmpty(title) ? "(Optional) " : "") + GetParameterTitle();

            // Update the contract window title
            titleTracker.Add(output);
            if (lastTitle != output && Root != null && (Root.ContractState == Contract.State.Active || Root.ContractState == Contract.State.Failed))
            {
                titleTracker.UpdateContractWindow(output);
                lastTitle = output;
            }

            return output;
        }

        protected override string GetHashString()
        {
            return (Root != null ? (Root.MissionSeed.ToString() + Root.DateAccepted.ToString()) : "") + ID;
        }

        /// <summary>
        /// Override this instead of GetTitle.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetParameterTitle()
        {
            return title;
        }

        protected override string GetNotes()
        {
            return notes;
        }

        protected override string GetMessageComplete()
        {
            return string.IsNullOrEmpty(completedMessage) ? base.GetMessageComplete() : completedMessage;
        }

        protected sealed override void OnSave(ConfigNode node)
        {
            try
            {
                if (Root != null)
                {
                    node.AddValue("ContractIdentifier", Root.ToString());
                }
                node.AddValue("title", title ?? "");
                node.AddValue("notes", notes ?? "");
                node.AddValue("completedMessage", completedMessage ?? "");
                if (completeInSequence)
                {
                    node.AddValue("completeInSequence", completeInSequence);
                }
                if (hidden)
                {
                    node.AddValue("hidden", hidden);
                }
                if (hideChildren)
                {
                    node.AddValue("hideChildren", hideChildren);
                }
                if (fakeFailures)
                {
                    node.AddValue("fakeFailures", fakeFailures);
                }
                OnParameterSave(node);
            }
            catch (Exception e)
            {
                LoggingUtil.LogException(e);
                ExceptionLogWindow.DisplayFatalException(ExceptionLogWindow.ExceptionSituation.PARAMETER_SAVE, e, Root.ToString(), ID);
            }
        }

        /// <summary>
        /// Hides the contract parameter.
        /// </summary>
        public void Hide()
        {
            hidden = true;
        }

        /// <summary>
        /// Use this instead of OnSave.
        /// </summary>
        /// <param name="node">The ConfigNode to save to.</param>
        protected abstract void OnParameterSave(ConfigNode node);

        protected sealed override void OnLoad(ConfigNode node)
        {
            try
            {
                title = ConfigNodeUtil.ParseValue<string>(node, "title", "");
                notes = ConfigNodeUtil.ParseValue<string>(node, "notes", "");
                completedMessage = ConfigNodeUtil.ParseValue<string>(node, "completedMessage", "");
                hidden = ConfigNodeUtil.ParseValue<bool?>(node, "hidden", (bool?)false).Value;
                hideChildren = ConfigNodeUtil.ParseValue<bool?>(node, "hideChildren", (bool?)false).Value;
                completeInSequence = ConfigNodeUtil.ParseValue<bool?>(node, "completeInSequence", (bool?)false).Value;
                fakeFailures = ConfigNodeUtil.ParseValue<bool?>(node, "fakeFailures", (bool?)false).Value;
                OnParameterLoad(node);
            }
            catch (Exception e)
            {
                string contractName = "unknown";
                try
                {
                    contractName = ConfigNodeUtil.ParseValue<string>(node, "ContractIdentifier");
                }
                catch { }
                LoggingUtil.LogException(e);
                ExceptionLogWindow.DisplayFatalException(ExceptionLogWindow.ExceptionSituation.PARAMETER_LOAD, e, contractName, ID);
            }
        }

        /// <summary>
        /// Use this instead of OnLoad.
        /// </summary>
        /// <param name="node">The ConfigNode to laod from.</param>
        protected abstract void OnParameterLoad(ConfigNode node);

        /// <summary>
        /// Checks if this parameter is ready to complete.  If the completeInSequence flag is set,
        /// it will check if all previous parameters in the sequence have been completed.
        /// </summary>
        /// <returns>True if the parameter is ready to complete.</returns>
        protected bool ReadyToComplete()
        {
            if (completeInSequence || Parent is Sequence)
            {
                // Go through the parent's parameters
                for (int i = 0; i < Parent.ParameterCount; i++)
                {
                    ContractParameter param = Parent.GetParameter(i);
                    // If we've made it all the way to us, we're ready
                    if (System.Object.ReferenceEquals(param, this))
                    {
                        // Passed our check
                        break;
                    }

                    if (param.State != ParameterState.Complete)
                        return false;
                }
            }

            // Special handling for the Duration parameter ideally shouldn't be here - someday I'll refactor this
            foreach (ContractParameter child in this.GetChildren())
            {
                Duration duration = child as Duration;
                if (duration != null)
                {
                    if (duration.state != ParameterState.Complete)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Method to use in place of SetComplete/SetFailed/SetIncomplete.  Doesn't fire the stock change event because of 
        /// performance issues with the stock contracts app.
        /// </summary>
        /// <param name="state">New parameter state</param>
        public virtual void SetState(ParameterState state)
        {
            // State already set, or parameter disabled
            if (this.state == state || !enabled)
            {
                return;
            }

            // Check if the transition is allowed
            if (state == ParameterState.Complete && !ReadyToComplete())
            {
                return;
            }

            this.state = state;

            if (disableOnStateChange)
            {
                Disable();
            }

            if (state == ParameterState.Complete)
            {
                AwardCompletion();
            }
            else if (state == ParameterState.Failed && !fakeFailures)
            {
                PenalizeFailure();
            }

            if (!fakeFailures || state != ParameterState.Failed)
            {
                OnStateChange.Fire(this, state);
                ContractConfigurator.OnParameterChange.Fire(Root, this);
                Parent.ParameterStateUpdate(this);
            }
        }

        /// <summary>
        /// Replacement for stock AllChildParametersComplete which considers child parameters.
        /// </summary>
        /// <returns>Whether all non-optional parameters are complete.</returns>
        new public bool AllChildParametersComplete()
        {
            foreach (ContractParameter param in this.GetChildren())
            {
                if (param.State != ParameterState.Complete && !param.Optional)
                {
                    return false;
                }
            }
            return true;
        }

        [Obsolete("Use SetState() instead.")]
        new protected void SetComplete()
        {
            base.SetComplete();
        }

        [Obsolete("Use SetState() instead.")]
        new protected void SetFailed()
        {
            base.SetFailed();
        }

        [Obsolete("Use SetState() instead.")]
        new protected void SetIncomplete()
        {
            base.SetIncomplete();
        }

        public new bool AnyChildParametersFailed()
        {
            for (int i = ParameterCount; i-- > 0;)
            {
                ContractParameter param = GetParameter(i);
                ContractConfiguratorParameter ccParam = param as ContractConfiguratorParameter;
                if (param.State == ParameterState.Failed && (ccParam == null || !ccParam.fakeFailures))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using KSP;
using Contracts;
using Contracts.Parameters;
using FinePrint;

namespace ContractConfigurator.Parameters
{
    /// <summary>
    /// Parameter for checking whether the parts in a vessel meet certain criteria.
    /// </summary>
    public class PartValidation : VesselParameter
    {
        public class Filter
        {
            public ParameterDelegateMatchType type = ParameterDelegateMatchType.FILTER;
            public List<AvailablePart> parts = new List<AvailablePart>();
            public List<string> partModules = new List<string>();
            public List<string> partModuleTypes = new List<string>();
            public List<ConfigNode.ValueList> partModuleExtended = new List<ConfigNode.ValueList>();
            public PartCategories? category = null;
            public string manufacturer = null;
            public int minCount = 1;
            public int maxCount = int.MaxValue;

            public Filter() { }
            public Filter(ParameterDelegateMatchType type) { this.type = type; }
        }

        protected List<Filter> filters { get; set; }
        protected int minCount { get; set; }
        protected int maxCount { get; set; }

        public PartValidation()
            : base(null)
        {
        }

        public PartValidation(List<Filter> filters, int minCount = 1, int maxCount = int.MaxValue, string title = null)
            : base(title)
        {
            this.filters = filters;
            this.minCount = minCount;
            this.maxCount = maxCount;

            CreateDelegates();
        }

        protected override string GetParameterTitle()
        {
            string output = null;
            if (string.IsNullOrEmpty(title))
            {
                output = "Parts";
                if (state == ParameterState.Complete)
                {
                    output += ": ";
                    if (maxCount == int.MaxValue && minCount != 1)
                    {
                        output += "At least " + minCount + " ";
                    }
                    else if (maxCount != int.MaxValue && minCount == 1)
                    {
                        output += "At most " + maxCount + " ";
                    }
                    output += ParameterDelegate<Part>.GetDelegateText(this);
                }
            }
            else
            {
                output = title;
            }
            return output;
        }

        protected void CreateDelegates()
        {
            foreach (Filter filter in filters)
            {
                if (filter.type == ParameterDelegateMatchType.VALIDATE)
                {
                    foreach (AvailablePart part in filter.parts)
                    {
                        AddParameter(new CountParameterDelegate<Part>(filter.minCount, filter.maxCount, p => p.partInfo.name == part.name,
                            part.title, false));
                    }

                    // Filter by part modules
                    foreach (string partModule in filter.partModules)
                    {
                        AddParameter(new CountParameterDelegate<Part>(filter.minCount, filter.maxCount, p => PartHasModule(p, partModule),
                            "with module: " + ModuleName(partModule), false));
                    }

                    // Filter by part module types
                    foreach (string partModuleType in filter.partModuleTypes)
                    {
                        AddParameter(new CountParameterDelegate<Part>(filter.minCount, filter.maxCount, p => PartHasObjective(p, partModuleType),
                            "with module type: " + partModuleType, false));
                    }
                }
                else
                {
                    // Filter by part
                    if (filter.parts.Any())
                    {
                        AddParameter(new ParameterDelegate<Part>(filter.type.Prefix() + "type: " +
                            filter.parts.Select(p => p.title).Aggregate((sum, s) => sum + " or " + s),
                            p => filter.parts.Any(pp => p.partInfo.name == pp.name), filter.type));
                    }

                    // Filter by part modules
                    foreach (string partModule in filter.partModules)
                    {
                        AddParameter(new ParameterDelegate<Part>(filter.type.Prefix() + "module: " + ModuleName(partModule), p => PartHasModule(p, partModule), filter.type));
                    }

                    // Filter by part modules
                    foreach (string partModuleType in filter.partModuleTypes)
                    {
                        AddParameter(new ParameterDelegate<Part>(filter.type.Prefix() + "module type: " + partModuleType, p => PartHasObjective(p, partModuleType), filter.type));
                    }

                    // Filter by part modules - extended mode
                    foreach (ConfigNode.ValueList list in filter.partModuleExtended)
                    {
                        ContractParameter wrapperParam = AddParameter(new AllParameterDelegate<Part>(filter.type.Prefix() + "module", filter.type));

                        foreach (ConfigNode.Value v in list)
                        {
                            string name = Regex.Replace(v.name, @"([A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", " $1");
                            name = name.Substring(0, 1).ToUpper() + name.Substring(1);
                            string value = v.name == "name" ? ModuleName(v.value) : v.value;

                            ParameterDelegateMatchType childFilter = ParameterDelegateMatchType.FILTER;
                            wrapperParam.AddParameter(new ParameterDelegate<Part>(childFilter.Prefix() + name + ": " + value, p => PartModuleCheck(p, v), childFilter));
                        }
                    }

                    // Filter by category
                    if (filter.category != null)
                    {
                        AddParameter(new ParameterDelegate<Part>(filter.type.Prefix() + "category: " + filter.category,
                            p => p.partInfo.category == filter.category.Value, filter.type));
                    }

                    // Filter by manufacturer
                    if (filter.manufacturer != null)
                    {
                        AddParameter(new ParameterDelegate<Part>(filter.type.Prefix() + "manufacturer: " + filter.manufacturer,
                            p => p.partInfo.manufacturer == filter.manufacturer, filter.type));
                    }
                }
            }

            // Validate count
            if (minCount != 0 || maxCount != int.MaxValue && !(minCount == maxCount && maxCount == 0))
            {
                AddParameter(new CountParameterDelegate<Part>(minCount, maxCount));
            }
        }

        public static string ModuleName(string partModule)
        {
            string output = partModule.Replace("Module", "").Replace("FX", "");

            // Hardcoded special values
            if (output == "SAS")
            {
                return output;
            }
            else if (output == "RTAntenna")
            {
                return "Antenna";
            }
            else if (output.Contains("Wheel"))
            {
                return "Wheel";
            }

            return Regex.Replace(output, "(\\B[A-Z])", " $1");
        }

        private bool PartHasModule(Part p, string partModule)
        {
            foreach (PartModule pm in p.Modules)
            {
                if (pm.moduleName.StartsWith(partModule) || pm.GetType().BaseType.Name.StartsWith(partModule))
                {
                    return true;
                }
            }
            return false;
        }

        private bool PartHasObjective(Part p, string contractObjective)
        {
            return p.HasValidContractObjective(contractObjective);
        }

        private bool PartModuleCheck(Part p, ConfigNode.Value v)
        {
            foreach (PartModule pm in p.Modules)
            {
                if (v.name == "name")
                {
                    if (pm.moduleName == v.value)
                    {
                        return true;
                    }
                }
                else if (v.name == "EngineType")
                {
                    ModuleEngines me = pm as ModuleEngines;
                    return me != null && me.engineType.ToString() == v.value;
                }

                foreach (BaseField field in pm.Fields)
                {
                    if (field != null && field.name == v.name && field.originalValue != null && field.originalValue.ToString() == v.value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected override void OnRegister()
        {
            base.OnRegister();
            GameEvents.onVesselWasModified.Add(new EventData<Vessel>.OnEvent(OnVesselWasModified));
        }

        protected override void OnUnregister()
        {
            base.OnUnregister();
            GameEvents.onVesselWasModified.Remove(new EventData<Vessel>.OnEvent(OnVesselWasModified));
        }

        protected void OnVesselWasModified(Vessel v)
        {
            CheckVessel(v);
        }

        protected override void OnParameterSave(ConfigNode node)
        {
            base.OnParameterSave(node);
            node.AddValue("minCount", minCount);
            node.AddValue("maxCount", maxCount);

            foreach (Filter filter in filters)
            {
                ConfigNode child = new ConfigNode("FILTER");
                child.AddValue("type", filter.type);

                foreach (AvailablePart part in filter.parts)
                {
                    child.AddValue("part", part.name);
                }
                foreach (string partModule in filter.partModules)
                {
                    child.AddValue("partModule", partModule);
                }
                foreach (string partModuleType in filter.partModuleTypes)
                {
                    child.AddValue("partModuleType", partModuleType);
                }
                foreach (ConfigNode.ValueList list in filter.partModuleExtended)
                {
                    ConfigNode moduleNode = new ConfigNode("MODULE");
                    child.AddNode(moduleNode);

                    foreach (ConfigNode.Value v in list)
                    {
                        moduleNode.AddValue(v.name, v.value);
                    }
                }
                if (filter.category != null)
                {
                    child.AddValue("category", filter.category);
                }
                if (filter.manufacturer != null)
                {
                    child.AddValue("manufacturer", filter.manufacturer);
                }
                if (filter.type == ParameterDelegateMatchType.VALIDATE)
                {
                    child.AddValue("minCount", filter.minCount);
                    child.AddValue("maxCount", filter.maxCount);
                }

                node.AddNode(child);
            }
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
            try
            {
                base.OnParameterLoad(node);
                minCount = Convert.ToInt32(node.GetValue("minCount"));
                maxCount = Convert.ToInt32(node.GetValue("maxCount"));

                filters = new List<Filter>();

                foreach (ConfigNode child in node.GetNodes("FILTER"))
                {
                    Filter filter = new Filter();
                    filter.type = ConfigNodeUtil.ParseValue<ParameterDelegateMatchType>(child, "type");

                    filter.parts = ConfigNodeUtil.ParseValue<List<AvailablePart>>(child, "part", new List<AvailablePart>());
                    filter.partModules = child.GetValues("partModule").ToList();
                    filter.partModuleTypes = child.GetValues("partModuleType").ToList();
                    filter.category = ConfigNodeUtil.ParseValue<PartCategories?>(child, "category", (PartCategories?)null);
                    filter.manufacturer = ConfigNodeUtil.ParseValue<string>(child, "manufacturer", (string)null);
                    filter.minCount = ConfigNodeUtil.ParseValue<int>(child, "minCount", 1);
                    filter.maxCount = ConfigNodeUtil.ParseValue<int>(child, "maxCount", int.MaxValue);

                    foreach (ConfigNode moduleNode in child.GetNodes("MODULE"))
                    {
                        ConfigNode.ValueList tmp = new ConfigNode.ValueList();
                        foreach (ConfigNode.Value v in moduleNode.values)
                        {
                            tmp.Add(new ConfigNode.Value(v.name, v.value));
                        }
                        filter.partModuleExtended.Add(tmp);
                    }

                    filters.Add(filter);
                }

                CreateDelegates();
            }
            finally
            {
                ParameterDelegate<Part>.OnDelegateContainerLoad(node);
            }
        }

        protected override void OnPartAttach(GameEvents.HostTargetAction<Part, Part> e)
        {
            base.OnPartAttach(e);
            CheckVessel(FlightGlobals.ActiveVessel);
        }

        protected override void OnPartJointBreak(PartJoint p, float breakForce)
        {
            base.OnPartJointBreak(p, breakForce);
            CheckVessel(FlightGlobals.ActiveVessel);
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

            return ParameterDelegate<Part>.CheckChildConditions(this, vessel.parts, checkOnly);
        }
    }
}

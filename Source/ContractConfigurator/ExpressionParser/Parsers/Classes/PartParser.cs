﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ContractConfigurator.ExpressionParser
{
    /// <summary>
    /// Expression parser subclass for Part (AvailablePart).
    /// </summary>
    public class PartParser : ClassExpressionParser<AvailablePart>, IExpressionParserRegistrer
    {
        static PartParser()
        {
            RegisterMethods();
        }

        public void RegisterExpressionParsers()
        {
            RegisterParserType(typeof(AvailablePart), typeof(PartParser));
        }

        public static void RegisterMethods()
        {
            RegisterMethod(new Method<AvailablePart, PartCategories>("Category", p => p == null ? 0 : p.category));
            RegisterMethod(new Method<AvailablePart, float>("Cost", p => p == null ? 0.0f : p.cost));
            RegisterMethod(new Method<AvailablePart, string>("Description", p => p == null ? "" : p.description));
            RegisterMethod(new Method<AvailablePart, string>("Manufacturer", p => p == null ? "" : p.manufacturer));
            RegisterMethod(new Method<AvailablePart, float>("Size", p => p == null ? 0.0f : p.partSize));
            RegisterMethod(new Method<AvailablePart, float>("Mass", p => p == null ? 0.0f : p.partPrefab.mass));
            RegisterMethod(new Method<AvailablePart, float>("MassWet", p => p == null ? 0.0f : p.partPrefab.mass + p.partPrefab.GetResourceMass()));
            RegisterMethod(new Method<AvailablePart, Tech>("TechRequired", p => p == null ? null : Tech.GetTech(p.TechRequired)));
            RegisterMethod(new Method<AvailablePart, int>("UnlockCost", p => p == null ? 0 : p.entryCost));
            RegisterMethod(new Method<AvailablePart, bool>("IsUnlocked", p => p != null && ResearchAndDevelopment.PartModelPurchased(p), false));
            RegisterMethod(new Method<AvailablePart, int>("CrewCapacity", p => p == null ? 0 : p.partPrefab.CrewCapacity));

            RegisterMethod(new Method<AvailablePart, List<Resource>>("Resources", ResourceList));
            RegisterMethod(new Method<AvailablePart, Resource, double>("ResourceCapacity", ResourceCapacity));

            RegisterMethod(new Method<AvailablePart, float>("EngineAtmosphereThrust", GetEngineAtmoThrust));
            RegisterMethod(new Method<AvailablePart, float>("EngineVacuumThrust", GetEngineVacThrust));
            RegisterMethod(new Method<AvailablePart, float>("EngineAtmosphereISP", GetEngineAtmoISP));
            RegisterMethod(new Method<AvailablePart, float>("EngineVacuumISP", GetEngineVacISP));

            RegisterGlobalFunction(new Function<List<AvailablePart>>("AllParts", AllParts));
            RegisterGlobalFunction(new Function<AvailablePart, AvailablePart>("AvailablePart", p => p));
        }

        public PartParser()
        {
        }

        public static List<AvailablePart> AllParts()
        {
            return PartLoader.Instance.loadedParts.Where(p => !p.name.StartsWith("kerbalEVA") && p.name != "flag").ToList();
        }

        public override U ConvertType<U>(AvailablePart value)
        {
            return typeof(U) == typeof(string) ? (U)(object)(value == null ? "" : value.title) : base.ConvertType<U>(value);
        }

        public override Token ParseNumericConstant()
        {
            // Parse as an identifier
            Token t = new Token(TokenType.IDENTIFIER);
            t.sval = "";
            return t;
        }

        private static List<Resource> ResourceList(AvailablePart p)
        {
            if (p == null)
            {
                return null;
            }

            List<Resource> resources = new List<Resource>();
            for (int i = p.partPrefab.Resources.Count - 1; i >= 0; i--)
            {
                PartResource r = p.partPrefab.Resources[i];
                var enumerator = PartResourceLibrary.Instance.resourceDefinitions.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.name == r.resourceName)
                        {
                            resources.Add(new Resource(enumerator.Current));
                            break;
                        }
                    }
                }
                finally
                {
                    enumerator.Dispose();
                }
            }

            return resources;
        }

        private static double ResourceCapacity(AvailablePart p, Resource r)
        {
            if (p == null || r == null)
            {
                return 0.0f;
            }

            for (int i = p.partPrefab.Resources.Count - 1; i >= 0; i--)
            {
                PartResource pr = p.partPrefab.Resources[i];
                if (pr.resourceName == r.res.name)
                {
                    return pr.maxAmount;
                }
            }

            return 0.0f;
        }

        private static float GetEngineVacThrust(AvailablePart p)
        {
            if (p == null)
            {
                return 0.0f;
            }

            for (int i = p.partPrefab.Modules.Count - 1; i >= 0; i--)
            {
                PartModule pm = p.partPrefab.Modules[i];
                if (pm.moduleName != null && pm.moduleName.StartsWith("ModuleEngines"))
                {
                    ModuleEngines enginePM = pm as ModuleEngines;
                    return enginePM.maxThrust;
                }
            }

            return 0.0f;
        }

        private static float GetEngineAtmoThrust(AvailablePart p)
        {
            if (p == null)
            {
                return 0.0f;
            }

            for (int i = p.partPrefab.Modules.Count - 1; i >= 0; i--)
            {
                PartModule pm = p.partPrefab.Modules[i];
                if (pm.moduleName != null && pm.moduleName.StartsWith("ModuleEngines"))
                {
                    ModuleEngines enginePM = pm as ModuleEngines;
                    return enginePM.maxThrust * enginePM.atmosphereCurve.Evaluate(1) / enginePM.atmosphereCurve.Evaluate(0);
                }
            }

            return 0.0f;
        }

        private static float GetEngineVacISP(AvailablePart p)
        {
            if (p == null)
            {
                return 0.0f;
            }

            for (int i = p.partPrefab.Modules.Count - 1; i >= 0; i--)
            {
                PartModule pm = p.partPrefab.Modules[i];
                if (pm.moduleName != null && pm.moduleName.StartsWith("ModuleEngines"))
                {
                    ModuleEngines enginePM = pm as ModuleEngines;
                    return enginePM.atmosphereCurve.Evaluate(0);
                }
            }

            return 0.0f;
        }

        private static float GetEngineAtmoISP(AvailablePart p)
        {
            if (p == null)
            {
                return 0.0f;
            }

            for (int i = p.partPrefab.Modules.Count - 1; i >= 0; i--)
            {
                PartModule pm = p.partPrefab.Modules[i];
                if (pm.moduleName != null && pm.moduleName.StartsWith("ModuleEngines"))
                {
                    ModuleEngines enginePM = pm as ModuleEngines;
                    return enginePM.atmosphereCurve.Evaluate(1);
                }
            }

            return 0.0f;
        }

        public override AvailablePart ParseIdentifier(Token token)
        {
            // Try to parse more, as part names can have spaces and other weird characters
            Match m = Regex.Match(expression, @"^((?>\s*[\w\d-\.]+)+).*");
            string identifier = m.Groups[1].Value;
            expression = (expression.Length > identifier.Length ? expression.Substring(identifier.Length) : "");
            identifier = token.sval + identifier;

            // Underscores in part names get replaced with spaces.  Nobody knows why.
            string partName = identifier.Replace('_', '.');

            if (identifier.Equals("null", StringComparison.CurrentCultureIgnoreCase))
            {
                return null;
            }

            // Get the part
            AvailablePart part = PartLoader.getPartInfoByName(partName);
            if (part == null)
            {
                throw new ArgumentException("'" + identifier + "' is not a valid Part.");
            }

            return part;
        }
    }
}

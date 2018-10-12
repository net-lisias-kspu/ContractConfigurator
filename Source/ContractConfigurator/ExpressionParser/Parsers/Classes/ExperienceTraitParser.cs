﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using Experience;

namespace ContractConfigurator.ExpressionParser
{
    /// <summary>
    /// Expression parser subclass for ExperienceTrait.
    /// </summary>
    public class ExperienceTraitParser : ClassExpressionParser<ExperienceTrait>, IExpressionParserRegistrer
    {
        static ExperienceTraitParser()
        {
            RegisterMethods();
        }

        public void RegisterExpressionParsers()
        {
            RegisterParserType(typeof(ExperienceTrait), typeof(ExperienceTraitParser));
        }

        public static void RegisterMethods()
        {
            RegisterGlobalFunction(new Function<List<ExperienceTrait>>("AllExperienceTraits", () => HighLogic.CurrentGame == null ? new List<ExperienceTrait>() :
                GameDatabase.Instance.ExperienceConfigs.Categories.Select<ExperienceTraitConfig, ExperienceTrait>(etc => 
                    ExperienceTrait.Create(KerbalRoster.GetExperienceTraitType(etc.Name) ?? typeof(ExperienceTrait), etc, null)
                ).ToList(), false));
            RegisterGlobalFunction(new Function<List<ExperienceTrait>>("AllExperienceTraitsNoTourist", () => HighLogic.CurrentGame == null ? new List<ExperienceTrait>() :
                GameDatabase.Instance.ExperienceConfigs.Categories.Where(etc => etc.Name != "Tourist").Select<ExperienceTraitConfig, ExperienceTrait>(etc =>
                    ExperienceTrait.Create(KerbalRoster.GetExperienceTraitType(etc.Name) ?? typeof(ExperienceTrait), etc, null)
                ).ToList(), false));
            RegisterGlobalFunction(new Function<ExperienceTrait, ExperienceTrait>("ExperienceTrait", k => k));
        }

        public ExperienceTraitParser()
        {
        }

        public override U ConvertType<U>(ExperienceTrait value)
        {
            return typeof(U) == typeof(string) ? (U)(object)(value == null ? "" : value.Title) : base.ConvertType<U>(value);
        }

        public override bool ConvertableFrom(Type type)
        {
            return type == typeof(string);
        }

        public override ExperienceTrait ConvertFrom<U>(U value)
        {
            LoggingUtil.LogDebug(this, StringBuilderCache.Format("ExperienceTraitParser.ConvertFrom<{0}>({1}", typeof(U), value));
            if (typeof(U) == typeof(string))
            {
                string sVal = (string)(object)value;

                if (HighLogic.CurrentGame == null)
                {
                    currentDataNode.SetDeterministic(currentKey, false);
                    return null;
                }

                for (int index = 0; index < GameDatabase.Instance.ExperienceConfigs.Categories.Count; ++index)
                {
                    if (sVal == GameDatabase.Instance.ExperienceConfigs.Categories[index].Name)
                    {
                        Type type = KerbalRoster.GetExperienceTraitType(sVal) ?? typeof(ExperienceTrait);
                        return ExperienceTrait.Create(type, GameDatabase.Instance.ExperienceConfigs.Categories[index], null);
                    }
                }

                throw new ArgumentException("'" + sVal + "' is not a valid experience trait.");
            }
            throw new DataStoreCastException(typeof(U), typeof(ExperienceTrait));
        }

        public override bool EQ(ExperienceTrait a, ExperienceTrait b)
        {
			if (null == a || null == b) return false;
            return base.EQ(a, b) ? true : a.TypeName == b.TypeName;
        }

        public override ExperienceTrait ParseIdentifier(Token token)
        {
            // Try to parse more, as ExperienceTrait names can have spaces
            Match m = Regex.Match(expression, @"^((?>\s*[\w\d]+)+).*");
            string identifier = m.Groups[1].Value;
            expression = (expression.Length > identifier.Length ? expression.Substring(identifier.Length) : "");
            identifier = token.sval + identifier;

            if (identifier.Equals("null", StringComparison.CurrentCultureIgnoreCase))
            {
                return null;
            }

            if (HighLogic.CurrentGame == null)
            {
                currentDataNode.SetDeterministic(currentKey, false);
                return null;
            }

            for (int index = 0; index < GameDatabase.Instance.ExperienceConfigs.Categories.Count; ++index)
            {
                if (identifier == GameDatabase.Instance.ExperienceConfigs.Categories[index].Name)
                {
                    Type type = KerbalRoster.GetExperienceTraitType(identifier) ?? typeof(ExperienceTrait);
                    return ExperienceTrait.Create(type, GameDatabase.Instance.ExperienceConfigs.Categories[index], null);
                }
            }

            LoggingUtil.LogError(this, StringBuilderCache.Format("Unknown experience trait '{0}'.", identifier));
            return null;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ContractConfigurator.ExpressionParser
{
    /// <summary>
    /// Expression parser subclass for Kerbal (ProtoCrewMember).
    /// </summary>
    public class KerbalParser : ClassExpressionParser<Kerbal>, IExpressionParserRegistrer
    {
        static KerbalParser()
        {
            RegisterMethods();
        }

        public void RegisterExpressionParsers()
        {
            RegisterParserType(typeof(Kerbal), typeof(KerbalParser));
        }

        public static void RegisterMethods()
        {
            RegisterMethod(new Method<Kerbal, float>("Experience", k => k == null ? 0.0f : k.experience));
            RegisterMethod(new Method<Kerbal, int>("ExperienceLevel", k => k == null ? 0 : k.experienceLevel));
            RegisterMethod(new Method<Kerbal, Experience.ExperienceTrait>("ExperienceTrait", k => k == null ? null : k.pcm.experienceTrait));
            RegisterMethod(new Method<Kerbal, ProtoCrewMember.RosterStatus>("RosterStatus", k => k == null ? ProtoCrewMember.RosterStatus.Dead : k.rosterStatus));
            RegisterMethod(new Method<Kerbal, ProtoCrewMember.KerbalType>("Type", k => k == null ? ProtoCrewMember.KerbalType.Applicant : k.kerbalType));
            RegisterMethod(new Method<Kerbal, ProtoCrewMember.Gender>("Gender", k => k == null ? ProtoCrewMember.Gender.Male : k.gender));

            RegisterGlobalFunction(new Function<List<Kerbal>>("AllKerbals", () => HighLogic.CurrentGame == null ? new List<Kerbal>() :
                HighLogic.CurrentGame.CrewRoster.AllKerbals().Select<ProtoCrewMember, Kerbal>(pcm => new Kerbal(pcm)).ToList(), false));
            RegisterGlobalFunction(new Function<Kerbal, Kerbal>("Kerbal", k => k));

            RegisterGlobalFunction(new Function<ProtoCrewMember.Gender, string>("RandomKerbalName", g => Kerbal.KerbalName(g), false));

            RegisterGlobalFunction(new Function<Kerbal>("NewKerbal", () => new Kerbal(), false));
            RegisterGlobalFunction(new Function<ProtoCrewMember.Gender, Kerbal>("NewKerbal", (g) => new Kerbal(g), false));
            RegisterGlobalFunction(new Function<ProtoCrewMember.Gender, string, Kerbal>("NewKerbal", (g, n) => new Kerbal(g, n), false));
            RegisterGlobalFunction(new Function<string, Kerbal>("NewKerbalWithTrait", NewKerbal, false));
            RegisterGlobalFunction(new Function<ProtoCrewMember.Gender, string, string, Kerbal>("NewKerbal", (g, n, t) => new Kerbal(g, n, t), false));

            RegisterGlobalFunction(new Function<int, List<Kerbal>>("NewKerbals", NewKerbals, false));
            RegisterGlobalFunction(new Function<int, string, List<Kerbal>>("NewKerbals", NewKerbals, false));

            RegisterGlobalFunction(new Function<float>("NextKerbalHireCost", NextKerbalHireCost, false));
        }

        public KerbalParser()
        {
        }

        private static List<Kerbal> NewKerbals(int count)
        {
            List<Kerbal> kerbals = new List<Kerbal>();
            for (int i = 0; i < count; i++)
            {
                kerbals.Add(new Kerbal());
            }
            return kerbals;
        }

        private static List<Kerbal> NewKerbals(int count, string trait)
        {
            List<Kerbal> kerbals = new List<Kerbal>();
            for (int i = 0; i < count; i++)
            {
                Kerbal k = new Kerbal();
                k.experienceTrait = trait;
                kerbals.Add(k);
            }
            return kerbals;
        }

        public override U ConvertType<U>(Kerbal value)
        {
            if (typeof(U) == typeof(string))
            {
                return (U)(object)(value == null ? "" : value.ToString());
            }
            return base.ConvertType<U>(value);
        }

        static Kerbal NewKerbal(string trait)
        {
            Kerbal k = new Kerbal();
            k.experienceTrait = trait;
            return k;
        }

        private static float NextKerbalHireCost()
        {
            if (GameVariables.Instance == null || HighLogic.CurrentGame == null)
            {
                return 1.0f;
            }

            CurrencyModifierQuery currencyModifierQuery = CurrencyModifierQuery.RunQuery(TransactionReasons.CrewRecruited, -GameVariables.Instance.GetRecruitHireCost(HighLogic.CurrentGame.CrewRoster.GetActiveCrewCount()) *
                HighLogic.CurrentGame.Parameters.Career.FundsLossMultiplier, 0.0f, 0.0f);
            return -(currencyModifierQuery.GetInput(Currency.Funds) + currencyModifierQuery.GetEffectDelta(Currency.Funds));
        }

        public override Kerbal ParseIdentifier(Token token)
        {
            // Try to parse more, as Kerbal names can have spaces
            Match m = Regex.Match(expression, @"^((?>\s*[\w\d]+)+).*");
            string identifier = m.Groups[1].Value;
            expression = (expression.Length > identifier.Length ? expression.Substring(identifier.Length) : "");
            identifier = token.sval + identifier;

            if (identifier.Equals("null", StringComparison.CurrentCultureIgnoreCase))
            {
                return null;
            }

            return new Kerbal(identifier);
        }
    }
}

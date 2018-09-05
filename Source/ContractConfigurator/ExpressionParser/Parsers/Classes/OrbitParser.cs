using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ContractConfigurator.ExpressionParser
{
    /// <summary>
    /// Expression parser subclass for Orbit.
    /// </summary>
    public class OrbitParser : ClassExpressionParser<Orbit>, IExpressionParserRegistrer
    {
        static OrbitParser()
        {
            RegisterMethods();
        }

        public void RegisterExpressionParsers()
        {
            RegisterParserType(typeof(Orbit), typeof(OrbitParser));
        }

        public static void RegisterMethods()
        {
            RegisterLocalFunction(new Function<List<double>, int, Orbit>("CreateOrbit", CreateOrbit));

            RegisterMethod(new Method<Orbit, double>("Apoapsis", GetApA, false));
            RegisterMethod(new Method<Orbit, double>("Periapsis", GetPeA, false));
            RegisterMethod(new Method<Orbit, double>("Inclination", GetInclination, false));
            RegisterMethod(new Method<Orbit, double>("Eccentricity", GetEccentricity, false));
            RegisterMethod(new Method<Orbit, double>("LAN", GetLAN, false));
            RegisterMethod(new Method<Orbit, double>("Period", GetPeriod, false));

            RegisterGlobalFunction(new Function<Orbit, Orbit>("Orbit", o => o));
        }

        public OrbitParser()
        {
        }

        protected static Orbit CreateOrbit(List<double> dVals, int refVal)
        {
            ConfigNode orbitNode = new ConfigNode("ORBIT");

            orbitNode.AddValue("SMA", dVals[0]);
            orbitNode.AddValue("ECC", dVals[1]);
            orbitNode.AddValue("INC", dVals[2]);
            orbitNode.AddValue("LPE", dVals[3]);
            orbitNode.AddValue("LAN", dVals[4]);
            orbitNode.AddValue("MNA", dVals[5]);
            orbitNode.AddValue("EPH", dVals[6]);
            orbitNode.AddValue("REF", refVal);

            return new OrbitSnapshot(orbitNode).Load();
        }

        static double GetApA(Orbit orbit)
        {
            return orbit == null ? 0.0 : orbit.ApA;
        }

        static double GetPeA(Orbit orbit)
        {
            return orbit == null ? 0.0 : orbit.PeA;
        }

        static double GetInclination(Orbit orbit)
        {
            return orbit == null ? 0.0 : orbit.inclination;
        }

        static double GetEccentricity(Orbit orbit)
        {
            return orbit == null ? 0.0 : orbit.eccentricity;
        }

        static double GetLAN(Orbit orbit)
        {
            return orbit == null ? 0.0 : orbit.LAN;
        }

        static double GetPeriod(Orbit orbit)
        {
            return orbit == null ? 0.0 : orbit.period;
        }
    }
}

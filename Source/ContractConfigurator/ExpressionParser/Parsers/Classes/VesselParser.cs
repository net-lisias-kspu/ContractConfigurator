﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ContractConfigurator.ExpressionParser
{
    /// <summary>
    /// Expression parser subclass for Vessel.
    /// </summary>
    public class VesselParser : ClassExpressionParser<Vessel>, IExpressionParserRegistrer
    {
        static VesselParser()
        {
            RegisterMethods();
        }

        public void RegisterExpressionParsers()
        {
            RegisterParserType(typeof(Vessel), typeof(VesselParser));
        }

        public static void RegisterMethods()
        {
            RegisterMethod(new Method<Vessel, bool>("IsLanded", v => v != null && v.Landed, false));
            RegisterMethod(new Method<Vessel, bool>("IsSplashed", v => v != null && v.Splashed, false));
            RegisterMethod(new Method<Vessel, bool>("IsOrbiting", v => v != null && !v.LandedOrSplashed, false));

            RegisterMethod(new Method<Vessel, List<Kerbal>>("Crew", v => v == null ? new List<Kerbal>() : v.GetVesselCrew().
                Select<ProtoCrewMember, Kerbal>(pcm => new Kerbal(pcm)).ToList(), false));
            RegisterMethod(new Method<Vessel, List<AvailablePart>>("Parts", PartList, false));

            RegisterMethod(new Method<Vessel, CelestialBody>("CelestialBody", v => v == null ? null : v.mainBody, false));
            RegisterMethod(new Method<Vessel, VesselType>("VesselType", v => v == null ? VesselType.Unknown : v.vesselType, false));
            RegisterMethod(new Method<Vessel, string>("VesselName", v => v == null ? "" : v.vesselName, false));

            RegisterMethod(new Method<Vessel, double>("Altitude", v => v == null ? 0.0 : v.altitude, false));

            RegisterMethod(new Method<Vessel, int>("CrewCount", GetCrewCount, false));
            RegisterMethod(new Method<Vessel, int>("CrewCapacity", GetCrewCapacity, false));
            RegisterMethod(new Method<Vessel, int>("EmptyCrewSpace", v => GetCrewCapacity(v) - GetCrewCount(v), false));
            RegisterMethod(new Method<Vessel, int>("FreeDockingPorts", FreeDockingPorts, false));
            RegisterMethod(new Method<Vessel, Resource, double>("ResourceQuantity", (v, r) => v == null || r == null ? 0.0 : v.ResourceQuantity(r.res), false));
            RegisterMethod(new Method<Vessel, Resource, double>("ResourceCapacity", (v, r) => v == null || r == null ? 0.0 : v.ResourceCapacity(r.res), false));

            RegisterMethod(new Method<Vessel, float>("Mass", v => v == null ? 0.0f : v.GetTotalMass(), false));
            RegisterMethod(new Method<Vessel, double>("XDimension", GetXDimension, false));
            RegisterMethod(new Method<Vessel, double>("YDimension", GetYDimension, false));
            RegisterMethod(new Method<Vessel, double>("ZDimension", GetZDimension, false));
            RegisterMethod(new Method<Vessel, double>("SmallestDimension", GetSmallestDimension, false));
            RegisterMethod(new Method<Vessel, double>("LargestDimension", GetLargestDimension, false));
            RegisterMethod(new Method<Vessel, Location>("Location", v => v == null ? null : new Location(v.mainBody, v.latitude, v.longitude), false));

            RegisterMethod(new Method<Vessel, Orbit>("Orbit", GetOrbit, false));
            RegisterMethod(new Method<Vessel, double>("OrbitApoapsis", GetApA, false));
            RegisterMethod(new Method<Vessel, double>("OrbitPeriapsis", GetPeA, false));
            RegisterMethod(new Method<Vessel, double>("OrbitInclination", GetInclination, false));
            RegisterMethod(new Method<Vessel, double>("OrbitEccentricity", GetEccentricity, false));

            RegisterMethod(new Method<Vessel, double>("AntennaTransmitPower", AntennaTransmitPower, false));
            RegisterMethod(new Method<Vessel, double>("AntennaRelayPower", AntennaRelayPower, false));

            RegisterMethod(new Method<Vessel, Duration>("MET", v => new Duration(v == null ? 0.0 : v.missionTime), false));

            RegisterGlobalFunction(new Function<List<Vessel>>("AllVessels", () => FlightGlobals.Vessels.ToList(), false));
            RegisterGlobalFunction(new Function<Vessel, Vessel>("Vessel", v => v));
        }

        public VesselParser()
        {
        }

        static List<AvailablePart> PartList(Vessel v)
        {
            if (v == null)  return new List<AvailablePart>();
            if (v.loaded)   return v.parts.Select<Part, AvailablePart>(p => p.protoPartSnapshot.partInfo).ToList();
            return v.protoVessel.protoPartSnapshots.Select<ProtoPartSnapshot, AvailablePart>(pps => pps.partInfo).ToList();
        }

        /// <summary>
        /// Gets the crew count, as the methods provided on vessel only return valid values for
        /// loaded vessels.
        /// </summary>
        /// <param name="v">The vessel to check.</param>
        /// <returns>The number of crew members on board</returns>
        static int GetCrewCount(Vessel v)
        {
            if (v == null || v.protoVessel == null || v.protoVessel.protoPartSnapshots == null)
            {
                return 0;
            }

            return v.protoVessel.protoPartSnapshots.Sum(pps => pps.protoModuleCrew.Count);
        }

        /// <summary>
        /// Gets the crew capacity, as the methods provided on vessel only return valid values for
        /// loaded vessels.
        /// </summary>
        /// <param name="v">The vessel to check.</param>
        /// <returns>The number of crew space</returns>
        static int GetCrewCapacity(Vessel v)
        {
            return v == null || v.protoVessel == null || v.protoVessel.protoPartSnapshots == null
                ? 0
                : v.protoVessel.protoPartSnapshots.Sum(pps => pps.partInfo.partPrefab.CrewCapacity);
        }

        /// <summary>
        /// Gets the number of free docking ports
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static int FreeDockingPorts(Vessel v)
        {
            if (v == null || v.protoVessel == null || v.protoVessel.protoPartSnapshots == null)
            {
                return 0;
            }

            int count = 0;
            for (int i = v.protoVessel.protoPartSnapshots.Count - 1; i >= 0; i--)
            {
                ProtoPartSnapshot pps = v.protoVessel.protoPartSnapshots[i];
                for (int j = pps.modules.Count - 1; j >= 0; j--)
                {
                    ProtoPartModuleSnapshot ppms = pps.modules[j];
                    if (ConfigNodeUtil.ParseValue<string>(ppms.moduleValues, "state", "") == "Ready")
                    {
                        count += 1;
                    }
                }
            }

            return count;
        }

        static double GetXDimension(Vessel v)
        {
            return v == null || v.protoVessel == null || v.protoVessel.protoPartSnapshots == null
                ? 0.0f
                : v.protoVessel.protoPartSnapshots.Max(p => p.position.x) - v.protoVessel.protoPartSnapshots.Min(p => p.position.x);
        }

        static double GetYDimension(Vessel v)
        {
            return v == null || v.protoVessel == null || v.protoVessel.protoPartSnapshots == null
                ? 0.0f
                : v.protoVessel.protoPartSnapshots.Max(p => p.position.y) - v.protoVessel.protoPartSnapshots.Min(p => p.position.y);
        }

        static double GetZDimension(Vessel v)
        {
            return v == null || v.protoVessel == null || v.protoVessel.protoPartSnapshots == null
                ? 0.0f
                : v.protoVessel.protoPartSnapshots.Max(p => p.position.z) - v.protoVessel.protoPartSnapshots.Min(p => p.position.z);
        }

        static double GetLargestDimension(Vessel v)
        {
            return Math.Max(Math.Max(GetXDimension(v), GetYDimension(v)), GetZDimension(v));
        }

        static double GetSmallestDimension(Vessel v)
        {
            return Math.Min(Math.Min(GetXDimension(v), GetYDimension(v)), GetZDimension(v));
        }

        static Orbit GetOrbit(Vessel vessel)
        {
            return vessel == null ? null : vessel.loaded ? vessel.orbit : vessel.protoVessel.orbitSnapShot.Load();
        }

        static double GetApA(Vessel vessel)
        {
            LoggingUtil.LogWarning(typeof(VesselParser), "Vessel.OrbitApoapsis() is deprecated as of Contract Configurator 1.9.6.  Please use Vessel.Orbit().Apoapsis() instead.");
            if (vessel == null)
            {
                return 0.0;
            }

            Orbit orbit = vessel.loaded ? vessel.orbit : vessel.protoVessel.orbitSnapShot.Load();
            return orbit.ApA;
        }

        static double GetPeA(Vessel vessel)
        {
            LoggingUtil.LogWarning(typeof(VesselParser), "Vessel.OrbitPeriapsis() is deprecated as of Contract Configurator 1.9.6.  Please use Vessel.Orbit().Periapsis() instead.");
            if (vessel == null)
            {
                return 0.0;
            }

            Orbit orbit = vessel.loaded ? vessel.orbit : vessel.protoVessel.orbitSnapShot.Load();
            return orbit.PeA;
        }

        static double GetInclination(Vessel vessel)
        {
            LoggingUtil.LogWarning(typeof(VesselParser), "Vessel.OrbitInclination() is deprecated as of Contract Configurator 1.9.6.  Please use Vessel.Orbit().Inclination() instead.");
            if (vessel == null)
            {
                return 0.0;
            }

            Orbit orbit = vessel.loaded ? vessel.orbit : vessel.protoVessel.orbitSnapShot.Load();
            return orbit.inclination;
        }

        static double GetEccentricity(Vessel vessel)
        {
            LoggingUtil.LogWarning(typeof(VesselParser), "Vessel.OrbitEccentricity() is deprecated as of Contract Configurator 1.9.6.  Please use Vessel.Orbit().Eccentricity() instead.");
            if (vessel == null)
            {
                return 0.0;
            }

            Orbit orbit = vessel.loaded ? vessel.orbit : vessel.protoVessel.orbitSnapShot.Load();
            return orbit.eccentricity;
        }

        static double AntennaTransmitPower(Vessel vessel)
        {
            if (vessel == null)
            {
                return 0.0;
            }

            return vessel.connection == null 
                ? 0.0
                : vessel.connection.Comm.antennaTransmit.power;
        }

        static double AntennaRelayPower(Vessel vessel)
        {
            if (vessel == null)
            {
                return 0.0;
            }

            return vessel.connection == null
                ? 0.0
                : vessel.connection.Comm.antennaRelay.power;
        }

        public override U ConvertType<U>(Vessel value)
        {
            if (typeof(U) == typeof(string))
            {
                if (!parseMode)
                {
                    ContractVesselTracker.Instance.AssociateVessel(value.vesselName, value);
                }
                return (U)(object)value.vesselName;
            }
            if (typeof(U) == typeof(VesselIdentifier))
            {
                if (value == null)
                {
                    return default(U);
                }

                if (!parseMode)
                {
                    ContractVesselTracker.Instance.AssociateVessel(value.vesselName, value);
                }
                return (U)(object)new VesselIdentifier(value.vesselName);
            }
            return base.ConvertType<U>(value);
        }

        public override Vessel ParseIdentifier(Token token)
        {
            // Try to parse more, as vessel names can have spaces
            Match m = Regex.Match(expression, @"^((?>\s*[\w\d\-\.]+)+).*");
            string identifier = m.Groups[1].Value;
            expression = (expression.Length > identifier.Length ? expression.Substring(identifier.Length) : "");
            identifier = token.sval + identifier;

            // In parse mode we typically don't have a save game loaded, so
            // don't try to get a vessel.  Give the benefit of the
            // doubt and assume that it will be a valid vessel (ie. no exception)
            if (parseMode)
            {
                return null;
            }

            return identifier.Equals("null", StringComparison.CurrentCultureIgnoreCase)
                ? null
                : ContractVesselTracker.Instance.GetAssociatedVessel(identifier);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using FinePrint;

namespace ContractConfigurator.ExpressionParser
{
    /// <summary>
    /// Expression parser subclass for Waypoints.
    /// </summary>
    public class WaypointParser : ClassExpressionParser<Waypoint>, IExpressionParserRegistrer
    {
        static WaypointParser()
        {
            RegisterMethods();
        }

        public void RegisterExpressionParsers()
        {
            RegisterParserType(typeof(Waypoint), typeof(WaypointParser));
        }

        public static void RegisterMethods()
        {
            RegisterMethod(new Method<Waypoint, string>("Name", w => w == null ? "" : w.name));
            RegisterMethod(new Method<Waypoint, double>("Latitude", w => w == null ? 0.0 : w.latitude));
            RegisterMethod(new Method<Waypoint, double>("Longitude", w => w == null ? 0.0 : w.longitude));
            RegisterMethod(new Method<Waypoint, Location>("Location", w => w == null ? null :
                new Location(FlightGlobals.Bodies.SingleOrDefault(b => b.name == w.celestialName), w.latitude, w.longitude)));
            RegisterMethod(new Method<Waypoint, double>("Altitude", w => w == null ? 0.0 : w.altitude));
        }

        public WaypointParser()
        {
        }

        public override U ConvertType<U>(Waypoint value)
        {
            return typeof(U) == typeof(string) 
                ? (U)(object)(value == null ? "" : value.name) 
                : base.ConvertType<U>(value);
        }
    }
}

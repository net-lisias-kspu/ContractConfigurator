﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using KSPAchievements;

namespace ContractConfigurator.ExpressionParser
{
    /// <summary>
    /// Expression parser subclass for PQSCity.
    /// </summary>
    public class PQSCityParser : ClassExpressionParser<PQSCity>, IExpressionParserRegistrer
    {
        static PQSCityParser()
        {
            RegisterMethods();
        }

        public void RegisterExpressionParsers()
        {
            RegisterParserType(typeof(PQSCity), typeof(PQSCityParser));
        }

        public static void RegisterMethods()
        {
            RegisterMethod(new Method<PQSCity, Location>("Location", GetLocation, false));
            RegisterMethod(new Method<PQSCity, string>("Name", city => city != null ? city.name : null));

            RegisterGlobalFunction(new Function<PQSCity>("KSC", () => FlightGlobals.Bodies.First(cb => cb.isHomeWorld).GetComponentsInChildren<PQSCity>(true).First(city => city.name == "KSC")));
        }

        public PQSCityParser()
        {
        }

        public override U ConvertType<U>(PQSCity value)
        {
            return typeof(U) == typeof(string) ? (U)(object)value.name : base.ConvertType<U>(value);
        }

        public static Location GetLocation(PQSCity city)
        {
            if (city == null)
            {
                return null;
            }

            Vector3d position = city.transform.position;
            CelestialBody body = Part.GetComponentUpwards<CelestialBody>(city.sphere.gameObject);

            return new Location(body, body.GetLatitude(position), body.GetLongitude(position));
        }
    }
}

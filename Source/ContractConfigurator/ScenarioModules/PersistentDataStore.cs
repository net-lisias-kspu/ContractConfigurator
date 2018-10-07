﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using UnityEngine;
using KSP;
using Contracts;
using ContractConfigurator.ExpressionParser;

namespace ContractConfigurator
{
    public class DataStoreCastException : InvalidCastException
    {
        public Type FromType { get; private set; }
        public Type ToType { get; private set; }

        public DataStoreCastException(Type fromType, Type toType)
            : this(fromType, toType, null)
        {
        }

        public DataStoreCastException(Type fromType, Type toType, Exception inner)
            : base("Cannot cast from " + fromType + " to " + toType + ".", inner)
        {
            FromType = fromType;
            ToType = toType;
        }
    }

    [KSPScenario(ScenarioCreationOptions.AddToExistingCareerGames | ScenarioCreationOptions.AddToNewCareerGames,
        GameScenes.FLIGHT, GameScenes.TRACKSTATION, GameScenes.SPACECENTER)]
    public class PersistentDataStore : ScenarioModule
    {
        static public PersistentDataStore Instance { get; private set; }
        private Dictionary<string, System.Object> data = new Dictionary<string, System.Object>();
        private Dictionary<string, ConfigNode> configNodes = new Dictionary<string, ConfigNode>();

        public PersistentDataStore()
        {
            Instance = this;
        }

        /// <summary>
        /// Store a key/value pair into the persistent data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Store<T>(string key, T value)
        {
            data[key] = value;
        }
        
        /// <summary>
        /// Store a config node into the persistent data store.
        /// </summary>
        /// <param name="node"></param>
        public void Store(ConfigNode node)
        {
            configNodes[node.name] = node;
        }

        /// <summary>
        /// Retrieve a value from the persistent data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Retrieve<T>(string key)
        {
            if (!data.ContainsKey(key))
            {
                return default(T);
            }
            try
            {
                return (T)data[key];
            }
            catch (InvalidCastException)
            {
                throw new DataStoreCastException(typeof(T), data[key].GetType());
            }
        }

        /// <summary>
        /// Checks wether a key exists.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HasKey(string key)
        {
            return data.ContainsKey(key);
        }

        /// <summary>
        /// Retrieve a value from the persistent data store.
        /// </summary>
        /// <param name="key">Key to retrieve for</param>
        /// <param name="type">Type of the value retrieved</param>
        /// <returns>The value</returns>
        public object Retrieve(string key, out Type type)
        {
            if (!data.ContainsKey(key))
            {
                throw new Exception("Key '" + key + "' is not in persistent data store!");
            }
            object result = data[key];
            type = result.GetType();
            return result;
        }

        /// <summary>
        /// Retrieve a config node from the persistent data store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ConfigNode Retrieve(string key)
        {
            if (!configNodes.ContainsKey(key))
            {
                return new ConfigNode();
            }
            return configNodes[key];
        }

        public override void OnLoad(ConfigNode node)
        {
            try
            {
                base.OnLoad(node);

                ConfigNode dataNode = node.GetNode("DATA");
                if (dataNode != null)
                {
                    // Handle individual values
                    foreach (ConfigNode.Value pair in dataNode.values)
                    {
                        string typeName = pair.value.Remove(pair.value.IndexOf(":"));
                        string value = pair.value.Substring(typeName.Length + 1);
                        Type type = ConfigNodeUtil.ParseTypeValue(typeName);

                        if (type == typeof(string))
                        {
                            data[pair.name] = value;
                        }
                        else if (type.Name == "List`1")
                        {
                            BaseParser parser = BaseParser.NewParser(type);
                            if (parser == null)
                            {
                                throw new Exception("Couldn't read list of values of type '" + type.GetGenericArguments().First().Name + "'.");
                            }
                            data[pair.name] = parser.ParseExpressionGeneric("", value, null);
                        }
                        else
                        {
                            // Get the ParseValue method
                            MethodInfo parseValueMethod = typeof(ConfigNodeUtil).GetMethods().Where(m => m.Name == "ParseSingleValue").Single();
                            parseValueMethod = parseValueMethod.MakeGenericMethod(new Type[] { type });

                            // Invoke the ParseValue method
                            data[pair.name] = parseValueMethod.Invoke(null, new object[] { pair.name, value, false });
                        }
                    }

                    // Handle config nodes
                    foreach (ConfigNode childNode in dataNode.GetNodes())
                    {
                        configNodes[childNode.name] = childNode;
                    }
                }
            }
            catch (Exception e)
            {
                LoggingUtil.LogError(this, "Error loading PersistentDataStore from persistance file!");
                LoggingUtil.LogException(e);
                ExceptionLogWindow.DisplayFatalException(ExceptionLogWindow.ExceptionSituation.SCENARIO_MODULE_LOAD, e, "PersistentDataStore");
            }
        }

        public override void OnSave(ConfigNode node)
        {
            try
            {
                base.OnSave(node);

                ConfigNode dataNode = new ConfigNode("DATA");
                node.AddNode(dataNode);

                // Handle individual values
                foreach (KeyValuePair<string, System.Object> p in data)
                {
                    StoreToConfigNode(dataNode, p.Key, p.Value);
                }

                // Handle config nodes
                foreach (ConfigNode childNode in configNodes.Values)
                {
                    dataNode.AddNode(childNode);
                }
            }
            catch (Exception e)
            {
                LoggingUtil.LogError(this, "Error saving PersistentDataStore to persistance file!");
                LoggingUtil.LogException(e);
                ExceptionLogWindow.DisplayFatalException(ExceptionLogWindow.ExceptionSituation.SCENARIO_MODULE_SAVE, e, "PersistentDataStore");
            }
        }

        public static void StoreToConfigNode(ConfigNode node, string key, object value)
        {
            Type type = null;
            string outputValue = OutputValue(value, out type);
            node.AddValue(key, GetTypeName(type) + ":" + outputValue);
        }

        public static string OutputValue(object value, out Type type)
        {
            string strValue;
            type = value.GetType();
            if (type == typeof(CelestialBody))
            {
                strValue = ((CelestialBody)value).name;
            }
            else if (type == typeof(Vessel))
            {
                strValue = ((Vessel)value).id.ToString();
            }
            else if (type == typeof(ScienceSubject))
            {
                strValue = ((ScienceSubject)value).id;
            }
            else if (type == typeof(ScienceExperiment))
            {
                strValue = ((ScienceExperiment)(value)).id;
            }
            else if (type == typeof(AvailablePart))
            {
                strValue = ((AvailablePart)(value)).name;
            }
            else if (type == typeof(Biome))
            {
                Biome b = (Biome)value;
                strValue = b.body.name + ";" + b.biome;
            }
            else if (type.Name == "List`1")
            {
                strValue = "[ ";
                System.Collections.IEnumerable list = (System.Collections.IEnumerable)value;
                foreach (object o in list)
                {
                    Type t;
                    strValue += OutputValue(o, out t) + ", ";
                }
                strValue = strValue.Length == 2 ? "[]" : (strValue.Remove(strValue.Length - 2) + " ]");
            }
            else
            {
                strValue = value.ToString();
            }
            return strValue;
        }

        public static string GetTypeName(Type type)
        {
            Type[] generics = type.GetGenericArguments();
            if (!generics.Any())
            {
                return type.Name;
            }

            return type.Name.Replace("`1", "") + "<" +
                generics.First().Name + ">";
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using KSP;
using Contracts;

namespace ContractConfigurator
{
    [KSPScenario(ScenarioCreationOptions.AddToExistingCareerGames | ScenarioCreationOptions.AddToNewCareerGames,
        GameScenes.FLIGHT, GameScenes.TRACKSTATION, GameScenes.SPACECENTER)]
    public class BiomeTracker : ScenarioModule
    {
        private class BiomeData
        {
            public string name;
            public int landCount;
            public int waterCount;

            public double landRatio
            {
                get
                {
                    return (double)landCount / (landCount + waterCount);
                }
            }

            public List<Vector2d> landLocations = new List<Vector2d>();
            public List<Vector2d> waterLocations = new List<Vector2d>();

            public BiomeData(string name)
            {
                this.name = name;
            }

            public void Save(ConfigNode node)
            {
                node.AddValue("name", name);
                node.AddValue("landCount", landCount);
                node.AddValue("waterCount", waterCount);

                for (int i = landLocations.Count - 1; i >= 0; i--)
                {
                    Vector2d v = landLocations[i];
                    ConfigNode location = new ConfigNode("LAND_LOCATION");
                    node.AddNode(location);
                    location.AddValue("lat", v.y);
                    location.AddValue("lon", v.x);
                }

                for (int i = waterLocations.Count - 1; i >= 0; i--)
                {
                    Vector2d v = waterLocations[i];
                    ConfigNode location = new ConfigNode("WATER_LOCATION");
                    node.AddNode(location);
                    location.AddValue("lat", v.y);
                    location.AddValue("lon", v.x);
                }
            }

            public static BiomeData Load(ConfigNode node)
            {
                BiomeData biomeData = new BiomeData(ConfigNodeUtil.ParseValue<string>(node, "name"))
                {
                    landCount = ConfigNodeUtil.ParseValue<int>(node, "landCount"),
                    waterCount = ConfigNodeUtil.ParseValue<int>(node, "waterCount")
                };

                for (int i = node.GetNodes("LAND_LOCATION").Length - 1; i >= 0; i--)
                {
                    ConfigNode location = node.GetNodes("LAND_LOCATION")[i];
                    Vector2d v = new Vector2d
                    {
                        y = ConfigNodeUtil.ParseValue<double>(location, "lat"),
                        x = ConfigNodeUtil.ParseValue<double>(location, "lon")
                    };
                    biomeData.landLocations.Add(v);
                }

                for (int i = node.GetNodes("WATER_LOCATION").Length - 1; i >= 0; i--)
                {
                    ConfigNode location = node.GetNodes("WATER_LOCATION")[i];
                    Vector2d v = new Vector2d
                    {
                        y = ConfigNodeUtil.ParseValue<double>(location, "lat"),
                        x = ConfigNodeUtil.ParseValue<double>(location, "lon")
                    };
                    biomeData.waterLocations.Add(v);
                }

                return biomeData;
            }
        }
        private static BiomeTracker Instance;
        private Dictionary<CelestialBody, Dictionary<string, BiomeData>> bodyInfo = new Dictionary<CelestialBody, Dictionary<string, BiomeData>>();

        public static string BiomeDataFile
        {
            get
            {
                return string.Join(Path.DirectorySeparatorChar.ToString(), new string[] { KSPUtil.ApplicationRootPath, "GameData", "ContractConfigurator", "BiomeData.cfg" });
            }
        }
        public static string DefaultBiomeDataFile
        {
            get
            {
                return string.Join(Path.DirectorySeparatorChar.ToString(), new string[] { KSPUtil.ApplicationRootPath, "GameData", "ContractConfigurator", "BiomeDataDefault.cfg" });
            }
        }

        void Start()
        {
            DontDestroyOnLoad(this);
            Instance = this;

            StartCoroutine(LoadAllBodyInfo());
        }

        void Destroy()
        {
        }

        IEnumerator<YieldInstruction> LoadAllBodyInfo()
        {
            foreach (YieldInstruction ins in FlightGlobals.Bodies.SelectMany<CelestialBody, YieldInstruction>(LoadBodyInfo))
            {
                yield return ins;
            }
        }

        IEnumerable<YieldInstruction> LoadBodyInfo(CelestialBody body)
        {
            if (body == null || body.pqsController == null || !body.ocean || bodyInfo.ContainsKey(body))
            {
                yield break;
            }

            Dictionary<string, BiomeData> biomeData = new Dictionary<string, BiomeData>();

            int biomeCount = body.BiomeMap.Attributes.Length;
            float startTime = Time.realtimeSinceStartup;
            float timeStep = 0.005f;
            int maxCount = 1000;
            int maxIterations = 50000;
            int targetMin = 3;

            int w = 4096;
            int h = 2048;
            int bu = 0;
            int bv = 0;

            LoggingUtil.LogInfo(this, "Starting background load of " + body.name + " biome data.");
            int count = 0;
            for (int i = 0; i < w; i++)
            {
                bu = (bu + 977) % w;

                double lonRads = 2.0 * Math.PI * ((bu + 0.5) / w);
                double cosLon = Math.Cos(lonRads);
                double sinLon = Math.Sin(lonRads);

                for (int j = 0; j < h; j++)
                {
                    count++;
                    bv = (bv + 239) % h;

                    double latRads = Math.PI * (0.5 - (bv + 0.5) / h);
                    double cosLat = Math.Cos(latRads);
                    double sinLat = Math.Sin(latRads);

                    // Get biome data
                    string biome = body.BiomeMap.GetAtt(latRads, lonRads).name.Replace(" ", "");
                    BiomeData bd;
                    biomeData.TryGetValue(biome, out bd);
                    if (bd == null)
                    {
                        bd = biomeData[biome] = new BiomeData(biome);
                    }

                    if (bd.landCount + bd.waterCount < maxCount || bd.landLocations.Count < targetMin || bd.waterLocations.Count < targetMin)
                    {
                        Vector3d radialVector = new Vector3d(cosLat * cosLon, sinLat, cosLat * sinLon);
                        double height = body.pqsController.GetSurfaceHeight(radialVector) - body.pqsController.radius;

                        if (height > 0.0)
                        {
                            bd.landCount++;
                            if (bd.landLocations.Count < targetMin)
                            {
                                double lon = lonRads * 180.0 / Math.PI;
                                double lat = latRads * 180.0 / Math.PI;
                                if (!bd.landLocations.Any(v => Math.Abs(v.x - lon) < 2.0 || Math.Abs(v.y - lat) < 2.0))
                                {
                                    bd.landLocations.Add(new Vector2d(lon, latRads * 180.0 / Math.PI));
                                }
                            }
                        }
                        else
                        {
                            bd.waterCount++;
                            if (bd.waterLocations.Count < targetMin)
                            {
                                double lon = lonRads * 180.0 / Math.PI;
                                double lat = latRads * 180.0 / Math.PI;
                                if (!bd.waterLocations.Any(v => Math.Abs(v.x - lon) < 2.0 || Math.Abs(v.y - lat) < 2.0))
                                {
                                    bd.waterLocations.Add(new Vector2d(lon, latRads * 180.0 / Math.PI));
                                }
                            }
                        }
                    }

                    // Take a break
                    if (Time.realtimeSinceStartup >= startTime + timeStep)
                    {
                        yield return null;
                        startTime = Time.realtimeSinceStartup;
                    }
                }

                // Check for completion after every "row"
                if (biomeData.Count == biomeCount &&
                    biomeData.All(pair => pair.Value.landCount + pair.Value.waterCount >= maxCount &&
                        pair.Value.landLocations.Count >= targetMin && pair.Value.waterLocations.Count >= targetMin || count >= maxIterations))
                {
                    break;
                }
            }

            // Build a color => name map
            Dictionary<string, string> nameMap = new Dictionary<string, string>();
            for (int i = 0; i < body.BiomeMap.Attributes.Length; i++)
            {
                nameMap[body.BiomeMap.Attributes[i].mapColor.ToString()] = body.BiomeMap.Attributes[i].name;
			}

            // Save the biome data that was collected
            bodyInfo[body] = biomeData;
            Save();

            LoggingUtil.LogInfo(this, "Completed background load of " + body.name + " biome data.");
        }

        public override void OnLoad(ConfigNode node)
        {
            try
            {
                Load();
            }
            catch (Exception e)
            {
                LoggingUtil.LogError(this, "Error loading BiomeTracker data from custom file!");
                LoggingUtil.LogException(e);
                ExceptionLogWindow.DisplayFatalException(ExceptionLogWindow.ExceptionSituation.SCENARIO_MODULE_LOAD, e, "BiomeTracker");
            }
        }

        public override void OnSave(ConfigNode node)
        {
        }

        protected void Save()
        {
            ConfigNode node = new ConfigNode("CONTRACT_CONFIGURATOR_BIOME_DATA");

            foreach (KeyValuePair<CelestialBody, Dictionary<string, BiomeData>> pair in bodyInfo)
            {
                ConfigNode bodyNode = new ConfigNode("CELESTIAL_BODY");
                node.AddNode(bodyNode);
                bodyNode.AddValue("body", pair.Key.name);

                foreach (BiomeData biomeData in pair.Value.Values)
                {
                    ConfigNode biomeNode = new ConfigNode("BIOME");
                    bodyNode.AddNode(biomeNode);
                    biomeData.Save(biomeNode);
                }
            }

            node.Save(BiomeDataFile,
                "Contract Configurator Biome Data File\r\n" +
                "//\r\n" +
                "// This file contains land/water biome data from applicable Celestial Bodies.");
        }

        protected void Load()
        {
            for (int i = new string[] { DefaultBiomeDataFile, BiomeDataFile }.Length - 1; i >= 0; i--)
            {
                string file = new string[] { DefaultBiomeDataFile, BiomeDataFile }[i];
                if (!File.Exists(file))
                {
                    continue;
                }

                ConfigNode node = ConfigNode.Load(file);
                for (int j = node.GetNodes("CELESTIAL_BODY").Length - 1; j >= 0; j--)
                {
                    ConfigNode bodyNode = node.GetNodes("CELESTIAL_BODY")[j];
                    CelestialBody body;
                    try
                    {
                        body = ConfigNodeUtil.ParseValue<CelestialBody>(bodyNode, "body");
                    }
                    // Check for invalidated celestial bodies, and ignore those entries
                    catch (ArgumentException e)
                    {
                        if (e.Message.Contains("not a valid CelestialBody"))
                            continue;
                        throw;
                    }
                    Dictionary<string, BiomeData> biomeDetails = bodyInfo[body] = new Dictionary<string, BiomeData>();

                    for (int k = bodyNode.GetNodes("BIOME").Length - 1; k >= 0; k--)
                    {
                        ConfigNode biomeNode = bodyNode.GetNodes("BIOME")[k];
                        BiomeData biomeData = BiomeData.Load(biomeNode);
                        biomeDetails.Add(biomeData.name, biomeData);
                    }
                }
            }
        }

        public static bool IsDifficult(CelestialBody body, string biome, ExperimentSituations situation)
        {
            if (body == null || !body.ocean || body.pqsController == null ||
                (situation != ExperimentSituations.SrfLanded && situation != ExperimentSituations.SrfSplashed))
            {
                return false;
            }

            if (Instance == null || !Instance.bodyInfo.ContainsKey(body))
            {
                return true;
            }

            // Handles KSC biomes
            if (!Instance.bodyInfo[body].ContainsKey(biome))
            {
                return situation == ExperimentSituations.SrfSplashed;
            }

            double landRatio = Instance.bodyInfo[body][biome].landRatio;
            return landRatio > 0.95 && situation == ExperimentSituations.SrfSplashed ||
                landRatio < 0.05 && situation == ExperimentSituations.SrfLanded;
        }

        public static IEnumerable<Vector2d> GetDifficultLocations(CelestialBody body, string biome)
        {
            if (body == null || Instance == null || !Instance.bodyInfo.ContainsKey(body) ||
                !Instance.bodyInfo[body].ContainsKey(biome))
            {
                yield break;
            }

            double landRatio = Instance.bodyInfo[body][biome].landRatio;
            List<Vector2d> list = landRatio > 0.95 ? Instance.bodyInfo[body][biome].waterLocations :
                landRatio < 0.05 ? Instance.bodyInfo[body][biome].landLocations : new List<Vector2d>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                Vector2d v = list[i];
                yield return v;
            }
        }

        public static Vessel.Situations GetPrimarySituation(CelestialBody body, string biome)
        {
            biome = biome.Replace(" ", "");
            if (body == null || Instance == null || !Instance.bodyInfo.ContainsKey(body) ||
                !Instance.bodyInfo[body].ContainsKey(biome))
            {
                return Vessel.Situations.LANDED;
            }

            double landRatio = Instance.bodyInfo[body][biome].landRatio;
            return landRatio > 0.5 ? Vessel.Situations.LANDED : Vessel.Situations.SPLASHED;
        }
    }
}

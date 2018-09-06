﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;

namespace ContractConfigurator.Util
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class TipLoader : MonoBehaviour
    {
        public void Update()
        {
            // Delay until the game database has started loading (it's a short delay)
            if (LoadingScreen.Instance != null && GameDatabase.Instance != null && GameDatabase.Instance.root != null)
            {
                LoggingUtil.LogDebug(this, "Adding custom loading tips");

                // Add the Contract Configurator tip
                List<string> contractTips = new List<string>();
                contractTips.Add("Configuring Contracts...");

                // Read tips from root contract groups
                ConfigNode[] contractGroups = GameDatabase.Instance.GetConfigNodes("CONTRACT_GROUP");
                for (int i = contractGroups.Length - 1; i >= 0; i--)
                {
                    ConfigNode groupConfig = contractGroups[i];
                    if (groupConfig.HasValue("tip"))
                    {
                        for (int j = groupConfig.GetValues("tip").Length - 1; j >= 0; j--)
                        {
                            string tip = groupConfig.GetValues("tip")[j];
                            contractTips.Add(tip);
                        }
                    }
                }

                for (int i = LoadingScreen.Instance.Screens.Count - 1; i >= 0; i--)
                {
                    LoadingScreen.LoadingScreenState lss = LoadingScreen.Instance.Screens[i];
                    // Append our custom tips
                    lss.tips = lss.tips.Union(contractTips).ToArray();
                }

                Destroy(this);
            }
        }
    }
}

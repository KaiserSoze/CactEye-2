﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CactEye2
{
    /* ************************************************************************************************
    * Class Name: CactEyeAsteroidSpawner_Flight
    * Purpose: This will allow CactEye's custom asteroid spawner to run in multiple specific scenes. 
    * Shamelessly stolen from Starstrider42, who shamelessly stole it from Trigger Au.
    * Thank you!
    * ************************************************************************************************/
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    internal class CactEyeConfig_Flight : CactEyeConfig
    {
    }

    /* ************************************************************************************************
    * Class Name: CactEyeAsteroidSpawner_SpaceCentre
    * Purpose: This will allow CactEye's custom asteroid spawner to run in multiple specific scenes. 
    * Shamelessly stolen from Starstrider42, who shamelessly stole it from Trigger Au.
    * Thank you!
    * ************************************************************************************************/
    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    internal class CactEyeConfig_SpaceCentre : CactEyeConfig
    {
    }

    /* ************************************************************************************************
    * Class Name: CactEyeAsteroidSpawner_TrackingStation
    * Purpose: This will allow CactEye's custom asteroid spawner to run in multiple specific scenes. 
    * Shamelessly stolen from Starstrider42, who shamelessly stole it from Trigger Au.
    * Thank you!
    * ************************************************************************************************/
    [KSPAddon(KSPAddon.Startup.TrackingStation, false)]
    internal class CactEyeConfig_TrackStation : CactEyeConfig
    {
    }

    internal class CactEyeConfig : MonoBehaviour
    {

        //Path to the configuration file.
        private string ConfigFilePath = KSPUtil.ApplicationRootPath + "GameData/CactEye/Resources/settings.cfg";

        //Boolean stating whether the file is loaded or not
        public bool IsLoaded = false;

        //Specifies whether CactEye should operate in debug mode or not.
        public static bool DebugMode = false;

        //Specifies whether telescopes should blow up when pointed at the sun.
        public static bool SunDamage = true;

        //Specifies whether telescopes should blow up when pointed at the sun.
        public static bool GyroDecay = true;

        public void Start()
        {
            ReadSettings();
        }

        public void ReadSettings()
        {
            ConfigNode Settings = ConfigNode.Load(ConfigFilePath);

            if (Settings != null)
            {
                if (Settings.HasNode("CactEye2"))
                {
                    ConfigNode CactEye2 = Settings.GetNode("CactEye2");

                    if (CactEye2.HasValue("DebugMode"))
                    {
                        DebugMode = bool.Parse(CactEye2.GetValue("DebugMode"));
                    }
                    if (CactEye2.HasValue("SunDamage"))
                    {
                        DebugMode = bool.Parse(CactEye2.GetValue("SunDamage"));
                    }
                    if (CactEye2.HasValue("GyroDecay"))
                    {
                        DebugMode = bool.Parse(CactEye2.GetValue("GyroDecay"));
                    }
                }
                else
                {
                    Debug.Log("CactEye 2: Logical Error: Error loaded configuration file. Was not able to find CactEye2 node in configuration file.");
                }

                IsLoaded = true;
            }
            else
            {
                Debug.Log("CactEye 2: Logical Error: Was not able to load the CactEye configuration file.");
            }

        }

        public void ApplySettings()
        {
            ConfigNode Settings = new ConfigNode();
            ConfigNode CactEye2 = Settings.AddNode("CactEye2");
            CactEye2.AddValue("DebugMode", DebugMode);
            CactEye2.AddValue("SunDamage", SunDamage);
            CactEye2.AddValue("GyroDecay", GyroDecay);
            Settings.Save(ConfigFilePath);
        }
    }
}

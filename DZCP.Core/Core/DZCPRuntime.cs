using System;
using DZCP.API.Models;
using PluginAPI.Core;
using UnityEngine;

namespace DZCP.Core
{
    public static class DZCPRuntime
    {
        public static bool Initialized { get; private set; }

        public static void Start()
        {
            if (Initialized) return;

            Initialized = true;
            Log("Starting Runtime...");

            Loader.PluginLoader.LoadAll();

            Log("DZCP is now running.");
        }

        public static void Log(string msg)
        {
            Debug.Log($"<color=green>[DZCP]</color> {msg}");
        }
    }
}
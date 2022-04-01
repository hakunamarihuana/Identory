﻿using Identory.Helpers;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Identory
{
    public class Identory
    {
        public SettingsEndpoint Settings { get; }
        public ProfileEndpoint Profile { get; }
        public ToolsEndpoint Tools { get; }

        private ChildProcessManager windowsChildProcessManager;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="httpClient">Consumer specified HttpClient.</param>
        private Identory(string endpoint, HttpClient? httpClient = null)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                windowsChildProcessManager = new ChildProcessManager();
            }

            Profile = new ProfileEndpoint(endpoint, httpClient);
            Tools = new ToolsEndpoint(endpoint, httpClient);
            Settings = new SettingsEndpoint(endpoint, httpClient);
        }

        internal Identory(ushort apiPort, int apiVersion, HttpClient? httpClient = null) : this($"http://localhost:{apiPort}/api/v{apiVersion}", httpClient) { }

        private void OnIdentoryProccessExited()
        {
        }

        /// <summary>
        /// Starts and connects to a locally based Identory browser.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="apiPort"></param>
        /// <param name="bindIdentoryToProcess">Close indentory when the program that has initialized it closes.</param>
        /// <param name="customStartPath"></param>
        /// <param name="httpClient">Consumer specified HttpClient.</param>
        /// <returns>Instance of <see cref="Identory"/></returns>
        public static async Task<Identory?> StartIdentory(string accessToken, ushort apiPort = 3005, int apiVersion = 1, bool bindIdentoryToProcess = false, string customStartPath = "", HttpClient? httpClient = null)
        {

            var identory = new Identory(apiPort, apiVersion);
            
            string startPath;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                startPath = !string.IsNullOrEmpty(customStartPath) ? customStartPath : "%userprofile%/AppData/Local/Programs/identory/identory.exe";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                startPath = !string.IsNullOrEmpty(customStartPath) ? customStartPath : "/Applications/IDENTORY.app/Contents/MacOS/IDENTORY";
            }
            else
            {
                startPath = !string.IsNullOrEmpty(customStartPath) ? customStartPath : "identory";
            }

            startPath = Environment.ExpandEnvironmentVariables(startPath);

            var startInfo = new ProcessStartInfo()
            {
                FileName = startPath,
                Arguments = $"serve --access-token={accessToken} --port={apiPort}",
                RedirectStandardOutput = true
            };

            var process = Process.Start(startInfo);

            if (bindIdentoryToProcess)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    identory.windowsChildProcessManager.AddProcess(process.Id);
                } else
                {
                    AppDomain.CurrentDomain.DomainUnload += (s, e) => { process.Kill(); process.WaitForExit(); };
                    AppDomain.CurrentDomain.ProcessExit += (s, e) => { process.Kill(); process.WaitForExit(); };
                    AppDomain.CurrentDomain.UnhandledException += (s, e) => { process.Kill(); process.WaitForExit(); };
                }
            }

            process.Exited += (sender, e) => Process_Exited(sender, e, identory);


            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                if (line.StartsWith("API URL"))
                {
                    return identory;
                }
            }

            return null;

        }
        /// <summary>
        /// Connects to an already running Identory browser. 
        /// </summary>
        /// <param name="endpoint">Full endpoint with port and api version.</param>
        /// <returns></returns>
        public static Identory ConnectToIdentory(string endpoint, int apiVersion = 1, HttpClient? httpClient = null)
        {
            return new Identory($"{endpoint}/api/v{apiVersion}", httpClient);
        }

        private static void Process_Exited(object sender, EventArgs e, Identory instance)
        {
            if (instance != null)
            {
                instance.OnIdentoryProccessExited();
            }
        }
    }
}

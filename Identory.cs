using Identory.Helpers;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Identory
{
    public class Identory
    {
        public static string ApiVersion { get; set; } = "v1";
        public ProfileEndpoint Profile { get; }
        public ToolsEndpoint Tools { get; }

        private ChildProcessManager windowsChildProcessManager;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="endpoint"></param>
        private Identory(string endpoint)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                windowsChildProcessManager = new ChildProcessManager();
            }

            Profile = new ProfileEndpoint(endpoint);
            Tools = new ToolsEndpoint(endpoint);
        }

        internal Identory(ushort apiPort) : this($"http://localhost:{apiPort}/api/{ApiVersion}") { }


        private void OnIdentoryProccessExited()
        {

        }
        /// <summary>
        /// Starts and connects to a locally based Identory browser.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="apiPort"></param>
        /// <param name="bindIdentoryToProcess">Close indentory when the program who has intitialized it closes.</param>
        /// <param name="customStartPath"></param>
        /// <returns>Instance of <see cref="Identory"/></returns>
        public static async Task<Identory?> StartIdentory(string accessToken, ushort apiPort = 3005, bool bindIdentoryToProcess = false, string customStartPath = "")
        {

            var identory = new Identory(apiPort);


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
        public static Identory ConnectToIdentory(string endpoint, int apiVersion = 1)
        {
            return new Identory($"{endpoint}/api/v{apiVersion}");
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

using Identory.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Identory
{
    public class ToolsEndpoint : IdentoryEndpoint
    {
        public ToolsEndpoint(string endpoint) : base(endpoint)
        {
        }
        /// <summary>
        /// Get information about a proxy.
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns><see cref="ProxyInfo"/></returns>
        public async Task<IdentoryOption<ProxyInfo, IdentoryError>> GetProxyInfo(Proxy proxy)
        {
            try
            {
                var serializedProxy = JsonConvert.SerializeObject(proxy);
                var httpContent = new StringContent(serializedProxy, Encoding.UTF8, "application/json");
                HttpResponseMessage? result;
                result = await HttpClient.PostAsync($"{Endpoint}/tools/get-ip-info", httpContent);

                return VerifyResponse(result).Match<IdentoryOption<ProxyInfo, IdentoryError>>(successful =>
                {
                    var ipInfo = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result) as ProxyInfo ?? new ProxyInfo();
                    
                    return IdentoryOption<ProxyInfo, IdentoryError>.Successful(ipInfo);
                },
                error =>
                {
                    return IdentoryOption<ProxyInfo, IdentoryError>.Error(error);
                });

            }
            catch (Exception ex)
            {
                return IdentoryOption<ProxyInfo, IdentoryError>.Error(new IdentoryError(ex.Message, ex));
            }
        }
        /// <summary>
        /// Check if connection to a proxy is possible. 
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns><see cref="ProxyTestResult"/> or <see cref="IdentoryError"/></returns>
        public async Task<IdentoryOption<ProxyTestResult, IdentoryError>> CheckProxyHealth(Proxy proxy)
        {
            var serializedProxy = JsonConvert.SerializeObject(proxy);
            var httpContent = new StringContent(serializedProxy, Encoding.UTF8, "application/json");

            HttpResponseMessage? result;

            try
            {
                result = await HttpClient.PostAsync($"{Endpoint}/tools/check-proxy", httpContent);

                return VerifyResponse(result).Match<IdentoryOption<ProxyTestResult, IdentoryError>>(successful =>
                {
                    var proxyHealth = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result) as ProxyTestResult ?? new ProxyTestResult();
                    return IdentoryOption<ProxyTestResult, IdentoryError>.Successful(proxyHealth);
                },
               error =>
               {
                   return IdentoryOption<ProxyTestResult, IdentoryError>.Error(error);
               });

            }
            catch (Exception ex)
            {
                return IdentoryOption<ProxyTestResult, IdentoryError>.Error(new IdentoryError(ex.Message, ex));
            }
        }
    }
}

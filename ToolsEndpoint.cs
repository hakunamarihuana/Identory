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

        public async Task<IdentoryOption<IPInfo, IdentoryError>> GetProxyInfo(Proxy proxy)
        {
            try
            {
                var serializedProxy = JsonConvert.SerializeObject(proxy);
                var httpContent = new StringContent(serializedProxy, Encoding.UTF8, "application/json");
                HttpResponseMessage? result;
                result = await HttpClient.PostAsync($"{Endpoint}/tools/get-ip-info", httpContent);

                return VerifyResponse(result).Match<IdentoryOption<IPInfo, IdentoryError>>(successful =>
                {
                    var ipInfo = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result) as IPInfo ?? new IPInfo();
                    
                    return IdentoryOption<IPInfo, IdentoryError>.Successful(ipInfo);
                },
                error =>
                {
                    return IdentoryOption<IPInfo, IdentoryError>.Error(error);
                });

            }
            catch (Exception ex)
            {
                return IdentoryOption<IPInfo, IdentoryError>.Error(new IdentoryError(ex.Message, ex));
            }
        }

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

using Identory.Models;
using Identory.Models.Profile;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Identory
{
    public class SettingsEndpoint : IdentoryEndpoint
    {
        public SettingsEndpoint(string endpoint, HttpClient? httpClient = null) : base(endpoint, httpClient)
        {
        }

        public async Task<IdentoryOption<DefaultProfile, IdentoryError>> GetProfile(DefaultProfile defaultProfile)
        {
            try
            {
                var serializedProfile = JsonConvert.SerializeObject(defaultProfile);
                var httpContent = new StringContent(serializedProfile, Encoding.UTF8, "application/json");

                var result = await HttpClient.PutAsync($"{Endpoint}/settings/default-profile", httpContent);


                return VerifyResponse(result).Match(successful =>
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    var token = JToken.Parse(response);

                    if (token.Type == JTokenType.Object)
                    {
                        var obj = token as JObject;

                        if (obj != null)
                        {
                            return IdentoryOption<DefaultProfile, IdentoryError>.Successful(obj.ToObject<DefaultProfile>());
                        }
                    }

                    return IdentoryOption<DefaultProfile, IdentoryError>.Error(new IdentoryError("Unable to cast object."));
                },
               error =>
               {
                   return IdentoryOption<DefaultProfile, IdentoryError>.Error(error);
               });

            }
            catch (Exception ex)
            {
                return IdentoryOption<DefaultProfile, IdentoryError>.Error(new IdentoryError(ex.Message));
            }
        }
    }
}

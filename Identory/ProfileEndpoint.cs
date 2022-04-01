using Identory.Models;
using Identory.Models.Profile;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Identory
{
    public class ProfileEndpoint : IdentoryEndpoint
    {
        public ProfileEndpoint(string endpoint, HttpClient? httpClient = null) : base(endpoint, httpClient)
        {
        }

        public async Task<IdentoryOption<IEnumerable<UnknownProfile>, IdentoryError>> GetProfiles()
        {
            try
            {
               var result = await HttpClient.GetAsync($"{Endpoint}/profiles");

               return VerifyResponse(result).Match(successful =>
                {
                    var response =  successful.Content.ReadAsStringAsync().Result;
                    var token = JToken.Parse(response);

                    if (token.Type == JTokenType.Array)
                    {
                        var profileCol = (token as JArray);
                        var unknownProfileCol = new UnknownProfile[profileCol.Count];

                        for (int i = 0; i < profileCol.Count; i++)
                        {
                            unknownProfileCol[i] = new UnknownProfile(profileCol[i]);
                        }

                        return IdentoryOption<IEnumerable<UnknownProfile>, IdentoryError>.Successful(unknownProfileCol);
                    }

                    return IdentoryOption<IEnumerable<UnknownProfile>, IdentoryError>.Error(new IdentoryError("Unable to cast object."));
                },
                error =>
                {
                   return IdentoryOption<IEnumerable<UnknownProfile>, IdentoryError>.Error(error);
                });
            }
            catch (Exception ex)
            {
                return IdentoryOption<IEnumerable<UnknownProfile>, IdentoryError>.Error(new IdentoryError(ex.Message));
            }
        }

        public async Task<IdentoryOption<UnknownProfile, IdentoryError>> GetProfile(string profileId)
        {
            try
            {
                var result = await HttpClient.GetAsync($"{Endpoint}/profiles/{profileId}");

                return VerifyResponse(result).Match(successful =>
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    var token = JToken.Parse(response);

                    if (token.Type == JTokenType.Object)
                    {
                        var obj = token as JObject;

                        if (obj != null)
                        {
                            return IdentoryOption<UnknownProfile, IdentoryError>.Successful(new UnknownProfile(obj));
                        }
                    }

                    return IdentoryOption<UnknownProfile, IdentoryError>.Error(new IdentoryError("Unable to cast object."));
                },
                error =>
                {
                    return IdentoryOption<UnknownProfile, IdentoryError>.Error(error);
                });

            }
            catch (Exception ex)
            {
                return IdentoryOption<UnknownProfile, IdentoryError>.Error(new IdentoryError(ex.Message));
            }
        }

        public Task<IdentoryOption<MobileProfile, IdentoryError>> UpsertProfile(MobileProfile profile) => UpsertProfile<MobileProfile>(profile);
        public Task<IdentoryOption<DesktopProfile, IdentoryError>> UpsertProfile(DesktopProfile profile) => UpsertProfile<DesktopProfile>(profile);

        public async Task<IdentoryOption<ProfileType, IdentoryError>> UpsertProfile<ProfileType>(ProfileType profile) where ProfileType : IdentoryProfile
        {
            try
            {
                var serializedProfile = JsonConvert.SerializeObject(profile);
                var httpContent = new StringContent(serializedProfile, Encoding.UTF8, "application/json");

                HttpResponseMessage? result;

                if (profile.ProfileId != null)
                {
                    //Profile already has a id. We have to updated it.
                    result = await HttpClient.PutAsync($"{Endpoint}/profiles/{profile.ProfileId}", httpContent);
                }
                else
                {
                    //Profile doesn't have id. We need to insert it.
                    result = await HttpClient.PostAsync($"{Endpoint}/profiles", httpContent);
                }

                return VerifyResponse(result).Match<IdentoryOption<ProfileType, IdentoryError>>(successful =>
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    var token = JToken.Parse(response);

                    if (token.Type == JTokenType.Object)
                    {
                        var obj = token as JObject;

                        if (obj != null)
                        {
                            return IdentoryOption<ProfileType, IdentoryError>.Successful(obj.ToObject<ProfileType>());
                        }
                    }

                    return IdentoryOption<ProfileType, IdentoryError>.Error(new IdentoryError("Unable to cast object."));
                },
               error =>
               {
                   return IdentoryOption<ProfileType, IdentoryError>.Error(error);
               });
            }
            catch (Exception ex)
            {
                return IdentoryOption<ProfileType, IdentoryError>.Error(new IdentoryError(ex.Message));
            }

        }

        public async Task<bool> DeleteProfile(string profileId)
        {
            HttpResponseMessage? result;

            try
            {
                result = await HttpClient.DeleteAsync($"{Endpoint}/profiles/{profileId}");
            }
            catch (Exception)
            {
                return false;
            }

            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        public async Task<bool> StopProfile(string profileId)
        {
            HttpResponseMessage? result;

            try
            {
                result = await HttpClient.PostAsync($"{Endpoint}/profiles/{profileId}/stop", null);

            }
            catch (Exception)
            {
                return false;
            }

            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<IdentoryOption<BrowserStart, IdentoryError>> StartProfile(string profileId)
        {
            try
            {
                var result = await HttpClient.PostAsync($"{Endpoint}/profiles/{profileId}/start", null);

                return VerifyResponse(result).Match(successful =>
                {
                    var response = result.Content.ReadAsStringAsync().Result;

                    var token = JToken.Parse(response);

                    if (token.Type == JTokenType.Object)
                    {
                        var obj = token as JObject;

                        if (obj != null)
                        {
                            return IdentoryOption<BrowserStart, IdentoryError>.Successful(obj.ToObject<BrowserStart>());
                        }
                    }

                    return IdentoryOption<BrowserStart, IdentoryError>.Error(new IdentoryError("Unable to cast object."));
                },
                error =>
                {
                    return IdentoryOption<BrowserStart, IdentoryError>.Error(error);
                });

            }
            catch (Exception ex)
            {
                return IdentoryOption<BrowserStart, IdentoryError>.Error(new IdentoryError(ex.Message));
            }
        }

        public async Task<IdentoryOption<NewPage, IdentoryError>> CreateNewPage(string profileId)
        {
            try
            {
                var result = await HttpClient.PostAsync($"{Endpoint}/profiles/{profileId}/new-page", null);

                return VerifyResponse(result).Match(successful =>
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    var token = JToken.Parse(response);

                    if (token.Type == JTokenType.Object)
                    {
                        var obj = token as JObject;

                        if (obj != null)
                        {
                            return IdentoryOption<NewPage, IdentoryError>.Successful(obj.ToObject<NewPage>());
                        }
                    }

                    return IdentoryOption <NewPage, IdentoryError>.Error(new IdentoryError("Unable to cast object."));
                },
                error =>
                {
                    return IdentoryOption<NewPage, IdentoryError>.Error(error);
                });
            }
            catch (Exception ex)
            {
                return IdentoryOption<NewPage, IdentoryError>.Error(new IdentoryError(ex.Message));
            }

        }

        public async Task<IdentoryOption<byte[], IdentoryError>> ExportProfile(string profileId)
        {
            try
            {
                var exportPath = Path.Combine(Directory.GetCurrentDirectory(), profileId + ".zip");
                var serializedRequest = JsonConvert.SerializeObject(new ExportProfile(exportPath));
                var httpContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
                var result = await HttpClient.PostAsync($"{Endpoint}/profiles/{profileId}/export", httpContent);

                return VerifyResponse(result).Match(successful =>
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    var token = JToken.Parse(response);

                    if (token.Type == JTokenType.Object)
                    {
                        var obj = token as JObject;

                        if (obj != null)
                        {
                            //Successful export.
                            var allBytes = File.ReadAllBytes(exportPath);
                            File.Delete(exportPath);
                            return IdentoryOption<byte[], IdentoryError>.Successful(allBytes);
                        }
                    }

                    return IdentoryOption<byte[], IdentoryError>.Error(new IdentoryError("Unable to cast object."));
                },
                error =>
                {
                    return IdentoryOption<byte[], IdentoryError>.Error(error);
                });
            }
            catch (Exception ex)
            {
                return IdentoryOption<byte[], IdentoryError>.Error(new IdentoryError(ex.Message));
            }
        }

        public async Task<IdentoryOption<IdentoryProfile, IdentoryError>> ImportProfile(byte[] exportedProfileAsZip)
        {
            try
            {
                Guid randomId = Guid.NewGuid();
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), randomId + ".zip");
                File.WriteAllBytes(savePath, exportedProfileAsZip);

                var serializedRequest = JsonConvert.SerializeObject(new ImportProfile(savePath));
                var httpContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

                var result = await HttpClient.PostAsync($"{Endpoint}/profiles/import", httpContent);

                return VerifyResponse(result).Match(successful =>
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    var token = JToken.Parse(response);

                    if (token.Type == JTokenType.Object)
                    {
                        var obj = token as JObject;

                        if (obj != null)
                        {
                            return IdentoryOption<IdentoryProfile, IdentoryError>.Successful(obj.ToObject<IdentoryProfile>());
                        }
                    }

                    return IdentoryOption<IdentoryProfile, IdentoryError>.Error(new IdentoryError("Unable to cast object."));
                },
               error =>
               {
                   return IdentoryOption<IdentoryProfile, IdentoryError>.Error(error);
               });
            }
            catch (Exception ex)
            {
                return IdentoryOption<IdentoryProfile, IdentoryError>.Error(new IdentoryError(ex.Message));
            }
        }
    }
}

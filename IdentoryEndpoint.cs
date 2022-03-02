using Identory.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace Identory
{
    public abstract class IdentoryEndpoint
    {
        internal IdentoryEndpoint(string endpoint)
        {
            Endpoint = endpoint;
            HttpClient = new HttpClient();
        }

        protected string Endpoint { get; }
        protected HttpClient HttpClient { get; }

        protected IdentoryOption<HttpResponseMessage, IdentoryError> VerifyResponse(HttpResponseMessage responseMessage)
        {
            switch (responseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.OK: return IdentoryOption<HttpResponseMessage, IdentoryError>.Successful(responseMessage);
                case System.Net.HttpStatusCode.BadRequest: return IdentoryOption<HttpResponseMessage, IdentoryError>.Error(JsonConvert.DeserializeObject<IdentoryError>(responseMessage.Content.ToString()));
                default: return IdentoryOption<HttpResponseMessage, IdentoryError>.Error(new IdentoryError(responseMessage.StatusCode.ToString(), responseMessage.Content is null ? null : responseMessage.Content.ToString()));
            }
        }
    }
}

using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public sealed class NewPage
    {
        public NewPage()
        {

        }

        public NewPage(string pageId)
        {
            PageId = pageId;
        }

        [JsonProperty("targetId")]
        public string PageId { get; set; }
    }
}

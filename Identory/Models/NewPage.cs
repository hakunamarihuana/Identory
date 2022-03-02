using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public sealed class NewPage
    {
        internal NewPage()
        {
        }

        internal NewPage(string pageId)
        {
            PageId = pageId;
        }

        [JsonProperty("targetId")]
        public string PageId { get; set; }
    }
}

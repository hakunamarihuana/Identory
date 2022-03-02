using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public class ExportProfile
    {
        public ExportProfile()
        {

        }
        public ExportProfile(string filePath)
        {
            FilePath = filePath;
        }

        [JsonProperty("filePath")]
        public string FilePath { get; set; }
    }
}

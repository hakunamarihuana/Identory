using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public class ImportProfile
    {
        public ImportProfile()
        {

        }

        public ImportProfile(string filePath)
        {
            FilePath = filePath;
        }

        [JsonProperty("filePath")]
        public string FilePath { get; set; }
    }
}

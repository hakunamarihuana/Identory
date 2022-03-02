using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public class IdentoryError
    {
        public IdentoryError()
        {
        }

        internal IdentoryError(string message, params string[]? errors)
        {
            Message = message;
            Errors = errors;
        }

        internal IdentoryError(string message, Exception? exception)
        {
            Message = message;
            Exception = exception;
        }

        [JsonProperty("message")]
        public string Message { get; private set; }

        [JsonProperty("errors")]
        public string[]? Errors { get; private set; }
        [JsonIgnore]
        public Exception? Exception { get; private set; }
    }
}

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = DeflateCompressedResponse.FromJson(jsonString);
//
namespace QuickType
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class DeflateCompressedResponse
    {
        [JsonProperty("deflated")]
        public bool Deflated { get; set; }

        [JsonProperty("headers")]
        public Headers Headers { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }

    public partial class Headers
    {
        [JsonProperty("accept")]
        public string Accept { get; set; }

        [JsonProperty("accept-encoding")]
        public string AcceptEncoding { get; set; }

        [JsonProperty("cache-control")]
        public string CacheControl { get; set; }

        [JsonProperty("cookie")]
        public string Cookie { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("postman-token")]
        public string PostmanToken { get; set; }

        [JsonProperty("user-agent")]
        public string UserAgent { get; set; }

        [JsonProperty("x-forwarded-port")]
        public string XForwardedPort { get; set; }

        [JsonProperty("x-forwarded-proto")]
        public string XForwardedProto { get; set; }
    }

    public partial class DeflateCompressedResponse
    {
        public static DeflateCompressedResponse FromJson(string json) => JsonConvert.DeserializeObject<DeflateCompressedResponse>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DeflateCompressedResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
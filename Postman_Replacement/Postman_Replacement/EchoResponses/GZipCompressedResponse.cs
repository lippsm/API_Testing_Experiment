// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = GZipCompressedResponse.FromJson(jsonString);
//
namespace QuickType
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class GZipCompressedResponse
    {
        [JsonProperty("gzipped")]
        public bool Gzipped { get; set; }

        [JsonProperty("headers")]
        public Headers Headers { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }

    public partial class GZipCompressedResponse
    {
        public static GZipCompressedResponse FromJson(string json) => JsonConvert.DeserializeObject<GZipCompressedResponse>(json, Converter.Settings);
    }

    /* NOTE: The original code pulled in from QuickType included a partial class called headers, but
     * I removed it because the same partial class was already contained within DeflateCompressedResponse,
     * which is also contained within the QuickType namespace
     */
}

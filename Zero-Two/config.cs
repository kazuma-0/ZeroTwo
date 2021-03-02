namespace Zero_Two
{

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Globalization;

    public partial class Conf
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("rapidApiKey")]
        public string RapidApiKey { get; set; }
    }

    public partial class Conf
    {
        public static Conf FromJson(string json) => JsonConvert.DeserializeObject<Conf>(json, Zero_Two.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Conf self) => JsonConvert.SerializeObject(self, Zero_Two.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

namespace Zero_Two.models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Globalization;

    public partial class NyaaModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("seeders")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Seeders { get; set; }

        [JsonProperty("leechers")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Leechers { get; set; }

        [JsonProperty("downloads")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Downloads { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("trusted")]
        public Trusted Trusted { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

    public enum Category { AnimeEnglishTranslated, AnimeNonEnglishTranslated, LiteratureNonEnglishTranslated };

    public enum Description { AnimeEnglishTranslated, AnimeNonEnglishTranslated, LiteratureNonEnglishTranslated };

    public enum Trusted { No, Yes };

    public partial class NyaaModel
    {
        public static NyaaModel[] FromJson(string json)
        {
            return JsonConvert.DeserializeObject<NyaaModel[]>(json, Converter.Settings);
        }
    }

    public static partial class Serialize
    {
        public static string ToJson(this NyaaModel[] self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    internal static partial class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CategoryConverter.Singleton,
                DescriptionConverter.Singleton,
                TrustedConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(Category) || t == typeof(Category?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Anime - English-translated":
                    return Category.AnimeEnglishTranslated;
                case "Anime - Non-English-translated":
                    return Category.AnimeNonEnglishTranslated;
                case "Literature - Non-English-translated":
                    return Category.LiteratureNonEnglishTranslated;
            }
            throw new Exception("Cannot unmarshal type Category");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Category)untypedValue;
            switch (value)
            {
                case Category.AnimeEnglishTranslated:
                    serializer.Serialize(writer, "Anime - English-translated");
                    return;
                case Category.AnimeNonEnglishTranslated:
                    serializer.Serialize(writer, "Anime - Non-English-translated");
                    return;
                case Category.LiteratureNonEnglishTranslated:
                    serializer.Serialize(writer, "Literature - Non-English-translated");
                    return;
            }
            throw new Exception("Cannot marshal type Category");
        }

        public static readonly CategoryConverter Singleton = new CategoryConverter();
    }

    internal class DescriptionConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(Description) || t == typeof(Description?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case " Anime - English-translated ":
                    return Description.AnimeEnglishTranslated;
                case " Anime - Non-English-translated ":
                    return Description.AnimeNonEnglishTranslated;
                case " Literature - Non-English-translated ":
                    return Description.LiteratureNonEnglishTranslated;
            }
            throw new Exception("Cannot unmarshal type Description");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Description)untypedValue;
            switch (value)
            {
                case Description.AnimeEnglishTranslated:
                    serializer.Serialize(writer, " Anime - English-translated ");
                    return;
                case Description.AnimeNonEnglishTranslated:
                    serializer.Serialize(writer, " Anime - Non-English-translated ");
                    return;
                case Description.LiteratureNonEnglishTranslated:
                    serializer.Serialize(writer, " Literature - Non-English-translated ");
                    return;
            }
            throw new Exception("Cannot marshal type Description");
        }

        public static readonly DescriptionConverter Singleton = new DescriptionConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(long) || t == typeof(long?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class TrustedConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(Trusted) || t == typeof(Trusted?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "No":
                    return Trusted.No;
                case "Yes":
                    return Trusted.Yes;
            }
            throw new Exception("Cannot unmarshal type Trusted");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Trusted)untypedValue;
            switch (value)
            {
                case Trusted.No:
                    serializer.Serialize(writer, "No");
                    return;
                case Trusted.Yes:
                    serializer.Serialize(writer, "Yes");
                    return;
            }
            throw new Exception("Cannot marshal type Trusted");
        }

        public static readonly TrustedConverter Singleton = new TrustedConverter();
    }
}
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zero_Two.Commands
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Translation
    {
        [JsonProperty("translatedText")]
        public string TranslatedText { get; set; }

        [JsonProperty("detectedSourceLanguage")]
        public string DetectedSourceLanguage { get; set; }
    }

    public class Data
    {
        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }
    }

    public class Root
    {

        [JsonProperty("data")]
        public Data Data { get; set; }
    }


}
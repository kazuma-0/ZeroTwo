using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
namespace Zero_Two.Commands
{

    public class translate : BaseCommandModule
    {
        [Command("translate")]
        public async Task Translate(CommandContext ctx, params string[] message)
        {
            string mess = string.Join(" ", message);
            var en = new translateApi();
            Root obj = JsonConvert.DeserializeObject<Root>(en.val(mess));
            await ctx.Channel.SendMessageAsync(obj.Data.Translations[0].TranslatedText.ToString());
        }

        private class translateApi
        {
            public dynamic val(string test)
            {
                var client = new RestClient("https://google-translate1.p.rapidapi.com/language/translate/v2");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddHeader("accept-encoding", "application/gzip");
                request.AddHeader("x-rapidapi-key", "rapidApiKey");
                request.AddHeader("x-rapidapi-host", "google-translate1.p.rapidapi.com");
                request.AddParameter("application/x-www-form-urlencoded", $"q={test}&target=en", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
        }

    }
}
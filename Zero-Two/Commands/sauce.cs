using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Mono.Web;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Zero_Two.Commands
{
    public class sauce : BaseCommandModule
    {
        [Command("sauce")]
        public async Task Sause(CommandContext ctx)
        {
            var api = new sauseApi();
            await ctx.Channel.SendMessageAsync(api.result(ctx.Message.Attachments[0].Url).ToString());
        }
        private class sauseApi
        {
            public dynamic result(string url)
            {
                String encodedUrl = HttpUtility.UrlEncode(url);
                var client = new RestClient($"https://google-reverse-image-search.p.rapidapi.com/imgSearch?url={encodedUrl}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-key", "");
                request.AddHeader("x-rapidapi-host", "google-reverse-image-search.p.rapidapi.com");
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
        }
    }
}
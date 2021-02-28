using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;
using unirest_net.http;
using Zero_Two.models;

namespace Zero_Two.Commands
{
    public class nyaa : BaseCommandModule
    {
        [Command("nyaa")]
        public async Task Nyaa(CommandContext ctx, string animeName)
        {
            Console.WriteLine("processing...");
            var http = Unirest.get($"https://api.nyaator.co/search?s={animeName}&l=10")
                .asJson<String>();
            var json = NyaaModel.FromJson(http.Body);

            //await ctx.Message.CreateReactionAsync(DiscordEmoji.FromName("ok_skin"));
            var embed = new DiscordEmbedBuilder()
            {
                Title = "Nyaa"
            };
            foreach (var anime in json)
            {
                embed.AddField(anime.Name,
                    $@"[link](https://m.subby.dev/?redirect={anime.Link}) {System.Environment.NewLine}size: `{anime.Size}` seeders: `{anime.Seeders}` category: `{anime.Category}`",
                    false);

            }
            await ctx.Channel.SendMessageAsync(embed.Build());
            //await ctx.Channel.SendMessageAsync("hi");
        }
    }
}
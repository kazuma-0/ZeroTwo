using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Zero_Two.Commands
{
    public class help : BaseCommandModule
    {
        [Command("help")]
        public async Task Help(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder()
            {
                Title = "Help",
                Description = "Kon'nichiwa! Zero Two des\n**Commands**"
            };
            embed.AddField("Say <message>", "I repeat the message");
            embed.AddField("translate <text>", "I translate any given text to English");
            embed.AddField("nyaa <query>", "Search queries from Nyaa.si");
            embed.Color = DiscordColor.HotPink;
            embed.Footer = new DiscordEmbedBuilder.EmbedFooter()
            {
                IconUrl = "https://cdn.discordapp.com/attachments/740615123869237320/740622639734980753/unknown.png",
                Text = "© 12020 HE | Zero Two"
            };
            embed.Author = new DiscordEmbedBuilder.EmbedAuthor()
            {
                Name = ctx.Client.CurrentUser.Username,
                IconUrl = ctx.Client.CurrentUser.AvatarUrl
            };
            await ctx.Channel.SendMessageAsync(embed.Build());
        }
    }
}
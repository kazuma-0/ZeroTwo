using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Zero_Two.Commands
{
    public class ping : BaseCommandModule
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Pong! `{ctx.Client.Ping.ToString()}ms`");
        }
    }
}
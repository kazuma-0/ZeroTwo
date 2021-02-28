using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
namespace Zero_Two.Commands
{
    public class say : BaseCommandModule
    {
        [Command("say")]
        public async Task sayCommand(CommandContext ctx, params string[] message)
        {
            await ctx.Message.DeleteAsync();
            await ctx.Channel.SendMessageAsync(string.Join(" ", message)).ConfigureAwait(false);
        }

    }
}
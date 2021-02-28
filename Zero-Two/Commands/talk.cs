using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using System.Threading.Tasks;

namespace Zero_Two.Commands
{
    public class talk : BaseCommandModule
    {
        [Command("talk")]
        public async Task Talk(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            var interactivity = ctx.Client.GetInteractivity();
            for (int i = 0; i < 10; i++)
            {
                var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel & x.Author == ctx.Message.Author);
                await message.Result.DeleteAsync();
                if (message.Result.Content == "exit")
                {
                    break;
                }
                else
                {
                    await ctx.Channel.SendMessageAsync(message.Result.Content);
                }
            }
        }
    }
}

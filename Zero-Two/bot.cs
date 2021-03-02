using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.IO;
using System.Threading.Tasks;
using Zero_Two.Commands;

namespace Zero_Two
{
    public class bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension commands { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public string RapidApiKey { get; private set; }
        public async Task runAsync()
        {
            var jsonstr = File.ReadAllText("config.json");
            var vars = Conf.FromJson(jsonstr);
            //discord client config
            var config = new DiscordConfiguration()
            {
                Token = vars.Token,//bot token here.
                TokenType = TokenType.Bot,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,
            };
            //commands next config
            var commandsNextConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "," },
                EnableDefaultHelp = false,

            };
            RapidApiKey = vars.RapidApiKey;
            Client = new DiscordClient(config);//client 
            var commands = Client.UseCommandsNext(commandsNextConfig);
            var interactivityConfig = new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(1)
            };
            Client.UseInteractivity(interactivityConfig);
            //connecting
            Client.Ready += client_Onready;
            commands.RegisterCommands<say>();
            commands.RegisterCommands<nyaa>();
            commands.RegisterCommands<talk>();
            commands.RegisterCommands<ping>();
            commands.RegisterCommands<translate>();
            //commands.RegisterCommands<sauce>(); disabled.
            Client.GuildMemberAdded += clientMemberAdd;
            Client.GuildMemberRemoved += MemberRemoved;

            commands.RegisterCommands<help>();
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task client_Onready(DiscordClient sender, ReadyEventArgs e)
        {
            Console.WriteLine($"connected as {sender.CurrentUser.Username}");
            return Task.CompletedTask;
        }
        private async Task clientMemberAdd(DiscordClient client, GuildMemberAddEventArgs e)
        {
            int count = 0;
            int botCount = 0;
            var GuildID = e.Guild.Id;
            ulong PrimaryGuildID = 690933830600622152;
            var mem = await e.Guild.GetAllMembersAsync();

            if (PrimaryGuildID == GuildID)
            {
                foreach (var i in mem)
                {
                    if (i.IsBot == true)
                    { botCount++; }
                    else { count++; }

                    var memberChannel = e.Guild.GetChannel(691007186813321417);
                    await memberChannel.ModifyAsync(x => x.Name = $"Ningen Members: {count}");
                    var botChannel = e.Guild.GetChannel(691008005176557678);
                    await botChannel.ModifyAsync(y => y.Name = $"Bots: {botCount}");
                }
            }
        }
        private async Task MemberRemoved(DiscordClient Client, GuildMemberRemoveEventArgs e)
        {
            int count = 0;
            int botCount = 0;
            var GuildID = e.Guild.Id;
            ulong PrimaryGuildID = 690933830600622152;
            var mem = await e.Guild.GetAllMembersAsync();

            if (PrimaryGuildID == GuildID)
            {
                foreach (var i in mem)
                {
                    if (i.IsBot == true)
                    { botCount++; }
                    else { count++; }

                    var memberChannel = e.Guild.GetChannel(691007186813321417);
                    await memberChannel.ModifyAsync(x => x.Name = $"Ningen Members: {count}");
                    var botChannel = e.Guild.GetChannel(691008005176557678);
                    await botChannel.ModifyAsync(y => y.Name = $"Bots: {botCount}");
                }
            }
        }
    }
}
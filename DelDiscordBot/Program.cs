using DelDiscordBot.config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelDiscordBot
{
    internal class Program
    {
        //Getting the main discord settings, client and commands
        private static DiscordClient Client { get; set; }
        private static CommandsNextConfiguration Commands { get; set; }

        //Our main will be a task that will loop every time it is connected to the token 

        static async Task Main(string[] args)
        {
            try { 

            var JsonReader = new JSONReader();
            await JsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = JsonReader.token,   
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            //Instantiating a variable so that it has the new settings
            Client = new DiscordClient(discordConfig);
            Client.Ready += Client_Ready; //It's adding an event handler for the Discord client's Ready event.

            await Client.ConnectAsync();
            await Task.Delay(-1);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}

using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DSharpPlus;

namespace DelDiscordBot.commands
{
    internal class TextCommands : BaseCommandModule
    {
        private static HashSet<ulong> usersWhoExecutedSCommand = new HashSet<ulong>();

        [Command("C")]
        [Description("Clears all messages in the current channel.")]
        public async Task Clear(CommandContext ctx)
        {
            // Permissions
            if (!ctx.Member.PermissionsIn(ctx.Channel).HasPermission(Permissions.ManageMessages))
            {
                await ctx.RespondAsync("You do not have permission to clear messages in this channel.");
                return;
            }

            // Catch all the messages from the channel
            var messages = await ctx.Channel.GetMessagesAsync();

            // See the messages and delete them
            foreach (var message in messages)
            {
                await message.DeleteAsync();
            }

            // Send a Confirmation!
            await ctx.RespondAsync("All messages in this channel have been cleaned.");

        }


        [Command("T")]
        [Description("Creates a new text channel within the server.")]
        public async Task NewTextChannel(CommandContext ctx, String channelname)
        {

            // Permissions
            if (!ctx.Member.PermissionsIn(ctx.Channel).HasPermission(Permissions.ManageChannels))
            {
                await ctx.RespondAsync("You do not have permission to manage channel in this server.");
                return;
            }

            //Validating input
            if (channelname.Equals(string.Empty))
            {
                await ctx.RespondAsync("You did not specify a channel name. Try again!");
                return;
            }

            if (channelname.Equals(""))
            {
                await ctx.RespondAsync("You forgot to specify a name for the new text channel!");
                return;
            }
            await ctx.Guild.CreateChannelAsync(channelname, ChannelType.Text);


            // Send a Confirmation!
            await ctx.RespondAsync("Text channel \"" + channelname + "\" created.");
        }

        [Command("V")]
        [Description("Creates a new voice channel within the server.")]
        public async Task NewVoiceChannel(CommandContext ctx, String channelname = "")
        {

                // Permissions
                if (!ctx.Member.PermissionsIn(ctx.Channel).HasPermission(Permissions.ManageChannels))
                {
                    await ctx.RespondAsync("You do not have permission to manage channel in this server.");
                    return;
                }

                if (channelname.Equals("")){
                    await ctx.RespondAsync("You forgot to specify a name for the new voice channel!");
                    return;
            }
            await ctx.Guild.CreateChannelAsync(channelname, ChannelType.Voice);
                

            // Send a Confirmation!
            await ctx.RespondAsync("Voice channel \"" + channelname + "\" created.");

            
        }

        [Command("Spam")]
        [Description("Spawn a lot (a lot) of messages!")]
        public async Task SpamMessages(CommandContext ctx, int quantity = 20)
        {

            // SPAMMMM!
            for (int i = 1; i <= quantity; i++) { 
            await ctx.RespondAsync("Message "+i+" :SPAMMMMMM MUAHAHAHAHAHA");
            }

        }

        [Command("R")]
        [Description("Delete and create a new channel with the same name, in the same category.")]
        public async Task RecreateChannel(CommandContext ctx, String channelName, String categoryName, String channelType)
        {       
         //  Check if channel is in a category
   //       var category = ctx.Guild.Channels.cache.find(c => c.type == "category" && c.name == categoryName);

       //    if (!category)
          {
               await ctx.RespondAsync("Category was not found!");
               return;
           }

            //Delete channel
            await ctx.Channel.DeleteAsync();

            // TO-DO: Create a channel with the same name, in the same category

        }
        [Command("S")]
        [Description("Task to delete messages everyday at 11:45pm")]
        public async Task ScheduleDelete(CommandContext ctx)
        {
            var horaAtual = DateTime.Now;
            var horaAgendada = new TimeSpan(11, 45, 0);

            if (usersWhoExecutedSCommand.Contains(ctx.User.Id))
            {
                await ctx.RespondAsync("You have already run this command. Messages will be deleted as scheduled.");
                return;
            }

            // Add in the colletion hashset the user as having executed the command
            usersWhoExecutedSCommand.Add(ctx.User.Id);
        

            if (horaAtual.Hour == horaAgendada.Hours && horaAtual.Minute == horaAgendada.Minutes)
            {
                await ctx.RespondAsync("Messages will be deleted at the scheduled time, 11:45 pm!");
                await Task.Delay(1000);
                await Clear(ctx);
            }  else
            {
                await ctx.RespondAsync("Messages will be deleted at the scheduled time, 11:45 pm!");
            }
        }
    }
} 
  
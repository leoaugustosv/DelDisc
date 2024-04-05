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

            //To-do: Validating input!!!

            await ctx.Guild.CreateChannelAsync(channelname, ChannelType.Text);


            // Send a Confirmation!
            await ctx.RespondAsync("Text channel \"" + channelname + "\" created.");
        }

        [Command("V")]
        [Description("Creates a new voice channel within the server.")]
        public async Task NewVoiceChannel(CommandContext ctx, String channelname)
        {

                // Permissions
                if (!ctx.Member.PermissionsIn(ctx.Channel).HasPermission(Permissions.ManageChannels))
                {
                    await ctx.RespondAsync("You do not have permission to manage channel in this server.");
                    return;
                }

                //To-do: Validating input!!!


                await ctx.Guild.CreateChannelAsync(channelname, ChannelType.Voice);


                // Send a Confirmation!
                await ctx.RespondAsync("Voice channel \"" + channelname + "\" created.");

            
        }
    }

}
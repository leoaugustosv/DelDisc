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
        [Command("Clear")]
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
    }
}


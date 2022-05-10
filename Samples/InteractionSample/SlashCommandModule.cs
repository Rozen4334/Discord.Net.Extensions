using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionSample
{
    public class SlashCommandModule : InteractionModuleBase<SocketInteractionContext<SocketSlashCommand>>
    {
        [SlashCommand("ping", "Pong")]
        public async Task PingAsync()
            => await RespondAsync("pong");
    }
}

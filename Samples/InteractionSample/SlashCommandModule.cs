using Discord.Interactions;
using Discord.WebSocket;

namespace InteractionSample
{
    public class SlashCommandModule : InteractionModuleBase<SocketInteractionContext<SocketSlashCommand>>
    {
        [SlashCommand("ping", "Pong")]
        public async Task PingAsync()
            => await RespondAsync("pong");
    }
}

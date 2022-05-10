using Discord;
using Discord.Extensions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryExample
{
    internal class ReusableEmbedSender
    {
        private readonly EmbedBuilderFactory _factory;
        private readonly DiscordSocketClient _client;
        private readonly System.Timers.Timer _timer;

        private ITextChannel _channel = null!;

        public ReusableEmbedSender(EmbedBuilderFactory factory, DiscordSocketClient client)
        {
            _factory = factory;
            _timer = new()
            {
                Interval = 10000,
                AutoReset = true
            };
            _client = client;
        }

        public async Task StartAsync(ulong channelId)
        {
            _timer.Elapsed += OnElapse;
            _timer.Start();

            var channel = await _client.GetChannelAsync(channelId);
            if (channel is not ITextChannel textChannel)
                throw new ArgumentException($"Channel with id {channelId} not found.", nameof(channelId));
            else
                _channel = textChannel;
        }

        private async void OnElapse(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var eb = _factory.Generate();

            eb.WithDescription("Test");

            await _channel.SendMessageAsync(embed: eb.Build());
        }
    }
}

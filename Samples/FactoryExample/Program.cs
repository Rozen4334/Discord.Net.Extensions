using Discord;
using Discord.Extensions;
using Discord.WebSocket;
using FactoryExample;
using Microsoft.Extensions.DependencyInjection;

var factorySettings = new BuilderSettings<EmbedBuilder>(x =>
{
    x.AddField("Look:", "This field will always appear!");
});

var discordSettings = new DiscordSocketConfig()
{
    AlwaysDownloadUsers = true,
    GatewayIntents = GatewayIntents.AllUnprivileged,
};

using var services = new ServiceCollection()
    .AddSingleton(discordSettings)
    .AddSingleton<DiscordSocketClient>()
    .AddSingleton(factorySettings)
    .AddSingleton<EmbedBuilderFactory>()
    .AddSingleton<ReusableEmbedSender>()
    .BuildServiceProvider();

await services.GetRequiredService<ReusableEmbedSender>()
    .StartAsync(1ul); // fill in a channel ID here.

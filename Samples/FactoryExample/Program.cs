using Discord;
using Discord.Extensions;
using Discord.WebSocket;
using FactoryExample;
using Microsoft.Extensions.DependencyInjection;

var factorySettings = new BuilderSettings<ExampleType, EmbedBuilder>()
    .AddAction(ExampleType.Default, x => x.AddField("The default embed", "This is generated when generating an embed with 'ExampleType.Default' as key."));

var discordSettings = new DiscordSocketConfig()
{
    AlwaysDownloadUsers = true,
    GatewayIntents = GatewayIntents.AllUnprivileged,
};

using var services = new ServiceCollection()
    .AddSingleton(discordSettings)
    .AddSingleton<DiscordSocketClient>()
    .AddSingleton(factorySettings)
    .AddSingleton<EmbedBuilderFactory<ExampleType>>()
    .AddSingleton<ReusableEmbedSender>()
    .BuildServiceProvider();

await services.GetRequiredService<ReusableEmbedSender>()
    .StartAsync(1ul); // fill in a channel ID here.

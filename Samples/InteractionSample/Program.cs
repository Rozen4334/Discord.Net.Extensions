using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

var discordSettings = new DiscordSocketConfig()
{
    AlwaysDownloadUsers = true,
    GatewayIntents = GatewayIntents.AllUnprivileged,
};

var interactionSettings = new InteractionServiceConfig()
{
    UseCompiledLambda = true,
    DefaultRunMode = RunMode.Async
};

using var services = new ServiceCollection()
    .AddSingleton(discordSettings)
    .AddSingleton<DiscordSocketClient>()
    .AddSingleton(interactionSettings)
    .AddSingleton<InteractionService>()
    .BuildServiceProvider();

var interactionService = services.GetRequiredService<InteractionService>();

interactionService.AddModulesAsync(typeof(Program).Assembly, services);

var discordClient = services.GetRequiredService<DiscordSocketClient>();

discordClient.Ready += async () =>
{
    await interactionService.RegisterCommandsGloballyAsync(true);
};

discordClient.InteractionCreated += async (i) =>
{
    var ctx = interaction.CreateGenericContext(discordClient);

    await interactionService.ExecuteCommandAsync(ctx, services);
};

discordClient.Log += LogAsync;
interactionService.Log += LogAsync;

Task LogAsync(LogMessage arg)
{
    Console.WriteLine(arg);
    return Task.CompletedTask;
}
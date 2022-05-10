using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Discord.Extensions.Interactions;

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

await interactionService.AddModulesAsync(typeof(Program).Assembly, services);

var discordClient = services.GetRequiredService<DiscordSocketClient>();

await discordClient.LoginAsync(TokenType.Bot, ""); // token here.

discordClient.Ready += async () =>
{
    await interactionService.RegisterCommandsGloballyAsync(true);
};

discordClient.InteractionCreated += async (interaction) =>
{
    var ctx = interaction.GenerateGeneric(discordClient);

    await interactionService.ExecuteCommandAsync(ctx, services);
};

discordClient.Log += LogAsync;
interactionService.Log += LogAsync;

Task LogAsync(LogMessage arg)
{
    Console.WriteLine(arg);
    return Task.CompletedTask;
}

await discordClient.StartAsync();
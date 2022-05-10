using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="TypeConverter{T}"/> to convert slash command options to <see langword="ulong"/>.
    /// </summary>
    public class UlongTypeConverter : TypeConverter<ulong>
    {
        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            string @string = (option.Value as string)!;

            if (ulong.TryParse(@string, out ulong value))
                return Task.FromResult(TypeConverterResult.FromSuccess(value));
            
            return Task.FromResult(TypeConverterResult.FromError(
                error: InteractionCommandError.ConvertFailed,
                reason: "Unable to parse input string as ulong."));
        }
    }
}

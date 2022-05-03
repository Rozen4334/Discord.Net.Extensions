using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="TypeConverter{T}"/> that converts from string to emote.
    /// </summary>
    public class EmoteTypeConverter : TypeConverter<IEmote>
    {
        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            string @string = (option.Value as string) ?? "";

            return Task.FromResult(Utils.ConverterExtensions.ConvertEmote(@string));
        }
    }
}

using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A generic <see cref="TypeConverter{T}"/> that converts from string to emote.
    /// </summary>
    public class EmoteConverter : TypeConverter<IEmote>
    {
        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            string @string = (option.Value as string) ?? "";

            if (string.IsNullOrEmpty(@string))
                return Task.FromResult(TypeConverterResult.FromError(InteractionCommandError.ConvertFailed, "An empty or null string cannot be parsed into an emote."));

            if (Emote.TryParse(@string, out Emote emote))
                return Task.FromResult(TypeConverterResult.FromSuccess(emote));

            IEmote emoji = new Emoji(@string);

            if (string.IsNullOrEmpty(emoji.Name))
                return Task.FromResult(TypeConverterResult.FromError(InteractionCommandError.ConvertFailed, "The passed string is no emote."));

            return Task.FromResult(TypeConverterResult.FromSuccess(emoji));
        }
    }
}

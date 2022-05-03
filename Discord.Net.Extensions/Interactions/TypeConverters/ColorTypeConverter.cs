using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="TypeConverter{T}"/> to convert app command options into <see cref="Color"/>
    /// </summary>
    public class ColorTypeConverter : TypeConverter<Color>
    {
        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            var @string = (string)option.Value;

            return Task.FromResult(Utils.ConverterExtensions.ConvertColor(@string));
        }
    }
}

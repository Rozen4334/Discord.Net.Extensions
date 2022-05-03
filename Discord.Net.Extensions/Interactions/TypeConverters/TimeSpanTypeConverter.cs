using Discord.Extensions.Utils;
using Discord.Interactions;
using System.Text.RegularExpressions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A generic <see cref="TypeConverter{T}"/> that converts from string to timespan.
    /// </summary>
    public class TimeSpanTypeConverter : TypeConverter<TimeSpan>
    {
        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            var @string = (option.Value as string)!;
            var span = LazyTimeSpanConverter.GetSpan(@string);
            return Task.FromResult(TypeConverterResult.FromSuccess(span));
        }
    }
}

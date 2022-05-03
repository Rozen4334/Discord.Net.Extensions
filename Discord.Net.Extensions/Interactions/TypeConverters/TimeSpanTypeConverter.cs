using Discord.Extensions.Utils;
using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A generic <see cref="TypeConverter{T}"/> that converts slash command options to <see cref="TimeSpan"/>.
    /// </summary>
    public class TimeSpanTypeConverter : TypeConverter<TimeSpan>
    {
        private readonly List<TimeSpan> _errorSpans = new();

        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            var @string = (option.Value as string)!;
            var span = LazyTimeSpanConverter.GetSpan(@string);

            if (_errorSpans.Any(x => x == span))
                return Task.FromResult(TypeConverterResult.FromError(
                    error: InteractionCommandError.ConvertFailed,
                    reason: "Unable to convert input string to TimeSpan."));

            return Task.FromResult(TypeConverterResult.FromSuccess(span));
        }

        /// <summary>
        ///     Adds an error span to the converter. If the convertion result is the added value, it will error out. 
        ///     If none are added, everything will pass and automatically generate <see cref="TimeSpan.Zero"/>
        /// </summary>
        /// <param name="span">The <see cref="TimeSpan"/> to error out on.</param>
        /// <returns>The current instance with the new error span added.</returns>
        public TimeSpanTypeConverter AddError(TimeSpan span)
        {
            _errorSpans.Add(span);
            return this;
        }
    }
}

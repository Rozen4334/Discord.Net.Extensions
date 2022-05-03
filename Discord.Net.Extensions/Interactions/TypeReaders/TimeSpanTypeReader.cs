using Discord.Extensions.Utils;
using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="TypeReader{T}"/> to convert component wildcards into <see cref="TimeSpan"/>.
    /// </summary>
    public class TimeSpanTypeReader : TypeReader<TimeSpan>
    {
        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, string option, IServiceProvider services)
            => Task.FromResult(TypeConverterResult.FromSuccess(LazyTimeSpanConverter.GetSpan(option)));
    }
}

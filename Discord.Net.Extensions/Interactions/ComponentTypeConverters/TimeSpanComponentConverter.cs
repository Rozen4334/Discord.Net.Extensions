using Discord.Extensions.Utils;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="ComponentTypeConverter{T}"/> to convert modal parameters into <see cref="TimeSpan"/>.
    /// </summary>
    internal class TimeSpanComponentConverter : ComponentTypeConverter<TimeSpan>
    {
        private readonly List<TimeSpan> _errorSpans = new();

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IComponentInteractionData option, IServiceProvider services)
        {
            var span = LazyTimeSpanConverter.GetSpan(option.Value);

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
        public TimeSpanComponentConverter AddError(TimeSpan span)
        {
            _errorSpans.Add(span);
            return this;
        }
    }
}

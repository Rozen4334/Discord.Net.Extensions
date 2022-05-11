/*

MIT License

Copyright (c) 2022 Armano den Boef and Discord.Net.Extensions contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using Discord.Extensions.Internal;
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

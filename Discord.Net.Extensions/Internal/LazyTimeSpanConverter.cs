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

using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Discord.Extensions.Internal
{
    internal static class LazyTimeSpanConverter
    {
        private static readonly Lazy<IReadOnlyDictionary<string, Func<string, TimeSpan>>> _callback = new(ValueFactory);

        private static readonly Regex _regex = new(@"(\d*)\s*([a-zA-Z]*)\s*(?:and|,)?\s*", RegexOptions.Compiled);

        private static IReadOnlyDictionary<string, Func<string, TimeSpan>> ValueFactory()
        {
            var callback = ImmutableDictionary.CreateBuilder<string, Func<string, TimeSpan>>();
            callback["second"] = Seconds;
            callback["seconds"] = Seconds;
            callback["sec"] = Seconds;
            callback["s"] = Seconds;
            callback["minute"] = Minutes;
            callback["minutes"] = Minutes;
            callback["min"] = Minutes;
            callback["m"] = Minutes;
            callback["hour"] = Hours;
            callback["hours"] = Hours;
            callback["h"] = Hours;
            callback["day"] = Days;
            callback["days"] = Days;
            callback["d"] = Days;
            callback["week"] = Weeks;
            callback["weeks"] = Weeks;
            callback["w"] = Weeks;
            callback["month"] = Months;
            callback["months"] = Months;
            return callback.ToImmutable();
        }

        private static TimeSpan Seconds(string match)
            => new(0, 0, int.Parse(match));

        private static TimeSpan Minutes(string match)
            => new(0, int.Parse(match), 0);

        private static TimeSpan Hours(string match)
            => new(int.Parse(match), 0, 0);

        private static TimeSpan Days(string match)
            => new(int.Parse(match), 0, 0, 0);

        private static TimeSpan Weeks(string match)
            => new((int.Parse(match) * 7), 0, 0, 0);

        private static TimeSpan Months(string match)
            => new((int.Parse(match) * 30), 0, 0, 0);

        /// <summary>
        ///     Gets a timespan based on its string counterpart, almost like a tryparse.
        /// </summary>
        /// <param name="span">The string to pass.</param>
        /// <returns>A timespan. <see cref="TimeSpan.Zero"/> if nothing was found.</returns>
        public static TimeSpan GetSpan(this string span)
        {
            if (!TimeSpan.TryParse(span, out TimeSpan timeSpan))
            {
                span = span.ToLower().Trim();
                MatchCollection matches = _regex.Matches(span);
                if (matches.Any())
                    foreach (Match match in matches)
                        if (_callback.Value.TryGetValue(match.Groups[2].Value, out var result))
                            span += result(match.Groups[1].Value);
            }
            return timeSpan;
        }
    }
}

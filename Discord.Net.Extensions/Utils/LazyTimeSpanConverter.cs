using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Discord.Extensions.Utils
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

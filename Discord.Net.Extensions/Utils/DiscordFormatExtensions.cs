namespace Discord.Extensions.Utils
{
    /// <summary>
    ///     Provides a number of extensions for formatting Discord text.
    /// </summary>
    public static class DiscordFormatExtensions
    {
        /// <summary>
        /// Formats <paramref name="text"/> to bold markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to bold markdown.</param>
        /// <returns>The same <paramref name="text"/> with bold formatting.</returns>
        public static string ToBold(this string text) => $"**{text}**";
        
        /// <summary>
        /// Formats <paramref name="text"/> to italics markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to italics markdown.</param>
        /// <returns>The same <paramref name="text"/> with italics formatting.</returns>
        public static string ToItalics(this string text) => $"*{text}*";
        
        /// <summary>
        /// Formats <paramref name="text"/> to underline markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to underline markdown.</param>
        /// <returns>The same <paramref name="text"/> with underline formatting.</returns>
        public static string ToUnderline(this string text) => $"__{text}__";
        
        /// <summary>
        /// Formats <paramref name="text"/> to strikethrough markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to strikethrough markdown.</param>
        /// <returns>The same <paramref name="text"/> with strikethrough formatting.</returns>
        public static string ToStrikethrough(this string text) => $"~~{text}~~";
        
        /// <summary>
        /// Formats <paramref name="text"/> to spoiler markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to spoiler markdown.</param>
        /// <returns>The same <paramref name="text"/> with spoiler formatting.</returns>
        public static string ToSpoiler(this string text) => $"||{text}||";
        
        /// <summary>
        /// Formats <paramref name="text"/> to quote markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to quote markdown.</param>
        /// <returns>The same <paramref name="text"/> with quote formatting.</returns>
        public static string ToQuote(this string text) => $"> {text}";
        
        /// <summary>
        /// Formats <paramref name="text"/> to block quote markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to block quote markdown.</param>
        /// <returns>The same <paramref name="text"/> with block quote formatting.</returns>
        public static string ToBlockQuote(this string text) => $">>> {text}";

        /// <summary>
        /// Formats <paramref name="text"/> to code block markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to code block markdown.</param>
        /// <returns>The same <paramref name="text"/> with code block formatting.</returns>
        public static string ToCodeBlock(this string text) => $"`{text}`";
    }
}
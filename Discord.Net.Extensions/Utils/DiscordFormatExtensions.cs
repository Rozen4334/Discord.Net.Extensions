namespace Discord.Extensions.Utils
{
    /// <summary>
    ///     Provides a number of extensions for formatting discord text.
    /// </summary>
    public static class DiscordFormatExtensions
    {
        /// <summary>
        /// Format <see cref="text"/> to bold.
        /// </summary>
        /// <param name="text">Text which will be formatted.</param>
        /// <returns>The same <see cref="text"/> with bold formatting.</returns>
        public static string FormatToBold(this string text) => $"**{text}**";
        
        /// <summary>
        /// Format <see cref="text"/> to italics.
        /// </summary>
        /// <param name="text">Text which will be formatted.</param>
        /// <returns>The same <see cref="text"/> with italics formatting.</returns>
        public static string FormatToItalics(this string text) => $"*{text}*";
        
        /// <summary>
        /// Format <see cref="text"/> to underline.
        /// </summary>
        /// <param name="text">Text which will be formatted.</param>
        /// <returns>The same <see cref="text"/> with underline formatting.</returns>
        public static string FormatToUnderline(this string text) => $"__{text}__";
        
        /// <summary>
        /// Format <see cref="text"/> to strikethrough.
        /// </summary>
        /// <param name="text">Text which will be formatted.</param>
        /// <returns>The same <see cref="text"/> with strikethrough formatting.</returns>
        public static string FormatToStrikethrough(this string text) => $"~~{text}~~";
        
        /// <summary>
        /// Format <see cref="text"/> to spoiler.
        /// </summary>
        /// <param name="text">Text which will be formatted.</param>
        /// <returns>The same <see cref="text"/> with spoiler formatting.</returns>
        public static string FormatToSpoiler(this string text) => $"||{text}||";
        
        /// <summary>
        /// Format <see cref="text"/> to quote.
        /// </summary>
        /// <param name="text">Text which will be formatted.</param>
        /// <returns>The same <see cref="text"/> with quote formatting.</returns>
        public static string FormatToQuote(this string text) => $"> {text}";
        
        /// <summary>
        /// Format <see cref="text"/> to block quote.
        /// </summary>
        /// <param name="text">Text which will be formatted.</param>
        /// <returns>The same <see cref="text"/> with block quote formatting.</returns>
        public static string FormatToBlockQuote(this string text) => $">>> {text}";

        /// <summary>
        /// Format <see cref="text"/> to code block.
        /// </summary>
        /// <param name="text">Text which will be formatted.</param>
        /// <returns>The same <see cref="text"/> with code block formatting.</returns>
        public static string FormatToCodeBlock(this string text) => $"`{text}`";
    }
}
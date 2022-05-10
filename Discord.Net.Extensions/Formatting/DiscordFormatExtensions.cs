namespace Discord.Extensions
{
    /// <summary>
    ///     Provides a number of extensions for formatting Discord text.
    /// </summary>
    public static class DiscordFormatExtensions
    {
        /// <summary>
        ///     Formats <paramref name="text"/> to bold markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to bold markdown.</param>
        /// <returns>The same <paramref name="text"/> with bold formatting.</returns>
        public static string ToBold(this string text, int index = 0, int? count = null) //=> $"**{text}**";
        {
            var length = count ?? (text.Length - index);

            return text.Format($"**{text[index..(index + length)]}**", index, length);
        }

        /// <summary>
        ///     Formats <paramref name="text"/> to italics markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to italics markdown.</param>
        /// <returns>The same <paramref name="text"/> with italics formatting.</returns>
        public static string ToItalic(this string text, int index = 0, int? count = null) //=> $"*{text}*";
        {
            var length = count ?? (text.Length - index);

            return text.Format($"*{text[index..(index + length)]}*", index, length);
        }
        
        /// <summary>
        ///     Formats <paramref name="text"/> to underline markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to underline markdown.</param>
        /// <returns>The same <paramref name="text"/> with underline formatting.</returns>
        public static string ToUnderline(this string text, int index = 0, int? count = null) //=> $"__{text}__";
        {
            var length = count ?? (text.Length - index);

            return text.Format($"__{text[index..(index + length)]}__", index, length);
        }
        
        /// <summary>
        ///     Formats <paramref name="text"/> to strikethrough markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to strikethrough markdown.</param>
        /// <returns>The same <paramref name="text"/> with strikethrough formatting.</returns>
        public static string ToStrikethrough(this string text, int index = 0, int? count = null) //=> $"~~{text}~~";
        {
            var length = count ?? (text.Length - index);

            return text.Format($"~~{text[index..(index + length)]}~~", index, length);
        }
        
        /// <summary>
        ///     Formats <paramref name="text"/> to spoiler markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to spoiler markdown.</param>
        /// <returns>The same <paramref name="text"/> with spoiler formatting.</returns>
        public static string ToSpoiler(this string text, int index = 0, int? count = null) //=> $"||{text}||";
        {
            var length = count ?? (text.Length - index);

            return text.Format($"||{text[index..(index + length)]}||", index, length);
        }
        
        /// <summary>
        ///     Formats <paramref name="text"/> to quote markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to quote markdown.</param>
        /// <returns>The same <paramref name="text"/> with quote formatting.</returns>
        public static string ToQuote(this string text, int index = 0, int? count = null) //=> $"> {text}";
        {
            var length = count ?? (text.Length - index);

            return text.Format($"\n {text[index..(index + length)]}\n", index, length);
        }
        
        /// <summary>
        ///     Formats <paramref name="text"/> to block quote markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to block quote markdown.</param>
        /// <returns>The same <paramref name="text"/> with block quote formatting.</returns>
        public static string ToBlockQuote(this string text, int index = 0, int? count = null) //=> $">>> {text}";
        {
            var length = count ?? (text.Length - index);

            return text.Format($"\n>>> {text[index..(index + length)]}\n", index, length);
        }

        /// <summary>
        ///     Formats <paramref name="text"/> to code  markdown.
        /// </summary>
        /// <param name="text">The string to be formatted to code markdown.</param>
        /// <returns>The same <paramref name="text"/> with code formatting.</returns>
        public static string ToCode(this string text, int index = 0, int? count = null) //=> $"`{text}`";
        {
            var length = count ?? (text.Length - index);

            return text.Format($"`{text[index..(index + length)]}`", index, length);
        }

        /// <summary>
        ///     Formats part of <paramref name="text"/> to a markdown code block.
        /// </summary>
        /// <param name="text">The text of which part should format as code block.</param>
        /// <param name="index">The index at which the codeblock should start.</param>
        /// <param name="count">The amount of characters in the string to include in the code block. If left as <see langword="null"/>, it will take all characters.</param>
        /// <param name="lang">The language to set as markdown. If left as <see langword="null"/>, it will default to <see cref="CodeLanguage.None"/></param>
        /// <returns></returns>
        public static string ToCodeBlock(this string text, int index = 0, int? count = null, CodeLanguage? lang = null)
        {
            lang ??= CodeLanguage.None;

            var length = count ?? (text.Length - index);

            return text.Format($"```{lang.Value}\n{text[index..(index + length)]}\n```", index, length);
        }

        private static string Format(this string text, string format, int index, int length)
        {
            return text.Insert(index, format).Remove(index + format.Length, length);
        }
    }
}
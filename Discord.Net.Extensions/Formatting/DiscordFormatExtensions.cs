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
        /// <returns>The same <paramref name="text"/> with a codeblock formatted at provided <paramref name="index"/>, ranging until provided <paramref name="count"/>.</returns>
        public static string ToCodeBlock(this string text, CodeLanguage? lang = null, int index = 0, int? count = null)
        {
            lang ??= CodeLanguage.None;

            var length = count ?? (text.Length - index);

            return text.Format($"```{lang.Value}\n{text[index..(index + length)]}\n```", index, length);
        }

        /// <summary>
        ///     Embeds a link into a set of (or single) word(s).
        /// </summary>
        /// <remarks>
        ///     [Note] This format is only supported in <see cref="EmbedBuilder.Description"/>'s. Use <see cref="EmbedBuilder.WithDescription(string)"/> to insert the formatted string.
        /// </remarks>
        /// <param name="text">The text of which part should format as link.</param>
        /// <param name="url">The url to link to.</param>
        /// <param name="index">The index at which the link should start.</param>
        /// <param name="count">The amount of characters in the string to include in the link. If left as <see langword="null"/>, it will take all characters.</param>
        /// <returns>The same <paramref name="text"/> with a markdown embedded link at provided <paramref name="index"/>, ranging until provided <paramref name="count"/>.</returns>
        public static string ToHyperLink(this string text, string url, int index = 0, int? count = null)
        {
            var length = count ?? (text.Length - index);

            return text.Format($"[{text[index..(index + length)]}]({url})", index, length);
        }

        /// <summary>
        ///     Formats a header into the provided <paramref name="text"/>.
        /// </summary>
        /// <remarks>
        ///      [Note] This format is only supported in forum threads. Forums are currently not publically available.
        /// </remarks>
        /// <param name="text">The text of which part should format as header.</param>
        /// <param name="format">The format of the header.</param>
        /// <param name="index">The index at which the header should start.</param>
        /// <param name="count">The amount of characters in the string to include in the header. If left as <see langword="null"/>, it will take all characters.</param>
        /// <returns>The same <paramref name="text"/> with a markdown header at provided <paramref name="index"/>, ranging until provided <paramref name="count"/>.</returns>
        public static string ToHeader(this string text, HeaderFormat format, int index = 0, int? count = null)
        {
            var length = count ?? (text.Length - index);

            return text.Format($"\n{format.Format} {text[index..(index + length)]} \n", index, length);
        }

        private static string Format(this string text, string format, int index, int length)
        {
            return text.Insert(index, format).Remove(index + format.Length, length);
        }
    }
}
﻿/*

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
using System.Text;

namespace Discord.Extensions
{
    /// <summary>
    ///     Represents a builder to build Discord messages with markdown with.
    /// </summary>
    public class MessageBuilder
    {
        private readonly StringBuilder _builder;

        /// <summary>
        ///     Creates a new instance of <see cref="MessageBuilder"/>.
        /// </summary>
        public MessageBuilder()
        {
            _builder = new();
        }

        /// <summary>
        ///     Creates a new instance of <see cref="MessageBuilder"/> with a starting string appended.
        /// </summary>
        /// <param name="startingString">The string to start the builder with.</param>
        public MessageBuilder(string startingString)
        {
            _builder = new(startingString);
        }

        /// <summary>
        ///     Creates a new instance of <see cref="MessageBuilder"/> with a capacity and (optionally) max capacity defined.
        /// </summary>
        /// <param name="capacity">The init capacity of the underlying <see cref="StringBuilder"/>.</param>
        /// <param name="maxCapacity">The maximum capacity of the underlying <see cref="StringBuilder"/>.</param>
        public MessageBuilder(int capacity, int? maxCapacity = null)
        {
            if (maxCapacity is not null)
                _builder = new(capacity, maxCapacity.Value);
            else
                _builder = new(capacity);
        }

        /// <summary>
        ///     Adds a header to the builder.
        /// </summary>
        /// <remarks>
        ///     [Note] Headers are only supported in forums, which are not released publically yet.
        /// </remarks>
        /// <param name="text">The text to be present in the header.</param>
        /// <param name="format">The header format.</param>
        /// <returns>The same instance with a header appended. This method will append a new line below the header.</returns>
        public MessageBuilder AddHeader(string text, HeaderFormat format)
        {
            text.ThrowIfNullOrEmpty();
            format.ThrowIfNull();

            _builder.AppendLine(text.ToHeader(format));
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        ///     Adds bold text to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <param name="inline">If the text should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with bold text appended.</returns>
        public MessageBuilder AddBoldText(string text, bool inline = true)
        {
            text.ThrowIfNullOrEmpty();
            Format(text.ToBold(), inline);
            return this;
        }

        /// <summary>
        ///     Adds italic text to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <param name="inline">If the text should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with italic appended.</returns>
        public MessageBuilder AddItalicText(string text, bool inline = true)
        {
            text.ThrowIfNullOrEmpty();
            Format(text.ToItalic(), inline);
            return this;
        }

        /// <summary>
        ///     Adds plain text to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <param name="inline">If the text should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with plain text appended.</returns>
        public MessageBuilder AddPlainText(string text, bool inline = true)
        {
            text.ThrowIfNullOrEmpty();
            Format(text, inline);
            return this;
        }

        /// <summary>
        ///     Adds underlined text to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <param name="inline">If the text should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with underlined text appended.</returns>
        public MessageBuilder AddUnderlinedText(string text, bool inline = true)
        {
            text.ThrowIfNullOrEmpty();
            Format(text.ToUnderline(), inline);
            return this;
        }

        /// <summary>
        ///     Adds a timestamp to the builder.
        /// </summary>
        /// <param name="dateTime">The time for which this timestamp should be created.</param>
        /// <param name="style">The style of the stamp.</param>
        /// <param name="inline">If the stamp should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with a timestamp appended.</returns>
        public MessageBuilder AddTimestamp(DateTime dateTime, TimestampTagStyles style, bool inline = true)
        {
            dateTime.ThrowIfNull();
            style.ThrowIfNull();
            Format(TimestampTag.FromDateTime(dateTime, style).ToString(), inline);
            return this;
        }

        /// <summary>
        ///     Adds strikethrough text to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <param name="inline">If the text should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with striked through text appended.</returns>
        public MessageBuilder AddStrikeThroughText(string text, bool inline = true)
        {
            text.ThrowIfNullOrEmpty();
            Format(text.ToStrikethrough(), inline);
            return this;
        }

        /// <summary>
        ///     Adds a spoiler to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <param name="inline">If the text should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with a spoiler appended.</returns>
        public MessageBuilder AddSpoiler(string text, bool inline = true)
        {
            text.ThrowIfNullOrEmpty();
            Format(text.ToSpoiler(), inline);
            return this;
        }

        /// <summary>
        ///     Adds a quote to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <returns>The same instance with a quote appended. This method will append a new line below the quote.</returns>
        public MessageBuilder AddQuote(string text)
        {
            text.ThrowIfNullOrEmpty();
            _builder.AppendLine(text.ToQuote());
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        ///     Adds a block quote to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <returns>The same instance with a block quote appended. This method will append a new line below the quote.</returns>
        public MessageBuilder AddBlockQuote(string text)
        {
            text.ThrowIfNullOrEmpty();
            _builder.AppendLine(text.ToBlockQuote());
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        ///     Adds code marked text to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <param name="inline">If the text should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with code marked text appended.</returns>
        public MessageBuilder AddCode(string text, bool inline = false)
        {
            text.ThrowIfNullOrEmpty();
            Format(text.ToCode(), inline);
            return this;
        }

        /// <summary>
        ///     Adds a code block to the builder.
        /// </summary>
        /// <param name="text">The text to be present in the markdown.</param>
        /// <param name="lang">The language in which this code should be presented.</param>
        /// <returns>The same instance with a code block appended. This method will append a new line below the block.</returns>
        public MessageBuilder AddCodeBlock(string text, CodeLanguage? lang = null)
        {
            text.ThrowIfNullOrEmpty();
            lang ??= CodeLanguage.None;
            _builder.AppendLine(text.ToCodeBlock(lang));
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        ///     Adds an emote to the builder.
        /// </summary>
        /// <param name="emote">The emote to add.</param>
        /// <param name="inline">If the emote should be appended in the same line or if it should append to a new line.</param>
        /// <returns>The same instance with an emote appended.</returns>
        public MessageBuilder AddEmote(IEmote emote, bool inline = false)
        {
            emote.ThrowIfNull();
            var str = emote switch
            {
                Emote ee => ee.ToString(),
                Emoji ei => ei.ToString(),
                _ => null
            };
            str.ThrowIfNullOrEmpty();
            Format(str!, inline);
            return this;
        }

        /// <summary>
        ///     Adds a range of emotes to the builder.
        /// </summary>
        /// <param name="seperator">The seperator to join the emotes with.</param>
        /// <param name="inline">If the emotes should be appended in the same line or if it should append to a new line.</param>
        /// <param name="emotes">The range of emotes to add.</param>
        /// <returns>The same instance with a range of emotes appended.</returns>
        public MessageBuilder AddEmotes(string? seperator, bool inline = false, params IEmote[] emotes)
        {
            if (!emotes.Any())
                throw new ArgumentException("No values were found in the passed selection", nameof(emotes));
            var str = string.Join(seperator, emotes.Select(x =>
            {
                return x switch
                {
                    Emote emote => emote.ToString(),
                    Emoji emoji => emoji.ToString(),
                    _ => throw new ArgumentNullException(nameof(emotes)),
                };
            }));
            Format(str, inline);
            return this;
        }

        /// <summary>
        ///     Adds a line of whitespace to the builder.
        /// </summary>
        /// <returns>The same instance with an empty line appended.</returns>
        public MessageBuilder AddNewline()
        {
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        ///     Builds a Discord message string from this instance.
        /// </summary>
        /// <returns>The string to send to Discord.</returns>
        public string Build()
            => _builder.ToString();

        private void Format(string text, bool inline)
        {
            if (inline)
                _builder.Append(text);
            else
                _builder.AppendLine(text);
        }
    }
}
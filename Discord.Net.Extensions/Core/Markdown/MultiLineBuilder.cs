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

namespace Discord.Extensions
{
    /// <summary>
    ///     Represents a builder for multi-line text.
    /// </summary>
    public class MultiLineBuilder
    {
        /// <summary>
        ///     The underlying list of lines this builder uses to construct multiline text.
        /// </summary>
        public List<string> Lines { get; set; }

        /// <summary>
        ///     Creates a new instance of <see cref="MultiLineBuilder"/>.
        /// </summary>
        public MultiLineBuilder()
        {
            Lines = new();
        }

        /// <summary>
        ///     Creates a new instance of <see cref="MultiLineBuilder"/> with a pre-defined capacity.
        /// </summary>
        /// <param name="capacity"></param>
        public MultiLineBuilder(int capacity)
        {
            Lines = new(capacity);
        }

        /// <summary>
        ///     Creates a new instance of <see cref="MultiLineBuilder"/> with a number of lines pre-defined.
        /// </summary>
        /// <param name="entries">The range of lines to add to this builder.</param>
        public MultiLineBuilder(params string[] entries)
        {
            Lines = new(entries);
        }

        /// <summary>
        ///     Adds a line to the builder.
        /// </summary>
        /// <param name="text">The text to add to this line.</param>
        /// <returns>The same instance with a line appended.</returns>
        public MultiLineBuilder AddLine(string text)
        {
            Lines.Add(text);
            return this;
        }

        /// <summary>
        ///     Adds a newline to the builder.
        /// </summary>
        /// <returns>The same instance with an empty line appended.</returns>
        public MultiLineBuilder AddNewline()
        {
            Lines.Add("");
            return this;
        }

        /// <summary>
        ///     Adds a range of lines to the builder.
        /// </summary>
        /// <param name="text">The range of text to add.</param>
        /// <returns>The same instance with a range of lines appended.</returns>
        public MultiLineBuilder AddLines(IEnumerable<string> text)
        {
            if (!text.Any())
                throw new ArgumentException("The passed range does not contain any values", nameof(text));
            Lines.AddRange(text);
            return this;
        }

        /// <summary>
        ///     Removes a (or more) line(s) from the builder.
        /// </summary>
        /// <param name="predicate">The predicate to remove lines with.</param>
        /// <returns>The same instance with all lines matching <paramref name="predicate"/> removed.</returns>
        public MultiLineBuilder RemoveLine(Predicate<string> predicate)
        {
            predicate.ThrowIfNull();
            Lines.RemoveAll(x => predicate(x));
            return this;
        }

        /// <summary>
        ///     Removes a line from the builder.
        /// </summary>
        /// <param name="index">The index to remove a line at.</param>
        /// <returns></returns>
        public MultiLineBuilder RemoveLine(int index)
        {
            Lines.RemoveAt(index);
            return this;
        }

        /// <summary>
        ///     Gets the line at a specific index.
        /// </summary>
        /// <param name="index">The index to get a line for.</param>
        /// <returns>The line at defined <paramref name="index"/>.</returns>
        public string this[int index]
        {
            get
            {
                return Lines[index];
            }
        }

        /// <summary>
        ///     Builds the builder into multiline text.
        /// </summary>
        /// <returns>A string representing the lines added in this builder.</returns>
        public string Build()
            => string.Join(Environment.NewLine, Lines);

        /// <summary>
        ///     Creates a string from the lines currently present in <see cref="Lines"/>.
        /// </summary>
        /// <remarks>
        ///     This method has the same behavior as <see cref="Build"/>.
        /// </remarks>
        /// <returns>A string representing the lines added in this builder.</returns>
        public override string ToString()
            => string.Join(Environment.NewLine, Lines);
    }
}

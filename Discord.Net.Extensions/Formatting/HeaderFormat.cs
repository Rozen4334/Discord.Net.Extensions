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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions
{
    public struct HeaderFormat
    {
        public string Format { get; }

        /// <summary>
        ///     The biggest header type.
        /// </summary>
        public static readonly HeaderFormat H1 = new("#");

        /// <summary>
        ///     An above-average sized header.
        /// </summary>
        public static readonly HeaderFormat H2 = new("##");

        /// <summary>
        ///     An average-sized header.
        /// </summary>
        public static readonly HeaderFormat H3 = new("###");

        /// <summary>
        ///     A subheader.
        /// </summary>
        public static readonly HeaderFormat H4 = new("####");

        /// <summary>
        ///     A smaller subheader.
        /// </summary>
        public static readonly HeaderFormat H5 = new("#####");

        /// <summary>
        ///     Slightly bigger than regular bold markdown.
        /// </summary>
        public static readonly HeaderFormat H6 = new("######");

        private HeaderFormat(string format)
        {
            Format = format;
        }

        /// <summary>
        ///     Formats this header into markdown, appending provided string.
        /// </summary>
        /// <param name="input">The string to turn into a header.</param>
        /// <returns>A markdown formatted header title.</returns>
        public string ToMarkdown(string input)
            => $"{Format} {input}";

        /// <summary>
        ///     Gets the markdown format for this header.
        /// </summary>
        /// <returns>The markdown format for this header.</returns>
        public override string ToString()
            => $"{Format}";
    }
}

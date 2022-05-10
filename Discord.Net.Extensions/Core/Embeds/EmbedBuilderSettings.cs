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
    ///     Settings for embed generation in <see cref="EmbedBuilderFactory"/>.
    /// </summary>
    public class EmbedBuilderSettings
    {
        /// <summary>
        ///     The base color of every embed generated inside <see cref="EmbedBuilderFactory"/>.
        /// </summary>
        public Color? BaseColor { get; set; }

        /// <summary>
        ///     The base footer of every embed generated inside <see cref="EmbedBuilderFactory"/>.
        /// </summary>
        public EmbedFooterBuilder BaseFooter { get; set; } = null!;

        /// <summary>
        ///     Sets the base footer.
        /// </summary>
        /// <param name="text">The text of the footer.</param>
        /// <param name="iconUrl">Thr icon url of the footer.</param>
        /// <returns>The current instance of <see cref="EmbedBuilderSettings"/> with the base footer included.</returns>
        public EmbedBuilderSettings WithFooter(string text, string iconUrl = "")
        {
            BaseFooter = new() { IconUrl = iconUrl, Text = text };
            return this;
        }

        /// <summary>
        ///     The base author of every embed generated inside <see cref="EmbedBuilderFactory"/>.
        /// </summary>
        public EmbedAuthorBuilder BaseAuthor { get; set; } = null!;

        /// <summary>
        ///     Sets the base author.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        /// <param name="iconUrl">The icon url of the author.</param>
        /// <param name="url">The url used when clicking on the authors' name.</param>
        /// <returns>The current instance of <see cref="EmbedBuilderSettings"/> with the base author included.</returns>
        public EmbedBuilderSettings WithAuthor(string name, string iconUrl = "", string url = "")
        {
            BaseAuthor = new() { IconUrl = iconUrl, Name = name, Url = url };
            return this;
        }

        /// <summary>
        ///     The base description of every embed generated inside <see cref="EmbedBuilderFactory"/>.
        /// </summary>
        public string BaseDescription { get; set; } = string.Empty;
    }
}

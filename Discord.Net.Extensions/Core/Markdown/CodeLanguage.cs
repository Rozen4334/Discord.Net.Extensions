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
    ///     Represents a language in which codeblocks can be formatted.
    /// </summary>
    public struct CodeLanguage
    {
        /// <summary>
        ///     Gets the tag of the language.
        /// </summary>
        public string Tag { get; }

        /// <summary>
        ///     Gets the name of the language. <see cref="string.Empty"/> if this <see cref="CodeLanguage"/> was constructed with no name provided.
        /// </summary>
        public string Name { get; } = string.Empty;

        /// <summary>
        ///     Gets the CSharp language format.
        /// </summary>
        public static readonly CodeLanguage CSharp = new("cs", "csharp");

        /// <summary>
        ///     Gets the Javascript language format.
        /// </summary>
        public static readonly CodeLanguage JavaScript = new("js", "javascript");

        /// <summary>
        ///     Gets the XML language format.
        /// </summary>
        public static readonly CodeLanguage XML = new("xml", "xml");

        /// <summary>
        ///     Gets the HTML language format.
        /// </summary>
        public static readonly CodeLanguage HTML = new("html", "html");

        /// <summary>
        ///     Gets the CSS markdown format.
        /// </summary>
        public static readonly CodeLanguage CSS = new("css", "css");

        /// <summary>
        ///     Gets a language format that represents none.
        /// </summary>
        public static readonly CodeLanguage None = new("", "none");

        /// <summary>
        ///     Creates a new language format with name & tag.
        /// </summary>
        /// <param name="tag">The tag with which markdown will be formatted.</param>
        /// <param name="name">The name of the language.</param>
        public CodeLanguage(string tag, string name)
        {
            Tag = tag;
            Name = name;
        }

        /// <summary>
        ///     Creates a new language format with a tag.
        /// </summary>
        /// <param name="tag">The tag with which markdown will be formatted.</param>
        public CodeLanguage(string tag)
            => Tag = tag;

        /// <summary>
        ///     Gets the tag of the language.
        /// </summary>
        /// <param name="language"></param>
        public static implicit operator string(CodeLanguage language)
            => language.Tag;

        /// <summary>
        ///     Gets a language based on the tag.
        /// </summary>
        /// <param name="tag"></param>
        public static implicit operator CodeLanguage(string tag)
            => new(tag);

        /// <summary>
        ///     Creates markdown format for this language.
        /// </summary>
        /// <param name="input">The input string to format.</param>
        /// <returns>A markdown formatted code-block with this language.</returns>
        public string ToMarkdown(string input)
            => $"```{Tag}\n{input}\n```";

        /// <summary>
        ///     Gets the tag of the language.
        /// </summary>
        /// <returns><see cref="Tag"/></returns>
        public override string ToString()
            => $"{Tag}";
    }
}

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
    ///     Represents a factory that builds <see cref="EmbedBuilder"/>'s from provided <see cref="EmbedBuilderSettings"/>.
    /// </summary>
    public class EmbedBuilderFactory
    {
        private readonly EmbedBuilderSettings _settings;

        /// <summary>
        ///     Creates a new instance with provided <see cref="EmbedBuilderSettings"/>.
        /// </summary>
        public EmbedBuilderFactory(EmbedBuilderSettings settings)
        {
            if (_settings is null)
                throw new ArgumentNullException(nameof(settings));
            _settings = settings;
        }

        /// <summary>
        ///     Generates a new <see cref="EmbedBuilder"/> based on the values put in at <see cref="EmbedBuilderSettings"/>.
        /// </summary>
        /// <returns>The generated <see cref="EmbedBuilder"/></returns>
        public virtual EmbedBuilder Generate()
            => Generate(_settings);

        /// <summary>
        ///     Generates a new <see cref="EmbedBuilder"/> based on the values put in at <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">The base settings for this embed.</param>
        /// <returns></returns>
        public static EmbedBuilder Generate(EmbedBuilderSettings settings)
        {
            var eb = new EmbedBuilder();

            if (settings.BaseAuthor is not null)
                eb.WithAuthor(settings.BaseAuthor);
            if (settings.BaseFooter is not null)
                eb.WithFooter(settings.BaseFooter);
            if (settings.BaseColor is not null)
                eb.WithColor(settings.BaseColor.Value);

            if (!string.IsNullOrEmpty(settings.BaseDescription))
                eb.WithDescription(settings.BaseDescription);

            return eb;
        }
    }
}

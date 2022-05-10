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
    ///     Represents a factory that builds <see cref="EmbedBuilder"/>'s from provided <see cref="BuilderSettings{T}"/>.
    /// </summary>
    public class EmbedBuilderFactory
    {
        private readonly BuilderSettings<EmbedBuilder> _generator;

        /// <summary>
        ///     Creates a new instance with provided <see cref="BuilderSettings{T}"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the passed <paramref name="generator"/> is <see langword="null"/>.</exception>
        public EmbedBuilderFactory(BuilderSettings<EmbedBuilder> generator)
        {
            if (_generator is null)
                throw new ArgumentNullException(nameof(generator));
            _generator = generator;
        }

        /// <summary>
        ///     Generates a new <see cref="EmbedBuilder"/> based on the values put in at <see cref="BuilderSettings{T}"/>.
        /// </summary>
        /// <remarks>
        ///     Can be overridden to modify the flow of how the builder is created.
        /// </remarks>
        /// <param name="action">An alternative action the builder should take. Executed after the action in <see cref="BuilderSettings{T}"/>.</param>
        /// <returns>The generated <see cref="EmbedBuilder"/>.</returns>
        public virtual EmbedBuilder Generate(Action<EmbedBuilder>? action = null)
            => Generate(_generator, action);

        /// <summary>
        ///     Generates a new <see cref="EmbedBuilder"/> based on the values put in at <paramref name="generator"/>.
        /// </summary>
        /// <param name="generator">The base settings for this builder.</param>
        /// <param name="action">An alternative action the builder should take. Executed after the action in <paramref name="generator"/>.</param>
        /// <returns>The generated <see cref="EmbedBuilder"/>.</returns>
        public static EmbedBuilder Generate(BuilderSettings<EmbedBuilder> generator, Action<EmbedBuilder>? action = null)
        {
            var eb = new EmbedBuilder();
            generator.Action(eb);

            if (action is not null)
                action(eb);

            return eb;
        }
    }
}

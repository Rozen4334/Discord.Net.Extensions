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
    public class EmbedBuilderFactory<TKey> : IBuilderFactory<TKey, EmbedBuilder> where TKey : notnull
    {
        private readonly BuilderSettings<TKey, EmbedBuilder> _generator;

        /// <summary>
        ///     Creates a new <see cref="EmbedBuilderFactory{TKey}"/> based on the provided <paramref name="generator"/>.
        /// </summary>
        /// <param name="generator">The generator with unique actions reserved by the key.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="generator"/> is null.</exception>
        public EmbedBuilderFactory(BuilderSettings<TKey, EmbedBuilder> generator)
        {
            if (_generator is null)
                throw new ArgumentNullException(nameof(generator));
            _generator = generator;
        }

        /// <inheritdoc/>
        public virtual EmbedBuilder Generate(TKey key, Action<EmbedBuilder>? action = null)
            => Generate(key, _generator, action);

        /// <inheritdoc/>
        public virtual EmbedBuilder GenerateGlobal(Action<EmbedBuilder>? action = null)
        {
            var eb = new EmbedBuilder();

            if (_generator.GlobalAction is not null)
                _generator.GlobalAction(eb);

            if (action is not null)
                action(eb);

            return eb;
        }

        /// <summary>
        ///     Generates a new <see cref="EmbedBuilder"/> based on the values put in at <paramref name="generator"/>.
        /// </summary>
        /// <param name="key">The key for which to grab the generator.</param>
        /// <param name="generator">The base settings for this builder.</param>
        /// <param name="action">An alternative action the builder should take. Executed after the action in <paramref name="generator"/>.</param>
        /// <returns>The generated <see cref="EmbedBuilder"/>.</returns>
        public static EmbedBuilder Generate(TKey key, BuilderSettings<TKey, EmbedBuilder> generator, Action<EmbedBuilder>? action = null)
        {
            var eb = new EmbedBuilder();

            if (generator.GlobalAction is not null)
                generator.GlobalAction(eb);

            if (generator.TryGetAction(key, out var genAction))
                genAction?.Invoke(eb);

            if (action is not null)
                action(eb);

            return eb;
        }
    }
}

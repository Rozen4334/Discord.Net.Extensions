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
    ///     Represents a factory to generate modal builders with.
    /// </summary>
    /// <typeparam name="TKey">The type that serves as key in the passed <see cref="BuilderSettings{T, TBuilder}"/>.</typeparam>
    public class ModalBuilderFactory<TKey> : IBuilderFactory<TKey, ModalBuilder> where TKey : notnull
    {
        private readonly BuilderSettings<TKey, ModalBuilder> _generator;

        /// <summary>
        ///     Creates a new <see cref="ModalBuilderFactory{TKey}"/> based on the provided <paramref name="generator"/>.
        /// </summary>
        /// <param name="generator">The generator with unique actions reserved by the key.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="generator"/> is null.</exception>
        public ModalBuilderFactory(BuilderSettings<TKey, ModalBuilder> generator)
        {
            if (generator is null)
                throw new ArgumentNullException(nameof(generator));
            _generator = generator;
        }

        /// <inheritdoc/>
        public virtual ModalBuilder Generate(TKey key, Action<ModalBuilder>? action = null)
            => Generate(key, _generator, action);

        /// <inheritdoc/>
        public virtual ModalBuilder GenerateGlobal(Action<ModalBuilder>? action = null)
        {
            var mb = new ModalBuilder();

            if (_generator.GlobalAction is not null)
                _generator.GlobalAction(mb);

            if (action is not null)
                action(mb);

            return mb;
        }

        /// <summary>
        ///     Generates a new <see cref="ModalBuilder"/> based on the values put in at <paramref name="generator"/>.
        /// </summary>
        /// <param name="key">The key for which to grab the generator.</param>
        /// <param name="generator">The base settings for this builder.</param>
        /// <param name="action">An alternative action the builder should take. Executed after the action in <paramref name="generator"/>.</param>
        /// <returns>The generated <see cref="ModalBuilder"/>.</returns>
        public static ModalBuilder Generate(TKey key, BuilderSettings<TKey, ModalBuilder> generator, Action<ModalBuilder>? action = null)
        {
            var mb = new ModalBuilder();

            if (generator.GlobalAction is not null)
                generator.GlobalAction(mb);

            if (generator.TryGetAction(key, out var genAction))
                genAction?.Invoke(mb);

            if (action is not null)
                action(mb);

            return mb;
        }
    }
}

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
    ///     Settings for builder generation in implementations of <see cref="IBuilderFactory{TKey, TBuilder}"/>.
    /// </summary>
    public class BuilderSettings<TKey, TBuilder> where TKey : notnull
    {
        /// <summary>
        ///     A dictionary of actions that should be executed when the builder is being built depending on the <see cref="TKey"/> provided.
        /// </summary>
        public Dictionary<TKey, Action<TBuilder>> Actions { get; private set; } = new();

        /// <summary>
        ///     An action to run for all builders of <typeparamref name="TBuilder"/>.
        /// </summary>
        public Action<TBuilder> GlobalAction { get; private set; } = null!;

        /// <summary>
        ///     Adds an action that should be executed for at creation of all builders.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>The current instance with a new <see cref="GlobalAction"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="action"/> is null.</exception>
        public BuilderSettings<TKey, TBuilder> WithGlobalAction(Action<TBuilder> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            GlobalAction = action;

            return this;
        }

        /// <summary>
        ///     Adds an action to the current <see cref="BuilderSettings{T, TBuilder}"/>.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="action">The value matching the key.</param>
        /// <returns>The current instance with a new <see cref="KeyValuePair"/> added to <see cref="Actions"/></returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="action"/> is null.</exception>
        public BuilderSettings<TKey, TBuilder> AddAction(TKey key, Action<TBuilder> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            Actions.Add(key, action);

            return this;
        }

        /// <summary>
        ///     Attempts to get an action matching the provided key.
        /// </summary>
        /// <param name="key">The key to find a value for.</param>
        /// <param name="action">The found value.</param>
        /// <returns><see langword="true"/> if found. <see langword="false"/> if not.</returns>
        public bool TryGetAction(TKey key, out Action<TBuilder>? action)
            => Actions.TryGetValue(key, out action);

        /// <summary>
        ///     Gets an action or default matching the provided key.
        /// </summary>
        /// <param name="key">The key to find a value for.</param>
        /// <returns>An action or <see langword="null"/> depending on if the value was found.</returns>
        public Action<TBuilder>? GetActionOrDefault(TKey key)
            => Actions.GetValueOrDefault(key);
    }
}

namespace Discord.Extensions
{
    /// <summary>
    ///     Represents a builder factory that builds instances of <typeparamref name="TBuilder"/> with found action on <see cref="BuilderSettings{T, TBuilder}"/> of <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type that serves as key to get builder actions.</typeparam>
    /// <typeparam name="TBuilder">The type of builder to build.</typeparam>
    public interface IBuilderFactory<TKey, TBuilder> where TKey : notnull
    {
        /// <summary>
        ///     Builds an instance of <typeparamref name="TBuilder"/> from the provided action found at <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to gather a build action of.</param>
        /// <param name="action">An optional additional action to be handled post-generation.</param>
        /// <returns>A new instance of <typeparamref name="TBuilder"/> based on the actions from <see cref="BuilderSettings{TKey, TBuilder}.GlobalAction"/>, <paramref name="key"/> and <paramref name="action"/>.</returns>
        public TBuilder Generate(TKey key, Action<TBuilder>? action = null);

        /// <summary>
        ///     Builds an instance of <typeparamref name="TBuilder"/> from the provided <see cref="BuilderSettings{TKey, TBuilder}.GlobalAction"/>.
        /// </summary>
        /// <param name="action">An optional additional action to be handled post-generation.</param>
        /// <returns>A new instance of <typeparamref name="TBuilder"/> based on the order of actions from <see cref="BuilderSettings{TKey, TBuilder}.GlobalAction"/> and <paramref name="action"/>.</returns>
        public TBuilder GenerateGlobal(Action<TBuilder>? action = null);
    }
}

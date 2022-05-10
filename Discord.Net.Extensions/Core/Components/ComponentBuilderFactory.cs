using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions
{
    /// <summary>
    ///     Represents a factory that builds <see cref="ComponentBuilder"/>'s from provided <see cref="BuilderSettings{T}"/>.
    /// </summary>
    public class ComponentBuilderFactory
    {
        private readonly BuilderSettings<ComponentBuilder> _generator;

        /// <summary>
        ///     Creates a new instance with provided <see cref="BuilderSettings{T}"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the passed <paramref name="generator"/> is <see langword="null"/>.</exception>
        public ComponentBuilderFactory(BuilderSettings<ComponentBuilder> generator)
        {
            if (_generator is null)
                throw new ArgumentNullException(nameof(generator));
            _generator = generator;
        }

        /// <summary>
        ///     Generates a new <see cref="ComponentBuilder"/> based on the values put in at <see cref="BuilderSettings{T}"/>.
        /// </summary>
        /// <remarks>
        ///     Can be overridden to modify the flow of how the builder is created.
        /// </remarks>
        /// <param name="action">An alternative action the builder should take. Executed after the action in <see cref="BuilderSettings{T}"/>.</param>
        /// <returns>The generated <see cref="ComponentBuilder"/>.</returns>
        public virtual ComponentBuilder Generate(Action<ComponentBuilder>? action = null)
            => Generate(_generator, action);

        /// <summary>
        ///     Generates a new <see cref="ComponentBuilder"/> based on the values put in at <paramref name="generator"/>.
        /// </summary>
        /// <param name="generator">The base settings for this builder.</param>
        /// <param name="action">An alternative action the builder should take. Executed after the action in <paramref name="generator"/>.</param>
        /// <returns>The generated <see cref="ComponentBuilder"/>.</returns>
        public static ComponentBuilder Generate(BuilderSettings<ComponentBuilder> generator, Action<ComponentBuilder>? action = null)
        {
            var cb = new ComponentBuilder();
            generator.Action(cb);

            if (action is not null)
                action(cb);

            return cb;
        }
    }
}

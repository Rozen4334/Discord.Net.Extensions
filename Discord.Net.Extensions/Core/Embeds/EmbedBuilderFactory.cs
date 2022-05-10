using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

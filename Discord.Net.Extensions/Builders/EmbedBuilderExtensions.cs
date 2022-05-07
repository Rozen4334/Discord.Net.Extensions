namespace Discord.Extensions.Builders
{
    /// <summary>
    ///     Provides a number of extensions to the <see cref="EmbedBuilder"/> class.
    /// </summary>
    public static class EmbedBuilderExtensions
    {
        /// <summary>
        /// Adds link to the text to the <see cref="EmbedBuilder"/> in the description.
        /// </summary>
        /// <param name="embed">The <see cref="EmbedBuilder"/> this text link should be added to.</param>
        /// <param name="text">Text which will be the link.</param>
        /// <param name="url">The URL this <see cref="text"/>.</param>
        /// <returns>The same <see cref="EmbedBuilder"/> with the text link.</returns>
        public static EmbedBuilder AddTextLink(this EmbedBuilder embed, string text, string url)
        {
            if (!embed.Description.Contains(text))
                throw new InvalidOperationException($"The description does not have this text ({text})");

            return embed.WithDescription(embed.Description.Replace(text, $"[{text}]({url})"));
        }
    }
}

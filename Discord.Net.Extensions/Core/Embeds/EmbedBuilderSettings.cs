using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions
{
    /// <summary>
    ///     Settings for embed generation in <see cref="EmbedBuilderFactory"/>.
    /// </summary>
    public class EmbedBuilderSettings
    {
        /// <summary>
        ///     The base color of every embed generated inside <see cref="EmbedBuilderFactory"/>.
        /// </summary>
        public Color? BaseColor { get; set; }

        /// <summary>
        ///     The base footer of every embed generated inside <see cref="EmbedBuilderFactory"/>.
        /// </summary>
        public EmbedFooterBuilder BaseFooter { get; set; } = null!;

        /// <summary>
        ///     Sets the base footer.
        /// </summary>
        /// <param name="text">The text of the footer.</param>
        /// <param name="iconUrl">Thr icon url of the footer.</param>
        /// <returns>The current instance of <see cref="EmbedBuilderSettings"/> with the base footer included.</returns>
        public EmbedBuilderSettings WithFooter(string text, string iconUrl = "")
        {
            BaseFooter = new() { IconUrl = iconUrl, Text = text };
            return this;
        }

        /// <summary>
        ///     The base author of every embed generated inside <see cref="EmbedBuilderFactory"/>.
        /// </summary>
        public EmbedAuthorBuilder BaseAuthor { get; set; } = null!;

        /// <summary>
        ///     Sets the base author.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        /// <param name="iconUrl">The icon url of the author.</param>
        /// <param name="url">The url used when clicking on the authors' name.</param>
        /// <returns>The current instance of <see cref="EmbedBuilderSettings"/> with the base author included.</returns>
        public EmbedBuilderSettings WithAuthor(string name, string iconUrl = "", string url = "")
        {
            BaseAuthor = new() { IconUrl = iconUrl, Name = name, Url = url };
            return this;
        }

        /// <summary>
        ///     The base description of every embed generated inside <see cref="EmbedBuilderFactory"/>.
        /// </summary>
        public string BaseDescription { get; set; } = string.Empty;
    }
}

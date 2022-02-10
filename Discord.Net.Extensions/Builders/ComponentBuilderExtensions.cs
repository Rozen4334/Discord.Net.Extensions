using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Builders
{
    /// <summary>
    ///     An extension class that adds an easier way to create components for a <see cref="ComponentBuilder"/>
    /// </summary>
    public static class ComponentBuilderExtensions
    {
        /// <summary>
        ///     Adds a link button with its respective constraints to the <see cref="ComponentBuilder"/>
        /// </summary>
        /// <param name="builder">The <see cref="ComponentBuilder"/> this button should be added to.</param>
        /// <param name="label">The label of this button. Cannot be empty.</param>
        /// <param name="url">The url this button should lead to.</param>
        /// <param name="emote">The emote that should line the left side of this button.</param>
        /// <param name="disabled">If the button should be clickable or not.</param>
        /// <param name="row">The row, 0 to 4. 0 is top, 4 is bottom. This can only be done in sequence, so a button with row 1 cannot be added before a button was added with row 0.</param>
        /// <returns>The same <see cref="ComponentBuilder"/> with this button added.</returns>
        public static ComponentBuilder AddLinkButton(this ComponentBuilder builder, string label, string url, IEmote emote = null!, bool disabled = false, int row = 0)
            => builder.WithButton(label: label, url: url, emote: emote, style: ButtonStyle.Link, disabled: disabled, row: row);

        /// <summary>
        ///     Adds a danger button with its respective constraints to the <see cref="ComponentBuilder"/>
        /// </summary>
        /// <param name="builder">The <see cref="ComponentBuilder"/> this button should be added to.</param>
        /// <param name="label">The label of this button. Cannot be empty.</param>
        /// <param name="customId">The custom ID of this button. cannot be empty.</param>
        /// <param name="emote">The emote that should line the left side of this button.</param>
        /// <param name="disabled">If the button should be clickable or not.</param>
        /// <param name="row">The row, 0 to 4. 0 is top, 4 is bottom. This can only be done in sequence, so a button with row 1 cannot be added before a button was added with row 0.</param>
        /// <returns>The same <see cref="ComponentBuilder"/> with this button added.</returns>
        public static ComponentBuilder AddDangerButton(this ComponentBuilder builder, string label, string customId, IEmote emote = null!, bool disabled = false, int row = 0)
            => builder.WithButton(label: label, customId: customId, style: ButtonStyle.Danger, emote: emote, disabled: disabled, row: row);

        /// <summary>
        ///     Adds a success button with its respective constraints to the <see cref="ComponentBuilder"/>
        /// </summary>
        /// <param name="builder">The <see cref="ComponentBuilder"/> this button should be added to.</param>
        /// <param name="label">The label of this button. Cannot be empty.</param>
        /// <param name="customId">The custom ID of this button. cannot be empty.</param>
        /// <param name="emote">The emote that should line the left side of this button.</param>
        /// <param name="disabled">If the button should be clickable or not.</param>
        /// <param name="row">The row, 0 to 4. 0 is top, 4 is bottom. This can only be done in sequence, so a button with row 1 cannot be added before a button was added with row 0.</param>
        /// <returns>The same <see cref="ComponentBuilder"/> with this button added.</returns>
        public static ComponentBuilder AddSuccessButton(this ComponentBuilder builder, string label, string customId, IEmote emote = null!, bool disabled = false, int row = 0)
            => builder.WithButton(label: label, customId: customId, style: ButtonStyle.Primary, emote: emote, disabled: disabled, row: row);

        /// <summary>
        ///     Adds a call-to-action (primary) button with its respective constraints to the <see cref="ComponentBuilder"/>
        /// </summary>
        /// <param name="builder">The <see cref="ComponentBuilder"/> this button should be added to.</param>
        /// <param name="label">The label of this button. Cannot be empty.</param>
        /// <param name="customId">The custom ID of this button. cannot be empty.</param>
        /// <param name="emote">The emote that should line the left side of this button.</param>
        /// <param name="disabled">If the button should be clickable or not.</param>
        /// <param name="row">The row, 0 to 4. 0 is top, 4 is bottom. This can only be done in sequence, so a button with row 1 cannot be added before a button was added with row 0.</param>
        /// <returns>The same <see cref="ComponentBuilder"/> with this button added.</returns>
        public static ComponentBuilder AddCTAButton(this ComponentBuilder builder, string label, string customId, IEmote emote = null!, bool disabled = false, int row = 0)
            => builder.WithButton(label: label, customId: customId, style: ButtonStyle.Primary, emote: emote, disabled: disabled, row: row);

        /// <summary>
        ///     Adds a basic (secondary) button with its respective constraints to the <see cref="ComponentBuilder"/>
        /// </summary>
        /// <param name="builder">The <see cref="ComponentBuilder"/> this button should be added to.</param>
        /// <param name="label">The label of this button. Cannot be empty.</param>
        /// <param name="customId">The custom ID of this button. cannot be empty.</param>
        /// <param name="emote">The emote that should line the left side of this button.</param>
        /// <param name="disabled">If the button should be clickable or not.</param>
        /// <param name="row">The row, 0 to 4. 0 is top, 4 is bottom. This can only be done in sequence, so a button with row 1 cannot be added before a button was added with row 0.</param>
        /// <returns>The same <see cref="ComponentBuilder"/> with this button added.</returns>
        public static ComponentBuilder AddBasicButton(this ComponentBuilder builder, string label, string customId, IEmote emote = null!, bool disabled = false, int row = 0)
            => builder.WithButton(label: label, customId: customId, style: ButtonStyle.Secondary, emote: emote, disabled: disabled, row: row);
    }
}

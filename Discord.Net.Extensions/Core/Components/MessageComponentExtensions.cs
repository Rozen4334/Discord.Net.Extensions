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
    ///     Represents a class of extensions for the <see cref="MessageComponent"/> type.
    /// </summary>
    public static class MessageComponentExtensions
    {
        /// <summary>
        ///     Modifies select menu's in the passed <paramref name="component"/> by <paramref name="predicate"/>.
        /// </summary>
        /// <remarks>
        ///     If you only want to modify a single menu, consider filtering by custom Id in the <paramref name="predicate"/>.
        /// </remarks>
        /// <param name="component">The <see cref="MessageComponent"/> to modify.</param>
        /// <param name="action">The edit to make to the select menu's.</param>
        /// <param name="predicate">The filter by which the menu's should be modified. Will modify all menu's if parameter is left null.</param>
        /// <returns>A <see cref="ComponentBuilder"/> based on the <paramref name="component"/> passed with modifications from <paramref name="action"/>.</returns>
        public static ComponentBuilder ModifySelectMenus(this MessageComponent component, Action<SelectMenuBuilder> action, Predicate<SelectMenuBuilder>? predicate = null)
        {
            var cb = new ComponentBuilder();

            var rows = component.Components.ToArray();

            for (int i = 0; i < rows.Length; i++)
                foreach (var c in rows[i].Components)
                    switch (c)
                    {
                        case ButtonComponent button:
                            cb.WithButton(button.ToBuilder(), i);
                            break;
                        case SelectMenuComponent menu:
                            var sb = menu.ToBuilder();
                            if (predicate is null || predicate(sb))
                                action(sb);
                            cb.WithSelectMenu(sb, i);
                            break;
                    }
            return cb;
        }

        /// <summary>
        ///     Modifies buttons in the passed <paramref name="component"/> by <paramref name="predicate"/>.
        /// </summary>
        /// <remarks>
        ///     If you only want to modify a single button, consider filtering by custom Id in the <paramref name="predicate"/>.
        /// </remarks>
        /// <param name="component">The <see cref="MessageComponent"/> to modify.</param>
        /// <param name="action">The edit to make to the buttons.</param>
        /// <param name="predicate">The filter by which the buttons should be modified. Will modify all buttons if parameter is left null.</param>
        /// <returns>A <see cref="ComponentBuilder"/> based on the <paramref name="component"/> passed with modifications from <paramref name="action"/>.</returns>
        public static ComponentBuilder ModifyButtons(this MessageComponent component, Action<ButtonBuilder> action, Predicate<ButtonBuilder>? predicate = null)
        {
            var cb = new ComponentBuilder();

            var rows = component.Components.ToArray();

            for (int i = 0; i < rows.Length; i++)
                foreach (var c in rows[i].Components)
                    switch (c)
                    {
                        case ButtonComponent button:
                            var bb = button.ToBuilder();
                            if (predicate is null || predicate(bb))
                                action(bb);
                            cb.WithButton(bb, i);
                            break;
                        case SelectMenuComponent menu:
                            cb.WithSelectMenu(menu.ToBuilder(), i);
                            break;
                    }
            return cb;
        }
    }
}

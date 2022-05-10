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

using Discord.Interactions;

namespace Discord.Extensions.Interactions.Attributes
{
    /// <summary>
    ///     Disables the components on the message this interaction sources from.
    /// </summary>
    /// <remarks>
    ///     This attribute will fail if the source message was ephemeral or if it is used on methods that do not implement <see cref="ComponentInteractionAttribute"/>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method)]
    public class DisableSourceAttribute : PreconditionAttribute
    {
        public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
        {
            if (context.Interaction is not IComponentInteraction messageComponent)
                return PreconditionResult.FromError("This attribute does not work for application commands!");

            var builder = new ComponentBuilder();

            var rows = ComponentBuilder.FromMessage(messageComponent.Message).ActionRows;

            for (int i = 0; i < rows.Count; i++)
                foreach (var component in rows[i].Components)
                    switch (component)
                    {
                        case ButtonComponent button:
                            builder.WithButton(button.ToBuilder()
                                .WithDisabled(true), i);
                            break;
                        case SelectMenuComponent menu:
                            builder.WithSelectMenu(menu.ToBuilder()
                                .WithDisabled(true), i);
                            break;
                    }

            try
            {
                await messageComponent.Message.ModifyAsync(x => x.Components = builder.Build());
                return PreconditionResult.FromSuccess();
            }
            catch (Exception ex)
            {
                return PreconditionResult.FromError(ex);
            }
        }
    }
}

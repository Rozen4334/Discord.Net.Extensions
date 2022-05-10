using Discord.Interactions;

namespace Discord.Extensions.Interactions
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

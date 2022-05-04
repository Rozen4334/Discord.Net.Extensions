using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     Checks if the user ID of the user interacting with this message component matches that of what was placed in the custom ID.
    /// </summary>
    /// <remarks>
    ///     This attribute will fail if it is used on methods that do not implement <see cref="ComponentInteractionAttribute"/>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CheckUserIDAttribute : PreconditionAttribute
    {
        private readonly int _index;

        private readonly char _wildcardAnnouncer;

        private readonly char _wildcardSplitter;

        public override Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
        {
            if (context.Interaction is not IComponentInteraction component)
                return Task.FromResult(PreconditionResult.FromError("Context unrecognized as component context."));

            var param = component.Data.CustomId.Split(_wildcardAnnouncer);

            if (param.Length > 1 && ulong.TryParse(param[1].Split(_wildcardSplitter)[_index], out ulong id))
                return (context.User.Id == id)
                    ? Task.FromResult(PreconditionResult.FromSuccess())
                    : Task.FromResult(PreconditionResult.FromError("User ID does not match component ID!"));

            return Task.FromResult(PreconditionResult.FromError("Parse cannot be done if no userID exists."));
        }

        /// <summary>
        ///     Checks if the user ID of the user interacting with this message component matches that of what was placed in the custom ID.
        /// </summary>
        /// <remarks>
        ///     With the placeholder implementation of the arguments of this attribute, 
        ///     the implementation would look like
        ///     <c>"myCustomId:*,*"</c>.
        ///     Where the first occurence of <c>*</c> can be replaced with the user ID.
        /// </remarks>
        /// <param name="index">The index of which wildcard (*) the user ID is expected.</param>
        /// <param name="wildcardAnnouncer">The character at which the wildcard pattern (*) begins.</param>
        /// <param name="wildcardSplitter">The character that implies a wildcard is followed up by another.</param>
        /// <exception cref="InvalidOperationException">This attribute will fail if it is used on methods that do not implement <see cref="ComponentInteractionAttribute"/></exception>
        public CheckUserIDAttribute(int index = 0, char wildcardAnnouncer = ':', char wildcardSplitter = ',')
        {
            _index = index;
            _wildcardAnnouncer = wildcardAnnouncer;
            _wildcardSplitter = wildcardSplitter;
        }
    }
}

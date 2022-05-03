using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="TypeReader{T}"/> to convert component wildcards into <see cref="Guid"/>.
    /// </summary>
    public class GuidTypeReader : TypeReader<Guid>
    {
        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, string option, IServiceProvider services)
        {
            if (Guid.TryParse(option, out Guid id))
                return Task.FromResult(TypeConverterResult.FromSuccess(id));
            else
                return Task.FromResult(TypeConverterResult.FromError(
                    InteractionCommandError.ConvertFailed,
                    "Unable to parse wildcard as Guid"));
        }
    }
}

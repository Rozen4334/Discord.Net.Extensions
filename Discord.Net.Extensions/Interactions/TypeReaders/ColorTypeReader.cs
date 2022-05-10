using Discord.Interactions;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="TypeReader{T}"/> to convert component wildcards into <see cref="Color"/>.
    /// </summary>
    public class ColorTypeReader : TypeReader<Color>
    {
        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, string option, IServiceProvider services)
            => Task.FromResult(Utils.ConverterExtensions.ConvertColor(option));
    }
}

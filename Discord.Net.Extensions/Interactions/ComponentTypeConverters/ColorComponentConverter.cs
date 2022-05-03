using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="ComponentTypeConverter{T}"/> to convert modal parameters into <see cref="Color"/>. Only works with hex values.
    /// </summary>
    public class ColorComponentConverter : ComponentTypeConverter<Color>
    {
        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IComponentInteractionData option, IServiceProvider services)
        {
            if (uint.TryParse(option.Value.Replace("#", " ").Trim(), NumberStyles.HexNumber, null, out uint result))
                return Task.FromResult(TypeConverterResult.FromSuccess(new Color(result)));

            else
                return Task.FromResult(TypeConverterResult.FromError(
                    error: InteractionCommandError.ConvertFailed, 
                    reason: "Unable to convert input string to Color."));
        }
    }
}

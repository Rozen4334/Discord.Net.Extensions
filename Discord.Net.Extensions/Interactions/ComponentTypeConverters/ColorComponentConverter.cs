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
            => Task.FromResult(Utils.ConverterExtensions.ConvertColor(option.Value));   
    }
}

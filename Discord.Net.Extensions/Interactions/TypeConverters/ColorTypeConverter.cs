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
    ///     A <see cref="TypeConverter{T}"/> to convert app command options into <see cref="Color"/>
    /// </summary>
    public class ColorTypeConverter : TypeConverter<Color>
    {
        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            var @string = (string)option.Value;

            if (uint.TryParse(@string.Replace("#", " ").Trim(), NumberStyles.HexNumber, null, out uint result))
                return Task.FromResult(TypeConverterResult.FromSuccess(new Color(result)));
            else
                return Task.FromResult(TypeConverterResult.FromError(
                    error: InteractionCommandError.ConvertFailed,
                    reason: "Unable to convert input string to Color."));
        }
    }
}

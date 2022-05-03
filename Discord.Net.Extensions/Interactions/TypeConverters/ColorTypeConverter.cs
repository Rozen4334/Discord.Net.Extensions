using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Interactions
{
    public class ColorTypeConverter : TypeConverter<Color>
    {
        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String | ApplicationCommandOptionType.Integer;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            switch (option.Value)
            {
                case string @string:
                    if (uint.TryParse(@string.Replace("#", " ").Trim(), NumberStyles.HexNumber, null, out uint result))
                        return Task.FromResult(TypeConverterResult.FromSuccess(new Color(result)));
                    else
                        return Task.FromResult(TypeConverterResult.FromError(
                            error: InteractionCommandError.ConvertFailed,
                            reason: "Unable to convert input string to Color."));

                case long @long:
                    var value = Convert.ToUInt32(@long.ToString(), 16);
                    return Task.FromResult(TypeConverterResult.FromSuccess(new Color(value)));

                default:
                    return Task.FromResult(TypeConverterResult.FromError(
                        error: InteractionCommandError.ConvertFailed,
                        reason: "Unable to parse provided value to Color."));
            }
        }
    }
}

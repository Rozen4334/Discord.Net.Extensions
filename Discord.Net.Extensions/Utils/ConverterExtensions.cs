using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Utils
{
    internal static class ConverterExtensions
    {
        public static TypeConverterResult ConvertEmote(string input)
        {
            if (string.IsNullOrEmpty(input))
                return TypeConverterResult.FromError(InteractionCommandError.ConvertFailed, "An empty or null string cannot be parsed into an emote.");

            if (Emote.TryParse(input, out Emote emote))
                return TypeConverterResult.FromSuccess(emote);

            IEmote emoji = new Emoji(input);

            if (string.IsNullOrEmpty(emoji.Name))
                return TypeConverterResult.FromError(InteractionCommandError.ConvertFailed, "The passed string is no emote.");

            return TypeConverterResult.FromSuccess(emoji);
        }

        public static TypeConverterResult ConvertColor(string input)
        {
            if (uint.TryParse(input.Replace("#", " ").Trim(), NumberStyles.HexNumber, null, out uint result))
                return TypeConverterResult.FromSuccess(new Color(result));

            else
                return TypeConverterResult.FromError(
                    error: InteractionCommandError.ConvertFailed,
                    reason: "Unable to convert input string to Color.");
        }
    }
}

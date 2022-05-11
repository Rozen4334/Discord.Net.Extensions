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
using System.Globalization;

namespace Discord.Extensions.Internal
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

            try
            {
                var @uint = Convert.ToUInt32(input, 16); // Parse any other uint value i.e. 0x******
                return TypeConverterResult.FromSuccess(@uint);
            }
            catch
            {
                return TypeConverterResult.FromError(
                    error: InteractionCommandError.ConvertFailed,
                    reason: "Unable to convert input string to Color.");
            }
        }
    }
}

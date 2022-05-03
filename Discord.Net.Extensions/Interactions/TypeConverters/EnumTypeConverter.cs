using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="TypeConverter{T}"/> that converts an integer or string parameter to <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The enum to convert to.</typeparam>
    public class EnumTypeConverter<T> : TypeConverter<T> where T : Enum
    {
        public override ApplicationCommandOptionType GetDiscordType()
            => ApplicationCommandOptionType.String | ApplicationCommandOptionType.Integer;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            switch (option.Value)
            {
                case string @string:
                    {
                        if (Enum.TryParse(typeof(T), @string, out var value))
                            return Task.FromResult(TypeConverterResult.FromSuccess(value));

                        else
                            return Task.FromResult(TypeConverterResult.FromError(
                                error: InteractionCommandError.ConvertFailed,
                                reason: $"String passed is not convertible to constants presented by {typeof(T)}"));
                    }
                case long @long:
                    {
                        var values = Enum.GetValues(typeof(T));

                        foreach(var value in values)
                        {
                            if (@long == (int)value)
                                return Task.FromResult(TypeConverterResult.FromSuccess(value));
                        }
                        return Task.FromResult(TypeConverterResult.FromError(
                            error: InteractionCommandError.ConvertFailed,
                            reason: $"Integer passed is not known in the range of constants presented by {typeof(T)}"));
                    }
                default:
                    return Task.FromResult(TypeConverterResult.FromError(
                        error: InteractionCommandError.ConvertFailed, 
                        reason: $"Unable to parse input value as {typeof(T)}."));
            }
        }
    }
}

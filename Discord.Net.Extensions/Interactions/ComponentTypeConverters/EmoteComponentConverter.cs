﻿using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="ComponentTypeConverter{T}"/> to convert modal parameters into Emote or Emoji.
    /// </summary>
    public class EmoteComponentConverter : ComponentTypeConverter<IEmote>
    {
        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IComponentInteractionData option, IServiceProvider services)
            => Task.FromResult(Utils.ConverterExtensions.ConvertEmote(option.Value));
    }
}

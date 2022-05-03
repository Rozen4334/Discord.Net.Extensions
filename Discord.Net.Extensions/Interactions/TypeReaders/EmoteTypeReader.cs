﻿using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     A <see cref="TypeReader{T}"/> to convert component wildcards into <see cref="IEmote"/>.
    /// </summary>
    public class EmoteTypeReader : TypeReader<IEmote>
    {
        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, string option, IServiceProvider services)
            => Task.FromResult(Utils.ConverterExtensions.ConvertEmote(option));
    }
}

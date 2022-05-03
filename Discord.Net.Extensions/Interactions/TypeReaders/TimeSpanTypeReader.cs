using Discord.Extensions.Utils;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Interactions
{
    public class TimeSpanTypeReader : TypeReader<TimeSpan>
    {
        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, string option, IServiceProvider services)
            => Task.FromResult(TypeConverterResult.FromSuccess(LazyTimeSpanConverter.GetSpan(option)));
    }
}

using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Extensions.Interactions
{
    public class EmoteTypeReader : TypeReader<IEmote>
    {
        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, string option, IServiceProvider services)
        {
            throw new NotImplementedException();
        }
    }
}

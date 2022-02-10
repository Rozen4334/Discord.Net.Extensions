using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;

namespace Discord.Extensions.Interactions.Preconditions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class CheckUserIDAttribute : PreconditionAttribute
    {
    }
}

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
using Discord.Rest;
using Discord.WebSocket;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     Extensions for building an <see cref="IInteractionContext"/>
    /// </summary>
    public static class InteractionContext
    {
        /// <summary>
        ///     Generates a generic <see cref="RestInteractionContext{TInteraction}"/>. This function only works on REST received interactions.
        /// </summary>
        /// <param name="interaction">The succesfully parsed <see cref="RestInteraction"/> resulted from <see cref="DiscordRestClient.ParseHttpInteractionAsync(string, string, string, byte[])"/></param>
        /// <param name="client">The <see cref="DiscordRestClient"/> that should be passed into the context of this interaction.</param>
        /// <param name="callback">The initial REST response callback.</param>
        /// <returns>A <see cref="RestInteractionContext{TInteraction}"/> where TInteraction is the type of <paramref name="interaction"/>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IInteractionContext CreateGenericContext(this RestInteraction interaction, DiscordRestClient client, Func<string, Task> callback)
            => interaction switch
            {
                RestModal modal => new RestInteractionContext<RestModal>(client, modal, callback),
                RestUserCommand user => new RestInteractionContext<RestUserCommand>(client, user, callback),
                RestSlashCommand slash => new RestInteractionContext<RestSlashCommand>(client, slash, callback),
                RestMessageCommand message => new RestInteractionContext<RestMessageCommand>(client, message, callback),
                RestMessageComponent component => new RestInteractionContext<RestMessageComponent>(client, component, callback),
                _ => throw new InvalidOperationException("This interaction type is unsupported! Please report this.")
            };

        /// <summary>
        ///     Generates a generic <see cref="SocketInteractionContext{TInteraction}"/>.
        /// </summary>
        /// <param name="interaction">The interaction received from <see cref="BaseSocketClient.InteractionCreated"/> event.</param>
        /// <param name="client">The <see cref="DiscordSocketClient"/> that should be passed into the context of this interaction.</param>
        /// <returns>A <see cref="SocketInteractionContext{TInteraction}"/> where TInteraction is the type of <paramref name="interaction"/>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IInteractionContext CreateGenericContext(this SocketInteraction interaction, DiscordSocketClient client)
            => interaction switch
            {
                SocketModal modal => new SocketInteractionContext<SocketModal>(client, modal),
                SocketUserCommand user => new SocketInteractionContext<SocketUserCommand>(client, user),
                SocketSlashCommand slash => new SocketInteractionContext<SocketSlashCommand>(client, slash),
                SocketMessageCommand message => new SocketInteractionContext<SocketMessageCommand>(client, message),
                SocketMessageComponent component => new SocketInteractionContext<SocketMessageComponent>(client, component),
                _ => throw new InvalidOperationException("This interaction type is unsupported! Please report this.")
            };

        /// <summary>
        ///     Generates a generic <see cref="ShardedInteractionContext{TInteraction}"/>.
        /// </summary>
        /// <param name="interaction">The interaction received from <see cref="BaseSocketClient.InteractionCreated"/> event.</param>
        /// <param name="client">The <see cref="DiscordShardedClient"/> that should be passed into the context of this interaction.</param>
        /// <returns>A <see cref="ShardedInteractionContext{TInteraction}"/> where TInteraction is the type of <paramref name="interaction"/>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IInteractionContext CreateGenericContext(this SocketInteraction interaction, DiscordShardedClient client)
            => interaction switch
            {
                SocketModal modal => new ShardedInteractionContext<SocketModal>(client, modal),
                SocketUserCommand user => new ShardedInteractionContext<SocketUserCommand>(client, user),
                SocketSlashCommand slash => new ShardedInteractionContext<SocketSlashCommand>(client, slash),
                SocketMessageCommand message => new ShardedInteractionContext<SocketMessageCommand>(client, message),
                SocketMessageComponent component => new ShardedInteractionContext<SocketMessageComponent>(client, component),
                _ => throw new InvalidOperationException("This interaction type is unsupported! Please report this.")
            };
    }
}

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

using System.Threading.Tasks;
using Discord.Rest;

namespace Discord.Extensions.Core.Webhooks
{
    /// <summary>
    ///     Provides a number of extensions to the webhooks.
    /// </summary>
    public static class WebhookExtensions
    {
        /// <summary>
        /// Sets a avatar of the webhook for url. 
        /// </summary>
        /// <param name="webhook">The webhook to be changed.</param>
        /// <param name="url">The url of the avatar.</param>
        /// <returns>The same <paramref name="webhook"/> with updated avatar.</returns>
        public static async Task SetUrlAvatar(this RestWebhook webhook, string url)
        {
            MemoryStream avatar = new (await new HttpClient().GetByteArrayAsync(url));
            
            await webhook.ModifyAsync(wh => wh.Image = new Image(avatar));
        }
    }
}
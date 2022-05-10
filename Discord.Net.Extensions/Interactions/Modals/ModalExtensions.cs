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
using System.Collections.Immutable;

namespace Discord.Extensions.Interactions
{
    /// <summary>
    ///     Provides a number of extensions for <see cref="IModal"/>'s.
    /// </summary>
    public static class ModalExtensions // This is not declared in Core because IModal is part of Interactions.
    {
        /// <summary>
        ///     Generates a <see cref="ModalBuilder"/> from the attributes in <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="IModal"/> to turn into a modal builder.</typeparam>
        /// <param name="instance">The instance of the modal.</param>
        /// <returns>A newly created <see cref="ModalBuilder"/> with all inputs from the provided <see cref="IModal"/>.</returns>
        public static ModalBuilder ToModalBuilder<T>(this T instance) where T : IModal
        {
            var modalBuilder = new ModalBuilder();

            modalBuilder.WithTitle(instance.Title);

            var type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                var inputBuilder = new TextInputBuilder();
                foreach (var attribute in prop.GetCustomAttributes(true))
                    switch (attribute)
                    {
                        case ModalTextInputAttribute text:
                            inputBuilder
                                .WithStyle(text.Style)
                                .WithPlaceholder(text.Placeholder)
                                .WithValue(text.InitialValue)
                                .WithMaxLength(text.MaxLength)
                                .WithMinLength(text.MinLength)
                                .WithCustomId(text.CustomId);

                            break;
                        case RequiredInputAttribute required:
                            inputBuilder.WithRequired(required.IsRequired);
                            break;
                        case InputLabelAttribute label:
                            inputBuilder.WithLabel(label.Label);
                            break;
                        default:
                            break;
                    }
                inputBuilder.Build();
            }

            return modalBuilder;
        }

        /// <summary>
        ///     Gets an <see cref="ImmutableDictionary"/> of <see cref="TextInputBuilder"/>'s with the defined values from the modal property attributes.
        /// </summary>
        /// <remarks>
        ///     This extension allows for <see cref="IModal"/> properties to be transfered to text input builders for better customizability.
        /// </remarks>
        /// <typeparam name="T">The modal to create a new range of <see cref="TextInputBuilder"/>'s for.</typeparam>
        /// <returns>
        ///     An <see cref="IReadOnlyDictionary{TKey, TValue}"/> of which the key is the defined <see cref="ModalTextInputAttribute"/>'s custom ID, 
        ///     and the value is the <see cref="TextInputBuilder"/> created from the properties.
        /// </returns>
        public static IReadOnlyDictionary<string, TextInputBuilder> ToTextInputBuilders<T>() where T : IModal
        {
            var builder = ImmutableDictionary.CreateBuilder<string, TextInputBuilder>();

            var type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                var inputBuilder = new TextInputBuilder();
                foreach (var attribute in prop.GetCustomAttributes(true))
                    switch (attribute)
                    {
                        case ModalTextInputAttribute text:
                            inputBuilder
                                .WithStyle(text.Style)
                                .WithPlaceholder(text.Placeholder)
                                .WithValue(text.InitialValue)
                                .WithMaxLength(text.MaxLength)
                                .WithMinLength(text.MinLength)
                                .WithCustomId(text.CustomId);
                            break;
                        case RequiredInputAttribute required:
                            inputBuilder.WithRequired(required.IsRequired);
                            break;
                        case InputLabelAttribute label:
                            inputBuilder.WithLabel(label.Label);
                            break;
                        default:
                            break;
                    }
                builder.Add(inputBuilder.CustomId, inputBuilder);
            }

            return builder.ToImmutable();
        }

        /// <summary>
        ///     Turns the collection returned by <see cref="ToTextInputBuilders{T}"/> into a <see cref="ModalBuilder"/>.
        /// </summary>
        /// <param name="collection">The collection created by <see cref="ToTextInputBuilders{T}"/> or from other sources.</param>
        /// <returns>A newly created <see cref="ModalBuilder"/> from the values in <paramref name="collection"/>.</returns>
        public static ModalBuilder ToModalBuilder(this IReadOnlyDictionary<string, TextInputBuilder> collection)
        {
            var builder = new ModalBuilder();

            foreach (var kvp in collection)
                builder.AddTextInput(kvp.Value);

            return builder;
        }
    }
}

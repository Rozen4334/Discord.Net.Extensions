# ➕ Discord.Net.Extensions

This package introduces a number of features that assist [Discord.Net](https://github.com/discord-net/Discord.Net) as a library. 
It attempts to make work for the developer easier, by introducing extensions that perfectly support development needs.

## ℹ️ How to install

### Grabbing the package from NuGet:

The Discord.Net.Extensions package is available on [Nuget](https://www.nuget.org/packages/Discord.Net.Extensions/) or through the package manager:
- `PM> Install-Package Discord.Net.Extensions -Version 1.2.1`

### Installing from Visual Studio:

Just like Discord.Net, Discord.Net.Extensions is available from the NuGet package manager built into VS:

![Go to the Manager](https://rozen.one/files/devenv_JcPwXUnJxP.png)

### Installing from Rider:

![Go to the Manager](https://i.ibb.co/djm4Yf5/Rider.png)

### Applying namespaces:

The naming of this package follows that of Discord.Net:

```cs
using Discord;
using Discord.Extensions;
```

Because the package is seperate, and not a part of the library itself, it levels down a single name on the namespace. 
It does still follow the naming of Discord.Net itself however:

```cs
using Discord.Interactions;
using Discord.Extensions.Interactions;
```

Depending on the namespace of the type you're looking to target, its extensions will be in the matching `Extensions` namespace.

# 📑 Features

Below a number of features is covered, including notices of logic, examples or exceptions.

## 🌐 Core

### Message Formatting support

- `MessageBuilder` has been introduced to allow for large text message creation to look a lot cleaner & helps avoid a lot of markdown errors.

> Alternatively, inside the `DiscordFormattingExtensions` class a large amount of formatting extensions exist, allowing developers to customize messages with ease.

### Builder Factories

- `EmbedBuilderFactory`
- `ComponentBuilderFactory`
- `ModalBuilderFactory`

> These factories generate builders based on the actions defined in `BuilderSettings`. View the [Samples](https://github.com/Rozen4334/Discord.Net.Extensions/tree/master/Samples) for how to use it.

## 💤 Rest

In progress...

## ⚡ Websocket

In progress...

## 🪝 Webhook

In progress...

## ❗ Commands

In progress...

## ⭕ Interactions

### IModal to ModalBuilder support

Thanks to the design of modals in Discord.Net, a few extensions have been added to turn `IModal`'s into `ModalBuilder`'s with populated values.

### Generic Context Generation

For each type of `Interaction` a method has been introduced to automatically generate generic `IInteractionContext`, 
supporting the use-case of `XInteractionContext<XInteraction>`.

> View the [Samples](https://github.com/Rozen4334/Discord.Net.Extensions/tree/master/Samples) to learn how to use these methods.

### Type converters for commands, modals & components.

- **TypeReaders**
  - `Color`
  - `TimeSpan`\*
  - `Guid`
  - `IEmote`\*\*

- **TypeConverters**
  - `Color`
  - `TimeSpan`\*
  - `UInt64`\*\*\*
  - `IEmote`\*\*

- **ComponentTypeConverters**
  - `Color`
  - `TimeSpan`\*
  - `IEmote`\*\*

> \* The `TimeSpan` converters run through a reader far more advanced than a simple `TryParse`. 
> It supports formatting such as: 1d16h10m up to 10 weeks, 4 months & 7 seconds. Parsing does not respect order, and works in any format.

> \*\* The `IEmote` converters support `Emoji` and `Emote`. Both can be parsed from this parser. 
> However, the parameter implementation will have to be `IEmote` as well, regardless of the underlying type.

> \*\*\* The `UInt64` (ulong) converter is introduced because the `Int64` (number) 
> parameter from discord does not support unsigned positive characters up to the height of Discord snowflake ID's.

## ✨ Peculiarities of Discord

1. You can use **any** emote in webhooks.
Also you use emote only using it's id without the title.
For an example, <:quinpat:923586781465706548>

2. Every bot has nitro. You can use any emote from servers if your bot is there.

3. There is no way to edit or delete an ephemeral message but this bot could...

![Bot can everything](https://user-images.githubusercontent.com/64978711/168347881-cb5f9228-817e-418a-b085-4f2e8e92b71e.png)

4. Bots can change their status and activity.

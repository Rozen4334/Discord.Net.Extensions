# Discord.Net.Extensions

This package introduces a number of features that assist Discord.Net as a library. 
It attempts to make work for the developer easier, by introducing extensions that perfectly support development needs

## Practices

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

# Features

## Core

### Formatting support

Inside the `DiscordFormattingExtensions` class a large amount of formatting extensions exists, allowing users to customize developers with ease.

## Rest

In progress...

## Websocket

In progress...

## Webhook

In progress...

## Commands

In progress...

## Interactions

### Generic Context Generation

For each type of `Interaction` a method has been introduced to automatically generate generic `IInteractionContext`, 
supporting the use-case of `XInteractionContext<XInteraction>`

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

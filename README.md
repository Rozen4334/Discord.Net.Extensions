# ➕ Discord.Net.Extensions

This package introduces a number of features that assist Discord.Net as a library. 
It attempts to make work for the developer easier, by introducing extensions that perfectly support development needs.

## ℹ️ Practices

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

### Formatting support

Inside the `DiscordFormattingExtensions` class a large amount of formatting extensions exists, allowing developers to customize messages with ease.

## 💤 Rest

In progress...

## ⚡ Websocket

In progress...

## 🪝 Webhook

In progress...

## ❗ Commands

In progress...

## ⭕ Interactions

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

# 🧑‍💻 Code & Contribution

If you want to contribute to Discord.Net.Extensions, it is suggested you read the below information first, so you understand the method in which the extension functions.

## 🌿 Branches

- `master`
  - Main branch, no direct pushes will be made here unless they do not affect the extension itself.
- `feature/x`
  - Introduces new features to the library.
- `fix/x`
  - Fixes part of the library.
- `doc/x`
  - Adds or modifies documentation.

> For one-time pulls such as adding licensing, no specific branch format exists.

## 🚄 Contributing

- Fork the repository
- Create a new branch, preferably one that matches the feature/fix you're implementing
- Commit to the branch, adding or removing whichever is being added.
- Open a PR to the master branch of this repo.
  - Await review, merge potential uproot commits.

> Contributing to Discord.Net.Extensions means you are part of the CR stated in the MIT licensing of this project.

## 🔢 Versioning

Discord.Net.Extensions aims to project Discord.Net versioning. This mean semantic versioning is expected:

- We will only increment `MAJOR` versioning if a breaking change is made in Discord or in this extension. 

- We will only increment `MINOR` versioning if a new feature is introduced or a number of patches are ready to be released.

- We will only increment `PATCH` if a patch must immediately be pushed as it breaks the flow of the extension.

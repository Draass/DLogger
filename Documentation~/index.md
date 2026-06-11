# DLogger Documentation

## Overview

DLogger is a lightweight structured logging package for Unity. It wraps `UnityEngine.Debug` with:

- log levels with a configurable minimum level (`Info`, `Warning`, `Error`, `Exception`, `None`),
- strongly-typed tags for filtering,
- pluggable output sinks (`ILoggerService`),
- a custom editor console (DConsole) with tag/level filtering, search, collapse and clickable stack traces.

## Core API

### Logging

```csharp
using DraasGames.Logging;

DLogger.Log(string message, object sender = null, params DLogTag[] tags);
DLogger.LogWarning(string message, object sender = null, params DLogTag[] tags);
DLogger.LogError(string message, object sender = null, params DLogTag[] tags);
DLogger.LogException(Exception exception, params DLogTag[] tags);
```

`sender` is used to prefix messages with `[TypeName]` and to show the sender column in DConsole.

### Minimum level

`DLogger.MinimumLevel` gates all messages. It is loaded from the `DLoggerSettings` asset
(`Assets/Resources/DraasGames/DLoggerSettings.asset`) on first use; call `DLogger.ReloadSettings()`
to re-read it. Set `DLogLevel.None` to silence everything.

### Sinks

Default sinks are registered automatically: a color-formatted console sink in the editor, a plain
`Debug` sink in standalone/mobile players. Add your own:

```csharp
DLogger.AddLogger(new MyLoggerService());   // implements ILoggerService
DLogger.RemoveLogger(service);
DLogger.RemoveAllLoggers();
```

### Structured events

`DLogger.MessageLogged` fires a `DLogEntry` (level, message, sender, tags, source) for every message
that passes the level gate — this is what feeds DConsole, and you can subscribe to it yourself.

## Tags

1. Define tag names in **Project Settings > DraasGames > DLogger** or **DraasGames > Logger > Tags Editor**.
2. Click **Generate Tags**. A static `DLogTags` class is generated (default:
   `Assets/DraasGames/Generated/DLogTags.cs`, namespace and path are configurable in the settings).
3. Use the constants at call sites: `DLogger.Log("msg", this, DLogTags.UI);`

For dynamic tags use `DLogTag.Of("MyTag")`. The name `None` is reserved for the DConsole
"untagged" filter.

## DConsole

Open via **Window > DraasGames > Console**.

- Per-level toggle buttons with live counts.
- Tags dropdown (multi-select, `None` = untagged messages).
- Free-text search across message, sender and tags.
- Collapse mode groups identical messages with an occurrence badge.
- Clear on Play, auto-scroll.
- Double-click a row (or click a stack frame in the detail pane) to open the source line in your IDE.
- Compiler errors are kept through manual Clear so they stay visible until fixed.

## Settings asset

`DLoggerSettings` lives in your project (not in the package) at
`Assets/Resources/DraasGames/DLoggerSettings.asset` so it can be versioned with the project and the
package can be updated independently. It stores the minimum level, the tag list and the generated
tags namespace/path.

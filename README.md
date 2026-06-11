# DLogger

Tagged, level-filtered logging for Unity with a custom console window.

- **`DLogger` static API** — `Log`, `LogWarning`, `LogError`, `LogException` with an optional sender and tags.
- **Strongly-typed tags** — define tag names once, generate a compile-safe `DLogTags` constants class, then write `DLogger.Log("Loaded", this, DLogTags.UI)`.
- **Minimum level filtering** — configured per project via a `DLoggerSettings` asset (Project Settings > DraasGames > DLogger).
- **Pluggable sinks** — implement `ILoggerService` and register it with `DLogger.AddLogger` to forward messages anywhere (file, server, on-screen overlay).
- **DConsole** — a Unity-console-like editor window (`Window > DraasGames > Console`) with per-level toggles, a multi-select tag filter, free-text search, collapse mode and clickable stack traces.
- **Zero dependencies** — runtime code depends only on UnityEngine.

## Installation

### Via git URL (Package Manager)

`Window > Package Manager > + > Add package from git URL...`

```
https://github.com/Draass/DraasGames.DLogger.git#v0.1.0
```

### Requirements

Unity 2022.3 or newer.

## Quick start

```csharp
using DraasGames.Logging;

DLogger.Log("Hello!");                          // plain info message
DLogger.LogWarning("Low memory", this);         // with a sender (prefixes [TypeName])
DLogger.LogError("Load failed", this, DLogTags.Network); // with a tag
```

1. Open **Project Settings > DraasGames > DLogger** — the settings asset is created automatically at `Assets/Resources/DraasGames/DLoggerSettings.asset`.
2. Edit the tag list (or use **DraasGames > Logger > Tags Editor**), then click **Generate Tags** to build the `DLogTags` constants class.
3. Open **Window > DraasGames > Console** to view, filter and search messages.

### Custom sinks

```csharp
public sealed class FileLoggerService : ILoggerService
{
    public void Log(string message, object sender = null) { /* ... */ }
    public void LogWarning(string message, object sender = null) { /* ... */ }
    public void LogError(string message, object sender = null) { /* ... */ }
    public void LogException(Exception exception) { /* ... */ }
}

DLogger.AddLogger(new FileLoggerService());
```

## License

[MIT](LICENSE.md)

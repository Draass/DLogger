# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.2.0] - 2026-06-12

### Added

- DConsole: row context menu with Copy / Copy Message / Copy Stack Trace.
- DConsole: Save button that exports the captured log to a text file.
- DConsole: Error Pause toggle — pauses Play mode when an error or exception is logged.
- Console buffer capacity is now configurable via DLoggerSettings (Console Capacity, default 5000).

## [0.1.0] - 2026-06-11

### Added

- Initial release as a standalone package, extracted from `com.draasgames.core`.
- `DLogger` static API: `Log`, `LogWarning`, `LogError`, `LogException` with optional sender and tags.
- `DLogLevel` minimum-level filtering, configured via `DLoggerSettings` asset (Project Settings > DraasGames > DLogger).
- Pluggable sinks via `ILoggerService` (`AddLogger` / `RemoveLogger`). A default console sink is registered on every player platform; the editor uses a color-formatted one.
- Strongly-typed tags (`DLogTag`) with compile-safe generated constants (`DraasGames/Logger/Generate Tags`).
- DConsole editor window (`Window/DraasGames/Console`): tag and level filtering, search, collapse, clickable stack traces.

### Changed

- Namespaces moved to `DraasGames.Logging` (was `DraasGames.Core.Runtime.Infrastructure.Logger`).
- Default generated tags path is now `Assets/DraasGames/Generated/DLogTags.cs`.

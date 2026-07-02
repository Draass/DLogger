# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.2.1] - 2026-07-02

### Fixed

- Regenerated script GUIDs that were carried over from `com.draasgames.core`. They collided with the copies still shipped in Core <= 0.3.8, so Unity silently dropped the package scripts and compilation failed with `CS0246: DLogLevel could not be found`.

### Upgrade notes

- `DLoggerSettings` assets created with 0.1.0-0.2.0 reference the old script GUID and will show up as "missing script" after updating. Delete the asset and reopen Project Settings > DraasGames > DLogger to recreate it.

## [0.2.0] - 2026-06-12

### Added

- DConsole: row context menu with Copy / Copy Message / Copy Stack Trace.
- DConsole: Save button that exports the captured log to a text file.
- DConsole: Error Pause toggle — pauses Play mode when an error or exception is logged.

### Removed

- The unused `DLogSource` enum and `DLogEntry.Source` property.

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

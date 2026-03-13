# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Test Commands

This is a .NET Framework 4.8 solution. Use MSBuild or Visual Studio to build.

```bash
# Restore NuGet packages
nuget restore Greed/Greed.sln

# Build (Debug)
msbuild Greed/Greed.sln /p:Configuration=Debug

# Run tests
mstest /testcontainer:Greed/Greed.Test/bin/Debug/Greed.Test.dll

# Run the app
Greed/Greed/bin/Debug/Greed.exe
```

## Architecture

This is a Greed dice-scoring kata implemented as a C# console app.

- **[Greed/Greed/Greed.cs](Greed/Greed/Greed.cs)** — Core scoring logic. The `Dice` class exposes one public method: `GetScore(int[] diceRolls)`. Internally it counts die face frequencies, then checks for special combinations (straight, three pairs) before scoring multiples and singles.
- **[Greed/Greed/Program.cs](Greed/Greed/Program.cs)** — Console entry point; handles user input and calls `Dice.GetScore`.
- **[Greed/Greed.Test/GreedTest.cs](Greed/Greed.Test/GreedTest.cs)** — 14 MSTest unit tests covering all scoring scenarios.

## Scoring Rules

Standard rules (5 dice) plus extra credit (up to 6 dice):
- Single 1 = 100, single 5 = 50
- Triple N = N×100 (triple 1s = 1000)
- Four/Five/Six-of-a-kind = triple score × 2/4/8
- Three pairs = 800
- Straight (1–6) = 1200

# Day Length

Makes each in-game day last longer in real time. Twice as long by default.

A day in Survival Log goes by fast. Day Length slows the game clock so each day lasts as many times longer as you set, and everything that runs on the clock slows with it: hunger and other needs, plant growth, disaster countdowns and the time actions take. You get more real time to think and plan each day, and the game stays balanced because nothing gets ahead of the clock.

## Features

- **Longer days**: set `DayLength` to how many times longer a day should last. 2 (the default) means a day takes twice as long in real time. Any value from 0.25 to 10 works.
- **Everything keeps pace**: hunger and other needs, plant growth, disaster countdowns and action times all run on the same clock, so they all stretch with the day. A day still costs the same food and brings disasters on the same day as before.
- **Shorter days too**: a value below 1 makes days shorter instead. 0.5 means a day goes by in half the real time.
- **Every save**: the day length is set each time you load a save, for every save and every chapter.

Day Length changes how fast game time passes. It writes nothing into your save and does not edit game files. You can remove it at any time; the next save you load runs at the game's normal day length.

It shows no text of its own, so it works with the game set to any language.

## Known issues and limits

- **Actions take longer in real time.** Actions cost game time, and game time now passes more slowly, so with 2x days an action takes twice as long to watch. To keep actions as fast as before, raise the action speeds in the Action Speed mod by the same amount.
- **The day length is rounded.** The game counts time with a whole number, so the day length you get can be a little off from the one you set. The log shows the length you actually got (see Troubleshooting).
- **Changes need a restart.** The setting is read when the game starts and applied when you load a save.

## Requirements

- Survival Log 1.1.18902. Built and tested on this version; a game update can break it until the mod is updated.
- The [BepInEx Pack for Survival Log](https://www.nexusmods.com/survivallog/mods/12), the BepInEx 6 (IL2CPP) build for the game.

## Install

1. Install the [BepInEx Pack for Survival Log](https://www.nexusmods.com/survivallog/mods/12) (if no other mods were installed before, start the game once so BepInEx finishes setup, then quit).
2. Download `DayLength-x.y.z.zip` from the [latest release](https://github.com/AnExiledDev/SurvivalLog-DayLength/releases/latest) or from [Nexus Mods](https://www.nexusmods.com/survivallog/mods/50).
3. Extract the zip into the game folder (the folder with `SurvivalLog.exe`). It holds a `BepInEx` folder, so the DLL lands in the right place. When asked, merge the folders. The result should be:
   `C:\Program Files (x86)\Steam\steamapps\common\Survival Log\BepInEx\plugins\DayLength.dll`

## Uninstall

Delete `DayLength.dll` from the `BepInEx\plugins` folder. For a clean slate, also delete `BepInEx\config\com.dev.survivallog.daylength.cfg`.

## Keys

None. Day Length has no hotkeys and no buttons.

## Configuration

Settings live in `BepInEx\config\com.dev.survivallog.daylength.cfg`, created the first time the game starts with the mod. Edit it while the game is closed; changes apply when you load a save after the next game start. See [CONFIG.md](CONFIG.md) for every setting.

## Troubleshooting

Day Length writes to `BepInEx\LogOutput.log`. Check it for these lines:

- `Day Length 0.1.0 started` when the game starts.
- `hooked the world start, days will be 2x as long` right after. A line starting with `could not hook` instead means a game update broke the mod, and days keep their normal length.
- `time scale A -> B, days are Nx as long` each time you load a save. N is the day length you actually got after rounding. No such line means the setting is 1, or the game's clock was already at that speed.

## Feedback and bug reports

Found a bug, have an idea, or something feels off? Come say so on the Core Directive Discord: https://discord.gg/trTsyxUFqg . You can also leave a comment on the Nexus page or [open an issue](https://github.com/AnExiledDev/SurvivalLog-DayLength/issues). When reporting a bug, attach `BepInEx\LogOutput.log`.

## Build

This is a BepInEx 6 IL2CPP plugin. It compiles against BepInEx and the game's IL2CPP interop assemblies, so a game install with BepInEx set up and started once is required. Those assemblies come from the game and are not part of this repo. The .NET 8 SDK is required.

```
dotnet build src/DayLength -c Release -p:GameDir="C:\path\to\Survival Log"
```

`GameDir` is the game folder. The default in the project file is a local path you will almost certainly need to override. The output DLL is at `src\DayLength\bin\Release\DayLength.dll`.

The unit tests cover the pure day length math and need nothing from the game:

```
dotnet test tests/DayLength.Tests
```

## License

MIT. Copyright (c) 2026 AnExiledDev. See [LICENSE](LICENSE).

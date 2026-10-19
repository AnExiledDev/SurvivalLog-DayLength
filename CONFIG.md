# Day Length settings

Settings live in `BepInEx\config\com.dev.survivallog.daylength.cfg`, created the first time the game starts with the mod. Change it in game on the Mod Manager's Mods screen, or edit the file while the game is closed. A new day length takes effect the next time you load a save. Delete the file to get the defaults back. Without Exiled's Toolkit installed, changes made on the Mods screen take effect at the next game start instead.

## Day

| Setting | Default | What it does |
| --- | --- | --- |
| `DayLength` | `2` | How many times longer each in-game day lasts in real time. 2 means a day takes twice as long. From 0.25 to 10. |

`1` is the game's normal day length, and the mod then changes nothing. A value below 1 makes days shorter: `0.5` means a day goes by in half the real time. A value outside 0.25 to 10 is held to the nearest limit.

Hunger and other needs, plant growth, disaster countdowns and action times all stretch with the day. Actions therefore take longer in real time; to keep them as fast as before, raise the action speeds in the Action Speed mod by the same amount.

The game counts time with a whole number, so the day length you get is rounded and can be a little off from the one you set. Each time you load a save, `BepInEx\LogOutput.log` shows the length you actually got in a line like `time scale A -> B, days are Nx as long`.

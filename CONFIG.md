# Day Length settings

Settings live in `BepInEx\config\com.dev.survivallog.daylength.cfg`, created the first time the game starts with the mod. Change it in game on the Mod Manager's Mods screen, or edit the file while the game is closed. A new day length takes effect the next time you load a save. Delete the file to get the defaults back.

## Day

| Setting | Default | What it does |
| --- | --- | --- |
| `DayLength` | `1` | How many times longer each in-game day lasts in real time. 2 means a day takes twice as long. From 0.25 to 10. |

`1`, the default, is the normal day length, and the mod changes nothing. Set `2` for days twice as long. A value below 1 makes days shorter: `0.5` means a day goes by in half the real time. A value below 0.25 counts as 0.25, and a value above 10 counts as 10.

Hunger and other needs, plant growth, disaster countdowns and action times all stretch with the day. That means actions take longer in real time too. To keep them as fast as before, raise the action speeds in the Action Speed mod by the same amount.

The game counts time with a whole number, so the day length you get is rounded and can be a little off from the one you set. Each time you load a save, `BepInEx\LogOutput.log` shows the length you actually got in a line like `time scale A -> B, days are Nx as long`.

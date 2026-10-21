Name: Day Length
Summary: Make every in-game day last longer in real time, twice as long by default, anywhere from 0.25x to 10x. Hunger, plant growth, action times and disaster countdowns all stretch with it, so a day still costs the same food and disasters still arrive on the same day. You just get more real time to plan. Set it below 1 for shorter days.

Description (BBCode):
Days in Survival Log go by fast. Day Length slows the game clock so each day lasts longer in real time, and everything that runs on the clock slows with it. You get more time to think and plan, and nothing gets ahead of the clock.

[size=5]Main features[/size]
[list]
[*][b]Longer days[/b]: set how many times longer a day should last. 2 (the default) means a day takes twice as long in real time. Any value from 0.25 to 10 works.[/*]
[*][b]Everything keeps pace[/b]: hunger and other needs, plant growth, disaster countdowns and action times stretch with the day, so a day still costs the same food and disasters still come on the same day.[/*]
[*][b]Shorter days too[/b]: a value below 1 makes days shorter instead.[/*]
[*][b]Every save[/b]: the day length is set each time you load a save.[/*]
[/list]
Day Length only changes how fast game time passes. It writes nothing into your save and does not edit game files. You can remove it at any time.

It shows no text of its own, so it works with the game in any language.

[size=5]Known issues[/size]
[list]
[*]Actions cost game time, so with longer days they also take longer in real time. To keep actions as fast as before, raise the action speeds in the Action Speed mod by the same amount.[/*]
[*]The game counts time with a whole number, so the day length you get can be a little off from the one you set. [font=Courier New]BepInEx\LogOutput.log[/font] shows the length you actually got each time you load a save.[/*]
[/list]

[size=5]Requirements[/size]
[list]
[*]Survival Log 1.1.19131. A game update can break it until the mod is updated.[/*]
[*][url=https://www.nexusmods.com/survivallog/mods/12]BepInEx for Survival Log[/url]. Install it first.[/*]
[*]Optional: [url=https://www.nexusmods.com/survivallog/mods/61]Exiled's Toolkit[/url] 0.4.0 or newer. With it, settings changed on the Mod Manager's Mods screen take effect without restarting the game. Without it, they take effect at the next game start.[/*]
[/list]

[size=5]Installation[/size]
[list=1]
[*]Install [url=https://www.nexusmods.com/survivallog/mods/12]BepInEx[/url] [i](if no other mods were installed before, start the game once so BepInEx finishes setup, then quit)[/i].[/*]
[*]Optional, to change settings without a restart: install Exiled's Toolkit the same way. Download its zip and extract it into the game folder.[/*]
[*]Download the zip from the Files tab.[/*]
[*]Extract it into the game folder (the folder with [font=Courier New]SurvivalLog.exe[/font]). The zip holds a BepInEx folder, so the DLL lands in the right place. When asked, merge the folders. The result should be:
[code]C:\Program Files (x86)\Steam\steamapps\common\Survival Log\BepInEx\plugins\DayLength.dll[/code][/*]
[/list]

[size=5]Uninstall[/size]
Delete [font=Courier New]DayLength.dll[/font] from the [font=Courier New]BepInEx\plugins[/font] folder.

[size=5]Configuration[/size]
To change the day length, edit [font=Courier New]DayLength[/font] in [font=Courier New]BepInEx\config\com.dev.survivallog.daylength.cfg[/font] while the game is closed, or do it in game on the Mod Manager's Mods screen (see [url=https://github.com/AnExiledDev/SurvivalLog-DayLength/blob/main/CONFIG.md]CONFIG.md[/url] for details). A new day length takes effect the next time you load a save. Without Exiled's Toolkit installed, changes made on the Mods screen take effect at the next game start instead.

[size=5]Feedback[/size]
Found a bug or have an idea? Come say hi on the [url=https://discord.gg/trTsyxUFqg]Core Directive Discord[/url], or post in this page's Posts tab. For bugs, please include [font=Courier New]BepInEx\LogOutput.log[/font].
To reach me directly, message [b]exiled.dev[/b] on Discord; you can find me in the [url=https://discord.gg/MZGg4gQAUe]official Survival Log Discord[/url]. I'm also on X as [url=https://x.com/AnExiledDev]@AnExiledDev[/url].
Coming soon: a Survival Log wiki with detailed documentation for all of my mods.

[size=5]Source and license[/size]
Open source under MIT: [url=https://github.com/AnExiledDev/SurvivalLog-DayLength]github.com/AnExiledDev/SurvivalLog-DayLength[/url]

[line]
[size=5]简体中文[/size]

Survival Log 里的一天过得很快。Day Length 会放慢游戏时钟，让每一天在现实中持续更久，所有跟着时钟走的东西也会一起放慢。你有更多时间思考和规划，也不会有任何东西跑在时钟前面。

[size=5]主要功能[/size]
[list]
[*][b]更长的一天[/b]：设置一天要延长到几倍。默认值 2 表示一天的现实时间变为原来的两倍。可设为 0.25 到 10 之间的任意数值。[/*]
[*][b]一切同步放慢[/b]：饥饿等需求、植物生长、灾难倒计时和动作时间都会随一天一起变长，所以每天消耗的食物不变，灾难也仍在同一天到来。[/*]
[*][b]也能缩短[/b]：设为小于 1 的数值，一天反而会变短。[/*]
[*][b]所有存档通用[/b]：每次读取存档时都会设置一天的长度。[/*]
[/list]
Day Length 只改变游戏时间流逝的快慢，不会往存档里写入任何内容，也不会修改游戏文件，随时可以移除。

模组本身不显示任何文字，所以游戏设为任何语言都能用。

[size=5]已知问题[/size]
[list]
[*]动作会消耗游戏时间，所以一天变长后，动作在现实中花的时间也会变长。如果想让动作保持原来的速度，请在 Action Speed 模组中把动作速度提高相同的倍数。[/*]
[*]游戏用整数计算时间，所以实际得到的一天长度可能和设置的数值略有出入。每次读取存档时，[font=Courier New]BepInEx\LogOutput.log[/font] 都会记录实际的长度。[/*]
[/list]

[size=5]前置要求[/size]
[list]
[*]Survival Log 1.1.19131。游戏更新后模组可能暂时失效，直到模组更新为止。[/*]
[*][url=https://www.nexusmods.com/survivallog/mods/12]BepInEx for Survival Log[/url]，请先安装。[/*]
[*]可选：[url=https://www.nexusmods.com/survivallog/mods/61]Exiled's Toolkit[/url] 0.4.0 或更新版本。装了它，在 Mod Manager 的「模组」界面改动的设置无需重启游戏即可生效；没装的话，改动在下次启动游戏时生效。[/*]
[/list]

[size=5]安装[/size]
[list=1]
[*]安装 [url=https://www.nexusmods.com/survivallog/mods/12]BepInEx[/url] [i]（如果之前没有装过其他模组，先启动一次游戏，让 BepInEx 完成初始化，然后退出）[/i]。[/*]
[*]可选（改动设置无需重启游戏）：用同样的方式安装 Exiled's Toolkit，下载它的压缩包并解压到游戏目录。[/*]
[*]在「文件」页下载压缩包。[/*]
[*]把压缩包解压到游戏目录（[font=Courier New]SurvivalLog.exe[/font] 所在的文件夹）。压缩包里带有 BepInEx 文件夹，DLL 会自动放到正确位置。如果提示合并文件夹，选择合并。解压后应为：
[code]C:\Program Files (x86)\Steam\steamapps\common\Survival Log\BepInEx\plugins\DayLength.dll[/code][/*]
[/list]

[size=5]卸载[/size]
从 [font=Courier New]BepInEx\plugins[/font] 文件夹中删除 [font=Courier New]DayLength.dll[/font]。

[size=5]配置[/size]
如需修改一天的长度，可以在游戏内 Mod Manager 的「模组」界面修改，也可以在游戏关闭时编辑 [font=Courier New]BepInEx\config\com.dev.survivallog.daylength.cfg[/font] 中的 [font=Courier New]DayLength[/font]。配置文件中的设置有中文说明，完整说明见 [url=https://github.com/AnExiledDev/SurvivalLog-DayLength/blob/main/CONFIG.md]CONFIG.md[/url]（英文）。新的长度会在下次读取存档时生效。没装 Exiled's Toolkit 的话，在「模组」界面的改动改为在下次启动游戏时生效。

[size=5]反馈[/size]
发现 bug 或有好点子？欢迎来 [url=https://discord.gg/trTsyxUFqg]Core Directive Discord[/url] 打个招呼，或在本页的「Posts」标签里发帖。报告 bug 时，请附上 [font=Courier New]BepInEx\LogOutput.log[/font]。
想直接联系我，可以在 Discord 上给 [b]exiled.dev[/b] 发消息，我在 [url=https://discord.gg/MZGg4gQAUe]Survival Log 官方 Discord[/url] 里。也可以在 X 上找我：[url=https://x.com/AnExiledDev]@AnExiledDev[/url]。
即将推出：Survival Log 维基，收录我所有模组的详细说明。

[size=5]源代码与许可[/size]
基于 MIT 许可开源：[url=https://github.com/AnExiledDev/SurvivalLog-DayLength]github.com/AnExiledDev/SurvivalLog-DayLength[/url]

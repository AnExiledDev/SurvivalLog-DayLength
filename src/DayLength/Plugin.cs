using BepInEx;
using BepInEx.Unity.IL2CPP;
using ExiledToolkit;
using DayLength.Adapters;
using DayLength.Core;
using HarmonyLib;

namespace DayLength;

[BepInPlugin(Guid, "Day Length", Version)]
[BepInDependency(ExiledToolkit.Plugin.Guid, ">=0.4.0")]
public sealed class Plugin : BasePlugin
{
    private const string Guid = "com.dev.survivallog.daylength";
    private const string Version = "0.2.0";

    public override void Load()
    {
        var dayLength = Config.Bind("Day", "DayLength", 2.0,
            $"How many times longer each in-game day lasts. 2 means a day takes twice as long in real time. Hunger and other needs, plant growth, disaster countdowns and action times stretch with the day, so raise action speeds to keep actions as fast as before. From {DayScale.MinDayLength} to {DayScale.MaxDayLength}. Takes effect the next time you load a save.\n" +
            $"每个游戏日持续的倍数。2 表示一天的现实时间变为原来的两倍。饥饿等需求、植物生长、灾难倒计时和动作时间都会随之变长，如需保持原来的动作速度，请提高动作速度。范围 {DayScale.MinDayLength} 到 {DayScale.MaxDayLength}。下次读取存档时生效。");

        Log.LogInfo($"Day Length {Version} started");
        WorldStartPatch.Apply(new Harmony(Guid), Log.LogInfo);
        LiveSettings.Watch(dayLength, value => WorldStartPatch.UseDayLength(DayScale.ClampDayLength(value)));
    }
}

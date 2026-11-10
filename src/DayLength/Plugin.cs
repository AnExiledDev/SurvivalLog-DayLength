using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using DayLength.Adapters;
using DayLength.Core;
using HarmonyLib;

namespace DayLength;

[BepInPlugin(Guid, "Day Length", Version)]
[BepInDependency(ToolkitGuid, ">=0.20.0")]
public sealed class Plugin : BasePlugin
{
    private const string Guid = "com.dev.survivallog.daylength";
    private const string Version = "0.3.3";
    private const string ToolkitGuid = "com.dev.survivallog.exiledtoolkit";

    public override void Load()
    {
        var dayLength = Config.Bind("Day", "DayLength", DayScale.DefaultDayLength, new ConfigDescription(
            $"How many times longer each in-game day lasts. 1 is the game's day length and changes nothing; 2 means a day takes twice as long in real time. Hunger and other needs, plant growth, disaster countdowns and action times stretch with the day, so raise action speeds to keep actions as fast as before. From {DayScale.MinDayLength} to {DayScale.MaxDayLength}. Takes effect the next time you load a save.\n" +
            $"每个游戏日持续的倍数。1 为游戏原本的一天长度，不做任何改变；2 表示一天的现实时间变为原来的两倍。饥饿等需求、植物生长、灾难倒计时和动作时间都会随之变长，如需保持原来的动作速度，请提高动作速度。范围 {DayScale.MinDayLength} 到 {DayScale.MaxDayLength}。下次读取存档时生效。",
            null, "ModManager.WorldRule"));

        Log.LogInfo($"Day Length {Version} started");
        // The entry is read as the world starts: a world that keeps its own day length sets it just before.
        WorldStartPatch.Apply(new Harmony(Guid), Write, () => DayScale.ClampDayLength(dayLength.Value));
        ExiledToolkit.LiveSettings.Watch(dayLength, value => WorldStartPatch.LogDayLength(DayScale.ClampDayLength(value)));
    }

    private void Write(string message)
    {
        if (ExiledToolkit.Game.HookFailure.Is(message)) Log.LogError(message);
        else Log.LogInfo(message);
    }
}

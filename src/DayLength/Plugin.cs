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
    private const string Version = "0.3.4";
    private const string ToolkitGuid = "com.dev.survivallog.exiledtoolkit";

    public override void Load()
    {
        var dayLength = Config.Bind("Day", "DayLength", DayScale.DefaultDayLength, new ConfigDescription(
            $"How many times longer each in-game day lasts in real time. 1 is the normal day length and changes nothing. 2 makes a day take twice as long. Hunger and other needs, plant growth, disaster countdowns and action times stretch with the day. To keep actions as fast as before, raise the action speeds in the Action Speed mod by the same amount. From {DayScale.MinDayLength} to {DayScale.MaxDayLength}. Takes effect the next time you load a save.\n" +
            $"每个游戏日在现实中持续的倍数。1 为正常的一天长度，不做任何改变。2 表示一天的现实时间变为原来的两倍。饥饿等需求、植物生长、灾难倒计时和动作时间都会随一天变长。如需保持原来的动作速度，请在 Action Speed 模组中把动作速度提高相同的倍数。范围 {DayScale.MinDayLength} 到 {DayScale.MaxDayLength}。下次读取存档时生效。",
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

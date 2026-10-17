using System;
using DayLength.Core;
using GameCore.HotUpdate;
using GameCore.HotUpdate.Battle.Logic;
using HarmonyLib;

namespace DayLength.Adapters;

/// <summary>
/// The chapter sets Toolset.TimeScale before the logic world starts, and the clock, the disaster countdown and
/// every timer read it while the world starts and loads the save. Scaling it at the top of
/// BattleLogicWorld.Initialize lands after the chapter and before any of them.
/// </summary>
internal static class WorldStartPatch
{
    private static readonly ScaleTracker Tracker = new();
    private static double _dayLength = 1;
    private static Action<string> _log = _ => { };

    public static void Apply(Harmony harmony, double dayLength, Action<string> log)
    {
        _dayLength = dayLength;
        _log = log;

        try
        {
            harmony.Patch(
                AccessTools.Method(typeof(BattleLogicWorld), nameof(BattleLogicWorld.Initialize)),
                prefix: new HarmonyMethod(typeof(WorldStartPatch), nameof(BeforeWorldStart)));
            log($"hooked the world start, days will be {dayLength}x as long");
        }
        catch (Exception ex)
        {
            log($"could not hook BattleLogicWorld.Initialize, days keep their normal length: {ex.Message}");
        }
    }

    private static void BeforeWorldStart()
    {
        try
        {
            var current = Toolset.TimeScale;
            var scaled = Tracker.Next(current, _dayLength);

            if (scaled is not int value) return;

            Toolset.TimeScale = value;
            _log($"time scale {current} -> {value}, days are {DayScale.ActualDayLength(current, value):0.##}x as long");
        }
        catch (Exception ex)
        {
            _log($"could not change the day length: {ex.Message}");
        }
    }
}

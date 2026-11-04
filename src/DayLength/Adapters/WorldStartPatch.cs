using System;
using DayLength.Core;
using GameCore.HotUpdate;
using GameCore.HotUpdate.Battle.Logic;
using HarmonyLib;

namespace DayLength.Adapters;

/// <summary>
/// The chapter sets Toolset.TimeScale before the logic world starts, and the clock, the disaster countdown and
/// every timer read it while the world starts and loads the save. BattleLogicWorld.Initialize calls
/// ChallengeSetupContext.TryConsume first, before any manager starts, so scaling after it lands after the chapter and
/// before any of them. Running last there lets a mod that starts the world's own settings in the same place
/// (Customizable Difficulty) set this world's day length first.
/// </summary>
internal static class WorldStartPatch
{
    private static readonly ScaleTracker Tracker = new();
    private static double _dayLength = 1;
    private static Action<string> _log = _ => { };
    private static Func<double>? _current;

    /// <summary>
    /// <paramref name="current"/> reads the setting as the world starts, for a value set in the same frame (a world's
    /// own value is set then, and a watched change reaches <see cref="UseDayLength"/> only at the next frame).
    /// </summary>
    public static void Apply(Harmony harmony, Action<string> log, Func<double>? current)
    {
        _log = log;
        _current = current;

        try
        {
            var target = AccessTools.Method(typeof(ChallengeSetupContext), nameof(ChallengeSetupContext.TryConsume));

            if (target == null) throw new MissingMethodException("ChallengeSetupContext.TryConsume not found");

            harmony.Patch(target, postfix: new HarmonyMethod(typeof(WorldStartPatch), nameof(BeforeWorldStart)) { priority = Priority.Last });
            log("hooked the world start");
        }
        catch (Exception ex)
        {
            log($"could not hook ChallengeSetupContext.TryConsume, days keep their normal length: {ex.Message}");
        }
    }

    /// <summary>Used from the next time a save loads.</summary>
    public static void UseDayLength(double dayLength)
    {
        _dayLength = dayLength;
        _log($"days will be {dayLength}x as long from the next save load");
    }

    private static void BeforeWorldStart()
    {
        try
        {
            var current = Toolset.TimeScale;
            var scaled = Tracker.Next(current, _current?.Invoke() ?? _dayLength);

            if (scaled is not int value) return;

            Toolset.TimeScale = value;
            _log($"time scale {current} -> {value}, days are {DayScale.ActualDayLength(Tracker.ChapterScale, value):0.##}x as long");
        }
        catch (Exception ex)
        {
            _log($"could not change the day length: {ex.Message}");
        }
    }
}

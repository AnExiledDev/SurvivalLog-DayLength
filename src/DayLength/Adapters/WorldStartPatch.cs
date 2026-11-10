using System;
using DayLength.Core;
using ExiledToolkit.Game;
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
    private static Action<string> _log = _ => { };
    private static Func<double> _current = () => 1;

    /// <summary>
    /// <paramref name="current"/> reads the setting as the world starts, for a value set in the same frame (a world's
    /// own value is set then, and a watched change reaches <see cref="LogDayLength"/> only at the next frame).
    /// </summary>
    public static void Apply(Harmony harmony, Action<string> log, Func<double> current)
    {
        _log = log;
        _current = current;

        new PatchKit(harmony, log).Patch(
            typeof(WorldStartPatch), typeof(ChallengeSetupContext), nameof(ChallengeSetupContext.TryConsume), null, Priority.Last,
            postfix: nameof(BeforeWorldStart), done: "hooked the world start", consequence: "days keep their normal length");
    }

    /// <summary>Logs the setting when it changes. The world reads it as it starts, so it is used from the next save load.</summary>
    public static void LogDayLength(double dayLength) => _log($"days will be {dayLength}x as long from the next save load");

    private static void BeforeWorldStart()
    {
        try
        {
            var current = Toolset.TimeScale;
            var scaled = Tracker.Next(current, _current());

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

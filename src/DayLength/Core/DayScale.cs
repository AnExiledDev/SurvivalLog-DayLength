using System;

namespace DayLength.Core;

/// <summary>
/// The game converts between real and game seconds with one whole number per chapter
/// (game seconds per real second). Dividing it makes every game day last longer in real time.
/// </summary>
public static class DayScale
{
    public const double MinDayLength = 0.25;
    public const double MaxDayLength = 10;

    public static double ClampDayLength(double dayLength) =>
        double.IsNaN(dayLength) ? 1 : Math.Clamp(dayLength, MinDayLength, MaxDayLength);

    /// <summary>The game's number for a day <paramref name="dayLength"/> times as long. Never below 1, since 0 would stop the clock.</summary>
    public static int Scaled(int chapterScale, double dayLength)
    {
        if (chapterScale <= 0) return chapterScale;

        var scaled = (int)Math.Round(chapterScale / ClampDayLength(dayLength), MidpointRounding.AwayFromZero);

        return Math.Max(1, scaled);
    }

    /// <summary>How much longer a day really is after rounding to a whole number.</summary>
    public static double ActualDayLength(int chapterScale, int scaled) =>
        chapterScale <= 0 || scaled <= 0 ? 1 : (double)chapterScale / scaled;
}

/// <summary>
/// The chapter writes its number before the world starts. Seeing the value this mod last wrote means it was
/// already scaled, so the chapter's own number is the one kept from before, and a new day length is worked out from
/// that, never from the scaled value.
/// </summary>
public sealed class ScaleTracker
{
    private int? _lastWritten;

    /// <summary>The chapter's own number, as last seen before this mod changed it.</summary>
    public int ChapterScale { get; private set; }

    public int? Next(int current, double dayLength)
    {
        if (current != _lastWritten) ChapterScale = current;

        var scaled = DayScale.Scaled(ChapterScale, dayLength);

        _lastWritten = scaled;

        return scaled == current ? null : scaled;
    }
}

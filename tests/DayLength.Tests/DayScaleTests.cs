using DayLength.Core;
using Xunit;

namespace DayLength.Tests;

public class DayScaleTests
{
    [Fact]
    public void The_default_day_length_leaves_the_game_clock_alone()
    {
        // Installing the mod must change no balance until the player picks a day length.
        Assert.Null(DayScale.Change(48, DayScale.DefaultDayLength));
    }

    [Fact]
    public void Twice_as_long_days_halve_the_game_seconds_per_real_second()
    {
        Assert.Equal(24, DayScale.Scaled(48, 2));
    }

    [Fact]
    public void Shorter_days_raise_the_number()
    {
        Assert.Equal(96, DayScale.Scaled(48, 0.5));
    }

    [Fact]
    public void An_uneven_split_rounds_to_the_nearest_whole_number()
    {
        Assert.Equal(17, DayScale.Scaled(50, 3));
        Assert.Equal(50.0 / 17, DayScale.ActualDayLength(50, 17), 6);
    }

    [Fact]
    public void The_clock_never_stops_even_when_the_number_is_already_tiny()
    {
        Assert.Equal(1, DayScale.Scaled(1, 2));
        Assert.Equal(1, DayScale.Scaled(3, 10));
    }

    [Fact]
    public void Out_of_range_settings_are_held_to_the_limits()
    {
        Assert.Equal(DayScale.Scaled(100, DayScale.MaxDayLength), DayScale.Scaled(100, 1000));
        Assert.Equal(DayScale.Scaled(100, DayScale.MinDayLength), DayScale.Scaled(100, 0));
        Assert.Equal(100, DayScale.Scaled(100, double.NaN));
    }

    [Fact]
    public void A_number_the_game_never_set_is_left_alone()
    {
        Assert.Equal(0, DayScale.Scaled(0, 2));
    }

    [Fact]
    public void A_chapter_number_is_scaled()
    {
        Assert.Equal(24, DayScale.Change(48, 2));
    }

    [Fact]
    public void A_chapter_number_equal_to_one_written_before_is_still_scaled()
    {
        // Chapter 0 (120) at half length becomes 240, and chapter 2's own number is 240. Each load sets the chapter's
        // number first, so the second load must be scaled too.
        Assert.Equal(240, DayScale.Change(120, 0.5));
        Assert.Equal(480, DayScale.Change(240, 0.5));
    }

    [Fact]
    public void Normal_day_length_writes_nothing()
    {
        Assert.Null(DayScale.Change(48, 1));
    }
}

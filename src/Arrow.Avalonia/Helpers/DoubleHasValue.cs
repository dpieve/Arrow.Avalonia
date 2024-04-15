namespace Arrow.Avalonia.Helpers;

internal static class Extensions
{
    public static bool HasValue(this double value)
    {
        if (double.IsNaN(value) || double.IsInfinity(value) || double.IsNegativeInfinity(value))
        {
            return false;
        }
        return true;
    }

    public static bool HasValue(this double? value)
    {
        if (value is null)
        {
            return false;
        }

        return HasValue(value.Value);
    }
}

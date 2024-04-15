using Avalonia;

namespace Arrow.Avalonia.Helpers;

internal static class GetDistanceBetweenPoints
{
    public static double Execute(Point start, Point end)
    {
        var dist2 = Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2);
        return Math.Sqrt(dist2);
    }
}

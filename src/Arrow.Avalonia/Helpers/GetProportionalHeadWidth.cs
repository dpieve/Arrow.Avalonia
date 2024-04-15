using Avalonia;

namespace Arrow.Avalonia.Helpers;

internal static class GetProportionalHeadWidth
{
    public static double Execute(Point start, Point end, double proportionFactor = 0.2)
    {
        var dist = GetDistanceBetweenPoints.Execute(start, end);
        return dist * proportionFactor;
    }
}
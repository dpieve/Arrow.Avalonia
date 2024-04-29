using Avalonia;

namespace Arrow.Avalonia.Helpers;

internal static class GetProportionalHeadLength
{
    public static double Execute(Point start, Point end, double proportionFactor = 0.27)
    {
        var dist = GetDistanceBetweenPoints.Execute(start, end);
        return dist * proportionFactor;
    }
}
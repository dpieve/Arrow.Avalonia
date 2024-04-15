using Avalonia;

namespace Arrow.Avalonia.Helpers;

/// <summary>
/// Gets the points that define a triangle to form the head of an arrow shape.
/// </summary>
public static class GetHeadPoints
{
    public record Request(Arrow Arrow);
    public record class Response(HeadPoints? HeadPoints);
    /// <summary>
    /// Calculates the points that define the head of an arrow.
    /// </summary>
    public static Response Execute(Request request)
    {
        var arrow = request.Arrow;

        var startPoint = arrow.StartPoint;
        var endPoint = arrow.EndPoint;

        var deltaY = endPoint.Y - startPoint.Y;
        var deltaX = endPoint.X - startPoint.X;

        var slope = CalculateSlope(deltaY, deltaX);

        var angle = Math.Atan(slope); 
        var direction = GetDirection(deltaX);
        var headMiddleBottomPoint = CalculatePoint(endPoint, direction, arrow.HeadLength, angle);

        var perpendicularSlope = CalculatePerpendicularSlope(slope);
        var perpendicularAngle = Math.Atan(perpendicularSlope);
       
        var leftPoint = CalculatePoint(headMiddleBottomPoint, arrow.HeadWidth, perpendicularAngle);
        var rightPoint = CalculatePoint(headMiddleBottomPoint, -arrow.HeadWidth, perpendicularAngle);

        var isUndefined = !leftPoint.X.HasValue() || !leftPoint.Y.HasValue() ||
            !rightPoint.X.HasValue() || !rightPoint.Y.HasValue();
        
        if (isUndefined)
        {
            if (startPoint == endPoint)
            {
                return new(new HeadPoints(startPoint, startPoint, startPoint, startPoint));
            }
            return new Response(null);
        }

        var headPoints = deltaY >= 0 ?
            new HeadPoints(rightPoint, leftPoint, endPoint, headMiddleBottomPoint) :
            new HeadPoints(leftPoint, rightPoint, endPoint, headMiddleBottomPoint);

        return new Response(headPoints);
    }

    /// <summary>
    /// Direction X-axis is going
    /// </summary>
    public static int GetDirection(double deltaX)
    {
        return deltaX >= 0 ? -1 : 1;
    }

    /// <summary>
    /// Slope of a line.
    /// </summary>
    /// <param name="deltaY">y2 - y1</param>
    /// <param name="deltaX">x2 - x1</param>
    /// <returns> m = (y2 - y1) / (x2 - x1)</returns>
    public static double CalculateSlope(double deltaY, double deltaX)
    {
        return deltaY / deltaX;
    }

    /// <summary>
    /// Calculates the perperdicular slope of a given slope.
    /// </summary>
    /// <param name="slope">slope = y2 - y1 / x2 - x1 </param>
    /// <returns>Perpendicular slope</returns>
    public static double CalculatePerpendicularSlope(double slope)
    {
        return -1 / slope;
    }

    /// <summary>
    /// Calculates the point that is len away from a reference point, following the direction and angle.
    /// </summary>
    public static Point CalculatePoint(Point point, int direction, double len, double angle)
    {
        var pointAway = new Point(point.X + direction * len * Math.Cos(angle), point.Y + direction * len * Math.Sin(angle));
        var isVerticalLine = !pointAway.X.HasValue() || !pointAway.Y.HasValue();
        if (isVerticalLine)
        {
            pointAway = new Point(point.X, point.Y + direction * len);
        }
        return pointAway;
    }

    /// <summary>
    /// Calculates the point that is distance away from the reference point, following an angle.
    /// </summary>
    public static Point CalculatePoint(Point point, double distance, double angle)
    {
        return new Point(point.X - distance * Math.Cos(angle), point.Y - distance * Math.Sin(angle));
    }

    public record HeadPoints(Point Left,
        Point Right,
        Point Top,
        Point Bottom);
    public record Arrow(Point StartPoint,
        Point EndPoint,
        double HeadLength,
        double HeadWidth);
}

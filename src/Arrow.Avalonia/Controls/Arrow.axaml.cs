using Arrow.Avalonia.Helpers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using static Arrow.Avalonia.Helpers.GetHeadPoints;

namespace Arrow.Avalonia.Controls;

public partial class Arrow : UserControl
{
    private Point _endPoint = new(30, 30);

    public Arrow()
    {
        InitializeComponent();
    }

    static Arrow()
    {
        StartPointProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            var value = e.NewValue as Point?;
            if (value is not null)
            {
                s.ArrowLine.StartPoint = value.Value;
                UpdateArrow(s);
            }
        });

        EndPointProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            var value = e.NewValue as Point?;
            if (value is not null)
            {
                s._endPoint = value.Value;
                s.ArrowLine.EndPoint = value.Value;
                UpdateArrow(s);
            }
        });

        IsVisibleProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            var value = e.NewValue as bool?;
            if (value is not null)
            {
                s.ArrowLine.IsVisible = value.Value;
                s.ArrowLineHeadLeft.IsVisible = value.Value;
                s.ArrowLineHeadRight.IsVisible = value.Value;
            }
        });

        HeadLengthProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            var value = e.NewValue as double?;
            if (value is not null)
            {
                UpdateArrow(s);
            }
        });

        HeadWidthProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            var value = e.NewValue as double?;
            if (value is not null)
            {
                UpdateArrow(s);
            }
        });

        ColorProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            if (e.NewValue is null)
            {
                return;
            }

            var value = e.NewValue as Color?;
            if (value is null)
            {
                return;
            }

            var brush = new SolidColorBrush(value.Value);
            s.ArrowLine.Stroke = brush;
            s.ArrowLineHeadLeft.Stroke = brush;
            s.ArrowLineHeadRight.Stroke = brush;
            s.TrianglePath.Fill = brush;
        });

        IsProportionalProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            var value = e.NewValue as bool?;
            if (value is not null)
            {
                UpdateArrow(s);
            }
        });

        IsFilledProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            var value = e.NewValue as bool?;
            if (value is not null)
            {
                UpdateArrow(s);
            }
        });

        ThicknessProperty.Changed.AddClassHandler<Arrow>((s, e) =>
        {
            var value = e.NewValue as double?;
            if (value is not null)
            {
                s.ArrowLine.StrokeThickness = value.Value;
                s.ArrowLineHeadLeft.StrokeThickness = value.Value;
                s.ArrowLineHeadRight.StrokeThickness = value.Value;
            }
        });
    }

    public static readonly StyledProperty<Point> StartPointProperty =
        AvaloniaProperty.Register<Arrow, Point>(nameof(StartPoint), defaultValue: new Point(0, 0));

    public static readonly StyledProperty<Point> EndPointProperty =
       AvaloniaProperty.Register<Arrow, Point>(nameof(EndPoint), defaultValue: new Point(30, 30));

    public static readonly StyledProperty<Color> ColorProperty =
      AvaloniaProperty.Register<Arrow, Color>(nameof(Color), Colors.Green);

    public new static readonly StyledProperty<bool> IsVisibleProperty =
        AvaloniaProperty.Register<Arrow, bool>(nameof(IsVisible), defaultValue: true);

    public static readonly StyledProperty<bool> IsProportionalProperty =
      AvaloniaProperty.Register<Arrow, bool>(nameof(IsProportional), false);

    public static readonly StyledProperty<bool> IsFilledProperty =
        AvaloniaProperty.Register<Arrow, bool>(nameof(IsFilled), false);

    public static readonly StyledProperty<double> HeadLengthProperty =
        AvaloniaProperty.Register<Arrow, double>(nameof(HeadLength), defaultValue: 10);

    public static readonly StyledProperty<double> HeadWidthProperty =
        AvaloniaProperty.Register<Arrow, double>(nameof(HeadWidth), defaultValue: 7);

    public static readonly StyledProperty<double> ThicknessProperty =
        AvaloniaProperty.Register<Arrow, double>(nameof(Thickness), 5.0);

    /// <summary>
    /// Start point of the arrow.
    /// </summary>
    public Point StartPoint
    {
        get => GetValue(StartPointProperty);
        set => SetValue(StartPointProperty, value);
    }

    /// <summary>
    /// End point of the arrow.
    /// </summary>
    public Point EndPoint
    {
        get => GetValue(EndPointProperty);
        set => SetValue(EndPointProperty, value);
    }

    /// <summary>
    /// Color of the arrow.
    /// </summary>
    public Color Color
    {
        get => GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    /// <summary>
    /// Visibility of the arrow.
    /// </summary>
    public new bool IsVisible
    {
        get => GetValue(IsVisibleProperty);
        set => SetValue(IsVisibleProperty, value);
    }

    /// <summary>
    /// If true, the arrow head will be proportional to the distance between the StartPoint and the EndPoint of the arrow.
    /// </summary>
    public bool IsProportional
    {
        get => GetValue(IsProportionalProperty);
        set => SetValue(IsProportionalProperty, value);
    }

    /// <summary>
    /// If true, the arrow head will be filled.
    /// </summary>
    public bool IsFilled
    {
        get => GetValue(IsFilledProperty);
        set => SetValue(IsFilledProperty, value);
    }

    /// <summary>
    /// The length of the arrow head.
    /// </summary>
    public double HeadLength
    {
        get => GetValue(HeadLengthProperty);
        set => SetValue(HeadLengthProperty, value);
    }

    /// <summary>
    /// The width of the arrow head.
    /// </summary>
    public double HeadWidth
    {
        get => GetValue(HeadWidthProperty);
        set => SetValue(HeadWidthProperty, value);
    }

    /// <summary>
    /// The thickness of the arrow.
    /// </summary>
    public double Thickness
    {
        get => GetValue(ThicknessProperty);
        set => SetValue(ThicknessProperty, value);
    }

    public static void UpdateArrow(Arrow s)
    {
        var start = s.StartPoint;
        var end = s._endPoint;
        var len = s.IsProportional || !s.HeadLength.HasValue() ? GetProportionalHeadLength.Execute(start, end) : s.HeadLength;
        var width = s.IsProportional || !s.HeadWidth.HasValue() ? GetProportionalHeadWidth.Execute(start, end) : s.HeadWidth;

        var headPoints = GetHeadPoints.Execute(new(new(start, end, len, width))).HeadPoints;
        if (headPoints is null)
        {
            return;
        }

        s.HeadLength = len;
        s.HeadWidth = width;

        s.ArrowLine.EndPoint = s.IsFilled ? headPoints.Bottom : headPoints.Top;

        s.ArrowLineHeadLeft.IsVisible = !s.IsFilled && s.IsVisible;
        s.ArrowLineHeadLeft.StartPoint = headPoints.Left;
        s.ArrowLineHeadLeft.EndPoint = headPoints.Top;

        s.ArrowLineHeadRight.IsVisible = !s.IsFilled && s.IsVisible;
        s.ArrowLineHeadRight.StartPoint = headPoints.Right;
        s.ArrowLineHeadRight.EndPoint = headPoints.Top;

        s.TrianglePath.IsVisible = s.IsFilled;

        if (s.IsFilled)
        {
            s.TrianglePath.Data = CreateFilledHead(headPoints);
        }
    }

    private static PathGeometry CreateFilledHead(HeadPoints headPoints)
    {
        return new PathGeometry
        {
            Figures =
            [
                new PathFigure
                {
                    IsClosed = true,
                    IsFilled = true,
                    StartPoint = headPoints.Top,
                    Segments =
                    [
                        new LineSegment() { Point = headPoints.Left },
                        new LineSegment() { Point = headPoints.Right },
                    ]
                }
            ]
        };
    }
}
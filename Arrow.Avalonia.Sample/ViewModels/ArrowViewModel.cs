using Avalonia;
using Avalonia.Media;
using ReactiveUI.Fody.Helpers;

namespace Arrow.Avalonia.Sample.ViewModels;

public sealed class ArrowViewModel : ViewModelBase
{
    public ArrowViewModel()
    {
    }

    [Reactive] public bool IsVisible { get; set; } = true;
    [Reactive] public bool IsHeadProportional { get; set; } = true;
    [Reactive] public bool IsHeadFilled { get; set; } = false;

    [Reactive] public Point Start { get; set; } = new Point(65, 335);
    [Reactive] public Point End { get; set; } = new Point(293, 65);
    [Reactive] public Color Color { get; set; } = Colors.Green;

    [Reactive] public double HeadLength { get; set; } = 93.0;
    [Reactive] public double HeadWidth { get; set; } = 68.0;
    [Reactive] public double Thickness { get; set; } = 18.0;
}
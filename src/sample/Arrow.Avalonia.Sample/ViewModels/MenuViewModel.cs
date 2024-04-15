using Avalonia.Media;
using ReactiveUI.Fody.Helpers;

namespace Arrow.Avalonia.Sample.ViewModels;

public sealed class MenuViewModel(ArrowViewModel arrow) : ViewModelBase
{
    [Reactive] public Color PlaygroundBackground { get; set; } = Colors.Gray;
    public ArrowViewModel Arrow { get; } = arrow;
}
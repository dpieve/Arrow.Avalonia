using Arrow.Avalonia.Sample.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.ReactiveUI;

namespace Arrow.Avalonia.Sample.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    private bool _isPressed;

    public MainView()
    {
        InitializeComponent();
    }

    private new void PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is null || ViewModel is null)
        {
            return;
        }

        _isPressed = true;

        var point = e.GetCurrentPoint(sender as Control).Position;
        ViewModel.Arrow.Start = new Point(point.X, point.Y);
        ViewModel.Arrow.End = new Point(point.X, point.Y);
    }

    private new void PointerMoved(object? sender, PointerEventArgs e)
    {
        if (sender is null || ViewModel is null || !_isPressed)
        {
            return;
        }

        var point = e.GetCurrentPoint(sender as Control).Position;
        ViewModel.Arrow.End = new Point(point.X, point.Y);
    }

    private new void PointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        if (sender is null || ViewModel is null || !_isPressed)
        {
            return;
        }

        _isPressed = false;

        var point = e.GetCurrentPoint(sender as Control).Position;
        ViewModel.Arrow.End = new Point(point.X, point.Y);
    }
}
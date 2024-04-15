namespace Arrow.Avalonia.Sample.ViewModels;

public sealed class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Arrow = new ArrowViewModel();
        Menu = new MenuViewModel(Arrow);
    }

    public ArrowViewModel Arrow { get; init; }
    public MenuViewModel Menu { get; init; }
}
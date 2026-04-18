using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] public ViewModelBase pageSwitcher = new LoginPageViewModel();

    public Employee? currentEmployee;
    
    public static MainWindowViewModel Instance { get; set; }
    
    public MainWindowViewModel()
    {
        Instance = this;
    }
}
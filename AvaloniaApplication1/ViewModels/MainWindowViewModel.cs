using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] public ViewModelBase pageSwitcher = new LoginPageViewModel();

    public Employee? currentEmployee;
    
    MainWindowViewModel Instance { get; set; }
    
    public MainWindowViewModel()
    {
        Instance = this;
    }
}
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.ViewModels;

public partial class UserPageViewModel : ViewModelBase
{
    [ObservableProperty] Employee employee;

    public UserPageViewModel()
    {
        employee = MainWindowViewModel.Instance.currentEmployee;
    }

    public void GoBack()
    {
        MainWindowViewModel.Instance.PageSwitcher = new LoginPageViewModel();
    }
}
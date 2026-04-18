using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.ViewModels;

public partial class LoginPageViewModel : ViewModelBase
{
    [ObservableProperty] string login;
    [ObservableProperty] string password;
    [ObservableProperty] string message;

    

    public void LoginEnter()
    {
        MainWindowViewModel.Instance.currentEmployee = db.Employees
            .Include(x => x.EmployeeMetrics)
            .ThenInclude(x => x.Metric)
            .Include(x => x.Position)
            .Include(x => x.Role)
            .Where(x => x.Login == Login && x.Password == Password)
            .FirstOrDefault();
        if (MainWindowViewModel.Instance.currentEmployee != null)
        {
            Message = "success";
            if (MainWindowViewModel.Instance.currentEmployee.Role.Name == "Администратор")
            {
                MainWindowViewModel.Instance.PageSwitcher = new AdminPageViewModel();
            }
            else
            {
                MainWindowViewModel.Instance.PageSwitcher = new UserPageViewModel();
            }
        }
        else
        {
            Message = "error";
        }
    }
}
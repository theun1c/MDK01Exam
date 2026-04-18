using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.ViewModels;

public partial class AdminPageViewModel : ViewModelBase
{
    [ObservableProperty] List<Employee> employees = db.Employees
        .Include(x => x.EmployeeMetrics)
        .ThenInclude(x => x.Metric)
        .Include(x => x.Position)
        .Include(x => x.Role)
        .ToList();

    public void EditUser(Employee employee)
    {
        MainWindowViewModel.Instance.PageSwitcher = new EditUserPageViewModel(employee);
    }

    public void GoBack()
    {
        MainWindowViewModel.Instance.PageSwitcher = new LoginPageViewModel();
    }
    
    public void CreateUser()
    {
        MainWindowViewModel.Instance.PageSwitcher = new CreateUserViewModel();
    }
}
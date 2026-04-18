using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.ViewModels;

public partial class AdminPageViewModel : ViewModelBase
{
    [ObservableProperty] List<Employee> employees = new();

    private List<Employee> allEmployees = new();

    public AdminPageViewModel()
    {
        allEmployees = db.Employees
            .Include(x => x.EmployeeMetrics)
            .ThenInclude(x => x.Metric)
            .Include(x => x.Position)
            .Include(x => x.Role)
            .ToList();
        Employees =  allEmployees;
    }
    
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

    [ObservableProperty] private string search;

    partial void OnSearchChanged(string value)
    {
        Employees = allEmployees
            .Where(x => 
                (x.FirstName.Contains(value)) || 
                (x.LastName.Contains(value)) ||
                (x.MiddleName.Contains(value))).ToList();
    }
    
    public void SortDest()
    {
        Employees = db.Employees
            .Include(x => x.Role)
            .Include(x => x.Position)
            .Include(x => x.EmployeeMetrics)
            .ThenInclude(x => x.Metric)
            .OrderByDescending(x => x.EmployeeMetrics
                .Select(m => (decimal?)m.Metric.Weight)
                .Sum() ?? 0)
            .ToList();
    }

    public void SortAsc()
    {
        Employees = db.Employees
            .Include(x => x.Role)
            .Include(x => x.Position)
            .Include(x => x.EmployeeMetrics)
            .ThenInclude(x => x.Metric)
            .OrderBy(x => x.EmployeeMetrics
                .Select(m => (decimal?)m.Metric.Weight)
                .Sum() ?? 0)
            .ToList();
    }
}
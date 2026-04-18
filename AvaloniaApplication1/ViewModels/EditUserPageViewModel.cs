using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class EditUserPageViewModel : ViewModelBase
{
    [ObservableProperty] Employee employee;
    [ObservableProperty] string message;
    
    [ObservableProperty] List<Role> roles = db.Roles.ToList();
    [ObservableProperty] Role selectedRole;
    
    [ObservableProperty] List<Position> positions  = db.Positions.ToList();
    [ObservableProperty] Position selectedPosition;
    
    public EditUserPageViewModel(Employee employee)
    {
        Employee = employee;
    }

    public void GoBack()
    {
        MainWindowViewModel.Instance.PageSwitcher = new AdminPageViewModel();
    }
    
    public void SaveUser()
    {
        Employee.RoleId =  SelectedRole.Id;
        Employee.PositionId = SelectedPosition.Id;
        db.SaveChanges();
        Message =  "saved";
    }
    
    public void DeleteUser()
    {
        var metrics = db.EmployeeMetrics.Where(x => x.EmployeeId == Employee.Id).ToList();
        db.EmployeeMetrics.RemoveRange(metrics);
        db.Employees.Remove(Employee);
        db.SaveChanges();
        Message = "deleted";
        MainWindowViewModel.Instance.PageSwitcher = new AdminPageViewModel();
    }
}
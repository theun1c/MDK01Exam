using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class CreateUserViewModel : ViewModelBase
{
    [ObservableProperty] Employee employee = new Employee();
    [ObservableProperty] string message;
    
    [ObservableProperty] List<Role> roles = db.Roles.ToList();
    [ObservableProperty] Role selectedRole;
    
    [ObservableProperty] List<Position> positions  = db.Positions.ToList();
    [ObservableProperty] Position selectedPosition;
    
    public void GoBack()
    {
        MainWindowViewModel.Instance.PageSwitcher = new AdminPageViewModel();
    }
    
    public void SaveUser()
    {
        Employee.RoleId =  SelectedRole.Id;
        Employee.PositionId = SelectedPosition.Id;
        db.Employees.Add(Employee);
        db.SaveChanges();
        Message =  "saved";
    }
}
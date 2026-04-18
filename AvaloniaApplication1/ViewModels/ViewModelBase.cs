using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public abstract class ViewModelBase : ObservableObject
{
    public static PostgresContext db = new PostgresContext();
}
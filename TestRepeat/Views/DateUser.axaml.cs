using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestRepeat.Models;
using TestRepeat.ViewModels;

namespace TestRepeat.Views;

public partial class DateUser : UserControl
{
    public DateUser()
    {
        InitializeComponent();
    }
    public DateUser(User user)
    {
        InitializeComponent();
        DataContext = new DateUserViewModel(user);
    }
    public DateUser(User cuurentUser,User changeableUser)
    {
        InitializeComponent();
        DataContext = new DateUserViewModel(cuurentUser, changeableUser);
    }
}
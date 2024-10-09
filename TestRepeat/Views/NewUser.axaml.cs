using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestRepeat.Models;
using TestRepeat.ViewModels;

namespace TestRepeat.Views;

public partial class NewUser : UserControl
{
    public NewUser()
    {
        InitializeComponent();
        DataContext = new NewUserViewModel();
    }
    
}
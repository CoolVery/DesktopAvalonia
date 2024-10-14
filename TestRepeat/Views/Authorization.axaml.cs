using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestRepeat.ViewModels;
using TestRepeat.ViewModels.AuthorizationViewModel;

namespace TestRepeat.Views;

public partial class Authorization : UserControl
{
    public Authorization()
    {
        InitializeComponent();
        DataContext = new AuthorizationViewModel();
    }
}
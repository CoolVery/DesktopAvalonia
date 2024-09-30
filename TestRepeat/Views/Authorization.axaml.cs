using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestRepeat.ViewModels;

namespace TestRepeat.Views;

public partial class Authorization : UserControl
{
    public Authorization()
    {
        InitializeComponent();
        DataContext = new AuthorizationViewModel();
    }
}
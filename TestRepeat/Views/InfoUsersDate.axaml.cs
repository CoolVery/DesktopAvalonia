using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using TestRepeat.Models;
using TestRepeat.ViewModels;

namespace TestRepeat.Views;

public partial class InfoUsersDate : UserControl
{
    public InfoUsersDate(List<User> listUsers)
    {
        InitializeComponent();
        DataContext = new InfoUsersDateViewModel(listUsers);
    }
}
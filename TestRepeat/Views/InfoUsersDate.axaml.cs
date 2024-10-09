using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using TestRepeat.Models;
using TestRepeat.ViewModels;

namespace TestRepeat.Views;

public partial class InfoUsersDate : UserControl
{
    public static User CurrentUser { get; set; }
    public InfoUsersDate()
    {
        InitializeComponent();
    }
    public InfoUsersDate( List<User> listUsers)
    {
        InitializeComponent();
        DataContext = new InfoUsersDateViewModel(listUsers);
    }
    public InfoUsersDate(User currentUser, List<User> listUsers)
    {
        InitializeComponent();
        CurrentUser = currentUser;
        DataContext = new InfoUsersDateViewModel(listUsers);
    }
}
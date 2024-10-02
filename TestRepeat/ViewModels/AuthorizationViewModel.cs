using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestRepeat.Models;
using TestRepeat.Views;

namespace TestRepeat.ViewModels
{
	public partial class AuthorizationViewModel : ViewModelBase
	{
		[ObservableProperty] string login;
        [ObservableProperty] string password;
        [ObservableProperty] bool wrongSignIn;

		public void SignIn() {
            Logined user = MainWindowViewModel.Db_context.Logineds.Include(x=>x.User.IdGenderNavigation).FirstOrDefault(user=>user.Login == Login && user.Password == Password);
            if (user != null) {
                switch (user.IdRole) {
                    case 1:
                        MainWindowViewModel.Instance.Uc = new DateUser(user);
                        break;
                    case 2:
                        MainWindowViewModel.Instance.Uc = new InfoUsersDate(MainWindowViewModel.Db_context.Users.Include(x => x.IdGenderNavigation).ToList());
                        break;
                }
            }
            else
            {
                WrongSignIn = true;
            }

        }

    }
}
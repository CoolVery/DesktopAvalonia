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
            _41pKyklevContext _41PKyklevContext = new _41pKyklevContext();
            Logined user = _41PKyklevContext.Logineds.Include(x=>x.User.IdGenderNavigation).FirstOrDefault(user=>user.Login == Login && user.Password == Password);
            if (user != null) {
                switch (user.IdRole) {
                    case 1:
                        break;
                    case 2:
                        MainWindowViewModel.Instance.Uc = new InfoUsersDate(_41PKyklevContext.Users.Include(x => x.IdUserNavigation.IdRoleNavigation).ToList<User>());

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
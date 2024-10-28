using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using TestRepeat.Models;
using TestRepeat.Views;

namespace TestRepeat.ViewModels.AuthorizationViewModel
{
	public partial class AuthorizationViewModel : ViewModelBase
	{
		[ObservableProperty] string login;
        [ObservableProperty] string password;
        [ObservableProperty] bool wrongSignIn;
        public AuthorizationViewModel() { }
        public AuthorizationViewModel(string login, string password) { 
            this.login = login;
            this.password = password;
            SignIn();
        }
        public void SignInAndWriteFile() {
            if (SignIn())
            {
                AuthorizationVMAdditionalMethods.CreateAndWriteWork(login, password);

            }
        }
        public bool SignIn() {            
            Logined user = MainWindowViewModel.Db_context.Logineds.Include(x=>x.User.IdGenderNavigation).FirstOrDefault(user=>user.Login == Login && user.Password == MD5.HashData(Encoding.ASCII.GetBytes(Password)));
            if (user != null) {
                switch (user.IdRole) {
                    case 1:
                        MainWindowViewModel.Instance.Uc = new DateUser(user.User);
                        break;
                    case 2:
                        MainWindowViewModel.Instance.Uc = new InfoUsersDate(user.User, MainWindowViewModel.Db_context.Users
                            .Include(x => x.IdGenderNavigation)
                            .Include(x => x.IdUserNavigation.IdRoleNavigation)
                            .ToList());
                        break;
                }
                return true;
            }
            else
            {
                WrongSignIn = true;
                return false;
            }

        }

    }
}
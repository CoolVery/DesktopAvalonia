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
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestRepeat.Models;
using TestRepeat.ViewModels.ApiRequest;
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
        public async void SignInAndWriteFile() {
            if (await SignIn())
            {
                AuthorizationVMAdditionalMethods.CreateAndWriteWork(login, password);
                
            }
        }
        public async Task<bool> SignIn() {
            Logined user;
            user = await AuthRequest.AuthInSystem(Login, Password);
            if (user != null) {
                switch (user.IdRole) {
                    case 1:
                        MainWindowViewModel.Instance.Uc = new DateUser(user.User);
                        break;
                    case 2:
                        User userFromAPI;
                        List<User> userList;
                        userFromAPI = await UserRequest.GetUser(user.Id);
                        userList = await UserRequest.GetAllUser();
                        MainWindowViewModel.Instance.Uc = new InfoUsersDate(userFromAPI, userList);
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
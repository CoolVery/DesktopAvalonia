using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using TestRepeat.Models;
using TestRepeat.Views;

namespace TestRepeat.ViewModels
{
	public partial class NewUserViewModel : ViewModelBase
	{
		[ObservableProperty] User newUser = new User();
        [ObservableProperty] Logined newLogin = new Logined();
		[ObservableProperty] List<Gender> listGender;
        [ObservableProperty] List<Role> listRole;
        [ObservableProperty] bool isUserCreated = false;
        DateTimeOffset birthDateNewUser = DateTimeOffset.MinValue;
        public DateTimeOffset BirthDateNewUser
        {
            get => birthDateNewUser;
            set
            {
                NewUser.BirthDate = new DateTime(value.Year, value.Month, value.Day);
            }
        }
        public NewUserViewModel()
		{
			listGender = MainWindowViewModel.Db_context.Genders.ToList();
            listRole = MainWindowViewModel.Db_context.Roles.ToList();
        }
        
        public void CreateNewUserAndLogin()
		{
            MainWindowViewModel.Db_context.Logineds.Add(NewLogin);
            MainWindowViewModel.Db_context.SaveChanges();
            NewUser.IdUser = MainWindowViewModel.Db_context.Logineds.FirstOrDefault(log => log.Login == NewLogin.Login && log.Password == NewLogin.Password).Id;
            MainWindowViewModel.Db_context.Users.Add(NewUser);
            MainWindowViewModel.Db_context.SaveChanges();
            IsUserCreated = true;
        }
        public void BackToListUser()
        {
            MainWindowViewModel.Instance.Uc = new InfoUsersDate(MainWindowViewModel.Db_context.Users.ToList());
        }
        public void BackToAuth()
        {
            MainWindowViewModel.Instance.Uc = new Authorization();
        }
    }

}
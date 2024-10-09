using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using TestRepeat.Models;
using TestRepeat.Views;

namespace TestRepeat.ViewModels
{
	public partial class DateUserViewModel : ViewModelBase
	{
		[ObservableProperty] User userForPage;
        [ObservableProperty] string dateString;
		[ObservableProperty] List<Gender> genders;
		[ObservableProperty] bool isAdmin = false;
        User currentUser;
        public DateUserViewModel() { }
		public DateUserViewModel(User user) {
            userForPage = user;
			genders = MainWindowViewModel.Db_context.Genders.ToList();
			dateString = userForPage.BirthDate.ToString();
			if (user.IdUserNavigation.IdRole == 2)
			{
				isAdmin = true;
			}
        }
        public DateUserViewModel(User cuurentUser, User changeableUser) {
            currentUser = cuurentUser;
            userForPage = changeableUser;
            genders = MainWindowViewModel.Db_context.Genders.ToList();
            dateString = userForPage.BirthDate.ToString();
            if (cuurentUser.IdUserNavigation.IdRole == 2)
            {
                isAdmin = true;
            }
        }
        public void SaveChange()
		{
			MainWindowViewModel.Db_context.SaveChanges();
		}
		public DateTimeOffset NewDate { 
			get => new DateTimeOffset((DateTime)UserForPage.BirthDate, TimeSpan.Zero);
			set
			{
                UserForPage.BirthDate = new DateTime(value.Year, value.Month, value.Day);
                DateString = value.ToString();
            }
		}
		public void BackToAuth()
		{
			MainWindowViewModel.Instance.Uc = new Authorization();
		}
		public void BackToListUser()
		{
			MainWindowViewModel.Instance.Uc = new InfoUsersDate(currentUser, MainWindowViewModel.Db_context.Users.ToList());
		}
		
    }
}
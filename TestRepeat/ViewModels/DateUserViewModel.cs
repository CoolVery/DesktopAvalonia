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
		[ObservableProperty] Logined currentUser;
		[ObservableProperty] string dateString;
		[ObservableProperty] List<Gender> genders;
		public DateUserViewModel() { }
		public DateUserViewModel(Logined user) {
			currentUser = user;
			genders = MainWindowViewModel.Db_context.Genders.ToList();
			dateString = currentUser.User.BirthDate.ToString();

        }

		public void SaveChange()
		{
			MainWindowViewModel.Db_context.SaveChanges();
		}
		public DateTimeOffset NewDate { 
			get => new DateTimeOffset((DateTime)CurrentUser.User.BirthDate, TimeSpan.Zero);
			set
			{
				CurrentUser.User.BirthDate = new DateTime(value.Year, value.Month, value.Day);
                DateString = value.ToString();
            }
		}
		public void BackToAuth()
		{
			MainWindowViewModel.Instance.Uc = new Authorization();
		}
    }
}
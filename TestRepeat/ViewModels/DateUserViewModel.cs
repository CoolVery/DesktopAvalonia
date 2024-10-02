using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using TestRepeat.Models;

namespace TestRepeat.ViewModels
{
	public partial class DateUserViewModel : ViewModelBase
	{
		[ObservableProperty] Logined currentUser;
		[ObservableProperty] List<Gender> genders;
		public DateUserViewModel() { }
		public DateUserViewModel(Logined user) {
			currentUser = user;
			genders = MainWindowViewModel.Db_context.Genders.ToList();
		}

		public void SaveChange()
		{
			MainWindowViewModel.Db_context.SaveChanges();
		}
    }
}
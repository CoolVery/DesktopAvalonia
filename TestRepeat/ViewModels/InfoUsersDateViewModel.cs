using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using TestRepeat.Models;

namespace TestRepeat.ViewModels
{
	public partial class InfoUsersDateViewModel : ViewModelBase
	{
		[ObservableProperty] List<User> listUsers;
		public InfoUsersDateViewModel() { }

        public InfoUsersDateViewModel(List<User> users)
		{
			this.listUsers = users;
		}
	}
}
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using TestRepeat.Models;

namespace TestRepeat.ViewModels
{
	public partial class InfoUsersDateViewModel : ViewModelBase
	{
		[ObservableProperty] List<User> listUsers;
		[ObservableProperty] List<Gender> listGenders;
		[ObservableProperty] string textFolderContent;
		[ObservableProperty] Gender selectedGender;
		List<User> copyUsers;
		public InfoUsersDateViewModel() { }

		public InfoUsersDateViewModel(List<User> users)
		{
			this.listUsers = users;
			copyUsers = users;
			listGenders = [
				new Gender() { Gender1 = "—бросить фильтр", IdGender = 0 },
				.. users.Select(gender => gender.IdGenderNavigation).Distinct().OrderBy(gender => gender.IdGender).ToList()
				];
		}
		public void DateSort(int idParam)
		{
			switch (idParam)
			{
				case 1:
					ListUsers = ListUsers.OrderByDescending(x => x.BirthDate).ToList();
					break;
				case 2:
					ListUsers = ListUsers.OrderBy(x => x.BirthDate).ToList();
					break;
			}
		}

		partial void OnSelectedGenderChanged(Gender value) => Filters();
        partial void OnTextFolderContentChanged(string value) => Filters();
        void Filters()
		{
			ListUsers = copyUsers;
            if (!string.IsNullOrEmpty(textFolderContent)) ListUsers = ListUsers.Where(user => user.Name.Contains(textFolderContent)).ToList();
			if(selectedGender != null && selectedGender.IdGender != 0) ListUsers = ListUsers.Where(user => user.IdGenderNavigation == selectedGender).ToList();
		}
	}
}
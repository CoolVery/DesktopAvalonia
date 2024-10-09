using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using TestRepeat.Models;
using TestRepeat.Views;

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
        public InfoUsersDateViewModel(List<User> users) {
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
		public void ChangeUserDate(int idUser)
		{
			User changeableUser = MainWindowViewModel.Db_context.Users.FirstOrDefault(user => user.IdUser == idUser);
            MainWindowViewModel.Instance.Uc = new DateUser(InfoUsersDate.CurrentUser, changeableUser);
        }
		public void DeleteUser(int idUser) {
			MainWindowViewModel.Db_context
				.Remove(
					MainWindowViewModel.Db_context.Users.FirstOrDefault(u => u.IdUser == idUser));
			MainWindowViewModel.Db_context
				.Remove(
					MainWindowViewModel.Db_context.Logineds.FirstOrDefault(l => l.Id == idUser));
            MainWindowViewModel.Db_context.SaveChanges();
			MainWindowViewModel.Instance.Uc = new InfoUsersDate(MainWindowViewModel.Db_context.Users.ToList());
		}
		public void AddNewUser()
		{
			MainWindowViewModel.Instance.Uc = new NewUser();
		}

    }
}
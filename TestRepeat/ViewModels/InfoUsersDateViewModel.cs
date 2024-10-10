using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestRepeat.Models;
using TestRepeat.Views;

namespace TestRepeat.ViewModels
{
    public partial class InfoUsersDateViewModel : ViewModelBase
    {
        [ObservableProperty] List<UserCustom> listUsers;
        [ObservableProperty] List<Gender> listGenders;
        [ObservableProperty] string textFolderContent;
        [ObservableProperty] Gender selectedGender;

        List<UserCustom> copyUsers;
        public InfoUsersDateViewModel() { }
        public InfoUsersDateViewModel(List<User> users)
        {
            listUsers = ConvertList(users);
            copyUsers = listUsers;
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
        private List<UserCustom> ConvertList(List<User> users)
        {
            List<UserCustom> listUsers = new List<UserCustom>();
            foreach (var user in users)
            {
                UserCustom tempUser =
                    new UserCustom
                    {
                        Name = user.Name,
                        IdGender = user.IdGender,
                        IdGenderNavigation = user.IdGenderNavigation,
                        IdUser = user.IdUser,
                        IdUserNavigation = user.IdUserNavigation,
                        BirthDate = user.BirthDate,
                        ConvertImgUser = new Bitmap(new MemoryStream(user.ImgUser))
                    };
                if (user.IdUser == InfoUsersDate.CurrentUser.IdUser)
                {
                    tempUser.IsCanseled = false;
                }
                
                listUsers.Add(tempUser);
            }
            return listUsers;
        }
        partial void OnSelectedGenderChanged(Gender value) => Filters();
        partial void OnTextFolderContentChanged(string value) => Filters();
        void Filters()
        {
            ListUsers = copyUsers;
            if (!string.IsNullOrEmpty(textFolderContent)) ListUsers = ListUsers.Where(user => user.Name.Contains(textFolderContent)).ToList();
            if (selectedGender != null && selectedGender.IdGender != 0) ListUsers = ListUsers.Where(user => user.IdGenderNavigation == selectedGender).ToList();
        }
        public void ChangeUserDate(int idUser)
        {
            User changeableUser = MainWindowViewModel.Db_context.Users.FirstOrDefault(user => user.IdUser == idUser);
            MainWindowViewModel.Instance.Uc = new DateUser(changeableUser);
        }
        public void DeleteUser(int idUser)
        {
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